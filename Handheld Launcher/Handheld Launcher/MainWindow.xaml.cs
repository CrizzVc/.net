using Microsoft.UI;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Gaming.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using WinRT.Interop;

// Nuevos using para batería y red
using Windows.System.Power;
using Windows.Networking.Connectivity;
using Windows.Devices.Power;

namespace Handheld_Launcher
{
    public sealed partial class MainWindow : Microsoft.UI.Xaml.Window, INotifyPropertyChanged
    {
        // Todas las entradas
        public ObservableCollection<GameItem> Games { get; set; } = new ObservableCollection<GameItem>();

        // Colecci�n para el carrusel (ahora incluye todos, tambi�n el primero)
        public ObservableCollection<GameItem> OtherGames { get; set; } = new ObservableCollection<GameItem>();

        private GameItem _featuredGame;
        public GameItem FeaturedGame
        {
            get => _featuredGame;
            set
            {
                if (_featuredGame != value)
                {
                    _featuredGame = value;
                    OnPropertyChanged(nameof(FeaturedGame));
                }
            }
        }

        // Propiedad para la vista detalle
        private GameItem _selectedGame;
        public GameItem SelectedGame
        {
            get => _selectedGame;
            set
            {
                if (_selectedGame != value)
                {
                    _selectedGame = value;
                    OnPropertyChanged(nameof(SelectedGame));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        // Persistencia
        private bool _suspendSave = false;
        // Añadido LogoPath y Description al registro persistido
        private record PersistedGame(string Name, string Path, string IconPath, string BackgroundPath, string LogoPath, string Description);

        // Gamepad support
        private readonly List<Gamepad> _gamepads = new List<Gamepad>();
        private DispatcherTimer _gamepadTimer;
        private DateTime _lastGamepadAction = DateTime.MinValue;
        private const int GamepadActionCooldownMs = 250;

        // Guardamos el �ndice seleccionado anterior para restablecer estados visuales
        private int _lastSelectedIndex = -1;

        // Background manager helpers
        private bool _bgAIsActive = true; // true => A visible (opacity 1), B is the incoming
        private bool _libraryMode = false; // when true, background stays fixed to user choice
        private const int CrossfadeMs = 600;

        // NUEVO: timer para estado batería/red
        private DispatcherTimer _statusTimer;

        public MainWindow()
        {
            this.InitializeComponent();

            // En WinUI3, Window no tiene DataContext; asignamos al Grid ra�z (named in XAML)
            RootGrid.DataContext = this;

            // Asegurar foco para recibir KeyDown
            RootGrid.Loaded += (s, e) =>
            {
                RootGrid.Focus(FocusState.Programmatic);
                // asegurar selecci�n inicial
                EnsureSelection();
            };

            // Conectamos lista y eventos
            Games.CollectionChanged += Games_CollectionChanged;
            Games.CollectionChanged += Games_SaveOnCollectionChanged;

            // Cargamos juegos guardados (suspendamos guardado durante la carga)
            _suspendSave = true;
            CargarJuegosDesdeJson();
            _suspendSave = false;

            // Aplicar fondo guardado por el usuario (carga inicial)
            ApplyUserBackground(initial: true);

            // Iniciar splash overlay y esconderlo tras breve delay/selecci�n
            ShowSplashAndHideOnReady();

            // Inicializar timer de reloj
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                TimeTextBlock.Text = DateTime.Now.ToString("HH:mm");
            };
            timer.Start();

            // Inicializar detección y polling de gamepads
            Gamepad.GamepadAdded += Gamepad_GamepadAdded;
            Gamepad.GamepadRemoved += Gamepad_GamepadRemoved;
            StartGamepadPolling();

            // Inicializar timer de estado (batería / red)
            _statusTimer = new DispatcherTimer();
            _statusTimer.Interval = TimeSpan.FromSeconds(5);
            _statusTimer.Tick += (s, e) => UpdatePowerAndNetworkStatus();
            _statusTimer.Start();

            // Llamada inicial rápida
            UpdatePowerAndNetworkStatus();

            // Suscribir cambio de estado de red (opcional)
            try
            {
                NetworkInformation.NetworkStatusChanged += (obj) =>
                {
                    // se ejecuta en hilo de sistema; postear al dispatcher UI
                    _ = DispatcherQueue.TryEnqueue(() => UpdatePowerAndNetworkStatus());
                };
            }
            catch
            {
                // ignorar si no disponible
            }
        }

        // Nuevo método que actualiza batería y red
        private void UpdatePowerAndNetworkStatus()
        {
            // BATERÍA: intentamos obtener porcentaje y si está cargando
            try
            {
                // Intento directo con PowerManager (suele ser el más sencillo)
                int percent = -1;
                bool hasPercent = false;
                bool isCharging = false;

                try
                {
                    // RemainingChargePercent puede devolver -1 si no hay batería
                    percent = PowerManager.RemainingChargePercent;
                    if (percent >= 0) hasPercent = true;
                }
                catch { /* no disponible */ }

                try
                {
                    var ps = PowerManager.PowerSupplyStatus;
                    // PowerSupplyStatus.Adequate indica que la alimentación externa está disponible
                    isCharging = (ps == PowerSupplyStatus.Adequate);
                }
                catch { /* fallback */ }

                // Fallback con Battery API si falta info
                if (!hasPercent)
                {
                    try
                    {
                        var report = Battery.AggregateBattery.GetReport();
                        var rem = report.RemainingCapacityInMilliwattHours;
                        var full = report.FullChargeCapacityInMilliwattHours;
                        var chargeRate = report.ChargeRateInMilliwatts;
                        if (rem.HasValue && full.HasValue && full.Value > 0)
                        {
                            percent = (int)Math.Round((rem.Value * 100.0) / full.Value);
                            hasPercent = true;
                        }
                        // chargeRate > 0 normalmente indica que está cargando
                        if (chargeRate.HasValue)
                        {
                            isCharging = chargeRate.Value > 0;
                        }
                    }
                    catch { /* ignorar */ }
                }

                // Actualizar UI (dispatcher)
                _ = DispatcherQueue.TryEnqueue(() =>
                {
                    try
                    {
                        if (hasPercent)
                        {
                            BatteryPercent.Text = $"{percent}%";
                        }
                        else
                        {
                            BatteryPercent.Text = ""; // ocultar si no hay info
                        }

                        // Cambiar icon/colores según estado de carga / nivel
                        if (isCharging)
                        {
                            // glyph de "charging" (puede ajustarse)
                            BatteryIcon.Glyph = "\uEBA3"; // glyph aproximado para carga
                            BatteryIcon.Foreground = new SolidColorBrush(Colors.LightGreen);
                        }
                        else
                        {
                            BatteryIcon.Glyph = "\uEB10"; // glyph aproximado para batería
                            // color según umbral
                            if (hasPercent && percent <= 20)
                                BatteryIcon.Foreground = new SolidColorBrush(Colors.OrangeRed);
                            else
                                BatteryIcon.Foreground = new SolidColorBrush(Colors.LightGray);
                        }
                    }
                    catch { /* proteger UI */ }
                });
            }
            catch
            {
                // ignorar errores de lectura de batería
            }

            // RED: comprobamos si hay acceso a internet
            try
            {
                bool haveInternet = false;
                string profileName = string.Empty;

                try
                {
                    var profile = NetworkInformation.GetInternetConnectionProfile();
                    if (profile != null)
                    {
                        var level = profile.GetNetworkConnectivityLevel();
                        haveInternet = level == NetworkConnectivityLevel.InternetAccess || level == NetworkConnectivityLevel.ConstrainedInternetAccess;
                        profileName = profile.ProfileName ?? string.Empty;
                    }
                }
                catch { /* ignore */ }

                _ = DispatcherQueue.TryEnqueue(() =>
                {
                    try
                    {
                        if (haveInternet)
                        {
                            NetworkIcon.Glyph = "\uE701"; // glyph Wi-Fi (aprox.)
                            NetworkIcon.Foreground = new SolidColorBrush(Colors.LightGreen);
                            NetworkText.Text = ""; // opcional: mostrar nombre o dejar vacío
                        }
                        else
                        {
                            NetworkIcon.Glyph = "\uE8A7"; // glyph desconectado / error (aprox.)
                            NetworkIcon.Foreground = new SolidColorBrush(Colors.OrangeRed);
                            NetworkText.Text = ""; // opcional: "offline"
                        }
                    }
                    catch { }
                });
            }
            catch
            {
                // ignorar errores de red
            }
        }

        private async void ShowSplashAndHideOnReady()
        {
            // Splash visible por defecto (definido en XAML). Esperamos a que se carguen juegos y selecci�n.
            // Si no hay juegos, ocultamos splash tras un par de segundos igualmente.
            int waited = 0;
            while (waited < 3000) // m�ximo 3s
            {
                if (OtherGames.Count > 0 && CarouselGrid != null && CarouselGrid.SelectedItem != null)
                {
                    break;
                }
                await Task.Delay(150);
                waited += 150;
            }

            // Peque�a pausa para que el usuario vea la pantalla de inicio estilo PS5
            await Task.Delay(650);

            // Fade out splash
            var fade = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new Duration(TimeSpan.FromMilliseconds(400))
            };
            var sb = new Storyboard();
            sb.Children.Add(fade);
            Storyboard.SetTarget(fade, SplashOverlay);
            Storyboard.SetTargetProperty(fade, "Opacity");
            sb.Begin();

            // al completar, ocultar y liberar hit test
            await Task.Delay(420);
            SplashOverlay.Visibility = Visibility.Collapsed;
            SplashOverlay.IsHitTestVisible = false;
        }

        private void StartGamepadPolling()
        {
            // Mantener lista inicial de gamepads
            foreach (var gp in Gamepad.Gamepads) _gamepads.Add(gp);

            _gamepadTimer = new DispatcherTimer();
            _gamepadTimer.Interval = TimeSpan.FromMilliseconds(100);
            _gamepadTimer.Tick += GamepadTimer_Tick;
            _gamepadTimer.Start();
        }

        private void Gamepad_GamepadAdded(object sender, Gamepad e)
        {
            // A�adir al listado (asegurar no duplicados)
            if (!_gamepads.Contains(e)) _gamepads.Add(e);
        }

        private void Gamepad_GamepadRemoved(object sender, Gamepad e)
        {
            if (_gamepads.Contains(e)) _gamepads.Remove(e);
        }

        private void GamepadTimer_Tick(object sender, object e)
        {
            if (_gamepads.Count == 0) return;

            foreach (var gp in _gamepads)
            {
                try
                {
                    var reading = gp.GetCurrentReading();

                    // DPad o stick horizontal para navegar
                    bool left = (reading.Buttons & GamepadButtons.DPadLeft) == GamepadButtons.DPadLeft || reading.LeftThumbstickX < -0.6;
                    bool right = (reading.Buttons & GamepadButtons.DPadRight) == GamepadButtons.DPadRight || reading.LeftThumbstickX > 0.6;
                    bool aButton = (reading.Buttons & GamepadButtons.A) == GamepadButtons.A;

                    if (left && (DateTime.Now - _lastGamepadAction).TotalMilliseconds > GamepadActionCooldownMs)
                    {
                        SelectPrevious(); // navegaci�n por gamepad: no activamos efecto hover (usa SelectedKeyboard)
                        _lastGamepadAction = DateTime.Now;
                    }
                    else if (right && (DateTime.Now - _lastGamepadAction).TotalMilliseconds > GamepadActionCooldownMs)
                    {
                        SelectNext(); // navegaci�n por gamepad: no activamos efecto hover (usa SelectedKeyboard)
                        _lastGamepadAction = DateTime.Now;
                    }
                    else if (aButton && (DateTime.Now - _lastGamepadAction).TotalMilliseconds > GamepadActionCooldownMs)
                    {
                        // bot�n A -> abrir vista detalle del elemento seleccionado
                        var selected = CarouselGrid?.SelectedItem as GameItem;
                        if (selected != null)
                        {
                            MoveToFeatured(selected);
                            ShowDetail(selected);
                        }
                        _lastGamepadAction = DateTime.Now;
                    }
                }
                catch
                {
                    // Ignorar gamepads que fallen al leer
                }
            }
        }

        private void Games_SaveOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_suspendSave) return;
            GuardarJuegoEnJson();
        }

        private void Games_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Cuando cambie la colecci�n principal recalculamos featured y othergames
            UpdateFeaturedAndOthers();
            // asegurar que siempre haya selecci�n v�lida
            EnsureSelection();
        }

        private void UpdateFeaturedAndOthers()
        {
            if (Games.Count > 0)
            {
                FeaturedGame = Games[0];
                // Rellenar OtherGames con todos los juegos (incluye el featured)
                OtherGames.Clear();

                for (int i = 0; i < Games.Count; i++)
                {
                    var g = Games[i];
                    // Marcar el primer elemento como "grande" para que el DataTemplate lo haga doble ancho
                    g.IsLarge = (i == 0);
                    OtherGames.Add(g);
                }
            }
            else
            {
                FeaturedGame = null;
                OtherGames.Clear();
            }
        }

        private void MoveToFeatured(GameItem item)
        {
            if (item == null) return;

            // Si ya es featured, no hacemos nada
            if (Games.Count > 0 && Games[0] == item) return;

            // Mover el item al �ndice 0
            if (Games.Contains(item))
            {
                Games.Remove(item);
                Games.Insert(0, item);
            }
            else
            {
                // Si no estaba en la lista por alguna raz�n, lo insertamos arriba
                Games.Insert(0, item);
            }

            // UpdateFeaturedAndOthers se ejecutar� por el evento CollectionChanged
        }

        // Mostrar detalle (overlay)
        private void ShowDetail(GameItem selected)
        {
            SelectedGame = selected;

            DetailOverlay.Visibility = Visibility.Visible;
            DetailOverlay.IsHitTestVisible = true;

            // Cargar trailer si existe
            if (!string.IsNullOrEmpty(selected.TrailerUrl))
            {
                GameTrailerView.Source = new Uri(selected.TrailerUrl);
            }
            else
            {
                GameTrailerView.Source = null;
            }

            DetailOverlay.UpdateLayout();
            DetailOverlay.Focus(FocusState.Programmatic);
        }

        // Ocultar detalle
        private void HideDetail()
        {
            SelectedGame = null;
            DetailOverlay.Visibility = Visibility.Collapsed;
            DetailOverlay.IsHitTestVisible = false;
            // devolver foco al grid principal
            RootGrid.Focus(FocusState.Programmatic);
        }

        private bool _isMenuOpen = false;

        private void ToggleMenu_Click(object sender, Microsoft.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            LeftSidebar.Translation = _isMenuOpen
                ? new System.Numerics.Vector3(-250, 0, 0)
                : new System.Numerics.Vector3(0, 0, 0);

            _isMenuOpen = !_isMenuOpen;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            HomeView.Visibility = Visibility.Visible;
            LibraryView.Visibility = Visibility.Collapsed;
            _libraryMode = false;

            // Al volver al Home, mostrar el fondo correspondiente al item actualmente seleccionado
            if (CarouselGrid.SelectedItem is GameItem gi)
            {
                var idx = OtherGames.IndexOf(gi);
                if (idx >= 0) UpdateBackgroundForIndex(idx, immediate: false);
            }
            else
            {
                // si no hay selecci�n, aplicar fondo del usuario
                ApplyUserBackground();
            }
        }

        private void Library_Click(object sender, RoutedEventArgs e)
        {
            HomeView.Visibility = Visibility.Collapsed;
            LibraryView.Visibility = Visibility.Visible;
            _libraryMode = true;

            // En la vista de biblioteca fondo fijo al personalizado del usuario
            ApplyUserBackground();
        }

        private void CloseMenu()
        {
            LeftSidebar.Translation = new System.Numerics.Vector3(-250, 0, 0);
            _isMenuOpen = false;
        }

        private bool _isPanelOpen = false;

        private void ToggleSidePanel(object sender, RoutedEventArgs e)
        {
            if (_isPanelOpen)
            {
                LeftSidebar.Translation = new System.Numerics.Vector3(-250, 0, 0);
                _isPanelOpen = false;
            }
            else
            {
                LeftSidebar.Translation = new System.Numerics.Vector3(0, 0, 0);
                _isPanelOpen = true;
            }
        }

        // Handlers para el men� de fondo (corregir referencias XAML)
        private void Solid_Click(object sender, RoutedEventArgs e)
        {
            SetSolidColor();
        }

        private void Gradient_Click(object sender, RoutedEventArgs e)
        {
            SetGradient();
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            // SetImageBackground es async void, se puede invocar directamente
            SetImageBackground();
        }

        // Play desde la vista detalle
        private void PlaySelectedGame_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGame == null || string.IsNullOrEmpty(SelectedGame.Path)) return;
            try
            {
                Process.Start(new ProcessStartInfo(SelectedGame.Path) { UseShellExecute = true });
                HideDetail();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al iniciar {SelectedGame.Name}: {ex.Message}");
            }
        }

        private async void OpenGameOptions_Click(object sender, RoutedEventArgs e)
        {
            // Mostrar MenuFlyout con opciones: editar descripción, cambiar logotipo, carátula, fondo, eliminar
            var fe = sender as FrameworkElement;
            var game = fe?.DataContext as GameItem ?? SelectedGame;
            if (game == null) return;

            var menu = new MenuFlyout();

            var editDesc = new MenuFlyoutItem { Text = "Editar descripción" };
            editDesc.Click += async (s, ev) => await EditDescriptionAsync(game);

            var changeLogo = new MenuFlyoutItem { Text = "Cambiar logotipo" };
            changeLogo.Click += async (s, ev) => await PickAndSetLogoAsync(game);

            var changeIcon = new MenuFlyoutItem { Text = "Cambiar carátula" };
            changeIcon.Click += async (s, ev) => await PickAndSetIconAsync(game);

            var changeBg = new MenuFlyoutItem { Text = "Cambiar fondo" };
            changeBg.Click += async (s, ev) => await PickAndSetBackgroundAsync(game);

            // Nueva opción: añadir/editar URL del trailer
            var editTrailer = new MenuFlyoutItem { Text = "Añadir URL de trailer" };
            editTrailer.Click += async (s, ev) => await EditTrailerUrlAsync(game);

            var separator = new MenuFlyoutSeparator();

            var delete = new MenuFlyoutItem { Text = "Eliminar del launcher" };
            delete.Click += async (s, ev) =>
            {
                SelectedGame = game;
                await ConfirmDeleteAsync();
            };

            menu.Items.Add(editDesc);
            menu.Items.Add(changeLogo);
            menu.Items.Add(changeIcon);
            menu.Items.Add(changeBg);
            menu.Items.Add(editTrailer);
            menu.Items.Add(separator);
            menu.Items.Add(delete);

            menu.ShowAt(fe);
        }

        private async Task EditDescriptionAsync(GameItem game)
        {
            var tb = new TextBox
            {
                Text = game.Description ?? string.Empty,
                AcceptsReturn = true,
                TextWrapping = TextWrapping.Wrap,
                Height = 140
            };

            var dialog = new ContentDialog
            {
                Title = "Editar descripción",
                Content = tb,
                PrimaryButtonText = "Guardar",
                CloseButtonText = "Cancelar",
                XamlRoot = RootGrid.XamlRoot
            };

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                game.Description = tb.Text;
                GuardarJuegoEnJson();
            }
        }

        private async Task PickAndSetLogoAsync(GameItem game)
        {
            var picker = new FileOpenPicker();
            var hwnd = WindowNative.GetWindowHandle(this);
            InitializeWithWindow.Initialize(picker, hwnd);

            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".bmp");
            picker.FileTypeFilter.Add(".ico");

            var file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                try
                {
                    using IRandomAccessStream stream = await file.OpenReadAsync();
                    var bitmap = new BitmapImage();
                    await bitmap.SetSourceAsync(stream);
                    game.Logo = bitmap;
                    game.LogoPath = file.Path;

                    GuardarJuegoEnJson();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error cargando logotipo: {ex.Message}");
                }
            }
        }

        private void GuardarJuegoEnJson()
        {
            try
            {
                string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HandheldLauncher");
                Directory.CreateDirectory(folder);
                string filePath = Path.Combine(folder, "games.json");

                var list = Games
                    .Where(g => !string.IsNullOrEmpty(g.Path))
                    .Select(g => new PersistedGame(g.Name, g.Path, g.IconPath, g.BackgroundPath, g.LogoPath, g.Description))
                    .ToList();

                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(list, options);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error guardando juegos: {ex.Message}");
            }
        }

        private void CargarJuegosDesdeJson()
        {
            try
            {
                string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HandheldLauncher");
                string filePath = Path.Combine(folder, "games.json");
                if (!File.Exists(filePath)) return;

                var json = File.ReadAllText(filePath);
                var list = JsonSerializer.Deserialize<List<PersistedGame>>(json);
                if (list != null)
                {
                    foreach (var pg in list)
                    {
                        BitmapImage icon = new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png"));
                        if (!string.IsNullOrEmpty(pg.IconPath) && File.Exists(pg.IconPath))
                        {
                            try
                            {
                                icon = new BitmapImage(new Uri(pg.IconPath));
                            }
                            catch
                            {
                                // fallback a la imagen por defecto si falla
                                icon = new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png"));
                            }
                        }

                        // Cargar logo si existe
                        ImageSource logo = null;
                        if (!string.IsNullOrEmpty(pg.LogoPath) && File.Exists(pg.LogoPath))
                        {
                            try
                            {
                                logo = new BitmapImage(new Uri(pg.LogoPath));
                            }
                            catch
                            {
                                logo = null;
                            }
                        }

                        var game = new GameItem(pg.Name, pg.Path, icon, pg.IconPath, pg.BackgroundPath, pg.LogoPath, logo, pg.Description);

                        if (!string.IsNullOrEmpty(pg.BackgroundPath) && File.Exists(pg.BackgroundPath))
                        {
                            try
                            {
                                game.BackgroundImage = new BitmapImage(new Uri(pg.BackgroundPath));
                            }
                            catch
                            {
                                // ignorar si falla
                                game.BackgroundImage = null;
                            }
                        }

                        Games.Add(game);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error cargando juegos: {ex.Message}");
            }
        }

        // Navegaci�n por selecci�n enfocada y resaltada
        private bool IsSelectable(GameItem item) => item != null && !string.IsNullOrEmpty(item.Path);

        private int FindSelectableIndexFrom(int startIndex, int direction)
        {
            int i = startIndex;
            while (i >= 0 && i < OtherGames.Count)
            {
                if (IsSelectable(OtherGames[i])) return i;
                i += direction;
            }
            return -1;
        }

        // Helper: asegura que el contenedor est� visible dentro del ScrollViewer externo
        private void EnsureContainerVisible(GridViewItem container)
        {
            if (container == null || CarouselScrollViewer == null) return;

            // Forzar layout para asegurar medidas actualizadas
            try
            {
                container.UpdateLayout();
                CarouselScrollViewer.UpdateLayout();

                // Transformar la posici�n del contenedor respecto al ScrollViewer
                var transform = container.TransformToVisual(CarouselScrollViewer);
                Point pos = transform.TransformPoint(new Point(0, 0));

                double containerLeft = pos.X;
                double containerRight = containerLeft + container.ActualWidth;
                double viewportWidth = CarouselScrollViewer.ActualWidth;
                double current = CarouselScrollViewer.HorizontalOffset;
                double target = current;

                if (containerLeft < 0)
                {
                    // desplazar a la izquierda lo necesario
                    target = Math.Max(0, current + containerLeft);
                }
                else if (containerRight > viewportWidth)
                {
                    // desplazar a la derecha lo necesario
                    target = current + (containerRight - viewportWidth);
                }

                // Si target cambia, aplicarlo
                if (Math.Abs(target - current) > 0.5)
                {
                    CarouselScrollViewer.ChangeView(target, null, null, true);
                }
            }
            catch
            {
                // si algo falla (transform devuelve null o similar), caer silenciosamente
            }
        }

        // Ahora permitimos elegir si queremos dar foco (para evitar activar PointerOver cuando navegamos con teclado/gamepad)
        private void SelectIndex(int index, bool setFocus = true)
        {
            if (OtherGames.Count == 0 || CarouselGrid == null) return;
            index = Math.Max(0, Math.Min(OtherGames.Count - 1, index));
            // si el �ndice no es seleccionable, buscar el siguiente seleccionable hacia adelante
            if (!IsSelectable(OtherGames[index]))
            {
                int forward = FindSelectableIndexFrom(index + 1, 1);
                int backward = FindSelectableIndexFrom(index - 1, -1);
                index = forward >= 0 ? forward : backward;
                if (index < 0) return; // no hay items seleccionables
            }

            var item = OtherGames[index];

            // Guardamos el �ndice previo para restablecer su estado visual
            int previousIndex = _lastSelectedIndex;

            // Selecci�n real en el Grid
            CarouselGrid.SelectedItem = item;
            CarouselGrid.UpdateLayout();

            // Intentar obtener el contenedor; si no existe, forzamos UpdateLayout y lo obtenemos por �ndice
            var container = CarouselGrid.ContainerFromItem(item) as GridViewItem;
            if (container == null)
            {
                container = CarouselGrid.ContainerFromIndex(index) as GridViewItem;
            }

            // Asegurar visibilidad usando el ScrollViewer externo (si existe)
            if (container != null)
            {
                EnsureContainerVisible(container);
            }
            else
            {
                // fallback: usar ScrollIntoView del GridView si no hay contenedor
                try { CarouselGrid.ScrollIntoView(item, ScrollIntoViewAlignment.Leading); } catch { }
            }

            // Solo dar foco si explicitamente queremos (evita activar PointerOver/hover en navegaci�n por teclado/gamepad)
            if (setFocus)
            {
                container?.Focus(FocusState.Programmatic);
            }

            // Restablecer visual states y transform del elemento previamente seleccionado (si est� realizado)
            if (previousIndex >= 0 && previousIndex < OtherGames.Count)
            {
                var prevItem = OtherGames[previousIndex];
                if (!ReferenceEquals(prevItem, item))
                {
                    var prevContainer = CarouselGrid.ContainerFromItem(prevItem) as GridViewItem;
                    if (prevContainer != null)
                    {
                        // Forzar estado 'Unselected' para que reduzca la escala
                        VisualStateManager.GoToState(prevContainer, "Unselected", true);
                        // Tambi�n volver al estado normal del grupo CommonStates
                        VisualStateManager.GoToState(prevContainer, "Normal", true);

                        // Restaurar escala a 1.0 si se hab�a aplicado por navegci�n con teclado/gamepad
                        try
                        {
                            prevContainer.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);
                            prevContainer.RenderTransform = new ScaleTransform { ScaleX = 1.0, ScaleY = 1.0 };
                        }
                        catch { }
                    }
                }
            }

            // Aplicar estado/escala al nuevo contenedor
            if (container != null)
            {
                try
                {
                    container.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);
                    if (setFocus)
                    {
                        // navegaci�n por pointer/click: no escalado extra
                        container.RenderTransform = new ScaleTransform { ScaleX = 1.0, ScaleY = 1.0 };
                        VisualStateManager.GoToState(container, "Selected", true);
                    }
                    else
                    {
                        // Navegaci�n por teclado/gamepad: aplicar scale 1.05
                        container.RenderTransform = new ScaleTransform { ScaleX = 1.05, ScaleY = 1.05 };
                        VisualStateManager.GoToState(container, "SelectedKeyboard", true);
                    }
                }
                catch { /* proteger contra contenedores no listos */ }
            }

            // Actualizamos el �ndice seleccionado
            _lastSelectedIndex = index;

            // Actualizar background din�mico si estamos en Home (no en Library)
            if (!_libraryMode)
            {
                UpdateBackgroundForIndex(index, immediate: false);
            }
        }

        private void UpdateBackgroundForIndex(int index, bool immediate = false)
        {
            if (index < 0 || index >= OtherGames.Count) return;
            var gi = OtherGames[index];
            // Preferimos la imagen de fondo del juego; si no existe usar icono o fallback
            string path = null;
            if (!string.IsNullOrEmpty(gi.BackgroundPath) && File.Exists(gi.BackgroundPath))
            {
                path = gi.BackgroundPath;
            }
            else if (!string.IsNullOrEmpty(gi.IconPath) && File.Exists(gi.IconPath))
            {
                path = gi.IconPath;
            }

            if (string.IsNullOrEmpty(path))
            {
                // si no hay path de juego, aplicamos el fondo del usuario (si lo hay)
                ApplyUserBackground();
                return;
            }

            // Crossfade al fondo del juego
            CrossfadeToImagePath(path, immediate: immediate);
        }

        private void SelectNext()
        {
            int start = CarouselGrid.SelectedIndex;
            if (start < 0) start = 0; else start = start + 1;
            int idx = FindSelectableIndexFrom(start, 1);
            // No hacer wrap: si no hay m�s, no hacemos nada
            if (idx >= 0) SelectIndex(idx, setFocus: false); // navegaci�n por flechas/gamepad: no activar hover
        }

        private void SelectPrevious()
        {
            int start = CarouselGrid.SelectedIndex;
            if (start < 0) start = OtherGames.Count - 1; else start = start - 1;
            int idx = FindSelectableIndexFrom(start, -1);
            // No hacer wrap: si no hay m�s hacia atr�s, no hacemos nada
            if (idx >= 0) SelectIndex(idx, setFocus: false); // navegaci�n por flechas/gamepad: no activar hover
        }

        private void EnsureSelection()
        {
            // Si no hay selecci�n, seleccionar el primer juego seleccionable
            if (CarouselGrid == null) return;
            if (CarouselGrid.SelectedItem != null)
            {
                // actualizamos _lastSelectedIndex para reflejar la selecci�n actual
                var cur = CarouselGrid.SelectedItem as GameItem;
                _lastSelectedIndex = cur != null ? OtherGames.IndexOf(cur) : -1;
                return;
            }
            int idx = FindSelectableIndexFrom(0, 1);
            if (idx >= 0) SelectIndex(idx, setFocus: false);
        }

        private void ScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            // ahora navegamos a la izquierda seleccionando el juego anterior
            SelectPrevious();
        }

        private void ScrollRight_Click(object sender, RoutedEventArgs e)
        {
            // ahora navegamos a la derecha seleccionando el siguiente juego
            SelectNext();
        }

        private void CarouselGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clicked = e.ClickedItem as GameItem;
            if (clicked != null)
            {
                // seleccionar y enfocar el item clicado usando la versi�n que s� da foco
                int clickedIndex = OtherGames.IndexOf(clicked);
                if (clickedIndex >= 0) SelectIndex(clickedIndex, setFocus: true);

                // Asegurar que el contenedor tenga foco para que el usuario pueda interactuar si ha hecho click
                var container = CarouselGrid.ContainerFromItem(clicked) as GridViewItem;
                container?.Focus(FocusState.Programmatic);

                // Mover a featured (opcional) y mostrar detalle en overlay
                MoveToFeatured(clicked);
                ShowDetail(clicked);

                // Forzar background al seleccionado (home only)
                if (!_libraryMode)
                {
                    UpdateBackgroundForIndex(clickedIndex, immediate: false);
                }
            }
        }

        private async void AddGame_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            var hwnd = WindowNative.GetWindowHandle(this);
            InitializeWithWindow.Initialize(picker, hwnd);

            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            picker.FileTypeFilter.Add(".exe");
            picker.FileTypeFilter.Add(".lnk");

            var file = await picker.PickSingleFileAsync();

            if (file != null)
            {
                string path = file.Path;
                string name = file.DisplayName;

                var icon = new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png"));
                var newGame = new GameItem(name, path, icon, null, null);
                Games.Add(newGame);

                // Guardado gestionado por Games_SaveOnCollectionChanged handler
            }
        }

        // Handler para cambiar la car�tula desde el bot�n espec�fico (ha sido mantenido para compatibilidad)
        private async void ChangeCover_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var game = btn?.DataContext as GameItem;
            if (game == null) return;

            await PickAndSetIconAsync(game);
        }

        // Bot�n de tres puntos (ahora usado en el overlay). DataContext apunta al GameItem (o tomar� SelectedGame)
        private async void EditGame_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var game = btn?.DataContext as GameItem ?? SelectedGame;
            if (game == null) return;

            var dialog = new ContentDialog
            {
                Title = "Editar im�genes",
                PrimaryButtonText = "Cambiar car�tula",
                SecondaryButtonText = "Cambiar fondo",
                CloseButtonText = "Cancelar",
                XamlRoot = RootGrid.XamlRoot
            };

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                await PickAndSetIconAsync(game);
            }
            else if (result == ContentDialogResult.Secondary)
            {
                await PickAndSetBackgroundAsync(game);
            }
        }

        private async Task PickAndSetIconAsync(GameItem game)
        {
            var picker = new FileOpenPicker();
            var hwnd = WindowNative.GetWindowHandle(this);
            InitializeWithWindow.Initialize(picker, hwnd);

            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".bmp");
            picker.FileTypeFilter.Add(".ico");

            var file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                try
                {
                    using IRandomAccessStream stream = await file.OpenReadAsync();
                    var bitmap = new BitmapImage();
                    await bitmap.SetSourceAsync(stream);
                    game.Icon = bitmap;
                    game.IconPath = file.Path;

                    GuardarJuegoEnJson();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error cargando imagen: {ex.Message}");
                }
            }
        }

        private async Task PickAndSetBackgroundAsync(GameItem game)
        {
            var picker = new FileOpenPicker();
            var hwnd = WindowNative.GetWindowHandle(this);
            InitializeWithWindow.Initialize(picker, hwnd);

            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".bmp");

            var file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                try
                {
                    using IRandomAccessStream stream = await file.OpenReadAsync();
                    var bitmap = new BitmapImage();
                    await bitmap.SetSourceAsync(stream);
                    game.BackgroundImage = bitmap;
                    game.BackgroundPath = file.Path;

                    GuardarJuegoEnJson();

                    // Si estamos en Home y el juego es el seleccionado actual, actualizar fondo inmediatamente
                    if (!_libraryMode)
                    {
                        var idx = OtherGames.IndexOf(game);
                        if (idx >= 0 && idx == _lastSelectedIndex)
                        {
                            CrossfadeToImagePath(file.Path, immediate: false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error cargando imagen de fondo: {ex.Message}");
                }
            }
        }

        // Navegación por juego resaltado en Home (no en Library)
        private void LibraryGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clicked = e.ClickedItem as GameItem;
            if (clicked == null) return;

            // En la vista de biblioteca mostramos el overlay de detalle en lugar de ejecutar el juego directamente
            MoveToFeatured(clicked);
            ShowDetail(clicked);
        }

        // KeyDown handler para flechas del teclado (y Escape para cerrar detalle)
        private void RootGrid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Left)
            {
                SelectPrevious(); // navegaci�n por teclado: no activar hover
                e.Handled = true;
            }
            else if (e.Key == Windows.System.VirtualKey.Right)
            {
                SelectNext(); // navegaci�n por teclado: no activar hover
                e.Handled = true;
            }
            else if (e.Key == Windows.System.VirtualKey.Escape)
            {
                if (DetailOverlay != null && DetailOverlay.Visibility == Visibility.Visible)
                {
                    HideDetail();
                    e.Handled = true;
                }
            }
            else if (e.Key == Windows.System.VirtualKey.Enter)
            {
                // Al pulsar Enter, abrir la vista de detalle del juego seleccionado
                var selected = CarouselGrid?.SelectedItem as GameItem;
                if (selected != null)
                {
                    // Alineamos comportamiento con click: mover a featured y mostrar detalle
                    MoveToFeatured(selected);
                    ShowDetail(selected);
                    e.Handled = true;
                }
            }
        }

        private void HideDetail_Click(object sender, RoutedEventArgs e)
        {
            DetailOverlay.Visibility = Visibility.Collapsed;
            DetailOverlay.IsHitTestVisible = false;
        }

        // --- Background management: crossfades y aplicaci�n de fondo del usuario ---

        private void ApplyUserBackground(bool initial = false)
        {
            // Leer settings
            var local = ApplicationData.Current.LocalSettings;
            var type = local.Values.TryGetValue("BackgroundType", out var t) ? (t as string) : null;
            var imagePath = local.Values.TryGetValue("ImagePath", out var p) ? (p as string) : null;

            if (string.Equals(type, "Image", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                // Establecer imagen de usuario en ambos layers (sin animar en initial)
                if (initial)
                {
                    BackgroundImageA.Source = new BitmapImage(new Uri(imagePath));
                    BackgroundImageA.Opacity = 1;
                    BackgroundImageB.Source = null;
                    BackgroundImageB.Opacity = 0;
                    _bgAIsActive = true;
                }
                else
                {
                    CrossfadeToImagePath(imagePath, immediate: false);
                }
            }
            else if (string.Equals(type, "Gradient", StringComparison.OrdinalIgnoreCase))
            {
                // Usar RootGrid.Background (se mantiene como fallback)
                RootGrid.Background = new LinearGradientBrush
                {
                    StartPoint = new Point(0, 0),
                    EndPoint = new Point(0, 1),
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop { Color = Color.FromArgb(255, 20, 20, 40), Offset = 0 },
                        new GradientStop { Color = Color.FromArgb(255, 8, 8, 18), Offset = 1 }
                    }
                };
                // ocultar im�genes
                BackgroundImageA.Source = null;
                BackgroundImageA.Opacity = 0;
                BackgroundImageB.Source = null;
                BackgroundImageB.Opacity = 0;
            }
            else
            {
                // Solid por defecto
                RootGrid.Background = new SolidColorBrush(Colors.DarkSlateBlue);
                BackgroundImageA.Source = null;
                BackgroundImageA.Opacity = 0;
                BackgroundImageB.Source = null;
                BackgroundImageB.Opacity = 0;
            }
        }

        private void SetSolidColor()
        {
            // Oculta im�genes y aplica color s�lido
            BackgroundImageA.Source = null;
            BackgroundImageA.Opacity = 0;
            BackgroundImageB.Source = null;
            BackgroundImageB.Opacity = 0;
            RootGrid.Background = new SolidColorBrush(Colors.DarkSlateBlue);
            ApplicationData.Current.LocalSettings.Values["BackgroundType"] = "Solid";
            ApplicationData.Current.LocalSettings.Values.Remove("ImagePath");
        }

        private void SetGradient()
        {
            // Gradiente m�s intenso para mayor presencia
            var brush = new LinearGradientBrush();
            brush.StartPoint = new Windows.Foundation.Point(0, 0);
            brush.EndPoint = new Windows.Foundation.Point(0, 1);

            brush.GradientStops.Add(new GradientStop
            {
                Color = Color.FromArgb(255, 24, 24, 48),
                Offset = 0
            });

            brush.GradientStops.Add(new GradientStop
            {
                Color = Color.FromArgb(255, 8, 8, 18),
                Offset = 1
            });

            // Ocultar im�genes y usar RootGrid background
            BackgroundImageA.Source = null;
            BackgroundImageA.Opacity = 0;
            BackgroundImageB.Source = null;
            BackgroundImageB.Opacity = 0;

            RootGrid.Background = brush;

            ApplicationData.Current.LocalSettings.Values["BackgroundType"] = "Gradient";
            ApplicationData.Current.LocalSettings.Values.Remove("ImagePath");
        }

        private async void SetImageBackground()
        {
            var picker = new FileOpenPicker();
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            InitializeWithWindow.Initialize(picker, hwnd);

            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");

            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                var bitmap = new BitmapImage(new Uri(file.Path));
                // Aplicar imagen del usuario con crossfade suave
                CrossfadeToImagePath(file.Path, immediate: true);

                ApplicationData.Current.LocalSettings.Values["BackgroundType"] = "Image";
                ApplicationData.Current.LocalSettings.Values["ImagePath"] = file.Path;
            }
        }

        private void CrossfadeToImagePath(string path, int durationMs = CrossfadeMs, bool immediate = false)
        {
            try
            {
                if (string.IsNullOrEmpty(path) || !File.Exists(path)) return;

                var nextImage = _bgAIsActive ? BackgroundImageB : BackgroundImageA;
                var currImage = _bgAIsActive ? BackgroundImageA : BackgroundImageB;

                nextImage.Source = new BitmapImage(new Uri(path));

                if (immediate)
                {
                    // Sin animaci�n: set next fully visible
                    nextImage.Opacity = 1;
                    currImage.Opacity = 0;
                    _bgAIsActive = !_bgAIsActive;
                    return;
                }

                // Animaciones de opacidad
                var fadeIn = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = new Duration(TimeSpan.FromMilliseconds(durationMs)),
                    EasingFunction = new ExponentialEase { EasingMode = EasingMode.EaseOut }
                };
                var fadeOut = new DoubleAnimation
                {
                    From = 1,
                    To = 0,
                    Duration = new Duration(TimeSpan.FromMilliseconds(durationMs)),
                    EasingFunction = new ExponentialEase { EasingMode = EasingMode.EaseOut }
                };

                var sb = new Storyboard();
                sb.Children.Add(fadeIn);
                sb.Children.Add(fadeOut);

                Storyboard.SetTarget(fadeIn, nextImage);
                Storyboard.SetTargetProperty(fadeIn, "Opacity");

                Storyboard.SetTarget(fadeOut, currImage);
                Storyboard.SetTargetProperty(fadeOut, "Opacity");

                sb.Begin();

                _bgAIsActive = !_bgAIsActive;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en CrossfadeToImagePath: {ex.Message}");
            }
        }

        private async Task ConfirmDeleteAsync()
        {
            // If no selection, nothing to do
            if (SelectedGame == null) return;

            var dialog = new ContentDialog
            {
                Title = "Eliminar juego",
                Content = $"¿Desea eliminar \"{SelectedGame.Name}\" del launcher?",
                PrimaryButtonText = "Eliminar",
                CloseButtonText = "Cancelar",
                XamlRoot = RootGrid.XamlRoot
            };

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                try
                {
                    // Remove from collection (this triggers save via handler)
                    Games.Remove(SelectedGame);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error eliminando juego: {ex.Message}");
                    // Aun si falla, intentamos persistir
                }
                finally
                {
                    // Asegurar que el overlay se cierre y que no quede la referencia
                    HideDetail();
                    // Guardar por si el handler no se ejecuta
                    GuardarJuegoEnJson();
                }
            }
        }

        // Nuevo método para añadir/editar la URL del trailer
        private async Task EditTrailerUrlAsync(GameItem game)
        {
            var tb = new TextBox
            {
                Text = game.TrailerUrl ?? string.Empty,
                AcceptsReturn = false,
                PlaceholderText = "https://ejemplo.com/trailer",
                TextWrapping = TextWrapping.NoWrap,
                Height = 32
            };

            var dialog = new ContentDialog
            {
                Title = "Añadir/Editar URL del trailer",
                Content = tb,
                PrimaryButtonText = "Guardar",
                CloseButtonText = "Cancelar",
                XamlRoot = RootGrid.XamlRoot
            };

            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var url = tb.Text?.Trim();
                if (string.IsNullOrEmpty(url))
                {
                    game.TrailerUrl = null;
                }
                else
                {
                    // Intento básico de normalización: si falta esquema, probar con https://
                    try
                    {
                        // Validar/normalizar URI
                        if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                            !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                        {
                            url = "https://" + url;
                        }
                        var uri = new Uri(url);
                        game.TrailerUrl = uri.AbsoluteUri;
                    }
                    catch
                    {
                        // Si no es una URI válida, conservar el texto tal cual (opcional)
                        game.TrailerUrl = url;
                    }
                }

                // Persistir cambio
                GuardarJuegoEnJson();

                // Si el overlay está mostrando este juego, actualizar la vista del trailer
                if (SelectedGame == game)
                {
                    if (!string.IsNullOrEmpty(game.TrailerUrl))
                    {
                        try
                        {
                            GameTrailerView.Source = new Uri(game.TrailerUrl);
                        }
                        catch { GameTrailerView.Source = null; }
                    }
                    else
                    {
                        GameTrailerView.Source = null;
                    }
                }
            }
        }
    }
}
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Windows.Storage.Pickers;
using WinRT.Interop;
using System.Linq;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Gaming.Input;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml.Controls.Primitives;
using Windows.Foundation;
using System.Threading.Tasks;

namespace Handheld_Launcher
{
    public sealed partial class MainWindow : Microsoft.UI.Xaml.Window, INotifyPropertyChanged
    {
        // Todas las entradas
        public ObservableCollection<GameItem> Games { get; set; } = new ObservableCollection<GameItem>();

        // Colección para el carrusel (ahora incluye todos, también el primero)
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
        private record PersistedGame(string Name, string Path, string IconPath, string BackgroundPath);

        // Gamepad support
        private readonly List<Gamepad> _gamepads = new List<Gamepad>();
        private DispatcherTimer _gamepadTimer;
        private DateTime _lastGamepadAction = DateTime.MinValue;
        private const int GamepadActionCooldownMs = 250;

        // Guardamos el índice seleccionado anterior para restablecer estados visuales
        private int _lastSelectedIndex = -1;

        public MainWindow()
        {
            this.InitializeComponent();

            // En WinUI3, Window no tiene DataContext; asignamos al Grid raíz (named in XAML)
            RootGrid.DataContext = this;

            // Asegurar foco para recibir KeyDown
            RootGrid.Loaded += (s, e) =>
            {
                RootGrid.Focus(FocusState.Programmatic);
                // asegurar selección inicial
                EnsureSelection();
            };

            // Conectamos lista y eventos
            Games.CollectionChanged += Games_CollectionChanged;
            Games.CollectionChanged += Games_SaveOnCollectionChanged;

            // Cargamos juegos guardados (suspendimos guardado durante la carga)
            _suspendSave = true;
            CargarJuegosDesdeJson();
            _suspendSave = false;

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
            // Añadir al listado (asegurar no duplicados)
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

                    if (left && (DateTime.Now - _lastGamepadAction).TotalMilliseconds > GamepadActionCooldownMs)
                    {
                        SelectPrevious(); // navegación por gamepad: no activamos efecto hover
                        _lastGamepadAction = DateTime.Now;
                    }
                    else if (right && (DateTime.Now - _lastGamepadAction).TotalMilliseconds > GamepadActionCooldownMs)
                    {
                        SelectNext(); // navegación por gamepad: no activamos efecto hover
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
            // Cuando cambie la colección principal recalculamos featured y othergames
            UpdateFeaturedAndOthers();
            // asegurar que siempre haya selección válida
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

            // Mover el item al índice 0
            if (Games.Contains(item))
            {
                Games.Remove(item);
                Games.Insert(0, item);
            }
            else
            {
                // Si no estaba en la lista por alguna razón, lo insertamos arriba
                Games.Insert(0, item);
            }

            // UpdateFeaturedAndOthers se ejecutará por el evento CollectionChanged
        }

        // Mostrar detalle (overlay)
        private void ShowDetail(GameItem game)
        {
            if (game == null) return;
            SelectedGame = game;
            DetailOverlay.Visibility = Visibility.Visible;
            DetailOverlay.IsHitTestVisible = true;
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
            if (SelectedGame == null) return;

            var dialog = new ContentDialog
            {
                Title = SelectedGame.Name,
                Content = "Selecciona una opción",
                PrimaryButtonText = "Cambiar carátula",
                SecondaryButtonText = "Cambiar fondo",
                CloseButtonText = "Eliminar del launcher",
                DefaultButton = ContentDialogButton.Primary,
                XamlRoot = RootGrid.XamlRoot
            };

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                await PickAndSetIconAsync(SelectedGame);
            }
            else if (result == ContentDialogResult.Secondary)
            {
                await PickAndSetBackgroundAsync(SelectedGame);
            }
            else if (result == ContentDialogResult.None)
            {
                await ConfirmDeleteAsync();
            }
        }

        private async Task ConfirmDeleteAsync()
        {
            if (SelectedGame == null) return;

            var confirmDialog = new ContentDialog
            {
                Title = "Eliminar juego",
                Content = $"¿Seguro que deseas eliminar \"{SelectedGame.Name}\" del launcher?",
                PrimaryButtonText = "Eliminar",
                CloseButtonText = "Cancelar",
                DefaultButton = ContentDialogButton.Close,
                XamlRoot = RootGrid.XamlRoot
            };

            var result = await confirmDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                DeleteSelectedGame();
            }
        }

        private void DeleteSelectedGame()
        {
            if (SelectedGame == null) return;

            var gameToDelete = SelectedGame;

            HideDetail();

            Games.Remove(gameToDelete);

            GuardarJuegoEnJson();
        }

        // Navegación por selección enfocada y resaltada
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

        // Helper: asegura que el contenedor esté visible dentro del ScrollViewer externo
        private void EnsureContainerVisible(GridViewItem container)
        {
            if (container == null || CarouselScrollViewer == null) return;

            // Forzar layout para asegurar medidas actualizadas
            try
            {
                container.UpdateLayout();
                CarouselScrollViewer.UpdateLayout();

                // Transformar la posición del contenedor respecto al ScrollViewer
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
            // si el índice no es seleccionable, buscar el siguiente seleccionable hacia adelante
            if (!IsSelectable(OtherGames[index]))
            {
                int forward = FindSelectableIndexFrom(index + 1, 1);
                int backward = FindSelectableIndexFrom(index - 1, -1);
                index = forward >= 0 ? forward : backward;
                if (index < 0) return; // no hay items seleccionables
            }

            var item = OtherGames[index];

            // Guardamos el índice previo para restablecer su estado visual
            int previousIndex = _lastSelectedIndex;

            // Selección real en el Grid
            CarouselGrid.SelectedItem = item;
            CarouselGrid.UpdateLayout();

            // Intentar obtener el contenedor; si no existe, forzamos UpdateLayout y lo obtenemos por índice
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

            // Solo dar foco si explicitamente queremos (evita activar PointerOver/hover en navegación por teclado/gamepad)
            if (setFocus)
            {
                container?.Focus(FocusState.Programmatic);
            }

            // Restablecer visual states del elemento previamente seleccionado (si está realizado)
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
                        // También volver al estado normal del grupo CommonStates
                        VisualStateManager.GoToState(prevContainer, "Normal", true);
                    }
                }
            }

            // Aplicar estado 'Selected' o 'SelectedKeyboard' al nuevo contenedor
            if (container != null)
            {
                if (setFocus)
                {
                    VisualStateManager.GoToState(container, "Selected", true);
                }
                else
                {
                    // Navegación por teclado/gamepad: usar zoom menor para evitar recorte
                    VisualStateManager.GoToState(container, "SelectedKeyboard", true);
                }
            }

            // Actualizamos el índice seleccionado
            _lastSelectedIndex = index;
        }

        private void SelectNext()
        {
            int start = CarouselGrid.SelectedIndex;
            if (start < 0) start = 0; else start = start + 1;
            int idx = FindSelectableIndexFrom(start, 1);
            // No hacer wrap: si no hay más, no hacemos nada
            if (idx >= 0) SelectIndex(idx, setFocus: false); // navegación por flechas/gamepad: no activar hover
        }

        private void SelectPrevious()
        {
            int start = CarouselGrid.SelectedIndex;
            if (start < 0) start = OtherGames.Count - 1; else start = start - 1;
            int idx = FindSelectableIndexFrom(start, -1);
            // No hacer wrap: si no hay más hacia atrás, no hacemos nada
            if (idx >= 0) SelectIndex(idx, setFocus: false); // navegación por flechas/gamepad: no activar hover
        }

        private void EnsureSelection()
        {
            // Si no hay selección, seleccionar el primer juego seleccionable
            if (CarouselGrid == null) return;
            if (CarouselGrid.SelectedItem != null)
            {
                // actualizamos _lastSelectedIndex para reflejar la selección actual
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
                // seleccionar y enfocar el item clicado usando la versión que sí da foco
                int clickedIndex = OtherGames.IndexOf(clicked);
                if (clickedIndex >= 0) SelectIndex(clickedIndex, setFocus: true);

                // Asegurar que el contenedor tenga foco para que el usuario pueda interactuar si ha hecho click
                var container = CarouselGrid.ContainerFromItem(clicked) as GridViewItem;
                container?.Focus(FocusState.Programmatic);

                // Mover a featured (opcional) y mostrar detalle en overlay
                MoveToFeatured(clicked);
                ShowDetail(clicked);
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

        // Handler para cambiar la carátula desde el botón específico (ha sido mantenido para compatibilidad)
        private async void ChangeCover_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var game = btn?.DataContext as GameItem;
            if (game == null) return;

            await PickAndSetIconAsync(game);
        }

        // Botón de tres puntos (ahora usado en el overlay). DataContext apunta al GameItem (o tomará SelectedGame)
        private async void EditGame_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var game = btn?.DataContext as GameItem ?? SelectedGame;
            if (game == null) return;

            var dialog = new ContentDialog
            {
                Title = "Editar imágenes",
                PrimaryButtonText = "Cambiar carátula",
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
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error cargando imagen de fondo: {ex.Message}");
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
                    .Select(g => new PersistedGame(g.Name, g.Path, g.IconPath, g.BackgroundPath))
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

                        var game = new GameItem(pg.Name, pg.Path, icon, pg.IconPath, pg.BackgroundPath);

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

        private void GamesGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedGame = e.ClickedItem as GameItem;
            if (selectedGame != null)
            {
                try
                {
                    Process.Start(new ProcessStartInfo(selectedGame.Path) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error al iniciar {selectedGame.Name}: {ex.Message}");
                }
            }
        }

        // KeyDown handler para flechas del teclado (y Escape para cerrar detalle)
        private void RootGrid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Left)
            {
                SelectPrevious(); // navegación por teclado: no activar hover
                e.Handled = true;
            }
            else if (e.Key == Windows.System.VirtualKey.Right)
            {
                SelectNext(); // navegación por teclado: no activar hover
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
        }

        private void HideDetail_Click(object sender, global::Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            HideDetail();
        }
    }
}
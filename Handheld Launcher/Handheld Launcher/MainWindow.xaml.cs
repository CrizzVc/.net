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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        // Persistencia
        private bool _suspendSave = false;
        private record PersistedGame(string Name, string Path, string IconPath);

        // Gamepad support
        private readonly List<Gamepad> _gamepads = new List<Gamepad>();
        private DispatcherTimer _gamepadTimer;
        private DateTime _lastGamepadAction = DateTime.MinValue;
        private const int GamepadActionCooldownMs = 250;

        public MainWindow()
        {
            this.InitializeComponent();

            // En WinUI3, Window no tiene DataContext; asignamos al Grid raíz (named in XAML)
            RootGrid.DataContext = this;

            // Asegurar foco para recibir KeyDown
            RootGrid.Loaded += (s, e) => RootGrid.Focus(FocusState.Programmatic);

            // Conectamos lista y eventos
            Games.CollectionChanged += Games_CollectionChanged;
            Games.CollectionChanged += Games_SaveOnCollectionChanged;

            // Cargamos juegos guardados (suspendemos guardado durante la carga)
            _suspendSave = true;
            CargarJuegosDesdeJson();
            _suspendSave = false;

            // Aseguramos que exista el placeholder en primer lugar (sin Path)
            if (Games.Count == 0 || !string.IsNullOrEmpty(Games[0].Path))
            {
                Games.Insert(0, new GameItem("AGREGAR", null, new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png")), null));
            }

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
                        ScrollLeft_Click(null, null);
                        _lastGamepadAction = DateTime.Now;
                    }
                    else if (right && (DateTime.Now - _lastGamepadAction).TotalMilliseconds > GamepadActionCooldownMs)
                    {
                        ScrollRight_Click(null, null);
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

        private void ScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            // Desplaza el ScrollViewer a la izquierda una cantidad (ajusta step según tus items)
            double step = 420;
            double target = Math.Max(0, CarouselScrollViewer.HorizontalOffset - step);
            CarouselScrollViewer.ChangeView(target, null, null, true);
        }

        private void ScrollRight_Click(object sender, RoutedEventArgs e)
        {
            double step = 420;
            double max = CarouselScrollViewer.ExtentWidth - CarouselScrollViewer.ViewportWidth;
            double target = Math.Min(max, CarouselScrollViewer.HorizontalOffset + step);
            CarouselScrollViewer.ChangeView(target, null, null, true);
        }

        private void CarouselGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clicked = e.ClickedItem as GameItem;
            if (clicked != null)
            {
                MoveToFeatured(clicked);
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
                var newGame = new GameItem(name, path, icon, null);
                Games.Add(newGame);

                // Guardado gestionado por Games_SaveOnCollectionChanged handler
            }
        }

        // Handler para cambiar la carátula de un juego desde la UI
        private async void ChangeCover_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var game = btn?.DataContext as GameItem;
            if (game == null) return;

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

        private void GuardarJuegoEnJson()
        {
            try
            {
                string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HandheldLauncher");
                Directory.CreateDirectory(folder);
                string filePath = Path.Combine(folder, "games.json");

                var list = Games
                    .Where(g => !string.IsNullOrEmpty(g.Path))
                    .Select(g => new PersistedGame(g.Name, g.Path, g.IconPath))
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

                        Games.Add(new GameItem(pg.Name, pg.Path, icon, pg.IconPath));
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

        // KeyDown handler para flechas del teclado
        private void RootGrid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Left)
            {
                ScrollLeft_Click(null, null);
                e.Handled = true;
            }
            else if (e.Key == Windows.System.VirtualKey.Right)
            {
                ScrollRight_Click(null, null);
                e.Handled = true;
            }
        }
    }
}
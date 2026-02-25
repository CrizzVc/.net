using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using Windows.Storage.Pickers;
using WinRT.Interop;
using System.Linq;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Collections.Generic;

namespace Handheld_Launcher
{
    public sealed partial class MainWindow : Microsoft.UI.Xaml.Window, INotifyPropertyChanged
    {
        // Todas las entradas
        public ObservableCollection<GameItem> Games { get; set; } = new ObservableCollection<GameItem>();

        // Colección para el carrusel (todos excepto el primero)
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
        private record PersistedGame(string Name, string Path);

        public MainWindow()
        {
            this.InitializeComponent();

            // En WinUI3, Window no tiene DataContext; asignamos al Grid raíz (named in XAML)
            RootGrid.DataContext = this;

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
                Games.Insert(0, new GameItem("AGREGAR", null, new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png"))));
            }

            // Inicializar timer de reloj
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                TimeTextBlock.Text = DateTime.Now.ToString("HH:mm");
            };
            timer.Start();
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
                // Rellenar OtherGames
                OtherGames.Clear();
                foreach (var g in Games.Skip(1))
                    OtherGames.Add(g);
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
            double step = 300;
            double target = Math.Max(0, CarouselScrollViewer.HorizontalOffset - step);
            CarouselScrollViewer.ChangeView(target, null, null, true);
        }

        private void ScrollRight_Click(object sender, RoutedEventArgs e)
        {
            double step = 300;
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

                var newGame = new GameItem(name, path, new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png")));
                Games.Add(newGame);

                // Guardado gestionado por Games_SaveOnCollectionChanged handler
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
                    .Select(g => new PersistedGame(g.Name, g.Path))
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
                        // Por simplicidad usamos icono por defecto; puedes mejorar extrayendo el icono real.
                        var icon = new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png"));
                        Games.Add(new GameItem(pg.Name, pg.Path, icon));
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
    }
}
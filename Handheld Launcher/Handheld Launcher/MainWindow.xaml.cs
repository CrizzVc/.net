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
using WinRT.Interop; // Necesario para asociar la ventana
using System.Text.Json;

namespace Handheld_Launcher
{
    public sealed partial class MainWindow : Microsoft.UI.Xaml.Window
    {
        // Esta es la lista que leerá el GridView
        public ObservableCollection<GameItem> Games { get; set; } = new ObservableCollection<GameItem>();

        public MainWindow()
        {
            this.InitializeComponent();
            GamesGrid.ItemsSource = Games;
            // Ejemplo: Escanea una carpeta (Cámbiala por una real en tu PC)
            ScanGames(@"C:\Games");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) => {
                TimeTextBlock.Text = DateTime.Now.ToString("HH:mm");
            };
            timer.Start();

        }

        private void ScanGames(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                var files = Directory.GetFiles(folderPath, "*.exe");
                foreach (var file in files)
                {
                    // Extraer el icono del archivo .exe
                    Icon sysIcon = Icon.ExtractAssociatedIcon(file);
                    SoftwareBitmapSource bitmapSource = new SoftwareBitmapSource();

                    // Convertimos el icono de Windows a algo que WinUI entienda
                    using (var stream = new MemoryStream())
                    {
                        sysIcon.ToBitmap().Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        // Aquí podrías implementar una función async para cargar el bitmap
                        // Pero para empezar, usaremos una imagen por defecto si no carga
                    }

                    Games.Add(new GameItem(Path.GetFileNameWithoutExtension(file), file, null));
                }
            }
        }

        private async void AddGame_Click(object sender, RoutedEventArgs e)
        {
            // 1. Crear el selector de archivos
            var picker = new FileOpenPicker();

            // IMPORTANTE: En WinUI 3 hay que asociar el picker con la ventana actual
            var hwnd = WindowNative.GetWindowHandle(this);
            InitializeWithWindow.Initialize(picker, hwnd);

            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
            picker.FileTypeFilter.Add(".exe");
            picker.FileTypeFilter.Add(".lnk"); // También accesos directos

            // 2. Abrir el buscador
            var file = await picker.PickSingleFileAsync();

            if (file != null)
            {
                string path = file.Path;
                string name = file.DisplayName;

                // 3. Crear el objeto y añadirlo a la lista visual
                // Usaremos una imagen por defecto por ahora
                var newGame = new GameItem(name, path, new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png")));

                Games.Add(newGame);
                System.Diagnostics.Debug.WriteLine($"Juego añadido: {newGame.Name} - Total: {Games.Count}");

                // Opcional: Guardar en una base de datos o archivo JSON para que no se borre al cerrar
                GuardarJuegoEnJson(name, path);
            }
        }


        private void GuardarJuegoEnJson(string nombre, string ruta)
        {
            // Puedes crear una carpeta en AppData para guardar tu "base de datos"
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HandheldLauncher");
            Directory.CreateDirectory(folder);
            string filePath = Path.Combine(folder, "games.json");

            // Cargamos lo que ya existe, añadimos el nuevo y guardamos
            // (Esto es una versión simplificada)
            var json = JsonSerializer.Serialize(Games);
            File.WriteAllText(filePath, json);
        }

    private void GamesGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedGame = e.ClickedItem as GameItem;
            if (selectedGame != null)
            {
                Process.Start(new ProcessStartInfo(selectedGame.Path) { UseShellExecute = true });
            }
        }
    }
}
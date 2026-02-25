using System.ComponentModel;
using Microsoft.UI.Xaml.Media;

namespace Handheld_Launcher
{
    public class GameItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Path { get; set; }

        // Ruta al archivo de la carátula (persistible)
        public string IconPath { get; set; }

        private ImageSource _icon;
        public ImageSource Icon
        {
            get => _icon;
            set
            {
                if (_icon != value)
                {
                    _icon = value;
                    OnPropertyChanged(nameof(Icon));
                }
            }
        }

        private bool _isLarge;
        public bool IsLarge
        {
            get => _isLarge;
            set
            {
                if (_isLarge != value)
                {
                    _isLarge = value;
                    OnPropertyChanged(nameof(IsLarge));
                }
            }
        }

        public GameItem(string name, string path, ImageSource icon, string iconPath = null)
        {
            Name = name;
            Path = path;
            Icon = icon;
            IconPath = iconPath;
            IsLarge = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

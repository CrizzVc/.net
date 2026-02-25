using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;

namespace Handheld_Launcher
{
    public class GameItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public ImageSource Icon { get; set; } // Cambiado a ImageSource

        public GameItem(string name, string path, ImageSource icon)
        {
            Name = name;
            Path = path;
            Icon = icon;
        }
    }
}

using System;
using Microsoft.UI.Xaml.Data;

namespace Handheld_Launcher
{
    public class BoolToWidthConverter : IValueConverter
    {
        // Devuelve el ancho en píxeles: true => ancho grande (420), false => ancho normal (220)
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isLarge = value is bool b && b;
            return isLarge ? 420.0 : 220.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
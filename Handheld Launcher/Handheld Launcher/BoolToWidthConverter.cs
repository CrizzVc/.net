using System;
using Microsoft.UI.Xaml.Data;

namespace Handheld_Launcher
{
    public class BoolToWidthConverter : IValueConverter
    {
        // Devuelve el ancho en píxeles: true => ancho doble (300), false => ancho normal (150)
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isLarge = value is bool b && b;
            return isLarge ? 300.0 : 150.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
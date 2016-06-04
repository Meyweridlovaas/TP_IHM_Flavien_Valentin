// ========================================================================
//
// Module        : Bool2Visibility2Converter.cs
// Author        : Valentin Gonon & Flavien Sarret
// Creation date : 2016-06-03
//
// ========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjetFlavienValentin.Converter
{
    public class Bool2Visibility2Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(bool)value) return "Visible";
            return "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

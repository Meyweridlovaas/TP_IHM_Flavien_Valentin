// ========================================================================
//
// Module        : String2UriConverter.cs
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
    public class String2UriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //path prend la valeur de value, ou un chemin par défaut si value est vide
            string path = ((string)value != string.Empty ? (string)value : "http://www.verification-des-liens.com/images/image-manquante.png");
            return new Uri(path, UriKind.Absolute);
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

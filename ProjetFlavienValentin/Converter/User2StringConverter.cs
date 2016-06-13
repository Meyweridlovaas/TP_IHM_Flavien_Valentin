using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DAO;

namespace ProjetFlavienValentin.Converter
{
    class User2StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value == null) return "Veuillez vous connecter";
            UserAccount user = value as UserAccount;
            string ret = new StringBuilder().AppendFormat("Vous êtes connecté en tant que {0}", user.Name).ToString();
            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

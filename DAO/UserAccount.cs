using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserAccount
    {
        public string Name { get; set; }
        private string _password;
        public string ListAnimalSource { get; set; }

        public UserAccount()
        {
            _password = string.Empty;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            return (obj as UserAccount).Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public void AddFirstPassword(string pass, string confirmPass)
        {
            if (_password == string.Empty && pass == confirmPass)
            {
                _password = pass;
            }
        }

        public bool ChangePassword(string oldPass, string newPass, string confirmPass)
        {
            if (oldPass != _password || newPass != confirmPass || newPass == string.Empty) return false;
            _password = newPass;
            return true;
        }

        public bool IsPasswordCorrect(string pass)
        {
            return pass == _password;
        }
    }
}

// ========================================================================
//
// Module        : UserAccount.cs
// Author        : Valentin Gonon & Flavien Sarret
// Creation date : 2016-06-15
//
// ========================================================================

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
        public string Password
        {
            get
            {
                //retourne le mot de passe encrypté
                return EncryptPassword(_password);
            }
            set
            {
                //ajoute le mot de passe si il est vide
                if (_password == string.Empty)
                {
                    _password = value;
                }
            }
        }        
        public string ListAnimalSource { get; set; }

        private string _password;

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

        /// <summary>
        /// Permet l'ajout d'un premier mot de passe
        /// </summary>
        public void AddFirstPassword(string pass, string confirmPass)
        {
            if (_password == string.Empty && pass == confirmPass)
            {
                _password = pass;
            }
        }

        /// <summary>
        /// Change le mot de passe de l'utilisateur
        /// </summary>
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

        /// <summary>
        /// Encrypte le mot de passe
        /// </summary>
        public static string EncryptPassword(string pass)
        {
            //placer ici un vrai encryptage
            return pass;
        }

        /// <summary>
        /// Décrypte le mot de passe encrypté
        /// </summary>
        public static string DecryptPassword(string pass)
        {
            //placer ici le décryptage correspondant
            return pass;
        }
    }
}

// ========================================================================
//
// Module        : ConnectUserWindowViewModel.cs
// Author        : Valentin Gonon & Flavien Sarret
// Creation date : 2016-06-15
//
// ========================================================================

using DAO;
using Library;
using ProjetFlavienValentin.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFlavienValentin.ViewModel
{
    class ConnectUserWindowViewModel
    {
        #region Propriétés

        #region PropriétésPubliques

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                ConnectCommand.RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                ConnectCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region AttributsPrivés

        private string _name;
        private string _password;

        #endregion

        #endregion

        #region Déléguées

        public DelegateCommand ConnectCommand { get; set; }

        #endregion

        public ConnectUserWindowViewModel()
        {
            ConnectCommand = new DelegateCommand(OnConnectCommand, CanConnectCommand);
            Name = string.Empty;
            Password = string.Empty;
        }

        #region Commandes

        private void OnConnectCommand(object obj)
        {
            UserEventArgs arg = new UserEventArgs();
            arg.UserAccount = new UserAccount { Name = Name };
            //Encrypte le mot de passe
            arg.Password = UserAccount.EncryptPassword(Password);
            ButtonPressedEvent.GetEvent().OnButtonPressedHandler(arg);
        }

        private bool CanConnectCommand(object obj)
        {
            //Vérifie que tous les champs sont remplis
            return (Name != string.Empty && Password != string.Empty);
        }

        #endregion
    }
}

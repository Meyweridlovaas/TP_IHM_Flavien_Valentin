using Library;
using ProjetFlavienValentin.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFlavienValentin.ViewModel
{
    class ChangePasswordWindowViewModel
    {
        #region Propriétés

        #region PropriétésPubliques

        public string OldPassword
        {
            get
            {
                return _oldPassword;
            }
            set
            {
                _oldPassword = value;
                ChangePassCommand.RaiseCanExecuteChanged();
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
                ChangePassCommand.RaiseCanExecuteChanged();
            }
        }

        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                ChangePassCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region AttributsPrivés

        private string _oldPassword;
        private string _confirmPassword;
        private string _password;

        #endregion

        #endregion

        #region Déléguées

        public DelegateCommand ChangePassCommand { get; set; }

        #endregion

        public ChangePasswordWindowViewModel()
        {
            ChangePassCommand = new DelegateCommand(OnChangePassCommand, CanChangePassCommand);
            OldPassword = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }           

        #region Commandes

        private void OnChangePassCommand(object o)
        {
            UserEventArgs arg = new UserEventArgs();
            arg.Password = OldPassword;
            arg.NewPass = Password;
            arg.ConfirmPass = ConfirmPassword;
            ButtonPressedEvent.GetEvent().OnButtonPressedHandler(arg);
        }

        private bool CanChangePassCommand(object o)
        {
            //Vérifie que tous les champs sont remplis et que les mots de passes sont les mêmes
            return (OldPassword != string.Empty && Password != string.Empty && ConfirmPassword == Password);
        }        

        #endregion
    }
}

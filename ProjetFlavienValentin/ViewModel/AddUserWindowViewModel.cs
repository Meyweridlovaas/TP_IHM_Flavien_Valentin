// ========================================================================
//
// Module        : AddUserWindowViewModel.cs
// Author        : Valentin Gonon & Flavien Sarret
// Creation date : 2016-06-15
//
// ========================================================================

using DAO;
using Library;
using Microsoft.Win32;
using ProjetFlavienValentin.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFlavienValentin
{
    public class AddUserWindowViewModel
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
                ConfirmCreateCommand.RaiseCanExecuteChanged();
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
                ConfirmCreateCommand.RaiseCanExecuteChanged();
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
                ConfirmCreateCommand.RaiseCanExecuteChanged();
            }
        }

        public string ListSource
        {
            get
            {
                return _listSource;
            }
            set
            {
                _listSource = value;
                ConfirmCreateCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region AttributsPrivés

        private string _name;
        private string _confirmPassword;
        private string _password;
        private string _listSource;

        #endregion

        #endregion

        #region Déléguées

        public DelegateCommand ConfirmCreateCommand { get; set; }
        public DelegateCommand CancelCreateCommand { get; set; }
        public DelegateCommand AddListCommand { get; set; }

        #endregion

        public AddUserWindowViewModel()
        {
            ConfirmCreateCommand = new DelegateCommand(OnConfirmCreateCommand, CanConfirmCreateCommand);
            CancelCreateCommand = new DelegateCommand(OnCancelCreateCommand, CanCancelCreateCommand);
            AddListCommand = new DelegateCommand(OnAddListCommand, CanAddListCommand);

            Name = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
            ListSource = string.Empty;
        }           

        #region Commandes

        private void OnConfirmCreateCommand(object o)
        {
            UserEventArgs arg = new UserEventArgs();
            arg.UserAccount = new UserAccount { Name = Name, ListAnimalSource = ListSource};
            arg.UserAccount.AddFirstPassword(Password, ConfirmPassword);
            ButtonPressedEvent.GetEvent().OnButtonPressedHandler(arg);
        }

        private bool CanConfirmCreateCommand(object o)
        {
            //Vérifie que tous les champs sont remplis et que les mots de passes sont les mêmes
            return (Name != string.Empty && Password != string.Empty && ConfirmPassword == Password);
        }

        private void OnCancelCreateCommand(object o)
        {
            ButtonPressedEvent.GetEvent().OnButtonPressedHandler(EventArgs.Empty);
        }

        private bool CanCancelCreateCommand(object o)
        {
            return true;
        }               

        private void OnAddListCommand(object obj)
        {
            OpenFileDialog fenetre = new OpenFileDialog();
            fenetre.Title = "Sélectionnez une liste XML";
            fenetre.Filter = "Fichier XML (*.xml)|*.xml";
            fenetre.ShowDialog();
            ListSource = fenetre.FileName;
        }

        private bool CanAddListCommand(object obj)
        {
            return true;
        }

        #endregion
    }
}

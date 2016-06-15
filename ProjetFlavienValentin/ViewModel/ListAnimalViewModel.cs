// ========================================================================
//
// Module        : ListAnimalViewModel.cs
// Author        : Valentin Gonon & Flavien Sarret
// Creation date : 2016-06-03
//
// ========================================================================

using DAO;
using Library;
using Microsoft.Win32;
using ProjetFlavienValentin.Event;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjetFlavienValentin.ViewModel
{
    class ListAnimalViewModel : NotifyPropertyChangedBase
    {
        #region Propriétés

        #region PropriétésPubliques

        public UserAccount User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                NotifyPropertyChanged("User");
                AddListToUserCommand.RaiseCanExecuteChanged();
            }
        }

        public Animal Animal
        {
            get
            {
                return _animal;
            }
            set
            {
                _animal = value;
                NotifyPropertyChanged("Animal");
                //Mise à jour des attributs privés représentant l'animal
                if (_animal != null)
                {
                    _name = Animal.Name;
                    NotifyPropertyChanged("Name");
                    _description = Animal.Description;
                    NotifyPropertyChanged("Description");
                    _family = Animal.Family;
                    NotifyPropertyChanged("Family");
                }
                else
                {
                    _name = string.Empty;
                    NotifyPropertyChanged("Name");
                    _description = string.Empty;
                    NotifyPropertyChanged("Description");
                    _family = string.Empty;
                    NotifyPropertyChanged("Family");
                }
                NotifyPropertyChanged("ListAnimals");
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
                ChangeImageCommand.RaiseCanExecuteChanged();
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public string Family
        {
            get
            {
                return _family;
            }
            set
            {
                _family = value;
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<UserAccount> ListUsers
        {
            get
            {
                return _listUsers;
            }
            set
            {
                _listUsers = value;
            }
        }

        public ObservableCollection<Animal> ListAnimals
        {
            get
            {
                return _listAnimals;
            }
            set
            {
                _listAnimals = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        //Définit si les champs sont en lecture seule (lecture) ou non (édition)
        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }
            set
            {
                _isReadOnly = value;
                NotifyPropertyChanged("IsReadOnly");
                CancelCommand.RaiseCanExecuteChanged();
                SaveCommand.RaiseCanExecuteChanged();
                EditCommand.RaiseCanExecuteChanged();
            }
        }

        //Définit si un utilisateur est connecté
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
                NotifyPropertyChanged("IsConnected");
                ConnectCommand.RaiseCanExecuteChanged();
                DisconnectCommand.RaiseCanExecuteChanged();
                CreateAccountCommand.RaiseCanExecuteChanged();
                ChangePasswordCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region AttributsPrivés

        private Animal _animal;
        private UserAccount _user;
        private ObservableCollection<UserAccount> _listUsers = new ObservableCollection<UserAccount>();
        private ObservableCollection<Animal> _listAnimals = new ObservableCollection<Animal>();
        private bool _isConnected;
        private bool _isReadOnly;
        private string _name;
        private string _family;
        private string _description;
        private AddWindow _addWindow;
        private AddUserWindow _addUserWindow;
        private ConnectUserWindow _connectUserWindow;
        private ChangePasswordWindow _changePasswordWindow;
        private string _actualXMLFile;

        #endregion

        #endregion

        #region Déléguées

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand ChangeImageCommand { get; set; }
        public DelegateCommand ConnectCommand { get; set; }
        public DelegateCommand DisconnectCommand { get; set; }
        public DelegateCommand CreateAccountCommand { get; set; }
        public DelegateCommand ChangePasswordCommand { get; set; }
        public DelegateCommand SaveXMLCommand { get; set; }
        public DelegateCommand SaveAsXMLCommand { get; set; }
        public DelegateCommand OpenXMLCommand { get; set; }
        public DelegateCommand AddListToUserCommand { get; set; }

        #endregion

        public ListAnimalViewModel()
        {
            AnimalManager.InitializeListAnimal(_listAnimals);
            UserManager.InitializeListUser(_listUsers);

            AddCommand = new DelegateCommand(OnAddCommand, CanAddCommand);
            EditCommand = new DelegateCommand(OnEditCommand, CanEditOrDeleteCommand);
            DeleteCommand = new DelegateCommand(OnDeleteCommand, CanEditOrDeleteCommand);
            SaveCommand = new DelegateCommand(OnSaveCommand, CanSaveCommand);
            CancelCommand = new DelegateCommand(OnCancelCommand, CanCancelCommand);
            ChangeImageCommand = new DelegateCommand(OnChangeImageCommand, CanChangeImageCommand);
            ConnectCommand = new DelegateCommand(OnConnectCommand, CanConnectOrCreateAccountCommand);
            CreateAccountCommand = new DelegateCommand(OnCreateAccountCommant, CanConnectOrCreateAccountCommand);
            DisconnectCommand = new DelegateCommand(OnDisconnectCommand, CanDisconnectOrChangePasswordCommand);
            ChangePasswordCommand = new DelegateCommand(OnChangePasswordCommand, CanDisconnectOrChangePasswordCommand);
            SaveXMLCommand = new DelegateCommand(OnSaveXMLCommand, CanXMLCommand);
            SaveAsXMLCommand = new DelegateCommand(OnSaveAsXMLCommand, CanXMLCommand);
            OpenXMLCommand = new DelegateCommand(OnOpenXMLCommand, CanXMLCommand);
            AddListToUserCommand = new DelegateCommand(OnAddListCommand, CanAddListCommand);

            IsReadOnly = true;
            IsConnected = false;
        }

        #region Commandes

        #region CRUD

        private void OnAddCommand(object o)
        {
            ButtonPressedEvent.GetEvent().Handler += CloseAddWindow;
            _addWindow = new AddWindow();
            _addWindow.ShowDialog();
        }

        private bool CanAddCommand(object o)
        {
            return IsReadOnly;
        }

        private void CloseAddWindow(object sender, EventArgs e)
        {
            _addWindow.Close();
            if (e != EventArgs.Empty) ListAnimals.Add((e as AnimalEventArgs).Animal);
            ButtonPressedEvent.GetEvent().Handler -= CloseAddWindow;
        }

        private void OnEditCommand(object o)
        {
            IsReadOnly = false;
            DeleteCommand.RaiseCanExecuteChanged();
            AddCommand.RaiseCanExecuteChanged();
        }

        private bool CanEditOrDeleteCommand(object o)
        {
            return Animal != null && IsReadOnly;
        }

        private void OnDeleteCommand(object o)
        {
            MessageBoxResult result = MessageBox.Show("Voulez vous vraiment supprimer cet animal ?", "Supprimer un animal", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                ListAnimals.Remove(Animal);
                NotifyPropertyChanged("ListAnimals");
            }
        }

        private bool CanSaveCommand(object obj)
        {
            //Vérifie que tous les champs sont remplis
            return (Name != string.Empty && Family != string.Empty && Description != string.Empty) && !IsReadOnly;
        }

        private void OnSaveCommand(object obj)
        {
            IsReadOnly = true;
            DeleteCommand.RaiseCanExecuteChanged();
            AddCommand.RaiseCanExecuteChanged();
            Animal.Name = _name;
            Animal.Family = _family;
            Animal.Description = _description;
            Animal = Animal;
        }

        private bool CanCancelCommand(object obj)
        {
            return !IsReadOnly;
        }

        private void OnCancelCommand(object obj)
        {
            IsReadOnly = true;
            DeleteCommand.RaiseCanExecuteChanged();
            AddCommand.RaiseCanExecuteChanged();
            Animal = Animal;
        }

        private bool CanChangeImageCommand(object obj)
        {
            return Animal != null;
        }

        private void OnChangeImageCommand(object obj)
        {
            OpenFileDialog fenetre = new OpenFileDialog();
            fenetre.Title = "Sélectionnez une image";
            fenetre.Filter = "Images (*.jpg, *.png, *.gif)|*.xml;*.png;*.gif";
            fenetre.ShowDialog();
            if (fenetre.FileName != string.Empty)
            {
                Animal.ImageSource = fenetre.FileName;
                Animal = Animal;
            }
        }

        #endregion

        #region PersistanceXML

        private void OnOpenXMLCommand(object obj)
        {
            OpenFileDialog fenetre = new OpenFileDialog();
            fenetre.Title = "Sélectionnez un fichier XML";
            fenetre.Filter = "Fichier XML (*.xml)|*.xml";
            fenetre.ShowDialog();
            if (fenetre.FileName != string.Empty)
            {
                ListAnimalXMLManager.ReadListAnimalInXMLFile(_listAnimals, fenetre.FileName);
                _actualXMLFile = fenetre.FileName;
            }            
        }

        private void OnSaveAsXMLCommand(object obj)
        {
            SaveFileDialog fenetre = new SaveFileDialog();
            fenetre.Title = "Enregistrez un fichier XML";
            fenetre.Filter = "Fichier XML (*.xml)|*.xml";
            fenetre.ShowDialog();
            if (fenetre.FileName != string.Empty)
            {
                _actualXMLFile = fenetre.FileName;
                OnSaveXMLCommand(null);
            }
        }

        private void OnSaveXMLCommand(object obj)
        {
            if (_actualXMLFile == null)
            {
                OnSaveAsXMLCommand(null);
            }
            ListAnimalXMLManager.WriteListAnimalInXMLFile(_listAnimals, _actualXMLFile);
        }

        private bool CanXMLCommand(object obj)
        {
            return true;
        }

        #endregion

        #region ComptesUtilisateurs

        private void OnConnectCommand(object obj)
        {
            ButtonPressedEvent.GetEvent().Handler += CloseConnectUserWindow;
            _connectUserWindow = new ConnectUserWindow();
            _connectUserWindow.ShowDialog();
        }

        private void OnCreateAccountCommant(object obj)
        {
            ButtonPressedEvent.GetEvent().Handler += CloseAddUserWindow;
            _addUserWindow = new AddUserWindow();
            _addUserWindow.ShowDialog();
        }

        private bool CanConnectOrCreateAccountCommand(object obj)
        {
            return !IsConnected;
        }

        private void OnDisconnectCommand(object obj)
        {
            IsConnected = false;
            User = null;
            _actualXMLFile = null;
        }

        private void OnChangePasswordCommand(object obj)
        {
            ButtonPressedEvent.GetEvent().Handler += CloseChangePasswordWindow;
            _changePasswordWindow = new ChangePasswordWindow();
            _changePasswordWindow.ShowDialog();
        }

        private bool CanDisconnectOrChangePasswordCommand(object obj)
        {
            return IsConnected;
        }

        private void CloseChangePasswordWindow(object sender, EventArgs e)
        {
            _changePasswordWindow.Close();
            if (e != EventArgs.Empty)
            {
                UserEventArgs arg = e as UserEventArgs;
                if (!User.ChangePassword(UserAccount.DecryptPassword(arg.Password), UserAccount.DecryptPassword(arg.NewPass),UserAccount.DecryptPassword(arg.ConfirmPass)))
                {
                    MessageBox.Show("Erreur dans le changement du mot de passe", "Erreur changement mot de passe", MessageBoxButton.OK);
                }
                else UserManager.SaveListUser(_listUsers);
            }
            ButtonPressedEvent.GetEvent().Handler -= CloseChangePasswordWindow;
        }

        private void CloseAddUserWindow(object sender, EventArgs e)
        {
            _addUserWindow.Close();
            if (e != EventArgs.Empty)
            {
                UserAccount account = (e as UserEventArgs).UserAccount;
                if (ListUsers.Contains(account)) //Cas : utilisateur déjà existant
                {
                    MessageBox.Show("Erreur : cet utilisateur existe déjà", "Erreur : utilisateur existant", MessageBoxButton.OK);
                }
                else
                {
                    ListUsers.Add(account);
                    UserManager.SaveListUser(_listUsers);
                    User = account;
                    IsConnected = true;
                    if (User.ListAnimalSource != string.Empty)
                    {
                        ListAnimalXMLManager.ReadListAnimalInXMLFile(_listAnimals, User.ListAnimalSource);
                        _actualXMLFile = User.ListAnimalSource;
                    }
                }
            }
            ButtonPressedEvent.GetEvent().Handler -= CloseAddUserWindow;
        }

        private void CloseConnectUserWindow(object sender, EventArgs e)
        {
            _connectUserWindow.Close();
            if (e != EventArgs.Empty)
            {
                UserAccount account = (e as UserEventArgs).UserAccount;
                string pass = (e as UserEventArgs).Password;
                if (!ListUsers.Contains(account)) //Cas : compte innexistant
                {
                    MessageBox.Show("Erreur : cet utilisateur n'existe pas", "Erreur : utilisateur inconnu", MessageBoxButton.OK);
                }
                else
                {
                    UserAccount selectedAccount = ListUsers.Where(usr => usr.Equals(account)).First();
                    if (!selectedAccount.IsPasswordCorrect(UserAccount.DecryptPassword(pass))) //Cas : mauvais mot de passe
                    {
                        MessageBox.Show("Erreur : mot de passe incorrect", "Erreur : mot de passe incorrect", MessageBoxButton.OK);
                    }
                    else
                    {
                        IsConnected = true;
                        User = selectedAccount;
                        if (User.ListAnimalSource != string.Empty)
                        {
                            ListAnimalXMLManager.ReadListAnimalInXMLFile(_listAnimals, User.ListAnimalSource);
                            _actualXMLFile = User.ListAnimalSource;
                        }
                    }
                }
            }
            ButtonPressedEvent.GetEvent().Handler -= CloseConnectUserWindow;
        }        

        private void OnAddListCommand(object obj)
        {
            OpenFileDialog fenetre = new OpenFileDialog();
            fenetre.Title = "Sélectionnez une liste XML";
            fenetre.Filter = "Fichier XML (*.xml)|*.xml";
            fenetre.ShowDialog();
            if (fenetre.FileName != string.Empty)
            {
                User.ListAnimalSource = fenetre.FileName;
                UserManager.SaveListUser(_listUsers);
                ListAnimalXMLManager.ReadListAnimalInXMLFile(_listAnimals, fenetre.FileName);
                _actualXMLFile = fenetre.FileName;
            }            
        }

        private bool CanAddListCommand(object obj)
        {
            return User != null;
        }

        #endregion

        #endregion
    }
}

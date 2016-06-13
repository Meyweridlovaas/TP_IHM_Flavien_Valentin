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
            get;
            set;
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

        public bool IsConnected
        {
            get
            {
                return IsConnected;
            }
            set
            {
                IsConnected = value;
            }
        }

        #endregion

        #region AttributsPrivés

        private Animal _animal;
        private ObservableCollection<Animal> _listAnimals = new ObservableCollection<Animal>();
        private bool _isConnected;
        private bool _isReadOnly;
        private string _name;
        private string _family;
        private string _description;
        private AddWindow _addWindow;

        #endregion

        #endregion

        #region Déléguées

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand ChangeImageCommand { get; set; }

        #endregion

        public ListAnimalViewModel()
        {
            AnimalManager.InitializeListAnimal(_listAnimals);

            AddCommand = new DelegateCommand(OnAddCommand, CanAddCommand);
            EditCommand = new DelegateCommand(OnEditCommand, CanEditOrDeleteCommand);
            DeleteCommand = new DelegateCommand(OnDeleteCommand, CanEditOrDeleteCommand);
            SaveCommand = new DelegateCommand(OnSaveCommand, CanSaveCommand);
            CancelCommand = new DelegateCommand(OnCancelCommand, CanCancelCommand);
            ChangeImageCommand = new DelegateCommand(OnChangeImageCommand, CanChangeImageCommand);

            IsReadOnly = true;
        }

        #region Commandes

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
            ListAnimals.Add((e as AnimalEventArgs).Animal);
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
            fenetre.ShowDialog();
            if (fenetre.FileName != string.Empty)
            {
                Animal.ImageSource = fenetre.FileName;
                Animal = Animal;
            }
        }

        #endregion
    }
}

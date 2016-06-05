// ========================================================================
//
// Module        : AddWindowViewModel.cs
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetFlavienValentin.ViewModel
{
    class AddWindowViewModel
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
                ConfirmAddCommand.RaiseCanExecuteChanged();
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
                ConfirmAddCommand.RaiseCanExecuteChanged();
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
                ConfirmAddCommand.RaiseCanExecuteChanged();
            }
        }

        public string ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                _imageSource = value;
                ConfirmAddCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region AttributsPrivés

        private string _name;
        private string _family;
        private string _description;
        private string _imageSource;

        #endregion

        #endregion

        #region Déléguées

        public DelegateCommand ConfirmAddCommand { get; set; }
        public DelegateCommand CancelAddCommand { get; set; }
        public DelegateCommand AddImageCommand { get; set; }

        #endregion

        //Référence vers le ViewModel, permettant d'y ajouter un animal
        private ListAnimalViewModel ListModel;
        //Référence vers la fenêtre active, permettant de la fermer
        private AddWindow _window;

        public AddWindowViewModel(ListAnimalViewModel listModel, AddWindow window)
        {
            ListModel = listModel;
            _window = window;
            ConfirmAddCommand = new DelegateCommand(OnConfirmAddCommand, CanConfirmAddCommand);
            CancelAddCommand = new DelegateCommand(OnCancelAddCommand, CanCancelAddCommand);
            AddImageCommand = new DelegateCommand(OnAddImageCommand, CanAddImageCommand);
            Name = string.Empty;
            Description = string.Empty;
            Family = string.Empty;
            ImageSource = string.Empty;
        }               

        #region Commandes

        private void OnConfirmAddCommand(object o)
        {
            ListModel.ListAnimals.Add(new Animal { Name = Name, Description = Description, Family = Family, ImageSource = ImageSource });
            ButtonPressedEvent.GetEvent().OnButtonPressedHandler(EventArgs.Empty);
        }

        private bool CanConfirmAddCommand(object o)
        {
            //Vérifie que tous les champs sont remplis
            return (Name != string.Empty && Family != string.Empty && Description != string.Empty);
        }

        private void OnCancelAddCommand(object o)
        {
            ButtonPressedEvent.GetEvent().OnButtonPressedHandler(EventArgs.Empty);
        }

        private bool CanCancelAddCommand(object o)
        {
            return true;
        }               

        private void OnAddImageCommand(object obj)
        {
            OpenFileDialog fenetre = new OpenFileDialog();
            fenetre.Title = "Sélectionnez une image";
            fenetre.ShowDialog();
            ImageSource = fenetre.FileName;
        }

        private bool CanAddImageCommand(object obj)
        {
            return true;
        }

        #endregion
    }
}

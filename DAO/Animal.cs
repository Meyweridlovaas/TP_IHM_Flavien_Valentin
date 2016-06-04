// ========================================================================
//
// Module        : Animal.cs
// Author        : Valentin Gonon & Flavien Sarret
// Creation date : 2016-06-03
//
// ========================================================================

using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Animal : NotifyPropertyChangedBase
    {
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
                NotifyPropertyChanged("Name");
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
                NotifyPropertyChanged("Family");
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
                NotifyPropertyChanged("Description");
            }
        }

        //source de l'image représentant l'animal
        public string ImageSource { get; set; }

        #endregion

        #region AttributsPrivés

        private string _name;
        private string _family;
        private string _description;

        #endregion       
        
        public override string ToString()
        {
            return string.Format("{0} est un {1}", Name, Family);
        }
    }
}

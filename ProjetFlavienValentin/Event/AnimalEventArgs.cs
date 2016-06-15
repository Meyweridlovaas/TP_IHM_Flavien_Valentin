// ========================================================================
//
// Module        : AnimalEventArgs.cs
// Author        : Valentin Gonon & Flavien Sarret
// Creation date : 2016-06-15
//
// ========================================================================

using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFlavienValentin.Event
{
    class AnimalEventArgs : EventArgs
    {
        public Animal Animal { get; set; }
    }
}

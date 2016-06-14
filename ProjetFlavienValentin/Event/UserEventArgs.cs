﻿using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFlavienValentin.Event
{
    class UserEventArgs : EventArgs
    {
        public UserAccount UserAccount { get; set; }
        public string Password { get; set; }
        public string ConfirmPass { get; set; }
        public string NewPass { get; set; }
    }
}

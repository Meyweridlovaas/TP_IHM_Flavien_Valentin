﻿// ========================================================================
//
// Module        : ButtonPressedEvent.cs
// Author        : Valentin Gonon & Flavien Sarret
// Creation date : 2016-06-15
//
// ========================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFlavienValentin.Event
{
    public class ButtonPressedEvent
    {
        #region Singleton
        private static ButtonPressedEvent _myEvent
        {
            get;
            set;
        }

        private ButtonPressedEvent()
        {

        }

        public static ButtonPressedEvent GetEvent()
        {
            if (_myEvent == null)
            {
                _myEvent = new ButtonPressedEvent();
            }
            return _myEvent;

        }

        #endregion


        public event EventHandler Handler;

        public void OnButtonPressedHandler(EventArgs e)
        {
            if (Handler != null)
            {
                Handler(this, e);
            }
        }
    }
}

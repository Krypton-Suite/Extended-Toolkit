﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.UI
{
    public class KryptonFormExtended : KryptonForm
    {
        #region Variables
        private bool _useFade;

        private InternalFadeController _fadeController = new InternalFadeController();

        private int _fadeInterval;

        private KryptonFormExtended _currentWindow, _nextWindow;
        #endregion

        #region Properties
        [DefaultValue(false)]
        public bool UseFade { get => _useFade; set => _useFade = value; }

        [DefaultValue(50)]
        public int FadeInterval { get => _fadeInterval; set => _fadeInterval = value; }

        public KryptonFormExtended NextWindow { get => _nextWindow; set => _nextWindow = value; }

        public KryptonFormExtended CurrentWindow { get => _currentWindow; private set => _currentWindow = value; }
        #endregion

        #region Constructors
        public KryptonFormExtended()
        {
            _useFade = false;

            _fadeInterval = 50;

            CurrentWindow = this;

            NextWindow = null;
        }
        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            if (_useFade)
            {
                _fadeController.FadeWindowIn(this);
            }

            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_useFade)
            {
                if (_nextWindow != null)
                {
                    _fadeController.FadeWindowOut(_currentWindow, _nextWindow);
                }
                else
                {
                    _fadeController.FadeWindowOut(_currentWindow);
                }
            }

            base.OnFormClosing(e);
        }
        #endregion
    }
}
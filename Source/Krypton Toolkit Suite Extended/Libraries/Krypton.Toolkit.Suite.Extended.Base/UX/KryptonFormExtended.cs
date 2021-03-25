#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonFormExtended : KryptonForm
    {
        #region Variables
        private bool _useFade;

        private int _fadeInSleepTimer, _fadeOutSleepTimer;

        private KryptonFormExtended _nextWindow;

        private InternalKryptonFadeManager _fadeManager;
        #endregion

        #region Properties
        [DefaultValue(true)]
        public bool UseFade { get => _useFade; set => _useFade = value; }

        [DefaultValue(50)]
        public int FadeInSleepTimer { get => _fadeInSleepTimer; set => _fadeInSleepTimer = value; }

        [DefaultValue(50)]
        public int FadeOutSleepTimer { get => _fadeOutSleepTimer; set => _fadeOutSleepTimer = value; }

        public KryptonFormExtended NextWindow { get => _nextWindow; set => _nextWindow = value; }
        #endregion

        #region Constructor
        public KryptonFormExtended()
        {

        }
        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            if (_useFade)
            {
                _fadeManager.FadeExtendedWindowIn(this, _fadeInSleepTimer);
            }

            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_useFade)
            {
                _fadeManager.FadeExtendedWindowOut(this, _nextWindow, _fadeOutSleepTimer);
            }

            base.OnFormClosing(e);
        }
        #endregion
    }
}
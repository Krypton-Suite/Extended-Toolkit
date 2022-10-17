using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    public class KryptonFormExtended : VirtualKryptonFormExtended
    {
        #region Instance Fields

        #region Fade Items

        private bool _useFade;

        private FadeController _fadeController = new();

        private int _fadeSpeed;

        private KryptonFormExtended _currentWindow, _nextWindow;

        #endregion

        #endregion

        #region Public

        [DefaultValue(false)]
        public bool UseFade { get => _useFade; set => _useFade = value; }

        [DefaultValue(50)]
        public int FadeSpeed { get => _fadeSpeed; set => _fadeSpeed = value; }

        public KryptonFormExtended CurrentWindow { get => _currentWindow; set => _currentWindow = value; }

        public KryptonFormExtended NextWindow { get => _nextWindow; set => _nextWindow = value; }

        #endregion

        #region Identity

        public KryptonFormExtended()
        {
            _useFade = false;

            _fadeSpeed = 50;

            _currentWindow = null;

            _nextWindow = null;
        }

        #endregion

        #region Protected Overrides

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
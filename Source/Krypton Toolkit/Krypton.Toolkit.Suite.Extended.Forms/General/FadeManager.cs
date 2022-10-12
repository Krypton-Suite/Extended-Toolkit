using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    internal class FadeManager
    {
        #region Instance Fields

        private readonly InternalFadeController _fadeController;

        private readonly FadeValues _fadeValues;

        private bool _useFade;

        private int _fadeInterval;

        private VirtualForm _currentWindow;

        private VirtualForm _nextWindow;

        #endregion

        #region Identity

        public FadeManager(VirtualForm currentWindow, VirtualForm nextWindow, bool useFade, int fadeInterval, FadeValues fadeValues, InternalFadeController fadeController)
        {
            _fadeController = fadeController;

            _currentWindow = currentWindow;

            _nextWindow = nextWindow;

            _useFade = useFade;

            _fadeInterval = fadeInterval;

            _fadeValues = fadeValues;

            _currentWindow.FormClosing += OnCurrentWindowFormClosing;

            _currentWindow.Load += OnCurrentWindowLoad;
        }

        private void OnCurrentWindowLoad(object sender, EventArgs e)
        {
            if (_useFade)
            {
                _fadeController.FadeWindowIn(_currentWindow, _fadeInterval);
            }
        }

        private void OnCurrentWindowFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_useFade)
            {
                if (_nextWindow != null)
                {
                    _fadeController.FadeWindowOut(_currentWindow, _nextWindow, _fadeInterval);
                }
                else
                {
                    _fadeController.FadeWindowOut(_currentWindow, null, _fadeInterval);
                }
            }
        }

        #endregion
    }
}

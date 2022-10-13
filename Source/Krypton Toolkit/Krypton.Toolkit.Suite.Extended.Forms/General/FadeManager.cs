namespace Krypton.Toolkit.Suite.Extended.Forms
{
    internal class FadeManager
    {
        #region Instance Fields

        private readonly FadeController _fadeController;

        private readonly FadeValues _fadeValues;

        private bool _useFade;

        private int _fadeInterval;

        private KryptonFormExtended _currentWindow;

        private KryptonFormExtended _nextWindow;

        private VirtualForm _currentVirtualWindow;

        private VirtualForm _nextVirtualWindow;

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="FadeManager" /> class.</summary>
        /// <param name="currentWindow">The current window.</param>
        /// <param name="nextWindow">The next window.</param>
        /// <param name="useFade">if set to <c>true</c> [use fade].</param>
        /// <param name="fadeInterval">The fade interval.</param>
        /// <param name="fadeValues">The fade values.</param>
        /// <param name="fadeController">The fade controller.</param>
        public FadeManager(VirtualForm currentWindow, VirtualForm nextWindow, bool useFade, int fadeInterval, FadeValues fadeValues, FadeController fadeController)
        {
            _fadeController = fadeController;

            _currentVirtualWindow = currentWindow;

            _nextVirtualWindow = nextWindow;

            _useFade = useFade;

            _fadeInterval = fadeInterval;

            _fadeValues = fadeValues;

            //_currentVirtualWindow.FormClosing += OnCurrentWindowFormClosing;

            //_currentVirtualWindow.Load += OnCurrentWindowLoad;
        }

        /// <summary>Initializes a new instance of the <see cref="FadeManager" /> class.</summary>
        /// <param name="currentWindow">The current window.</param>
        /// <param name="nextWindow">The next window.</param>
        /// <param name="useFade">if set to <c>true</c> [use fade].</param>
        /// <param name="fadeInterval">The fade interval.</param>
        /// <param name="values">The values.</param>
        /// <param name="controller">The controller.</param>
        public FadeManager(KryptonFormExtended currentWindow, KryptonFormExtended nextWindow, bool useFade, int fadeInterval, FadeValues values, FadeController controller)
        {
            _currentWindow = currentWindow;

            _nextWindow = nextWindow;

            _useFade = useFade;

            _fadeInterval = fadeInterval;

            _fadeValues = values;

            _fadeController = controller;
        }

        //private void OnCurrentWindowLoad(object sender, EventArgs e)
        //{
        //    if (_useFade)
        //    {
        //        _fadeController.FadeWindowIn(_currentVirtualWindow, _fadeInterval);
        //    }
        //}

        //private void OnCurrentWindowFormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (_useFade)
        //    {
        //        if (_nextWindow != null)
        //        {
        //            _fadeController.FadeWindowOut(_currentVirtualWindow, _nextWindow, _fadeInterval);
        //        }
        //        else
        //        {
        //            _fadeController.FadeWindowOut(_currentVirtualWindow, null, _fadeInterval);
        //        }
        //    }
        //}

        #endregion
    }
}

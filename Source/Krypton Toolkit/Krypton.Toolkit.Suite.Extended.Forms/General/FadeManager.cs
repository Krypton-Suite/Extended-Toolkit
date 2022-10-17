#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

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

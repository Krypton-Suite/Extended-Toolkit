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
#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Effects
{
    public class FadeManager : Component
    {
        #region Variables
        private float _fadeSpeed;

        private KryptonForm? _windowToFade;
        private KryptonForm? _parentWindow;
        #endregion

        #region Properties
        public float FadeSpeed { get => _fadeSpeed; set => _fadeSpeed = value; }

        public KryptonForm? WindowToFade { get => _windowToFade; set => _windowToFade = value; }

        public KryptonForm? ParentWindow { get => _parentWindow; set => _parentWindow = value; }
        #endregion

        #region Custom Events

        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="FadeManager" /> class.</summary>
        public FadeManager()
        {
            _fadeSpeed = 5;

            _parentWindow = null;

            _windowToFade = null;
        }
        #endregion

        #region Methods
        /// <summary>Fades the window in.</summary>
        public void FadeIn() => FadeController.FadeIn(_windowToFade, _fadeSpeed);

        /// <summary>Fades the window out.</summary>
        public void FadeOut() => FadeController.FadeOut(_windowToFade, _fadeSpeed);

        /// <summary>Fades the window out and close.</summary>
        public void FadeOutAndClose() => FadeController.FadeOutAndClose(_windowToFade, _fadeSpeed);

        /// <summary>Fades the dialog.</summary>
        public void FadeDialog() => FadeController.ShowDialog(_windowToFade, _parentWindow, _fadeSpeed);
        #endregion
    }
}
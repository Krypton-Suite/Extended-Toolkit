#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Effects
{
    public class FadeManager : Component
    {
        #region Variables
        private float _fadeSpeed;

        private KryptonForm _windowToFade, _parentWindow;
        #endregion

        #region Properties
        public float FadeSpeed { get => _fadeSpeed; set => _fadeSpeed = value; }

        public KryptonForm WindowToFade { get => _windowToFade; set => _windowToFade = value; }

        public KryptonForm ParentWindow { get => _parentWindow; set => _parentWindow = value; }
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
#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    internal class InternalFadeController
    {
        #region Variables
        private int _fadeInterval;

        private KryptonFormExtended _owner, _nextWindow;
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="InternalFadeController" /> class.</summary>
        public InternalFadeController() { }

        /// <summary>Initializes a new instance of the <see cref="InternalFadeController" /> class.</summary>
        /// <param name="fadeInterval">The fade sleep timer.</param>
        /// <param name="owner">The owner.</param>
        /// <param name="nextWindow">The next window.</param>
        public InternalFadeController(int fadeInterval, KryptonFormExtended owner, KryptonFormExtended nextWindow = null)
        {
            _fadeInterval = fadeInterval;

            _owner = owner;

            _nextWindow = nextWindow;
        }
        #endregion

        #region Methods
        /// <summary>Fades the window in. Credit: https://stackoverflow.com/questions/12497826/better-algorithm-to-fade-a-winform.</summary>
        /// <param name="owner">The owner.</param>
        public async void FadeWindowIn(KryptonForm owner)
        {
            // The window is not visible, so fade it in
            while (owner.Opacity <= 1.0)
            {
                await Task.Delay(_fadeInterval);

                owner.Opacity += 0.05;
            }

            // Now, the window is fully visible
            owner.Opacity = 1;
        }

        /// <summary>Fades the window out. Credit: https://stackoverflow.com/questions/12497826/better-algorithm-to-fade-a-winform.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="nextWindow">The next window.</param>
        public async void FadeWindowOut(KryptonForm owner, KryptonForm nextWindow = null)
        {
            // The window is visible, so fade it out
            while (owner.Opacity > 0.0)
            {
                await Task.Delay(_fadeInterval);

                owner.Opacity -= 0.05;
            }

            // Now, the window is invisible
            owner.Opacity = 0;

            // Move on to the next window if necessary
            if (nextWindow != null)
            {
                nextWindow.Show();
            }
        }
        #endregion
    }
}
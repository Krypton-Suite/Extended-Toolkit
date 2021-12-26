#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Threading;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Global.Utilities
{
    /// <summary>
    /// Fades the selected <see cref="KryptonForm"/> or <see cref="Form"/> in and out.
    /// </summary>
    public class FadeEffects
    {
        #region Variables
        private Double _fadeIn, _fadeOut;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the fade in value.
        /// </summary>
        /// <value>
        /// The fade in value.
        /// </value>
        private Double FadeIn
        {
            get
            {
                return _fadeIn;
            }

            set
            {
                _fadeIn = value;
            }
        }

        /// <summary>
        /// Gets or sets the fade out value.
        /// </summary>
        /// <value>
        /// The fade out value.
        /// </value>
        private Double FadeOut
        {
            get
            {
                return _fadeOut;
            }

            set
            {
                _fadeOut = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initialises a new instance of the <see cref="FadeEffects"/> class.
        /// </summary>
        public FadeEffects()
        {

        }
        #endregion

        #region Methods

        #region Fade In        
        /// <summary>
        /// Fades the form in.
        /// Use this in your 'Form_Load' event.
        /// </summary>
        /// <param name="kryptonWindow">The krypton window.</param>
        /// <param name="window">The window.</param>
        /// <param name="fadeInSleepTimer">The fade in sleep timer.</param>
        public void FadeInWindow(KryptonForm kryptonWindow, Form window = null, int fadeInSleepTimer = 50)
        {
            for (FadeIn = 0.0; FadeIn <= 1.1; FadeIn += 0.1)
            {
                if (window != null)
                {
                    window.Opacity = FadeIn;

                    window.Refresh();
                }
                else
                {
                    kryptonWindow.Opacity = FadeIn;

                    kryptonWindow.Refresh();
                }

                Thread.Sleep(fadeInSleepTimer);
            }
        }
        #endregion

        #region Fade Out        
        /// <summary>
        /// Fades the out window.
        /// </summary>
        /// <param name="currentKryptonWindow">The current krypton window.</param>
        /// <param name="nextKryptonWindow">The next krypton window.</param>
        /// <param name="currentWindow">The current window.</param>
        /// <param name="nextWindow">The next window.</param>
        /// <param name="fadeOutSleepTimer">The fade out sleep timer.</param>
        public void FadeOutWindow(KryptonForm currentKryptonWindow, KryptonForm nextKryptonWindow, Form currentWindow = null, Form nextWindow = null, int fadeOutSleepTimer = 50)
        {
            for (FadeOut = 90; FadeOut >= 10; FadeOut += -10)
            {
                if (nextWindow != null)
                {
                    nextWindow.Opacity = FadeOut / 100;

                    nextWindow.Refresh();
                }
                else
                {
                    nextKryptonWindow.Opacity = FadeOut / 100;

                    nextKryptonWindow.Refresh();
                }

                Thread.Sleep(fadeOutSleepTimer);
            }

            if (nextWindow != null)
            {
                nextWindow.Show();
            }
            else
            {
                nextKryptonWindow.Show();
            }
        }
        #endregion

        #endregion

        #region De constructor        
        /// <summary>
        /// Finalises an instance of the <see cref="FadeEffects"/> class.
        /// </summary>
        ~FadeEffects()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
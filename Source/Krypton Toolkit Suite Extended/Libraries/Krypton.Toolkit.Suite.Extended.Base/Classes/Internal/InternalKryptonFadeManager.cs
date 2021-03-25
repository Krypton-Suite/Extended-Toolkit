﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Threading;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    internal class InternalKryptonFadeManager
    {
        #region Variables
        private double _fadeIn, _fadeOut;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the fade in value.
        /// </summary>
        /// <value>
        /// The fade in value.
        /// </value>
        private double FadeIn { get => _fadeIn; set => _fadeIn = value; }

        /// <summary>
        /// Gets or sets the fade out value.
        /// </summary>
        /// <value>
        /// The fade out value.
        /// </value>
        private double FadeOut { get => _fadeOut; set => _fadeOut = value; }
        #endregion

        public InternalKryptonFadeManager()
        {

        }

        #region Methods
        /// <summary>Fades the extended window in.</summary>
        /// <param name="window">The window.</param>
        /// <param name="fadeInSleepTimer">The fade in sleep timer.</param>
        public void FadeExtendedWindowIn(KryptonFormExtended window, int fadeInSleepTimer = 50)
        {
            for (FadeIn = 0.0; FadeIn <= 1.1; FadeIn += 0.1)
            {
                window.Opacity = FadeIn;

                window.Refresh();

                Thread.Sleep(fadeInSleepTimer);
            }
        }

        /// <summary>Fades the extended window out.</summary>
        /// <param name="window">The current window.</param>
        /// <param name="nextWindow">The next window.</param>
        /// <param name="fadeOutSleepTimer">The fade out sleep timer.</param>
        public void FadeExtendedWindowOut(KryptonFormExtended window, KryptonFormExtended nextWindow = null, int fadeOutSleepTimer = 50)
        {
            for (FadeOut = 90; FadeOut >= 10; FadeOut += -10)
            {
                window.Opacity = FadeOut / 100;

                window.Refresh();

                Thread.Sleep(fadeOutSleepTimer);
            }

            if (nextWindow != null)
            {
                window.Close();

                nextWindow.Show();
            }
        }
        #endregion
    }
}
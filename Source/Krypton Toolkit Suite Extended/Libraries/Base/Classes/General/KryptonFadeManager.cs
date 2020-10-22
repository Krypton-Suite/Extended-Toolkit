using System.Threading;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    /// <summary>Use this class to apply 'fading' effects to <see cref="KryptonForm">your window</see>.</summary>
    public class KryptonFadeManager
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

        /// <summary>Initializes a new instance of the <see cref="KryptonFadeManager" /> class.</summary>
        public KryptonFadeManager()
        {

        }

        #region Methods
        /// <summary>Fades the extended window in.</summary>
        /// <param name="window">The window.</param>
        /// <param name="fadeInSleepTimer">The fade in sleep timer.</param>
        public void FadeExtendedWindowIn(KryptonForm window, int fadeInSleepTimer = 50)
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
        public void FadeExtendedWindowOut(KryptonForm window, KryptonForm nextWindow = null, int fadeOutSleepTimer = 50)
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
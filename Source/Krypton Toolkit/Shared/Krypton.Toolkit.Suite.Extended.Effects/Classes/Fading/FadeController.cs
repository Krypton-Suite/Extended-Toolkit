using System.Threading;

namespace Krypton.Toolkit.Suite.Extended.Effects
{
    /// <summary>Handles the fading effects.</summary>
    internal class FadeController
    {
        #region Variables
        private double _fadeInValue, _fadeOutValue;

        private int _fadeSleepTimer;

        private KryptonForm _owner, _nextWindow;
        #endregion

        #region Properties
        /// <summary>Gets or sets the fade in value.</summary>
        /// <value>The fade in value.</value>
        public double FadeInValue { get => _fadeInValue; set => _fadeInValue = value; }

        /// <summary>Gets or sets the fade out value.</summary>
        /// <value>The fade out value.</value>
        public double FadeOutValue { get => _fadeOutValue; set => _fadeOutValue = value; }

        /// <summary>Gets or sets the fade sleep timer.</summary>
        /// <value>The fade sleep timer.</value>
        public int FadeSleepTimer { get => _fadeSleepTimer; set => _fadeSleepTimer = value; }

        /// <summary>Gets or sets the owner.</summary>
        /// <value>The owner.</value>
        public KryptonForm Owner { get => _owner; set => _owner = value; }

        /// <summary>Gets or sets the next window.</summary>
        /// <value>The next window.</value>
        public KryptonForm NextWindow { get => _nextWindow; set => _nextWindow = value; }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="FadeController" /> class.</summary>
        public FadeController() { }

        /// <summary>Initializes a new instance of the <see cref="FadeController" /> class.</summary>
        /// <param name="fadeInValue">The fade in value.</param>
        /// <param name="fadeOutValue">The fade out value.</param>
        /// <param name="fadeSleepTimer">The fade sleep timer.</param>
        /// <param name="owner">The owner.</param>
        /// <param name="nextWindow">The next window.</param>
        public FadeController(double fadeInValue, double fadeOutValue, int fadeSleepTimer, KryptonForm owner, KryptonForm nextWindow = null)
        {
            _fadeInValue = fadeInValue;

            _fadeOutValue = fadeOutValue;

            _fadeSleepTimer = fadeSleepTimer;

            _owner = owner;

            _nextWindow = nextWindow;
        }
        #endregion

        #region Methods
        /// <summary>Fades the window in.</summary>
        /// <param name="owner">The owner.</param>
        public void FadeWindowIn(KryptonForm owner)
        {
            for (_fadeInValue = 0.0; _fadeInValue <= 1.1; _fadeInValue += 0.1)
            {
                owner.Opacity = _fadeInValue;

                owner.Refresh();

                Thread.Sleep(_fadeSleepTimer);
            }
        }

        /// <summary>Fades the window out.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="nextWindow">The next window.</param>
        public void FadeWindowOut(KryptonForm owner, KryptonForm nextWindow = null)
        {
            for (_fadeOutValue = 90; _fadeOutValue >= 10; _fadeOutValue += 10)
            {
                owner.Opacity = _fadeOutValue / 100;

                owner.Refresh();

                Thread.Sleep(_fadeSleepTimer);
            }

            if (nextWindow != null)
            {
                nextWindow.Show();
            }
        }
        #endregion
    }
}
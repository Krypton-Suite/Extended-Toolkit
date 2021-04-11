using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Effects
{
    public class FadeManager : Component
    {
        #region Variables
        private double _fadeInValue, _fadeOutValue;

        private FadeController _controller = null;

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

        #region Custom Events

        #endregion

        #region Constructor
        public FadeManager()
        {
            _fadeInValue = 1;

            _fadeOutValue = 0;

            _fadeSleepTimer = 50;

            _nextWindow = null;
        }
        #endregion

        #region Methods
        public void FadeIn()
        {
            _controller = new FadeController(_fadeInValue, _fadeOutValue, _fadeSleepTimer, _owner, _nextWindow);

            _controller.FadeWindowIn(_owner);
        }

        public void FadeOut()
        {
            _controller = new FadeController(_fadeInValue, _fadeOutValue, _fadeSleepTimer, _owner, _nextWindow);

            _controller.FadeWindowOut(_owner, _nextWindow);
        }
        #endregion
    }
}
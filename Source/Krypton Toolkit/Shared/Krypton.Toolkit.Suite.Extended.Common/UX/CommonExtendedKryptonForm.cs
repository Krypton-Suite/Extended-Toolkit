using Krypton.Toolkit.Suite.Extended.Effects;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class CommonExtendedKryptonForm : KryptonForm
    {
        #region Variables
        private float _fadeSpeed;

        private FadeSpeedChoice _fadeSpeedChoice;
        #endregion

        #region Properties
        public bool UseBlur { get; set; }

        [DefaultValue(true), Description("")]
        public bool UseFade { get; set; }

        [DefaultValue(50), Description("")]
        public int SleepInterval { get; set; }

        [DefaultValue(0), Description("")]
        public float FadeSpeed { get => _fadeSpeed; set => _fadeSpeed = value; }

        [DefaultValue(typeof(FadeSpeedChoice), "FadeSpeedChoice.Normal"), Description("")]
        public FadeSpeedChoice FadeSpeedChoice { get => _fadeSpeedChoice; set => _fadeSpeedChoice = value; }
        #endregion

        #region Constructor
        public CommonExtendedKryptonForm()
        {
            UseBlur = false;

            UseFade = true;

            SleepInterval = 50;
        }
        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            if (UseFade)
            {
#if NET40_OR_GREATER || NET5_0_OR_GREATER
                FadeController.FadeIn(this, _fadeSpeedChoice);
#else
                FadeController.FadeWindowInExtended(this, SleepInterval);
#endif
            }

            BlurValues.EnableBlur = UseBlur;

            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (UseFade)
            {
#if NET40_OR_GREATER || NET5_0_OR_GREATER
                FadeController.FadeOutAndClose(this, _fadeSpeedChoice);
#else
                FadeController.FadeWindowOutExtended(this, SleepInterval);
#endif
            }

            base.OnFormClosing(e);
        }
        #endregion

        private void FadeInComplete() { }
    }
}
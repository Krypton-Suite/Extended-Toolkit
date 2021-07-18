using Krypton.Toolkit.Suite.Extended.Effects;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class CommonExtendedKryptonForm : KryptonForm
    {
        #region Variables

        #endregion

        #region Properties
        public bool UseBlur { get; set; }

        [DefaultValue(true), Description("")]
        public bool UseFade { get; set; }

        [DefaultValue(50), Description("")]
        public int SleepInterval { get; set; }

        //public static FadeSpeed FadeSpeed { get; set; }
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
#if NET40_OR_GREATER
                FadeController.FadeIn(this, FadeSpeed.Normal, FadeInComplete);
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
#if NET40_OR_GREATER
                FadeController.FadeOutAndClose(this, FadeSpeed.Normal);
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
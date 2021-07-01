namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class CommonExtendedKryptonForm : KryptonForm
    {
        #region Variables
        private double _fadeIn, _fadeOut;
        #endregion

        #region Properties
        [DefaultValue(true), Description("")]
        public bool UseFade { get; set; }

        [DefaultValue(50), Description("")]
        public int SleepInterval { get; set; }
        #endregion

        #region Constructor
        public CommonExtendedKryptonForm()
        {
            UseFade = true;

            SleepInterval = 50;
        }
        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            if (UseFade)
            {
                for (_fadeIn = 0.0; _fadeIn <= 1.1; _fadeIn += 0.1)
                {
                    Opacity = _fadeIn;

                    Refresh();

                    Thread.Sleep(SleepInterval);
                }
            }

            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (UseFade)
            {
                for (_fadeOut = 90; _fadeOut >= 10; _fadeOut += -10)
                {
                    Opacity = _fadeOut / 100;

                    Refresh();

                    Thread.Sleep(SleepInterval);
                }
            }

            base.OnFormClosing(e);
        }
        #endregion
    }
}
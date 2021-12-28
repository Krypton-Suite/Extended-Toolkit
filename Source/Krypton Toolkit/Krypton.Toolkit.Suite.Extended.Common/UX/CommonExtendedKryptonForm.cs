#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
#if NETCOREAPP3_1_OR_GREATER
                FadeControllerNETCoreSafe.FadeWindowInExtended(this, SleepInterval);
#else
                FadeController.FadeIn(this, FadeSpeedChoice, FadeSpeed);
#endif
            }

            BlurValues.EnableBlur = UseBlur;

            base.OnLoad(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (UseFade)
            {
#if NETCOREAPP3_1_OR_GREATER
                FadeControllerNETCoreSafe.FadeWindowOutExtended(this, SleepInterval);
#else
                FadeController.FadeOutAndClose(this, _fadeSpeedChoice);
#endif
            }

            base.OnFormClosing(e);
        }
        #endregion

        private void FadeInComplete() { }
    }
}
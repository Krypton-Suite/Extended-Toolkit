#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    public class KryptonFormExtended : VirtualKryptonFormExtended
    {
        #region Instance Fields

        #region Fade Items

        private bool _useBlur, _useFade;

        private float _fadeSpeed;

        private FadeSpeedChoice _fadeSpeedChoice;

        private int _sleepInterval;

        #endregion

        private KryptonFormTitleStyle _titleStyle;

        #endregion

        #region Public

        #region Fading

        [DefaultValue(false)]
        public bool UseBlur { get => _useBlur; set => _useBlur = value; }

        [DefaultValue(true), Description("")]
        public bool UseFade { get => _useFade; set => _useBlur = value; }

        [DefaultValue(50), Description("")]
        public int SleepInterval { get => _sleepInterval; set => _sleepInterval = value; }

        [DefaultValue(0), Description("")]
        public float FadeSpeed { get => _fadeSpeed; set => _fadeSpeed = value; }

        [DefaultValue(typeof(FadeSpeedChoice), "FadeSpeedChoice.Normal"), Description("")]
        public FadeSpeedChoice FadeSpeedChoice { get => _fadeSpeedChoice; set => _fadeSpeedChoice = value; }

        #endregion

        [Category(@"Appearance"), DefaultValue(typeof(KryptonFormTitleStyle), "KryptonFormTitleStyle.Inherit"), Description(@"Arranges the current window title.")]
        public KryptonFormTitleStyle TitleStyle { get => _titleStyle; set { _titleStyle = value; UpdateTitleStyle(value); } }

        public static GlobalStrings Strings { get; } = new();

        /// <summary>
        /// Gets a set of global strings used by Krypton that can be localized.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Collection of global strings.")]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        public GlobalStrings GlobalStrings => Strings;

        private bool ShouldSerializeGlobalStrings() => !Strings.IsDefault;

        /// <summary>
        /// Resets the GlobalStrings property to its default value.
        /// </summary>
        public void ResetGlobalStrings() => Strings.Reset();

        #endregion

        #region Identity

        public KryptonFormExtended()
        {
            _useFade = false;

            _fadeSpeed = 50;

            _useBlur = false;

            _sleepInterval = 50;

            _fadeSpeedChoice = FadeSpeedChoice.Normal;

            _titleStyle = KryptonFormTitleStyle.Inherit;
        }

        #endregion

        #region Implementation

        /// <summary>Updates the title style.</summary>
        /// <param name="titleStyle">The title style.</param>
        private void UpdateTitleStyle(KryptonFormTitleStyle titleStyle)
        {
            switch (titleStyle)
            {
                case KryptonFormTitleStyle.Inherit:
                    FormTitleAlign = PaletteRelativeAlign.Inherit;
                    break;
                case KryptonFormTitleStyle.Classic:
                    FormTitleAlign = PaletteRelativeAlign.Near;
                    break;
                case KryptonFormTitleStyle.Modern:
                    FormTitleAlign = PaletteRelativeAlign.Center;
                    break;
            }
        }

        #endregion

        #region Protected Overrides

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

            BlurValues.BlurWhenFocusLost = UseBlur;

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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        #endregion
    }
}
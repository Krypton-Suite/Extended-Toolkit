#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class PaletteThemeSettingsManager
    {
        #region Variables
        private PaletteThemeSettings _paletteThemeSettings = new();
        #endregion

        #region Constructor
        public PaletteThemeSettingsManager()
        {

        }
        #endregion

        #region Setters / Getters
        /// <summary>
        /// Sets the Theme to the value of themeValue.
        /// </summary>
        /// <param name="themeValue">The value of themeValue.</param>
        public void SetTheme(PaletteModeManager themeValue)
        {
            _paletteThemeSettings.CurrentTheme = themeValue;
        }

        /// <summary>
        /// Gets the Theme value.
        /// </summary>
        /// <returns>The value of themeValue.</returns>
        public PaletteModeManager GetTheme()
        {
            return _paletteThemeSettings.CurrentTheme;
        }

        /// <summary>
        /// Sets the CustomThemeFilePath to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetCustomThemeFilePath(string value)
        {
            _paletteThemeSettings.CustomThemeFilePath = value;
        }

        /// <summary>
        /// Gets the CustomThemeFilePath value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public string GetCustomThemeFilePath()
        {
            return _paletteThemeSettings.CustomThemeFilePath;
        }
        #endregion

        #region Methods
        public void SavePaletteThemeSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Do you want to save the current palette theme settings?", "Save Confirmation", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _paletteThemeSettings.Save();
                }
                else
                {
                    ResetPaletteThemeSettings(usePrompt);
                }
            }
            else
            {
                _paletteThemeSettings.Save();
            }
        }

        public void ResetPaletteThemeSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Are you sure that you want to reset the current palette theme settings back to their defaults?", "Reset Palette Theme Settings", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetPaletteThemeSettings();
                }
                else
                {
                    ResetPaletteThemeSettings();
                }
            }

            SavePaletteThemeSettings(usePrompt);
        }

        private void ResetPaletteThemeSettings()
        {
            SetTheme(PaletteModeManager.Office2010Blue);

            SetCustomThemeFilePath("");
        }
        #endregion
    }
}
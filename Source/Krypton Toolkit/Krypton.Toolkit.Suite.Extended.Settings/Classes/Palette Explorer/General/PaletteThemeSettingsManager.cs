#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class PaletteThemeSettingsManager
    {
        #region Variables
        private PaletteThemeSettings _paletteThemeSettings = new PaletteThemeSettings();
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
                DialogResult result = KryptonMessageBox.Show("Do you want to save the current palette theme settings?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                DialogResult result = KryptonMessageBox.Show("Are you sure that you want to reset the current palette theme settings back to their defaults?", "Reset Palette Theme Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
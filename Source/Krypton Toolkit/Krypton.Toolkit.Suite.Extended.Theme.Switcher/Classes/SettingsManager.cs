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

namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class SettingsManager
    {
        #region Variables
        private Properties.Settings _settings = new();
        #endregion

        #region Constructor
        public SettingsManager()
        {

        }
        #endregion

        #region Setters & Getters
        /// <summary>Sets the theme.</summary>
        /// <param name="value">The value.</param>
        public void SetSelectedTheme(PaletteMode value) => _settings.SelectedTheme = value;

        /// <summary>Gets the theme.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public PaletteMode GetSelectedTheme() => _settings.SelectedTheme;

        /// <summary>Sets the DarkTheme to the value of value.</summary>
        /// <param name="value">The desired value of DarkTheme.</param>
        public void SetDarkTheme(PaletteMode value) => _settings.DarkTheme = value;

        /// <summary>Returns the value of the DarkTheme.</summary>
        /// <returns>The value of the DarkTheme.</returns>
        public PaletteMode GetDarkTheme() => _settings.DarkTheme;

        /// <summary>Sets the LightTheme to the value of value.</summary>
        /// <param name="value">The desired value of LightTheme.</param>
        public void SetLightTheme(PaletteMode value) => _settings.LightTheme = value;

        /// <summary>Returns the value of the LightTheme.</summary>
        /// <returns>The value of the LightTheme.</returns>
        public PaletteMode GetLightTheme() => _settings.LightTheme;

        /// <summary>Sets the SelectedThemePaletteMode to the value of value.</summary>
        /// <param name="value">The desired value of SelectedThemePaletteMode.</param>
        public void SetSelectedThemePaletteMode(PaletteMode value) => _settings.SelectedThemePaletteMode = value;

        /// <summary>Returns the value of the SelectedThemePaletteMode.</summary>
        /// <returns>The value of the SelectedThemePaletteMode.</returns>
        public PaletteMode GetSelectedThemePaletteMode() => _settings.SelectedThemePaletteMode;

        /// <summary>Sets the DarkModeThemePaletteMode to the value of value.</summary>
        /// <param name="value">The desired value of DarkModeThemePaletteMode.</param>
        public void SetDarkModeThemePaletteMode(PaletteMode value) => _settings.DarkModeThemePaletteMode = value;

        /// <summary>Returns the value of the DarkModeThemePaletteMode.</summary>
        /// <returns>The value of the DarkModeThemePaletteMode.</returns>
        public PaletteMode GetDarkModeThemePaletteMode() => _settings.DarkModeThemePaletteMode;

        /// <summary>Sets the LightModeThemePaletteMode to the value of value.</summary>
        /// <param name="value">The desired value of LightModeThemePaletteMode.</param>
        public void SetLightModeThemePaletteMode(PaletteMode value) => _settings.LightModeThemePaletteMode = value;

        /// <summary>Returns the value of the LightModeThemePaletteMode.</summary>
        /// <returns>The value of the LightModeThemePaletteMode.</returns>
        public PaletteMode GetLightModeThemePaletteMode() => _settings.LightModeThemePaletteMode;

        /// <summary>Sets the custom theme path.</summary>
        /// <param name="value">The value.</param>
        public void SetCustomThemePath(string value) => _settings.CustomThemePath = value;

        /// <summary>Gets the custom theme path.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public string GetCustomThemePath() => _settings.CustomThemePath;

        /// <summary>Sets the ShowResetButton to the value of value.</summary>
        /// <param name="value">The desired value of ShowResetButton.</param>
        public void SetShowResetButton(bool value) => _settings.ShowResetButton = value;

        /// <summary>Returns the value of the ShowResetButton.</summary>
        /// <returns>The value of the ShowResetButton.</returns>
        public bool GetShowResetButton() => _settings.ShowResetButton;

        /// <summary>Sets the ShowImportButton to the value of value.</summary>
        /// <param name="value">The desired value of ShowImportButton.</param>
        public void SetShowImportButton(bool value) => _settings.ShowImportButton = value;

        /// <summary>Returns the value of the ShowImportButton.</summary>
        /// <returns>The value of the ShowImportButton.</returns>
        public bool GetShowImportButton() => _settings.ShowImportButton;

        /// <summary>Sets the PaletteName to the value of value.</summary>
        /// <param name="value">The desired value of PaletteName.</param>
        public void SetPaletteName(string value) => _settings.PaletteName = value;

        /// <summary>Returns the value of the PaletteName.</summary>
        /// <returns>The value of the PaletteName.</returns>
        public string GetPaletteName() => _settings.PaletteName;

        /// <summary>Sets the AskMe to the value of value.</summary>
        /// <param name="value">The desired value of AskMe.</param>
        public void SetAskMe(bool value) => _settings.AskMe = value;

        /// <summary>Returns the value of the AskMe.</summary>
        /// <returns>The value of the AskMe.</returns>
        public bool GetAskMe() => _settings.AskMe;
        #endregion

        #region Methods
        /// <summary>Saves the settings.</summary>
        public void SaveSettings(bool askForConfirmation = true)
        {
            if (askForConfirmation)
            {
                DialogResult result = KryptonMessageBox.Show("Are you sure that you want to save these settings?", "Save Settings", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _settings.Save();
                }
            }
            else
            {
                _settings.Save();
            }
        }

        public void ResetSettings(bool askForConfirmation = true)
        {
            if (askForConfirmation)
            {
                DialogResult result = KryptonMessageBox.Show("Are you sure that you want to reset the theme settings back to their defaults?", "Reset Theme Settings", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SetCustomThemePath(string.Empty);

                    SetPaletteName(string.Empty);

                    SetShowImportButton(true);

                    SetShowResetButton(true);

                    SetAskMe(true);

                    SetSelectedTheme(PaletteMode.Microsoft365Blue);

                    SaveSettings(true);
                }
            }
            else
            {
                SetCustomThemePath(string.Empty);

                SetPaletteName(string.Empty);

                SetShowImportButton(true);

                SetShowResetButton(true);

                SetAskMe(true);

                SetSelectedTheme(PaletteMode.Microsoft365Blue);

                SaveSettings(false);
            }
        }
        #endregion
    }
}
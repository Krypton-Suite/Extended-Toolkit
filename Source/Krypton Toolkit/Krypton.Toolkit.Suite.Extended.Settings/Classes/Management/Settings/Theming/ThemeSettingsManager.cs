namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class ThemeSettingsManager
    {
        #region Variables
        private ThemeSettings _themeSettings = new ThemeSettings();
        #endregion

        #region Constuctor
        public ThemeSettingsManager()
        {

        }
        #endregion

        #region Setters & Getters
        /// <summary>Sets the ShowResetButton to the value of value.</summary>
        /// <param name="value">The desired value of ShowResetButton.</param>
        public void SetShowResetButton(bool value) => _themeSettings.ShowResetButton = value;

        /// <summary>Returns the value of the ShowResetButton.</summary>
        /// <returns>The value of the ShowResetButton.</returns>
        public bool GetShowResetButton() => _themeSettings.ShowResetButton;

        /// <summary>Sets the ShowImportButton to the value of value.</summary>
        /// <param name="value">The desired value of ShowImportButton.</param>
        public void SetShowImportButton(bool value) => _themeSettings.ShowImportButton = value;

        /// <summary>Returns the value of the ShowImportButton.</summary>
        /// <returns>The value of the ShowImportButton.</returns>
        public bool GetShowImportButton() => _themeSettings.ShowImportButton;

        /// <summary>Sets the CustomThemePath to the value of value.</summary>
        /// <param name="value">The desired value of CustomThemePath.</param>
        public void SetCustomThemePath(string value) => _themeSettings.CustomThemePath = value;

        /// <summary>Returns the value of the CustomThemePath.</summary>
        /// <returns>The value of the CustomThemePath.</returns>
        public string GetCustomThemePath() => _themeSettings.CustomThemePath;

        /// <summary>Sets the SelectedThemePaletteMode to the value of value.</summary>
        /// <param name="value">The desired value of SelectedThemePaletteMode.</param>
        public void SetSelectedThemePaletteMode(PaletteMode value) => _themeSettings.SelectedThemePaletteMode = value;

        /// <summary>Returns the value of the SelectedThemePaletteMode.</summary>
        /// <returns>The value of the SelectedThemePaletteMode.</returns>
        public PaletteMode GetSelectedThemePaletteMode() => _themeSettings.SelectedThemePaletteMode;

        /// <summary>Sets the DarkModeThemePaletteMode to the value of value.</summary>
        /// <param name="value">The desired value of DarkModeThemePaletteMode.</param>
        public void SetDarkModeThemePaletteMode(PaletteMode value) => _themeSettings.DarkModeThemePaletteMode = value;

        /// <summary>Returns the value of the DarkModeThemePaletteMode.</summary>
        /// <returns>The value of the DarkModeThemePaletteMode.</returns>
        public PaletteMode GetDarkModeThemePaletteMode() => _themeSettings.DarkModeThemePaletteMode;

        /// <summary>Sets the LightModeThemePaletteMode to the value of value.</summary>
        /// <param name="value">The desired value of LightModeThemePaletteMode.</param>
        public void SetLightModeThemePaletteMode(PaletteMode value) => _themeSettings.LightModeThemePaletteMode = value;

        /// <summary>Returns the value of the LightModeThemePaletteMode.</summary>
        /// <returns>The value of the LightModeThemePaletteMode.</returns>
        public PaletteMode GetLightModeThemePaletteMode() => _themeSettings.LightModeThemePaletteMode;
        #endregion

        #region Save & Reset Methods
        public void SaveThemeSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Do you want to save the current theme settings?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _themeSettings.Save();
                }
                else
                {
                    ResetThemeSettings(usePrompt);
                }
            }
            else
            {
                _themeSettings.Save();
            }
        }

        public void ResetThemeSettings(bool usePrompt)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Are you sure that you want to reset the current theme settings back to their defaults?", "Reset Theme Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetThemeSettings();
                }
            }
            else
            {
                ResetThemeSettings();
            }
        }

        private void ResetThemeSettings()
        {
            SetCustomThemePath(string.Empty);

            SetDarkModeThemePaletteMode(PaletteMode.Office365Black);

            SetLightModeThemePaletteMode(PaletteMode.Office365Blue);

            SetSelectedThemePaletteMode(PaletteMode.Office365Blue);

            SetShowImportButton(true);

            SetShowResetButton(true);
        }
        #endregion
    }
}
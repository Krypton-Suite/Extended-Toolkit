#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class SettingsManager
    {
        #region Variables
        private Properties.Settings _settings = new Properties.Settings();
        #endregion

        #region Constructor
        public SettingsManager()
        {

        }
        #endregion

        #region Setters & Getters
        /// <summary>Sets the theme.</summary>
        /// <param name="value">The value.</param>
        public void SetTheme(PaletteModeManager value) => _settings.SelectedTheme = value;

        /// <summary>Gets the theme.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public PaletteModeManager GetTheme() => _settings.SelectedTheme;

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
                DialogResult result = KryptonMessageBox.Show("Are you sure that you want to save these settings?", "Save Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                DialogResult result = KryptonMessageBox.Show("Are you sure that you want to reset the theme settings back to their defaults?", "Reset Theme Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SetCustomThemePath(string.Empty);

                    SetPaletteName(string.Empty);

                    SetShowImportButton(true);

                    SetShowResetButton(true);

                    SetAskMe(true);

                    SetTheme(PaletteModeManager.Office365Blue);

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

                SetTheme(PaletteModeManager.Office365Blue);

                SaveSettings(false);
            }
        }
        #endregion
    }
}
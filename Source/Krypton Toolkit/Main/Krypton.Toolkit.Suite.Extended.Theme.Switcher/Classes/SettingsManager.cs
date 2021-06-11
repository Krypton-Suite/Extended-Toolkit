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
        #endregion

        #region Methods
        /// <summary>Saves the settings.</summary>
        public void SaveSettings()
        {
            DialogResult result = KryptonMessageBox.Show("Are you sure that you want to save these settings?", "Save Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _settings.Save();
            }
        }
        #endregion
    }
}
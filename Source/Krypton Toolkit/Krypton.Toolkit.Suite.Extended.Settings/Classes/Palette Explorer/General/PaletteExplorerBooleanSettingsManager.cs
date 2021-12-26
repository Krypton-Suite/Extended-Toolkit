#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class PaletteExplorerBooleanSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private PaletteExplorerBooleanSettings _paletteExplorerBooleanSettings = new PaletteExplorerBooleanSettings();
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets a value indicating whether [always use prompt].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [always use prompt]; otherwise, <c>false</c>.
        /// </value>
        public bool AlwaysUsePrompt { get => _alwaysUsePrompt; set => _alwaysUsePrompt = value; }

        /// <summary>
        /// Gets or sets a value indicating whether [settings modified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [settings modified]; otherwise, <c>false</c>.
        /// </value>
        public bool SettingsModified { get => _settingsModified; set => _settingsModified = value; }
        #endregion

        #region Constructor            
        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteExplorerBooleanSettingsManager"/> class.
        /// </summary>
        public PaletteExplorerBooleanSettingsManager()
        {

        }
        #endregion

        #region Property Manipulation        
        /// <summary>
        /// Sets the AlwaysUsePrompt.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetAlwaysUsePrompt(bool value) => AlwaysUsePrompt = value;

        /// <summary>
        /// Gets the AlwaysUsePrompt.
        /// </summary>
        /// <returns>The value of AlwaysUsePrompt.</returns>
        public bool GetAlwaysUsePrompt() => AlwaysUsePrompt;

        /// <summary>
        /// Sets the SettingsModified.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetSettingsModified(bool value) => SettingsModified = value;

        /// <summary>
        /// Gets the SettingsModified.
        /// </summary>
        /// <returns>The value of SettingsModified.</returns>
        public bool GetSettingsModified() => SettingsModified;
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the ShowAdvancedColourToolTips.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetShowAdvancedColourToolTips(bool value) => _paletteExplorerBooleanSettings.ShowAdvancedColourToolTips = value;

        /// <summary>
        /// Gets the ShowAdvancedColourToolTips.
        /// </summary>
        /// <returns>The value of _paletteExplorerBooleanSettings.ShowAdvancedColourToolTips.</returns>
        public bool GetShowAdvancedColourToolTips() => _paletteExplorerBooleanSettings.ShowAdvancedColourToolTips;
        #endregion

        #region Methods 
        /// <summary>
        /// Saves the boolean settings.
        /// </summary>
        /// <param name="usePrompt">if set to <c>true</c> [use prompt].</param>
        public void SaveBooleanSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Do you want to save the current boolean settings?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _paletteExplorerBooleanSettings.Save();
                }
                else
                {
                    ResetSettings(usePrompt);
                }
            }
            else
            {
                _paletteExplorerBooleanSettings.Save();
            }
        }

        /// <summary>
        /// Resets the settings.
        /// </summary>
        /// <param name="usePrompt">if set to <c>true</c> [use prompt].</param>
        public void ResetSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("This action will reset the boolean values. Do you want to continue?", "Reset Boolean Values", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetBooleanSettings();

                    SaveBooleanSettings(usePrompt);
                }
                else
                {
                    ResetBooleanSettings();

                    SaveBooleanSettings();
                }
            }
        }

        private void ResetBooleanSettings()
        {
            SetShowAdvancedColourToolTips(false);
        }
        #endregion
    }
}
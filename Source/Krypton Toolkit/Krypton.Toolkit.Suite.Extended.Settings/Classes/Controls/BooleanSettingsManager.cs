#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class BooleanSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private BooleanSettings _booleanSettings = new BooleanSettings();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether [always use prompt].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [always use prompt]; otherwise, <c>false</c>.
        /// </value>
        public bool AlwaysUsePrompt
        {
            get => _alwaysUsePrompt;

            set => _alwaysUsePrompt = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [settings modified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [settings modified]; otherwise, <c>false</c>.
        /// </value>
        public bool SettingsModified
        {
            get => _settingsModified;

            set => _settingsModified = value;
        }
        #endregion

        #region Constructor
        public BooleanSettingsManager()
        {

        }
        #endregion

        #region Settings Manipulation
        /// <summary>
        /// Sets the value of AlwaysUsePrompt to value.
        /// </summary>
        /// <param name="value">The value of AlwaysUsePrompt.</param>
        public void SetAlwaysUsePrompt(bool value)
        {
            AlwaysUsePrompt = value;
        }

        /// <summary>
        /// Returns the value of AlwaysUsePrompt.
        /// </summary>
        /// <returns>The value of AlwaysUsePrompt.</returns>
        public bool GetAlwaysUsePrompt()
        {
            return AlwaysUsePrompt;
        }

        /// <summary>
        /// Sets the value of SettingsModified to value.
        /// </summary>
        /// <param name="value">The value of SettingsModified.</param>
        public void SetSettingsModified(bool value)
        {
            SettingsModified = value;
        }

        /// <summary>
        /// Returns the value of SettingsModified.
        /// </summary>
        /// <returns>The value of SettingsModified.</returns>
        public bool GetSettingsModified()
        {
            return SettingsModified;
        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the value of UseVirusTotalUseTLS to value.
        /// </summary>
        /// <param name="value">The value of UseVirusTotalUseTLS.</param>
        public void SetUseVirusTotalUseTLS(bool value)
        {
            _booleanSettings.UseVirusTotalUseTLS = value;

            SetUseVirusTotalUseTLS(true);
        }

        /// <summary>
        /// Returns the value of UseVirusTotalUseTLS.
        /// </summary>
        /// <returns>The value of UseVirusTotalUseTLS.</returns>
        public bool GetUseVirusTotalUseTLS()
        {
            return _booleanSettings.UseVirusTotalUseTLS;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Resets to defaults.
        /// </summary>
        public void ResetToDefaults()
        {
            if (General.ResetSettings("Boolean") == DialogResult.Yes)
            {
                SetUseVirusTotalUseTLS(false);

                if (KryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the XML file application updater settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveBooleanSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (General.SaveSettings("Boolean") == DialogResult.Yes)
                {
                    _booleanSettings.Save();

                    SetSettingsModified(false);
                }
            }
            else
            {
                _booleanSettings.Save();

                SetSettingsModified(false);
            }
        }
        #endregion
    }
}
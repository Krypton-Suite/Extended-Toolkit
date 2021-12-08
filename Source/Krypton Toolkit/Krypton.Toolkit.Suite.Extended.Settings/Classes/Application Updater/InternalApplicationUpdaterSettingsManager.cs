#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    /// <summary>
    /// Manages the settings for <see cref="InternalApplicationUpdaterSettings"/>.
    /// </summary>
    public class InternalApplicationUpdaterSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private InternalApplicationUpdaterSettings _internalApplicationUpdaterSettings = new InternalApplicationUpdaterSettings();
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
            get
            {
                return _alwaysUsePrompt;
            }

            set
            {
                _alwaysUsePrompt = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [settings modified].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [settings modified]; otherwise, <c>false</c>.
        /// </value>
        public bool SettingsModified
        {
            get
            {
                return _settingsModified;
            }

            set
            {
                _settingsModified = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="InternalApplicationUpdaterSettingsManager"/> class.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public InternalApplicationUpdaterSettingsManager(bool alwaysUsePrompt = false)
        {
            SetAlwaysUsePrompt(alwaysUsePrompt);
        }
        #endregion

        #region Setter and Getters
        /// <summary>
        /// Sets the AlwaysUsePrompt to the value of value.
        /// </summary>
        /// <param name="value">The desired value of AlwaysUsePrompt.</param>
        public void SetAlwaysUsePrompt(bool value)
        {
            AlwaysUsePrompt = value;
        }

        /// <summary>
        /// Returns the value of the AlwaysUsePrompt.
        /// </summary>
        /// <returns>The value of the AlwaysUsePrompt.</returns>
        public bool GetAlwaysUsePrompt()
        {
            return AlwaysUsePrompt;
        }

        /// <summary>
        /// Sets the SettingsModified to the value of value.
        /// </summary>
        /// <param name="value">The desired value of SettingsModified.</param>
        public void SetSettingsModified(bool value)
        {
            SettingsModified = value;
        }

        /// <summary>
        /// Returns the value of the SettingsModified.
        /// </summary>
        /// <returns>The value of the SettingsModified.</returns>
        public bool GetSettingsModified()
        {
            return SettingsModified;
        }

        /// <summary>
        /// Sets the ApplicationName to the value of value.
        /// </summary>
        /// <param name="value">The desired value of ApplicationName.</param>
        public void SetApplicationName(string value)
        {
            _internalApplicationUpdaterSettings.ApplicationName = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the ApplicationName.
        /// </summary>
        /// <returns>The value of the ApplicationName.</returns>
        public string GetApplicationName()
        {
            return _internalApplicationUpdaterSettings.ApplicationName;
        }

        /// <summary>
        /// Sets the CurrentApplicationVersion to the value of value.
        /// </summary>
        /// <param name="value">The desired value of CurrentApplicationVersion.</param>
        public void SetCurrentApplicationVersion(string value)
        {
            _internalApplicationUpdaterSettings.CurrentApplicationVersion = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the CurrentApplicationVersion.
        /// </summary>
        /// <returns>The value of the CurrentApplicationVersion.</returns>
        public string GetCurrentApplicationVersion()
        {
            return _internalApplicationUpdaterSettings.CurrentApplicationVersion;
        }

        /// <summary>
        /// Sets the VersionXMLFileURL to the value of value.
        /// </summary>
        /// <param name="value">The desired value of VersionXMLFileURL.</param>
        public void SetVersionXMLFileURL(string value)
        {
            _internalApplicationUpdaterSettings.VersionXMLFileURL = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the VersionXMLFileURL.
        /// </summary>
        /// <returns>The value of the VersionXMLFileURL.</returns>
        public string GetVersionXMLFileURL()
        {
            return _internalApplicationUpdaterSettings.VersionXMLFileURL;
        }

        /// <summary>
        /// Sets the DestinationDownloadPath to the value of value.
        /// </summary>
        /// <param name="value">The desired value of DestinationDownloadPath.</param>
        public void SetDestinationDownloadPath(string value)
        {
            _internalApplicationUpdaterSettings.DestinationDownloadPath = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the DestinationDownloadPath.
        /// </summary>
        /// <returns>The value of the DestinationDownloadPath.</returns>
        public string GetDestinationDownloadPath()
        {
            return _internalApplicationUpdaterSettings.DestinationDownloadPath;
        }

        /// <summary>
        /// Sets the DisableAutomaticUpdates to the value of value.
        /// </summary>
        /// <param name="value">The desired value of DisableAutomaticUpdates.</param>
        public void SetDisableAutomaticUpdates(bool value)
        {
            _internalApplicationUpdaterSettings.DisableAutomaticUpdates = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the DisableAutomaticUpdates.
        /// </summary>
        /// <returns>The value of the DisableAutomaticUpdates.</returns>
        public bool GetDisableAutomaticUpdates()
        {
            return _internalApplicationUpdaterSettings.DisableAutomaticUpdates;
        }

        /// <summary>
        /// Sets the AlwaysUseUACElevation to the value of value.
        /// </summary>
        /// <param name="value">The desired value of AlwaysUseUACElevation.</param>
        public void SetAlwaysUseUACElevation(bool value)
        {
            _internalApplicationUpdaterSettings.AlwaysUseUACElevation = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the AlwaysUseUACElevation.
        /// </summary>
        /// <returns>The value of the AlwaysUseUACElevation.</returns>
        public bool GetAlwaysUseUACElevation()
        {
            return _internalApplicationUpdaterSettings.AlwaysUseUACElevation;
        }

        /// <summary>
        /// Sets the BetaFlag to the value of value.
        /// </summary>
        /// <param name="value">The desired value of BetaFlag.</param>
        public void SetBetaFlag(bool value)
        {
            _internalApplicationUpdaterSettings.BetaFlag = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the BetaFlag.
        /// </summary>
        /// <returns>The value of the BetaFlag.</returns>
        public bool GetBetaFlag()
        {
            return _internalApplicationUpdaterSettings.BetaFlag;
        }

        /// <summary>
        /// Sets the DateOfLastCheck to the value of value.
        /// </summary>
        /// <param name="value">The desired value of DateOfLastCheck.</param>
        public void SetDateOfLastCheck(DateTime value)
        {
            _internalApplicationUpdaterSettings.DateOfLastCheck = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the DateOfLastCheck.
        /// </summary>
        /// <returns>The value of the DateOfLastCheck.</returns>
        public DateTime GetDateOfLastCheck()
        {
            return _internalApplicationUpdaterSettings.DateOfLastCheck;
        }

        /// <summary>
        /// Sets the DateOfNextCheck to the value of value.
        /// </summary>
        /// <param name="value">The desired value of DateOfNextCheck.</param>
        public void SetDateOfNextCheck(DateTime value)
        {
            _internalApplicationUpdaterSettings.DateOfNextCheck = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the DateOfNextCheck.
        /// </summary>
        /// <returns>The value of the DateOfNextCheck.</returns>
        public DateTime GetDateOfNextCheck()
        {
            return _internalApplicationUpdaterSettings.DateOfNextCheck;
        }

        /// <summary>
        /// Sets the DateOfLastUpdateInstallation to the value of value.
        /// </summary>
        /// <param name="value">The desired value of DateOfLastUpdateInstallation.</param>
        public void SetDateOfLastUpdateInstallation(DateTime value)
        {
            _internalApplicationUpdaterSettings.DateOfLastUpdateInstallation = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the DateOfLastUpdateInstallation.
        /// </summary>
        /// <returns>The value of the DateOfLastUpdateInstallation.</returns>
        public DateTime GetDateOfLastUpdateInstallation()
        {
            return _internalApplicationUpdaterSettings.DateOfLastUpdateInstallation;
        }

        /// <summary>
        /// Sets the ApplicationIdentification to the value of value.
        /// </summary>
        /// <param name="value">The desired value of ApplicationIdentification.</param>
        public void SetApplicationIdentification(string value)
        {
            _internalApplicationUpdaterSettings.ApplicationIdentification = value;
        }

        /// <summary>
        /// Returns the value of the ApplicationIdentification.
        /// </summary>
        /// <returns>The value of the ApplicationIdentification.</returns>
        public string GetApplicationIdentification()
        {
            return _internalApplicationUpdaterSettings.ApplicationIdentification;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Resets settings to defaults.
        /// </summary>
        public void ResetToDefaults()
        {
            if (KryptonMessageBox.Show("WARNING! You are about to reset these settings back to their original state. This action cannot be undone!\nDo you want to proceed?", "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SetAlwaysUseUACElevation(false);

                SetBetaFlag(false);

                SetDisableAutomaticUpdates(false);

                SetDateOfLastCheck(DateTime.Now);

                SetDateOfLastUpdateInstallation(DateTime.Now);

                SetDateOfNextCheck(DateTime.Now);

                SetApplicationName(string.Empty);

                SetCurrentApplicationVersion(string.Empty);

                SetDestinationDownloadPath(string.Empty);

                SetVersionXMLFileURL(string.Empty);

                SetApplicationIdentification(string.Empty);

                SaveInternalApplicationUpdaterSettings(GetAlwaysUsePrompt());

                if (KryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the internal application updater settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveInternalApplicationUpdaterSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (KryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _internalApplicationUpdaterSettings.Save();

                    SetSettingsModified(false);
                }
            }
            else
            {
                _internalApplicationUpdaterSettings.Save();

                SetSettingsModified(false);
            }
        }
        #endregion
    }
}
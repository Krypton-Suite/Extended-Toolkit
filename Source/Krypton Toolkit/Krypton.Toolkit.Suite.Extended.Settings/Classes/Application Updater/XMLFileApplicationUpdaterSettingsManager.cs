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
    /// Manages the settings for <see cref="XMLFileApplicationUpdaterSettings"/>.
    /// </summary>
    public class XMLFileApplicationUpdaterSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private XMLFileApplicationUpdaterSettings _xmlFileApplicationUpdaterSettings = new XMLFileApplicationUpdaterSettings();
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
        /// Gets or sets a value indicating whether [settings modifed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [settings modifed]; otherwise, <c>false</c>.
        /// </value>
        public bool SettingsModifed
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
        /// Initialises a new instance of the <see cref="XMLFileApplicationUpdaterSettingsManager"/> class.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public XMLFileApplicationUpdaterSettingsManager(bool alwaysUsePrompt = false)
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
            SettingsModifed = value;
        }

        /// <summary>
        /// Returns the value of the SettingsModified.
        /// </summary>
        /// <returns>The value of the SettingsModified.</returns>
        public bool GetSettingsModified()
        {
            return SettingsModifed;
        }

        /// <summary>
        /// Sets the StartUpdateInstallationUponDownloadCompletion to the value of value.
        /// </summary>
        /// <param name="value">The desired value of StartUpdateInstallationUponDownloadCompletion.</param>
        public void SetStartUpdateInstallationUponDownloadCompletion(bool value)
        {
            _xmlFileApplicationUpdaterSettings.StartUpdateInstallationUponDownloadCompletion = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the StartUpdateInstallationUponDownloadCompletion.
        /// </summary>
        /// <returns>The value of the StartUpdateInstallationUponDownloadCompletion.</returns>
        public bool GetStartUpdateInstallationUponDownloadCompletion()
        {
            return _xmlFileApplicationUpdaterSettings.StartUpdateInstallationUponDownloadCompletion;
        }

        /// <summary>
        /// Sets the BetaFlag to the value of value.
        /// </summary>
        /// <param name="value">The desired value of BetaFlag.</param>
        public void SetBetaFlag(bool value)
        {
            _xmlFileApplicationUpdaterSettings.BetaFlag = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the BetaFlag.
        /// </summary>
        /// <returns>The value of the BetaFlag.</returns>
        public bool GetBetaFlag()
        {
            return _xmlFileApplicationUpdaterSettings.BetaFlag;
        }

        /// <summary>
        /// Sets the ApplicationIdentifier to the value of value.
        /// </summary>
        /// <param name="value">The desired value of ApplicationIdentifier.</param>
        public void SetApplicationIdentifier(string value)
        {
            _xmlFileApplicationUpdaterSettings.ApplicationIdentifier = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the ApplicationIdentifier.
        /// </summary>
        /// <returns>The value of the ApplicationIdentifier.</returns>
        public string GetApplicationIdentifier()
        {
            return _xmlFileApplicationUpdaterSettings.ApplicationIdentifier;
        }

        /// <summary>
        /// Sets the ServerApplicatonVersion to the value of value.
        /// </summary>
        /// <param name="value">The desired value of ServerApplicatonVersion.</param>
        public void SetServerApplicatonVersion(string value)
        {
            _xmlFileApplicationUpdaterSettings.ServerApplicatonVersion = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the ServerApplicatonVersion.
        /// </summary>
        /// <returns>The value of the ServerApplicatonVersion.</returns>
        public string GetServerApplicatonVersion()
        {
            return _xmlFileApplicationUpdaterSettings.ServerApplicatonVersion;
        }

        /// <summary>
        /// Sets the UpdatePackageType to the value of value.
        /// </summary>
        /// <param name="value">The desired value of UpdatePackageType.</param>
        public void SetUpdatePackageType(string value)
        {
            _xmlFileApplicationUpdaterSettings.UpdatePackageType = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the UpdatePackageType.
        /// </summary>
        /// <returns>The value of the UpdatePackageType.</returns>
        public string GetUpdatePackageType()
        {
            return _xmlFileApplicationUpdaterSettings.UpdatePackageType;
        }

        /// <summary>
        /// Sets the UpdatePackageSeverity to the value of value.
        /// </summary>
        /// <param name="value">The desired value of UpdatePackageSeverity.</param>
        public void SetUpdatePackageSeverity(string value)
        {
            _xmlFileApplicationUpdaterSettings.UpdatePackageSeverity = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the UpdatePackageSeverity.
        /// </summary>
        /// <returns>The value of the UpdatePackageSeverity.</returns>
        public string GetUpdatePackageSeverity()
        {
            return _xmlFileApplicationUpdaterSettings.UpdatePackageSeverity;
        }

        /// <summary>
        /// Sets the UpdatePackageName to the value of value.
        /// </summary>
        /// <param name="value">The desired value of UpdatePackageName.</param>
        public void SetUpdatePackageName(string value)
        {
            _xmlFileApplicationUpdaterSettings.UpdatePackageName = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the UpdatePackageName.
        /// </summary>
        /// <returns>The value of the UpdatePackageName.</returns>
        public string GetUpdatePackageName()
        {
            return _xmlFileApplicationUpdaterSettings.UpdatePackageName;
        }

        /// <summary>
        /// Sets the UpdatePackageServerURLDownloadLocation to the value of value.
        /// </summary>
        /// <param name="value">The desired value of UpdatePackageServerURLDownloadLocation.</param>
        public void SetUpdatePackageServerURLDownloadLocation(string value)
        {
            _xmlFileApplicationUpdaterSettings.UpdatePackageServerURLDownloadLocation = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the UpdatePackageServerURLDownloadLocation.
        /// </summary>
        /// <returns>The value of the UpdatePackageServerURLDownloadLocation.</returns>
        public string GetUpdatePackageServerURLDownloadLocation()
        {
            return _xmlFileApplicationUpdaterSettings.UpdatePackageServerURLDownloadLocation;
        }

        /// <summary>
        /// Sets the ChangelogServerURLDownloadLocation to the value of value.
        /// </summary>
        /// <param name="value">The desired value of ChangelogServerURLDownloadLocation.</param>
        public void SetChangelogServerURLDownloadLocation(string value)
        {
            _xmlFileApplicationUpdaterSettings.ChangelogServerURLDownloadLocation = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the ChangelogServerURLDownloadLocation.
        /// </summary>
        /// <returns>The value of the ChangelogServerURLDownloadLocation.</returns>
        public string GetChangelogServerURLDownloadLocation()
        {
            return _xmlFileApplicationUpdaterSettings.ChangelogServerURLDownloadLocation;
        }

        /// <summary>
        /// Sets the SpecialisedUpdateIconURL to the value of value.
        /// </summary>
        /// <param name="value">The desired value of SpecialisedUpdateIconURL.</param>
        public void SetSpecialisedUpdateIconURL(string value)
        {
            _xmlFileApplicationUpdaterSettings.SpecialisedUpdateIconURL = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the SpecialisedUpdateIconURL.
        /// </summary>
        /// <returns>The value of the SpecialisedUpdateIconURL.</returns>
        public string GetSpecialisedUpdateIconURL()
        {
            return _xmlFileApplicationUpdaterSettings.SpecialisedUpdateIconURL;
        }

        /// <summary>
        /// Sets the MD5CheckSum to the value of value.
        /// </summary>
        /// <param name="value">The desired value of MD5CheckSum.</param>
        public void SetMD5CheckSum(string value)
        {
            _xmlFileApplicationUpdaterSettings.MD5CheckSum = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the MD5CheckSum.
        /// </summary>
        /// <returns>The value of the MD5CheckSum.</returns>
        public string GetMD5CheckSum()
        {
            return _xmlFileApplicationUpdaterSettings.MD5CheckSum;
        }

        /// <summary>
        /// Sets the SHA1CheckSum to the value of value.
        /// </summary>
        /// <param name="value">The desired value of SHA1CheckSum.</param>
        public void SetSHA1CheckSum(string value)
        {
            _xmlFileApplicationUpdaterSettings.SHA1CheckSum = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the SHA1CheckSum.
        /// </summary>
        /// <returns>The value of the SHA1CheckSum.</returns>
        public string GetSHA1CheckSum()
        {
            return _xmlFileApplicationUpdaterSettings.SHA1CheckSum;
        }

        /// <summary>
        /// Sets the SHA256CheckSum to the value of value.
        /// </summary>
        /// <param name="value">The desired value of SHA256CheckSum.</param>
        public void SetSHA256CheckSum(string value)
        {
            _xmlFileApplicationUpdaterSettings.SHA256CheckSum = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the SHA256CheckSum.
        /// </summary>
        /// <returns>The value of the SHA256CheckSum.</returns>
        public string GetSHA256CheckSum()
        {
            return _xmlFileApplicationUpdaterSettings.SHA256CheckSum;
        }

        /// <summary>
        /// Sets the SHA384CheckSum to the value of value.
        /// </summary>
        /// <param name="value">The desired value of SHA384CheckSum.</param>
        public void SetSHA384CheckSum(string value)
        {
            _xmlFileApplicationUpdaterSettings.SHA384CheckSum = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the SHA384CheckSum.
        /// </summary>
        /// <returns>The value of the SHA384CheckSum.</returns>
        public string GetSHA384CheckSum()
        {
            return _xmlFileApplicationUpdaterSettings.SHA384CheckSum;
        }

        /// <summary>
        /// Sets the SHA512CheckSum to the value of value.
        /// </summary>
        /// <param name="value">The desired value of SHA512CheckSum.</param>
        public void SetSHA512CheckSum(string value)
        {
            _xmlFileApplicationUpdaterSettings.SHA512CheckSum = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the SHA512CheckSum.
        /// </summary>
        /// <returns>The value of the SHA512CheckSum.</returns>
        public string GetSHA512CheckSum()
        {
            return _xmlFileApplicationUpdaterSettings.SHA512CheckSum;
        }

        /// <summary>
        /// Sets the RIPEMD160CheckSum to the value of value.
        /// </summary>
        /// <param name="value">The desired value of RIPEMD160CheckSum.</param>
        public void SetRIPEMD160CheckSum(string value)
        {
            _xmlFileApplicationUpdaterSettings.RIPEMD160CheckSum = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the RIPEMD160CheckSum.
        /// </summary>
        /// <returns>The value of the RIPEMD160CheckSum.</returns>
        public string GetRIPEMD160CheckSum()
        {
            return _xmlFileApplicationUpdaterSettings.RIPEMD160CheckSum;
        }

        /// <summary>
        /// Sets the OptionalArguments to the value of value.
        /// </summary>
        /// <param name="value">The desired value of OptionalArguments.</param>
        public void SetOptionalArguments(string value)
        {
            _xmlFileApplicationUpdaterSettings.OptionalArguments = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the OptionalArguments.
        /// </summary>
        /// <returns>The value of the OptionalArguments.</returns>
        public string GetOptionalArguments()
        {
            return _xmlFileApplicationUpdaterSettings.OptionalArguments;
        }

        /// <summary>
        /// Sets the UpdatePackageBuildString to the value of value.
        /// </summary>
        /// <param name="value">The desired value of UpdatePackageBuildString.</param>
        public void SetUpdatePackageBuildString(string value)
        {
            _xmlFileApplicationUpdaterSettings.UpdatePackageBuildString = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the UpdatePackageBuildString.
        /// </summary>
        /// <returns>The value of the UpdatePackageBuildString.</returns>
        public string GetUpdatePackageBuildString()
        {
            return _xmlFileApplicationUpdaterSettings.UpdatePackageBuildString;
        }

        /// <summary>
        /// Sets the CheckSumFileURL to the value of value.
        /// </summary>
        /// <param name="value">The desired value of CheckSumFileURL.</param>
        public void SetCheckSumFileURL(string value)
        {
            _xmlFileApplicationUpdaterSettings.CheckSumFileURL = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the CheckSumFileURL.
        /// </summary>
        /// <returns>The value of the CheckSumFileURL.</returns>
        public string GetCheckSumFileURL()
        {
            return _xmlFileApplicationUpdaterSettings.CheckSumFileURL;
        }

        /// <summary>
        /// Sets the VirusTotalScanURL to the value of value.
        /// </summary>
        /// <param name="value">The desired value of VirusTotalScanURL.</param>
        public void SetVirusTotalScanURL(string value)
        {
            _xmlFileApplicationUpdaterSettings.VirusTotalScanURL = value;
        }

        /// <summary>
        /// Returns the value of the VirusTotalScanURL.
        /// </summary>
        /// <returns>The value of the VirusTotalScanURL.</returns>
        public string GetVirusTotalScanURL()
        {
            return _xmlFileApplicationUpdaterSettings.VirusTotalScanURL;
        }

        /// <summary>
        /// Sets the KnowledgebaseArticleNumber to the value of value.
        /// </summary>
        /// <param name="value">The desired value of KnowledgebaseArticleNumber.</param>
        public void SetKnowledgebaseArticleNumber(string value)
        {
            _xmlFileApplicationUpdaterSettings.KnowledgebaseArticleNumber = value;
        }

        /// <summary>
        /// Returns the value of the KnowledgebaseArticleNumber.
        /// </summary>
        /// <returns>The value of the KnowledgebaseArticleNumber.</returns>
        public string GetKnowledgebaseArticleNumber()
        {
            return _xmlFileApplicationUpdaterSettings.KnowledgebaseArticleNumber;
        }

        /// <summary>
        /// Sets the KnowledgebaseArticleNumberURL to the value of value.
        /// </summary>
        /// <param name="value">The desired value of KnowledgebaseArticleNumberURL.</param>
        public void SetKnowledgebaseArticleNumberURL(string value)
        {
            _xmlFileApplicationUpdaterSettings.KnowledgebaseArticleNumberURL = value;
        }

        /// <summary>
        /// Returns the value of the KnowledgebaseArticleNumberURL.
        /// </summary>
        /// <returns>The value of the KnowledgebaseArticleNumberURL.</returns>
        public string GetKnowledgebaseArticleNumberURL()
        {
            return _xmlFileApplicationUpdaterSettings.KnowledgebaseArticleNumberURL;
        }

        /// <summary>
        /// Sets the UpdatePackageDescription to the value of value.
        /// </summary>
        /// <param name="value">The desired value of UpdatePackageDescription.</param>
        public void SetUpdatePackageDescription(string value)
        {
            _xmlFileApplicationUpdaterSettings.UpdatePackageDescription = value;
        }

        /// <summary>
        /// Returns the value of the UpdatePackageDescription.
        /// </summary>
        /// <returns>The value of the UpdatePackageDescription.</returns>
        public string GetUpdatePackageDescription()
        {
            return _xmlFileApplicationUpdaterSettings.UpdatePackageDescription;
        }

        /// <summary>
        /// Sets the UpdatePackageReleaseDate to the value of value.
        /// </summary>
        /// <param name="value">The desired value of UpdatePackageReleaseDate.</param>
        public void SetUpdatePackageReleaseDate(DateTime value)
        {
            _xmlFileApplicationUpdaterSettings.UpdatePackageReleaseDate = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the UpdatePackageReleaseDate.
        /// </summary>
        /// <returns>The value of the UpdatePackageReleaseDate.</returns>
        public DateTime GetUpdatePackageReleaseDate()
        {
            return _xmlFileApplicationUpdaterSettings.UpdatePackageReleaseDate;
        }

        /// <summary>
        /// Sets the UpdatePackageBuildDate to the value of value.
        /// </summary>
        /// <param name="value">The desired value of UpdatePackageBuildDate.</param>
        public void SetUpdatePackageBuildDate(DateTime value)
        {
            _xmlFileApplicationUpdaterSettings.UpdatePackageBuildDate = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the UpdatePackageBuildDate.
        /// </summary>
        /// <returns>The value of the UpdatePackageBuildDate.</returns>
        public DateTime GetUpdatePackageBuildDate()
        {
            return _xmlFileApplicationUpdaterSettings.UpdatePackageBuildDate;
        }

        /// <summary>
        /// Sets the UpdatePackageFileSize to the value of value.
        /// </summary>
        /// <param name="value">The desired value of UpdatePackageFileSize.</param>
        public void SetUpdatePackageFileSize(long value)
        {
            _xmlFileApplicationUpdaterSettings.UpdatePackageFileSize = value;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of the UpdatePackageFileSize.
        /// </summary>
        /// <returns>The value of the UpdatePackageFileSize.</returns>
        public long GetUpdatePackageFileSize()
        {
            return _xmlFileApplicationUpdaterSettings.UpdatePackageFileSize;
        }

        /// <summary>
        /// Sets the InstallCountdown to the value of value.
        /// </summary>
        /// <param name="value">The desired value of InstallCountdown.</param>
        public void SetInstallCountdown(int value)
        {
            _xmlFileApplicationUpdaterSettings.InstallCountdown = value;
        }

        /// <summary>
        /// Returns the value of the InstallCountdown.
        /// </summary>
        /// <returns>The value of the InstallCountdown.</returns>
        public int GetInstallCountdown()
        {
            return _xmlFileApplicationUpdaterSettings.InstallCountdown;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Resets to defaults.
        /// </summary>
        public void ResetToDefaults()
        {
            if (KryptonMessageBox.Show("WARNING! You are about to reset these settings back to their original state. This action cannot be undone!\nDo you want to proceed?", "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SetStartUpdateInstallationUponDownloadCompletion(false);

                SetBetaFlag(false);

                SetApplicationIdentifier(string.Empty);

                SetServerApplicatonVersion(string.Empty);

                SetUpdatePackageType(string.Empty);

                SetUpdatePackageSeverity(string.Empty);

                SetUpdatePackageName(string.Empty);

                SetUpdatePackageDescription(string.Empty);

                SetUpdatePackageServerURLDownloadLocation(string.Empty);

                SetChangelogServerURLDownloadLocation(string.Empty);

                SetSpecialisedUpdateIconURL(string.Empty);

                SetMD5CheckSum(string.Empty);

                SetSHA1CheckSum(string.Empty);

                SetSHA256CheckSum(string.Empty);

                SetSHA384CheckSum(string.Empty);

                SetSHA512CheckSum(string.Empty);

                SetRIPEMD160CheckSum(string.Empty);

                SetOptionalArguments(string.Empty);

                SetUpdatePackageBuildString(string.Empty);

                SetCheckSumFileURL(string.Empty);

                SetVirusTotalScanURL(string.Empty);

                SetKnowledgebaseArticleNumber(string.Empty);

                SetKnowledgebaseArticleNumberURL(string.Empty);

                SetUpdatePackageReleaseDate(DateTime.Now);

                SetUpdatePackageBuildDate(DateTime.Now);

                SetUpdatePackageFileSize(0);

                SetInstallCountdown(60);

                SaveXMLFileApplicationUpdaterSettings(GetAlwaysUsePrompt());

                if (KryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the XML file application updater settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveXMLFileApplicationUpdaterSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (KryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _xmlFileApplicationUpdaterSettings.Save();

                    SetSettingsModified(false);
                }
            }
            else
            {
                _xmlFileApplicationUpdaterSettings.Save();

                SetSettingsModified(false);
            }
        }
        #endregion
    }
}
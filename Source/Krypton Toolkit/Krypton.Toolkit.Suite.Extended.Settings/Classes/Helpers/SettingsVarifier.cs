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
    public class SettingsVarifier
    {
        #region Constructor
        public SettingsVarifier()
        {

        }
        #endregion

        #region Methods        
        /// <summary>
        /// Are the internal application updater settings default.
        /// </summary>
        /// <returns></returns>
        public static bool AreInternalApplicationUpdaterSettingsDefault()
        {
            InternalApplicationUpdaterSettingsManager manager = new();

            if (manager.GetAlwaysUsePrompt() == false && manager.GetAlwaysUseUACElevation() == false && manager.GetBetaFlag() == false && manager.GetDisableAutomaticUpdates() == false && manager.GetDateOfLastCheck() == DateTime.Now && manager.GetDateOfLastUpdateInstallation() == DateTime.Now && manager.GetDateOfNextCheck() == DateTime.Now && manager.GetApplicationIdentification() == string.Empty && manager.GetApplicationName() == string.Empty && manager.GetCurrentApplicationVersion() == string.Empty && manager.GetDestinationDownloadPath() == string.Empty && manager.GetVersionXMLFileURL() == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Are the application updater theme settings default.
        /// </summary>
        /// <returns></returns>
        public static bool AreApplicationUpdaterThemeSettingsDefault()
        {
            ApplicationUpdaterThemeSettingsManager manager = new();

            if (manager.GetCurrentApplicationTheme() == PaletteMode.Office2010Blue && manager.GetCustomThemePath() == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Are the XML file application updater settings default.
        /// </summary>
        /// <returns></returns>
        public static bool AreXMLFileApplicationUpdaterSettingsDefault()
        {
            XMLFileApplicationUpdaterSettingsManager manager = new();

            if (manager.GetBetaFlag() == false && manager.GetStartUpdateInstallationUponDownloadCompletion() == false && manager.GetUpdatePackageBuildDate() == DateTime.Now && manager.GetUpdatePackageReleaseDate() == DateTime.Now && manager.GetInstallCountdown() == 60 && manager.GetUpdatePackageFileSize() == 0 && manager.GetApplicationIdentifier() == string.Empty && manager.GetChangelogServerURLDownloadLocation() == string.Empty && manager.GetCheckSumFileURL() == string.Empty && manager.GetKnowledgebaseArticleNumber() == string.Empty && manager.GetKnowledgebaseArticleNumberURL() == string.Empty && manager.GetMD5CheckSum() == string.Empty && manager.GetOptionalArguments() == string.Empty && manager.GetRIPEMD160CheckSum() == string.Empty && manager.GetServerApplicatonVersion() == string.Empty && manager.GetSHA1CheckSum() == string.Empty && manager.GetSHA256CheckSum() == string.Empty && manager.GetSHA384CheckSum() == string.Empty && manager.GetSHA512CheckSum() == string.Empty && manager.GetSpecialisedUpdateIconURL() == string.Empty && manager.GetUpdatePackageBuildString() == string.Empty && manager.GetUpdatePackageDescription() == string.Empty && manager.GetUpdatePackageName() == string.Empty && manager.GetUpdatePackageServerURLDownloadLocation() == string.Empty && manager.GetUpdatePackageSeverity() == string.Empty && manager.GetUpdatePackageType() == string.Empty && manager.GetVirusTotalScanURL() == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Are the extended controls boolean settings default.
        /// </summary>
        /// <returns></returns>
        public static bool AreExtendedControlsBooleanSettingsDefault()
        {
            BooleanSettingsManager manager = new();

            if (manager.GetUseVirusTotalUseTLS() == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Are the extended controls string settings default.
        /// </summary>
        /// <returns></returns>
        public static bool AreExtendedControlsStringSettingsDefault()
        {
            StringSettingsManager manager = new();

            if (manager.GetPaletteExplorerLocation() == string.Empty && manager.GetVirusTotalAPIKey() == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Are the extended controls theme settings default.
        /// </summary>
        /// <returns></returns>
        public static bool AreExtendedControlsThemeSettingsDefault()
        {
            ControlThemeSettingsManager manager = new();

            if (manager.GetDefaultTheme() == PaletteMode.Office2010Blue && manager.GetGlobalManager() == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Are the extended controls window location default.
        /// </summary>
        /// <returns></returns>
        public static bool AreExtendedControlsWindowLocationDefault()
        {
            WindowLocationSettingsManager manager = new();

            if (manager.GetDefaultWindowPosition() == new Point(0, 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Are the global boolean settings default.
        /// </summary>
        /// <returns></returns>
        public static bool AreGlobalBooleanSettingsDefault()
        {
            GlobalBooleanSettingsManager manager = new();

            if (manager.GetIsInDeveloperMode() == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool AreAllMergedColourSettingsDefault()
        {
            // TODO: Come back later!
            return false;
        }
        #endregion
    }
}
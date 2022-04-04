#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

using Krypton.Toolkit.Suite.Extended.Settings.Settings.Globals;

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class GlobalStringSettingsManager
    {
        #region Variables
        private GlobalStringSettings _globalStringSettings = new GlobalStringSettings();
        #endregion

        #region Constructor
        public GlobalStringSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters                
        /// <summary>
        /// Sets the base palette mode.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetBasePaletteMode(string value)
        {
            _globalStringSettings.BasePaletteMode = value;
        }

        /// <summary>
        /// Gets the base palette mode.
        /// </summary>
        /// <returns></returns>
        public string GetBasePaletteMode()
        {
            return _globalStringSettings.BasePaletteMode;
        }

        /// <summary>
        /// Sets the feedback text.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetFeedbackText(string value)
        {
            _globalStringSettings.FeedbackText = value;
        }

        /// <summary>
        /// Gets the feedback text.
        /// </summary>
        /// <returns></returns>
        public string GetFeedbackText()
        {
            return _globalStringSettings.FeedbackText;
        }

        /// <summary>
        /// Sets the PaletteExportPath to the value of pathValue.
        /// </summary>
        /// <param name="pathValue">The value of pathValue.</param>
        public void SetPaletteExportPath(string pathValue)
        {
            _globalStringSettings.PaletteExportPath = pathValue;
        }

        /// <summary>
        /// Gets the PaletteExportPath value.
        /// </summary>
        /// <returns>The value of pathValue.</returns>
        public string GetPaletteExportPath()
        {
            return _globalStringSettings.PaletteExportPath;
        }

        /// <summary>
        /// Gets the hash readable file types filter list.
        /// </summary>
        /// <returns></returns>
        public string GetHashReadableFileTypesFilterList()
        {
            return _globalStringSettings.HashReadableFileTypesFilterList;
        }

        /// <summary>
        /// Gets the hash file type extension list.
        /// </summary>
        /// <returns></returns>
        public string GetHashFileTypeExtensionList()
        {
            return _globalStringSettings.HashFileTypeExtensionList;
        }
        #endregion

        #region Save & Reset Methods
        public void SaveStringSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Do you want to save the current string settings?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //KryptonMessageBoxExtendedResult result = ExtendedKryptonMessageBox.Show("Do you want to save the current colour settings?", "Save Confirmation", KryptonMessageBoxExtendedButtons.YESNO, KryptonMessageBoxExtendedIcon.QUESTION);

                if (result == DialogResult.Yes)
                {
                    _globalStringSettings.Save();
                }
                else
                {
                    ResetSettings(usePrompt);
                }
            }
            else
            {
                _globalStringSettings.Save();
            }
        }

        public void ResetSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Are you sure that you want to reset the current string settings back to their defaults?", "Reset String Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetSettings();
                }
                else
                {
                    ResetSettings();
                }
            }
        }

        private void ResetSettings()
        {
            SetBasePaletteMode(string.Empty);

            SetFeedbackText("This will become informative...");

            SetPaletteExportPath(Environment.SpecialFolder.MyDocuments + "\\Krypton Palettes");
        }
        #endregion
    }
}
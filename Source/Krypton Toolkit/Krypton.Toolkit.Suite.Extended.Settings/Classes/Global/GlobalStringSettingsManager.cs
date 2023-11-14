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
    public class GlobalStringSettingsManager
    {
        #region Variables
        private GlobalStringSettings _globalStringSettings = new();
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
                DialogResult result = KryptonMessageBox.Show("Do you want to save the current string settings?", "Save Confirmation", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

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
                DialogResult result = KryptonMessageBox.Show("Are you sure that you want to reset the current string settings back to their defaults?", "Reset String Settings", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

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

            SetPaletteExportPath($"{Environment.SpecialFolder.MyDocuments}\\Krypton Palettes");
        }
        #endregion
    }
}
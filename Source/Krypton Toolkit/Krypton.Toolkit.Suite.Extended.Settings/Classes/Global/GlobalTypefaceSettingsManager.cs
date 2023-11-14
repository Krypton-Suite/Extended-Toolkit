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
    public class GlobalTypefaceSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private GlobalTypefaceSettings _globalTypefaceSettings = new();
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

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalTypefaceSettingsManager"/> class.
        /// </summary>
        public GlobalTypefaceSettingsManager()
        {

        }
        #endregion

        #region Settings Manipulation
        /// <summary>
        /// Sets the value of AlwaysUsePrompt to value.
        /// </summary>
        /// <param name="value">The value of AlwaysUsePrompt.</param>
        public void SetAlwaysUsePrompt(bool value) => AlwaysUsePrompt = value;

        /// <summary>
        /// Returns the value of AlwaysUsePrompt.
        /// </summary>
        /// <returns>The value of AlwaysUsePrompt.</returns>
        public bool GetAlwaysUsePrompt() => AlwaysUsePrompt;

        /// <summary>
        /// Sets the value of SettingsModified to value.
        /// </summary>
        /// <param name="value">The value of SettingsModified.</param>
        public void SetSettingsModified(bool value) => SettingsModified = value;

        /// <summary>
        /// Returns the value of SettingsModified.
        /// </summary>
        /// <returns>The value of SettingsModified.</returns>
        public bool GetSettingsModified() => SettingsModified;

        #endregion

        #region Setters & Getters

        /// <summary>Sets the bold typeface.</summary>
        /// <param name="value">The value.</param>
        public void SetBoldTypeface(Font value) => _globalTypefaceSettings.BoldTypeface = value;

        /// <summary>Gets the bold typeface.</summary>
        /// <returns></returns>
        public Font GetBoldTypeface() => _globalTypefaceSettings.BoldTypeface;

        /// <summary>Sets the cue typeface.</summary>
        /// <param name="value">The value.</param>
        public void SetCueTypeface(Font value) => _globalTypefaceSettings.CueTypeface = value;

        /// <summary>Gets the cue typeface.</summary>
        /// <returns></returns>
        public Font GetCueTypeface() => _globalTypefaceSettings.CueTypeface;

        /// <summary>Sets the normal typeface.</summary>
        /// <param name="value">The value.</param>
        public void SetNormalTypeface(Font value) => _globalTypefaceSettings.NormalTypeface = value;

        /// <summary>Gets the normal typeface.</summary>
        /// <returns></returns>
        public Font GetNormalTypeface() => _globalTypefaceSettings.NormalTypeface;

        public void SetMessageBoxButtonsTypeface(Font value) => _globalTypefaceSettings.MessageBoxButtonsTypeface = value;

        public Font GetMessageBoxButtonsTypeface() => _globalTypefaceSettings.MessageBoxButtonsTypeface;

        public void SetMessageBoxContentTypeface(Font value) => _globalTypefaceSettings.MessageBoxContentTypeface = value;

        public Font GetMessageBoxContentTypeface() => _globalTypefaceSettings.MessageBoxContentTypeface;

        #endregion

        #region Methods 
        /// <summary>Saves the typeface settings.</summary>
        /// <param name="usePrompt">if set to <c>true</c> [use prompt].</param>
        public void SaveTypefaceSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = MessageBox.Show(@"Do you want to save the current typeface settings?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _globalTypefaceSettings.Save();
                }
                else
                {
                    ResetSettings(usePrompt);
                }
            }
            else
            {
                _globalTypefaceSettings.Save();
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
                DialogResult result = MessageBox.Show(@"This action will reset the typeface values. Do you want to continue?", "Reset Boolean Values", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetTypefaceSettings();

                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    SaveTypefaceSettings(usePrompt);
                }
                else
                {
                    ResetTypefaceSettings();

                    SaveTypefaceSettings();
                }
            }
        }

        /// <summary>Resets the typeface settings.</summary>
        private void ResetTypefaceSettings()
        {
            SetBoldTypeface(new(@"Segoe UI", 8.25f, FontStyle.Bold));

            SetCueTypeface(new(@"Segoe UI", 8.25f, FontStyle.Regular));

            SetNormalTypeface(new(@"Segoe UI", 8.25f, FontStyle.Regular));

            SetMessageBoxButtonsTypeface(new(@"Segoe UI", 8.25f, FontStyle.Regular));

            SetMessageBoxContentTypeface(new(@"Segoe UI", 8.25f, FontStyle.Regular));
        }
        #endregion
    }
}
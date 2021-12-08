#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Settings.Settings.Dialogs.Text_Finder;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class TextFinderDialogSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private TextFinderDialogSettings _textFinderDialogSettings = new TextFinderDialogSettings();
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

        #region Constructors
        public TextFinderDialogSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the AlwaysUsePrompt to the value of value.
        /// </summary>
        /// <param name="value">The desired value of AlwaysUsePrompt.</param>
        public void SetAlwaysUsePrompt(bool value) => AlwaysUsePrompt = value;

        /// <summary>
        /// Returns the value of the AlwaysUsePrompt.
        /// </summary>
        /// <returns>The value of the AlwaysUsePrompt.</returns>
        public bool GetAlwaysUsePrompt() => AlwaysUsePrompt;

        /// <summary>
        /// Sets the SettingsModified to the value of value.
        /// </summary>
        /// <param name="value">The desired value of SettingsModified.</param>
        public void SetSettingsModified(bool value) => SettingsModified = value;

        /// <summary>
        /// Returns the value of the SettingsModified.
        /// </summary>
        /// <returns>The value of the SettingsModified.</returns>
        public bool GetSettingsModified() => SettingsModified;

        /// <summary>Sets the text highlighter colour.</summary>
        /// <param name="value">The value.</param>
        public void SetTextHighlighterColour(Color value) => _textFinderDialogSettings.TextHighlighterColour = value;

        /// <summary>Gets the text highlighter colour.</summary>
        /// <returns></returns>
        public Color GetTextHighlighterColour() => _textFinderDialogSettings.TextHighlighterColour;

        /// <summary>Sets the default text mask.</summary>
        /// <param name="value">The value.</param>
        public void SetDefaultTextMask(string value) => _textFinderDialogSettings.DefaultTextMask = value;

        /// <summary>Gets the default text mask.</summary>
        /// <returns></returns>
        public string GetDefaultTextMask() => _textFinderDialogSettings.DefaultTextMask;
        #endregion

        #region Methods
        /// <summary>Resets to defaults.</summary>
        public void ResetToDefaults()
        {
            DialogResult result = ExtendedKryptonMessageBox.Show("WARNING! You are about to reset these settings back to their original state. This action cannot be undone!\nDo you want to proceed?", "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                SetDefaultTextMask(string.Empty);

                // Set to yellow to make it more realistic
                SetTextHighlighterColour(Color.Yellow);

                SaveTextFinderDialogSettings(GetAlwaysUsePrompt());

                if (ExtendedKryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the text finder dialog settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveTextFinderDialogSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (ExtendedKryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _textFinderDialogSettings.Save();

                    SetSettingsModified(false);
                }
            }
            else
            {
                _textFinderDialogSettings.Save();

                SetSettingsModified(false);
            }
        }
        #endregion
    }
}
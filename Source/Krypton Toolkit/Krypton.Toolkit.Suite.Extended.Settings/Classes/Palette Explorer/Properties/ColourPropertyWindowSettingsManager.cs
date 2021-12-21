#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class ColourPropertyWindowSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private ColourPropertyWindowSettings _colourPropertyWindowSettings = new ColourPropertyWindowSettings();
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

        #region Constructor
        public ColourPropertyWindowSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the value of HotColourControl to control.
        /// </summary>
        /// <param name="control">The value of HotColourControl.</param>
        public void SetHotColourControl(Control control)
        {
            _colourPropertyWindowSettings.HotColourControl = control;
        }

        /// <summary>
        /// Returns the value of HotColourControl.
        /// </summary>
        /// <returns>The value of HotColourControl.</returns>
        public Control GetHotColourControl()
        {
            return _colourPropertyWindowSettings.HotColourControl;
        }

        /// <summary>
        /// Sets the value of ColourControlText to value.
        /// </summary>
        /// <param name="value">The value of ColourControlText.</param>
        public void SetColourControlText(string value)
        {
            _colourPropertyWindowSettings.ColourControlText = value;
        }

        /// <summary>
        /// Returns the value of ColourControlText.
        /// </summary>
        /// <returns>The value of ColourControlText.</returns>
        public string GetColourControlText()
        {
            return _colourPropertyWindowSettings.ColourControlText;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Resets to defaults.
        /// </summary>
        public void ResetToDefaults()
        {
            if (ExtendedKryptonMessageBox.Show("WARNING! You are about to reset these settings back to their original state. This action cannot be undone!\nDo you want to proceed?", "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SetHotColourControl(null);

                SetColourControlText(string.Empty);

                SaveColourPropertyWindowSettings();

                if (ExtendedKryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the colour property window settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveColourPropertyWindowSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (ExtendedKryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _colourPropertyWindowSettings.Save();

                    SetSettingsModified(false);
                }
            }
            else
            {
                _colourPropertyWindowSettings.Save();

                SetSettingsModified(false);
            }
        }
        #endregion
    }
}
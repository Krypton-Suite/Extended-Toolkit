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
    /// <summary>
    /// Manages the theme settings.
    /// </summary>
    public class ControlThemeSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private ControlThemeSettings _themeSettings = new();
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

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlThemeSettingsManager"/> class.
        /// </summary>
        public ControlThemeSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the value of DefaultTheme to paletteMode.
        /// </summary>
        /// <param name="paletteMode">The value of DefaultTheme.</param>
        public void SetDefaultTheme(PaletteMode paletteMode)
        {
            _themeSettings.DefaultTheme = paletteMode;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of DefaultTheme.
        /// </summary>
        /// <returns>The value of DefaultTheme.</returns>
        public PaletteMode GetDefaultTheme()
        {
            return _themeSettings.DefaultTheme;
        }

        /// <summary>
        /// Sets the value of GlobalManager to manager.
        /// </summary>
        /// <param name="manager">The value of GlobalManager.</param>
        public void SetGlobalManager(KryptonManager manager)
        {
            _themeSettings.GlobalManager = manager;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of GlobalManager.
        /// </summary>
        /// <returns>The value of GlobalManager.</returns>
        public KryptonManager GetGlobalManager()
        {
            return _themeSettings.GlobalManager;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Resets to defaults.
        /// </summary>
        public void ResetToDefaults()
        {
            if (General.ResetSettings("Control Theme") == DialogResult.Yes)
            {
                SetDefaultTheme(PaletteMode.Office2010Blue);

                SetGlobalManager(null);

                if (KryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the XML file application updater settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveThemeSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (General.SaveSettings("Control Theme") == DialogResult.Yes)
                {
                    _themeSettings.Save();

                    SetSettingsModified(false);
                }
            }
            else
            {
                _themeSettings.Save();

                SetSettingsModified(false);
            }
        }
        #endregion
    }
}
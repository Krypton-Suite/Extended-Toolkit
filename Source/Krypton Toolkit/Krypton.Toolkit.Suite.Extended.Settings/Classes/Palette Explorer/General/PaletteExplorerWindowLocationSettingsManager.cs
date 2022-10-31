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
    public class PaletteExplorerWindowLocationSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private PaletteExplorerWindowLocationSettings _windowLocationSettings = new PaletteExplorerWindowLocationSettings();
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
        public PaletteExplorerWindowLocationSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the value of ColourPropertiesWindowLocation to point.
        /// </summary>
        /// <param name="point">The value of ColourPropertiesWindowLocation.</param>
        public void SetColourPropertiesWindowLocation(Point point)
        {
            _windowLocationSettings.ColourPropertiesWindowLocation = point;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of ColourPropertiesWindowLocation.
        /// </summary>
        /// <returns>The value of ColourPropertiesWindowLocation.</returns>
        public Point GetColourPropertiesWindowLocation()
        {
            return _windowLocationSettings.ColourPropertiesWindowLocation;
        }

        /// <summary>
        /// Sets the value of MainWindowLocation to point.
        /// </summary>
        /// <param name="point">The value of MainWindowLocation.</param>
        public void SetMainWindowLocation(Point point)
        {
            _windowLocationSettings.MainWindowLocation = point;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of MainWindowLocation.
        /// </summary>
        /// <returns>The value of MainWindowLocation.</returns>
        public Point GetMainWindowLocation()
        {
            return _windowLocationSettings.MainWindowLocation;
        }

        /// <summary>
        /// Sets the value of PalettePropertiesPaneWindowLocation to point.
        /// </summary>
        /// <param name="point">The value of PalettePropertiesPaneWindowLocation.</param>
        public void SetPalettePropertiesPaneWindowLocation(Point point)
        {
            _windowLocationSettings.PalettePropertiesPaneWindowLocation = point;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of PalettePropertiesPaneWindowLocation.
        /// </summary>
        /// <returns>The value of PalettePropertiesPaneWindowLocation.</returns>
        public Point GetPalettePropertiesPaneWindowLocation()
        {
            return _windowLocationSettings.PalettePropertiesPaneWindowLocation;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Resets to defaults.
        /// </summary>
        public void ResetToDefaults()
        {
            if (KryptonMessageBox.Show("WARNING! You are about to reset these settings back to their original state. This action cannot be undone!\nDo you want to proceed?", "Reset Settings", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SetColourPropertiesWindowLocation(new Point(0, 0));

                SetMainWindowLocation(new Point(0, 0));

                SetPalettePropertiesPaneWindowLocation(new Point(0, 0));

                SaveWindowLocationSettings();

                if (KryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the window location settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveWindowLocationSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (KryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _windowLocationSettings.Save();

                    SetSettingsModified(false);
                }
            }
            else
            {
                _windowLocationSettings.Save();

                SetSettingsModified(false);
            }
        }
        #endregion
    }
}
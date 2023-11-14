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
    public class TextColourSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private TextColourSettings _textColourSettings = new();
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
        public TextColourSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the value of AlternativeNormalTextColour to colour.
        /// </summary>
        /// <param name="colour">The value of AlternativeNormalTextColour.</param>
        public void SetAlternativeNormalTextColour(Color colour)
        {
            _textColourSettings.AlternativeNormalTextColour = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of AlternativeNormalTextColour.
        /// </summary>
        /// <returns>The value of AlternativeNormalTextColour.</returns>
        public Color GetAlternativeNormalTextColour()
        {
            return _textColourSettings.AlternativeNormalTextColour;
        }

        /// <summary>
        /// Sets the value of DisabledTextColour to colour.
        /// </summary>
        /// <param name="colour">The value of DisabledTextColour.</param>
        public void SetDisabledTextColour(Color colour)
        {
            _textColourSettings.DisabledTextColour = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of DisabledTextColour.
        /// </summary>
        /// <returns>The value of DisabledTextColour.</returns>
        public Color GetDisabledTextColour()
        {
            return _textColourSettings.DisabledTextColour;
        }

        /// <summary>
        /// Sets the value of FocusedTextColour to colour.
        /// </summary>
        /// <param name="colour">The value of FocusedTextColour.</param>
        public void SetFocusedTextColour(Color colour)
        {
            _textColourSettings.FocusedTextColour = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of FocusedTextColour.
        /// </summary>
        /// <returns>The value of FocusedTextColour.</returns>
        public Color GetFocusedTextColour()
        {
            return _textColourSettings.FocusedTextColour;
        }

        /// <summary>
        /// Sets the value of NormalTextColour to colour.
        /// </summary>
        /// <param name="colour">The value of NormalTextColour.</param>
        public void SetNormalTextColour(Color colour)
        {
            _textColourSettings.NormalTextColour = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of NormalTextColour.
        /// </summary>
        /// <returns>The value of NormalTextColour.</returns>
        public Color GetNormalTextColour()
        {
            return _textColourSettings.NormalTextColour;
        }

        /// <summary>
        /// Sets the value of PressedTextColour to colour.
        /// </summary>
        /// <param name="colour">The value of PressedTextColour.</param>
        public void SetPressedTextColour(Color colour)
        {
            _textColourSettings.PressedTextColour = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of PressedTextColour.
        /// </summary>
        /// <returns>The value of PressedTextColour.</returns>
        public Color GetPressedTextColour()
        {
            return _textColourSettings.PressedTextColour;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Resets to defaults.
        /// </summary>
        public void ResetToDefaults()
        {
            if (KryptonMessageBox.Show("WARNING! You are about to reset these settings back to their original state. This action cannot be undone!\nDo you want to proceed?", "Reset Settings", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SetDisabledTextColour(Color.Empty);

                SetFocusedTextColour(Color.Empty);

                SetNormalTextColour(Color.Empty);

                SetPressedTextColour(Color.Empty);

                if (KryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the text colour settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveTextColourSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (KryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _textColourSettings.Save();

                    SetSettingsModified(false);
                }
            }
            else
            {
                _textColourSettings.Save();

                SetSettingsModified(false);
            }
        }

        public static void WriteARGBColoursToFile(string colourConfigurationPath)
        {

        }

        public static void WriteRGBColoursToFile(string colourConfigurationPath)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Detection
        public static bool AreTextPaletteColoursEmpty()
        {
            TextColourSettingsManager textPaletteColourManager = new();

            if (textPaletteColourManager.GetAlternativeNormalTextColour() == Color.Empty || textPaletteColourManager.GetDisabledTextColour() == Color.Empty || textPaletteColourManager.GetFocusedTextColour() == Color.Empty || textPaletteColourManager.GetNormalTextColour() == Color.Empty || textPaletteColourManager.GetPressedTextColour() == Color.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region IO Methods
        /// <summary>
        /// Creates a ARGB colour configuration file.
        /// </summary>
        public static void CreateARGBConfigurationFile(FileDialogType fileDialogType = FileDialogType.Standard)
        {
            try
            {
                switch (fileDialogType)
                {
                    case FileDialogType.Krypton:
                        break;
                    case FileDialogType.Standard:
                        break;
                    case FileDialogType.WindowsAPICodePack:
                        CommonSaveFileDialog csfd = new();

                        csfd.Title = "Save Colours To:";

                        csfd.Filters.Add(new("Colour Configuration File", ".ccf"));

                        csfd.Filters.Add(new("Normal Text File", ".txt"));

                        csfd.DefaultFileName = $"Custom Colours Configuration File - {TranslationMethods.ReturnSafeFileNameDateTimeString()}";

                        csfd.AlwaysAppendDefaultExtension = true;

                        csfd.DefaultExtension = "ccf";

                        if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
                        {
                            WriteARGBColoursToFile(csfd.FileName);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(fileDialogType), fileDialogType, null);
                }
            }
            catch (Exception exc)
            {
                ExtendedKryptonMessageBox.Show($"An unexpected error has occurred: '{exc.Message}'", "Unexpected Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Creates a RGB colour configuration file.
        /// </summary>
        public static void CreateRGBConfigurationFile(FileDialogType fileDialogType = FileDialogType.Standard)
        {
            try
            {
                switch (fileDialogType)
                {
                    case FileDialogType.Krypton:
                        break;
                    case FileDialogType.Standard:
                        break;
                    case FileDialogType.WindowsAPICodePack:
                        CommonSaveFileDialog csfd = new();

                        csfd.Title = "Save Colours To:";

                        csfd.Filters.Add(new("Colour Configuration File", ".ccf"));

                        csfd.Filters.Add(new("Normal Text File", ".txt"));

                        csfd.DefaultFileName = $"Custom Colours Configuration File - {TranslationMethods.ReturnSafeFileNameDateTimeString()}";

                        csfd.AlwaysAppendDefaultExtension = true;

                        csfd.DefaultExtension = "ccf";

                        if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
                        {
                            WriteRGBColoursToFile(csfd.FileName);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(fileDialogType), fileDialogType, null);
                }
            }
            catch (Exception exc)
            {
                ExtendedKryptonMessageBox.Show($"An unexpected error has occurred: '{exc.Message}'", "Unexpected Error", MessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
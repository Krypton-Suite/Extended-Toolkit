﻿#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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
    public class LinkTextColourSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private LinkTextColourSettings _linkTextColourSettings = new();
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
        public LinkTextColourSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the value of LinkDisabledColour to value.
        /// </summary>
        /// <param name="value">The value of LinkDisabledColour.</param>
        public void SetLinkDisabledColour(Color value)
        {
            _linkTextColourSettings.LinkDisabledColour = value;
        }

        /// <summary>
        /// Returns the value of LinkDisabledColour.
        /// </summary>
        /// <returns>The value of LinkDisabledColour.</returns>
        public Color GetLinkDisabledColour()
        {
            return _linkTextColourSettings.LinkDisabledColour;
        }

        /// <summary>
        /// Sets the value of LinkFocusedColour to colour.
        /// </summary>
        /// <param name="colour">The value of LinkFocusedColour.</param>
        public void SetLinkFocusedColour(Color colour)
        {
            _linkTextColourSettings.LinkFocusedColour = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of LinkFocusedColour.
        /// </summary>
        /// <returns>The value of LinkFocusedColour.</returns>
        public Color GetLinkFocusedColour()
        {
            return _linkTextColourSettings.LinkFocusedColour;
        }

        /// <summary>
        /// Sets the value of LinkHoverColour to colour.
        /// </summary>
        /// <param name="colour">The value of LinkHoverColour.</param>
        public void SetLinkHoverColour(Color colour)
        {
            _linkTextColourSettings.LinkHoverColour = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of LinkHoverColour.
        /// </summary>
        /// <returns>The value of LinkHoverColour.</returns>
        public Color GetLinkHoverColour()
        {
            return _linkTextColourSettings.LinkHoverColour;
        }

        /// <summary>
        /// Sets the value of LinkNormalColour to colour.
        /// </summary>
        /// <param name="colour">The value of LinkNormalColour.</param>
        public void SetLinkNormalColour(Color colour)
        {
            _linkTextColourSettings.LinkNormalColour = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of LinkNormalColour.
        /// </summary>
        /// <returns>The value of LinkNormalColour.</returns>
        public Color GetLinkNormalColour()
        {
            return _linkTextColourSettings.LinkNormalColour;
        }

        /// <summary>
        /// Sets the value of LinkVisitedColour to colour.
        /// </summary>
        /// <param name="colour">The value of LinkVisitedColour.</param>
        public void SetLinkVisitedColour(Color colour)
        {
            _linkTextColourSettings.LinkVisitedColour = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of LinkVisitedColour.
        /// </summary>
        /// <returns>The value of LinkVisitedColour.</returns>
        public Color GetLinkVisitedColour()
        {
            return _linkTextColourSettings.LinkVisitedColour;
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
                SetLinkDisabledColour(Color.Empty);

                SetLinkFocusedColour(Color.Empty);

                SetLinkHoverColour(Color.Empty);

                SetLinkNormalColour(Color.Empty);

                SetLinkVisitedColour(Color.Empty);

                if (KryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the link text colour settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveLinkTextColourSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (KryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _linkTextColourSettings.Save();

                    SetSettingsModified(false);
                }
            }
            else
            {
                _linkTextColourSettings.Save();

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
        public static bool AreLinkTextPaletteColoursEmpty()
        {
            LinkTextColourSettingsManager linkTextPaletteColourManager = new();

            if (linkTextPaletteColourManager.GetLinkNormalColour() == Color.Empty || linkTextPaletteColourManager.GetLinkFocusedColour() == Color.Empty || linkTextPaletteColourManager.GetLinkHoverColour() == Color.Empty || linkTextPaletteColourManager.GetLinkNormalColour() == Color.Empty || linkTextPaletteColourManager.GetLinkVisitedColour() == Color.Empty)
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
                // TODO: Complete this
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
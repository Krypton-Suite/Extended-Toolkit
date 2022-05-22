#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Global.Utilities;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class TextColourSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private TextColourSettings _textColourSettings = new TextColourSettings();
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
            if (KryptonMessageBox.Show("WARNING! You are about to reset these settings back to their original state. This action cannot be undone!\nDo you want to proceed?", "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                SetDisabledTextColour(Color.Empty);

                SetFocusedTextColour(Color.Empty);

                SetNormalTextColour(Color.Empty);

                SetPressedTextColour(Color.Empty);

                if (KryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                if (KryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            TextColourSettingsManager textPaletteColourManager = new TextColourSettingsManager();

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
        public static void CreateARGBConfigurationFile()
        {
            try
            {
                CommonSaveFileDialog csfd = new CommonSaveFileDialog();

                csfd.Title = "Save Colours To:";

                csfd.Filters.Add(new CommonFileDialogFilter("Colour Configuration File", ".ccf"));

                csfd.Filters.Add(new CommonFileDialogFilter("Normal Text File", ".txt"));

                csfd.DefaultFileName = $"Custom Colours Configuration File - { TranslationMethods.ReturnSafeFileNameDateTimeString() }";

                csfd.AlwaysAppendDefaultExtension = true;

                csfd.DefaultExtension = "ccf";

                if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    WriteARGBColoursToFile(csfd.FileName);
                }
            }
            catch (Exception exc)
            {
                ExtendedKryptonMessageBox.Show($"An unexpected error has occurred: '{ exc.Message }'", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Creates a RGB colour configuration file.
        /// </summary>
        public static void CreateRGBConfigurationFile()
        {
            try
            {
                CommonSaveFileDialog csfd = new CommonSaveFileDialog();

                csfd.Title = "Save Colours To:";

                csfd.Filters.Add(new CommonFileDialogFilter("Colour Configuration File", ".ccf"));

                csfd.Filters.Add(new CommonFileDialogFilter("Normal Text File", ".txt"));

                csfd.DefaultFileName = $"Custom Colours Configuration File - { TranslationMethods.ReturnSafeFileNameDateTimeString() }";

                csfd.AlwaysAppendDefaultExtension = true;

                csfd.DefaultExtension = "ccf";

                if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    WriteRGBColoursToFile(csfd.FileName);
                }
            }
            catch (Exception exc)
            {
                ExtendedKryptonMessageBox.Show($"An unexpected error has occurred: '{ exc.Message }'", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
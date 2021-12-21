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
using System.IO;

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class CustomColourSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private CustomColourSettings _customColourSettings = new CustomColourSettings();
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

        public static void WriteRGBColoursToFile(string path)
        {
            throw new NotImplementedException();
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
        public CustomColourSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the value of CustomColourOne to colour.
        /// </summary>
        /// <param name="colour">The value of CustomColourOne.</param>
        public void SetCustomColourOne(Color colour)
        {
            _customColourSettings.CustomColourOne = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of CustomColourOne.
        /// </summary>
        /// <returns>The value of CustomColourOne.</returns>
        public Color GetCustomColourOne()
        {
            return _customColourSettings.CustomColourOne;
        }

        /// <summary>
        /// Sets the value of CustomColourTwo to colour.
        /// </summary>
        /// <param name="colour">The value of CustomColourTwo.</param>
        public void SetCustomColourTwo(Color colour)
        {
            _customColourSettings.CustomColourTwo = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of CustomColourTwo.
        /// </summary>
        /// <returns>The value of CustomColourTwo.</returns>
        public Color GetCustomColourTwo()
        {
            return _customColourSettings.CustomColourTwo;
        }

        /// <summary>
        /// Sets the value of CustomColourThree to colour.
        /// </summary>
        /// <param name="colour">The value of CustomColourThree.</param>
        public void SetCustomColourThree(Color colour)
        {
            _customColourSettings.CustomColourThree = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of CustomColourThree.
        /// </summary>
        /// <returns>The value of CustomColourThree.</returns>
        public Color GetCustomColourThree()
        {
            return _customColourSettings.CustomColourThree;
        }

        /// <summary>
        /// Sets the value of CustomColourFour to colour.
        /// </summary>
        /// <param name="colour">The value of CustomColourFour.</param>
        public void SetCustomColourFour(Color colour)
        {
            _customColourSettings.CustomColourFour = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of CustomColourFour.
        /// </summary>
        /// <returns>The value of CustomColourFour.</returns>
        public Color GetCustomColourFour()
        {
            return _customColourSettings.CustomColourFour;
        }

        /// <summary>
        /// Sets the value of CustomColourFive to colour.
        /// </summary>
        /// <param name="colour">The value of CustomColourFive.</param>
        public void SetCustomColourFive(Color colour)
        {
            _customColourSettings.CustomColourFive = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of CustomColourFive.
        /// </summary>
        /// <returns>The value of CustomColourFive.</returns>
        public Color GetCustomColourFive()
        {
            return _customColourSettings.CustomColourFive;
        }

        /// <summary>
        /// Sets the value of CustomColourSix to colour.
        /// </summary>
        /// <param name="colour">The value of CustomColourSix.</param>
        public void SetCustomColourSix(Color colour)
        {
            _customColourSettings.CustomColourSix = colour;

            SetSettingsModified(true);
        }

        /// <summary>
        /// Returns the value of CustomColourSix.
        /// </summary>
        /// <returns>The value of CustomColourSix.</returns>
        public Color GetCustomColourSix()
        {
            return _customColourSettings.CustomColourSix;
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
                SetCustomColourOne(Color.Empty);

                SetCustomColourTwo(Color.Empty);

                SetCustomColourThree(Color.Empty);

                SetCustomColourFour(Color.Empty);

                SetCustomColourFive(Color.Empty);

                SetCustomColourSix(Color.Empty);

                if (KryptonMessageBox.Show($"Done! Do you want to restart the application now?", "Action Complete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }

        /// <summary>
        /// Saves the custom colour settings.
        /// </summary>
        /// <param name="alwaysUsePrompt">if set to <c>true</c> [always use prompt].</param>
        public void SaveCustomColourSettings(bool alwaysUsePrompt = false)
        {
            if (alwaysUsePrompt)
            {
                if (KryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _customColourSettings.Save();

                    SetSettingsModified(false);
                }
            }
            else
            {
                _customColourSettings.Save();

                SetSettingsModified(false);
            }
        }

        public static void WriteARGBColoursToFile(string colourFilePath)
        {
            CustomColourSettingsManager manager = new CustomColourSettingsManager();

            StreamWriter writer = new StreamWriter(colourFilePath);
        }
        #endregion

        #region Detection
        public static bool AreCustomPaletteColoursEmpty()
        {
            CustomColourSettingsManager customPaletteColourManager = new CustomColourSettingsManager();

            if (customPaletteColourManager.GetCustomColourOne() == Color.Empty || customPaletteColourManager.GetCustomColourTwo() == Color.Empty || customPaletteColourManager.GetCustomColourThree() == Color.Empty || customPaletteColourManager.GetCustomColourFour() == Color.Empty || customPaletteColourManager.GetCustomColourFive() == Color.Empty || customPaletteColourManager.GetCustomColourSix() == Color.Empty)
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
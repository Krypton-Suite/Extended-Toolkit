#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Settings.Settings.Globals;

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class GlobalBooleanSettingsManager
    {
        #region Variables
        private bool _alwaysUsePrompt = false, _settingsModified = false;

        private GlobalBooleanSettings _globalBooleanSettings = new GlobalBooleanSettings();
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
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalBooleanSettingsManager"/> class.
        /// </summary>
        public GlobalBooleanSettingsManager()
        {

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

        #region Setters & Getters
        /// <summary>
        /// Sets the AutomaticallyUpdateColours to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetAutomaticallyUpdateColours(bool value)
        {
            _globalBooleanSettings.AutomaticallyUpdateColours = value;
        }

        /// <summary>
        /// Gets the AutomaticallyUpdateColours value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public bool GetAutomaticallyUpdateColours()
        {
            return _globalBooleanSettings.AutomaticallyUpdateColours;
        }

        /// <summary>
        /// Sets the value of IsInDeveloperMode to value.
        /// </summary>
        /// <param name="value">The value of IsInDeveloperMode.</param>
        public void SetIsInDeveloperMode(bool value)
        {
            _globalBooleanSettings.IsInDeveloperMode = value;
        }

        /// <summary>
        /// Returns the value of IsInDeveloperMode.
        /// </summary>
        /// <returns>The value of IsInDeveloperMode.</returns>
        public bool GetIsInDeveloperMode()
        {
            return _globalBooleanSettings.IsInDeveloperMode;
        }

        /// <summary>
        /// Sets the DisableListItem to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetDisableListItem(bool value)
        {
            _globalBooleanSettings.DisableListItem = value;
        }

        /// <summary>
        /// Gets the DisableListItem value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public bool GetDisableListItem()
        {
            return _globalBooleanSettings.DisableListItem;
        }

        /// <summary>
        /// Sets the UseCircularPictureBoxes to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetUseCircularPictureBoxes(bool value)
        {
            _globalBooleanSettings.UseCircularPictureBoxes = value;
        }

        /// <summary>
        /// Gets the UseCircularPictureBoxes value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public bool GetUseCircularPictureBoxes()
        {
            return _globalBooleanSettings.UseCircularPictureBoxes;
        }

        /// <summary>
        /// Sets the LoadColoursOnOpenPalette to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetLoadColoursOnOpenPalette(bool value)
        {
            _globalBooleanSettings.LoadColoursOnOpenPalette = value;
        }

        /// <summary>
        /// Gets the LoadColoursOnOpenPalette value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public bool GetLoadColoursOnOpenPalette()
        {
            return _globalBooleanSettings.LoadColoursOnOpenPalette;
        }

        /// <summary>
        /// Sets the IsInBetaMode to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetIsInBetaMode(bool value)
        {
            _globalBooleanSettings.IsInBetaMode = value;
        }

        /// <summary>
        /// Gets the IsInBetaMode value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public bool GetIsInBetaMode()
        {
            return _globalBooleanSettings.IsInBetaMode;
        }

        /// <summary>
        /// Sets the HidePropertiesPane to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetHidePropertiesPane(bool value)
        {
            _globalBooleanSettings.HidePropertiesPane = value;
        }

        /// <summary>
        /// Gets the HidePropertiesPane value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public bool GetHidePropertiesPane()
        {
            return _globalBooleanSettings.HidePropertiesPane;
        }

        /// <summary>
        /// Sets the UsePromptFeedback to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetUsePromptFeedback(bool value)
        {
            _globalBooleanSettings.UsePromptFeedback = value;
        }

        /// <summary>
        /// Gets the UsePromptFeedback value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public bool GetUsePromptFeedback()
        {
            return _globalBooleanSettings.UsePromptFeedback;
        }

        /// <summary>
        /// Sets the ShowBuildTag to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetShowBuildTag(bool value)
        {
            _globalBooleanSettings.ShowBuildTag = value;
        }

        /// <summary>
        /// Gets the ShowBuildTag value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public bool GetShowBuildTag()
        {
            return _globalBooleanSettings.ShowBuildTag;
        }
        #endregion

        #region Methods 
        /// <summary>
        /// Saves the boolean settings.
        /// </summary>
        /// <param name="usePrompt">if set to <c>true</c> [use prompt].</param>
        public void SaveBooleanSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Do you want to save the current boolean settings?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _globalBooleanSettings.Save();
                }
                else
                {
                    ResetSettings(usePrompt);
                }
            }
            else
            {
                _globalBooleanSettings.Save();
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
                DialogResult result = KryptonMessageBox.Show("This action will reset the boolean values. Do you want to continue?", "Reset Boolean Values", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetBooleanSettings();

                    SaveBooleanSettings(usePrompt);
                }
                else
                {
                    ResetBooleanSettings();

                    SaveBooleanSettings();
                }
            }
        }

        private void ResetBooleanSettings()
        {
            SetAutomaticallyUpdateColours(true);

            SetIsInDeveloperMode(false);

            SetDisableListItem(false);

            SetUseCircularPictureBoxes(true);

            SetLoadColoursOnOpenPalette(true);

            SetIsInBetaMode(false);

            SetHidePropertiesPane(false);

            SetUsePromptFeedback(true);

            SetShowBuildTag(false);
        }
        #endregion
    }
}
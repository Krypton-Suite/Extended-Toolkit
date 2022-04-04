#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class ColourIntegerSettingsManager
    {
        #region Variables
        private ColourIntegerSettings _colourIntegerSettings = new ColourIntegerSettings();
        #endregion

        #region Setters and Getters

        /// <summary>
        /// Sets the AlphaChannelValue to the value of alphaChannelValue.
        /// </summary>
        /// <param name="alphaChannelValue">The value of alphaChannelValue.</param>
        public void SetAlphaChannelValue(int alphaChannelValue)
        {
            _colourIntegerSettings.AlphaChannelValue = alphaChannelValue;
        }

        /// <summary>
        /// Gets the AlphaChannelValue value.
        /// </summary>
        /// <returns>The value of alphaChannelValue.</returns>
        public int GetAlphaChannelValue()
        {
            return _colourIntegerSettings.AlphaChannelValue;
        }

        /// <summary>
        /// Sets the RedChannelValue to the value of redChannelValue.
        /// </summary>
        /// <param name="redChannelValue">The value of redChannelValue.</param>
        public void SetRedChannelValue(int redChannelValue)
        {
            _colourIntegerSettings.RedChannelValue = redChannelValue;
        }

        /// <summary>
        /// Gets the RedChannelValue value.
        /// </summary>
        /// <returns>The value of redChannelValue.</returns>
        public int GetRedChannelValue()
        {
            return _colourIntegerSettings.RedChannelValue;
        }

        /// <summary>
        /// Sets the GreenChannelValue to the value of greenChannelValue.
        /// </summary>
        /// <param name="greenChannelValue">The value of greenChannelValue.</param>
        public void SetGreenChannelValue(int greenChannelValue)
        {
            _colourIntegerSettings.GreenChannelValue = greenChannelValue;
        }

        /// <summary>
        /// Gets the GreenChannelValue value.
        /// </summary>
        /// <returns>The value of greenChannelValue.</returns>
        public int GetGreenChannelValue()
        {
            return _colourIntegerSettings.GreenChannelValue;
        }

        /// <summary>
        /// Sets the BlueChannelValue to the value of blueChannelValue.
        /// </summary>
        /// <param name="blueChannelValue">The value of blueChannelValue.</param>
        public void SetBlueChannelValue(int blueChannelValue)
        {
            _colourIntegerSettings.BlueChannelValue = blueChannelValue;
        }

        /// <summary>
        /// Gets the BlueChannelValue value.
        /// </summary>
        /// <returns>The value of blueChannelValue.</returns>
        public int GetBlueChannelValue()
        {
            return _colourIntegerSettings.BlueChannelValue;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves the colour integer settings.
        /// </summary>
        /// <param name="usePrompt">if set to <c>true</c> [use prompt].</param>
        public void SaveColourIntegerSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Do you want to save the current colour settings?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _colourIntegerSettings.Save();
                }
                else
                {
                    ResetColourIntegerSettings(usePrompt);
                }
            }
            else
            {
                _colourIntegerSettings.Save();
            }
        }

        /// <summary>
        /// Resets the settings.
        /// </summary>
        /// <param name="usePrompt">if set to <c>true</c> [use prompt].</param>
        public void ResetColourIntegerSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("This action will reset the colour values. Do you want to continue?", "Reset Colour Values", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetColourSettings();

                    SaveColourIntegerSettings(usePrompt);
                }
                else
                {
                    ResetColourSettings();

                    SaveColourIntegerSettings();
                }
            }
        }

        /// <summary>
        /// Resets the colour settings.
        /// </summary>
        private void ResetColourSettings()
        {
            SetAlphaChannelValue(255);

            SetRedChannelValue(0);

            SetGreenChannelValue(0);

            SetBlueChannelValue(0);
        }
        #endregion
    }
}
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
    public class ColourIntegerSettingsManager
    {
        #region Variables
        private ColourIntegerSettings _colourIntegerSettings = new();
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
                DialogResult result = KryptonMessageBox.Show("Do you want to save the current colour settings?", "Save Confirmation", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

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
                DialogResult result = KryptonMessageBox.Show("This action will reset the colour values. Do you want to continue?", "Reset Colour Values", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

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
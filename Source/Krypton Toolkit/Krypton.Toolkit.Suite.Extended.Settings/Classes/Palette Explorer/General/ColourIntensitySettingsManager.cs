#region MIT License
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
    public class ColourIntensitySettingsManager
    {
        #region Variables
        private ColourIntensitySettings _colourIntensitySettings = new();
        #endregion

        #region Constructors
        public ColourIntensitySettingsManager()
        {

        }
        #endregion

        #region Setters/Getters
        /// <summary>
        /// Sets the DarkestColourIntensity to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetDarkestColourIntensity(float value)
        {
            _colourIntensitySettings.DarkestColourIntensity = value;
        }

        /// <summary>
        /// Gets the DarkestColourIntensity value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public float GetDarkestColourIntensity()
        {
            return _colourIntensitySettings.DarkestColourIntensity;
        }

        /// <summary>
        /// Sets the MediumColourIntensity to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetMediumColourIntensity(float value)
        {
            _colourIntensitySettings.MediumColourIntensity = value;
        }

        /// <summary>
        /// Gets the MediumColourIntensity value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public float GetMediumColourIntensity()
        {
            return _colourIntensitySettings.MediumColourIntensity;
        }

        /// <summary>
        /// Sets the LightColourIntensity to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetLightColourIntensity(float value)
        {
            _colourIntensitySettings.LightColourIntensity = value;
        }

        /// <summary>
        /// Gets the LightColourIntensity value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public float GetLightColourIntensity()
        {
            return _colourIntensitySettings.LightColourIntensity;
        }

        /// <summary>
        /// Sets the LightestColourIntensity to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetLightestColourIntensity(float value)
        {
            _colourIntensitySettings.LightestColourIntensity = value;
        }

        /// <summary>
        /// Gets the LightestColourIntensity value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public float GetLightestColourIntensity()
        {
            return _colourIntensitySettings.LightestColourIntensity;
        }
        #endregion

        #region Methods        
        /// <summary>Resets the colour blending settings.</summary>
        /// <param name="usePrompt">Ask the user for confirmation.</param>
        public void ResetColourBlendingValues(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("This action will reset the colour blending values. Do you want to continue?", "Reset Colour Blending Values", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetColourBlendingValues();
                }
            }
            else
            {
                ResetColourBlendingValues();
            }

            SaveColourBlendingValues(usePrompt);
        }

        private void ResetColourBlendingValues()
        {
            SetDarkestColourIntensity(0.5f);

            SetMediumColourIntensity(0.25f);

            SetLightColourIntensity(0.25f);

            SetLightestColourIntensity(0.5f);
        }

        public void SaveColourBlendingValues(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Do you want to save the current colour blending settings?", "Save Confirmation", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _colourIntensitySettings.Save();
                }
                else
                {
                    ResetColourBlendingValues();
                }
            }
            else
            {
                _colourIntensitySettings.Save();
            }
        }
        #endregion
    }
}
#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class ColourIntensitySettingsManager
    {
        #region Variables
        private ColourIntensitySettings _colourIntensitySettings = new ColourIntensitySettings();
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
                DialogResult result = KryptonMessageBox.Show("This action will reset the colour blending values. Do you want to continue?", "Reset Colour Blending Values", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                DialogResult result = KryptonMessageBox.Show("Do you want to save the current colour blending settings?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
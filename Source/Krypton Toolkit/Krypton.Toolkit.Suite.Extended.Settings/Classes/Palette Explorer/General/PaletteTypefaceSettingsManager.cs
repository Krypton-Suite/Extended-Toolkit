#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    public class PaletteTypefaceSettingsManager
    {
        #region Variables
        private PaletteTypefaceSettings _paletteTypefaceSettings = new PaletteTypefaceSettings();
        #endregion

        #region Constructors
        public PaletteTypefaceSettingsManager()
        {

        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the GlobalPaletteTypeface to the value of value.
        /// </summary>
        /// <param name="value">The value of GlobalPaletteTypeface.</param>
        public void SetGlobalPaletteTypeface(Font value)
        {
            _paletteTypefaceSettings.GlobalPaletteTypeface = value;
        }

        /// <summary>
        /// Gets the GlobalPaletteTypeface value.
        /// </summary>
        /// <returns>The value of GlobalPaletteTypeface.</returns>
        public Font GetGlobalPaletteTypeface()
        {
            return _paletteTypefaceSettings.GlobalPaletteTypeface;
        }
        #endregion

        #region Save Settings        
        /// <summary>
        /// Saves the palette typeface settings.
        /// </summary>
        /// <param name="usePrompt">if set to <c>true</c> [use prompt].</param>
        public void SavePaletteTypefaceSettings(bool usePrompt = false)
        {
            if (usePrompt)
            {
                DialogResult result = ExtendedKryptonMessageBox.Show("You have changed a setting value. Do you want to save these changes?", "Setting Values Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _paletteTypefaceSettings.Save();
                }
            }
            else
            {
                _paletteTypefaceSettings.Save();
            }
        }
        #endregion

        #region Reset Settings
        public void ResetPaletteTypefaceSettings(bool usePrompt = false)
        {

        }

        private void ResetPaletteTypefaceSettings()
        {
            SetGlobalPaletteTypeface(new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular));
        }
        #endregion
    }
}
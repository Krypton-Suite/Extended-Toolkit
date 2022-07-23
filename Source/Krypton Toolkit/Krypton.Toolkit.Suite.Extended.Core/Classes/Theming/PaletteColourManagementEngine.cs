#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class PaletteColourManagementEngine
    {
        #region Constructor
        public PaletteColourManagementEngine()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseColour"></param>
        /// <param name="darkestColour"></param>
        /// <param name="mediumColour"></param>
        /// <param name="lightColour"></param>
        /// <param name="lightestColour"></param>
        public static void SetBasicPaletteColours(CircularPictureBox baseColour, CircularPictureBox darkestColour, CircularPictureBox mediumColour, CircularPictureBox lightColour, CircularPictureBox lightestColour)
        {
            BasicColourSettingsManager basicPaletteColourManager = new BasicColourSettingsManager();

            try
            {
                if (!BasicColourSettingsManager.AreBasicPaletteColoursEmpty())
                {
                    basicPaletteColourManager.ResetToDefaults();

                    basicPaletteColourManager.SetBaseColour(baseColour.BackColor);

                    basicPaletteColourManager.SetDarkColour(darkestColour.BackColor);

                    basicPaletteColourManager.SetMediumColour(mediumColour.BackColor);

                    basicPaletteColourManager.SetLightColour(lightColour.BackColor);

                    basicPaletteColourManager.SetLightestColour(lightestColour.BackColor);

                    basicPaletteColourManager.SaveBasicColourSettings();
                }
                else
                {
                    basicPaletteColourManager.SetBaseColour(baseColour.BackColor);

                    basicPaletteColourManager.SetDarkColour(darkestColour.BackColor);

                    basicPaletteColourManager.SetMediumColour(mediumColour.BackColor);

                    basicPaletteColourManager.SetLightColour(lightColour.BackColor);

                    basicPaletteColourManager.SetLightestColour(lightestColour.BackColor);

                    basicPaletteColourManager.SaveBasicColourSettings();
                }
            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exc.Message }", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                basicPaletteColourManager.ResetToDefaults();
            }
        }

        public static void SetBasicPaletteColours(PictureBox baseColour, PictureBox darkestColour, PictureBox mediumColour, PictureBox lightColour, PictureBox lightestColour)
        {
            BasicColourSettingsManager basicPaletteColourManager = new BasicColourSettingsManager();

            try
            {
                if (!BasicColourSettingsManager.AreBasicPaletteColoursEmpty())
                {
                    basicPaletteColourManager.ResetToDefaults();

                    basicPaletteColourManager.SetBaseColour(baseColour.BackColor);

                    basicPaletteColourManager.SetDarkColour(darkestColour.BackColor);

                    basicPaletteColourManager.SetMediumColour(mediumColour.BackColor);

                    basicPaletteColourManager.SetLightColour(lightColour.BackColor);

                    basicPaletteColourManager.SetLightestColour(lightestColour.BackColor);

                    basicPaletteColourManager.SaveBasicColourSettings();
                }
                else
                {
                    basicPaletteColourManager.SetBaseColour(baseColour.BackColor);

                    basicPaletteColourManager.SetDarkColour(darkestColour.BackColor);

                    basicPaletteColourManager.SetMediumColour(mediumColour.BackColor);

                    basicPaletteColourManager.SetLightColour(lightColour.BackColor);

                    basicPaletteColourManager.SetLightestColour(lightestColour.BackColor);

                    basicPaletteColourManager.SaveBasicColourSettings();
                }
            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exc.Message }", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                basicPaletteColourManager.ResetToDefaults();
            }
        }
        #endregion
    }
}
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
            BasicColourSettingsManager basicPaletteColourManager = new();

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
                ExceptionCapture.CaptureException(exc);

                basicPaletteColourManager.ResetToDefaults();
            }
        }

        public static void SetBasicPaletteColours(PictureBox baseColour, PictureBox darkestColour, PictureBox mediumColour, PictureBox lightColour, PictureBox lightestColour)
        {
            BasicColourSettingsManager basicPaletteColourManager = new();

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
                ExceptionCapture.CaptureException(exc);

                basicPaletteColourManager.ResetToDefaults();
            }
        }
        #endregion
    }
}
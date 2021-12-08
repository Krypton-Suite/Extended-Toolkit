#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public static class InformationControlManager
    {
        #region Methods
        /// <summary>
        /// Displays the colour information.
        /// </summary>
        /// <param name="targetControl">The target control.</param>
        /// <param name="showForeColourInformation">if set to <c>true</c> [show fore colour information].</param>
        /// <param name="controlDescription">The control description.</param>
        public static void DisplayColourInformation(Control targetControl, bool showForeColourInformation = false, string controlDescription = "", KryptonLabel output = null)
        {
            // Create a temporary tool tip
            ToolTip toolTipInformation = new ToolTip();

            ConversionMethods _conversionMethods = new ConversionMethods();

            if (showForeColourInformation && controlDescription != "")
            {
                toolTipInformation.SetToolTip(targetControl, $"{ controlDescription }\nBack Colour:\n\nARGB: ({ ColourUtilities.FormatColourARGBString(targetControl.BackColor)})\nRGB: ({ ColourUtilities.FormatColourRGBString(targetControl.BackColor) })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(targetControl.BackColor.R), Convert.ToInt32(targetControl.BackColor.G), Convert.ToInt32(targetControl.BackColor.B)).ToUpper() }\nHue: { targetControl.BackColor.GetHue().ToString() }\nSaturation: { targetControl.BackColor.GetSaturation().ToString() }\nBrightness: { targetControl.BackColor.GetBrightness().ToString() }\n\nFore Colour:\nARGB: ({ ColourUtilities.FormatColourARGBString(targetControl.ForeColor)})\nRGB: ({ ColourUtilities.FormatColourRGBString(targetControl.ForeColor) })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(targetControl.ForeColor.R), Convert.ToInt32(targetControl.ForeColor.G), Convert.ToInt32(targetControl.ForeColor.B)).ToUpper() }\nHue: { targetControl.BackColor.GetHue().ToString() }\nSaturation: { targetControl.BackColor.GetSaturation().ToString() }\nBrightness: { targetControl.BackColor.GetBrightness().ToString() }");

                output.Text = $"Colour values for: { controlDescription }, ARGB: ({ ColourUtilities.FormatColourARGBString(targetControl.BackColor) }), RGB: ({ ColourUtilities.FormatColourRGBString(targetControl.BackColor) })";
            }
            else if (showForeColourInformation)
            {
                toolTipInformation.SetToolTip(targetControl, $"Back Colour:\n\nARGB: ({ ColourUtilities.FormatColourARGBString(targetControl.BackColor)})\nRGB: ({ ColourUtilities.FormatColourRGBString(targetControl.BackColor) })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(targetControl.BackColor.R), Convert.ToInt32(targetControl.BackColor.G), Convert.ToInt32(targetControl.BackColor.B)).ToUpper() }\n\nFore Colour:\nARGB: ({ ColourUtilities.FormatColourARGBString(targetControl.ForeColor)})\nRGB: ({ ColourUtilities.FormatColourRGBString(targetControl.ForeColor) })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(targetControl.ForeColor.R), Convert.ToInt32(targetControl.ForeColor.G), Convert.ToInt32(targetControl.ForeColor.B)).ToUpper() }\nHue: { targetControl.BackColor.GetHue().ToString() }\nSaturation: { targetControl.BackColor.GetSaturation().ToString() }\nBrightness: { targetControl.BackColor.GetBrightness().ToString() }");

                output.Text = $"Colour values for: { controlDescription }, ARGB: ({ ColourUtilities.FormatColourARGBString(targetControl.BackColor) }), RGB: ({ ColourUtilities.FormatColourRGBString(targetControl.BackColor) })";
            }
            else if (controlDescription != "")
            {
                toolTipInformation.SetToolTip(targetControl, $"{ controlDescription }\nARGB: ({ ColourUtilities.FormatColourARGBString(targetControl.BackColor)})\nRGB: ({ ColourUtilities.FormatColourRGBString(targetControl.BackColor) })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(targetControl.BackColor.R), Convert.ToInt32(targetControl.BackColor.G), Convert.ToInt32(targetControl.BackColor.B)).ToUpper() }");

                output.Text = $"Colour values for: { controlDescription }, ARGB: ({ ColourUtilities.FormatColourARGBString(targetControl.BackColor) }), RGB: ({ ColourUtilities.FormatColourRGBString(targetControl.BackColor) })";
            }
            else
            {
                toolTipInformation.SetToolTip(targetControl, $"ARGB: ({ ColourUtilities.FormatColourARGBString(targetControl.BackColor)})\nRGB: ({ ColourUtilities.FormatColourRGBString(targetControl.BackColor) })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(targetControl.BackColor.R), Convert.ToInt32(targetControl.BackColor.G), Convert.ToInt32(targetControl.BackColor.B)).ToUpper() }\nHue: { targetControl.BackColor.GetHue().ToString() }\nSaturation: { targetControl.BackColor.GetSaturation().ToString() }\nBrightness: { targetControl.BackColor.GetBrightness().ToString() }");

                output.Text = $"Colour values for: { controlDescription }, ARGB: ({ ColourUtilities.FormatColourARGBString(targetControl.BackColor) }), RGB: ({ ColourUtilities.FormatColourRGBString(targetControl.BackColor) })";
            }
        }

        /// <summary>
        /// Resets the colour value information.
        /// </summary>
        /// <param name="output">The output.</param>
        public static void ResetColourValueInformation(KryptonLabel output)
        {
            output.Text = "";
        }
        #endregion
    }
}
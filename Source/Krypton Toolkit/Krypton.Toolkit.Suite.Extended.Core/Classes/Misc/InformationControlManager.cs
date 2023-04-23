﻿#region MIT License
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
            ToolTip toolTipInformation = new();

            ConversionMethods conversionMethods = new();

            if (showForeColourInformation && controlDescription != "")
            {
                toolTipInformation.SetToolTip(targetControl, $"{controlDescription}\nBack Colour:\n\nARGB: ({ColourUtilities.FormatColourARGBString(targetControl.BackColor)})\nRGB: ({ColourUtilities.FormatColourRGBString(targetControl.BackColor)})\nHexadecimal Value: #{conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(targetControl.BackColor.R), Convert.ToInt32(targetControl.BackColor.G), Convert.ToInt32(targetControl.BackColor.B)).ToUpper()}\nHue: {targetControl.BackColor.GetHue().ToString()}\nSaturation: {targetControl.BackColor.GetSaturation().ToString()}\nBrightness: {targetControl.BackColor.GetBrightness().ToString()}\n\nFore Colour:\nARGB: ({ColourUtilities.FormatColourARGBString(targetControl.ForeColor)})\nRGB: ({ColourUtilities.FormatColourRGBString(targetControl.ForeColor)})\nHexadecimal Value: #{conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(targetControl.ForeColor.R), Convert.ToInt32(targetControl.ForeColor.G), Convert.ToInt32(targetControl.ForeColor.B)).ToUpper()}\nHue: {targetControl.BackColor.GetHue().ToString()}\nSaturation: {targetControl.BackColor.GetSaturation().ToString()}\nBrightness: {targetControl.BackColor.GetBrightness().ToString()}");

                output.Text = $"Colour values for: {controlDescription}, ARGB: ({ColourUtilities.FormatColourARGBString(targetControl.BackColor)}), RGB: ({ColourUtilities.FormatColourRGBString(targetControl.BackColor)})";
            }
            else if (showForeColourInformation)
            {
                toolTipInformation.SetToolTip(targetControl, $"Back Colour:\n\nARGB: ({ColourUtilities.FormatColourARGBString(targetControl.BackColor)})\nRGB: ({ColourUtilities.FormatColourRGBString(targetControl.BackColor)})\nHexadecimal Value: #{conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(targetControl.BackColor.R), Convert.ToInt32(targetControl.BackColor.G), Convert.ToInt32(targetControl.BackColor.B)).ToUpper()}\n\nFore Colour:\nARGB: ({ColourUtilities.FormatColourARGBString(targetControl.ForeColor)})\nRGB: ({ColourUtilities.FormatColourRGBString(targetControl.ForeColor)})\nHexadecimal Value: #{conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(targetControl.ForeColor.R), Convert.ToInt32(targetControl.ForeColor.G), Convert.ToInt32(targetControl.ForeColor.B)).ToUpper()}\nHue: {targetControl.BackColor.GetHue().ToString()}\nSaturation: {targetControl.BackColor.GetSaturation().ToString()}\nBrightness: {targetControl.BackColor.GetBrightness().ToString()}");

                output.Text = $"Colour values for: {controlDescription}, ARGB: ({ColourUtilities.FormatColourARGBString(targetControl.BackColor)}), RGB: ({ColourUtilities.FormatColourRGBString(targetControl.BackColor)})";
            }
            else if (controlDescription != "")
            {
                toolTipInformation.SetToolTip(targetControl, $"{controlDescription}\nARGB: ({ColourUtilities.FormatColourARGBString(targetControl.BackColor)})\nRGB: ({ColourUtilities.FormatColourRGBString(targetControl.BackColor)})\nHexadecimal Value: #{conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(targetControl.BackColor.R), Convert.ToInt32(targetControl.BackColor.G), Convert.ToInt32(targetControl.BackColor.B)).ToUpper()}");

                output.Text = $"Colour values for: {controlDescription}, ARGB: ({ColourUtilities.FormatColourARGBString(targetControl.BackColor)}), RGB: ({ColourUtilities.FormatColourRGBString(targetControl.BackColor)})";
            }
            else
            {
                toolTipInformation.SetToolTip(targetControl, $"ARGB: ({ColourUtilities.FormatColourARGBString(targetControl.BackColor)})\nRGB: ({ColourUtilities.FormatColourRGBString(targetControl.BackColor)})\nHexadecimal Value: #{conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(targetControl.BackColor.R), Convert.ToInt32(targetControl.BackColor.G), Convert.ToInt32(targetControl.BackColor.B)).ToUpper()}\nHue: {targetControl.BackColor.GetHue().ToString()}\nSaturation: {targetControl.BackColor.GetSaturation().ToString()}\nBrightness: {targetControl.BackColor.GetBrightness().ToString()}");

                output.Text = $"Colour values for: {controlDescription}, ARGB: ({ColourUtilities.FormatColourARGBString(targetControl.BackColor)}), RGB: ({ColourUtilities.FormatColourRGBString(targetControl.BackColor)})";
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
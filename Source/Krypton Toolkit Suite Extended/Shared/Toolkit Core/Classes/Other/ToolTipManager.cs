using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Core
{
    public class ToolTipManager
    {
        #region Constructors
        public ToolTipManager()
        {

        }
        #endregion

        #region Methods        
        /// <summary>
        /// Displays the tool tip.
        /// </summary>
        /// <param name="information">The information.</param>
        /// <param name="target">The target.</param>
        /// <param name="colourType">Type of the colour.</param>
        /// <param name="alphaValue">The alpha value.</param>
        /// <param name="redValue">The red value.</param>
        /// <param name="greenValue">The green value.</param>
        /// <param name="blueValue">The blue value.</param>
        /// <param name="hexValue">The hexadecimal value.</param>
        /// <param name="hueValue">The hue value.</param>
        public void DisplayToolTip(ToolTip information, PictureBox target, string colourType, int alphaValue, int redValue, int greenValue, int blueValue, string hexValue, double hueValue)
        {
            information.SetToolTip(target, $"{ colourType } Colour\nARGB: ({ alphaValue.ToString() }, { redValue.ToString() }, { greenValue.ToString() }, { blueValue.ToString() })\nRGB: ({ redValue.ToString() }, { greenValue.ToString() }, { blueValue.ToString() })\nHexadecimal Value: #{ hexValue.ToUpper() }\nHue Value: { hueValue.ToString() }");
        }

        /// <summary>
        /// Displays the tool tip.
        /// </summary>
        /// <param name="information">The information.</param>
        /// <param name="target">The target.</param>
        /// <param name="colourType">Type of the colour.</param>
        /// <param name="alphaValue">The alpha value.</param>
        /// <param name="redValue">The red value.</param>
        /// <param name="greenValue">The green value.</param>
        /// <param name="blueValue">The blue value.</param>
        /// <param name="hexValue">The hexadecimal value.</param>
        /// <param name="hueValue">The hue value.</param>
        public static void DisplayToolTip(ToolTip information, CircularPictureBox target, string colourType, int alphaValue, int redValue, int greenValue, int blueValue, string hexValue, double hueValue)
        {
            information.SetToolTip(target, $"{ colourType } Colour\nARGB: ({ alphaValue.ToString() }, { redValue.ToString() }, { greenValue.ToString() }, { blueValue.ToString() })\nRGB: ({ redValue.ToString() }, { greenValue.ToString() }, { blueValue.ToString() })\nHexadecimal Value: #{ hexValue.ToUpper() }\nHue Value: { hueValue.ToString() }");
        }

        /// <summary>
        /// Displays the tool tip.
        /// </summary>
        /// <param name="information">The information.</param>
        /// <param name="target">The target.</param>
        /// <param name="colourDescription">The colour description.</param>
        /// <param name="selectedColour">The selected colour.</param>
        /// <param name="showExtraInformation">if set to <c>true</c> [show extra information].</param>
        /// <param name="useParenthesis">if set to <c>true</c> [use parenthesis].</param>
        public static void DisplayToolTip(ToolTip information, PictureBox target, string colourDescription, Color selectedColour, bool showExtraInformation = false, bool useParenthesis = false)
        {
            if (showExtraInformation)
            {
                information.SetToolTip(target, GetColourDataExtra(colourDescription, selectedColour));
            }
            else
            {
                information.SetToolTip(target, GetColourData(colourDescription, selectedColour));
            }
        }

        /// <summary>
        /// Displays the tool tip.
        /// </summary>
        /// <param name="information">The information.</param>
        /// <param name="target">The target.</param>
        /// <param name="colourDescription">The colour description.</param>
        /// <param name="selectedColour">The selected colour.</param>
        /// <param name="showExtraInformation">if set to <c>true</c> [show extra information].</param>
        /// <param name="useParenthesis">if set to <c>true</c> [use parenthesis].</param>
        public static void DisplayToolTip(ToolTip information, CircularPictureBox target, string colourDescription, Color selectedColour, bool showExtraInformation = false, bool useParenthesis = false)
        {
            if (showExtraInformation)
            {
                information.SetToolTip(target, GetColourDataExtra(colourDescription, selectedColour));
            }
            else
            {
                information.SetToolTip(target, GetColourData(colourDescription, selectedColour));
            }
        }


        private static string GetColourData(string colourDescription, Color selectedColour)
        {
            return $"{ colourDescription } Colour\nARGB: ({ ConversionMethods.FormatColourARGBString(selectedColour) })\nRGB: ({ ConversionMethods.FormatColourRGBString(selectedColour) })\nHexadecimal: { ConversionMethods.FormatColourToHexadecimal(selectedColour) }";
        }

        private static string GetColourDataExtra(string colourDescription, Color selectedColour)
        {
            return $"{ colourDescription } Colour\nARGB: ({ ConversionMethods.FormatColourARGBString(selectedColour) })\nRGB: ({ ConversionMethods.FormatColourRGBString(selectedColour) })\nHexadecimal: { ConversionMethods.FormatColourToHexadecimal(selectedColour) }\n\nHue: { selectedColour.GetHue() }\nSaturation: { selectedColour.GetSaturation() }\nBrightness: { selectedColour.GetBrightness() }";
        }
        #endregion
    }
}
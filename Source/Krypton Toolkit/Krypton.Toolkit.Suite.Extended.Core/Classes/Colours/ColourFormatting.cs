#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class ColourFormatting
    {
        #region Formatting Methods
        /// <summary>Formats the colour as a string.</summary>
        /// <param name="chosenColour">The chosen colour.</param>
        /// <returns>The colour as a string.</returns>
        public static string FormatColourAsString(Color chosenColour) => chosenColour.ToArgb().ToString();

        /// <summary>Formats the colour as a RGB string.</summary>
        /// <param name="chosenColour">The chosen colour.</param>
        /// <returns></returns>
        public static string FormatColourAsRGBString(Color chosenColour) => $"Red: { chosenColour.R }, Green: { chosenColour.G }, Blue: { chosenColour.B }";

        public static Color FormatStringColourAsColour(string colourString)
        {
            Color outputColour = Color.FromArgb(Convert.ToInt32(colourString));

            return outputColour;
        }
        #endregion
    }
}
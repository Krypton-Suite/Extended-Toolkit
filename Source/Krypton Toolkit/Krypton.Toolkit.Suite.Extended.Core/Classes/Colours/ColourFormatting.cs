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
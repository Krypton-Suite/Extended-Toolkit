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

using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class ColourInformation
    {
        #region Constructor
        public ColourInformation()
        {

        }
        #endregion

        #region Methods
        /// <summary>Returns the colour informtion.</summary>
        /// <param name="colour">The colour.</param>
        /// <param name="colourHeader">The colour header.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static string ReturnColourInformtion(Color colour, string colourHeader = null)
        {
            StringBuilder builder = new StringBuilder();

            if (colourHeader != null)
            {
                builder.Append($"{ colourHeader }:\nARGB: { colour.ToArgb() }\nRGB: { colour.R }, { colour.G }, { colour.B }\nHex: { ColorTranslator.ToHtml(colour) }"); //Known Name: { Color.FromKnownColor(colour) }")
            }
            else
            {
                builder.Append($"ARGB: { colour.ToArgb() }\nRGB: { colour.R }, { colour.G }, { colour.B }\nHex: { ColorTranslator.ToHtml(colour) }");
            }

            return builder.ToString();
        }

        /// <summary>Sets the tooltip.</summary>
        /// <param name="control">The control.</param>
        /// <param name="colourHeader">The colour header.</param>
        public static void SetTooltip(Control control, string colourHeader = null)
        {
            ToolTip temp = new ToolTip();

            temp.SetToolTip(control, ReturnColourInformtion(control.BackColor, $"{ colourHeader } Colour"));
        }
        #endregion
    }
}
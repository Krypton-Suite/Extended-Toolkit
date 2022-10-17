#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourHexadecimalValuesEventArgs : EventArgs
    {
        #region Variables
        private Color _colour;

        private string _colourHexadecimalValue;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set => _colour = value; }

        public string ColourHexadecimalValue { get => _colourHexadecimalValue; set => _colourHexadecimalValue = value; }
        #endregion

        #region Constructors
        public ColourHexadecimalValuesEventArgs(Color colour)
        {
            Colour = colour;
        }

        public ColourHexadecimalValuesEventArgs(string colourHexadecimalValue)
        {
            ColourHexadecimalValue = colourHexadecimalValue;
        }
        #endregion

        #region Methods
        public string TranslateColourToHexadecimal(Color colour) => ColorTranslator.ToHtml(colour);

        public Color TranslateHexadecimalToColour(string hexadecimalValue)
        {
            Color result;

            try
            {
                if (!hexadecimalValue.StartsWith("#"))
                {
                    string tempString = $"#{ hexadecimalValue }";

                    return ColorTranslator.FromHtml(tempString);
                }
                else
                {
                    return ColorTranslator.FromHtml(hexadecimalValue);
                }
            }
            catch (Exception e)
            {
                return Color.Empty;
            }

            return Color.Empty;
        }
        #endregion
    }
}
#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    // hex colorsets store web-formatted colors (e.g., '#FFAA66') in a string array.

    public abstract class HexColourset : IPalette
    {
        public (byte r, byte g, byte b) GetRGB(int index)
        {
            index %= hexColors.Length;

            string hexColor = hexColors[index];
            if (!hexColor.StartsWith("#"))
            {
                hexColor = $"#{hexColor}";
            }

            if (hexColor.Length != 7)
            {
                throw new InvalidOperationException("invalid hex color string");
            }

            Color color = ColorTranslator.FromHtml(hexColor);

            return (color.R, color.G, color.B);
        }

        public int Count() => hexColors is null ? 0 : hexColors.Length;

        public abstract string[] hexColors { get; }
    }
}

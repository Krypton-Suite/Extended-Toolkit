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


#pragma warning disable CS1574, CS1584, CS1581, CS1580
namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    /// <summary>
    /// Specifies the style of a color cell border.
    /// </summary>
    public enum ColourCellBorderStyle
    {
        /// <summary>
        /// No border.
        /// </summary>
        None,

        /// <summary>
        /// A single line border.
        /// </summary>
        FixedSingle,

        /// <summary>
        /// A contrasting double border with a soft inner outline using the color of the cell.
        /// </summary>
        DoubleSoft
    }


#pragma warning disable CS1574 // XML comment has cref attribute that could not be resolved
}
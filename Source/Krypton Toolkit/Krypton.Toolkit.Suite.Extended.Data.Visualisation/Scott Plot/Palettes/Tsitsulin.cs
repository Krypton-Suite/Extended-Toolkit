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

/* A 25-color pelette based on Anton Tsitsulin's 12-color palette
 * http://tsitsul.in/blog/coloropt
 * https://github.com/xgfs/coloropt
 */
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Tsitsulin : HexColourset, IPalette
    {
        public override string[] hexColors => new string[]
        {
            "#ebac23", "#b80058", "#008cf9", "#006e00", "#00bbad",
            "#d163e6", "#b24502", "#ff9287", "#5954d6", "#00c6f8",
            "#878500", "#00a76c",
            "#f6da9c", "#ff5caa", "#8accff", "#4bff4b", "#6efff4",
            "#edc1f5", "#feae7c", "#ffc8c3", "#bdbbef", "#bdf2ff",
            "#fffc43", "#65ffc8",
            "#aaaaaa",
        };
    }
}

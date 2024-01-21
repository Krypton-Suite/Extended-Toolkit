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
    /* This module will be expanded in ScottPlot 5 */
    public static class Palette
    {
        public static ScottPlotPalette Amber => new(new Amber());
        public static ScottPlotPalette Aurora => new(new Aurora());
        public static ScottPlotPalette Category10 => new(new Category10());
        public static ScottPlotPalette Category20 => new(new Category20());
        public static ScottPlotPalette ColorblindFriendly => new(new ColourBlindFriendly());
        public static ScottPlotPalette Dark => new(new Dark());
        public static ScottPlotPalette DarkPastel => new(new DarkPastel());
        public static ScottPlotPalette Frost => new(new Frost());
        public static ScottPlotPalette Microcharts => new(new Microcharts());
        public static ScottPlotPalette Nero => new(new Nero());
        public static ScottPlotPalette Nord => new(new Nord());
        public static ScottPlotPalette OneHalf => new(new OneHalf());
        public static ScottPlotPalette OneHalfDark => new(new OneHalfDark());
        public static ScottPlotPalette PolarNight => new(new PolarNight());
        public static ScottPlotPalette Redness => new(new Redness());
        public static ScottPlotPalette SnowStorm => new(new Snowstorm());
        public static ScottPlotPalette Tsitsulin => new(new Tsitsulin());

        /// <summary>
        /// Create a new color palette from an array of HTML colors
        /// </summary>
        public static ScottPlotPalette FromHtmlColors(string[] htmlColors)
        {
            return new ScottPlotPalette(htmlColors);
        }

        /// <summary>
        /// Return an array containing every available style
        /// </summary>
        public static ScottPlotPalette[] GetPalettes()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsClass)
                .Where(x => !x.IsAbstract)
                .Where(x => x.GetInterfaces().Contains(typeof(IPalette)))
                .Select(x => FormatterServices.GetUninitializedObject(x) as IPalette)
                .Select(x => new ScottPlotPalette(x))
                .Where(x => x.Count() > 0)
                .ToArray();
        }
    }
}
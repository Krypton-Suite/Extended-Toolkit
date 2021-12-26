#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
                .Select(x => (IPalette)FormatterServices.GetUninitializedObject(x))
                .Select(x => new ScottPlotPalette(x))
                .Where(x => x.Count() > 0)
                .ToArray();
        }
    }
}
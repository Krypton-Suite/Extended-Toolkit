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
        public static ScottPlot.Drawing.Palette Amber => new(new Amber());
        public static ScottPlot.Drawing.Palette Aurora => new(new Aurora());
        public static ScottPlot.Drawing.Palette Category10 => new(new Category10());
        public static ScottPlot.Drawing.Palette Category20 => new(new Category20());
        public static ScottPlot.Drawing.Palette ColorblindFriendly => new(new ColourBlindFriendly());
        public static ScottPlot.Drawing.Palette Dark => new(new Dark());
        public static ScottPlot.Drawing.Palette DarkPastel => new(new DarkPastel());
        public static ScottPlot.Drawing.Palette Frost => new(new Frost());
        public static ScottPlot.Drawing.Palette Microcharts => new(new Microcharts());
        public static ScottPlot.Drawing.Palette Nero => new(new Nero());
        public static ScottPlot.Drawing.Palette Nord => new(new Nord());
        public static ScottPlot.Drawing.Palette OneHalf => new(new OneHalf());
        public static ScottPlot.Drawing.Palette OneHalfDark => new(new OneHalfDark());
        public static ScottPlot.Drawing.Palette PolarNight => new(new PolarNight());
        public static ScottPlot.Drawing.Palette Redness => new(new Redness());
        public static ScottPlot.Drawing.Palette SnowStorm => new(new Snowstorm());
        public static ScottPlot.Drawing.Palette Tsitsulin => new(new Tsitsulin());

        /// <summary>
        /// Create a new color palette from an array of HTML colors
        /// </summary>
        public static ScottPlot.Drawing.Palette FromHtmlColors(string[] htmlColors)
        {
            return new ScottPlot.Drawing.Palette(htmlColors);
        }

        /// <summary>
        /// Return an array containing every available style
        /// </summary>
        public static ScottPlot.Drawing.Palette[] GetPalettes()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsClass)
                .Where(x => !x.IsAbstract)
                .Where(x => x.GetInterfaces().Contains(typeof(IPalette)))
                .Select(x => (IPalette)FormatterServices.GetUninitializedObject(x))
                .Select(x => new Drawing.Palette(x))
                .Where(x => x.Count() > 0)
                .ToArray();
        }
    }
}
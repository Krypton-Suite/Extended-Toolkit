#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /* This module will be retired in ScottPlot 5 in favor of ScottPlot.Palette */
    public class ScottPlotPalette
    {
        /* These properties have been included for backwards compatibility.
         * They are named identical to members of the old enumeration with the same name as this class.
         * This list does not have to be expanded as new palettes are added.
         */
        public static ScottPlotPalette Aurora => new(new Aurora());
        public static ScottPlotPalette Category10 => new(new Category10());
        public static ScottPlotPalette Category20 => new(new Category20());
        public static ScottPlotPalette ColorblindFriendly => new(new ColourBlindFriendly());
        public static ScottPlotPalette Dark => new(new Dark());
        public static ScottPlotPalette DarkPastel => new(new DarkPastel());
        public static ScottPlotPalette Frost => new(new Frost());
        public static ScottPlotPalette Microcharts => new(new Microcharts());
        public static ScottPlotPalette Nord => new(new Nord());
        public static ScottPlotPalette OneHalf => new(new OneHalf());
        public static ScottPlotPalette OneHalfDark => new(new OneHalfDark());
        public static ScottPlotPalette PolarNight => new(new PolarNight());
        public static ScottPlotPalette SnowStorm => new(new Snowstorm());

        private readonly IPalette cset;
        public readonly string Name;

        public ScottPlotPalette(IPalette colorset)
        {
            cset = colorset ?? new Category10();
            Name = cset.GetType().Name;
        }

        public ScottPlotPalette(string[] htmlColors, string name = "Custom")
        {
            cset = new Custom(htmlColors);
            Name = name;
        }

        public override string ToString() => Name;

        public int GetInt32(int index)
        {
            var (r, g, b) = cset.GetRGB(index);
            return 255 << 24 | r << 16 | g << 8 | b;
        }

        public Color GetColour(int index)
        {
            return Color.FromArgb(GetInt32(index));
        }

        public Color GetColor(int index, double alpha = 1)
        {
            return Color.FromArgb(alpha: (int)(alpha * 255), baseColor: GetColour(index));
        }

        public Color[] GetColors(int count, int offset = 0, double alpha = 1)
        {
            return Enumerable.Range(offset, count)
                .Select(x => GetColor(x, alpha))
                .ToArray();
        }

        // TODO: make this a property in ScottPlot 5
        public int Count()
        {
            return cset.Count();
        }
    }
}
#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class Colourset
    {
        // Matplotlib/D3/Vega/Tableau
        public static Colourset Category10 => new Colourset(new Category10());
        public static Colourset Category20 => new Colourset(new Category20());

        // Nord
        public static Colourset Aurora => new Colourset(new Aurora());
        public static Colourset Frost => new Colourset(new Frost());
        public static Colourset Nord => new Colourset(new Nord());
        public static Colourset PolarNight => new Colourset(new PolarNight());
        public static Colourset SnowStorm => new Colourset(new Snowstorm());

        // Misc
        public static Colourset OneHalfDark => new Colourset(new OneHalfDark());
        public static Colourset OneHalf => new Colourset(new OneHalf());

        private readonly IColourset cset;
        public readonly string Name;
        public Colourset(IColourset colourset)
        {
            cset = colourset ?? new Category10();
            Name = cset.GetType().Name;
        }

        public int GetInt32(int index)
        {
            var (r, g, b) = cset.GetRGB(index);
            return 255 << 24 | r << 16 | g << 8 | b;
        }

        public Color GetColour(int index)
        {
            return Color.FromArgb(GetInt32(index));
        }

        public int Count()
        {
            return cset.Count();
        }
    }
}
#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class AxisTicks : IRenderable
    {
        public Edge Edge { get; set; } = Edge.Bottom;

        public bool ShowLabels { get; set; } = true;
        public string FontName = Fonts.GetDefaultFontName();
        public float FontSize = 12;

        public readonly TickCollection Ticks = new TickCollection(false);

        public bool ShowMajorTicks = true;
        public Color MajorTickColour = Color.Black;
        public int MajorTickLength = 5;

        public bool ShowMinorTicks = true;
        public Color MinorTickColour = Color.Black;
        public int MinorTickLength = 2;

        public double FixedSpacing = 0;
        public DateTimeUnit? FixedDateTimeSpacingUnit = null;

        public bool RulerMode = false;
        public double Rotation = 0;

        public bool SnapToNearestPixel = true;

        // TODO: add support for multiplier and offset notation (removed in version 4.0.40)
        // TODO: add support for scientific notation (removed in version 4.0.40)
        /*
        public bool useMultiplierNotation = false;
        public bool useOffsetNotation = false;
        public bool useExponentialNotation = true;
        */

        public void Render(Settings settings)
        {
            using (var font = new Font(FontName, FontSize, GraphicsUnit.Pixel))
            {
                throw new NotImplementedException();
            }
        }
    }
}
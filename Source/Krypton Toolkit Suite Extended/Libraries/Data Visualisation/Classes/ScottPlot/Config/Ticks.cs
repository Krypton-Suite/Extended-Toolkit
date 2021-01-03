#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class Ticks
    {
        public string fontName = Fonts.GetDefaultFontName();
        public float fontSize = 12;
        public Font font { get { return new Font(fontName, fontSize, GraphicsUnit.Pixel); } }

        public bool displayYlabels = true;
        public bool displayXlabels = true;

        public readonly TickCollection x = new TickCollection(false);
        public readonly TickCollection y = new TickCollection(true);
        public int size = 5;
        public Color colour = Color.Black;

        public bool displayXmajor = true;
        public bool displayXminor = true;

        public double manualSpacingX = 0;
        public double manualSpacingY = 0;
        public DateTimeUnit? manualDateTimeSpacingUnitX = null;
        public DateTimeUnit? manualDateTimeSpacingUnitY = null;

        public bool rulerModeX = false;
        public bool rulerModeY = false;

        public double rotationX = 0;

        public bool displayYmajor = true;
        public bool displayYminor = true;

        public bool useMultiplierNotation = false;
        public bool useOffsetNotation = false;
        public bool useExponentialNotation = true;

        public bool snapToNearestPixel = true;
    }
}
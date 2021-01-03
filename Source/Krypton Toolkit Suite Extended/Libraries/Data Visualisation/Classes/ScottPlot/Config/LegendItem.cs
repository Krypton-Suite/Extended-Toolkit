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
    public class LegendItem
    {
        public string label;
        public Color colour;

        public LineStyle lineStyle;
        public double lineWidth;
        public MarkerShape markerShape;
        public double markerSize;

        public LegendItem(string label, Color colour, LineStyle lineStyle = LineStyle.Solid, double lineWidth = 1, MarkerShape markerShape = MarkerShape.filledCircle, double markerSize = 3)
        {
            this.label = label;
            this.colour = colour;

            this.lineStyle = lineStyle;
            this.lineWidth = lineWidth;
            this.markerShape = markerShape;
            this.markerSize = markerSize;
        }
    }
}
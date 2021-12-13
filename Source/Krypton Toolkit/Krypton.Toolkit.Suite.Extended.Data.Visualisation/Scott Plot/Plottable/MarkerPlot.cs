#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class MarkerPlot : IPlottable
    {
        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;

        /// <summary>
        /// Horizontal position in coordinate space
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Vertical position in coordinate space
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Marker to draw at this point
        /// </summary>
        public MarkerShape MarkerShape { get; set; } = MarkerShape.FILLEDCIRCLE;

        /// <summary>
        /// Size of the marker in pixel units
        /// </summary>
        public double MarkerSize { get; set; } = 10;

        /// <summary>
        /// Color of the marker to display at this point
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Text to appear in the legend (if populated)
        /// </summary>
        public string Label { get; set; }

        public AxisLimits GetAxisLimits() => new(X, X, Y, Y);

        public LegendItem[] GetLegendItems()
        {
            LegendItem item = new()
            {
                label = Label,
                markerShape = MarkerShape,
                color = Color
            };

            return new LegendItem[] { item };
        }

        public void ValidateData(bool deep = false)
        {
            Validate.AssertIsReal(nameof(X), X);
            Validate.AssertIsReal(nameof(Y), Y);
        }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (!IsVisible)
                return;

            PointF point = new(dims.GetPixelX(X), dims.GetPixelY(Y));

            using Graphics gfx = GDI.Graphics(bmp, lowQuality);
            MarkerTools.DrawMarker(gfx, point, MarkerShape, (float)MarkerSize, Color);
        }
    }
}

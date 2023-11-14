#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
        public MarkerShape MarkerShape { get; set; } = MarkerShape.FilledCircle;

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

            return new[] { item };
        }

        public void ValidateData(bool deep = false)
        {
            Validate.AssertIsReal(nameof(X), X);
            Validate.AssertIsReal(nameof(Y), Y);
        }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (!IsVisible)
            {
                return;
            }

            PointF point = new(dims.GetPixelX(X), dims.GetPixelY(Y));

            using Graphics gfx = GDI.Graphics(bmp, lowQuality);
            MarkerTools.DrawMarker(gfx, point, MarkerShape, (float)MarkerSize, Color);
        }
    }
}

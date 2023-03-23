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
    /// <summary>
    /// A tooltip displays a text bubble pointing to a specific location in X/Y space.
    /// The position of the bubble moves according to the axis limits to best display the text in the data area.
    /// </summary>
    public class Tooltip : IPlottable
    {
        public string Label { get; set; }
        public bool IsVisible { get; set; } = true;
        public Color BorderColor { get; set; } = Color.DarkGray;
        public float BorderWidth = 2;
        public Color FillColor { get; set; } = Color.White;
        public int XAxisIndex { get; set; }
        public int YAxisIndex { get; set; }

        public readonly Font Font = new Font();
        public int ArrowSize = 5;
        public int LabelPadding = 10;

        /// <summary>
        /// Tooltip position in coordinate space
        /// </summary>
        public double X;

        /// <summary>
        /// Tooltip position in coordinate space
        /// </summary>
        public double Y;

        public LegendItem[] GetLegendItems() => null;

        public AxisLimits GetAxisLimits() => new AxisLimits(double.NaN, double.NaN, double.NaN, double.NaN);

        public void ValidateData(bool deep = false)
        {
            if (string.IsNullOrEmpty(Label))
            {
                throw new InvalidOperationException("Label may not be empty");
            }

            if (double.IsNaN(X) || double.IsInfinity(X))
            {
                throw new InvalidOperationException("X must be a real number");
            }

            if (double.IsNaN(Y) || double.IsInfinity(Y))
            {
                throw new InvalidOperationException("Y must be a real number");
            }
        }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (!IsVisible)
            {
                return;
            }

            using (var gfx = GDI.Graphics(bmp, dims, lowQuality, clipToDataArea: true))
            using (var font = GDI.Font(Font))
            using (var fillBrush = GDI.Brush(FillColor))
            using (var fontBrush = GDI.Brush(Font.Color))
            using (var pen = GDI.Pen(BorderColor, BorderWidth))
            {
                SizeF labelSize = gfx.MeasureString(Label, font);

                bool labelIsOnRight = dims.DataWidth - dims.GetPixelX(X) - labelSize.Width > 0;
                int sign = labelIsOnRight ? 1 : -1;

                PointF arrowHeadLocation = new PointF(dims.GetPixelX(X), dims.GetPixelY(Y));

                float contentBoxInsideEdgeX = arrowHeadLocation.X + sign * ArrowSize;
                PointF upperArrowVertex = new PointF(contentBoxInsideEdgeX, arrowHeadLocation.Y - ArrowSize);
                PointF lowerArrowVertex = new PointF(contentBoxInsideEdgeX, arrowHeadLocation.Y + ArrowSize);

                float contentBoxTopEdge = upperArrowVertex.Y - LabelPadding;
                float contentBoxBottomEdge = Math.Max(contentBoxTopEdge + labelSize.Height, lowerArrowVertex.Y) + 2 * LabelPadding;

                PointF[] points =
                {
                    arrowHeadLocation,
                    upperArrowVertex,
                    new PointF(contentBoxInsideEdgeX, upperArrowVertex.Y - LabelPadding),
                    new PointF(contentBoxInsideEdgeX + sign * (labelSize.Width + LabelPadding), upperArrowVertex.Y - LabelPadding),
                    new PointF(contentBoxInsideEdgeX + sign * (labelSize.Width + LabelPadding), contentBoxBottomEdge),
                    new PointF(contentBoxInsideEdgeX, contentBoxBottomEdge),
                    lowerArrowVertex,
                    arrowHeadLocation,
                    // add one more point to prevent render artifacts where thick line ends meet
                    upperArrowVertex,
                };

                byte[] pathPointTypes = Enumerable.Range(0, points.Length).Select(_ => (byte)System.Drawing.Drawing2D.PathPointType.Line).ToArray();

                var path = new System.Drawing.Drawing2D.GraphicsPath(points, pathPointTypes);

                gfx.FillPath(fillBrush, path);
                gfx.DrawPath(pen, path);

                float labelOffsetX = labelIsOnRight ? 0 : -labelSize.Width;
                float labelX = contentBoxInsideEdgeX + labelOffsetX + sign * LabelPadding / 2;
                float labelY = upperArrowVertex.Y;
                gfx.DrawString(Label, font, fontBrush, labelX, labelY);
            }
        }
    }
}

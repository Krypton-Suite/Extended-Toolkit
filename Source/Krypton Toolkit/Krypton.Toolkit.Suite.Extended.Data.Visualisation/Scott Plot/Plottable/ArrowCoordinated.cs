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
    /// An arrow with X/Y coordinates for the base and the tip
    /// </summary>
    public class ArrowCoordinated : IPlottable
    {
        /// <summary>
        /// Location of the arrow base in coordinate space
        /// </summary>
        public readonly Coordinate Base = new(0, 0);

        /// <summary>
        /// Location of the arrow base in coordinate space
        /// </summary>
        public readonly Coordinate Tip = new(0, 0);

        /// <summary>
        /// Color of the arrow and arrowhead
        /// </summary>
        public Color Color = Color.Black;

        /// <summary>
        /// Thickness of the arrow line
        /// </summary>
        public double LineWidth = 2;

        /// <summary>
        /// Style of the arrow line
        /// </summary>
        public LineStyle LineStyle = LineStyle.Solid;

        /// <summary>
        /// Label to appear in the legend
        /// </summary>
        public string Label;

        /// <summary>
        /// Width of the arrowhead (pixels)
        /// </summary>
        public double ArrowheadWidth = 3;

        /// <summary>
        /// Height of the arrowhead (pixels)
        /// </summary>
        public double ArrowheadLength = 3;

        /// <summary>
        /// The arrow will be lengthened to ensure it is at least this size on the screen
        /// </summary>
        public float MinimumLengthPixels = 0;

        /// <summary>
        /// Marker to be drawn at the base (if MarkerSize > 0)
        /// </summary>
        public MarkerShape MarkerShape = MarkerShape.FilledCircle;

        /// <summary>
        /// Size of marker (in pixels) to draw at the base
        /// </summary>
        public float MarkerSize = 0;

        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;

        public ArrowCoordinated(Coordinate arrowBase, Coordinate arrowTip)
        {
            Base.X = arrowBase.X;
            Base.Y = arrowTip.Y;
            Tip.X = arrowTip.X;
            Tip.Y = arrowTip.Y;
        }

        public ArrowCoordinated(double xBase, double yBase, double xTip, double yTip)
        {
            Base.X = xBase;
            Base.Y = yBase;
            Tip.X = xTip;
            Tip.Y = yTip;
        }

        public AxisLimits GetAxisLimits()
        {
            double xMin = Math.Min(Base.X, Tip.X);
            double xMax = Math.Max(Base.X, Tip.X);
            double yMin = Math.Min(Base.Y, Tip.Y);
            double yMax = Math.Max(Base.Y, Tip.Y);
            return new AxisLimits(xMin, xMax, yMin, yMax);
        }

        public LegendItem[] GetLegendItems()
        {
            var item = new LegendItem()
            {
                label = Label
            };
            return new LegendItem[] { item };
        }

        public void ValidateData(bool deep = false)
        {
            if (!Base.IsFinite() || !Tip.IsFinite())
                throw new InvalidOperationException("Base and Tip coordinates must be finite");
        }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (IsVisible == false)
                return;

            using Graphics gfx = GDI.Graphics(bmp, dims, lowQuality);
            using Pen penLine = GDI.Pen(Color, LineWidth, LineStyle, true);

            Pixel basePixel = dims.GetPixel(Base);
            Pixel tipPixel = dims.GetPixel(Tip);

            float lengthPixels = basePixel.Distance(tipPixel);
            if (lengthPixels < MinimumLengthPixels)
            {
                float expandBy = MinimumLengthPixels / lengthPixels;
                float dX = tipPixel.X - basePixel.X;
                float dY = tipPixel.Y - basePixel.Y;
                basePixel.X = tipPixel.X - dX * expandBy;
                basePixel.Y = tipPixel.Y - dY * expandBy;
            }

            MarkerTools.DrawMarker(gfx, new(basePixel.X, basePixel.Y), MarkerShape, MarkerSize, Color);

            penLine.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap((float)ArrowheadWidth, (float)ArrowheadLength, true);
            penLine.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            gfx.DrawLine(penLine, basePixel.X, basePixel.Y, tipPixel.X, tipPixel.Y);
        }
    }
}

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
    /// A polygon is a collection of X/Y points that are all connected to form a closed shape.
    /// Polygons can be optionally filled with a color or a gradient.
    /// </summary>
    public class Polygon : IPlottable
    {
        // data
        public double[] Xs;
        public double[] Ys;

        // configuration
        public string Label;
        public double LineWidth = 1;
        public Color LineColor = Color.Black;
        public bool Fill = true;
        public Color FillColor = Color.Gray;
        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;
        public Color HatchColor = Color.Transparent;
        public HatchStyle HatchStyle = HatchStyle.None;

        public Polygon(double[] xs, double[] ys)
        {
            Xs = xs;
            Ys = ys;
        }

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(this.Label) ? "" : $" ({this.Label})";
            return $"PlottablePolygon{label} with {PointCount} points";
        }

        public int PointCount => Xs.Length;

        public AxisLimits GetAxisLimits()
        {
            double xMin = Xs[0];
            double xMax = Xs[0];
            double yMin = Ys[0];
            double yMax = Ys[0];

            for (int i = 1; i < Xs.Length; i++)
            {
                xMin = Math.Min(xMin, Xs[i]);
                xMax = Math.Max(xMax, Xs[i]);
                yMin = Math.Min(yMin, Ys[i]);
                yMax = Math.Max(yMax, Ys[i]);
            }

            return new AxisLimits(xMin, xMax, yMin, yMax);
        }

        public LegendItem[] GetLegendItems()
        {
            var singleLegendItem = new LegendItem()
            {
                label = Label,
                color = Fill ? FillColor : LineColor,
                lineWidth = Fill ? 10 : LineWidth,
                markerShape = MarkerShape.NONE,
                hatchColor = HatchColor,
                hatchStyle = HatchStyle
            };
            return new LegendItem[] { singleLegendItem };
        }

        public void ValidateData(bool deep = false)
        {
            Validate.AssertHasElements("xs", Xs);
            Validate.AssertHasElements("ys", Ys);
            Validate.AssertEqualLength("xs and ys", Xs, Ys);

            if (Xs.Length < 3)
                throw new InvalidOperationException("polygons must contain at least 3 points");

            if (deep)
            {
                Validate.AssertAllReal("xs", Xs);
                Validate.AssertAllReal("ys", Ys);
            }
        }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            PointF[] points = new PointF[Xs.Length];
            for (int i = 0; i < Xs.Length; i++)
                points[i] = new PointF(dims.GetPixelX(Xs[i]), dims.GetPixelY(Ys[i]));

            using (Graphics gfx = GDI.Graphics(bmp, dims, lowQuality))
            using (Brush fillBrush = GDI.Brush(FillColor, HatchColor, HatchStyle))
            using (Pen outlinePen = GDI.Pen(LineColor, (float)LineWidth))
            {
                if (Fill)
                    gfx.FillPolygon(fillBrush, points);

                if (LineWidth > 0)
                    gfx.DrawPolygon(outlinePen, points);
            }
        }
    }
}

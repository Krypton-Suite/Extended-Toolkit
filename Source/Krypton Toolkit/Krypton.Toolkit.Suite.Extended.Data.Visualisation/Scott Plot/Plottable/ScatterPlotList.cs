#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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
    /// A collection of X/Y coordinates that can be displayed as markers and/or connected lines.
    /// Unlike the regular ScatterPlot, this plot type has Add() methods to easily add data.
    /// </summary>
    public class ScatterPlotList : IPlottable
    {
        private readonly List<double> _xs = new();
        private readonly List<double> _ys = new();
        public int Count => _xs.Count;

        public string Label;
        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;
        public Color Color = Color.Black;
        public float LineWidth = 1;
        public LineStyle LineStyle = LineStyle.Solid;
        public float MarkerSize = 3;
        public MarkerShape MarkerShape = MarkerShape.FilledCircle;

        public void ValidateData(bool deep = false)
        {
            if (_xs.Count != _ys.Count)
            {
                throw new InvalidOperationException("Xs and Ys must be same length");
            }

            if (deep)
            {
                for (int i = 0; i < _xs.Count; i++)
                {
                    if (double.IsNaN(_xs[i]) || double.IsNaN(_ys[i]))
                    {
                        throw new InvalidOperationException("Xs and Ys cannot contain NaN");
                    }

                    if (double.IsInfinity(_xs[i]) || double.IsInfinity(_ys[i]))
                    {
                        throw new InvalidOperationException("Xs and Ys cannot contain Infinity");
                    }
                }
            }
        }

        /// <summary>
        /// Clear the list of points
        /// </summary>
        public void Clear()
        {
            _xs.Clear();
            _ys.Clear();
        }

        /// <summary>
        /// Add a single point to the list
        /// </summary>
        public void Add(double x, double y)
        {
            _xs.Add(x);
            _ys.Add(y);
        }

        /// <summary>
        /// Add multiple points to the list
        /// </summary>
        public void AddRange(double[] xs, double[] ys)
        {
            if (xs is null)
            {
                throw new ArgumentException("xs must not be null");
            }

            if (ys is null)
            {
                throw new ArgumentException("ys must not be null");
            }

            if (xs.Length != ys.Length)
            {
                throw new ArgumentException("xs and ys must have the same length");
            }

            _xs.AddRange(xs);
            _ys.AddRange(ys);
        }

        public AxisLimits GetAxisLimits()
        {
            if (Count == 0)
            {
                return new AxisLimits(double.NaN, double.NaN, double.NaN, double.NaN);
            }

            double xMin = _xs[0];
            double xMax = _xs[0];
            double yMin = _ys[0];
            double yMax = _ys[0];

            for (int i = 1; i < Count; i++)
            {
                xMin = Math.Min(xMin, _xs[i]);
                xMax = Math.Max(xMax, _xs[i]);
                yMin = Math.Min(yMin, _ys[i]);
                yMax = Math.Max(yMax, _ys[i]);
            }

            return new AxisLimits(xMin, xMax, yMin, yMax);
        }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            PointF[] points = new PointF[Count];
            for (int i = 0; i < Count; i++)
            {
                points[i] = new PointF(dims.GetPixelX(_xs[i]), dims.GetPixelY(_ys[i]));
            }

            using (var gfx = GDI.Graphics(bmp, dims, lowQuality))
            {
                using (var linePen = GDI.Pen(Color, LineWidth, LineStyle, true))
                {
                    if (LineStyle != LineStyle.None && LineWidth > 0 && Count > 1)
                    {
                        gfx.DrawLines(linePen, points);
                    }

                    if (MarkerShape != MarkerShape.None && MarkerSize > 0 && Count > 0)
                    {
                        foreach (PointF point in points)
                        {
                            MarkerTools.DrawMarker(gfx, point, MarkerShape, MarkerSize, Color);
                        }
                    }
                }
            }
        }

        public LegendItem[] GetLegendItems()
        {
            var singleLegendItem = new LegendItem()
            {
                label = Label,
                color = Color,
                lineStyle = LineStyle,
                lineWidth = LineWidth,
                markerShape = MarkerShape,
                markerSize = MarkerSize
            };
            return new[] { singleLegendItem };
        }
    }
}

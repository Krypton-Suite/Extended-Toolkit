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

using System.Data;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// A function plot displays a curve using a function (Y as a function of X)
    /// </summary>
    public class FunctionPlot : IPlottable
    {
        /// <summary>
        /// The function to translate an X to a Y (or null if undefined)
        /// </summary>
        public Func<double, double?> Function;

        // customizations
        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;
        public double LineWidth = 1;
        public LineStyle LineStyle = LineStyle.Solid;
        public string Label;
        public Color Color = Color.Black;

        public FunctionPlot(Func<double, double?> function)
        {
            Function = function;
        }

        public AxisLimits GetAxisLimits()
        {
            double max = double.NegativeInfinity;
            double min = double.PositiveInfinity;

            foreach (double x in DataGen.Range(-10, 10, .1))
            {
                double? y = Function(x);
                if (y != null)
                {
                    max = Math.Max(max, y.Value);
                    min = Math.Min(min, y.Value);
                }
            }

            // TODO: should X limits be null or NaN?
            return new AxisLimits(-10, 10, min, max);
        }

        public int PointCount { get; private set; }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            List<double> xList = new List<double>();
            List<double> yList = new List<double>();

            PointCount = (int)dims.DataWidth;
            for (int columnIndex = 0; columnIndex < dims.DataWidth; columnIndex++)
            {
                double x = columnIndex * dims.UnitsPerPxX + dims.XMin;
                try
                {
                    double? y = Function(x);

                    if (y is null)
                    {
                        throw new NoNullAllowedException();
                    }

                    if (double.IsNaN(y.Value) || double.IsInfinity(y.Value))
                    {
                        throw new ArithmeticException("not a real number");
                    }

                    xList.Add(x);
                    yList.Add(y.Value);
                }
                catch (Exception e) //Domain error, such log(-1) or 1/0
                {
                    System.Diagnostics.Debug.WriteLine($"Y({x}) failed because {e}");
                }
            }

            // create a temporary scatter plot and use it for rendering
            double[] xs = xList.ToArray();
            double[] ys = yList.ToArray();
            var scatter = new ScatterPlot(xs, ys)
            {
                Color = Color,
                LineWidth = LineWidth,
                MarkerSize = 0,
                Label = Label,
                MarkerShape = MarkerShape.None,
                LineStyle = LineStyle
            };
            scatter.Render(dims, bmp, lowQuality);
        }

        public void ValidateData(bool deepValidation = false)
        {
            if (Function is null)
            {
                throw new InvalidOperationException("function cannot be null");
            }
        }

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(Label) ? "" : $" ({Label})";
            return $"PlottableFunction{label} displaying {PointCount} points";
        }

        public LegendItem[] GetLegendItems()
        {
            var singleLegendItem = new LegendItem()
            {
                label = Label,
                color = Color,
                lineStyle = LineStyle,
                lineWidth = LineWidth,
                markerShape = MarkerShape.None
            };
            return new[] { singleLegendItem };
        }
    }
}

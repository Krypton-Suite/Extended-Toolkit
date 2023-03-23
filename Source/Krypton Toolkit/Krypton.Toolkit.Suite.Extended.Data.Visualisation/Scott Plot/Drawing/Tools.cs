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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.Drawing
{
    public static class Tools
    {
        /// <summary>
        /// Return Xs and Ys for 2 polygons representing the input data above and below the given baseline
        /// </summary>
        public static (double[] xs, double[] ysAbove, double[] ysBelow) PolyAboveAndBelow(double[] xs, double[] ys, double baseline)
        {
            if (xs.Length != ys.Length)
            {
                throw new ArgumentException("xs and ys must have same length");
            }

            double[] intersectionsX = new double[ys.Length - 1];
            double[] intersectionsY = new double[ys.Length - 1];
            for (int i = 0; i < intersectionsX.Length; i++)
            {
                intersectionsX[i] = double.NaN;
                intersectionsY[i] = double.NaN;

                double x1 = xs[i];
                double y1 = ys[i];
                double x2 = xs[i + 1];
                double y2 = ys[i + 1];

                if ((y1 <= baseline && y2 <= baseline) || (y1 >= baseline && y2 >= baseline))
                {
                    continue;
                }

                double deltaX = x2 - x1;
                double deltaY = y2 - y1;

                double y1diff = baseline - y1;
                double y2diff = y2 - baseline;
                double totalDiff = y1diff + y2diff;
                double frac = y1diff / totalDiff;
                intersectionsX[i] = x1 + deltaX * frac;
                intersectionsY[i] = y1 + deltaY * frac;
            }

            List<double> polyXs = new List<double>();
            List<double> polyYs = new List<double>();

            polyXs.Add(xs.First());
            polyYs.Add(baseline);

            for (int i = 0; i < xs.Length; i++)
            {
                polyXs.Add(xs[i]);
                polyYs.Add(ys[i]);

                if (i < intersectionsX.Length && !double.IsNaN(intersectionsX[i]))
                {
                    polyXs.Add(intersectionsX[i]);
                    polyYs.Add(intersectionsY[i]);
                }
            }

            polyXs.Add(xs.Last());
            polyYs.Add(baseline);

            double[] xs2 = polyXs.ToArray();
            double[] ysAbove = polyYs.Select(x => Math.Max(x, baseline)).ToArray();
            double[] ysBelow = polyYs.Select(x => Math.Min(x, baseline)).ToArray();

            return (xs2, ysAbove, ysBelow);
        }
    }
}
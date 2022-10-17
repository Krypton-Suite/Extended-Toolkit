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
    /// The Periodic Spline is a Natural Spline whose first and last point slopes are equal
    /// </summary>
    public class PeriodicSpline : SplineInterpolator
    {
        public PeriodicSpline(double[] xs, double[] ys, int resolution = 10) : base(xs, ys, resolution)
        {
            m = new Matrix(n - 1);
            gauss = new MatrixSolver(n - 1, m);

            a = new double[n + 1];
            b = new double[n + 1];
            c = new double[n + 1];
            d = new double[n + 1];
            h = new double[n];

            CalcParameters();
            Integrate();
            Interpolate();
        }

        public void CalcParameters()
        {
            for (int i = 0; i < n; i++)
                a[i] = givenYs[i];

            for (int i = 0; i < n - 1; i++)
                h[i] = givenXs[i + 1] - givenXs[i];

            a[n] = givenYs[1];
            h[n - 1] = h[0];

            for (int i = 0; i < n - 1; i++)
                for (int k = 0; k < n - 1; k++)
                {
                    m.a[i, k] = 0.0;
                    m.y[i] = 0.0;
                    m.x[i] = 0.0;
                }

            for (int i = 0; i < n - 1; i++)
            {
                if (i == 0)
                {
                    m.a[i, 0] = 2.0 * (h[0] + h[1]);
                    m.a[i, 1] = h[1];
                }
                else
                {
                    m.a[i, i - 1] = h[i];
                    m.a[i, i] = 2.0 * (h[i] + h[i + 1]);
                    if (i < n - 2)
                        m.a[i, i + 1] = h[i + 1];
                }
                if ((h[i] != 0.0) && (h[i + 1] != 0.0))
                    m.y[i] = ((a[i + 2] - a[i + 1]) / h[i + 1] - (a[i + 1] - a[i]) / h[i]) * 3.0;
                else
                    m.y[i] = 0.0;
            }

            m.a[0, n - 2] = h[0];
            m.a[n - 2, 0] = h[0];

            if (gauss.Eliminate() == false)
                throw new InvalidOperationException();

            gauss.Solve();

            for (int i = 1; i < n; i++)
                c[i] = m.x[i - 1];
            c[0] = c[n - 1];

            for (int i = 0; i < n; i++)
            {
                if (h[i] != 0.0)
                {
                    d[i] = 1.0 / 3.0 / h[i] * (c[i + 1] - c[i]);
                    b[i] = 1.0 / h[i] * (a[i + 1] - a[i]) - h[i] / 3.0 * (c[i + 1] + 2 * c[i]);
                }
            }
        }
    }
}
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
    public abstract class SplineInterpolator
    {
        public double[] givenYs, givenXs;
        public double[] interpolatedXs, interpolatedYs;

        protected Matrix m;
        protected MatrixSolver gauss;

        protected readonly int n;
        protected double[] a, b, c, d, h;

        protected SplineInterpolator(double[] xs, double[] ys, int resolution = 10)
        {
            if (xs is null || ys is null)
            {
                throw new ArgumentException("xs and ys cannot be null");
            }

            if (xs.Length != ys.Length)
            {
                throw new ArgumentException("xs and ys must have the same length");
            }

            if (xs.Length < 4)
            {
                throw new ArgumentException("xs and ys must have a length of 4 or greater");
            }

            if (resolution < 1)
            {
                throw new ArgumentException("resolution must be 1 or greater");
            }

            givenXs = xs;
            givenYs = ys;
            n = xs.Length;

            interpolatedXs = new double[n * resolution];
            interpolatedYs = new double[n * resolution];
        }

        public void Interpolate()
        {
            int resolution = interpolatedXs.Length / n;
            for (int i = 0; i < h.Length; i++)
            {
                for (int k = 0; k < resolution; k++)
                {
                    double deltaX = (double)k / resolution * h[i];
                    double termA = a[i];
                    double termB = b[i] * deltaX;
                    double termC = c[i] * deltaX * deltaX;
                    double termD = d[i] * deltaX * deltaX * deltaX;
                    int interpolatedIndex = i * resolution + k;
                    interpolatedXs[interpolatedIndex] = deltaX + givenXs[i];
                    interpolatedYs[interpolatedIndex] = termA + termB + termC + termD;
                }
            }

            // After interpolation the last several values of the interpolated arrays
            // contain uninitialized data. This section identifies the values which are
            // populated with values and copies just the useful data into new arrays.
            int pointsToKeep = resolution * (n - 1) + 1;
            double[] interpolatedXsCopy = new double[pointsToKeep];
            double[] interpolatedYsCopy = new double[pointsToKeep];
            Array.Copy(interpolatedXs, 0, interpolatedXsCopy, 0, pointsToKeep - 1);
            Array.Copy(interpolatedYs, 0, interpolatedYsCopy, 0, pointsToKeep - 1);
            interpolatedXs = interpolatedXsCopy;
            interpolatedYs = interpolatedYsCopy;
            interpolatedXs[pointsToKeep - 1] = givenXs[n - 1];
            interpolatedYs[pointsToKeep - 1] = givenYs[n - 1];
        }

        public double Integrate()
        {
            double integral = 0;
            for (int i = 0; i < h.Length; i++)
            {
                double termA = a[i] * h[i];
                double termB = b[i] * Math.Pow(h[i], 2) / 2.0;
                double termC = c[i] * Math.Pow(h[i], 3) / 3.0;
                double termD = d[i] * Math.Pow(h[i], 4) / 4.0;
                integral += termA + termB + termC + termD;
            }
            return integral;
        }
    }
}
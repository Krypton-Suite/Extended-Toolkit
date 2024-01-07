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
    // Matrix equation solver using the Gaussian elimination algorithm
    public class MatrixSolver
    {
        public readonly Matrix m;
        public readonly int maxOrder;
        public bool calcError;

        public MatrixSolver(int size, Matrix mi)
        {
            maxOrder = size;
            m = mi;
        }

        void SwitchRows(int n)
        {
            double tempD;
            int i, j;
            for (i = n; i <= maxOrder - 2; i++)
            {
                for (j = 0; j <= maxOrder - 1; j++)
                {
                    tempD = m.a[i, j];
                    m.a[i, j] = m.a[i + 1, j];
                    m.a[i + 1, j] = tempD;
                }
                tempD = m.y[i];
                m.y[i] = m.y[i + 1];
                m.y[i + 1] = tempD;
            }
        }

        public bool Eliminate()
        {
            int i, k, l;
            calcError = false;
            for (k = 0; k <= maxOrder - 2; k++)
            {
                for (i = k; i <= maxOrder - 2; i++)
                {
                    if (Math.Abs(m.a[i + 1, i]) < 1e-8)
                    {
                        SwitchRows(i + 1);
                    }
                    if (m.a[i + 1, k] != 0.0)
                    {
                        for (l = k + 1; l <= maxOrder - 1; l++)
                        {
                            if (!calcError)
                            {
                                m.a[i + 1, l] = m.a[i + 1, l] * m.a[k, k] - m.a[k, l] * m.a[i + 1, k];
                                if (m.a[i + 1, l] > 10E260)
                                {
                                    m.a[i + 1, k] = 0;
                                    calcError = true;
                                }
                            }
                        }
                        m.y[i + 1] = m.y[i + 1] * m.a[k, k] - m.y[k] * m.a[i + 1, k];
                        m.a[i + 1, k] = 0;
                    }
                }
            }
            return !calcError;
        }

        public void Solve()
        {
            int k, l;
            for (k = maxOrder - 1; k >= 0; k--)
            {
                for (l = maxOrder - 1; l >= k; l--)
                {
                    m.y[k] = m.y[k] - m.x[l] * m.a[k, l];
                }
                if (m.a[k, k] != 0)
                {
                    m.x[k] = m.y[k] / m.a[k, k];
                }
                else
                {
                    m.x[k] = 0;
                }
            }
        }
    }
}

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
    public class LinearFastDoubleMinMaxSearchStrategy<T> : LinearMinMaxSearchStrategy<T> where T : struct, IComparable
    {
        private double[] sourceArrayDouble;

        public override T[] SourceArray
        {
            get => base.SourceArray;
            set
            {
                sourceArrayDouble = value as double[];
                base.SourceArray = value;
            }
        }

        public override void MinMaxRangeQuery(int l, int r, out double lowestValue, out double highestValue)
        {
            if (sourceArrayDouble != null)
            {
                lowestValue = sourceArrayDouble[l];
                highestValue = sourceArrayDouble[l];
                for (int i = l; i <= r; i++)
                {
                    if (sourceArrayDouble[i] < lowestValue)
                    {
                        lowestValue = sourceArrayDouble[i];
                    }

                    if (sourceArrayDouble[i] > highestValue)
                    {
                        highestValue = sourceArrayDouble[i];
                    }
                }
                return;
            }
            else
            {
                base.MinMaxRangeQuery(l, r, out lowestValue, out highestValue);
            }
        }

        public override double SourceElement(int index)
        {
            if (sourceArrayDouble != null)
            {
                return sourceArrayDouble[index];
            }

            return Convert.ToDouble(SourceArray[index]);
        }
    }
}

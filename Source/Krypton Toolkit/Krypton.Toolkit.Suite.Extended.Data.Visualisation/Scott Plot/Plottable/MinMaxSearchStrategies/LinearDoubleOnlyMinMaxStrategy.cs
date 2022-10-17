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
    public class LinearDoubleOnlyMinMaxStrategy : IMinMaxSearchStrategy<double>
    {
        double[] sourceArray;
        public double[] SourceArray
        {
            get => sourceArray;
            set => sourceArray = value;
        }

        public void MinMaxRangeQuery(int l, int r, out double lowestValue, out double highestValue)
        {
            lowestValue = sourceArray[l];
            highestValue = sourceArray[l];
            for (int i = l; i <= r; i++)
            {
                if (sourceArray[i] < lowestValue)
                    lowestValue = sourceArray[i];
                if (sourceArray[i] > highestValue)
                    highestValue = sourceArray[i];
            }
        }

        public double SourceElement(int index)
        {
            return sourceArray[index];
        }

        public void updateElement(int index, double newValue)
        {
            sourceArray[index] = newValue;
        }

        public void updateRange(int from, int to, double[] newData, int fromData = 0)
        {
            for (int i = from; i < to; i++)
            {
                sourceArray[i] = newData[i - from + fromData];
            }
        }
    }
}

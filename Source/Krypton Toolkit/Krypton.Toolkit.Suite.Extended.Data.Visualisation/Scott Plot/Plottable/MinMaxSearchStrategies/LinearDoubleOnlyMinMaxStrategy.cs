#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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

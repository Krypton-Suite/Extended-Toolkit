﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
                        lowestValue = sourceArrayDouble[i];
                    if (sourceArrayDouble[i] > highestValue)
                        highestValue = sourceArrayDouble[i];
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
                return sourceArrayDouble[index];
            return Convert.ToDouble(SourceArray[index]);
        }
    }
}

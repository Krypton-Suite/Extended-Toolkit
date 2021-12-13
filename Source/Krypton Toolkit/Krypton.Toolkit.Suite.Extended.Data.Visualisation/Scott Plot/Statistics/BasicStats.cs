#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class BasicStats
    {
        public readonly int Count;
        public readonly double Min;
        public readonly double Max;
        public readonly double Sum;
        public readonly double Mean;
        public readonly double StDev;
        public readonly double StdErr;

        public BasicStats(double[] values)
        {
            if (values is null)
                throw new ArgumentNullException();

            if (values.Length == 0)
                throw new ArgumentException("input cannot be empty");

            Count = values.Length;
            (Min, Max, Sum) = Common.MinMaxSum(values);
            Mean = Sum / Count;
            StDev = Common.StDev(values, Mean);
            StdErr = StDev / Math.Sqrt(Count);
        }
    }
}
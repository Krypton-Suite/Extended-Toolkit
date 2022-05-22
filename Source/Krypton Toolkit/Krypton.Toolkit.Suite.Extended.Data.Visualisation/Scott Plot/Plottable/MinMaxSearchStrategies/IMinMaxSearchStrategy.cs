#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IMinMaxSearchStrategy<T>
    {
        T[] SourceArray { get; set; }
        void MinMaxRangeQuery(int l, int r, out double lowestValue, out double highestValue);
        void updateElement(int index, T newValue);
        void updateRange(int from, int to, T[] newData, int fromData = 0);
        double SourceElement(int index);
    }
}

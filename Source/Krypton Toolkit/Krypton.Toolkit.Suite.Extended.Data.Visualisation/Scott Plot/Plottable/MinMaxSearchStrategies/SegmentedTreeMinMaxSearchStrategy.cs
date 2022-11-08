#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class SegmentedTreeMinMaxSearchStrategy<T> : IMinMaxSearchStrategy<T> where T : struct, IComparable
    {
        private SegmentedTree<T> segmentedTree;

        public bool TreesReady => segmentedTree.TreesReady;
        public SegmentedTreeMinMaxSearchStrategy()
        {
            segmentedTree = new SegmentedTree<T>();
        }

        public SegmentedTreeMinMaxSearchStrategy(T[] data) : this()
        {
            SourceArray = data;
        }

        public T[] SourceArray
        {
            get => segmentedTree.SourceArray;
            set => segmentedTree.SourceArray = value;
        }

        public void MinMaxRangeQuery(int l, int r, out double lowestValue, out double highestValue)
        {
            segmentedTree.MinMaxRangeQuery(l, r, out lowestValue, out highestValue);
        }

        public double SourceElement(int index)
        {
            return Convert.ToDouble(SourceArray[index]);
        }

        public void updateElement(int index, T newValue)
        {
            segmentedTree.updateElement(index, newValue);
        }

        public void updateRange(int from, int to, T[] newData, int fromData = 0)
        {
            segmentedTree.updateRange(from, to, newData, fromData);
        }
    }
}

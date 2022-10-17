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

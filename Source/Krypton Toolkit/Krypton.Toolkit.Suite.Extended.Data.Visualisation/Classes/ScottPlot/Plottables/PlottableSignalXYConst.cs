#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class PlottableSignalXYConst<TX, TY> : PlottableSignalXYGeneric<TX, TY> where TX : struct, IComparable where TY : struct, IComparable
    {
        public PlottableSignalXYConst(TX[] xs, TY[] ys, Color color, double lineWidth, double markerSize, string label, int minRenderIndex, int maxRenderIndex, LineStyle lineStyle, bool useParallel, IMinMaxSearchStrategy<TY> minMaxSearchStrategy = null)
            : base(xs, ys, color, lineWidth, markerSize, label, minRenderIndex, maxRenderIndex, lineStyle, useParallel, new SegmentedTreeMinMaxSearchStrategy<TY>())
        {

        }

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(this.label) ? "" : $" ({this.label})";
            return $"PlottableSignalXYConst{label} with {GetPointCount()} points ({typeof(TX).Name}, {typeof(TY).Name})";
        }
    }
}

#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class PlottableSignalXY : PlottableSignalXYGeneric<double, double>
    {
        public PlottableSignalXY(double[] xs, double[] ys, Color color, double lineWidth, double markerSize, string label, int minRenderIndex, int maxRenderIndex, LineStyle lineStyle, bool useParallel)
            : base(xs, ys, color, lineWidth, markerSize, label, minRenderIndex, maxRenderIndex, lineStyle, useParallel, new LinearDoubleOnlyMinMaxStrategy())
        {
        }

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(this.label) ? "" : $" ({this.label})";
            return $"PlottableSignalXY{label} with {GetPointCount()} points";
        }
    }
}

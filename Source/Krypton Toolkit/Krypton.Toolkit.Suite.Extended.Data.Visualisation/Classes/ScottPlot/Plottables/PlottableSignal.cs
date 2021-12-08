#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class PlottableSignal : PlottableSignalBase<double>
    {
        public PlottableSignal(double[] ys, double sampleRate, double xOffset, double yOffset, Color color,
            double lineWidth, double markerSize, string label, Color[] colorByDensity,
            int minRenderIndex, int maxRenderIndex, LineStyle lineStyle, bool useParallel)
            : base(ys, sampleRate, xOffset, yOffset, color, lineWidth, markerSize, label, colorByDensity,
                 minRenderIndex, maxRenderIndex, lineStyle, useParallel, new LinearDoubleOnlyMinMaxStrategy())
        {
        }

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(this.label) ? "" : $" ({this.label})";
            return $"PlottableSignal{label} with {GetPointCount()} points";
        }
    }
}

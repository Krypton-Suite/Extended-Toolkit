#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// A variation of the SignalPlot optimized for unevenly-spaced ascending X values.
    /// </summary>
    public class SignalPlotXY : SignalPlotXYGeneric<double, double>
    {

        public SignalPlotXY() : base()
        {
            Strategy = new LinearDoubleOnlyMinMaxStrategy();
        }

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(this.Label) ? "" : $" ({this.Label})";
            return $"PlottableSignalXY{label} with {PointCount} points";
        }
    }
}

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
    /// A signal plot displays evenly-spaced data.
    /// Instead of X/Y pairs, signal plots take Y values and a sample rate.
    /// Optional X and Y offsets can further customize the data.
    /// </summary>
    public class SignalPlot : SignalPlotBase<double>
    {
        public SignalPlot() : base()
        {
            Strategy = new LinearDoubleOnlyMinMaxStrategy();
        }

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(this.Label) ? "" : $" ({this.Label})";
            return $"PlottableSignal{label} with {PointCount} points";
        }
    }
}

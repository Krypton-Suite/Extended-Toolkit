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
    /// A population series is a collection of similar PopulationStats objects.
    /// </summary>
    public class PopulationSeries
    {
        public Population[] populations;
        public string seriesLabel;
        public Color color;

        public PopulationSeries(Population[] populations, string? seriesLabel = null, Color? color = null)
        {
            this.populations = populations;
            this.seriesLabel = seriesLabel ?? string.Empty;
            this.color = (color is null) ? Color.LightGray : color.Value;
        }
    }
}
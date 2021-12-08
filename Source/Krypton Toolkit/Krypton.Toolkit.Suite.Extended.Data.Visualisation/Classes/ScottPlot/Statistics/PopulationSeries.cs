#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// A population series is a collection of similar PopulationStats objects.
    /// </summary>
    public class PopulationSeries
    {
        public Population[] populations;
        public string seriesLabel;
        public System.Drawing.Color color;

        public PopulationSeries(Population[] populations, string seriesLabel = null, System.Drawing.Color? color = null)
        {
            this.populations = populations;
            this.seriesLabel = seriesLabel;
            this.color = (color is null) ? System.Drawing.Color.LightGray : color.Value;
        }
    }
}

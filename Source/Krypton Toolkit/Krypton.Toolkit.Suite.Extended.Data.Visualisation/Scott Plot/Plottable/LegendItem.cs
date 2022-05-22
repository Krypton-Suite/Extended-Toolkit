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
    /// This class describes a single item that appears in the figure legend.
    /// </summary>
    public class LegendItem
    {
        public string label;
        public System.Drawing.Color color;
        public System.Drawing.Color hatchColor;
        public System.Drawing.Color borderColor;
        public float borderWith;

        public LineStyle lineStyle;
        public double lineWidth;
        public MarkerShape markerShape;
        public double markerSize;
        public HatchStyle hatchStyle;
        public bool IsRectangle
        {
            get { return lineWidth >= 10; }
            set { lineWidth = 10; }
        }
    }
}

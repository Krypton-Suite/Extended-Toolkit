#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IPlottable
    {
        bool IsVisible { get; set; }
        void Render(PlotDimensions dims, System.Drawing.Bitmap bmp, bool lowQuality = false);

        int XAxisIndex { get; set; }
        int YAxisIndex { get; set; }

        /// <summary>
        /// Returns items to show in the legend. Most plottables return a single item. in this array will appear in the legend.
        /// Plottables which never appear in the legend can return null.
        /// </summary>
        LegendItem[] GetLegendItems();

        /// <summary>
        /// Return min and max of the horizontal and vertical data contained in this plottable.
        /// Double.NaN is used for axes not containing data.
        /// </summary>
        /// <returns></returns>
        AxisLimits GetAxisLimits();

        /// <summary>
        /// Throw InvalidOperationException if ciritical variables are null or have incorrect sizes. 
        /// Deep validation is slower but also checks every value for NaN and Infinity.
        /// </summary>
        void ValidateData(bool deep = false);
    }
}

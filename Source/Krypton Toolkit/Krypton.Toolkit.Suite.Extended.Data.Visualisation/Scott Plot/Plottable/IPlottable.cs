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
    public interface IPlottable
    {
        bool IsVisible { get; set; }
        void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false);

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

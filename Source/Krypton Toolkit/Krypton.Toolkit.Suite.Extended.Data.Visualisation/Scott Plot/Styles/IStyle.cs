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
    /// A theme describes a collection of colors and fonts that can be used to style a plot
    /// </summary>
    public interface IStyle
    {
        Color FigureBackgroundColor { get; }
        Color DataBackgroundColor { get; }
        Color FrameColor { get; }
        Color GridLineColor { get; }
        Color AxisLabelColor { get; }
        Color TitleFontColor { get; }
        Color TickLabelColor { get; }
        Color TickMajorColor { get; }
        Color TickMinorColor { get; }

        string AxisLabelFontName { get; }
        string TitleFontName { get; }
        string TickLabelFontName { get; }
    }
}

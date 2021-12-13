#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Default : IStyle
    {
        public virtual Color FigureBackgroundColor => Color.White;
        public virtual Color DataBackgroundColor => Color.White;
        public virtual Color GridLineColor => ColorTranslator.FromHtml("#efefef");
        public virtual Color FrameColor => Color.Black;
        public virtual Color TitleFontColor => Color.Black;
        public virtual Color AxisLabelColor => Color.Black;
        public virtual Color TickLabelColor => Color.Black;
        public virtual Color TickMajorColor => Color.Black;
        public virtual Color TickMinorColor => Color.Black;

        public virtual string TitleFontName => InstalledFont.Default();
        public virtual string AxisLabelFontName => InstalledFont.Default();
        public virtual string TickLabelFontName => InstalledFont.Default();
    }
}

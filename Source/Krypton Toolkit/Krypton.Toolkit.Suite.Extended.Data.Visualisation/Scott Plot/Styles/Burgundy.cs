#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Burgundy : Default
    {
        public override Color FigureBackgroundColor => ColorTranslator.FromHtml("#ffffff");
        public override Color DataBackgroundColor => ColorTranslator.FromHtml("#fffdfd");
        public override Color FrameColor => ColorTranslator.FromHtml("#560013");
        public override Color GridLineColor => ColorTranslator.FromHtml("#ffdae3");
        public override Color AxisLabelColor => ColorTranslator.FromHtml("#5e0015");
        public override Color TitleFontColor => ColorTranslator.FromHtml("#560013");
        public override Color TickLabelColor => ColorTranslator.FromHtml("#5e0015");
        public override Color TickMajorColor => ColorTranslator.FromHtml("#560013");
        public override Color TickMinorColor => ColorTranslator.FromHtml("#560013");
    }
}

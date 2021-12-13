#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    internal class Blue3 : Default
    {
        public override Color FigureBackgroundColor => ColorTranslator.FromHtml("#001021");
        public override Color DataBackgroundColor => ColorTranslator.FromHtml("#021d38");
        public override Color FrameColor => ColorTranslator.FromHtml("#d3d3d3");
        public override Color GridLineColor => ColorTranslator.FromHtml("#273c51");
        public override Color AxisLabelColor => ColorTranslator.FromHtml("#d3d3d3");
        public override Color TitleFontColor => ColorTranslator.FromHtml("#FFFFFF");
        public override Color TickLabelColor => ColorTranslator.FromHtml("#d3d3d3");
        public override Color TickMajorColor => ColorTranslator.FromHtml("#d3d3d3");
        public override Color TickMinorColor => ColorTranslator.FromHtml("#d3d3d3");
    }
}

#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Gray1 : Default
    {
        public override Color FigureBackgroundColor => ColorTranslator.FromHtml("#31363a");
        public override Color DataBackgroundColor => ColorTranslator.FromHtml("#3a4149");
        public override Color FrameColor => ColorTranslator.FromHtml("#757a80");
        public override Color GridLineColor => ColorTranslator.FromHtml("#444b52");
        public override Color AxisLabelColor => ColorTranslator.FromHtml("#d6d7d8");
        public override Color TitleFontColor => ColorTranslator.FromHtml("#FFFFFF");
        public override Color TickLabelColor => ColorTranslator.FromHtml("#757a80");
        public override Color TickMajorColor => ColorTranslator.FromHtml("#757a80");
        public override Color TickMinorColor => ColorTranslator.FromHtml("#757a80");
    }
}

#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    internal class Gray2 : Default
    {
        public override Color FigureBackgroundColor => ColorTranslator.FromHtml("#131519");
        public override Color DataBackgroundColor => ColorTranslator.FromHtml("#262626");
        public override Color FrameColor => ColorTranslator.FromHtml("#757575");
        public override Color GridLineColor => ColorTranslator.FromHtml("#2d2d2d");
        public override Color AxisLabelColor => ColorTranslator.FromHtml("#b9b9ba");
        public override Color TitleFontColor => ColorTranslator.FromHtml("#FFFFFF");
        public override Color TickLabelColor => ColorTranslator.FromHtml("#757575");
        public override Color TickMajorColor => ColorTranslator.FromHtml("#757575");
        public override Color TickMinorColor => ColorTranslator.FromHtml("#757575");
    }
}

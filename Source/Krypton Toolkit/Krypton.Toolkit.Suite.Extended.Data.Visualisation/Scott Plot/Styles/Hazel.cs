#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Hazel : Default
    {
        public override Color FigureBackgroundColor => ColorTranslator.FromHtml("#221a0f");
        public override Color DataBackgroundColor => ColorTranslator.FromHtml("#362712");
        public override Color FrameColor => Color.White;
        public override Color GridLineColor => ColorTranslator.FromHtml("#221a0f");
        public override Color AxisLabelColor => Color.White;
        public override Color TitleFontColor => Color.White;
        public override Color TickLabelColor => Color.Gray;
        public override Color TickMajorColor => ColorTranslator.FromHtml("#757575");
        public override Color TickMinorColor => ColorTranslator.FromHtml("#757575");
    }
}

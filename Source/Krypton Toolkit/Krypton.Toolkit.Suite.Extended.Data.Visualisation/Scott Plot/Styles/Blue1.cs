#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Blue1 : Default
    {
        public override Color FigureBackgroundColor => ColorTranslator.FromHtml("#07263b");
        public override Color DataBackgroundColor => ColorTranslator.FromHtml("#0b3049");
        public override Color FrameColor => ColorTranslator.FromHtml("#145665");
        public override Color GridLineColor => ColorTranslator.FromHtml("#0e3d54");
        public override Color AxisLabelColor => ColorTranslator.FromHtml("#b5bec5");
        public override Color TitleFontColor => ColorTranslator.FromHtml("#d0dae2");
        public override Color TickLabelColor => ColorTranslator.FromHtml("#b5bec5");
        public override Color TickMajorColor => ColorTranslator.FromHtml("#145665");
        public override Color TickMinorColor => ColorTranslator.FromHtml("#145665");
    }
}

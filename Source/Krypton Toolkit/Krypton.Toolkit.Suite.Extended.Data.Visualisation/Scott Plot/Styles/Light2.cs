#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    internal class Light2 : Default
    {
        public override Color FigureBackgroundColor => ColorTranslator.FromHtml("#e4e6ec");
        public override Color DataBackgroundColor => ColorTranslator.FromHtml("#f1f3f7");
        public override Color FrameColor => ColorTranslator.FromHtml("#145665");
        public override Color GridLineColor => ColorTranslator.FromHtml("#e5e7ea");
        public override Color TickLabelColor => ColorTranslator.FromHtml("#77787b");
        public override Color TickMajorColor => ColorTranslator.FromHtml("#77787b");
        public override Color TickMinorColor => ColorTranslator.FromHtml("#77787b");
    }
}

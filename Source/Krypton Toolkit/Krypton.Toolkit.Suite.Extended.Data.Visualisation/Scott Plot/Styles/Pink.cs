#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    internal class Pink : Default
    {
        public override Color FigureBackgroundColor => ColorTranslator.FromHtml("#d7c0d0");
        public override Color DataBackgroundColor => ColorTranslator.FromHtml("#f7c7db");
        public override Color FrameColor => ColorTranslator.FromHtml("#f79ad3");
        public override Color GridLineColor => ColorTranslator.FromHtml("#c86fc9");
        public override Color TickLabelColor => ColorTranslator.FromHtml("#8e518d");
        public override Color TickMajorColor => ColorTranslator.FromHtml("#d7c0d0");
        public override Color TickMinorColor => ColorTranslator.FromHtml("#f79ad3");
    }
}

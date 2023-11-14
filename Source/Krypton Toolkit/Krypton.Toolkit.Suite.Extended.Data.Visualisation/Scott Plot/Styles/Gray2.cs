#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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

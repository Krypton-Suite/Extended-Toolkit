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

/* The AxisTicks object contains:
 *   - A TickCollection responsible for calculating tick positions and labels
 *   - major tick label styling
 *   - major/minor tick mark styling
 *   - major/minor grid line styling
 */

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class AxisTicks : IRenderable
    {
        // the tick collection determines where ticks should go and what tick labels should say
        public readonly TickCollection TickCollection = new();

        // tick label styling
        public bool TickLabelVisible = true;
        public float TickLabelRotation = 0;
        public Font TickLabelFont = new() { Size = 11 };

        // major tick/grid styling
        public bool MajorTickVisible = true;
        public float MajorTickLength = 5;
        public Color MajorTickColor = Color.Black;
        public bool MajorGridVisible = false;
        public LineStyle MajorGridStyle = LineStyle.Solid;
        public Color MajorGridColor = ColorTranslator.FromHtml("#efefef");
        public float MajorGridWidth = 1;

        // minor tick/grid styling
        public bool MinorTickVisible = true;
        public float MinorTickLength = 2;
        public Color MinorTickColor = Color.Black;
        public bool MinorGridVisible = false;
        public LineStyle MinorGridStyle = LineStyle.Solid;
        public Color MinorGridColor = ColorTranslator.FromHtml("#efefef");
        public float MinorGridWidth = 1;

        // misc configuration
        public Edge Edge;
        public bool IsHorizontal => Edge == Edge.Top || Edge == Edge.Bottom;
        public bool IsVertical => Edge == Edge.Left || Edge == Edge.Right;

        public bool IsVisible { get; set; } = true;

        public bool RulerMode = false;
        public bool SnapPx = true;
        public float PixelOffset = 0;

        // TODO: store the TickCollection in the Axis module, not in the Ticks module.

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (!IsVisible)
                return;

            using Graphics gfx = GDI.Graphics(bmp, dims, lowQuality, false);

            double[] visibleMajorTicks = TickCollection.GetVisibleMajorTicks(dims)
                .Select(t => t.Position)
                .ToArray();

            double[] visibleMinorTicks = TickCollection.GetVisibleMinorTicks(dims)
                .Select(t => t.Position)
                .ToArray();

            if (MajorTickVisible)
                AxisTicksRender.RenderTickMarks(dims, gfx, visibleMajorTicks, RulerMode ? MajorTickLength * 4 : MajorTickLength, MajorTickColor, Edge, PixelOffset);

            if (TickLabelVisible)
                AxisTicksRender.RenderTickLabels(dims, gfx, TickCollection, TickLabelFont, Edge, TickLabelRotation, RulerMode, PixelOffset, MajorTickLength, MinorTickLength);

            if (MinorTickVisible)
                AxisTicksRender.RenderTickMarks(dims, gfx, visibleMinorTicks, MinorTickLength, MinorTickColor, Edge, PixelOffset);

            if (MajorGridVisible)
                AxisTicksRender.RenderGridLines(dims, gfx, visibleMajorTicks, MajorGridStyle, MajorGridColor, MajorGridWidth, Edge);

            if (MinorGridVisible)
                AxisTicksRender.RenderGridLines(dims, gfx, visibleMinorTicks, MinorGridStyle, MinorGridColor, MinorGridWidth, Edge);
        }
    }
}

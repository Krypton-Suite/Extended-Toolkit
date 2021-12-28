﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
        public readonly TickCollection TickCollection = new TickCollection();

        // tick label styling
        public bool TickLabelVisible = true;
        public float TickLabelRotation = 0;
        public Font TickLabelFont = new Font() { Size = 11 };

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

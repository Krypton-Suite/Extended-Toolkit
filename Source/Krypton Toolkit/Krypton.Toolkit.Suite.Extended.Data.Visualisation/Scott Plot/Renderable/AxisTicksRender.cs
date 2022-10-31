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
    static class AxisTicksRender
    {
        private static bool EdgeIsVertical(Edge edge) => (edge == Edge.Left || edge == Edge.Right);

        private static bool EdgeIsHorizontal(Edge edge) => (edge == Edge.Top || edge == Edge.Bottom);

        public static void RenderGridLines(PlotDimensions dims, Graphics gfx, double[] positions,
            LineStyle gridLineStyle, Color gridLineColor, float gridLineWidth, Edge edge)
        {
            if (positions is null || positions.Length == 0 || gridLineStyle == LineStyle.None)
                return;

            // don't draw grid lines on the last pixel to prevent drawing over the data frame
            float xEdgeLeft = dims.DataOffsetX + 1;
            float xEdgeRight = dims.DataOffsetX + dims.DataWidth - 1;
            float yEdgeTop = dims.DataOffsetY + 1;
            float yEdgeBottom = dims.DataOffsetY + dims.DataHeight - 1;

            if (EdgeIsVertical(edge))
            {
                float x = (edge == Edge.Left) ? dims.DataOffsetX : dims.DataOffsetX + dims.DataWidth;
                float x2 = (edge == Edge.Left) ? dims.DataOffsetX + dims.DataWidth : dims.DataOffsetX;
                var ys = positions.Select(i => dims.GetPixelY(i)).Where(y => yEdgeTop < y && y < yEdgeBottom);
                if (gridLineStyle != LineStyle.None)
                    using (var pen = GDI.Pen(gridLineColor, gridLineWidth, gridLineStyle))
                        foreach (float y in ys)
                            gfx.DrawLine(pen, x, y, x2, y);
            }

            if (EdgeIsHorizontal(edge))
            {
                float y = (edge == Edge.Top) ? dims.DataOffsetY : dims.DataOffsetY + dims.DataHeight;
                float y2 = (edge == Edge.Top) ? dims.DataOffsetY + dims.DataHeight : dims.DataOffsetY;
                var xs = positions.Select(i => dims.GetPixelX(i)).Where(x => xEdgeLeft < x && x < xEdgeRight);
                if (gridLineStyle != LineStyle.None)
                    using (var pen = GDI.Pen(gridLineColor, gridLineWidth, gridLineStyle))
                        foreach (float x in xs)
                            gfx.DrawLine(pen, x, y, x, y2);
            }
        }

        public static void RenderTickMarks(PlotDimensions dims, Graphics gfx, double[] positions, float tickLength, Color tickColor, Edge edge, float pixelOffset)
        {
            if (positions is null || positions.Length == 0)
                return;

            if (EdgeIsVertical(edge))
            {
                float x = (edge == Edge.Left) ? dims.DataOffsetX - pixelOffset : dims.DataOffsetX + dims.DataWidth + pixelOffset;
                float tickDelta = (edge == Edge.Left) ? -tickLength : tickLength;

                var ys = positions.Select(i => dims.GetPixelY(i));
                using (var pen = GDI.Pen(tickColor))
                    foreach (float y in ys)
                        gfx.DrawLine(pen, x, y, x + tickDelta, y);
            }

            if (EdgeIsHorizontal(edge))
            {
                float y = (edge == Edge.Top) ? dims.DataOffsetY - pixelOffset : dims.DataOffsetY + dims.DataHeight + pixelOffset;
                float tickDelta = (edge == Edge.Top) ? -tickLength : tickLength;

                var xs = positions.Select(i => dims.GetPixelX(i));
                using (var pen = GDI.Pen(tickColor))
                    foreach (float x in xs)
                        gfx.DrawLine(pen, x, y, x, y + tickDelta);
            }
        }

        public static void RenderTickLabels(PlotDimensions dims, Graphics gfx, TickCollection tc, Font tickFont, Edge edge, float rotation, bool rulerMode, float PixelOffset, float MajorTickLength, float MinorTickLength)
        {
            if (TickCollectionStorage.tickLabels is null || TickCollectionStorage.tickLabels.Length == 0)
                return;

            using var font = GDI.Font(tickFont);
            using var brush = GDI.Brush(tickFont.Color);
            using var sf = GDI.StringFormat();

            Tick[] visibleMajorTicks = tc.GetVisibleMajorTicks(dims);

            switch (edge)
            {
                case Edge.Bottom:
                    for (int i = 0; i < visibleMajorTicks.Length; i++)
                    {
                        float x = dims.GetPixelX(visibleMajorTicks[i].Position);
                        float y = dims.DataOffsetY + dims.DataHeight + MajorTickLength;

                        gfx.TranslateTransform(x, y);
                        gfx.RotateTransform(-rotation);
                        sf.Alignment = rotation == 0 ? StringAlignment.Center : StringAlignment.Far;
                        if (rulerMode) sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = rotation == 0 ? StringAlignment.Near : StringAlignment.Center;
                        gfx.DrawString(visibleMajorTicks[i].Label, font, brush, 0, 0, sf);
                        gfx.ResetTransform();
                    }
                    break;

                case Edge.Top:
                    for (int i = 0; i < visibleMajorTicks.Length; i++)
                    {
                        float x = dims.GetPixelX(visibleMajorTicks[i].Position);
                        float y = dims.DataOffsetY - MajorTickLength;

                        gfx.TranslateTransform(x, y);
                        gfx.RotateTransform(-rotation);
                        sf.Alignment = rotation == 0 ? StringAlignment.Center : StringAlignment.Near;
                        if (rulerMode) sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = rotation == 0 ? StringAlignment.Far : StringAlignment.Center;
                        gfx.DrawString(visibleMajorTicks[i].Label, font, brush, 0, 0, sf);
                        gfx.ResetTransform();
                    }
                    break;

                case Edge.Left:
                    for (int i = 0; i < visibleMajorTicks.Length; i++)
                    {
                        float x = dims.DataOffsetX - PixelOffset - MajorTickLength;
                        float y = dims.GetPixelY(visibleMajorTicks[i].Position);

                        gfx.TranslateTransform(x, y);
                        gfx.RotateTransform(-rotation);
                        sf.Alignment = StringAlignment.Far;
                        sf.LineAlignment = rulerMode ? StringAlignment.Far : StringAlignment.Center;
                        if (rotation == 90)
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Far;
                        }
                        gfx.DrawString(visibleMajorTicks[i].Label, font, brush, 0, 0, sf);
                        gfx.ResetTransform();
                    }
                    break;

                case Edge.Right:
                    for (int i = 0; i < visibleMajorTicks.Length; i++)
                    {
                        float x = dims.DataOffsetX + PixelOffset + MajorTickLength + dims.DataWidth;
                        float y = dims.GetPixelY(visibleMajorTicks[i].Position);

                        gfx.TranslateTransform(x, y);
                        gfx.RotateTransform(-rotation);
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = rulerMode ? StringAlignment.Far : StringAlignment.Center;
                        if (rotation == 90)
                        {
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Near;
                        }
                        gfx.DrawString(visibleMajorTicks[i].Label, font, brush, 0, 0, sf);
                        gfx.ResetTransform();
                    }
                    break;

                default:
                    throw new NotImplementedException($"unsupported edge type {edge}");
            }

            if (!string.IsNullOrWhiteSpace(tc.CornerLabel))
            {
                switch (edge)
                {
                    case Edge.Bottom:
                        sf.Alignment = StringAlignment.Far;
                        sf.LineAlignment = StringAlignment.Near;
                        gfx.DrawString(s: "\n" + tc.CornerLabel,
                            x: dims.DataOffsetX + dims.DataWidth,
                            y: dims.DataOffsetY + dims.DataHeight + MajorTickLength,
                            font: font, brush: brush, format: sf);
                        break;

                    case Edge.Left:
                        sf.Alignment = StringAlignment.Near;
                        sf.LineAlignment = StringAlignment.Far;
                        gfx.DrawString(s: "\n" + tc.CornerLabel,
                            x: dims.DataOffsetX,
                            y: dims.DataOffsetY,
                            font: font, brush: brush, format: sf);
                        break;

                    case Edge.Top:
                        throw new NotImplementedException("multiplier and offset notation is not supported for right and top axes");

                    case Edge.Right:
                        throw new NotImplementedException("multiplier and offset notation is not supported for right and top axes");

                    default:
                        throw new NotImplementedException($"unsupported edge type {edge}");
                }
            }
        }
    }
}

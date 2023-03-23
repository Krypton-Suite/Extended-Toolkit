﻿#region MIT License
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
    public class Legend : IRenderable
    {
        public Alignment Location = Alignment.LowerRight;
        public bool FixedLineWidth = false;
        public bool ReverseOrder = false;
        public bool AntiAlias = true;
        public bool IsVisible { get; set; } = false;

        public Color FillColor = Color.White;
        public Color OutlineColor = Color.Black;
        public Color ShadowColor = Color.FromArgb(50, Color.Black);
        public float ShadowOffsetX = 2;
        public float ShadowOffsetY = 2;

        public Font Font = new Font();
        public string FontName { set => Font.Name = value; }
        public float FontSize { set => Font.Size = value; }
        public Color FontColor { set => Font.Color = value; }
        public bool FontBold { set => Font.Bold = value; }

        public float Padding = 5;
        private float SymbolWidth => 40 * Font.Size / 12;
        private float SymbolPad => Font.Size / 3;
        private float MarkerWidth => Font.Size / 2;

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (IsVisible is false || LegendItems is null || LegendItems.Length == 0)
            {
                return;
            }

            using (var gfx = GDI.Graphics(bmp, dims, lowQuality, false))
            using (var font = GDI.Font(Font))
            {
                var (maxLabelWidth, maxLabelHeight, width, height) = GetDimensions(gfx, LegendItems, font);
                var (x, y) = GetLocationPx(dims, width, height);
                RenderOnBitmap(gfx, LegendItems, font, x, y, width, height, maxLabelHeight);
            }
        }

        public Bitmap GetBitmap(bool lowQuality = false, double scale = 1.0)
        {
            if (LegendItems is null)
            {
                throw new InvalidOperationException("must render the plot at least once before getting the legend bitmap");
            }

            if (LegendItems.Length == 0)
            {
                throw new InvalidOperationException("The legend is empty (there are no visible plot objects with a label)");
            }

            // use a temporary bitmap and graphics (without scaling) to measure how large the final image should be
            using var tempBitmap = new Bitmap(1, 1);
            using var tempGfx = GDI.Graphics(tempBitmap, lowQuality, scale);
            using var legendFont = GDI.Font(Font);
            var (maxLabelWidth, maxLabelHeight, totalLabelWidth, totalLabelHeight) = GetDimensions(tempGfx, LegendItems, legendFont);

            // create the actual legend bitmap based on the scaled measured size
            int width = (int)(totalLabelWidth * scale);
            int height = (int)(totalLabelHeight * scale);
            Bitmap bmp = new(width, height, PixelFormat.Format32bppPArgb);
            using var gfx = GDI.Graphics(bmp, lowQuality, scale);
            RenderOnBitmap(gfx, LegendItems, legendFont, 0, 0, totalLabelWidth, totalLabelHeight, maxLabelHeight);

            return bmp;
        }

        private (float maxLabelWidth, float maxLabelHeight, float width, float height)
            GetDimensions(Graphics gfx, LegendItem[] items, System.Drawing.Font font)
        {
            // determine maximum label size and use it to define legend size
            float maxLabelWidth = 0;
            float maxLabelHeight = 0;
            for (int i = 0; i < items.Length; i++)
            {
                var labelSize = gfx.MeasureString(items[i].label, font);
                maxLabelWidth = Math.Max(maxLabelWidth, labelSize.Width);
                maxLabelHeight = Math.Max(maxLabelHeight, labelSize.Height);
            }

            float width = SymbolWidth + maxLabelWidth + SymbolPad;
            float height = maxLabelHeight * items.Length;

            return (maxLabelWidth, maxLabelHeight, width, height);
        }

        private void RenderOnBitmap(Graphics gfx, LegendItem[] items, System.Drawing.Font font,
            float locationX, float locationY, float width, float height, float maxLabelHeight,
            bool shadow = true, bool outline = true)
        {
            using (var fillBrush = new SolidBrush(FillColor))
            using (var shadowBrush = new SolidBrush(ShadowColor))
            using (var textBrush = new SolidBrush(Font.Color))
            using (var outlinePen = new Pen(OutlineColor))
            {
                RectangleF rectShadow = new RectangleF(locationX + ShadowOffsetX, locationY + ShadowOffsetY, width, height);
                RectangleF rectFill = new RectangleF(locationX, locationY, width, height);

                if (shadow)
                {
                    gfx.FillRectangle(shadowBrush, rectShadow);
                }

                gfx.FillRectangle(fillBrush, rectFill);

                if (outline)
                {
                    gfx.DrawRectangle(outlinePen, Rectangle.Round(rectFill));
                }

                for (int i = 0; i < items.Length; i++)
                {
                    var item = items[i];
                    float verticalOffset = i * maxLabelHeight;

                    // draw text
                    gfx.DrawString(item.label, font, textBrush, locationX + SymbolWidth, locationY + verticalOffset);

                    // prepare values for drawing a line
                    outlinePen.Color = item.color;
                    outlinePen.Width = 1;
                    float lineY = locationY + verticalOffset + maxLabelHeight / 2;
                    float lineX1 = locationX + SymbolPad;
                    float lineX2 = lineX1 + SymbolWidth - SymbolPad * 2;

                    // prepare values for drawing a rectangle
                    PointF rectOrigin = new PointF(lineX1, (float)(lineY - item.lineWidth / 2));
                    SizeF rectSize = new SizeF(lineX2 - lineX1, (float)item.lineWidth);
                    RectangleF rect = new RectangleF(rectOrigin, rectSize);

                    if (item.IsRectangle)
                    {
                        // draw a rectangle
                        using (var legendItemFillBrush = GDI.Brush(item.color, item.hatchColor, item.hatchStyle))
                        using (var legendItemOutlinePen = new Pen(item.borderColor, item.borderWith))
                        {
                            gfx.FillRectangle(legendItemFillBrush, rect);
                            gfx.DrawRectangle(legendItemOutlinePen, rect.X, rect.Y, rect.Width, rect.Height);
                        }
                    }
                    else
                    {
                        // draw a line
                        if (item.lineWidth > 0 && item.lineStyle != LineStyle.None)
                        {
                            using var linePen = GDI.Pen(item.color, item.lineWidth, item.lineStyle, false);
                            gfx.DrawLine(linePen, lineX1, lineY, lineX2, lineY);
                        }

                        // and perhaps a marker in the middle of the line
                        float lineXcenter = (lineX1 + lineX2) / 2;
                        PointF markerPoint = new PointF(lineXcenter, lineY);
                        if ((item.markerShape != MarkerShape.None) && (item.markerSize > 0))
                        {
                            MarkerTools.DrawMarker(gfx, markerPoint, item.markerShape, MarkerWidth, item.color);
                        }
                    }
                }
            }
        }

        private LegendItem[] LegendItems;
        public void UpdateLegendItems(IPlottable[] renderables)
        {
            LegendItems = renderables.Where(x => x.GetLegendItems() != null)
                                     .Where(x => x.IsVisible)
                                     .SelectMany(x => x.GetLegendItems())
                                     .Where(x => !string.IsNullOrWhiteSpace(x.label))
                                     .ToArray();
            if (ReverseOrder)
            {
                Array.Reverse(LegendItems);
            }
        }

        private (float x, float y) GetLocationPx(PlotDimensions dims, float width, float height)
        {
            float leftX = dims.DataOffsetX + Padding;
            float rightX = dims.DataOffsetX + dims.DataWidth - Padding - width;
            float centerX = dims.DataOffsetX + dims.DataWidth / 2 - width / 2;

            float topY = dims.DataOffsetY + Padding;
            float bottomY = dims.DataOffsetY + dims.DataHeight - Padding - height;
            float centerY = dims.DataOffsetY + dims.DataHeight / 2 - height / 2;

            switch (Location)
            {
                case Alignment.UpperLeft:
                    return (leftX, topY);
                case Alignment.UpperCenter:
                    return (centerX, topY);
                case Alignment.UpperRight:
                    return (rightX, topY);
                case Alignment.MiddleRight:
                    return (rightX, centerY);
                case Alignment.LowerRight:
                    return (rightX, bottomY);
                case Alignment.LowerCenter:
                    return (centerX, bottomY);
                case Alignment.LowerLeft:
                    return (leftX, bottomY);
                case Alignment.MiddleLeft:
                    return (leftX, centerY);
                case Alignment.MiddleCenter:
                    return (centerX, centerY);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

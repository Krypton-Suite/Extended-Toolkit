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
    /// <summary>
    /// An L-shaped scalebar rendered in the corner of the data area
    /// </summary>
    public class ScaleBar : IPlottable
    {
        /// <summary>
        /// Width of the scalebar in cooridinate units
        /// </summary>
        public double Width;

        /// <summary>
        /// Height of the scalebar in cooridinate units
        /// </summary>
        public double Height;

        /// <summary>
        /// Distance in pixels from the edge of the data area
        /// </summary>
        public float Padding = 10;

        public string HorizontalLabel;
        public string VerticalLabel;
        public float LineWidth = 2;
        public Color LineColor = Color.Black;
        public readonly Font Font = new Font();
        public float FontSize { set => Font.Size = value; }
        public Color FontColor { set => Font.Color = value; }
        public bool FontBold { set => Font.Bold = value; }
        public Color Color { set => (LineColor, FontColor) = (value, value); }

        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;

        public override string ToString() => $"PlottableScaleBar ({HorizontalLabel}={Width}, {VerticalLabel}={Height})";
        public AxisLimits GetAxisLimits() => new AxisLimits(double.NaN, double.NaN, double.NaN, double.NaN);
        public LegendItem[] GetLegendItems() => null;

        public void ValidateData(bool deep = false)
        {
            if (double.IsNaN(Width) || double.IsNaN(Height))
            {
                throw new InvalidOperationException("Width and Height cannot be NaN");
            }

            if (double.IsInfinity(Width) || double.IsInfinity(Height))
            {
                throw new InvalidOperationException("Width and Height cannot be Infinity");
            }
        }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            using (var gfx = GDI.Graphics(bmp, dims, lowQuality))
            using (var font = GDI.Font(Font))
            using (var fontBrush = new SolidBrush(Font.Color))
            using (var linePen = new Pen(LineColor, LineWidth))
            using (var sfNorth = new StringFormat() { LineAlignment = StringAlignment.Near, Alignment = StringAlignment.Center })
            using (var sfWest = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near })
            {
                // determine where the corner of the scalebar will be
                float widthPx = (float)(Width * dims.PxPerUnitX);
                float heightPx = (float)(Height * dims.PxPerUnitY);
                PointF cornerPoint = new PointF(dims.GetPixelX(dims.XMax) - Padding, dims.GetPixelY(dims.YMin) - Padding);

                // move the corner point away from the edge to accommodate label size
                var xLabelSize = GDI.MeasureString(gfx, HorizontalLabel, font);
                var yLabelSize = GDI.MeasureString(gfx, VerticalLabel, font);
                cornerPoint.X -= yLabelSize.Width * 1.2f;
                cornerPoint.Y -= yLabelSize.Height;

                // determine all other points relative to the corner point
                PointF horizPoint = new PointF(cornerPoint.X - widthPx, cornerPoint.Y);
                PointF vertPoint = new PointF(cornerPoint.X, cornerPoint.Y - heightPx);
                PointF horizMidPoint = new PointF((cornerPoint.X + horizPoint.X) / 2, cornerPoint.Y);
                PointF vertMidPoint = new PointF(cornerPoint.X, (cornerPoint.Y + vertPoint.Y) / 2);

                // draw the scalebar
                gfx.DrawLines(linePen, new PointF[] { horizPoint, cornerPoint, vertPoint });
                gfx.DrawString(HorizontalLabel, font, fontBrush, horizMidPoint.X, cornerPoint.Y, sfNorth);
                gfx.DrawString(VerticalLabel, font, fontBrush, cornerPoint.X, vertMidPoint.Y, sfWest);
            }
        }
    }
}

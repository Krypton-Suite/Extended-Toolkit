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
    public class StarAxis
    {
        /// <summary>
        /// The ticks for each spoke.
        /// </summary>
        public StarAxisTick[] Ticks { get; set; }

        /// <summary>
        /// The number of spokes to draw.
        /// </summary>
        public int NumberOfSpokes { get; set; }

        /// <summary>
        /// Labels for each category.
        /// Length must be equal to the number of columns (categories) in the original data.
        /// </summary>
        public string[] CategoryLabels;

        /// <summary>
        /// Icons for each category.
        /// Length must be equal to the number of columns (categories) in the original data.
        /// </summary>
        public System.Drawing.Image[] CategoryImages;

        /// <summary>
        /// Controls rendering style of the concentric circles (ticks) of the web
        /// </summary>
        public RadarAxis AxisType { get; set; }

        /// <summary>
        /// Indicates the type of axis chart to render
        /// </summary>
        public ImagePlacement ImagePlacement { get; set; }

        /// <summary>
        /// Color of the axis lines and concentric circles representing ticks
        /// </summary>
        public Color WebColor { get; set; } = Color.Gray;

        /// <summary>
        /// If true, each value will be written in text on the plot.
        /// </summary>
        public bool ShowAxisValues { get; set; } = true;

        /// <summary>
        /// If true, category labels will be written in text on the plot (provided they exist)
        /// </summary>
        public bool ShowCategoryLabels { get; set; } = true;

        /// <summary>
        /// Determines whether each spoke should be labeled, or just the first
        /// </summary>
        public bool LabelEachSpoke { get; set; } = false;

        /// <summary>
        /// The drawing surface to use.
        /// </summary>
        public Graphics Graphics { get; set; }

        /// <summary>
        /// Font used for labeling values on the plot
        /// </summary>
        public Font Font = new();

        /// <summary>
        /// Determines the width of each spoke and the axis lines.
        /// </summary>
        public int LineWidth { get; set; } = 1;

        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            double sweepAngle = 2 * Math.PI / NumberOfSpokes;
            double minScale = new double[] { dims.PxPerUnitX, dims.PxPerUnitX }.Min();
            PointF origin = new(dims.GetPixelX(0), dims.GetPixelY(0));

            RenderRings(origin, minScale, sweepAngle);
            RenderSpokes(origin, minScale, sweepAngle);

            if (CategoryImages is not null)
            {
                RenderImages(origin, minScale, sweepAngle);
            }
            else if (ShowCategoryLabels && CategoryLabels is not null)
            {
                RenderLabels(dims, origin, minScale, sweepAngle);
            }
        }

        private void RenderRings(PointF origin, double minScale, double sweepAngle)
        {
            using Pen pen = GDI.Pen(WebColor, LineWidth);

            foreach (var tick in Ticks)
            {
                double tickDistancePx = tick.Location * minScale;

                if (AxisType == RadarAxis.Circle)
                {
                    Graphics.DrawEllipse(pen,
                        x: (int)(origin.X - tickDistancePx),
                        y: (int)(origin.Y - tickDistancePx),
                        width: (int)(tickDistancePx * 2),
                        height: (int)(tickDistancePx * 2));
                }
                else if (AxisType == RadarAxis.Polygon)
                {
                    PointF[] points = new PointF[NumberOfSpokes];
                    for (int j = 0; j < NumberOfSpokes; j++)
                    {
                        float x = (float)(tickDistancePx * Math.Cos(sweepAngle * j - Math.PI / 2) + origin.X);
                        float y = (float)(tickDistancePx * Math.Sin(sweepAngle * j - Math.PI / 2) + origin.Y);
                        points[j] = new PointF(x, y);
                    }
                    Graphics.DrawPolygon(pen, points);
                }
            }
        }

        private void RenderSpokes(PointF origin, double minScale, double sweepAngle)
        {
            using Pen pen = GDI.Pen(WebColor, LineWidth);
            using System.Drawing.Font font = GDI.Font(Font);
            using Brush fontBrush = GDI.Brush(Font.Color);
            using StringFormat sf = new();

            for (int i = 0; i < NumberOfSpokes; i++)
            {
                PointF destination = new(
                    x: (float)(1.1 * Math.Cos(sweepAngle * i - Math.PI / 2) * minScale + origin.X),
                    y: (float)(1.1 * Math.Sin(sweepAngle * i - Math.PI / 2) * minScale + origin.Y));

                Graphics.DrawLine(pen, origin, destination);

                for (int j = 0; j < Ticks.Length; j++)
                {
                    double tickDistancePx = Ticks[j].Location * minScale;

                    if (ShowAxisValues)
                    {
                        if (LabelEachSpoke)
                        {
                            float x = (float)(tickDistancePx * Math.Cos(sweepAngle * i - Math.PI / 2) + origin.X);
                            float y = (float)(tickDistancePx * Math.Sin(sweepAngle * i - Math.PI / 2) + origin.Y);

                            sf.Alignment = x < origin.X ? StringAlignment.Far : StringAlignment.Near;
                            sf.LineAlignment = y < origin.Y ? StringAlignment.Far : StringAlignment.Near;

                            double val = Ticks[j].Labels[i];
                            Graphics.DrawString($"{val:f1}", font, fontBrush, x, y, sf);
                        }
                        else if (i == 0)
                        {
                            double val = Ticks[j].Labels[0];
                            Graphics.DrawString($"{val:f1}", font, fontBrush, origin.X, (float)(-tickDistancePx + origin.Y), sf);
                        }
                    }
                }
            }
        }

        private void RenderImages(PointF origin, double minScale, double sweepAngle)
        {
            for (int i = 0; i < NumberOfSpokes; i++)
            {
                double sweepOffset = ImagePlacement == ImagePlacement.Inside ? sweepAngle / 2 : 0;
                double cosinus = Math.Cos(sweepAngle * i + sweepOffset - Math.PI / 2);
                double sinus = Math.Sin(sweepAngle * i + sweepOffset - Math.PI / 2);
                int imageWidth = CategoryImages[i].Width;
                int imageHeight = CategoryImages[i].Height;

                PointF imageDestination = new(
                    (float)(1.45 * cosinus * minScale + origin.X - imageWidth / 2 * cosinus),
                    (float)(1.45 * sinus * minScale + origin.Y - imageHeight / 2 * sinus));

                RectangleF rect = new(
                    x: imageDestination.X - CategoryImages[i].Width / 2,
                    y: imageDestination.Y - CategoryImages[i].Height / 2,
                    width: CategoryImages[i].Width,
                    height: CategoryImages[i].Height);

                Graphics.DrawImage(CategoryImages[i], rect);
            }
        }

        private void RenderLabels(PlotDimensions dims, PointF origin, double minScale, double sweepAngle)
        {
            using System.Drawing.Font font = GDI.Font(Font);
            using Brush fontBrush = GDI.Brush(Font.Color);
            using StringFormat sf = GDI.StringFormat(HorizontalAlignment.Center, VerticalAlignment.Middle);

            for (int i = 0; i < NumberOfSpokes; i++)
            {
                PointF textDestination = new(
                    (float)(1.3 * Math.Cos(sweepAngle * i - Math.PI / 2) * minScale + origin.X),
                    (float)(1.3 * Math.Sin(sweepAngle * i - Math.PI / 2) * minScale + origin.Y));

                if (Math.Abs(textDestination.X - origin.X) < 0.1)
                    sf.Alignment = StringAlignment.Center;
                else
                    sf.Alignment = dims.GetCoordinateX(textDestination.X) < 0 ? StringAlignment.Far : StringAlignment.Near;

                Graphics.DrawString(CategoryLabels[i], font, fontBrush, textDestination, sf);
            }
        }
    }
}
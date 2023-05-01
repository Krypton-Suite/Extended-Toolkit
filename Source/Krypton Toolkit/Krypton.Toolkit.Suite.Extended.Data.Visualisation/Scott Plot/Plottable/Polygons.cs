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
    /// Polygons are multiple Polygon objects.
    /// This plot type is faster alternative for rendering a large number of polygons
    /// compared to adding a bunch of individual Polygon objects to the plot.
    /// </summary>
    public class Polygons : IPlottable
    {
        // data
        public readonly List<List<(double x, double y)>> Polys;

        // customization
        public string Label;
        public double LineWidth;
        public Color LineColor;
        public bool Fill = true;
        public Color FillColor;
        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;
        public Color HatchColor = Color.Transparent;
        public HatchStyle HatchStyle = HatchStyle.None;
        public bool SkipOffScreenPolygons = true;
        public bool RenderSmallPolygonsAsSinglePixels = true;

        public Polygons(List<List<(double x, double y)>> polys)
        {
            Polys = polys;
        }

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(Label) ? "" : $" ({Label})";
            return $"PlottablePolygons {label} with {PointCount} polygons";
        }

        public void ValidateData(bool deep = false)
        {
            if (deep == false)
            {
                return;
            }

            foreach (var poly in Polys)
            {
                foreach (var point in poly)
                {
                    if (double.IsNaN(point.x) || double.IsNaN(point.y))
                    {
                        throw new InvalidOperationException("points cannot contain NaN");
                    }

                    if (double.IsInfinity(point.x) || double.IsInfinity(point.y))
                    {
                        throw new InvalidOperationException("points cannot contain Infinity");
                    }
                }
            }
        }

        public int PointCount => Polys.Count;

        public AxisLimits GetAxisLimits()
        {
            double xMin = Polys[0][0].x;
            double xMax = Polys[0][0].x;
            double yMin = Polys[0][0].y;
            double yMax = Polys[0][0].y;

            foreach (var poly in Polys)
            {
                foreach (var (x, y) in poly)
                {
                    xMin = Math.Min(xMin, x);
                    xMax = Math.Max(xMax, x);
                    yMin = Math.Min(yMin, y);
                    yMax = Math.Max(yMax, y);
                }
            }

            return new AxisLimits(xMin, xMax, yMin, yMax);
        }

        public LegendItem[]? GetLegendItems()
        {
            var singleLegendItem = new LegendItem()
            {
                label = Label,
                color = Fill ? FillColor : LineColor,
                lineWidth = Fill ? 10 : LineWidth,
                markerShape = MarkerShape.None,
                hatchColor = HatchColor,
                hatchStyle = HatchStyle
            };
            return new LegendItem[] { singleLegendItem };
        }

        private bool IsBiggerThenPixel(List<(double x, double y)> poly, double UnitsPerPixelX, double UnitsPerPixelY)
        {
            double minX = poly[0].x;
            double maxX = poly[0].x;
            double minY = poly[0].y;
            double maxY = poly[0].y;
            double smallerThenPixelX = 0.5 * UnitsPerPixelX;
            double smallerThenPixelY = 0.5 * UnitsPerPixelY;
            for (int i = 1; i < poly.Count; i++)
            {
                if (poly[i].x < minX)
                {
                    minX = poly[i].x;
                    if (maxX - minX > smallerThenPixelX)
                    {
                        return true;
                    }
                }
                if (poly[i].x > maxX)
                {
                    maxX = poly[i].x;
                    if (maxX - minX > smallerThenPixelX)
                    {
                        return true;
                    }
                }
                if (poly[i].y < minX)
                {
                    minY = poly[i].y;
                    if (maxY - minY > smallerThenPixelY)
                    {
                        return true;
                    }
                }
                if (poly[i].y > maxX)
                {
                    maxY = poly[i].y;
                    if (maxY - minY > smallerThenPixelY)
                    {
                        return true;
                    }
                }
            }
            return (maxX - minX > smallerThenPixelX || maxY - minY > smallerThenPixelY);
        }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            using (Graphics gfx = GDI.Graphics(bmp, dims, lowQuality))
            {
                using (Brush brush = GDI.Brush(FillColor, HatchColor, HatchStyle))
                {
                    using (Pen pen = GDI.Pen(LineColor, LineWidth))
                    {
                        foreach (List<(double x, double y)> poly in Polys)
                        {
                            if (SkipOffScreenPolygons &&
                                poly.Where(pt => pt.x >= dims.XMin && pt.x <= dims.XMax &&
                                                 pt.y >= dims.YMin && pt.y <= dims.YMax)
                                    .Count() == 0)
                            {
                                continue;
                            }

                            var polyArray = RenderSmallPolygonsAsSinglePixels && !IsBiggerThenPixel(poly, dims.UnitsPerPxX, dims.UnitsPerPxY) ?
                                new PointF[] { new PointF(dims.GetPixelX(poly[0].x), dims.GetPixelY(poly[0].y)) } :
                                poly.Select(point => new PointF(dims.GetPixelX(point.x), dims.GetPixelY(point.y))).ToArray();

                            if (Fill)
                            {
                                if (polyArray.Length >= 3)
                                {
                                    gfx.FillPolygon(brush, polyArray);
                                }
                                else
                                {
                                    gfx.FillRectangle(brush, polyArray[0].X, polyArray[0].Y, 1, 1);
                                }
                            }

                            if (LineWidth > 0)
                            {
                                gfx.DrawPolygon(pen, polyArray);
                            }
                        }
                    }
                }
            }
        }
    }
}

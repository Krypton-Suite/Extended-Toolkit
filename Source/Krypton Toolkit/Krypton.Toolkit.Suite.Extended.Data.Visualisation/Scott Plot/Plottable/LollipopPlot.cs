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
    /// Lollipop plots display a series of "Lollipops" in place of bars. 
    /// Positions are defined by Xs.
    /// Heights are defined by Ys (relative to BaseValue and YOffsets).
    /// </summary>
    public class LollipopPlot : BarPlotBase, IPlottable
    {
        /// <summary>
        /// Name for this series of values that will appear in the legend
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Color of all lollipop components (the stick and the circle)
        /// </summary>
        public Color LollipopColor { get; set; }

        /// <summary>
        /// Size of the circle at the end of each lollipop
        /// </summary>
        public float LollipopRadius { get; set; } = 5;

        /// <summary>
        /// Create a lollipop plot from arrays of positions and sizes
        /// </summary>
        /// <param name="positions">position of each lollipop</param>
        /// <param name="values">height of each lollipop</param>
        public LollipopPlot(double[] positions, double[] values)
        {
            if (positions is null || positions.Length == 0 || values is null || values.Length == 0)
            {
                throw new InvalidOperationException("xs and ys must be arrays that contains elements");
            }

            if (values.Length != positions.Length)
            {
                throw new InvalidOperationException("xs and ys must have the same number of elements");
            }

            ValueErrors = DataGen.Zeros(values.Length);
            ValueOffsets = DataGen.Zeros(values.Length);
            Values = values;
            Positions = positions;
        }

        public LegendItem[] GetLegendItems()
        {
            var singleItem = new LegendItem()
            {
                label = Label,
                color = LollipopColor,
                lineWidth = 10,
                markerShape = MarkerShape.None,
                borderColor = BorderColor,
                borderWith = 1
            };
            return new[] { singleItem };
        }

        #region Render Implementation

        // NOTE: These render methods contains a lot of code and complexity not required to render this plot type.
        // TODO: Delete as much of this code as possible and simplify the render methods.

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            using Graphics gfx = GDI.Graphics(bmp, dims, lowQuality);
            for (int barIndex = 0; barIndex < Values.Length; barIndex++)
            {
                if (Orientation == PlotOrientation.Vertical)
                {
                    RenderBarVertical(dims, gfx, Positions[barIndex] + PositionOffset, Values[barIndex], ValueErrors[barIndex], ValueOffsets[barIndex]);
                }
                else
                {
                    RenderBarHorizontal(dims, gfx, Positions[barIndex] + PositionOffset, Values[barIndex], ValueErrors[barIndex], ValueOffsets[barIndex]);
                }
            }
        }

        private void RenderBarFromRect(RectangleF rect, bool negative, Graphics gfx)
        {
            float centerPx = Orientation == PlotOrientation.Horizontal
                ? rect.Y + rect.Height / 2
                : rect.X + rect.Width / 2;

            using var fillPen = new Pen(LollipopColor);
            using var fillBrush = GDI.Brush(LollipopColor);

            if (Orientation == PlotOrientation.Horizontal)
            {
                gfx.FillEllipse(fillBrush, negative ? rect.X : rect.X + rect.Width, centerPx - LollipopRadius / 2, LollipopRadius, LollipopRadius);
                gfx.DrawLine(fillPen, rect.X, centerPx, rect.X + rect.Width, centerPx);
            }
            else
            {
                gfx.FillEllipse(fillBrush, centerPx - LollipopRadius / 2, !negative ? rect.Y : rect.Y + rect.Height, LollipopRadius, LollipopRadius);
                gfx.DrawLine(fillPen, centerPx, rect.Y, centerPx, rect.Y + rect.Height);
            }
        }

        private void RenderBarVertical(PlotDimensions dims, Graphics gfx, double position, double value, double valueError, double yOffset)
        {
            // bar body
            float centerPx = dims.GetPixelX(position);
            double edge1 = position - BarWidth / 2;
            double value1 = Math.Min(ValueBase, value) + yOffset;
            double value2 = Math.Max(ValueBase, value) + yOffset;
            double valueSpan = value2 - value1;

            var rect = new RectangleF(
                x: dims.GetPixelX(edge1),
                y: dims.GetPixelY(value2),
                width: (float)(BarWidth * dims.PxPerUnitX),
                height: (float)(valueSpan * dims.PxPerUnitY));

            // errorbar
            double error1 = value > 0 ? value2 - Math.Abs(valueError) : value1 - Math.Abs(valueError);
            double error2 = value > 0 ? value2 + Math.Abs(valueError) : value1 + Math.Abs(valueError);
            float capPx1 = dims.GetPixelX(position - ErrorCapSize * BarWidth / 2);
            float capPx2 = dims.GetPixelX(position + ErrorCapSize * BarWidth / 2);
            float errorPx2 = dims.GetPixelY(error2);
            float errorPx1 = dims.GetPixelY(error1);

            RenderBarFromRect(rect, value < 0, gfx);

            if (ErrorLineWidth > 0 && valueError > 0)
            {
                using var errorPen = new Pen(ErrorColor, ErrorLineWidth);
                gfx.DrawLine(errorPen, centerPx, errorPx1, centerPx, errorPx2);
                gfx.DrawLine(errorPen, capPx1, errorPx1, capPx2, errorPx1);
                gfx.DrawLine(errorPen, capPx1, errorPx2, capPx2, errorPx2);
            }

            if (ShowValuesAboveBars)
            {
                using (var valueTextFont = GDI.Font(Font))
                {
                    using (var valueTextBrush = GDI.Brush(Font.Color))
                    {
                        using (var sf = new StringFormat() { LineAlignment = StringAlignment.Far, Alignment = StringAlignment.Center })
                        {
                            gfx.DrawString(value.ToString(CultureInfo.InvariantCulture), valueTextFont, valueTextBrush, centerPx, rect.Y, sf);
                        }
                    }
                }
            }
        }

        private void RenderBarHorizontal(PlotDimensions dims, Graphics gfx, double position, double value, double valueError, double yOffset)
        {
            // bar body
            float centerPx = dims.GetPixelY(position);
            double edge2 = position + BarWidth / 2;
            double value1 = Math.Min(ValueBase, value) + yOffset;
            double value2 = Math.Max(ValueBase, value) + yOffset;
            double valueSpan = value2 - value1;
            var rect = new RectangleF(
                x: dims.GetPixelX(value1),
                y: dims.GetPixelY(edge2),
                height: (float)(BarWidth * dims.PxPerUnitY),
                width: (float)(valueSpan * dims.PxPerUnitX));

            RenderBarFromRect(rect, value < 0, gfx);

            // errorbar
            double error1 = value > 0 ? value2 - Math.Abs(valueError) : value1 - Math.Abs(valueError);
            double error2 = value > 0 ? value2 + Math.Abs(valueError) : value1 + Math.Abs(valueError);
            float capPx1 = dims.GetPixelY(position - ErrorCapSize * BarWidth / 2);
            float capPx2 = dims.GetPixelY(position + ErrorCapSize * BarWidth / 2);
            float errorPx2 = dims.GetPixelX(error2);
            float errorPx1 = dims.GetPixelX(error1);

            if (ErrorLineWidth > 0 && valueError > 0)
            {
                using var errorPen = new Pen(ErrorColor, ErrorLineWidth);
                gfx.DrawLine(errorPen, errorPx1, centerPx, errorPx2, centerPx);
                gfx.DrawLine(errorPen, errorPx1, capPx2, errorPx1, capPx1);
                gfx.DrawLine(errorPen, errorPx2, capPx2, errorPx2, capPx1);
            }

            if (ShowValuesAboveBars)
            {
                using (var valueTextFont = GDI.Font(Font))
                {
                    using (var valueTextBrush = GDI.Brush(Font.Color))
                    {
                        using (var sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near })
                        {
                            gfx.DrawString(value.ToString(CultureInfo.InvariantCulture), valueTextFont, valueTextBrush, rect.X + rect.Width, centerPx, sf);
                        }
                    }
                }
            }
        }

        #endregion

        public void ValidateData(bool deep = false)
        {
            // TODO: refactor entire data validation system for all plot types (triaged March 2021)
        }
    }
}

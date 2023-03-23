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
    /// A Pie chart where the angle of slices is constant but the radii are not.
    /// </summary>
    public class CoxcombPlot : IPlottable
    {
        private double[] _values;

        /// <summary>
        /// The data to be plotted
        /// </summary>
        public double[] Values
        {
            get => _values;
            set
            {
                _values = value;
                Normalized = Normalize(value);
            }
        }
        /// <summary>
        /// The colors of each slice
        /// </summary>
        public Color[] FillColors { get; set; }

        /// <summary>
        /// The color to draw the axis in
        /// </summary>
        public Color WebColor { get; set; } = Color.Gray;

        /// <summary>
        /// Controls rendering style of the concentric circles (ticks) of the web
        /// </summary>
        public RadarAxis AxisType { get; set; } = RadarAxis.Circle;

        /// <summary>
        /// If true, each value will be written in text on the plot.
        /// </summary>
        public bool ShowAxisValues { get; set; } = true;

        /// <summary>
        /// Labels for each category.
        /// Length must be equal to the number of columns (categories) in the original data.
        /// </summary>
        public string[] SliceLabels;

        /// <summary>
        /// Icons for each category.
        /// Length must be equal to the number of columns (categories) in the original data. 
        /// </summary>
        public System.Drawing.Image[] CategoryImages { get; set; }

        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;

        public string Label;

        private double[] Normalized;

        public CoxcombPlot(double[] values, Color[] fillColors)
        {
            Values = values;
            FillColors = fillColors;
        }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            int numCategories = Normalized.Length;
            PointF origin = new PointF(dims.GetPixelX(0), dims.GetPixelY(0));
            double sweepAngle = 360f / numCategories;
            double maxRadiusPixels = new double[] { dims.PxPerUnitX, dims.PxPerUnitX }.Min();
            double maxDiameterPixels = maxRadiusPixels * 2;


            using Graphics gfx = GDI.Graphics(bmp, dims, lowQuality);
            using SolidBrush sliceFillBrush = (SolidBrush)GDI.Brush(Color.Black);

            RenderAxis(gfx, dims, bmp, lowQuality);

            double start = -90;
            for (int i = 0; i < numCategories; i++)
            {
                double angle = (Math.PI / 180) * ((sweepAngle + 2 * start) / 2);
                float diameter = (float)(maxDiameterPixels * Normalized[i]);
                sliceFillBrush.Color = FillColors[i];

                gfx.FillPie(brush: sliceFillBrush,
                    x: (int)origin.X - diameter / 2,
                    y: (int)origin.Y - diameter / 2,
                    width: diameter,
                    height: diameter,
                    startAngle: (float)start,
                    sweepAngle: (float)sweepAngle);

                start += sweepAngle;
            }
        }

        private void RenderAxis(Graphics gfx, PlotDimensions dims, Bitmap bmp, bool lowQuality)
        {
            double[,] Norm = new double[Normalized.Length, 1];
            for (int i = 0; i < Normalized.Length; i++)
            {
                Norm[i, 0] = Normalized[i];
            }

            StarAxisTick[] Ticks = new double[] { 0.25, 0.5, 1 }
                .Select(x => new StarAxisTick(x, Values.Max()))
                .ToArray();

            StarAxis axis = new()
            {
                Ticks = Ticks,
                CategoryLabels = SliceLabels,
                AxisType = AxisType,
                WebColor = WebColor,
                ShowAxisValues = ShowAxisValues,
                CategoryImages = CategoryImages,
                Graphics = gfx,
                ShowCategoryLabels = false,
                NumberOfSpokes = Values.Length,
                ImagePlacement = ImagePlacement.Inside
            };

            axis.Render(dims, bmp, lowQuality);
        }

        private static double[] Normalize(double[] values)
        {
            double Max = values.Max();

            if (Max == 0)
            {
                return values.Select(_ => 0.0).ToArray();
            }

            return values.Select(v => v / Max).ToArray();
        }

        public LegendItem[] GetLegendItems()
        {
            if (SliceLabels is null)
            {
                return null;
            }

            return Enumerable
                .Range(0, Values.Length)
                .Select(i => new LegendItem() { label = SliceLabels[i], color = FillColors[i], lineWidth = 10 })
                .ToArray();
        }

        public AxisLimits GetAxisLimits() => new AxisLimits(-2.5, 2.5, -2.5, 2.5);

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(this.Label) ? "" : $" ({this.Label})";
            return $"PlottableCoxcomb {label} with {Values.Length} categories";
        }

        public void ValidateData(bool deep = false)
        {
            // TODO
        }
    }
}

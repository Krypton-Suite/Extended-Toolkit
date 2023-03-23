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
    /// A heatmap displays a 2D array of intensities as small rectangles on the plot
    /// colored according to their intensity value according to a colormap.
    /// </summary>
    public class Heatmap : IPlottable, IHasColormap
    {
        /// <summary>
        /// Minimum heatmap value
        /// </summary>
        private double Min;

        /// <summary>
        /// Maximum heatmap value
        /// </summary>
        private double Max;

        /// <summary>
        /// Number of columns in the heatmap data
        /// </summary>
        private int DataWidth;

        /// <summary>
        /// Number of rows in the heatmap data
        /// </summary>
        private int DataHeight;

        /// <summary>
        /// Pre-rendered heatmap image
        /// </summary>
        protected Bitmap BmpHeatmap;

        /// <summary>
        /// Horizontal location of the lower-left cell
        /// </summary>
        public double OffsetX = 0;

        /// <summary>
        /// Vertical location of the lower-left cell
        /// </summary>
        public double OffsetY = 0;

        /// <summary>
        /// Width of each cell composing the heatmap
        /// </summary>
        public double CellWidth = 1;

        /// <summary>
        /// Width of each cell composing the heatmap
        /// </summary>
        public double CellHeight = 1;

        /// <summary>
        /// Position of the left edge of the heatmap
        /// </summary>
        public double XMin
        {
            get => OffsetX;
            set => OffsetX = value;
        }

        /// <summary>
        /// Position of the right edge of the heatmap
        /// </summary>
        public double XMax
        {
            get => OffsetX + DataWidth * CellWidth;
            set => CellWidth = (value - OffsetX) / DataWidth;
        }

        public double YMin
        {
            get => OffsetY;
            set => OffsetY = value;
        }

        public double YMax
        {
            get => OffsetY + DataHeight * CellHeight;
            set => CellHeight = (value - OffsetY) / DataHeight;
        }

        /// <summary>
        /// Text to appear in the legend
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Colormap used to translate heatmap values to colors
        /// </summary>
        public ColourMap Colormap { get; private set; } = ColourMap.Viridis;

        /// <summary>
        /// If defined, colors will be "clipped" to this value such that lower values (lower colors) will not be shown
        /// </summary>
        public double? ScaleMin { get; set; }

        /// <summary>
        /// If defined, colors will be "clipped" to this value such that greater values (higher colors) will not be shown
        /// </summary>
        public double? ScaleMax { get; set; }

        /// <summary>
        /// Heatmap values below this number (if defined) will be made transparent
        /// </summary>
        public double? TransparencyThreshold { get; set; }

        [Obsolete("This feature has been deprecated. Use AddImage() to place a bitmap beneath or above the heatmap.", true)]
        public Bitmap BackgroundImage { get; set; }

        [Obsolete("This feature has been deprecated. Use AddImage() to place a bitmap beneath or above the heatmap.", true)]
        public bool DisplayImageAbove { get; set; }

        [Obsolete("This feature has been deprecated. Use Plot.AddText() to add text to the plot.", true)]
        public bool ShowAxisLabels;

        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;

        /// <summary>
        /// Value of the the lower edge of the colormap
        /// </summary>
        public double ColormapMin => ScaleMin ?? Min;

        /// <summary>
        /// Value of the the upper edge of the colormap
        /// </summary>
        public double ColormapMax => ScaleMax ?? Max;

        /// <summary>
        /// Indicates whether values extend beyond the lower edge of the colormap
        /// </summary>
        public bool ColormapMinIsClipped { get; private set; } = false;

        /// <summary>
        /// Indicates whether values extend beyond the upper edge of the colormap
        /// </summary>
        public bool ColormapMaxIsClipped { get; private set; } = false;

        /// <summary>
        /// If true, heatmap squares will be smoothed using high quality bicubic interpolation.
        /// If false, heatmap squares will look like sharp rectangles (nearest neighbor interpolation).
        /// </summary>
        public bool Smooth
        {
            get => Interpolation != InterpolationMode.NearestNeighbor;
            set => Interpolation = value ? InterpolationMode.HighQualityBicubic : InterpolationMode.NearestNeighbor;
        }

        /// <summary>
        /// Controls which interpolation mode is used when zooming into the heatmap.
        /// </summary>
        public InterpolationMode Interpolation { get; set; } = InterpolationMode.NearestNeighbor;

        /// <summary>
        /// This method analyzes the intensities and colormap to create a bitmap
        /// with a single pixel for every intensity value. The bitmap is stored
        /// and displayed (without anti-alias interpolation) when Render() is called.
        /// </summary>
        /// <param name="intensities">2D array of data for the heatmap (null values are not shown)</param>
        /// <param name="colormap">update the Colormap to use this colormap</param>
        /// <param name="min">minimum intensity (according to the colormap)</param>
        /// <param name="max">maximum intensity (according to the colormap)</param>
        public void Update(double?[,] intensities, ColourMap colormap = null, double? min = null, double? max = null)
        {
            DataWidth = intensities.GetLength(1);
            DataHeight = intensities.GetLength(0);
            Colormap = colormap ?? Colormap;
            ScaleMin = min;
            ScaleMax = max;

            double?[] intensitiesFlattened = intensities.Cast<double?>().ToArray();
            Min = double.PositiveInfinity;
            Max = double.NegativeInfinity;

            foreach (double? curr in intensitiesFlattened)
            {
                if (curr.HasValue && double.IsNaN(curr.Value))
                {
                    throw new ArgumentException("Heatmaps do not support intensities of double.NaN");
                }

                if (curr.HasValue && curr.Value < Min)
                {
                    Min = curr.Value;
                }

                if (curr.HasValue && curr.Value > Max)
                {
                    Max = curr.Value;
                }
            }

            ColormapMinIsClipped = ScaleMin.HasValue && ScaleMin > Min;
            ColormapMaxIsClipped = ScaleMax.HasValue && ScaleMax < Max;

            double normalizeMin = (ScaleMin.HasValue && ScaleMin.Value < Min) ? ScaleMin.Value : Min;
            double normalizeMax = (ScaleMax.HasValue && ScaleMax.Value > Max) ? ScaleMax.Value : Max;

            if (TransparencyThreshold.HasValue)
            {
                TransparencyThreshold = Normalize(TransparencyThreshold.Value, Min, Max, ScaleMin, ScaleMax);
            }

            double?[] NormalizedIntensities = Normalize(intensitiesFlattened, null, null, ScaleMin, ScaleMax);

            int[] flatARGB = ColourMap.GetRGBAs(NormalizedIntensities, Colormap, minimumIntensity: TransparencyThreshold ?? 0);
            double?[] normalizedValues = Normalize(Enumerable.Range(0, 256).Select(i => (double?)i).Reverse().ToArray(), null, null, ScaleMin, ScaleMax);
            int[] scaleRGBA = ColourMap.GetRGBAs(normalizedValues, Colormap);

            BmpHeatmap?.Dispose();
            BmpHeatmap = new Bitmap(DataWidth, DataHeight, PixelFormat.Format32bppArgb);
            Rectangle rect = new(0, 0, BmpHeatmap.Width, BmpHeatmap.Height);
            BitmapData bmpData = BmpHeatmap.LockBits(rect, ImageLockMode.ReadWrite, BmpHeatmap.PixelFormat);
            Marshal.Copy(flatARGB, 0, bmpData.Scan0, flatARGB.Length);
            BmpHeatmap.UnlockBits(bmpData);
        }


        /// <summary>
        /// This method analyzes the intensities and colormap to create a bitmap
        /// with a single pixel for every intensity value. The bitmap is stored
        /// and displayed (without anti-alias interpolation) when Render() is called.
        /// </summary>
        /// <param name="intensities">2D array of data for the heatmap (all values are shown)</param>
        /// <param name="colormap">update the Colormap to use this colormap</param>
        /// <param name="min">minimum intensity (according to the colormap)</param>
        /// <param name="max">maximum intensity (according to the colormap)</param>
        public void Update(double[,] intensities, ColourMap colormap = null, double? min = null, double? max = null)
        {
            double?[,] tmp = new double?[intensities.GetLength(0), intensities.GetLength(1)];
            for (int i = 0; i < intensities.GetLength(0); i++)
                for (int j = 0; j < intensities.GetLength(1); j++)
                    tmp[i, j] = intensities[i, j];
            Update(tmp, colormap, min, max);
        }

        private double? Normalize(double? input, double? min = null, double? max = null, double? scaleMin = null, double? scaleMax = null)
            => Normalize(new double?[] { input }, min, max, scaleMin, scaleMax)[0];

        private double?[] Normalize(double?[] input, double? min = null, double? max = null, double? scaleMin = null, double? scaleMax = null)
        {
            double? NormalizePreserveNull(double? i)
            {
                if (i.HasValue)
                {
                    return (i.Value - min.Value) / (max.Value - min.Value);
                }
                return null;
            }

            min ??= input.Min();
            max ??= input.Max();

            min = (scaleMin.HasValue && scaleMin.Value < min) ? scaleMin.Value : min;
            max = (scaleMax.HasValue && scaleMax.Value > max) ? scaleMax.Value : max;

            double?[] normalized = input.AsParallel().AsOrdered().Select(i => NormalizePreserveNull(i)).ToArray();

            if (scaleMin.HasValue)
            {
                double threshold = (scaleMin.Value - min.Value) / (max.Value - min.Value);
                normalized = normalized.AsParallel().AsOrdered().Select(i => i < threshold ? threshold : i).ToArray();
            }

            if (scaleMax.HasValue)
            {
                double threshold = (scaleMax.Value - min.Value) / (max.Value - min.Value);
                normalized = normalized.AsParallel().AsOrdered().Select(i => i > threshold ? threshold : i).ToArray();
            }

            return normalized;
        }

        public LegendItem[] GetLegendItems()
        {
            var singleLegendItem = new LegendItem()
            {
                label = Label,
                color = Color.Gray,
                lineWidth = 10,
                markerShape = MarkerShape.None
            };
            return new LegendItem[] { singleLegendItem };
        }

        public virtual AxisLimits GetAxisLimits()
        {
            if (BmpHeatmap is null)
            {
                return new AxisLimits();
            }

            return new AxisLimits(
                xMin: OffsetX,
                xMax: OffsetX + DataWidth * CellWidth,
                yMin: OffsetY,
                yMax: OffsetY + DataHeight * CellHeight);
        }

        public void ValidateData(bool deepValidation = false)
        {
            if (BmpHeatmap is null)
            {
                throw new InvalidOperationException("Update() was not called prior to rendering");
            }

            if (deepValidation)
            {
                if (DataWidth > 1e6 || DataHeight > 1e6)
                {
                    throw new ArgumentException("Heatmaps may be unreliable for arrays with edges larger than 1 million values");
                }

                if (DataWidth * DataHeight > 1e7)
                {
                    throw new ArgumentException("Heatmaps may be unreliable for arrays with more than 10 million values");
                }
            }
        }
        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            RenderHeatmap(dims, bmp, lowQuality);
        }

        protected virtual void RenderHeatmap(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            using Graphics gfx = GDI.Graphics(bmp, dims, lowQuality);

            gfx.InterpolationMode = Interpolation;
            gfx.PixelOffsetMode = PixelOffsetMode.Half;

            int fromX = (int)Math.Round(dims.GetPixelX(OffsetX));
            int fromY = (int)Math.Round(dims.GetPixelY(OffsetY + DataHeight * CellHeight));
            int width = (int)Math.Round(dims.GetPixelX(OffsetX + DataWidth * CellWidth) - fromX);
            int height = (int)Math.Round(dims.GetPixelY(OffsetY) - fromY);

            Rectangle destRect = new(fromX, fromY, width, height);

            ImageAttributes attr = new();
            attr.SetWrapMode(WrapMode.TileFlipXY);

            gfx.DrawImage(
                    image: BmpHeatmap,
                    destRect: destRect,
                    srcX: 0,
                    srcY: 0,
                    BmpHeatmap.Width,
                    BmpHeatmap.Height,
                    GraphicsUnit.Pixel,
                    attr);
        }

        public override string ToString() => $"PlottableHeatmap ({BmpHeatmap.Size})";
    }
}

﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// The VectorField displays arrows representing a 2D array of 2D vectors
    /// </summary>
    public class VectorField : IPlottable
    {
        private readonly double[] Xs;
        private readonly double[] Ys;
        private readonly Vector2[,] Vectors;
        private readonly Color[] VectorColors;
        public string Label;
        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;

        private readonly ArrowStyle ArrowStyle = new();

        /// <summary>
        /// Describes which part of the vector line will be placed at the data coordinates.
        /// </summary>
        public ArrowAnchor Anchor { get => ArrowStyle.Anchor; set => ArrowStyle.Anchor = value; }

        /// <summary>
        /// If enabled arrowheads will be drawn as lines scaled to each vector's magnitude.
        /// </summary>
        public bool ScaledArrowheads { get => ArrowStyle.ScaledArrowheads; set => ArrowStyle.ScaledArrowheads = value; }

        /// <summary>
        /// When using scaled arrowheads this defines the width of the arrow relative to the vector line's length.
        /// </summary>
        public double ScaledArrowheadWidth { get => ArrowStyle.ScaledArrowheadWidth; set => ArrowStyle.ScaledArrowheadWidth = value; }

        /// <summary>
        /// When using scaled arrowheads this defines length of the arrowhead relative to the vector line's length.
        /// </summary>
        public double ScaledArrowheadLength { get => ArrowStyle.ScaledArrowheadLength; set => ArrowStyle.ScaledArrowheadLength = value; }

        /// <summary>
        /// Marker drawn at each coordinate
        /// </summary>
        public MarkerShape MarkerShape { get => ArrowStyle.MarkerShape; set => ArrowStyle.MarkerShape = value; }

        /// <summary>
        /// Size of markers to be drawn at each coordinate
        /// </summary>
        public float MarkerSize { get => ArrowStyle.MarkerSize; set => ArrowStyle.MarkerSize = value; }

        public VectorField(Vector2[,] vectors, double[] xs, double[] ys, ColourMap colormap, double scaleFactor, Color defaultColor)
        {
            double minMagnitudeSquared = vectors[0, 0].LengthSquared();
            double maxMagnitudeSquared = vectors[0, 0].LengthSquared();
            for (int i = 0; i < xs.Length; i++)
            {
                for (int j = 0; j < ys.Length; j++)
                {
                    if (vectors[i, j].LengthSquared() > maxMagnitudeSquared)
                        maxMagnitudeSquared = vectors[i, j].LengthSquared();
                    else if (vectors[i, j].LengthSquared() < minMagnitudeSquared)
                        minMagnitudeSquared = vectors[i, j].LengthSquared();
                }
            }
            double minMagnitude = Math.Sqrt(minMagnitudeSquared);
            double maxMagnitude = Math.Sqrt(maxMagnitudeSquared);

            double[,] intensities = new double[xs.Length, ys.Length];
            for (int i = 0; i < xs.Length; i++)
            {
                for (int j = 0; j < ys.Length; j++)
                {
                    if (colormap != null)
                        intensities[i, j] = (vectors[i, j].Length() - minMagnitude) / (maxMagnitude - minMagnitude);
                    vectors[i, j] = Vector2.Multiply(vectors[i, j], (float)(scaleFactor / (maxMagnitude * 1.2)));
                }
            }

            double[] flattenedIntensities = intensities.Cast<double>().ToArray();
            VectorColors = colormap is null ?
                Enumerable.Range(0, flattenedIntensities.Length).Select(x => defaultColor).ToArray() :
                ColourMap.GetColours(flattenedIntensities, colormap);

            this.Vectors = vectors;
            this.Xs = xs;
            this.Ys = ys;
        }

        public void ValidateData(bool deep = false) { /* validation occurs in constructor */ }

        public LegendItem[] GetLegendItems()
        {
            var singleLegendItem = new LegendItem()
            {
                label = Label,
                color = VectorColors[0],
                lineWidth = 10,
                markerShape = MarkerShape.NONE
            };
            return new LegendItem[] { singleLegendItem };
        }

        public AxisLimits GetAxisLimits() => new AxisLimits(Xs.Min() - 1, Xs.Max() + 1, Ys.Min() - 1, Ys.Max() + 1);

        public int PointCount { get => Vectors.Length; }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (IsVisible == false)
                return;

            using Graphics gfx = GDI.Graphics(bmp, dims, lowQuality);

            ArrowStyle.Render(dims, gfx, Xs, Ys, Vectors, VectorColors);
        }

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(this.Label) ? "" : $" ({this.Label})";
            return $"PlottableVectorField{label} with {PointCount} vectors";
        }
    }
}

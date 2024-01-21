#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

// ReSharper disable UnusedParameter.Local
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// The VectorField displays arrows representing a 2D array of 2D vectors
    /// </summary>
    public class VectorField : IPlottable
    {
        private readonly double[] _xs;
        private readonly double[] _ys;
        private readonly Vector2[,] _vectors;
        private readonly Color[] _vectorColors;
        public string Label;
        public bool IsVisible { get; set; } = true;
        public int XAxisIndex { get; set; } = 0;
        public int YAxisIndex { get; set; } = 0;

        private readonly ArrowStyle _arrowStyle = new();

        /// <summary>
        /// Describes which part of the vector line will be placed at the data coordinates.
        /// </summary>
        public ArrowAnchor Anchor { get => _arrowStyle.Anchor; set => _arrowStyle.Anchor = value; }

        /// <summary>
        /// If enabled arrowheads will be drawn as lines scaled to each vector's magnitude.
        /// </summary>
        public bool ScaledArrowheads { get => _arrowStyle.ScaledArrowheads; set => _arrowStyle.ScaledArrowheads = value; }

        /// <summary>
        /// When using scaled arrowheads this defines the width of the arrow relative to the vector line's length.
        /// </summary>
        public double ScaledArrowheadWidth { get => _arrowStyle.ScaledArrowheadWidth; set => _arrowStyle.ScaledArrowheadWidth = value; }

        /// <summary>
        /// When using scaled arrowheads this defines length of the arrowhead relative to the vector line's length.
        /// </summary>
        public double ScaledArrowheadLength { get => _arrowStyle.ScaledArrowheadLength; set => _arrowStyle.ScaledArrowheadLength = value; }

        /// <summary>
        /// Marker drawn at each coordinate
        /// </summary>
        public MarkerShape MarkerShape { get => _arrowStyle.MarkerShape; set => _arrowStyle.MarkerShape = value; }

        /// <summary>
        /// Size of markers to be drawn at each coordinate
        /// </summary>
        public float MarkerSize { get => _arrowStyle.MarkerSize; set => _arrowStyle.MarkerSize = value; }

        public VectorField(Vector2[,] vectors, double[] xs, double[] ys, ColourMap colormap, double scaleFactor, Color defaultColor)
        {
            double minMagnitudeSquared = vectors[0, 0].LengthSquared();
            double maxMagnitudeSquared = vectors[0, 0].LengthSquared();
            for (int i = 0; i < xs.Length; i++)
            {
                for (int j = 0; j < ys.Length; j++)
                {
                    if (vectors[i, j].LengthSquared() > maxMagnitudeSquared)
                    {
                        maxMagnitudeSquared = vectors[i, j].LengthSquared();
                    }
                    else if (vectors[i, j].LengthSquared() < minMagnitudeSquared)
                    {
                        minMagnitudeSquared = vectors[i, j].LengthSquared();
                    }
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
                    {
                        intensities[i, j] = (vectors[i, j].Length() - minMagnitude) / (maxMagnitude - minMagnitude);
                    }

                    vectors[i, j] = Vector2.Multiply(vectors[i, j], (float)(scaleFactor / (maxMagnitude * 1.2)));
                }
            }

            double[] flattenedIntensities = intensities.Cast<double>().ToArray();
            _vectorColors = colormap is null ?
                Enumerable.Range(0, flattenedIntensities.Length).Select(x => defaultColor).ToArray() :
                ColourMap.GetColours(flattenedIntensities, colormap);

            _vectors = vectors;
            _xs = xs;
            _ys = ys;
        }

        public void ValidateData(bool deep = false) { /* validation occurs in constructor */ }

        public LegendItem[] GetLegendItems()
        {
            var singleLegendItem = new LegendItem()
            {
                label = Label,
                color = _vectorColors[0],
                lineWidth = 10,
                markerShape = MarkerShape.None
            };
            return new[] { singleLegendItem };
        }

        public AxisLimits GetAxisLimits() => new(_xs.Min() - 1, _xs.Max() + 1, _ys.Min() - 1, _ys.Max() + 1);

        public int PointCount => _vectors.Length;

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (IsVisible == false)
            {
                return;
            }

            using Graphics gfx = GDI.Graphics(bmp, dims, lowQuality);

            _arrowStyle.Render(dims, gfx, _xs, _ys, _vectors, _vectorColors);
        }

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(Label) ? "" : $" ({Label})";
            return $"PlottableVectorField{label} with {PointCount} vectors";
        }
    }
}

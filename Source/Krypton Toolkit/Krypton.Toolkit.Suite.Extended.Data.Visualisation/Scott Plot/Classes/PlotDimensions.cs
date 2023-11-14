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
    /// <summary>
    /// PlotDimensions supplies figure dimensions and pixel/coordinate lookup methods for a single 2D plane
    /// </summary>
    public class PlotDimensions
    {
        // plot dimensions
        public readonly float Width;
        public readonly float Height;
        public readonly float DataWidth;
        public readonly float DataHeight;
        public readonly float DataOffsetX;
        public readonly float DataOffsetY;

        // rendering options
        public readonly double ScaleFactor;

        // axis limits
        public readonly double XMin;
        public readonly double XMax;
        public readonly double YMin;
        public readonly double YMax;
        public readonly double XSpan;
        public readonly double YSpan;
        public readonly double XCenter;
        public readonly double YCenter;

        // pixel/coordinate conversions
        public readonly double PxPerUnitX;
        public readonly double PxPerUnitY;
        public readonly double UnitsPerPxX;
        public readonly double UnitsPerPxY;

        public Pixel GetPixel(Coordinate coordinate) => new Pixel(GetPixelX(coordinate.X), GetPixelY(coordinate.Y));
        public float GetPixelX(double position) => (float)(DataOffsetX + ((position - XMin) * PxPerUnitX));
        public float GetPixelY(double position) => (float)(DataOffsetY + ((YMax - position) * PxPerUnitY));

        public Coordinate GetCoordinate(Pixel pixel) => new Coordinate(GetCoordinateX(pixel.X), GetCoordinateY(pixel.Y));
        public double GetCoordinateX(float pixel) => (pixel - DataOffsetX) / PxPerUnitX + XMin;
        public double GetCoordinateY(float pixel) => DataHeight - ((pixel - YMin) * PxPerUnitY);

        public PlotDimensions(SizeF figureSize, SizeF dataSize, PointF dataOffset,
            (double xMin, double xMax, double yMin, double yMax) axisLimits,
            double scaleFactor)
        {
            (Width, Height) = (figureSize.Width, figureSize.Height);
            (DataWidth, DataHeight) = (dataSize.Width, dataSize.Height);
            (DataOffsetX, DataOffsetY) = (dataOffset.X, dataOffset.Y);
            (XMin, XMax, YMin, YMax) = (axisLimits.xMin, axisLimits.xMax, axisLimits.yMin, axisLimits.yMax);
            (XSpan, YSpan) = (XMax - XMin, YMax - YMin);
            (XCenter, YCenter) = ((XMin + XMax) / 2, (YMin + YMax) / 2);
            (PxPerUnitX, PxPerUnitY) = (DataWidth / XSpan, DataHeight / YSpan);
            (UnitsPerPxX, UnitsPerPxY) = (XSpan / DataWidth, YSpan / DataHeight);
            ScaleFactor = scaleFactor;
        }

        public override string ToString() =>
            $"Dimensions for figure ({Width}x{Height}), data area ({DataWidth}x{DataHeight}), and axes ({XMin}, {XMax}, {YMin}, {YMax})";
    }
}
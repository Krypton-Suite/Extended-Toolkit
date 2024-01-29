namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class SignalXySourceDoubleArray : ISignalXySource
    {
        readonly double[] _xs;
        readonly double[] _ys;
        public bool Rotated { get; set; } = false;

        public double XOffset { get; set; } = 0;
        public double YOffset { get; set; } = 0;
        public int MinimumIndex { get; set; } = 0;
        public int MaximumIndex { get; set; }

        public SignalXySourceDoubleArray(double[] xs, double[] ys)
        {
            if (xs.Length != ys.Length)
            {
                throw new ArgumentException($"{nameof(xs)} and {nameof(ys)} must have equal length");
            }

            _xs = xs;
            _ys = ys;
            MaximumIndex = xs.Length - 1;
        }

        public AxisLimits GetAxisLimits()
        {
            double xMin = _xs[MinimumIndex] + XOffset;
            double xMax = _xs[MaximumIndex] + XOffset;

            CoordinateRange xRange = new(xMin, xMax);
            CoordinateRange yRange = GetRange(MinimumIndex, MaximumIndex);
            return Rotated
                ? new AxisLimits(yRange, xRange)
                : new AxisLimits(xRange, yRange);
        }

        public Pixel[] GetPixelsToDraw(RenderPack rp, IAxes axes)
        {
            return Rotated
                ? GetPixelsToDrawVertically(rp, axes)
                : GetPixelsToDrawHorizontally(rp, axes);
        }

        private Pixel[] GetPixelsToDrawHorizontally(RenderPack rp, IAxes axes)
        {
            // determine the range of data in view
            (Pixel[] pointBefore, int dataIndexFirst) = GetFirstPointX(axes);
            (Pixel[] pointAfter, int dataIndexLast) = GetLastPointX(axes);
            IndexRange visibileRange = new(dataIndexFirst, dataIndexLast);

            // get all points in view
            IEnumerable<Pixel> visiblePoints = Enumerable.Range(0, (int)Math.Ceiling(rp.DataRect.Width))
                .Select(pxColumn => GetColumnPixelsX(pxColumn, visibileRange, rp, axes))
                .SelectMany(x => x);

            // combine with one extra point before and after
            Pixel[] points = [.. pointBefore, .. visiblePoints, .. pointAfter];

            // use interpolation at the edges to prevent points from going way off the screen
            if (pointBefore.Length > 0)
            {
                SignalInterpolation.InterpolateBeforeX(rp, points);
            }

            if (pointAfter.Length > 0)
            {
                SignalInterpolation.InterpolateAfterX(rp, points);
            }

            return points;
        }

        private Pixel[] GetPixelsToDrawVertically(RenderPack rp, IAxes axes)
        {
            // determine the range of data in view
            (Pixel[] pointBefore, int dataIndexFirst) = GetFirstPointY(axes);
            (Pixel[] pointAfter, int dataIndexLast) = GetLastPointY(axes);
            IndexRange visibleRange = new(dataIndexFirst, dataIndexLast);

            // get all points in view
            IEnumerable<Pixel> visiblePoints = Enumerable.Range(0, (int)Math.Ceiling(rp.DataRect.Height))
                .Select(pxRow => GetColumnPixelsY(pxRow, visibleRange, rp, axes))
                .SelectMany(x => x);

            // combine with one extra point before and after
            Pixel[] points = [.. pointBefore, .. visiblePoints, .. pointAfter];

            // use interpolation at the edges to prevent points from going way off the screen
            if (pointBefore.Length > 0)
            {
                SignalInterpolation.InterpolateBeforeY(rp, points);
            }

            if (pointAfter.Length > 0)
            {
                SignalInterpolation.InterpolateAfterY(rp, points);
            }

            return points;
        }

        /// <summary>
        /// Return the vertical range covered by data between the given indices (inclusive)
        /// </summary>
        public CoordinateRange GetRange(int index1, int index2)
        {
            double min = _ys[index1];
            double max = _ys[index1];

            for (int i = index1; i <= index2; i++)
            {
                min = Math.Min(_ys[i], min);
                max = Math.Max(_ys[i], max);
            }

            return new CoordinateRange(min + YOffset, max + YOffset);
        }

        /// <summary>
        /// Get the index associated with the given X position
        /// </summary>
        public int GetIndex(double x)
        {
            IndexRange range = new(MinimumIndex, MaximumIndex);
            return GetIndex(x, range);
        }

        /// <summary>
        /// Get the index associated with the given X position limited to the given range
        /// </summary>
        public int GetIndex(double x, IndexRange indexRange)
        {
            int index = Array.BinarySearch(_xs, indexRange.Min, indexRange.Length, x - XOffset);

            if (index < 0)
            {
                index = ~index; // read BinarySearch() docs
            }

            return index;
        }

        /// <summary>
        /// Given a pixel column, return the pixels to render its line.
        /// If the column contains no data, no pixels are returned.
        /// If the column contains one point, return that one pixel.
        /// If the column contains multiple points, return 4 pixels: enter, min, max, and exit
        /// </summary>
        public IEnumerable<Pixel> GetColumnPixelsX(int pixelColumnIndex, IndexRange rng, RenderPack rp, IAxes axes)
        {
            float xPixel = pixelColumnIndex + rp.DataRect.Left;
            double unitsPerPixelX = axes.XAxis.Width / rp.DataRect.Width;
            double start = axes.XAxis.Min + unitsPerPixelX * pixelColumnIndex;
            double end = start + unitsPerPixelX;
            int startIndex = GetIndex(start, rng);
            int endIndex = GetIndex(end, rng);
            int pointsInRange = endIndex - startIndex;

            if (pointsInRange == 0)
            {
                yield break;
            }

            yield return new Pixel(xPixel, axes.GetPixelY(_ys[startIndex] + YOffset)); // enter

            if (pointsInRange > 1)
            {
                CoordinateRange yRange = GetRange(startIndex, endIndex - 1);
                yield return new Pixel(xPixel, axes.GetPixelY(yRange.Min)); // min
                yield return new Pixel(xPixel, axes.GetPixelY(yRange.Max)); // max
                yield return new Pixel(xPixel, axes.GetPixelY(_ys[endIndex - 1] + YOffset)); // exit
            }
        }

        /// <summary>
        /// Given a pixel column, return the pixels to render its line.
        /// If the column contains no data, no pixels are returned.
        /// If the column contains one point, return that one pixel.
        /// If the column contains multiple points, return 4 pixels: enter, min, max, and exit
        /// </summary>
        public IEnumerable<Pixel> GetColumnPixelsY(int rowColumnIndex, IndexRange rng, RenderPack rp, IAxes axes)
        {
            float yPixel = rp.DataRect.Bottom - rowColumnIndex;
            double unitsPerPixelY = axes.YAxis.Height / rp.DataRect.Height;
            double start = axes.YAxis.Min + unitsPerPixelY * rowColumnIndex;
            double end = start + unitsPerPixelY;
            int startIndex = GetIndex(start, rng);
            int endIndex = GetIndex(end, rng);
            int pointsInRange = endIndex - startIndex;

            if (pointsInRange == 0)
            {
                yield break;
            }

            yield return new Pixel(axes.GetPixelX(_ys[startIndex] + XOffset), yPixel); // enter

            if (pointsInRange > 1)
            {
                CoordinateRange yRange = GetRange(startIndex, endIndex - 1);
                yield return new Pixel(axes.GetPixelX(yRange.Min), yPixel); // min
                yield return new Pixel(axes.GetPixelX(yRange.Max), yPixel); // max
                yield return new Pixel(axes.GetPixelX(_ys[endIndex - 1] + XOffset), yPixel); // exit
            }
        }

        /// <summary>
        /// If data is off to the screen to the left, 
        /// returns information about the closest point off the screen
        /// </summary>
        private (Pixel[] pointsBefore, int firstIndex) GetFirstPointX(IAxes axes)
        {
            int pointBeforeIndex = GetIndex(axes.XAxis.Min);

            if (pointBeforeIndex > MinimumIndex)
            {
                float beforeX = axes.GetPixelX(_xs[pointBeforeIndex - 1] + XOffset);
                float beforeY = axes.GetPixelY(_ys[pointBeforeIndex - 1] + YOffset);
                Pixel beforePoint = new(beforeX, beforeY);
                return ([beforePoint], pointBeforeIndex);
            }
            else
            {
                return ([], MinimumIndex);
            }
        }

        /// <summary>
        /// If data is off to the screen to the bottom, 
        /// returns information about the closest point off the screen
        /// </summary>
        private (Pixel[] pointsBefore, int firstIndex) GetFirstPointY(IAxes axes)
        {
            int pointBeforeIndex = GetIndex(axes.YAxis.Min);

            if (pointBeforeIndex > MinimumIndex)
            {
                float beforeX = axes.GetPixelX(_ys[pointBeforeIndex - 1] + XOffset);
                float beforeY = axes.GetPixelY(_xs[pointBeforeIndex - 1] + YOffset);
                Pixel beforePoint = new(beforeX, beforeY);
                return ([beforePoint], pointBeforeIndex);
            }
            else
            {
                return ([], MinimumIndex);
            }
        }

        /// <summary>
        /// If data is off to the screen to the right, 
        /// returns information about the closest point off the screen
        /// </summary>
        private (Pixel[] pointsBefore, int lastIndex) GetLastPointX(IAxes axes)
        {
            int pointAfterIndex = GetIndex(axes.XAxis.Max);

            if (pointAfterIndex <= MaximumIndex)
            {
                float afterX = axes.GetPixelX(_xs[pointAfterIndex] + XOffset);
                float afterY = axes.GetPixelY(_ys[pointAfterIndex] + YOffset);
                Pixel afterPoint = new(afterX, afterY);
                return ([afterPoint], pointAfterIndex);
            }
            else
            {
                return ([], MaximumIndex);
            }
        }

        /// <summary>
        /// If data is off to the screen to the top, 
        /// returns information about the closest point off the screen
        /// </summary>
        private (Pixel[] pointsBefore, int lastIndex) GetLastPointY(IAxes axes)
        {
            int pointAfterIndex = GetIndex(axes.YAxis.Max);

            if (pointAfterIndex <= MaximumIndex)
            {
                float afterX = axes.GetPixelX(_ys[pointAfterIndex] + XOffset);
                float afterY = axes.GetPixelY(_xs[pointAfterIndex] + YOffset);
                Pixel afterPoint = new(afterX, afterY);
                return ([afterPoint], pointAfterIndex);
            }
            else
            {
                return ([], MaximumIndex);
            }
        }
    }
}
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// This data source manages X/Y points as separate X and Y collections
    /// </summary>
    public class ScatterSourceDoubleArray : IScatterSource
    {
        private readonly double[] _xs;
        private readonly double[] _ys;

        public ScatterSourceDoubleArray(double[] xs, double[] ys)
        {
            _xs = xs;
            _ys = ys;
        }

        public IReadOnlyList<Coordinates> GetScatterPoints()
        {
            // TODO: try to avoid calling this
            return _xs.Zip(_ys, (x, y) => new Coordinates(x, y)).ToArray();
        }

        public AxisLimits GetLimits()
        {
            return new AxisLimits(GetLimitsX(), GetLimitsY());
        }

        public CoordinateRange GetLimitsX()
        {
            if (!_xs.Any())
            {
                return CoordinateRange.NotSet;
            }

            return new CoordinateRange(_xs.Min(), _xs.Max());
        }

        public CoordinateRange GetLimitsY()
        {
            if (!_ys.Any())
            {
                return CoordinateRange.NotSet;
            }

            return new CoordinateRange(_ys.Min(), _ys.Max());
        }

        public DataPoint GetNearest(Coordinates mouseLocation, RenderDetails renderInfo, float maxDistance = 15)
        {
            double maxDistanceSquared = maxDistance * maxDistance;
            var closestDistanceSquared = double.PositiveInfinity;

            var closestIndex = 0;
            var closestX = double.PositiveInfinity;
            var closestY = double.PositiveInfinity;

            for (var i = 0; i < _xs.Length; i++)
            {
                var dX = (_xs[i] - mouseLocation.X) * renderInfo.PxPerUnitX;
                var dY = (_ys[i] - mouseLocation.Y) * renderInfo.PxPerUnitY;
                var distanceSquared = dX * dX + dY * dY;

                if (distanceSquared <= closestDistanceSquared)
                {
                    closestDistanceSquared = distanceSquared;
                    closestX = _xs[i];
                    closestY = _ys[i];
                    closestIndex = i;
                }
            }

            return closestDistanceSquared <= maxDistanceSquared
                ? new DataPoint(closestX, closestY, closestIndex)
                : DataPoint.None;
        }
    }
}
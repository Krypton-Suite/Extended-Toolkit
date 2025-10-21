namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

/// <summary>
/// This data source manages X/Y points as separate X and Y collections
/// </summary>
public class ScatterSourceGenericArray<T1, T2> : IScatterSource
{
    private readonly T1[] _xs;
    private readonly T2[] _ys;

    public ScatterSourceGenericArray(T1[] xs, T2[] ys)
    {
        if (xs.Length != ys.Length)
        {
            throw new ArgumentException($"{nameof(xs)} and {nameof(ys)} must have equal length");
        }

        _xs = xs;
        _ys = ys;
    }

    public IReadOnlyList<Coordinates> GetScatterPoints()
    {
        // TODO: try to avoid calling this
        return _xs.Zip(_ys, (x, y) => NumericConversion.GenericToCoordinates(ref x, ref y)).ToArray();
    }

    public AxisLimits GetLimits()
    {
        return new AxisLimits(GetLimitsX(), GetLimitsY());
    }

    public CoordinateRange GetLimitsX()
    {
        if (_xs.Length == 0)
        {
            return CoordinateRange.NotSet;
        }

        var values = NumericConversion.GenericToDoubleArray(_xs);

        return new CoordinateRange(values.Min(), values.Max());
    }

    public CoordinateRange GetLimitsY()
    {
        if (_ys.Length == 0)
        {
            return CoordinateRange.NotSet;
        }

        var values = NumericConversion.GenericToDoubleArray(_ys);

        return new CoordinateRange(values.Min(), values.Max());
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
            var xValue = _xs[i];
            var yValue = _ys[i];
            var xValueDouble = NumericConversion.GenericToDouble(ref xValue);
            var yValueDouble = NumericConversion.GenericToDouble(ref yValue);
            var dX = (xValueDouble - mouseLocation.X) * renderInfo.PxPerUnitX;
            var dY = (yValueDouble - mouseLocation.Y) * renderInfo.PxPerUnitY;
            var distanceSquared = dX * dX + dY * dY;

            if (distanceSquared <= closestDistanceSquared)
            {
                closestDistanceSquared = distanceSquared;
                closestX = xValueDouble;
                closestY = yValueDouble;
                closestIndex = i;
            }
        }

        return closestDistanceSquared <= maxDistanceSquared
            ? new DataPoint(closestX, closestY, closestIndex)
            : DataPoint.None;
    }
}
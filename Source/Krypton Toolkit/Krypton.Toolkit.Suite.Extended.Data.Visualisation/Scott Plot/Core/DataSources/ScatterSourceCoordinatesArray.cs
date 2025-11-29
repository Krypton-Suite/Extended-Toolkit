namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

/// <summary>
/// This data source manages X/Y points as a collection of coordinates
/// </summary>
public class ScatterSourceCoordinatesArray : IScatterSource
{
    private readonly Coordinates[] _coordinates;

    public ScatterSourceCoordinatesArray(Coordinates[] coordinates)
    {
        _coordinates = coordinates;
    }

    public IReadOnlyList<Coordinates> GetScatterPoints()
    {
        // TODO: try to avoid calling this
        return _coordinates;
    }

    public AxisLimits GetLimits()
    {
        ExpandingAxisLimits limits = new();
        limits.Expand(_coordinates);
        return limits.AxisLimits;
    }

    public CoordinateRange GetLimitsX()
    {
        return GetLimits().Rect.XRange;
    }

    public CoordinateRange GetLimitsY()
    {
        return GetLimits().Rect.YRange;
    }

    public DataPoint GetNearest(Coordinates mouseLocation, RenderDetails renderInfo, float maxDistance = 15)
    {
        double maxDistanceSquared = maxDistance * maxDistance;
        var closestDistanceSquared = double.PositiveInfinity;

        var closestIndex = 0;
        var closestX = double.PositiveInfinity;
        var closestY = double.PositiveInfinity;

        for (var i = 0; i < _coordinates.Length; i++)
        {
            double dX = (_coordinates[i].X - mouseLocation.X) * renderInfo.PxPerUnitX;
            double dY = (_coordinates[i].Y - mouseLocation.Y) * renderInfo.PxPerUnitY;
            var distanceSquared = dX * dX + dY * dY;

            if (distanceSquared <= closestDistanceSquared)
            {
                closestDistanceSquared = distanceSquared;
                closestX = _coordinates[i].X;
                closestY = _coordinates[i].Y;
                closestIndex = i;
            }
        }

        return closestDistanceSquared <= maxDistanceSquared
            ? new DataPoint(closestX, closestY, closestIndex)
            : DataPoint.None;
    }
}
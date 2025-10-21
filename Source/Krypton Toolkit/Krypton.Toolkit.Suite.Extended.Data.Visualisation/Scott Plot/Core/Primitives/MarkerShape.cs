namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public enum MarkerShape
{
    None,
    FilledCircle,
    OpenCircle,
    FilledSquare,
    OpenSquare,
    FilledTriangleUp,
    OpenTriangleUp,
    FilledTriangleDown,
    OpenTriangleDown,
    FilledDiamond,
    OpenDiamond,
    Eks,
    Cross,
    VerticalBar,
    HorizontalBar,
    TriUp,
    TriDown,
    Asterisk,
    HashTag,
}

public static class MarkerShapeExtensions
{
    public static IMarker GetRenderer(this MarkerShape shape)
    {
        return shape switch
        {
            MarkerShape.FilledCircle or MarkerShape.OpenCircle => new Circle(),
            MarkerShape.FilledSquare or MarkerShape.OpenSquare => new SquareMarker(),
            MarkerShape.FilledTriangleUp or MarkerShape.OpenTriangleUp => new TriangleUp(),
            MarkerShape.FilledTriangleDown or MarkerShape.OpenTriangleDown => new TriangleDown(),
            MarkerShape.FilledDiamond or MarkerShape.OpenDiamond => new Diamond(),
            MarkerShape.Eks => new Eks(),
            MarkerShape.Cross => new Cross(),
            MarkerShape.VerticalBar => new VerticalBar(),
            MarkerShape.HorizontalBar => new HorizontalBar(),
            MarkerShape.TriUp => new TriUp(),
            MarkerShape.TriDown => new TriDown(),
            MarkerShape.Asterisk => new Asterisk(),
            MarkerShape.HashTag => new HashTag(),
            MarkerShape.None => new None(),
            _ => throw new NotImplementedException(shape.ToString()),
        };
    }

    public static bool IsOutlined(this MarkerShape shape)
    {
        return shape switch
        {
            (MarkerShape.OpenCircle or MarkerShape.OpenSquare or MarkerShape.OpenTriangleUp or
                MarkerShape.OpenTriangleDown or MarkerShape.OpenDiamond or MarkerShape.Eks or
                MarkerShape.Cross or MarkerShape.VerticalBar or MarkerShape.HorizontalBar or
                MarkerShape.TriUp or MarkerShape.TriDown or MarkerShape.Asterisk or
                MarkerShape.HashTag) => true,
            _ => false,
        };
    }
}
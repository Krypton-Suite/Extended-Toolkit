namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public enum HandTypes
    {
        NORMAL = 1,
        MEDIUM = 2,
        SMALL = 3
    }

    public enum CentrePointSizes
    {
        NORMAL = 1,
        MEDIUM = 2,
        SMALL = 3,
        SMALLER = 4
    }

    public enum CentrePointTypes
    {
        ROUND = 1,
        SQUARE = 2
    }

    public enum ChartType
    {
        STICK,
        LINE
    }

    public enum Cursor
    {
        ARROW,
        CROSSHAIR,
        HAND,
        WE,
        NS,
        ALL
    }

    public enum DateTimeUnit
    {
        YEAR,
        MONTH,
        DAY,
        HOUR,
        MINUTE,
        SECOND
    }

    public enum Edge
    {
        Left,
        Right,
        Bottom,
        Top
    }

    public enum Orientation
    {
        Horizontal,
        Vertical
    }

    public enum Direction { W, NW, N, NE, E, SE, S, SW, C }

    public enum HorizontalAlignment { Left, Right, Center }

    public enum VerticalAlignment { Upper, Lower, Center }

    public enum legendLocation
    {
        none,
        upperLeft,
        upperRight,
        upperCenter,
        middleLeft,
        middleRight,
        lowerLeft,
        lowerRight,
        lowerCenter,
    }
    public enum shadowDirection
    {
        none,
        upperLeft,
        upperRight,
        lowerLeft,
        lowerRight,
    }

    public enum Style
    {
        Default,
        Control,
        Blue1,
        Blue2,
        Blue3,
        Light1,
        Light2,
        Gray1,
        Gray2,
        Black,
        Seaborn
    }

    public enum TextAlignment
    {
        // TODO: capitolize these in ScottPlot 4.1
        upperLeft,
        upperRight,
        upperCenter,
        middleLeft,
        middleRight,
        lowerLeft,
        lowerRight,
        lowerCenter,
        middleCenter
    }

    public enum LineStyle
    {
        None,
        Solid,
        Dash,
        DashDot,
        DashDotDot,
        Dot
    }

    /// <summary>
    /// Time resolution for the minor tick marks which are spaced Chart.TimeWidth apart
    /// </summary>
    public enum TimeResolution
    {
        Week,
        Day,
        Hour,
        Minute,
        Second,
    }
}
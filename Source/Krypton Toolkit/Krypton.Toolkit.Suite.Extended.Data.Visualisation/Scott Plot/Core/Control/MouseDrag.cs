namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public struct MouseDrag
{
    public readonly MultiAxisLimitManager InitialLimits;
    public readonly Pixel From;
    public readonly Pixel To;

    public MouseDrag(MultiAxisLimitManager limits, Pixel from, Pixel to)
    {
        InitialLimits = limits;
        From = from;
        To = to;
    }
}
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class EmptyTickGenerator : ITickGenerator
{
    public Tick[] Ticks { get; set; } = [];

    public int MaxTickCount { get; set; } = 50;

    public EmptyTickGenerator()
    {
    }

    public void Regenerate(CoordinateRange range, Edge edge, PixelLength size)
    {
    }
}
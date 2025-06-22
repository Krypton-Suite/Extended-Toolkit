namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class Wipe : IDataStreamerView
{
    private readonly bool _wipeRight;

    public DataStreamer Streamer { get; }

    //TODO: Add a BlankFraction property that adds a gap between old and new data

    public Wipe(DataStreamer streamer, bool wipeRight)
    {
        Streamer = streamer;
        _wipeRight = wipeRight;
    }

    public void Render(RenderPack rp)
    {
        int newestCount = Streamer.Data.NextIndex;
        int oldestCount = Streamer.Data.Data.Length - newestCount;

        double xMax = Streamer.Data.Data.Length * Streamer.Data.SamplePeriod + Streamer.Data.OffsetX;

        Pixel[] newest = new Pixel[newestCount];
        Pixel[] oldest = new Pixel[oldestCount];

        for (int i = 0; i < newest.Length; i++)
        {
            double xPos = i * Streamer.Data.SamplePeriod + Streamer.Data.OffsetX;
            float x = Streamer.Axes.GetPixelX(_wipeRight ? xPos : xMax - xPos);
            float y = Streamer.Axes.GetPixelY(Streamer.Data.Data[i] + Streamer.Data.OffsetY);
            newest[i] = new(x, y);
        }

        for (int i = 0; i < oldest.Length; i++)
        {
            double xPos = (i + Streamer.Data.NextIndex) * Streamer.Data.SamplePeriod + Streamer.Data.OffsetX;
            float x = Streamer.Axes.GetPixelX(_wipeRight ? xPos : xMax - xPos);
            float y = Streamer.Axes.GetPixelY(Streamer.Data.Data[i + Streamer.Data.NextIndex] + Streamer.Data.OffsetY);
            oldest[i] = new(x, y);
        }

        using SKPaint paint = new();
        Drawing.DrawLines(rp.Canvas, paint, oldest, Streamer.LineStyle);
        Drawing.DrawLines(rp.Canvas, paint, newest, Streamer.LineStyle);
    }
}
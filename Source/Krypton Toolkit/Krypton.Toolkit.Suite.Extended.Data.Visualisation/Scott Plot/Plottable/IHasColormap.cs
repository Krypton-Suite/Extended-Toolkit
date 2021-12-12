namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IHasColormap
    {
        Drawing.Colormap Colormap { get; }
        double ColormapMin { get; }
        double ColormapMax { get; }
        bool ColormapMinIsClipped { get; }
        bool ColormapMaxIsClipped { get; }
    }
}

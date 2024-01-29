namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IHasColorAxis
    {
        Range GetRange();
        IColormap Colormap { get; }
    }
}
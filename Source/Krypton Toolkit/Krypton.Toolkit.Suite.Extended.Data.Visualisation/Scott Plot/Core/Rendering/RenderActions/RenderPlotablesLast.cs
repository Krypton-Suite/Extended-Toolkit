namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class RenderPlotablesLast : IRenderAction
{
    public void Render(RenderPack rp)
    {
        rp.Plot.PlottableList
            .Where(x => x.IsVisible)
            .OfType<IRenderLast>()
            .ToList()
            .ForEach(x => x.RenderLast(rp));
    }
}
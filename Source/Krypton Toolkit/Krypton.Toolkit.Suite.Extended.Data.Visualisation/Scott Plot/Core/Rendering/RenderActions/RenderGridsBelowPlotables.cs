namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class RenderGridsBelowPlotables : IRenderAction
    {
        public void Render(RenderPack rp)
        {
            foreach (IGrid grid in rp.Plot.Axes.Grids.Where(x => x.IsBeneathPlotables))
            {
                grid.Render(rp);
            }
        }
    }
}
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class SyncGlPlotables : IRenderAction
    {
        public void Render(RenderPack rp)
        {
            var glPlottables = rp.Plot.PlottableList.OfType<IPlottableGl>();
            if (glPlottables.Any())
            {
                glPlottables.First().GlFinish();
            }
        }
    }
}
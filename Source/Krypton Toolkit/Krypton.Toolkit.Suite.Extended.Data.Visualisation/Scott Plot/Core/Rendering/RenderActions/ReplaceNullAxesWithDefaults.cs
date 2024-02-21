namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class ReplaceNullAxesWithDefaults : IRenderAction
    {
        public void Render(RenderPack rp)
        {
            rp.Plot.Axes.ReplaceNullAxesWithDefaults();
        }
    }
}
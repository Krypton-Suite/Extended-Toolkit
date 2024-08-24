namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class ApplyAxisRulesBeforeLayout : IRenderAction
    {
        public void Render(RenderPack rp)
        {
            rp.Plot.Axes.Rules.ForEach(x => x.Apply(rp, beforeLayout: true));
        }
    }
}
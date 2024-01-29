namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class RenderBenchmark : IRenderAction
    {
        public void Render(RenderPack rp)
        {
            rp.Plot.Benchmark.Render(rp);
        }
    }
}
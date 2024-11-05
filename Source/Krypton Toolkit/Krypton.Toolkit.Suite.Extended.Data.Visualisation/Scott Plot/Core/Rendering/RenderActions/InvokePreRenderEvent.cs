namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class InvokePreRenderEvent : IRenderAction
    {
        public void Render(RenderPack rp)
        {
            rp.Plot.RenderManager.RenderStarting.Invoke(this, rp);
        }
    }
}
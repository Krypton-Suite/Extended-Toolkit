namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class PreRenderLock : IRenderAction
{
    public void Render(RenderPack rp)
    {
        rp.Plot.RenderManager.PreRenderLock.Invoke(this, EventArgs.Empty);
    }
}
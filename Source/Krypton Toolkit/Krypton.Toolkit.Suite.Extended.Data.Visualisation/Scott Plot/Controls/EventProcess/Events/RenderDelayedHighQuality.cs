namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    class RenderDelayedHighQuality : IUIEvent
    {
        public RenderType RenderType => RenderType.LowQualityThenHighQualityDelayed;

        public void ProcessEvent()
        {
        }
    }
}
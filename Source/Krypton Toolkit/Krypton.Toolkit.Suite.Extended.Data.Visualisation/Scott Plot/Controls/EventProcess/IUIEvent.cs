namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IUIEvent
    {
        public RenderType RenderType { get; }
        void ProcessEvent();
    }
}
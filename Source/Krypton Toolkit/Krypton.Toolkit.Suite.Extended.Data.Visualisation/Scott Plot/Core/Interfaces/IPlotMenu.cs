namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IPlotMenu
    {
        public void Reset();

        public void Clear();

        public void Add(string label, Action<IPlotControl> action);

        void ShowContextMenu(Pixel pixel);
    }
}
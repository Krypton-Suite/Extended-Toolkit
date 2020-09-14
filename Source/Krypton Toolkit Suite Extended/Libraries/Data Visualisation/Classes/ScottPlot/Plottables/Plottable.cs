namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public abstract class Plottable
    {
        public bool visible = true;
        public abstract void Render(Settings settings);
        public abstract override string ToString();
        public abstract AxisLimits2D GetLimits();
        public abstract int GetPointCount();
        public abstract LegendItem[] GetLegendItems();
    }
}

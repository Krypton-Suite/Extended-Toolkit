namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public struct SizedLegendItem
{
    public LegendItem Item { get; }
    public LegendItemSize Size { get; }
    public SizedLegendItem[] Children { get; }

    public SizedLegendItem(LegendItem item, LegendItemSize size, SizedLegendItem[] children)
    {
        Item = item;
        Size = size;
        Children = children;
    }
}
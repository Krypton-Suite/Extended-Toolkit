namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public struct LegendItemSize
    {
        public PixelSize OwnSize { get; }
        public PixelSize WithChildren { get; }

        public LegendItemSize(PixelSize ownSize, PixelSize withChildren)
        {
            OwnSize = ownSize;
            WithChildren = withChildren;
        }
    }
}
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class LegendItem
    {
        public string label;
        public Color colour;

        public LineStyle lineStyle;
        public double lineWidth;
        public MarkerShape markerShape;
        public double markerSize;

        public LegendItem(string label, Color colour, LineStyle lineStyle = LineStyle.Solid, double lineWidth = 1, MarkerShape markerShape = MarkerShape.filledCircle, double markerSize = 3)
        {
            this.label = label;
            this.colour = colour;

            this.lineStyle = lineStyle;
            this.lineWidth = lineWidth;
            this.markerShape = markerShape;
            this.markerSize = markerSize;
        }
    }
}
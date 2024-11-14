namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class GrayscaleReversed : ColormapBase
    {
        public override string Name => "Grayscale Reversed";

        public override Color GetColor(double normalizedIntensity)
        {
            var value = (byte)(255 - (byte)(255 * normalizedIntensity));
            return Color.Gray(value);
        }
    }
}

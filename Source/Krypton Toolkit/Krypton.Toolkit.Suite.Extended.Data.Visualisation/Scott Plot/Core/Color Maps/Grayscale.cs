namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Grayscale : ColormapBase
    {
        public override string Name => "Grayscale";

        public override Color GetColor(double normalizedIntensity)
        {
            var value = (byte)(255 * normalizedIntensity);
            return Color.Gray(value);
        }
    }
}

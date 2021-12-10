namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IColourMap
    {
        (byte r, byte g, byte b) GetRGB(byte value);
        string Name { get; }
    }
}
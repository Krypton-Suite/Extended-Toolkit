namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class Grayscale : IColourmap
    {
        public (byte r, byte g, byte b) GetRGB(byte value)
        {
            return (value, value, value);
        }
    }
}
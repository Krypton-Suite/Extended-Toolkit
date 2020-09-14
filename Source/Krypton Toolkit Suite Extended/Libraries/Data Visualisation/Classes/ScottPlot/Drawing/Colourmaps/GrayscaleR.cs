namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class GrayscaleR : IColourmap
    {
        public (byte r, byte g, byte b) GetRGB(byte value)
        {
            value = (byte)(255 - value);
            return (value, value, value);
        }
    }
}
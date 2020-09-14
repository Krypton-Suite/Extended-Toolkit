namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public interface IColourmap
    {
        (byte r, byte g, byte b) GetRGB(byte value);
    }
}
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public interface IColourset
    {
        (byte r, byte g, byte b) GetRGB(int index);
        int Count();
    }
}
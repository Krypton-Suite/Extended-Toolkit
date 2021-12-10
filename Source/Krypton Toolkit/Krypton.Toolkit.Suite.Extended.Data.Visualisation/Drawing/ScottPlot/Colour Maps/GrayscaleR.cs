// This colormap was created by Scott Harden on 2020-06-16 and is released under a MIT license.

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class GrayscaleR : IColourMap
    {
        public string Name => "GrayscaleR";

        public (byte r, byte g, byte b) GetRGB(byte value)
        {
            value = (byte)(255 - value);
            return (value, value, value);
        }
    }
}

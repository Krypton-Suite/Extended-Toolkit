#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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

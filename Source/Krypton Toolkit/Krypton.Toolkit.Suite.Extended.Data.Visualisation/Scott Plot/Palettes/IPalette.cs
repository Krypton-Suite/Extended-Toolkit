#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

/* 
 * A color set is a collection of colors, like a color palette.
 * 
 * System.Drawing.Color is intentionally avoided here to simplify 
 * porting to other rendering systems down the road.
 * 
 **/

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IPalette
    {
        (byte r, byte g, byte b) GetRGB(int index);
        int Count();
    }
}

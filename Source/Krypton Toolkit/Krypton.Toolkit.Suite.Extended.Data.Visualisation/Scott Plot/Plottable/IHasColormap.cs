#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public interface IHasColormap
    {
        ColourMap Colormap { get; }
        double ColormapMin { get; }
        double ColormapMax { get; }
        bool ColormapMinIsClipped { get; }
        bool ColormapMaxIsClipped { get; }
    }
}

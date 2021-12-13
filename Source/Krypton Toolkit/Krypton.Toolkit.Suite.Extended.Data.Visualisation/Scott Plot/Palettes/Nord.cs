#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

/* Sourced from NordConEmu:
 * https://github.com/arcticicestudio/nord-conemu
 * Seems to be an extended version of Aurora
 */
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Nord : HexColourset, IPalette
    {
        // suggested background: #2e3440
        public override string[] hexColors => new string[]
        {
            "#bf616a", "#a3be8c", "#ebcb8b", "#81a1c1", "#b48ead", "#88c0d0", "#e5e9f0",
        };
    }
}

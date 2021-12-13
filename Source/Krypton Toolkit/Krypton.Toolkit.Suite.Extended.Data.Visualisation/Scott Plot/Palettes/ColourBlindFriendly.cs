#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

/* This color palette was sourced from the examples provided in:
 * Wong 2011, https://www.nature.com/articles/nmeth.1618.pdf
 * This 8-color palette has good overall variability and can be 
 * differentiated by individuals with red-green color blindness.
 */
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class ColourBlindFriendly : HexColourset, IPalette
    {
        public override string[] hexColors => new string[]
        {
            "#000000", "#E69F00", "#56B4E9", "#009E73", "#F0E442",
            "#0072B2", "#D55E00", "#CC79A7",
        };
    }
}

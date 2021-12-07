#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    class Aurora : HexColourset, IColourset
    {
        public override string[] hexColours => new string[]
        {
            "#BF616A", "#D08770", "#EBCB8B", "#A3BE8C", "#B48EAD",
        };
    }
}
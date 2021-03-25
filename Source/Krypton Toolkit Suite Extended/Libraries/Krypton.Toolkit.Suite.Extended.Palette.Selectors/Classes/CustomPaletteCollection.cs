#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections;

namespace Krypton.Toolkit.Suite.Extended.Palette.Selectors
{
    public class CustomPaletteCollection : CollectionBase
    {
        public CustomPalette this[int index]
        {
            get { return (CustomPalette)List[index]; }
        }

        public void Add(CustomPalette palette)
        {
            List.Add(palette);
        }

        public void Remove(CustomPalette palette)
        {
            List.Remove(palette);
        }
    }
}
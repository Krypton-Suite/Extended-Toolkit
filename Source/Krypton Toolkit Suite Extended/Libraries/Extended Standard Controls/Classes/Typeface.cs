#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Standard.Controls
{
    internal class Typeface
    {
        public static Color DefaultColour() => Color.Empty;

        public static Font DefaultTypeface() => new Font("Microsoft Sans Serif", 8.25F);
    }
}
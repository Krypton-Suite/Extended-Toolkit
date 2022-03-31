#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class Typeface
    {
        public Typeface()
        {

        }


        /// <summary>Gets the default typeface.</summary>
        /// <returns>Microsoft Sans Serif, 8.25</returns>
        public static Font GetDefaultTypeface() => new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
    }
}
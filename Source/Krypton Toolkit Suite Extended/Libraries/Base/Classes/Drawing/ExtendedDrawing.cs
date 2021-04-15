#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class ExtendedDrawing
    {
        #region Constructor
        public ExtendedDrawing()
        {

        }
        #endregion

        #region Methods
        public Rectangle GetUpperLeft(int value) => new Rectangle(0, 0, value, value);

        //public Rectangle GetUpperRight(int value)=>new Rectangle(Wid)
        #endregion
    }
}
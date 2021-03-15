#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class TypefaceChangedEventArgs : EventArgs
    {
        #region Variable
        private Font _typeface;
        #endregion

        #region Property
        public Font Typeface { get => _typeface; set => _typeface = value; }
        #endregion

        #region Constructor
        public TypefaceChangedEventArgs(Font typeface) => Typeface = typeface;
        #endregion
    }
}
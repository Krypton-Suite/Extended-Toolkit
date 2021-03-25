#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    public class ColourChangedEventArgs : EventArgs
    {
        #region Variables
        private Color _colour;
        #endregion

        #region Property
        public Color Colour { get => _colour; set => _colour = value; }
        #endregion

        #region Constructor
        public ColourChangedEventArgs(Color colour)
        {
            Colour = colour;
        }
        #endregion
    }
}
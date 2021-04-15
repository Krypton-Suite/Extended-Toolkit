#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Palette.Controls
{
    public class ColourValueChangedEventArgs : EventArgs
    {
        private Color _colour;

        public Color Colour { get => _colour; set => _colour = value; }

        public ColourValueChangedEventArgs(Color colour)
        {
            Colour = colour;
        }
    }
}
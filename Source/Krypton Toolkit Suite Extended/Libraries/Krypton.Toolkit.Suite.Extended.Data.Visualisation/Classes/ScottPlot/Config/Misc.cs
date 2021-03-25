﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class Misc
    {
        // drawing options
        public bool antiAliasData = true;
        public bool antiAliasFigure = true;

        // string formats (position indicates where their origin is)
        public StringFormat sfEast = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Far };
        public StringFormat sfNorth = new StringFormat() { LineAlignment = StringAlignment.Near, Alignment = StringAlignment.Center };
        public StringFormat sfNorthWest = new StringFormat() { LineAlignment = StringAlignment.Near, Alignment = StringAlignment.Near };
        public StringFormat sfNorthEast = new StringFormat() { LineAlignment = StringAlignment.Near, Alignment = StringAlignment.Far };
        public StringFormat sfSouth = new StringFormat() { LineAlignment = StringAlignment.Far, Alignment = StringAlignment.Center };
        public StringFormat sfSouthWest = new StringFormat() { LineAlignment = StringAlignment.Far, Alignment = StringAlignment.Near };
        public StringFormat sfSouthEast = new StringFormat() { LineAlignment = StringAlignment.Far, Alignment = StringAlignment.Far };
        public StringFormat sfWest = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near };
        public StringFormat sfCenterCenter = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
    }
}
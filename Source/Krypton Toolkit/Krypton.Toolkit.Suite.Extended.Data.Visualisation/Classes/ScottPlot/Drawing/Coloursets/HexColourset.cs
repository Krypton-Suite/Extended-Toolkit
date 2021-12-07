#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public abstract class HexColourset : IColourset
    {
        public (byte r, byte g, byte b) GetRGB(int index)
        {
            index %= hexColours.Length;

            string hexColour = hexColours[index];
            if (!hexColour.StartsWith("#"))
                hexColour = "#" + hexColour;

            if (hexColour.Length != 7)
                throw new InvalidOperationException("invalid hex color string");

            Color colour = ColorTranslator.FromHtml(hexColour);

            return (colour.R, colour.G, colour.B);
        }

        public int Count() => hexColours.Length;

        public abstract string[] hexColours { get; }
    }
}
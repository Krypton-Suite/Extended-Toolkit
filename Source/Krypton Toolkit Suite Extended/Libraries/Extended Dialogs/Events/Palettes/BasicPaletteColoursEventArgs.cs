#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class BasicPaletteColoursEventArgs : EventArgs
    {
        #region Variables
        public Color BaseColour { get; set; }

        public Color DarkestColour { get; set; }

        public Color MiddleColour { get; set; }

        public Color LightColour { get; set; }

        public Color LightestColour { get; set; }
        #endregion

        public BasicPaletteColoursEventArgs(Color baseColour, Color darkestColour, Color middleColour, Color lightColour, Color lightestColour)
        {
            BaseColour = baseColour;

            DarkestColour = darkestColour;

            MiddleColour = middleColour;

            LightColour = lightColour;

            LightestColour = lightestColour;
        }
    }
}
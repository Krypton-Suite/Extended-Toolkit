#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public interface IColourPalette
    {
        Color BaseColour { get; set; }

        Color DarkestColour { get; set; }

        Color LightColour { get; set; }

        Color LightestColour { get; set; }

        Color BorderColour { get; set; }

        Color AlternativeNormalTextColour { get; set; }

        Color DisabledTextColour { get; set; }

        Color NormalTextColour { get; set; }

        Color FocusedTextColour { get; set; }

        Color PressedTextColour { get; set; }

        Color RibbonTabTextColour { get; set; }

        Color DisabledControlColour { get; set; }

        Color LinkDisabledColour { get; set; }

        Color LinkFocusedColour { get; set; }

        Color LinkNormalColour { get; set; }

        Color LinkHoverColour { get; set; }

        Color LinkVisitedColour { get; set; }

        Color MenuTextColour { get; set; }

        Color StatusStripTextColour { get; set; }

        Color CustomColourOne { get; set; }

        Color CustomColourTwo { get; set; }

        Color CustomColourThree { get; set; }

        Color CustomColourFour { get; set; }

        Color CustomColourFive { get; set; }

        Color CustomTextColourOne { get; set; }

        Color CustomTextColourTwo { get; set; }

        Color CustomTextColourThree { get; set; }

        Color CustomTextColourFour { get; set; }

        Color CustomTextColourFive { get; set; }
    }
}
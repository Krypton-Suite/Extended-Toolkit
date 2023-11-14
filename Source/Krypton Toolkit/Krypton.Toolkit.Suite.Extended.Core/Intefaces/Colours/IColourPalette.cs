#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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
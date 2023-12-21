#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public static class InstalledFont
    {
        public static string Default() => Sans();

        public static string Serif() =>
            ValidFontName(new string[] { "Times New Roman", "DejaVu Serif", "Times" });

        public static string Sans() =>
            ValidFontName(new string[] { "Segoe UI", "DejaVu Sans", "Helvetica" });

        public static string Monospace() =>
            ValidFontName(new string[] { "Consolas", "DejaVu Sans Mono", "Courier" });

        /// <summary>
        /// Returns a font name guaranteed to be installed on the system
        /// </summary>
        public static string ValidFontName(string fontName)
        {
            foreach (FontFamily installedFont in FontFamily.Families)
            {
                if (string.Equals(installedFont.Name, fontName, StringComparison.OrdinalIgnoreCase))
                {
                    return installedFont.Name;
                }
            }

            return SystemFonts.DefaultFont.Name;
        }

        /// <summary>
        /// Returns a font name guaranteed to be installed on the system
        /// </summary>
        public static string ValidFontName(string[] fontNames)
        {
            foreach (string preferredFont in fontNames)
            {
                foreach (FontFamily font in FontFamily.Families)
                {
                    if (string.Equals(preferredFont, font.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        return font.Name;
                    }
                }
            }

            return SystemFonts.DefaultFont.Name;
        }
    }
}

/*
 
These fonts are on Azure Pipelines on Linux:
    Century Schoolbook L
    DejaVu Sans
    DejaVu Sans Mono
    DejaVu Serif
    Dingbats
    Liberation Mono
    Liberation Sans
    Liberation Sans Narrow
    Liberation Serif
    Nimbus Mono L
    Nimbus Roman No9 L
    Nimbus Sans L
    Standard Symbols L
    URW Bookman L
    URW Chancery L
    URW Gothic L
    URW Palladio L



These fonts are on Azure Pipelines on MacOS:
    Apple Braille
    Apple Color Emoji
    Apple SD Gothic Neo
    Apple Symbols
    Arial Hebrew
    Arial Hebrew Scholar
    Avenir
    Avenir Next
    Avenir Next Condensed
    Courier
    Geeza Pro
    Geneva
    Heiti SC
    Heiti TC
    Helvetica
    Helvetica Neue
    Hiragino Kaku Gothic Pro
    Hiragino Kaku Gothic ProN
    Hiragino Kaku Gothic Std
    Hiragino Kaku Gothic StdN
    Hiragino Maru Gothic Pro
    Hiragino Maru Gothic ProN
    Hiragino Mincho Pro
    Hiragino Mincho ProN
    Hiragino Sans
    Hiragino Sans GB
    Kohinoor Bangla
    Kohinoor Devanagari
    Kohinoor Telugu
    Lucida Grande
    Marker Felt
    Menlo
    Monaco
    Noteworthy
    Noto Nastaliq Urdu
    Optima
    Palatino
    PingFang HK
    PingFang SC
    PingFang TC
    Symbol
    System Font
    Thonburi
    Times
    Zapf Dingbats
    System Font
    .Apple Color Emoji UI
    .Apple SD Gothic NeoI
    .Aqua Kana
    .Aqua Kana
    .Arabic UI Display
    .Arabic UI Text
    .Arial Hebrew Desk Interface
    .Geeza Pro Interface
    .Geeza Pro PUA
    .Helvetica LT MM
    .Helvetica Neue DeskInterface
    .Hiragino Kaku Gothic Interface
    .Hiragino Sans GB Interface
    .Keyboard
    .LastResort
    .Lucida Grande UI
    .Noto Nastaliq Urdu UI
    .PingFang HK
    .PingFang SC
    .PingFang TC
    .SF Compact Display
    .SF Compact Rounded
    .SF Compact Text
    .SF NS Display Condensed
    .SF NS Rounded
    .SF NS Symbols
    .SF NS Text Condensed
    .Times LT MM

*/

#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core;

public static class TypefaceHelper
{
    #region Methods
    public static void InitialiseTypefaceFamilies(KryptonComboBox typefaceSelection)
    {
        foreach (FontFamily fontFamily in FontFamily.Families)
        {
            typefaceSelection.Items.Add(fontFamily.Name);
        }
    }

    public static void InitialiseTypefaceStyles(KryptonListBox typefaceStyleSelection)
    {
        foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
        {
            typefaceStyleSelection.Items.Add(style.ToString());
        }
    }

    public static Font DefaultTypeface() => new("Microsoft Sans Serif", 8.25f, FontStyle.Regular);

    public static void UpdateTypefaceStyles()
    {

    }
    #endregion
}
#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
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

        public static Font DefaultTypeface() => new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);

        public static void UpdateTypefaceStyles()
        {

        }
        #endregion
    }
}
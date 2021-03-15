#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    internal static partial class NativeMethods
    {
        [DllImport(UXTHEME, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GetThemeFont(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, int iPropId, out LOGFONT pFont);

        [DllImport(UXTHEME, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GetThemeSysFont(SafeThemeHandle hTheme, int iFontId, out LOGFONT pFont);
    }
}
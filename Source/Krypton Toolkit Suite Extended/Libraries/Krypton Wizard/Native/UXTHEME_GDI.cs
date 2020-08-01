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
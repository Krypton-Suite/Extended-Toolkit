#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
        #region Constants

        private const string GDI32_DLL = "gdi32.dll";

        #endregion

        /* Deletes a logical pen, brush, font, bitmap, region, or palette, 
       freeing all system resources associated with the object. After the 
       object has been deleted, the specified handle is no longer valid. */
        [DllImport(GDI32_DLL, CharSet = CharSet.Auto, ExactSpelling = false)]
        internal static extern bool DeleteObject(HandleRef hObject);

        /* Selects an object into the specified device context (DC). 
        The new object replaces the previous object of the same type. */
        [DllImport(GDI32_DLL, CharSet = CharSet.Auto, ExactSpelling = false)]
        internal static extern IntPtr SelectObject(HandleRef hDC, HandleRef hObject);

        /* Fills the specified buffer with the metrics for the currently selected font. */
        internal static int GetTextMetrics(HandleRef hDC, ref NativeMethods.TEXTMETRIC lptm)
        {
            if (Marshal.SystemDefaultCharSize != 1)
            {
                // Handle Unicode
                return SafeNativeMethods.GetTextMetricsW(hDC, out lptm);
            }

            // Handle ANSI; call GetTextMetricsA and translate to Unicode struct
            NativeMethods.TEXTMETRICA tEXTMETRICA = new NativeMethods.TEXTMETRICA();
            int result = SafeNativeMethods.GetTextMetricsA(hDC, out tEXTMETRICA);

            lptm.tmHeight = tEXTMETRICA.tmHeight;
            lptm.tmAscent = tEXTMETRICA.tmAscent;
            lptm.tmDescent = tEXTMETRICA.tmDescent;
            lptm.tmInternalLeading = tEXTMETRICA.tmInternalLeading;
            lptm.tmExternalLeading = tEXTMETRICA.tmExternalLeading;
            lptm.tmAveCharWidth = tEXTMETRICA.tmAveCharWidth;
            lptm.tmMaxCharWidth = tEXTMETRICA.tmMaxCharWidth;
            lptm.tmWeight = tEXTMETRICA.tmWeight;
            lptm.tmOverhang = tEXTMETRICA.tmOverhang;
            lptm.tmDigitizedAspectX = tEXTMETRICA.tmDigitizedAspectX;
            lptm.tmDigitizedAspectY = tEXTMETRICA.tmDigitizedAspectY;
            lptm.tmFirstChar = Convert.ToChar(tEXTMETRICA.tmFirstChar);
            lptm.tmLastChar = Convert.ToChar(tEXTMETRICA.tmLastChar);
            lptm.tmDefaultChar = Convert.ToChar(tEXTMETRICA.tmDefaultChar);
            lptm.tmBreakChar = Convert.ToChar(tEXTMETRICA.tmBreakChar);
            lptm.tmItalic = tEXTMETRICA.tmItalic;
            lptm.tmUnderlined = tEXTMETRICA.tmUnderlined;
            lptm.tmStruckOut = tEXTMETRICA.tmStruckOut;
            lptm.tmPitchAndFamily = tEXTMETRICA.tmPitchAndFamily;
            lptm.tmCharSet = tEXTMETRICA.tmCharSet;

            return result;
        }

        /* Fills the specified buffer with the metrics for the currently 
        selected font. This is the Ansi version of the function */
        [DllImport(GDI32_DLL, CharSet = CharSet.Ansi, ExactSpelling = false)]
        private static extern int GetTextMetricsA(HandleRef hDC, out NativeMethods.TEXTMETRICA lptm);

        /* Fills the specified buffer with the metrics for the currently 
        selected font. This is the Unicode version of the function.*/
        [DllImport(GDI32_DLL, CharSet = CharSet.Unicode, ExactSpelling = false)]
        private static extern int GetTextMetricsW(HandleRef hDC, out NativeMethods.TEXTMETRIC lptm);
    }
}
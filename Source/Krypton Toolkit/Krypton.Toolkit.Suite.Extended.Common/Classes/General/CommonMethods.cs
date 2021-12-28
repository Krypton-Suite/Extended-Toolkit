#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    /// Provides some methods from the user32 and uxtheme libraries.
    /// Modified from the AeroSuite project.
    /// </summary>
    public static class CommonNativeMethods
    {
        private const string user32 = "user32.dll";
        private const string uxtheme = "uxtheme.dll";
        private const string dwmapi = "dwmapi.dll";

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns></returns>
        [DllImport(user32, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns></returns>
        [DllImport(user32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, string lParam);

        /// <summary>
        /// Loads the cursor.
        /// </summary>
        /// <param name="hInstance">The h instance.</param>
        /// <param name="lpCursorName">Name of the lp cursor.</param>
        /// <returns></returns>
        [DllImport(user32, SetLastError = true)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        /// <summary>
        /// Sets the cursor.
        /// </summary>
        /// <param name="hCursor">The h cursor.</param>
        /// <returns></returns>
        [DllImport(user32, SetLastError = true)]
        public static extern IntPtr SetCursor(IntPtr hCursor);

        /// <summary>
        /// Loads the image.
        /// </summary>
        /// <param name="hinst">The hinst.</param>
        /// <param name="lpszName">Name of the LPSZ.</param>
        /// <param name="uType">Type of the u.</param>
        /// <param name="cxDesired">The cx desired.</param>
        /// <param name="cyDesired">The cy desired.</param>
        /// <param name="fuLoad">The fu load.</param>
        /// <returns></returns>
        [DllImport(user32, SetLastError = true)]
        public static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);

        /// <summary>
        /// Sets the window position.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hWndInsertAfter">The h WND insert after.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        /// <param name="uFlags">The u flags.</param>
        /// <returns></returns>
        [DllImport(user32, SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        /// <summary>
        /// Sets the window long32.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <param name="dwNewLong">The dw new long.</param>
        /// <returns></returns>
        [DllImport(user32, EntryPoint = "SetWindowLong", SetLastError = true)]
        public static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);

        /// <summary>
        /// Sets the window long PTR64.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nIndex">Index of the n.</param>
        /// <param name="dwNewLong">The dw new long.</param>
        /// <returns></returns>
        [DllImport(user32, EntryPoint = "SetWindowLongPtr", SetLastError = true)]
        public static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);


        /// <summary>
        /// Sets the window theme.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="pszSubAppName">Name of the PSZ sub application.</param>
        /// <param name="pszSubIdList">The PSZ sub identifier list.</param>
        /// <returns></returns>
        [DllImport(uxtheme, CharSet = CharSet.Unicode, SetLastError = true)]
        public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);



        //[DllImport(dwmapi, SetLastError = true)]
        //public static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref AeroSuite.Forms.BorderlessForm.Margins margins);

        /// <summary>
        /// DWMs the is composition enabled.
        /// </summary>
        /// <returns></returns>
        [DllImport(dwmapi, PreserveSig = false, SetLastError = true)]
        public static extern bool DwmIsCompositionEnabled();
    }
}
#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    internal class DrawingUtilitiesNativeMethods
    {
        #region Constants

        public const int R2_NOT = 6; // Inverted drawing mode

        #endregion

        #region Public Class Members

        [DllImport("user32.dll", EntryPoint = "GetDC", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll", EntryPoint = "LineTo", CallingConvention = CallingConvention.StdCall)]
        public static extern bool LineTo(IntPtr hdc, int x, int y);

        [DllImport("gdi32.dll", EntryPoint = "MoveToEx", CallingConvention = CallingConvention.StdCall)]
        public static extern bool MoveToEx(IntPtr hdc, int x, int y, IntPtr lpPoint);

        [DllImport("user32.dll", EntryPoint = "ReleaseDC", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", EntryPoint = "SetROP2", CallingConvention = CallingConvention.StdCall)]
        public static extern int SetROP2(IntPtr hdc, int fnDrawMode);

        #endregion

        [DllImport(_gdi32DllName)]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        private const string _gdi32DllName = "gdi32.dll";

        private const string _user32DllName = "user32.dll";

        /// <summary>
        ///   Logical pixels inch in X
        /// </summary>
        public const int LOGPIXELSX = 88;

        /// <summary>
        ///   Logical pixels inch in Y
        /// </summary>
        public const int LOGPIXELSY = 90;

        public static Point GetDesktopDpi()
        {
            IntPtr hWnd;
            IntPtr hDC;
            int dpix;
            int dpiy;

            hWnd = GetDesktopWindow();
            hDC = GetDC(hWnd);

            try
            {
                dpix = GetDeviceCaps(hDC, LOGPIXELSX);
                dpiy = GetDeviceCaps(hDC, LOGPIXELSY);
            }
            finally
            {
                ReleaseDC(hWnd, hDC);
            }

            return new Point(dpix, dpiy);
        }

        [DllImport(_user32DllName)]
        public static extern IntPtr GetDesktopWindow();
    }
}
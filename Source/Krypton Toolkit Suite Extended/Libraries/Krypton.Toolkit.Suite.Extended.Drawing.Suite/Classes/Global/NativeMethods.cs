﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite.Internal
{
    internal class NativeMethods
    {
        #region Constants

        public const int R2_NOT = 6; // Inverted drawing mode

        #endregion

        #region Protected Constructors

        protected NativeMethods()
        {
        }

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
#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    internal static class NativeMethods
    {
        public const int AW_HIDE = 0X10000;
        public const int AW_ACTIVATE = 0X20000;
        public const int AW_HOR_POSITIVE = 0X1;
        public const int AW_HOR_NEGATIVE = 0X2;
        public const int AW_SLIDE = 0X40000;
        public const int AW_BLEND = 0X80000;

        public const int MA_NOACTIVATE = 0x0003;

        public const int WS_EX_NOACTIVATE = 0x08000000;
        public const int WS_EX_TOOLWINDOW = 0x00000080;

        public const int WM_ACTIVATE = 0x0006;
        public const int WM_ACTIVATEAPP = 0x001C;
        public const int WM_GETMINMAXINFO = 0x0024;
        public const int WM_NCHITTEST = 0x0084;
        public const int WM_NCACTIVATE = 0x0086;

        public const int WM_MOUSEACTIVATE = 0x0021;

        public const int WM_PAINT = 0x0F;
        public const int WM_CAPTURECHANGED = 0x215;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_MBUTTONDOWN = 0x207;
        public const int WM_NCLBUTTONDOWN = 0x0A1;
        public const int WM_NCRBUTTONDOWN = 0x0A4;
        public const int WM_NCMBUTTONDOWN = 0x0A7;

        public const int KEYEVENTF_KEYUP = 0x0002;

        public const int HTTRANSPARENT = -1;
        public const int HTLEFT = 10;
        public const int HTRIGHT = 11;
        public const int HTTOP = 12;
        public const int HTTOPLEFT = 13;
        public const int HTTOPRIGHT = 14;
        public const int HTBOTTOM = 15;
        public const int HTBOTTOMLEFT = 16;
        public const int HTBOTTOMRIGHT = 17;
        public const int CS_DROPSHADOW = 0x20000;

        public enum SHOWWINDOW : uint
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11,
            SW_MAX = 11,
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int AnimateWindow(IntPtr hwand, int dwTime, int dwFlags);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int SendMessage(IntPtr handle, int msg, int wParam, IntPtr lParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int PostMessage(IntPtr handle, int msg, int wParam, IntPtr lParam);

        [DllImport("user32")]
        public extern static void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public static int HiWord(int n)
        {
            return (n >> 16) & 0xffff;
        }

        public static int HiWord(IntPtr n)
        {
            return HiWord(unchecked((int)(long)n));
        }

        public static int LoWord(int n)
        {
            return n & 0xffff;
        }

        public static int LoWord(IntPtr n)
        {
            return LoWord(unchecked((int)(long)n));
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public Point reserved;
            public Size maxSize;
            public Point maxPosition;
            public Size minTrackSize;
            public Size maxTrackSize;
        }
    }
}
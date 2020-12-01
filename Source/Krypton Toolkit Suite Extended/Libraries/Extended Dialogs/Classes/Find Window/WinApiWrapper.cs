using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class Window
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public Rectangle ToRectangle()
            {
                return new Rectangle(Left, Top, Right - Left, Bottom - Top);
            }
        }

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point point);

        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr handle, ref Point point);

        [DllImport("user32.dll")]
        public static extern IntPtr ChildWindowFromPointEx(IntPtr hWndParent, Point pt, uint uFlags);

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hwnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        public static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);

        public enum GetWindow_Cmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern Int32 ReleaseDC(IntPtr hWnd, IntPtr hdc);

        public Window()
        {
        }

        // helper function return directly a Rectangle object
        public static Rectangle GetWindowRect(IntPtr hWnd)
        {
            Debug.Assert(hWnd != IntPtr.Zero);
            RECT rect = new RECT();
            if (GetWindowRect(hWnd, ref rect) == false)
                throw new Exception("GetWindowRect failed");
            return rect.ToRectangle();
        }

        public static string GetWindowText(IntPtr hWnd)
        {
            Debug.Assert(hWnd != IntPtr.Zero);
            StringBuilder WindowText = new StringBuilder(GetWindowTextLength(hWnd) + 1);
            GetWindowText(hWnd, WindowText, WindowText.Capacity);
            return WindowText.ToString();
        }
    }
}
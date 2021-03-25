using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Task.Dialogs.UI
{
    internal static class WindowSubclassHandlerNativeMethods
    {
        public const int GWLP_WNDPROC = -4;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate IntPtr WindowProc(
                IntPtr hWnd,
                int msg,
                IntPtr wParam,
                IntPtr lParam);

        [DllImport("kernel32",
                   EntryPoint = "SetLastError",
                   ExactSpelling = true)]
        public static extern void SetLastError(int dwErrCode);

        [DllImport("user32",
                EntryPoint = "CallWindowProcW",
                ExactSpelling = true)]
        public static extern IntPtr CallWindowProc(
                IntPtr lpPrevWndFunc,
                IntPtr hWnd,
                int msg,
                IntPtr wParam,
                IntPtr lParam);

        public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 4)
                return (IntPtr)GetWindowLong32(hWnd, nIndex);

            return GetWindowLongPtr64(hWnd, nIndex);
        }

        public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 4)
                return (IntPtr)SetWindowLong32(hWnd, nIndex, (int)dwNewLong);

            return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }

        [DllImport("user32",
                EntryPoint = "GetWindowLongW",
                ExactSpelling = true,
                SetLastError = true)]
        private static extern int GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32",
                EntryPoint = "GetWindowLongPtrW",
                ExactSpelling = true,
                SetLastError = true)]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        [DllImport("user32",
                EntryPoint = "SetWindowLongW",
                ExactSpelling = true,
                SetLastError = true)]
        private static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32",
                EntryPoint = "SetWindowLongPtrW",
                ExactSpelling = true,
                SetLastError = true)]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
    }
}
namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    internal class PlatformEvents
    {
        [DllImport(Win32Libraries.User32)]
        internal static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

        [DllImport(Win32Libraries.User32)]
        internal static extern int MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport(Win32Libraries.User32)]
        public static extern UIntPtr SetTimer(IntPtr hWnd, UIntPtr nIDEvent, uint uElapse, PlatformInvoke.TimerProc lpTimerFunc);

        [DllImport(Win32Libraries.User32)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport(Win32Libraries.User32)]
        public static extern IntPtr SetWindowsHookEx(int idHook, PlatformInvoke.HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport(Win32Libraries.User32)]
        public static extern int UnhookWindowsHookEx(IntPtr idHook);

        [DllImport(Win32Libraries.User32)]
        public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport(Win32Libraries.User32)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport(Win32Libraries.User32)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxLength);

        [DllImport(Win32Libraries.User32)]
        public static extern int EndDialog(IntPtr hDlg, IntPtr nResult);

        [DllImport(Win32Libraries.User32, SetLastError = true)]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    }
}
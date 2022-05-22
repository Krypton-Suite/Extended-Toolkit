#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Runtime.InteropServices;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    internal class PI
    {
        #region Constants
        internal const uint WS_POPUP = 0x80000000;
        internal const uint WS_MINIMIZE = 0x20000000;
        internal const uint WS_MAXIMIZE = 0x01000000;
        internal const uint WS_VISIBLE = 0x10000000;
        internal const uint WS_BORDER = 0x00800000;
        internal const int PRF_CLIENT = 0x00000004;
        internal const int WS_EX_TOPMOST = 0x00000008;
        internal const int WS_EX_TOOLWINDOW = 0x00000080;
        internal const int WS_EX_LAYERED = 0x00080000;
        internal const int WS_EX_CLIENTEDGE = 0x00000200;
        internal const int SC_MINIMIZE = 0xF020;
        internal const int SC_MAXIMIZE = 0xF030;
        internal const int SC_CLOSE = 0xF060;
        internal const int SC_RESTORE = 0xF120;
        internal const int SW_SHOWNOACTIVATE = 4;
        internal const int WM_DESTROY = 0x0002;
        internal const int WM_NCDESTROY = 0x0082;
        internal const int WM_MOVE = 0x0003;
        internal const int WM_SETFOCUS = 0x0007;
        internal const int WM_KILLFOCUS = 0x0008;
        internal const int WM_SETREDRAW = 0x000B;
        internal const int WM_SETTEXT = 0x000C;
        internal const int WM_PAINT = 0x000F;
        internal const int WM_PRINTCLIENT = 0x0318;
        internal const int WM_CTLCOLOR = 0x0019;
        internal const int WM_ERASEBKGND = 0x0014;
        internal const int WM_MOUSEACTIVATE = 0x0021;
        internal const int WM_WINDOWPOSCHANGING = 0x0046;
        internal const int WM_WINDOWPOSCHANGED = 0x0047;
        internal const int WM_HELP = 0x0053;
        internal const int WM_NCCALCSIZE = 0x0083;
        internal const int WM_NCHITTEST = 0x0084;
        internal const int WM_NCPAINT = 0x0085;
        internal const int WM_NCACTIVATE = 0x0086;
        internal const int WM_NCMOUSEMOVE = 0x00A0;
        internal const int WM_NCLBUTTONDOWN = 0x00A1;
        internal const int WM_NCLBUTTONUP = 0x00A2;
        internal const int WM_NCLBUTTONDBLCLK = 0x00A3;
        internal const int WM_NCRBUTTONDOWN = 0x00A4;
        internal const int WM_NCMBUTTONDOWN = 0x00A7;
        internal const int WM_NCMBUTTONDBLCLK = 0x00A9;
        internal const int WM_SETCURSOR = 0x0020;
        internal const int WM_KEYDOWN = 0x0100;
        internal const int WM_KEYUP = 0x0101;
        internal const int WM_CHAR = 0x0102;
        internal const int WM_DEADCHAR = 0x0103;
        internal const int WM_SYSKEYDOWN = 0x0104;
        internal const int WM_SYSKEYUP = 0x0105;
        internal const int WM_SYSCHAR = 0x0106;
        internal const int WM_SYSDEADCHAR = 0x0107;
        internal const int WM_KEYLAST = 0x0108;
        internal const int WM_SYSCOMMAND = 0x0112;
        internal const int WM_HSCROLL = 0x0114;
        internal const int WM_VSCROLL = 0x0115;
        internal const int WM_INITMENU = 0x0116;
        internal const int WM_CTLCOLOREDIT = 0x0133;
        internal const int WM_MOUSEMOVE = 0x0200;
        internal const int WM_LBUTTONDOWN = 0x0201;
        internal const int WM_LBUTTONUP = 0x0202;
        internal const int WM_LBUTTONDBLCLK = 0x0203;
        internal const int WM_RBUTTONDOWN = 0x0204;
        internal const int WM_RBUTTONUP = 0x0205;
        internal const int WM_MBUTTONDOWN = 0x0207;
        internal const int WM_MBUTTONUP = 0x0208;
        internal const int WM_MOUSEWHEEL = 0x020A;
        internal const int WM_NCMOUSELEAVE = 0x02A2;
        internal const int WM_MOUSELEAVE = 0x02A3;
        internal const int WM_PRINT = 0x0317;
        internal const int WM_CONTEXTMENU = 0x007B;
        internal const int MA_NOACTIVATE = 0x03;
        internal const int EM_FORMATRANGE = 0x0439;
        internal const int SWP_NOSIZE = 0x0001;
        internal const int SWP_NOMOVE = 0x0002;
        internal const int SWP_NOZORDER = 0x0004;
        internal const int SWP_NOACTIVATE = 0x0010;
        internal const int SWP_FRAMECHANGED = 0x0020;
        internal const int SWP_NOOWNERZORDER = 0x0200;
        internal const int SWP_SHOWWINDOW = 0x0040;
        internal const int SWP_HIDEWINDOW = 0x0080;
        internal const int RDW_INVALIDATE = 0x0001;
        internal const int RDW_UPDATENOW = 0x0100;
        internal const int RDW_FRAME = 0x0400;
        internal const int DCX_WINDOW = 0x01;
        internal const int DCX_CACHE = 0x02;
        internal const int DCX_CLIPSIBLINGS = 0x10;
        internal const int DCX_INTERSECTRGN = 0x80;
        internal const int TME_LEAVE = 0x0002;
        internal const int TME_NONCLIENT = 0x0010;
        internal const int HTNOWHERE = 0x00;
        internal const int HTCLIENT = 0x01;
        internal const int HTCAPTION = 0x02;
        internal const int HTSYSMENU = 0x03;
        internal const int HTGROWBOX = 0x04;
        internal const int HTSIZE = 0x04;
        internal const int HTMENU = 0x05;
        internal const int HTLEFT = 0x0A;
        internal const int HTRIGHT = 0x0B;
        internal const int HTTOP = 0x0C;
        internal const int HTTOPLEFT = 0x0D;
        internal const int HTTOPRIGHT = 0x0E;
        internal const int HTBOTTOM = 0x0F;
        internal const int HTBOTTOMLEFT = 0x10;
        internal const int HTBOTTOMRIGHT = 0x11;
        internal const int HTBORDER = 0x12;
        internal const int HTHELP = 0x15;
        internal const int HTIGNORE = 0xFF;
        internal const int HTTRANSPARENT = -1;
        internal const int ULW_ALPHA = 0x00000002;
        internal const int DEVICE_BITSPIXEL = 12;
        internal const int DEVICE_PLANES = 14;
        internal const int SRCCOPY = 0xCC0020;
        internal const int GWL_STYLE = -16;
        internal const int DTM_SETMCCOLOR = 0x1006;
        internal const int DTT_COMPOSITED = 8192;
        internal const int DTT_GLOWSIZE = 2048;
        internal const int DTT_TEXTCOLOR = 1;
        internal const int MCSC_BACKGROUND = 0;
        internal const int PLANES = 14;
        internal const int BITSPIXEL = 12;
        internal const byte AC_SRC_OVER = 0x00;
        internal const byte AC_SRC_ALPHA = 0x01;
        internal const uint GW_HWNDFIRST = 0;
        internal const uint GW_HWNDLAST = 1;
        internal const uint GW_HWNDNEXT = 2;
        internal const uint GW_HWNDPREV = 3;
        internal const uint GW_OWNER = 4;
        internal const uint GW_CHILD = 5;
        internal const uint GW_ENABLEDPOPUP = 6;
        internal const int WM_GETMINMAXINFO = 0x0024;
        #endregion

        #region Static Methods
        internal static int LOWORD(IntPtr value)
        {
            int int32 = ((int)value.ToInt64() & 0xFFFF);
            return (int32 > 32767) ? int32 - 65536 : int32;
        }

        internal static int HIWORD(IntPtr value)
        {
            int int32 = (((int)value.ToInt64() >> 0x10) & 0xFFFF);
            return (int32 > 32767) ? int32 - 65536 : int32;
        }

        internal static int LOWORD(int value)
        {
            return (value & 0xFFFF);
        }

        internal static int HIWORD(int value)
        {
            return ((value >> 0x10) & 0xFFFF);
        }

        internal static int MAKELOWORD(int value)
        {
            return (value & 0xFFFF);
        }

        internal static int MAKEHIWORD(int value)
        {
            return ((value & 0xFFFF) << 0x10);
        }
        #endregion

        #region Static User32
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern short VkKeyScan(char ch);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr WindowFromPoint(POINT pt);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern uint SetWindowLong(IntPtr hwnd, int nIndex, int nLong);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int ShowWindow(IntPtr hWnd, short cmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern ushort GetKeyState(int virtKey);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern uint SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int X, int Y, int Width, int Height, uint flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern bool RedrawWindow(IntPtr hWnd, IntPtr rectUpdate, IntPtr hRgnUpdate, uint uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern bool RedrawWindow(IntPtr hWnd, ref RECT rectUpdate, IntPtr hRgnUpdate, uint uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern bool TrackMouseEvent(ref TRACKMOUSEEVENTS tme);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hRgnClip, uint fdwOptions);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern void DisableProcessWindowsGhosting();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern void AdjustWindowRectEx(ref RECT rect, int dwStyle, bool hasMenu, int dwExSytle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, [In, Out] POINTC pt, int cPoints);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr BeginPaint(IntPtr hwnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern bool EndPaint(IntPtr hwnd, ref PAINTSTRUCT ps);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern bool InflateRect(ref RECT lprc, int dx, int dy);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern uint RegisterWindowMessage(string lpString);

        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

        [DllImport("user32.dll")]
        internal static extern int GetSystemMetrics(SystemMetric smIndex);
        #endregion

        #region Static Gdi32
        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        internal static extern int BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        internal static extern int ExcludeClipRect(IntPtr hDC, int x1, int y1, int x2, int y2);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        internal static extern int IntersectClipRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr CreateDIBSection(IntPtr hDC, BITMAPINFO pBMI, uint iUsage, int ppvBits, IntPtr hSection, uint dwOffset);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        internal static extern bool DeleteDC(IntPtr hDC);

        [DllImport("gdi32.dll", EntryPoint = "SaveDC", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern int IntSaveDC(HandleRef hDC);

        [DllImport("gdi32.dll", EntryPoint = "RestoreDC", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern bool IntRestoreDC(HandleRef hDC, int nSavedDC);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern bool GetViewportOrgEx(HandleRef hDC, [In, Out] POINTC point);

        [DllImport("gdi32.dll", EntryPoint = "CreateRectRgn", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern IntPtr IntCreateRectRgn(int x1, int y1, int x2, int y2);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern int GetClipRgn(HandleRef hDC, HandleRef hRgn);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern bool SetViewportOrgEx(HandleRef hDC, int x, int y, [In, Out] POINTC point);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern int GetRgnBox(HandleRef hRegion, ref RECT clipRect);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern int CombineRgn(HandleRef hRgn, HandleRef hRgn1, HandleRef hRgn2, int nCombineMode);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern int SelectClipRgn(HandleRef hDC, HandleRef hRgn);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern int SelectClipRgn(IntPtr hDC, IntPtr hRgn);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern uint SetTextColor(IntPtr hdc, int crColor);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern uint SetBkColor(IntPtr hdc, int crColor);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        internal static extern IntPtr CreateSolidBrush(int crColor);
        #endregion

        #region Static DwmApi
        [DllImport("dwmapi.dll", CharSet = CharSet.Auto)]
        internal static extern void DwmIsCompositionEnabled(ref bool enabled);

        [DllImport("dwmapi.dll", CharSet = CharSet.Auto)]
        internal static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll", CharSet = CharSet.Auto)]
        internal static extern int DwmDefWindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, out IntPtr result);
        #endregion

        #region Static Ole32
        [DllImport("ole32.dll", CharSet = CharSet.Auto)]
        internal static extern void CoCreateGuid(ref GUIDSTRUCT guid);
        #endregion

        #region Static Uxtheme
        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        internal static extern bool IsAppThemed();

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        internal static extern bool IsThemeActive();

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
        internal static extern int SetWindowTheme(IntPtr hWnd, String subAppName, String subIdList);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        internal static extern int DrawThemeTextEx(IntPtr hTheme, IntPtr hDC, int iPartId, int iStateId, string text, int iCharCount, int dwFlags, ref RECT pRect, ref DTTOPTS pOptions);
        #endregion

        #region Static Kernel32
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        internal static extern short QueryPerformanceCounter(ref long var);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        internal static extern short QueryPerformanceFrequency(ref long var);
        #endregion

        #region Structures
        [StructLayout(LayoutKind.Sequential)]
        internal struct SIZE
        {
            public int cx;
            public int cy;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class POINTC
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct TRACKMOUSEEVENTS
        {
            public uint cbSize;
            public uint dwFlags;
            public IntPtr hWnd;
            public uint dwHoverTime;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct NCCALCSIZE_PARAMS
        {
            public RECT rectProposed;
            public RECT rectBeforeMove;
            public RECT rectClientBeforeMove;
            public int lpPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public uint flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct GUIDSTRUCT
        {
            public ushort Data1;
            public ushort Data2;
            public ushort Data3;
            public ushort Data4;
            public ushort Data5;
            public ushort Data6;
            public ushort Data7;
            public ushort Data8;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MSG
        {
            public IntPtr hwnd;
            public int message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public POINT pt;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct DTTOPTS
        {
            public int dwSize;
            public int dwFlags;
            public int crText;
            public int crBorder;
            public int crShadow;
            public int iTextShadowType;
            public POINT ptShadowOffset;
            public int iBorderSize;
            public int iFontPropId;
            public int iColorPropId;
            public int iStateId;
            public bool fApplyOverlay;
            public int iGlowSize;
            public int pfnDrawTextCallback;
            public IntPtr lParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class BITMAPINFO
        {
            public int biSize;
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public int biCompression;
            public int biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public int biClrUsed;
            public int biClrImportant;
            public byte bmiColors_rgbBlue;
            public byte bmiColors_rgbGreen;
            public byte bmiColors_rgbRed;
            public byte bmiColors_rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct PAINTSTRUCT
        {
            private readonly IntPtr hdc;
            public bool fErase;
            public RECT rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct CHARRANGE
        {
            public int cpMin;
            public int cpMax;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct FORMATRANGE
        {
            public IntPtr hdc;
            public IntPtr hdcTarget;
            public RECT rc;
            public RECT rcPage;
            public CHARRANGE chrg;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }

        /// <summary>
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class MONITORINFO
        {
            /// <summary>
            /// </summary>            
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));

            /// <summary>
            /// </summary>            
            public RECT rcMonitor = new RECT();

            /// <summary>
            /// </summary>            
            public RECT rcWork = new RECT();

            /// <summary>
            /// </summary>            
            public int dwFlags = 0;
        };


        /// <summary>
        /// Flags used with the Windows API (User32.dll):GetSystemMetrics(SystemMetric smIndex)
        ///   
        /// This Enum and declaration signature was written by Gabriel T. Sharp
        /// ai_productions@verizon.net or osirisgothra@hotmail.com
        /// Obtained on pinvoke.net, please contribute your code to support the wiki!
        /// </summary>
        internal enum SystemMetric : int
        {
            /// <summary>
            /// The flags that specify how the system arranged minimized windows. For more information, see the Remarks section in this topic.
            /// </summary>
            SM_ARRANGE = 56,

            /// <summary>
            /// The value that specifies how the system is started: 
            /// 0 Normal boot
            /// 1 Fail-safe boot
            /// 2 Fail-safe with network boot
            /// A fail-safe boot (also called SafeBoot, Safe Mode, or Clean Boot) bypasses the user startup files.
            /// </summary>
            SM_CLEANBOOT = 67,

            /// <summary>
            /// The number of display monitors on a desktop. For more information, see the Remarks section in this topic.
            /// </summary>
            SM_CMONITORS = 80,

            /// <summary>
            /// The number of buttons on a mouse, or zero if no mouse is installed.
            /// </summary>
            SM_CMOUSEBUTTONS = 43,

            /// <summary>
            /// The width of a window border, in pixels. This is equivalent to the SM_CXEDGE value for windows with the 3-D look.
            /// </summary>
            SM_CXBORDER = 5,

            /// <summary>
            /// The width of a cursor, in pixels. The system cannot create cursors of other sizes.
            /// </summary>
            SM_CXCURSOR = 13,

            /// <summary>
            /// This value is the same as SM_CXFIXEDFRAME.
            /// </summary>
            SM_CXDLGFRAME = 7,

            /// <summary>
            /// The width of the rectangle around the location of a first click in a double-click sequence, in pixels. ,
            /// The second click must occur within the rectangle that is defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system
            /// to consider the two clicks a double-click. The two clicks must also occur within a specified time.
            /// To set the width of the double-click rectangle, call SystemParametersInfo with SPI_SETDOUBLECLKWIDTH.
            /// </summary>
            SM_CXDOUBLECLK = 36,

            /// <summary>
            /// The number of pixels on either side of a mouse-down point that the mouse pointer can move before a drag operation begins. 
            /// This allows the user to click and release the mouse button easily without unintentionally starting a drag operation. 
            /// If this value is negative, it is subtracted from the left of the mouse-down point and added to the right of it.
            /// </summary>
            SM_CXDRAG = 68,

            /// <summary>
            /// The width of a 3-D border, in pixels. This metric is the 3-D counterpart of SM_CXBORDER.
            /// </summary>
            SM_CXEDGE = 45,

            /// <summary>
            /// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels.
            /// SM_CXFIXEDFRAME is the height of the horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border.
            /// This value is the same as SM_CXDLGFRAME.
            /// </summary>
            SM_CXFIXEDFRAME = 7,

            /// <summary>
            /// The width of the left and right edges of the focus rectangle that the DrawFocusRectdraws. 
            /// This value is in pixels. 
            /// Windows 2000:  This value is not supported.
            /// </summary>
            SM_CXFOCUSBORDER = 83,

            /// <summary>
            /// This value is the same as SM_CXSIZEFRAME.
            /// </summary>
            SM_CXFRAME = 32,

            /// <summary>
            /// The width of the client area for a full-screen window on the primary display monitor, in pixels. 
            /// To get the coordinates of the portion of the screen that is not obscured by the system taskbar or by application desktop toolbars, 
            /// call the SystemParametersInfofunction with the SPI_GETWORKAREA value.
            /// </summary>
            SM_CXFULLSCREEN = 16,

            /// <summary>
            /// The width of the arrow bitmap on a horizontal scroll bar, in pixels.
            /// </summary>
            SM_CXHSCROLL = 21,

            /// <summary>
            /// The width of the thumb box in a horizontal scroll bar, in pixels.
            /// </summary>
            SM_CXHTHUMB = 10,

            /// <summary>
            /// The default width of an icon, in pixels. The LoadIcon function can load only icons with the dimensions 
            /// that SM_CXICON and SM_CYICON specifies.
            /// </summary>
            SM_CXICON = 11,

            /// <summary>
            /// The width of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size 
            /// SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CXICON.
            /// </summary>
            SM_CXICONSPACING = 38,

            /// <summary>
            /// The default width, in pixels, of a maximized top-level window on the primary display monitor.
            /// </summary>
            SM_CXMAXIMIZED = 61,

            /// <summary>
            /// The default maximum width of a window that has a caption and sizing borders, in pixels. 
            /// This metric refers to the entire desktop. The user cannot drag the window frame to a size larger than these dimensions. 
            /// A window can override this value by processing the WM_GETMINMAXINFO message.
            /// </summary>
            SM_CXMAXTRACK = 59,

            /// <summary>
            /// The width of the default menu check-mark bitmap, in pixels.
            /// </summary>
            SM_CXMENUCHECK = 71,

            /// <summary>
            /// The width of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.
            /// </summary>
            SM_CXMENUSIZE = 54,

            /// <summary>
            /// The minimum width of a window, in pixels.
            /// </summary>
            SM_CXMIN = 28,

            /// <summary>
            /// The width of a minimized window, in pixels.
            /// </summary>
            SM_CXMINIMIZED = 57,

            /// <summary>
            /// The width of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. 
            /// This value is always greater than or equal to SM_CXMINIMIZED.
            /// </summary>
            SM_CXMINSPACING = 47,

            /// <summary>
            /// The minimum tracking width of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. 
            /// A window can override this value by processing the WM_GETMINMAXINFO message.
            /// </summary>
            SM_CXMINTRACK = 34,

            /// <summary>
            /// The amount of border padding for captioned windows, in pixels. Windows XP/2000:  This value is not supported.
            /// </summary>
            SM_CXPADDEDBORDER = 92,

            /// <summary>
            /// The width of the screen of the primary display monitor, in pixels. This is the same value obtained by calling 
            /// GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, HORZRES).
            /// </summary>
            SM_CXSCREEN = 0,

            /// <summary>
            /// The width of a button in a window caption or title bar, in pixels.
            /// </summary>
            SM_CXSIZE = 30,

            /// <summary>
            /// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. 
            /// SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border. 
            /// This value is the same as SM_CXFRAME.
            /// </summary>
            SM_CXSIZEFRAME = 32,

            /// <summary>
            /// The recommended width of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.
            /// </summary>
            SM_CXSMICON = 49,

            /// <summary>
            /// The width of small caption buttons, in pixels.
            /// </summary>
            SM_CXSMSIZE = 52,

            /// <summary>
            /// The width of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. 
            /// The SM_XVIRTUALSCREEN metric is the coordinates for the left side of the virtual screen.
            /// </summary>
            SM_CXVIRTUALSCREEN = 78,

            /// <summary>
            /// The width of a vertical scroll bar, in pixels.
            /// </summary>
            SM_CXVSCROLL = 2,

            /// <summary>
            /// The height of a window border, in pixels. This is equivalent to the SM_CYEDGE value for windows with the 3-D look.
            /// </summary>
            SM_CYBORDER = 6,

            /// <summary>
            /// The height of a caption area, in pixels.
            /// </summary>
            SM_CYCAPTION = 4,

            /// <summary>
            /// The height of a cursor, in pixels. The system cannot create cursors of other sizes.
            /// </summary>
            SM_CYCURSOR = 14,

            /// <summary>
            /// This value is the same as SM_CYFIXEDFRAME.
            /// </summary>
            SM_CYDLGFRAME = 8,

            /// <summary>
            /// The height of the rectangle around the location of a first click in a double-click sequence, in pixels. 
            /// The second click must occur within the rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider 
            /// the two clicks a double-click. The two clicks must also occur within a specified time. To set the height of the double-click 
            /// rectangle, call SystemParametersInfo with SPI_SETDOUBLECLKHEIGHT.
            /// </summary>
            SM_CYDOUBLECLK = 37,

            /// <summary>
            /// The number of pixels above and below a mouse-down point that the mouse pointer can move before a drag operation begins. 
            /// This allows the user to click and release the mouse button easily without unintentionally starting a drag operation. 
            /// If this value is negative, it is subtracted from above the mouse-down point and added below it.
            /// </summary>
            SM_CYDRAG = 69,

            /// <summary>
            /// The height of a 3-D border, in pixels. This is the 3-D counterpart of SM_CYBORDER.
            /// </summary>
            SM_CYEDGE = 46,

            /// <summary>
            /// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. 
            /// SM_CXFIXEDFRAME is the height of the horizontal border, and SM_CYFIXEDFRAME is the width of the vertical border. 
            /// This value is the same as SM_CYDLGFRAME.
            /// </summary>
            SM_CYFIXEDFRAME = 8,

            /// <summary>
            /// The height of the top and bottom edges of the focus rectangle drawn byDrawFocusRect. 
            /// This value is in pixels. 
            /// Windows 2000:  This value is not supported.
            /// </summary>
            SM_CYFOCUSBORDER = 84,

            /// <summary>
            /// This value is the same as SM_CYSIZEFRAME.
            /// </summary>
            SM_CYFRAME = 33,

            /// <summary>
            /// The height of the client area for a full-screen window on the primary display monitor, in pixels. 
            /// To get the coordinates of the portion of the screen not obscured by the system taskbar or by application desktop toolbars,
            /// call the SystemParametersInfo function with the SPI_GETWORKAREA value.
            /// </summary>
            SM_CYFULLSCREEN = 17,

            /// <summary>
            /// The height of a horizontal scroll bar, in pixels.
            /// </summary>
            SM_CYHSCROLL = 3,

            /// <summary>
            /// The default height of an icon, in pixels. The LoadIcon function can load only icons with the dimensions SM_CXICON and SM_CYICON.
            /// </summary>
            SM_CYICON = 12,

            /// <summary>
            /// The height of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size 
            /// SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CYICON.
            /// </summary>
            SM_CYICONSPACING = 39,

            /// <summary>
            /// For double byte character set versions of the system, this is the height of the Kanji window at the bottom of the screen, in pixels.
            /// </summary>
            SM_CYKANJIWINDOW = 18,

            /// <summary>
            /// The default height, in pixels, of a maximized top-level window on the primary display monitor.
            /// </summary>
            SM_CYMAXIMIZED = 62,

            /// <summary>
            /// The default maximum height of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. 
            /// The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by processing 
            /// the WM_GETMINMAXINFO message.
            /// </summary>
            SM_CYMAXTRACK = 60,

            /// <summary>
            /// The height of a single-line menu bar, in pixels.
            /// </summary>
            SM_CYMENU = 15,

            /// <summary>
            /// The height of the default menu check-mark bitmap, in pixels.
            /// </summary>
            SM_CYMENUCHECK = 72,

            /// <summary>
            /// The height of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.
            /// </summary>
            SM_CYMENUSIZE = 55,

            /// <summary>
            /// The minimum height of a window, in pixels.
            /// </summary>
            SM_CYMIN = 29,

            /// <summary>
            /// The height of a minimized window, in pixels.
            /// </summary>
            SM_CYMINIMIZED = 58,

            /// <summary>
            /// The height of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. 
            /// This value is always greater than or equal to SM_CYMINIMIZED.
            /// </summary>
            SM_CYMINSPACING = 48,

            /// <summary>
            /// The minimum tracking height of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. 
            /// A window can override this value by processing the WM_GETMINMAXINFO message.
            /// </summary>
            SM_CYMINTRACK = 35,

            /// <summary>
            /// The height of the screen of the primary display monitor, in pixels. This is the same value obtained by calling 
            /// GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, VERTRES).
            /// </summary>
            SM_CYSCREEN = 1,

            /// <summary>
            /// The height of a button in a window caption or title bar, in pixels.
            /// </summary>
            SM_CYSIZE = 31,

            /// <summary>
            /// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. 
            /// SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border. 
            /// This value is the same as SM_CYFRAME.
            /// </summary>
            SM_CYSIZEFRAME = 33,

            /// <summary>
            /// The height of a small caption, in pixels.
            /// </summary>
            SM_CYSMCAPTION = 51,

            /// <summary>
            /// The recommended height of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.
            /// </summary>
            SM_CYSMICON = 50,

            /// <summary>
            /// The height of small caption buttons, in pixels.
            /// </summary>
            SM_CYSMSIZE = 53,

            /// <summary>
            /// The height of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. 
            /// The SM_YVIRTUALSCREEN metric is the coordinates for the top of the virtual screen.
            /// </summary>
            SM_CYVIRTUALSCREEN = 79,

            /// <summary>
            /// The height of the arrow bitmap on a vertical scroll bar, in pixels.
            /// </summary>
            SM_CYVSCROLL = 20,

            /// <summary>
            /// The height of the thumb box in a vertical scroll bar, in pixels.
            /// </summary>
            SM_CYVTHUMB = 9,

            /// <summary>
            /// Nonzero if User32.dll supports DBCS; otherwise, 0.
            /// </summary>
            SM_DBCSENABLED = 42,

            /// <summary>
            /// Nonzero if the debug version of User.exe is installed; otherwise, 0.
            /// </summary>
            SM_DEBUG = 22,

            /// <summary>
            /// Nonzero if the current operating system is Windows 7 or Windows Server 2008 R2 and the Tablet PC Input 
            /// service is started; otherwise, 0. The return value is a bitmask that specifies the type of digitizer input supported by the device. 
            /// For more information, see Remarks. 
            /// Windows Server 2008, Windows Vista, and Windows XP/2000:  This value is not supported.
            /// </summary>
            SM_DIGITIZER = 94,

            /// <summary>
            /// Nonzero if Input Method Manager/Input Method Editor features are enabled; otherwise, 0. 
            /// SM_IMMENABLED indicates whether the system is ready to use a Unicode-based IME on a Unicode application. 
            /// To ensure that a language-dependent IME works, check SM_DBCSENABLED and the system ANSI code page.
            /// Otherwise the ANSI-to-Unicode conversion may not be performed correctly, or some components like fonts
            /// or registry settings may not be present.
            /// </summary>
            SM_IMMENABLED = 82,

            /// <summary>
            /// Nonzero if there are digitizers in the system; otherwise, 0. SM_MAXIMUMTOUCHES returns the aggregate maximum of the 
            /// maximum number of contacts supported by every digitizer in the system. If the system has only single-touch digitizers, 
            /// the return value is 1. If the system has multi-touch digitizers, the return value is the number of simultaneous contacts 
            /// the hardware can provide. Windows Server 2008, Windows Vista, and Windows XP/2000:  This value is not supported.
            /// </summary>
            SM_MAXIMUMTOUCHES = 95,

            /// <summary>
            /// Nonzero if the current operating system is the Windows XP, Media Center Edition, 0 if not.
            /// </summary>
            SM_MEDIACENTER = 87,

            /// <summary>
            /// Nonzero if drop-down menus are right-aligned with the corresponding menu-bar item; 0 if the menus are left-aligned.
            /// </summary>
            SM_MENUDROPALIGNMENT = 40,

            /// <summary>
            /// Nonzero if the system is enabled for Hebrew and Arabic languages, 0 if not.
            /// </summary>
            SM_MIDEASTENABLED = 74,

            /// <summary>
            /// Nonzero if a mouse is installed; otherwise, 0. This value is rarely zero, because of support for virtual mice and because 
            /// some systems detect the presence of the port instead of the presence of a mouse.
            /// </summary>
            SM_MOUSEPRESENT = 19,

            /// <summary>
            /// Nonzero if a mouse with a horizontal scroll wheel is installed; otherwise 0.
            /// </summary>
            SM_MOUSEHORIZONTALWHEELPRESENT = 91,

            /// <summary>
            /// Nonzero if a mouse with a vertical scroll wheel is installed; otherwise 0.
            /// </summary>
            SM_MOUSEWHEELPRESENT = 75,

            /// <summary>
            /// The least significant bit is set if a network is present; otherwise, it is cleared. The other bits are reserved for future use.
            /// </summary>
            SM_NETWORK = 63,

            /// <summary>
            /// Nonzero if the Microsoft Windows for Pen computing extensions are installed; zero otherwise.
            /// </summary>
            SM_PENWINDOWS = 41,

            /// <summary>
            /// This system metric is used in a Terminal Services environment to determine if the current Terminal Server session is 
            /// being remotely controlled. Its value is nonzero if the current session is remotely controlled; otherwise, 0. 
            /// You can use terminal services management tools such as Terminal Services Manager (tsadmin.msc) and shadow.exe to 
            /// control a remote session. When a session is being remotely controlled, another user can view the contents of that session 
            /// and potentially interact with it.
            /// </summary>
            SM_REMOTECONTROL = 0x2001,

            /// <summary>
            /// This system metric is used in a Terminal Services environment. If the calling process is associated with a Terminal Services 
            /// client session, the return value is nonzero. If the calling process is associated with the Terminal Services console session, 
            /// the return value is 0. 
            /// Windows Server 2003 and Windows XP:  The console session is not necessarily the physical console. 
            /// For more information, seeWTSGetActiveConsoleSessionId.
            /// </summary>
            SM_REMOTESESSION = 0x1000,

            /// <summary>
            /// Nonzero if all the display monitors have the same color format, otherwise, 0. Two displays can have the same bit depth, 
            /// but different color formats. For example, the red, green, and blue pixels can be encoded with different numbers of bits, 
            /// or those bits can be located in different places in a pixel color value.
            /// </summary>
            SM_SAMEDISPLAYFORMAT = 81,

            /// <summary>
            /// This system metric should be ignored; it always returns 0.
            /// </summary>
            SM_SECURE = 44,

            /// <summary>
            /// The build number if the system is Windows Server 2003 R2; otherwise, 0.
            /// </summary>
            SM_SERVERR2 = 89,

            /// <summary>
            /// Nonzero if the user requires an application to present information visually in situations where it would otherwise present 
            /// the information only in audible form; otherwise, 0.
            /// </summary>
            SM_SHOWSOUNDS = 70,

            /// <summary>
            /// Nonzero if the current session is shutting down; otherwise, 0. Windows 2000:  This value is not supported.
            /// </summary>
            SM_SHUTTINGDOWN = 0x2000,

            /// <summary>
            /// Nonzero if the computer has a low-end (slow) processor; otherwise, 0.
            /// </summary>
            SM_SLOWMACHINE = 73,

            /// <summary>
            /// Nonzero if the current operating system is Windows 7 Starter Edition, Windows Vista Starter, or Windows XP Starter Edition; otherwise, 0.
            /// </summary>
            SM_STARTER = 88,

            /// <summary>
            /// Nonzero if the meanings of the left and right mouse buttons are swapped; otherwise, 0.
            /// </summary>
            SM_SWAPBUTTON = 23,

            /// <summary>
            /// Nonzero if the current operating system is the Windows XP Tablet PC edition or if the current operating system is Windows Vista
            /// or Windows 7 and the Tablet PC Input service is started; otherwise, 0. The SM_DIGITIZER setting indicates the type of digitizer 
            /// input supported by a device running Windows 7 or Windows Server 2008 R2. For more information, see Remarks.
            /// </summary>
            SM_TABLETPC = 86,

            /// <summary>
            /// The coordinates for the left side of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. 
            /// The SM_CXVIRTUALSCREEN metric is the width of the virtual screen.
            /// </summary>
            SM_XVIRTUALSCREEN = 76,

            /// <summary>
            /// The coordinates for the top of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. 
            /// The SM_CYVIRTUALSCREEN metric is the height of the virtual screen.
            /// </summary>
            SM_YVIRTUALSCREEN = 77,
        }

        /// <summary>
        /// I needed some "Generic" magic to get from an enum to an int for switch and boolean operands
        /// </summary>
        internal struct WM_
        {
            public const int
            // <summary>
            // The WM_NULL message performs no operation. An application sends the WM_NULL message if it wants to post a message that the recipient window will ignore.
            // </summary>
            NULL = 0x0000,
            // <summary>
            // The WM_CREATE message is sent when an application requests that a window be created by calling the CreateWindowEx or CreateWindow function. (The message is sent before the function returns.) The window procedure of the new window receives this message after the window is created, but before the window becomes visible.
            // </summary>
            CREATE = 0x0001,
            // <summary>
            // The WM_DESTROY message is sent when a window is being destroyed. It is sent to the window procedure of the window being destroyed after the window is removed from the screen.
            // This message is sent first to the window being destroyed and then to the child windows (if any) as they are destroyed. During the processing of the message, it can be assumed that all child windows still exist.
            // // </summary>
            DESTROY = 0x0002,
            // <summary>
            // The WM_MOVE message is sent after a window has been moved.
            // </summary>
            MOVE = 0x0003,
            // <summary>
            // The WM_SIZE message is sent to a window after its size has changed.
            // </summary>
            SIZE = 0x0005,
            // <summary>
            // The WM_ACTIVATE message is sent to both the window being activated and the window being deactivated.
            // If the windows use the same input queue, the message is sent synchronously, first to the window procedure of the top-level window being deactivated, 
            // then to the window procedure of the top-level window being activated. If the windows use different input queues, the message is sent asynchronously,
            // so the window is activated immediately.
            // </summary>
            ACTIVATE = 0x0006,
            // <summary>
            // The WM_SETFOCUS message is sent to a window after it has gained the keyboard focus.
            // </summary>
            SETFOCUS = 0x0007,
            // <summary>
            // The WM_KILLFOCUS message is sent to a window immediately before it loses the keyboard focus.
            // </summary>
            KILLFOCUS = 0x0008,
            // <summary>
            // The WM_ENABLE message is sent when an application changes the enabled state of a window. It is sent to the window whose enabled state is changing. This message is sent before the EnableWindow function returns, but after the enabled state (WS_DISABLED style bit) of the window has changed.
            // </summary>
            ENABLE = 0x000A,
            // <summary>
            // An application sends the WM_SETREDRAW message to a window to allow changes in that window to be redrawn or to prevent changes in that window from being redrawn.
            // </summary>
            SETREDRAW = 0x000B,
            // <summary>
            // An application sends a WM_SETTEXT message to set the text of a window.
            // </summary>
            SETTEXT = 0x000C,
            // <summary>
            // An application sends a WM_GETTEXT message to copy the text that corresponds to a window into a buffer provided by the caller.
            // </summary>
            GETTEXT = 0x000D,
            // <summary>
            // An application sends a WM_GETTEXTLENGTH message to determine the length, in characters, of the text associated with a window.
            // </summary>
            GETTEXTLENGTH = 0x000E,
            // <summary>
            // The WM_PAINT message is sent when the system or another application makes a request to paint a portion of an application's window. The message is sent when the UpdateWindow or RedrawWindow function is called, or by the DispatchMessage function when the application obtains a WM_PAINT message by using the GetMessage or PeekMessage function.
            // </summary>
            PAINT = 0x000F,
            // <summary>
            // The WM_CLOSE message is sent as a signal that a window or an application should terminate.
            // </summary>
            CLOSE = 0x0010,
            // <summary>
            // The WM_QUERYENDSESSION message is sent when the user chooses to end the session or when an application calls one of the system shutdown functions. If any application returns zero, the session is not ended. The system stops sending WM_QUERYENDSESSION messages as soon as one application returns zero.
            // After processing this message, the system sends the WM_ENDSESSION message with the wParam parameter set to the results of the WM_QUERYENDSESSION message.
            // </summary>
            QUERYENDSESSION = 0x0011,
            // <summary>
            // The WM_QUERYOPEN message is sent to an icon when the user requests that the window be restored to its previous size and position.
            // </summary>
            QUERYOPEN = 0x0013,
            // <summary>
            // The WM_ENDSESSION message is sent to an application after the system processes the results of the WM_QUERYENDSESSION message. The WM_ENDSESSION message informs the application whether the session is ending.
            // </summary>
            ENDSESSION = 0x0016,
            // <summary>
            // The WM_QUIT message indicates a request to terminate an application and is generated when the application calls the PostQuitMessage function. It causes the GetMessage function to return zero.
            // </summary>
            QUIT = 0x0012,
            // <summary>
            // The WM_ERASEBKGND message is sent when the window background must be erased (for example, when a window is resized). The message is sent to prepare an invalidated portion of a window for painting.
            // </summary>
            ERASEBKGND = 0x0014,
            // <summary>
            // This message is sent to all top-level windows when a change is made to a system color setting.
            // </summary>
            SYSCOLORCHANGE = 0x0015,
            // <summary>
            // The WM_SHOWWINDOW message is sent to a window when the window is about to be hidden or shown.
            // </summary>
            SHOWWINDOW = 0x0018,
            // <summary>
            // An application sends the WM_WININICHANGE message to all top-level windows after making a change to the WIN.INI file. The SystemParametersInfo function sends this message after an application uses the function to change a setting in WIN.INI.
            // Note  The WM_WININICHANGE message is provided only for compatibility with earlier versions of the system. Applications should use the WM_SETTINGCHANGE message.
            // </summary>
            WININICHANGE = 0x001A,
            // <summary>
            // An application sends the WM_WININICHANGE message to all top-level windows after making a change to the WIN.INI file. The SystemParametersInfo function sends this message after an application uses the function to change a setting in WIN.INI.
            // Note  The WM_WININICHANGE message is provided only for compatibility with earlier versions of the system. Applications should use the WM_SETTINGCHANGE message.
            // </summary>
            SETTINGCHANGE = WININICHANGE,
            // <summary>
            // The WM_DEVMODECHANGE message is sent to all top-level windows whenever the user changes device-mode settings.
            // </summary>
            DEVMODECHANGE = 0x001B,
            // <summary>
            // The WM_ACTIVATEAPP message is sent when a window belonging to a different application than the active window is about to be activated.
            // The message is sent to the application whose window is being activated and to the application whose window is being deactivated.
            // </summary>
            ACTIVATEAPP = 0x001C,
            // <summary>
            // An application sends the WM_FONTCHANGE message to all top-level windows in the system after changing the pool of font resources.
            // </summary>
            FONTCHANGE = 0x001D,
            // <summary>
            // A message that is sent whenever there is a change in the system time.
            // </summary>
            TIMECHANGE = 0x001E,
            // <summary>
            // The WM_CANCELMODE message is sent to cancel certain modes, such as mouse capture. For example, the system sends this message to the active window when a dialog box or message box is displayed. Certain functions also send this message explicitly to the specified window regardless of whether it is the active window. For example, the EnableWindow function sends this message when disabling the specified window.
            // </summary>
            CANCELMODE = 0x001F,
            // <summary>
            // The WM_SETCURSOR message is sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured.
            // </summary>
            SETCURSOR = 0x0020,
            // <summary>
            // The WM_MOUSEACTIVATE message is sent when the cursor is in an inactive window and the user presses a mouse button. The parent window receives this message only if the child window passes it to the DefWindowProc function.
            // </summary>
            MOUSEACTIVATE = 0x0021,
            // <summary>
            // The WM_CHILDACTIVATE message is sent to a child window when the user clicks the window's title bar or when the window is activated, moved, or sized.
            // </summary>
            CHILDACTIVATE = 0x0022,
            // <summary>
            // The WM_QUEUESYNC message is sent by a computer-based training (CBT) application to separate user-input messages from other messages sent through the WH_JOURNALPLAYBACK Hook procedure.
            // </summary>
            QUEUESYNC = 0x0023,
            // <summary>
            // The WM_GETMINMAXINFO message is sent to a window when the size or position of the window is about to change.
            // An application can use this message to override the window's default maximized size and position, or its default minimum or maximum tracking size.
            // </summary>
            GETMINMAXINFO = 0x0024,
            // <summary>
            // Windows NT 3.51 and earlier: The WM_PAINTICON message is sent to a minimized window when the icon is to be painted. This message is not sent by newer versions of Microsoft Windows, except in unusual circumstances explained in the Remarks.
            // </summary>
            PAINTICON = 0x0026,
            // <summary>
            // Windows NT 3.51 and earlier: The WM_ICONERASEBKGND message is sent to a minimized window when the background of the icon must be filled before painting the icon. A window receives this message only if a class icon is defined for the window; otherwise, WM_ERASEBKGND is sent. This message is not sent by newer versions of Windows.
            // </summary>
            ICONERASEBKGND = 0x0027,
            // <summary>
            // The WM_NEXTDLGCTL message is sent to a dialog box procedure to set the keyboard focus to a different control in the dialog box.
            // </summary>
            NEXTDLGCTL = 0x0028,
            // <summary>
            // The WM_SPOOLERSTATUS message is sent from Print Manager whenever a job is added to or removed from the Print Manager queue.
            // </summary>
            SPOOLERSTATUS = 0x002A,
            // <summary>
            // The WM_DRAWITEM message is sent to the parent window of an owner-drawn button, combo box, list box, or menu when a visual aspect of the button, combo box, list box, or menu has changed.
            // </summary>
            DRAWITEM = 0x002B,
            // <summary>
            // The WM_MEASUREITEM message is sent to the owner window of a combo box, list box, list view control, or menu item when the control or menu is created.
            // </summary>
            MEASUREITEM = 0x002C,
            // <summary>
            // Sent to the owner of a list box or combo box when the list box or combo box is destroyed or when items are removed by the LB_DELETESTRING, LB_RESETCONTENT, CB_DELETESTRING, or CB_RESETCONTENT message. The system sends a WM_DELETEITEM message for each deleted item. The system sends the WM_DELETEITEM message for any deleted list box or combo box item with nonzero item data.
            // </summary>
            DELETEITEM = 0x002D,
            // <summary>
            // Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its owner in response to a WM_KEYDOWN message.
            // </summary>
            VKEYTOITEM = 0x002E,
            // <summary>
            // Sent by a list box with the LBS_WANTKEYBOARDINPUT style to its owner in response to a WM_CHAR message.
            // </summary>
            CHARTOITEM = 0x002F,
            // <summary>
            // An application sends a WM_SETFONT message to specify the font that a control is to use when drawing text.
            // </summary>
            SETFONT = 0x0030,
            // <summary>
            // An application sends a WM_GETFONT message to a control to retrieve the font with which the control is currently drawing its text.
            // </summary>
            GETFONT = 0x0031,
            // <summary>
            // An application sends a WM_SETHOTKEY message to a window to associate a hot key with the window. When the user presses the hot key, the system activates the window.
            // </summary>
            SETHOTKEY = 0x0032,
            // <summary>
            // An application sends a WM_GETHOTKEY message to determine the hot key associated with a window.
            // </summary>
            GETHOTKEY = 0x0033,
            // <summary>
            // The WM_QUERYDRAGICON message is sent to a minimized (iconic) window. The window is about to be dragged by the user but does not have an icon defined for its class. An application can return a handle to an icon or cursor. The system displays this cursor or icon while the user drags the icon.
            // </summary>
            QUERYDRAGICON = 0x0037,
            // <summary>
            // The system sends the WM_COMPAREITEM message to determine the relative position of a new item in the sorted list of an owner-drawn combo box or list box. Whenever the application adds a new item, the system sends this message to the owner of a combo box or list box created with the CBS_SORT or LBS_SORT style.
            // </summary>
            COMPAREITEM = 0x0039,
            // <summary>
            // Active Accessibility sends the WM_GETOBJECT message to obtain information about an accessible object contained in a server application.
            // Applications never send this message directly. It is sent only by Active Accessibility in response to calls to AccessibleObjectFromPoint, AccessibleObjectFromEvent, or AccessibleObjectFromWindow. However, server applications handle this message.
            // </summary>
            GETOBJECT = 0x003D,
            // <summary>
            // The WM_COMPACTING message is sent to all top-level windows when the system detects more than 12.5 percent of system time over a 30- to 60-second interval is being spent compacting memory. This indicates that system memory is low.
            // </summary>
            COMPACTING = 0x0041,
            // <summary>
            // WM_COMMNOTIFY is Obsolete for Win32-Based Applications
            // </summary>
            //[Obsolete]
            //COMMNOTIFY = 0x0044,
            // <summary>
            // The WM_WINDOWPOSCHANGING message is sent to a window whose size, position, or place in the Z order is about to change as a result of a call to the SetWindowPos function or another window-management function.
            // </summary>
            WINDOWPOSCHANGING = 0x0046,
            // <summary>
            // The WM_WINDOWPOSCHANGED message is sent to a window whose size, position, or place in the Z order has changed as a result of a call to the SetWindowPos function or another window-management function.
            // </summary>
            WINDOWPOSCHANGED = 0x0047,
            // <summary>
            // Notifies applications that the system, typically a battery-powered personal computer, is about to enter a suspended mode.
            // Use: POWERBROADCAST
            // </summary>
            //[Obsolete]
            //POWER = 0x0048,
            // <summary>
            // An application sends the WM_COPYDATA message to pass data to another application.
            // </summary>
            COPYDATA = 0x004A,
            // <summary>
            // The WM_CANCELJOURNAL message is posted to an application when a user cancels the application's journaling activities. The message is posted with a NULL window handle.
            // </summary>
            CANCELJOURNAL = 0x004B,
            // <summary>
            // Sent by a common control to its parent window when an event has occurred or the control requires some information.
            // </summary>
            NOTIFY = 0x004E,
            // <summary>
            // The WM_INPUTLANGCHANGEREQUEST message is posted to the window with the focus when the user chooses a new input language, either with the hotkey (specified in the Keyboard control panel application) or from the indicator on the system taskbar. An application can accept the change by passing the message to the DefWindowProc function or reject the change (and prevent it from taking place) by returning immediately.
            // </summary>
            INPUTLANGCHANGEREQUEST = 0x0050,
            // <summary>
            // The WM_INPUTLANGCHANGE message is sent to the topmost affected window after an application's input language has been changed. You should make any application-specific settings and pass the message to the DefWindowProc function, which passes the message to all first-level child windows. These child windows can pass the message to DefWindowProc to have it pass the message to their child windows, and so on.
            // </summary>
            INPUTLANGCHANGE = 0x0051,
            // <summary>
            // Sent to an application that has initiated a training card with Microsoft Windows Help. The message informs the application when the user clicks an authorable button. An application initiates a training card by specifying the HELP_TCARD command in a call to the WinHelp function.
            // </summary>
            TCARD = 0x0052,
            // <summary>
            // Indicates that the user pressed the F1 key. If a menu is active when F1 is pressed, WM_HELP is sent to the window associated with the menu; otherwise, WM_HELP is sent to the window that has the keyboard focus. If no window has the keyboard focus, WM_HELP is sent to the currently active window.
            // </summary>
            HELP = 0x0053,
            // <summary>
            // The WM_USERCHANGED message is sent to all windows after the user has logged on or off. When the user logs on or off, the system updates the user-specific settings. The system sends this message immediately after updating the settings.
            // </summary>
            USERCHANGED = 0x0054,
            // <summary>
            // Determines if a window accepts ANSI or Unicode structures in the WM_NOTIFY notification message. WM_NOTIFYFORMAT messages are sent from a common control to its parent window and from the parent window to the common control.
            // </summary>
            NOTIFYFORMAT = 0x0055,
            // <summary>
            // The WM_CONTEXTMENU message notifies a window that the user clicked the right mouse button (right-clicked) in the window.
            // </summary>
            CONTEXTMENU = 0x007B,
            // <summary>
            // The WM_STYLECHANGING message is sent to a window when the SetWindowLong function is about to change one or more of the window's styles.
            // </summary>
            STYLECHANGING = 0x007C,
            // <summary>
            // The WM_STYLECHANGED message is sent to a window after the SetWindowLong function has changed one or more of the window's styles
            // </summary>
            STYLECHANGED = 0x007D,
            // <summary>
            // The WM_DISPLAYCHANGE message is sent to all windows when the display resolution has changed.
            // </summary>
            DISPLAYCHANGE = 0x007E,
            // <summary>
            // The WM_GETICON message is sent to a window to retrieve a handle to the large or small icon associated with a window. The system displays the large icon in the ALT+TAB dialog, and the small icon in the window caption.
            // </summary>
            GETICON = 0x007F,
            // <summary>
            // An application sends the WM_SETICON message to associate a new large or small icon with a window. The system displays the large icon in the ALT+TAB dialog box, and the small icon in the window caption.
            // </summary>
            SETICON = 0x0080,
            // <summary>
            // The WM_NCCREATE message is sent prior to the WM_CREATE message when a window is first created.
            // </summary>
            NCCREATE = 0x0081,
            // <summary>
            // The WM_NCDESTROY message informs a window that its nonclient area is being destroyed. The DestroyWindow function sends the WM_NCDESTROY message to the window following the WM_DESTROY message. WM_DESTROY is used to free the allocated memory object associated with the window.
            // The WM_NCDESTROY message is sent after the child windows have been destroyed. In contrast, WM_DESTROY is sent before the child windows are destroyed.
            // </summary>
            NCDESTROY = 0x0082,
            // <summary>
            // The WM_NCCALCSIZE message is sent when the size and position of a window's client area must be calculated. By processing this message, an application can control the content of the window's client area when the size or position of the window changes.
            // </summary>
            NCCALCSIZE = 0x0083,
            // <summary>
            // The WM_NCHITTEST message is sent to a window when the cursor moves, or when a mouse button is pressed or released. If the mouse is not captured, the message is sent to the window beneath the cursor. Otherwise, the message is sent to the window that has captured the mouse.
            // </summary>
            NCHITTEST = 0x0084,
            // <summary>
            // The WM_NCPAINT message is sent to a window when its frame must be painted.
            // </summary>
            NCPAINT = 0x0085,
            // <summary>
            // The WM_NCACTIVATE message is sent to a window when its nonclient area needs to be changed to indicate an active or inactive state.
            // </summary>
            NCACTIVATE = 0x0086,
            // <summary>
            // The WM_GETDLGCODE message is sent to the window procedure associated with a control. By default, the system handles all keyboard input to the control; the system interprets certain types of keyboard input as dialog box navigation keys. To override this default behavior, the control can respond to the WM_GETDLGCODE message to indicate the types of input it wants to process itself.
            // </summary>
            GETDLGCODE = 0x0087,
            // <summary>
            // The WM_SYNCPAINT message is used to synchronize painting while avoiding linking independent GUI threads.
            // </summary>
            SYNCPAINT = 0x0088,
            // <summary>
            // The WM_NCMOUSEMOVE message is posted to a window when the cursor is moved within the nonclient area of the window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCMOUSEMOVE = 0x00A0,
            // <summary>
            // The WM_NCLBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCLBUTTONDOWN = 0x00A1,
            // <summary>
            // The WM_NCLBUTTONUP message is posted when the user releases the left mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCLBUTTONUP = 0x00A2,
            // <summary>
            // The WM_NCLBUTTONDBLCLK message is posted when the user double-clicks the left mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCLBUTTONDBLCLK = 0x00A3,
            // <summary>
            // The WM_NCRBUTTONDOWN message is posted when the user presses the right mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCRBUTTONDOWN = 0x00A4,
            // <summary>
            // The WM_NCRBUTTONUP message is posted when the user releases the right mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCRBUTTONUP = 0x00A5,
            // <summary>
            // The WM_NCRBUTTONDBLCLK message is posted when the user double-clicks the right mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCRBUTTONDBLCLK = 0x00A6,
            // <summary>
            // The WM_NCMBUTTONDOWN message is posted when the user presses the middle mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCMBUTTONDOWN = 0x00A7,
            // <summary>
            // The WM_NCMBUTTONUP message is posted when the user releases the middle mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCMBUTTONUP = 0x00A8,
            // <summary>
            // The WM_NCMBUTTONDBLCLK message is posted when the user double-clicks the middle mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCMBUTTONDBLCLK = 0x00A9,
            // <summary>
            // The WM_NCXBUTTONDOWN message is posted when the user presses the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCXBUTTONDOWN = 0x00AB,
            // <summary>
            // The WM_NCXBUTTONUP message is posted when the user releases the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCXBUTTONUP = 0x00AC,
            // <summary>
            // The WM_NCXBUTTONDBLCLK message is posted when the user double-clicks the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the mouse, this message is not posted.
            // </summary>
            NCXBUTTONDBLCLK = 0x00AD,
            // <summary>
            // The WM_INPUT_DEVICE_CHANGE message is sent to the window that registered to receive raw input. A window receives this message through its WindowProc function.
            // </summary>
            INPUT_DEVICE_CHANGE = 0x00FE,
            // <summary>
            // The WM_INPUT message is sent to the window that is getting raw input.
            // </summary>
            INPUT = 0x00FF,
            // <summary>
            // This message filters for keyboard messages.
            // </summary>
            KEYFIRST = 0x0100,
            // <summary>
            // The WM_KEYDOWN message is posted to the window with the keyboard focus when a nonsystem key is pressed. A nonsystem key is a key that is pressed when the ALT key is not pressed.
            // </summary>
            KEYDOWN = 0x0100,
            // <summary>
            // The WM_KEYUP message is posted to the window with the keyboard focus when a nonsystem key is released. A nonsystem key is a key that is pressed when the ALT key is not pressed, or a keyboard key that is pressed when a window has the keyboard focus.
            // </summary>
            KEYUP = 0x0101,
            // <summary>
            // The WM_CHAR message is posted to the window with the keyboard focus when a WM_KEYDOWN message is translated by the TranslateMessage function. The WM_CHAR message contains the character code of the key that was pressed.
            // </summary>
            CHAR = 0x0102,
            // <summary>
            // The WM_DEADCHAR message is posted to the window with the keyboard focus when a WM_KEYUP message is translated by the TranslateMessage function. WM_DEADCHAR specifies a character code generated by a dead key. A dead key is a key that generates a character, such as the umlaut (double-dot), that is combined with another character to form a composite character. For example, the umlaut-O character (Ö) is generated by typing the dead key for the umlaut character, and then typing the O key.
            // </summary>
            DEADCHAR = 0x0103,
            // <summary>
            // The WM_SYSKEYDOWN message is posted to the window with the keyboard focus when the user presses the F10 key (which activates the menu bar) or holds down the ALT key and then presses another key. It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYDOWN message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter.
            // </summary>
            SYSKEYDOWN = 0x0104,
            // <summary>
            // The WM_SYSKEYUP message is posted to the window with the keyboard focus when the user releases a key that was pressed while the ALT key was held down. It also occurs when no window currently has the keyboard focus; in this case, the WM_SYSKEYUP message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter.
            // </summary>
            SYSKEYUP = 0x0105,
            // <summary>
            // The WM_SYSCHAR message is posted to the window with the keyboard focus when a WM_SYSKEYDOWN message is translated by the TranslateMessage function. It specifies the character code of a system character key — that is, a character key that is pressed while the ALT key is down.
            // </summary>
            SYSCHAR = 0x0106,
            // <summary>
            // The WM_SYSDEADCHAR message is sent to the window with the keyboard focus when a WM_SYSKEYDOWN message is translated by the TranslateMessage function. WM_SYSDEADCHAR specifies the character code of a system dead key — that is, a dead key that is pressed while holding down the ALT key.
            // </summary>
            SYSDEADCHAR = 0x0107,
            // <summary>
            // The WM_UNICHAR message is posted to the window with the keyboard focus when a WM_KEYDOWN message is translated by the TranslateMessage function. The WM_UNICHAR message contains the character code of the key that was pressed.
            // The WM_UNICHAR message is equivalent to WM_CHAR, but it uses Unicode Transformation Format (UTF)-32, whereas WM_CHAR uses UTF-16. It is designed to send or post Unicode characters to ANSI windows and it can can handle Unicode Supplementary Plane characters.
            // </summary>
            UNICHAR = 0x0109,
            // <summary>
            // This message filters for keyboard messages.
            // </summary>
            KEYLAST = 0x0108,
            // <summary>
            // Sent immediately before the IME generates the composition string as a result of a keystroke. A window receives this message through its WindowProc function.
            // </summary>
            IME_STARTCOMPOSITION = 0x010D,
            // <summary>
            // Sent to an application when the IME ends composition. A window receives this message through its WindowProc function.
            // </summary>
            IME_ENDCOMPOSITION = 0x010E,
            // <summary>
            // Sent to an application when the IME changes composition status as a result of a keystroke. A window receives this message through its WindowProc function.
            // </summary>
            IME_COMPOSITION = 0x010F,
            IME_KEYLAST = 0x010F,
            // <summary>
            // The WM_INITDIALOG message is sent to the dialog box procedure immediately before a dialog box is displayed.
            // Dialog box procedures typically use this message to initialize controls and carry out any other initialization tasks that affect the appearance of the dialog box.
            // </summary>
            INITDIALOG = 0x0110,
            // <summary>
            // The WM_COMMAND message is sent when the user selects a command item from a menu, when a control sends a notification message to its parent window,
            // or when an accelerator keystroke is translated.
            // </summary>
            COMMAND = 0x0111,
            // <summary>
            // A window receives this message when the user chooses a command from the Window menu, clicks the maximize button, minimize button, restore button, 
            // close button, or moves the form. You can stop the form from moving by filtering this out.
            // </summary>
            SYSCOMMAND = 0x0112,
            // <summary>
            // The WM_TIMER message is posted to the installing thread's message queue when a timer expires. The message is posted by the GetMessage or PeekMessage function.
            // </summary>
            TIMER = 0x0113,
            // <summary>
            // The WM_HSCROLL message is sent to a window when a scroll event occurs in the window's standard horizontal scroll bar. This message is also sent to the owner of a horizontal scroll bar control when a scroll event occurs in the control.
            // </summary>
            HSCROLL = 0x0114,
            // <summary>
            // The WM_VSCROLL message is sent to a window when a scroll event occurs in the window's standard vertical scroll bar. This message is also sent to the owner of a vertical scroll bar control when a scroll event occurs in the control.
            // </summary>
            VSCROLL = 0x0115,
            // <summary>
            // The WM_INITMENU message is sent when a menu is about to become active. It occurs when the user clicks an item on the menu bar or presses a menu key. This allows the application to modify the menu before it is displayed.
            // </summary>
            INITMENU = 0x0116,
            // <summary>
            // The WM_INITMENUPOPUP message is sent when a drop-down menu or submenu is about to become active. This allows an application to modify the menu before it is displayed, without changing the entire menu.
            // </summary>
            INITMENUPOPUP = 0x0117,
            // <summary>
            // The WM_MENUSELECT message is sent to a menu's owner window when the user selects a menu item.
            // </summary>
            MENUSELECT = 0x011F,
            // <summary>
            // The WM_MENUCHAR message is sent when a menu is active and the user presses a key that does not correspond to any mnemonic or accelerator key. This message is sent to the window that owns the menu.
            // </summary>
            MENUCHAR = 0x0120,
            // <summary>
            // The WM_ENTERIDLE message is sent to the owner window of a modal dialog box or menu that is entering an idle state. A modal dialog box or menu enters an idle state when no messages are waiting in its queue after it has processed one or more previous messages.
            // </summary>
            ENTERIDLE = 0x0121,
            // <summary>
            // The WM_MENURBUTTONUP message is sent when the user releases the right mouse button while the cursor is on a menu item.
            // </summary>
            MENURBUTTONUP = 0x0122,
            // <summary>
            // The WM_MENUDRAG message is sent to the owner of a drag-and-drop menu when the user drags a menu item.
            // </summary>
            MENUDRAG = 0x0123,
            // <summary>
            // The WM_MENUGETOBJECT message is sent to the owner of a drag-and-drop menu when the mouse cursor enters a menu item or moves from the center of the item to the top or bottom of the item.
            // </summary>
            MENUGETOBJECT = 0x0124,
            // <summary>
            // The WM_UNINITMENUPOPUP message is sent when a drop-down menu or submenu has been destroyed.
            // </summary>
            UNINITMENUPOPUP = 0x0125,
            // <summary>
            // The WM_MENUCOMMAND message is sent when the user makes a selection from a menu.
            // </summary>
            MENUCOMMAND = 0x0126,
            // <summary>
            // An application sends the WM_CHANGEUISTATE message to indicate that the user interface (UI) state should be changed.
            // https://devblogs.microsoft.com/oldnewthing/20130516-00/?p=4343
            // </summary>
            CHANGEUISTATE = 0x0127,
            // <summary>
            // An application sends the WM_UPDATEUISTATE message to change the user interface (UI) state for the specified window and all its child windows.
            // https://devblogs.microsoft.com/oldnewthing/20130516-00/?p=4343
            // </summary>
            UPDATEUISTATE = 0x0128,
            // <summary>
            // An application sends the WM_QUERYUISTATE message to retrieve the user interface (UI) state for a window.
            // </summary>
            QUERYUISTATE = 0x0129,
            // <summary>
            // The WM_CTLCOLORMSGBOX message is sent to the owner window of a message box before Windows draws the message box. By responding to this message, the owner window can set the text and background colors of the message box by using the given display device context handle.
            // </summary>
            CTLCOLORMSGBOX = 0x0132,
            // <summary>
            // An edit control that is not read-only or disabled sends the WM_CTLCOLOREDIT message to its parent window when the control is about to be drawn. By responding to this message, the parent window can use the specified device context handle to set the text and background colors of the edit control.
            // </summary>
            CTLCOLOREDIT = 0x0133,
            // <summary>
            // Sent to the parent window of a list box before the system draws the list box. By responding to this message, the parent window can set the text and background colors of the list box by using the specified display device context handle.
            // </summary>
            CTLCOLORLISTBOX = 0x0134,
            // <summary>
            // The WM_CTLCOLORBTN message is sent to the parent window of a button before drawing the button. The parent window can change the button's text and background colors. However, only owner-drawn buttons respond to the parent window processing this message.
            // </summary>
            CTLCOLORBTN = 0x0135,
            // <summary>
            // The WM_CTLCOLORDLG message is sent to a dialog box before the system draws the dialog box. By responding to this message, the dialog box can set its text and background colors using the specified display device context handle.
            // </summary>
            CTLCOLORDLG = 0x0136,
            // <summary>
            // The WM_CTLCOLORSCROLLBAR message is sent to the parent window of a scroll bar control when the control is about to be drawn. By responding to this message, the parent window can use the display context handle to set the background color of the scroll bar control.
            // </summary>
            CTLCOLORSCROLLBAR = 0x0137,
            // <summary>
            // A static control, or an edit control that is read-only or disabled, sends the WM_CTLCOLORSTATIC message to its parent window when the control is about to be drawn. By responding to this message, the parent window can use the specified device context handle to set the text and background colors of the static control.
            // </summary>
            CTLCOLORSTATIC = 0x0138,
            // <summary>
            // Use WM_MOUSEFIRST to specify the first mouse message. Use the PeekMessage() Function.
            // </summary>
            MOUSEFIRST = 0x0200,
            // <summary>
            // The WM_MOUSEMOVE message is posted to a window when the cursor moves. If the mouse is not captured, the message is posted to the window that contains the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            MOUSEMOVE = 0x0200,
            // <summary>
            // The WM_LBUTTONDOWN message is posted when the user presses the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            LBUTTONDOWN = 0x0201,
            // <summary>
            // The WM_LBUTTONUP message is posted when the user releases the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            LBUTTONUP = 0x0202,
            // <summary>
            // The WM_LBUTTONDBLCLK message is posted when the user double-clicks the left mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            LBUTTONDBLCLK = 0x0203,
            // <summary>
            // The WM_RBUTTONDOWN message is posted when the user presses the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            RBUTTONDOWN = 0x0204,
            // <summary>
            // The WM_RBUTTONUP message is posted when the user releases the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            RBUTTONUP = 0x0205,
            // <summary>
            // The WM_RBUTTONDBLCLK message is posted when the user double-clicks the right mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            RBUTTONDBLCLK = 0x0206,
            // <summary>
            // The WM_MBUTTONDOWN message is posted when the user presses the middle mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            MBUTTONDOWN = 0x0207,
            // <summary>
            // The WM_MBUTTONUP message is posted when the user releases the middle mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            MBUTTONUP = 0x0208,
            // <summary>
            // The WM_MBUTTONDBLCLK message is posted when the user double-clicks the middle mouse button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            MBUTTONDBLCLK = 0x0209,
            // <summary>
            // The WM_MOUSEWHEEL message is sent to the focus window when the mouse wheel is rotated. The DefWindowProc function propagates the message to the window's parent. There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
            // </summary>
            MOUSEWHEEL = 0x020A,
            // <summary>
            // The WM_XBUTTONDOWN message is posted when the user presses the first or second X button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            XBUTTONDOWN = 0x020B,
            // <summary>
            // The WM_XBUTTONUP message is posted when the user releases the first or second X button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            XBUTTONUP = 0x020C,
            // <summary>
            // The WM_XBUTTONDBLCLK message is posted when the user double-clicks the first or second X button while the cursor is in the client area of a window. If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
            // </summary>
            XBUTTONDBLCLK = 0x020D,
            // <summary>
            // The WM_MOUSEHWHEEL message is sent to the focus window when the mouse's horizontal scroll wheel is tilted or rotated. The DefWindowProc function propagates the message to the window's parent. There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
            // </summary>
            MOUSEHWHEEL = 0x020E,
            // <summary>
            // Use WM_MOUSELAST to specify the last mouse message. Used with PeekMessage() Function.
            // </summary>
            MOUSELAST = 0x020E,
            // <summary>
            // The WM_PARENTNOTIFY message is sent to the parent of a child window when the child window is created or destroyed,
            // or when the user clicks a mouse button while the cursor is over the child window. When the child window is being created, 
            // the system sends WM_PARENTNOTIFY just before the CreateWindow or CreateWindowEx function that creates the window returns. 
            // When the child window is being destroyed, the system sends the message before any processing to destroy the window takes place.
            // This message is now extended to include the WM_POINTERDOWN event. 
            // </summary>
            PARENTNOTIFY = 0x0210,
            // <summary>
            // The WM_ENTERMENULOOP message informs an application's main window procedure that a menu modal loop has been entered.
            // </summary>
            ENTERMENULOOP = 0x0211,
            // <summary>
            // The WM_EXITMENULOOP message informs an application's main window procedure that a menu modal loop has been exited.
            // </summary>
            EXITMENULOOP = 0x0212,
            // <summary>
            // The WM_NEXTMENU message is sent to an application when the right or left arrow key is used to switch between the menu bar and the system menu.
            // </summary>
            NEXTMENU = 0x0213,
            // <summary>
            // The WM_SIZING message is sent to a window that the user is resizing. By processing this message, an application can monitor the size and position of the drag rectangle and, if needed, change its size or position.
            // </summary>
            SIZING = 0x0214,
            // <summary>
            // The WM_CAPTURECHANGED message is sent to the window that is losing the mouse capture.
            // </summary>
            CAPTURECHANGED = 0x0215,
            // <summary>
            // The WM_MOVING message is sent to a window that the user is moving. By processing this message, an application can monitor the position of the drag rectangle and, if needed, change its position.
            // </summary>
            MOVING = 0x0216,
            // <summary>
            // Notifies applications that a power-management event has occurred.
            // </summary>
            POWERBROADCAST = 0x0218,
            // <summary>
            // Notifies an application of a change to the hardware configuration of a device or the computer.
            // </summary>
            DEVICECHANGE = 0x0219,
            // <summary>
            // An application sends the WM_MDICREATE message to a multiple-document interface (MDI) client window to create an MDI child window.
            // </summary>
            MDICREATE = 0x0220,
            // <summary>
            // An application sends the WM_MDIDESTROY message to a multiple-document interface (MDI) client window to close an MDI child window.
            // </summary>
            MDIDESTROY = 0x0221,
            // <summary>
            // An application sends the WM_MDIACTIVATE message to a multiple-document interface (MDI) client window to instruct the client window to activate a different MDI child window.
            // </summary>
            MDIACTIVATE = 0x0222,
            // <summary>
            // An application sends the WM_MDIRESTORE message to a multiple-document interface (MDI) client window to restore an MDI child window from maximized or minimized size.
            // </summary>
            MDIRESTORE = 0x0223,
            // <summary>
            // An application sends the WM_MDINEXT message to a multiple-document interface (MDI) client window to activate the next or previous child window.
            // </summary>
            MDINEXT = 0x0224,
            // <summary>
            // An application sends the WM_MDIMAXIMIZE message to a multiple-document interface (MDI) client window to maximize an MDI child window. The system resizes the child window to make its client area fill the client window. The system places the child window's window menu icon in the rightmost position of the frame window's menu bar, and places the child window's restore icon in the leftmost position. The system also appends the title bar text of the child window to that of the frame window.
            // </summary>
            MDIMAXIMIZE = 0x0225,
            // <summary>
            // An application sends the WM_MDITILE message to a multiple-document interface (MDI) client window to arrange all of its MDI child windows in a tile format.
            // </summary>
            MDITILE = 0x0226,
            // <summary>
            // An application sends the WM_MDICASCADE message to a multiple-document interface (MDI) client window to arrange all its child windows in a cascade format.
            // </summary>
            MDICASCADE = 0x0227,
            // <summary>
            // An application sends the WM_MDIICONARRANGE message to a multiple-document interface (MDI) client window to arrange all minimized MDI child windows. It does not affect child windows that are not minimized.
            // </summary>
            MDIICONARRANGE = 0x0228,
            // <summary>
            // An application sends the WM_MDIGETACTIVE message to a multiple-document interface (MDI) client window to retrieve the handle to the active MDI child window.
            // </summary>
            MDIGETACTIVE = 0x0229,
            // <summary>
            // An application sends the WM_MDISETMENU message to a multiple-document interface (MDI) client window to replace the entire menu of an MDI frame window, to replace the window menu of the frame window, or both.
            // </summary>
            MDISETMENU = 0x0230,
            // <summary>
            // The WM_ENTERSIZEMOVE message is sent one time to a window after it enters the moving or sizing modal loop. The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, or when the window passes the WM_SYSCOMMAND message to the DefWindowProc function and the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value. The operation is complete when DefWindowProc returns.
            // The system sends the WM_ENTERSIZEMOVE message regardless of whether the dragging of full windows is enabled.
            // </summary>
            ENTERSIZEMOVE = 0x0231,
            // <summary>
            // The WM_EXITSIZEMOVE message is sent one time to a window, after it has exited the moving or sizing modal loop. The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, or when the window passes the WM_SYSCOMMAND message to the DefWindowProc function and the wParam parameter of the message specifies the SC_MOVE or SC_SIZE value. The operation is complete when DefWindowProc returns.
            // </summary>
            EXITSIZEMOVE = 0x0232,
            // <summary>
            // Sent when the user drops a file on the window of an application that has registered itself as a recipient of dropped files.
            // </summary>
            DROPFILES = 0x0233,
            // <summary>
            // An application sends the WM_MDIREFRESHMENU message to a multiple-document interface (MDI) client window to refresh the window menu of the MDI frame window.
            // </summary>
            MDIREFRESHMENU = 0x0234,
            // <summary>
            // Sent to an application when a window is activated. A window receives this message through its WindowProc function.
            // </summary>
            IME_SETCONTEXT = 0x0281,
            // <summary>
            // Sent to an application to notify it of changes to the IME window. A window receives this message through its WindowProc function.
            // </summary>
            IME_NOTIFY = 0x0282,
            // <summary>
            // Sent by an application to direct the IME window to carry out the requested command. The application uses this message to control the IME window that it has created. To send this message, the application calls the SendMessage function with the following parameters.
            // </summary>
            IME_CONTROL = 0x0283,
            // <summary>
            // Sent to an application when the IME window finds no space to extend the area for the composition window. A window receives this message through its WindowProc function.
            // </summary>
            IME_COMPOSITIONFULL = 0x0284,
            // <summary>
            // Sent to an application when the operating system is about to change the current IME. A window receives this message through its WindowProc function.
            // </summary>
            IME_SELECT = 0x0285,
            // <summary>
            // Sent to an application when the IME gets a character of the conversion result. A window receives this message through its WindowProc function.
            // </summary>
            IME_CHAR = 0x0286,
            // <summary>
            // Sent to an application to provide commands and request information. A window receives this message through its WindowProc function.
            // </summary>
            IME_REQUEST = 0x0288,
            // <summary>
            // Sent to an application by the IME to notify the application of a key press and to keep message order. A window receives this message through its WindowProc function.
            // </summary>
            IME_KEYDOWN = 0x0290,
            // <summary>
            // Sent to an application by the IME to notify the application of a key release and to keep message order. A window receives this message through its WindowProc function.
            // </summary>
            IME_KEYUP = 0x0291,
            // <summary>
            // The WM_MOUSEHOVER message is posted to a window when the cursor hovers over the client area of the window for the period of time specified in a prior call to TrackMouseEvent.
            // </summary>
            MOUSEHOVER = 0x02A1,
            // <summary>
            // The WM_MOUSELEAVE message is posted to a window when the cursor leaves the client area of the window specified in a prior call to TrackMouseEvent.
            // </summary>
            MOUSELEAVE = 0x02A3,
            // <summary>
            // The WM_NCMOUSEHOVER message is posted to a window when the cursor hovers over the nonclient area of the window for the period of time specified in a prior call to TrackMouseEvent.
            // </summary>
            NCMOUSEHOVER = 0x02A0,
            // <summary>
            // The WM_NCMOUSELEAVE message is posted to a window when the cursor leaves the nonclient area of the window specified in a prior call to TrackMouseEvent.
            // </summary>
            NCMOUSELEAVE = 0x02A2,
            // <summary>
            // The WM_WTSSESSION_CHANGE message notifies applications of changes in session state.
            // </summary>
            WTSSESSION_CHANGE = 0x02B1,
            TABLET_FIRST = 0x02c0,
            TABLET_LAST = 0x02df,
            // <summary>
            // An application sends a WM_CUT message to an edit control or combo box to delete (cut) the current selection, if any, in the edit control and copy the deleted text to the clipboard in CF_TEXT format.
            // </summary>
            CUT = 0x0300,
            // <summary>
            // An application sends the WM_COPY message to an edit control or combo box to copy the current selection to the clipboard in CF_TEXT format.
            // </summary>
            COPY = 0x0301,
            // <summary>
            // An application sends a WM_PASTE message to an edit control or combo box to copy the current content of the clipboard to the edit control at the current caret position. Data is inserted only if the clipboard contains data in CF_TEXT format.
            // </summary>
            PASTE = 0x0302,
            // <summary>
            // An application sends a WM_CLEAR message to an edit control or combo box to delete (clear) the current selection, if any, from the edit control.
            // </summary>
            CLEAR = 0x0303,
            // <summary>
            // An application sends a WM_UNDO message to an edit control to undo the last operation. When this message is sent to an edit control, the previously deleted text is restored or the previously added text is deleted.
            // </summary>
            UNDO = 0x0304,
            // <summary>
            // The WM_RENDERFORMAT message is sent to the clipboard owner if it has delayed rendering a specific clipboard format and if an application has requested data in that format. The clipboard owner must render data in the specified format and place it on the clipboard by calling the SetClipboardData function.
            // </summary>
            RENDERFORMAT = 0x0305,
            // <summary>
            // The WM_RENDERALLFORMATS message is sent to the clipboard owner before it is destroyed, if the clipboard owner has delayed rendering one or more clipboard formats. For the content of the clipboard to remain available to other applications, the clipboard owner must render data in all the formats it is capable of generating, and place the data on the clipboard by calling the SetClipboardData function.
            // </summary>
            RENDERALLFORMATS = 0x0306,
            // <summary>
            // The WM_DESTROYCLIPBOARD message is sent to the clipboard owner when a call to the EmptyClipboard function empties the clipboard.
            // </summary>
            DESTROYCLIPBOARD = 0x0307,
            // <summary>
            // The WM_DRAWCLIPBOARD message is sent to the first window in the clipboard viewer chain when the content of the clipboard changes. This enables a clipboard viewer window to display the new content of the clipboard.
            // </summary>
            DRAWCLIPBOARD = 0x0308,
            // <summary>
            // The WM_PAINTCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and the clipboard viewer's client area needs repainting.
            // </summary>
            PAINTCLIPBOARD = 0x0309,
            // <summary>
            // The WM_VSCROLLCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and an event occurs in the clipboard viewer's vertical scroll bar. The owner should scroll the clipboard image and update the scroll bar values.
            // </summary>
            VSCROLLCLIPBOARD = 0x030A,
            // <summary>
            // The WM_SIZECLIPBOARD message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDISPLAY format and the clipboard viewer's client area has changed size.
            // </summary>
            SIZECLIPBOARD = 0x030B,
            // <summary>
            // The WM_ASKCBFORMATNAME message is sent to the clipboard owner by a clipboard viewer window to request the name of a CF_OWNERDISPLAY clipboard format.
            // </summary>
            ASKCBFORMATNAME = 0x030C,
            // <summary>
            // The WM_CHANGECBCHAIN message is sent to the first window in the clipboard viewer chain when a window is being removed from the chain.
            // </summary>
            CHANGECBCHAIN = 0x030D,
            // <summary>
            // The WM_HSCROLLCLIPBOARD message is sent to the clipboard owner by a clipboard viewer window. This occurs when the clipboard contains data in the CF_OWNERDISPLAY format and an event occurs in the clipboard viewer's horizontal scroll bar. The owner should scroll the clipboard image and update the scroll bar values.
            // </summary>
            HSCROLLCLIPBOARD = 0x030E,
            // <summary>
            // This message informs a window that it is about to receive the keyboard focus, giving the window the opportunity to realize its logical palette when it receives the focus.
            // </summary>
            QUERYNEWPALETTE = 0x030F,
            // <summary>
            // The WM_PALETTEISCHANGING message informs applications that an application is going to realize its logical palette.
            // </summary>
            PALETTEISCHANGING = 0x0310,
            // <summary>
            // This message is sent by the OS to all top-level and overlapped windows after the window with the keyboard focus realizes its logical palette.
            // This message enables windows that do not have the keyboard focus to realize their logical palettes and update their client areas.
            // </summary>
            PALETTECHANGED = 0x0311,
            // <summary>
            // The WM_HOTKEY message is posted when the user presses a hot key registered by the RegisterHotKey function. The message is placed at the top of the message queue associated with the thread that registered the hot key.
            // </summary>
            HOTKEY = 0x0312,
            // <summary>
            // The WM_PRINT message is sent to a window to request that it draw itself in the specified device context, most commonly in a printer device context.
            // </summary>
            PRINT = 0x0317,
            // <summary>
            // The WM_PRINTCLIENT message is sent to a window to request that it draw its client area in the specified device context, most commonly in a printer device context.
            // </summary>
            PRINTCLIENT = 0x0318,
            // <summary>
            // The WM_APPCOMMAND message notifies a window that the user generated an application command event, for example, by clicking an application command button using the mouse or typing an application command key on the keyboard.
            // </summary>
            APPCOMMAND = 0x0319,
            // <summary>
            // The WM_THEMECHANGED message is broadcast to every window following a theme change event. Examples of theme change events are the activation of a theme, the deactivation of a theme, or a transition from one theme to another.
            // </summary>
            THEMECHANGED = 0x031A,
            // <summary>
            // Sent when the contents of the clipboard have changed.
            // </summary>
            CLIPBOARDUPDATE = 0x031D,
            // <summary>
            // The system will send a window the WM_DWMCOMPOSITIONCHANGED message to indicate that the availability of desktop composition has changed.
            // </summary>
            DWMCOMPOSITIONCHANGED = 0x031E,
            // <summary>
            // WM_DWMNCRENDERINGCHANGED is called when the non-client area rendering status of a window has changed. Only windows that have set the flag DWM_BLURBEHIND.fTransitionOnMaximized to true will get this message.
            // </summary>
            DWMNCRENDERINGCHANGED = 0x031F,
            // <summary>
            // Sent to all top-level windows when the colorization color has changed.
            // </summary>
            DWMCOLORIZATIONCOLORCHANGED = 0x0320,
            // <summary>
            // WM_DWMWINDOWMAXIMIZEDCHANGE will let you know when a DWM composed window is maximized. You also have to register for this message as well. You'd have other windowd go opaque when this message is sent.
            // </summary>
            DWMWINDOWMAXIMIZEDCHANGE = 0x0321,
            // <summary>
            // Sent to request extended title bar information. A window receives this message through its WindowProc function.
            // </summary>
            GETTITLEBARINFOEX = 0x033F,
            HANDHELDFIRST = 0x0358,
            HANDHELDLAST = 0x035F,
            AFXFIRST = 0x0360,
            AFXLAST = 0x037F,
            PENWINFIRST = 0x0380,
            PENWINLAST = 0x038F,
            // <summary>
            // The WM_APP constant is used by applications to help define private messages, usually of the form WM_APP+X, where X is an integer value.
            // </summary>
            APP = 0x8000,
            // <summary>
            // The WM_USER constant is used by applications to help define private messages for use by private window classes, usually of the form WM_USER+X, where X is an integer value.
            // </summary>
            USER = 0x0400,

            // <summary>
            // An application sends the WM_CPL_LAUNCH message to Windows Control Panel to request that a Control Panel application be started.
            // </summary>
            CPL_LAUNCH = USER + 0x1000,
            // <summary>
            // The WM_CPL_LAUNCHED message is sent when a Control Panel application, started by the WM_CPL_LAUNCH message, has closed. The WM_CPL_LAUNCHED message is sent to the window identified by the wParam parameter of the WM_CPL_LAUNCH message that started the application.
            // </summary>
            CPL_LAUNCHED = USER + 0x1001,
            // <summary>
            // WM_SYSTIMER is a well-known yet still undocumented message. Windows uses WM_SYSTIMER for internal actions like scrolling.
            // </summary>
            SYSTIMER = 0x118,


            // Following are the ShellProc messages via RegisterShellHookWindow 
            // <summary>
            // The accessibility state has changed.
            // </summary>
            HSHELL_ACCESSIBILITYSTATE = 11,
            // <summary>
            // The shell should activate its main window.
            // </summary>
            HSHELL_ACTIVATESHELLWINDOW = 3,
            // <summary>
            // The user completed an input event (for example, pressed an application command button on the mouse or an application command key on the keyboard), and the application did not handle the WM_APPCOMMAND message generated by that input.
            // If the Shell procedure handles the WM_COMMAND message, it should not call CallNextHookEx. See the Return Value section for more information.
            // </summary>
            HSHELL_APPCOMMAND = 12,
            // <summary>
            // A window is being minimized or maximized. The system needs the coordinates of the minimized rectangle for the window.
            // </summary>
            HSHELL_GETMINRECT = 5,
            // <summary>
            // Keyboard language was changed or a new keyboard layout was loaded.
            // </summary>
            HSHELL_LANGUAGE = 8,
            // <summary>
            // The title of a window in the task bar has been redrawn.
            // </summary>
            HSHELL_REDRAW = 6,
            // <summary>
            // The user has selected the task list. A shell application that provides a task list should return TRUE to prevent Windows from starting its task list.
            // </summary>
            HSHELL_TASKMAN = 7,
            // <summary>
            // A top-level, unowned window has been created. The window exists when the system calls this hook.
            // </summary>
            HSHELL_WINDOWCREATED = 1,
            // <summary>
            // A top-level, unowned window is about to be destroyed. The window still exists when the system calls this hook.
            // </summary>
            HSHELL_WINDOWDESTROYED = 2,
            // <summary>
            // The activation has changed to a different top-level, unowned window.
            // </summary>
            HSHELL_WINDOWACTIVATED = 4,
            // <summary>
            // A top-level window is being replaced. The window exists when the system calls this hook.
            // </summary>
            HSHELL_WINDOWREPLACED = 13;
        };
        #endregion
    }
}
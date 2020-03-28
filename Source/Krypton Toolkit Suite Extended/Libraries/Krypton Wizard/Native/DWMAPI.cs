using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Extended.Wizard
{
    internal static partial class NativeMethods
    {
        internal const string DWMAPI = "dwmapi.dll";

        public enum DWMWINDOWATTRIBUTE : uint
        {
            NCRenderingEnabled = 1,
            NCRenderingPolicy,
            TransitionsForceDisabled,
            AllowNCPaint,
            CaptionButtonBounds,
            NonClientRtlLayout,
            ForceIconicRepresentation,
            Flip3DPolicy,
            ExtendedFrameBounds,
            HasIconicBitmap,
            DisallowPeek,
            ExceludedFromPeek,
            Cloak,
            Cloaked,
            FreezeRepresentation
        }

        public enum BlurBehindFlags : int
        {
            Enable = 0x00000001,
            BlurRegion = 0x00000002,
            TransitionOnMaximized = 0x00000004
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BlurBehind
        {
            BlurBehindFlags dwFlags;
            int fEnable;
            IntPtr hRgnBlur;
            int fTransitionOnMaximized;

            public BlurBehind(bool enabled)
            {
                fEnable = enabled ? 1 : 0;
                hRgnBlur = IntPtr.Zero;
                fTransitionOnMaximized = 0;
                dwFlags = BlurBehindFlags.Enable;
            }

            public System.Drawing.Region Region => System.Drawing.Region.FromHrgn(hRgnBlur);

            public bool TransitionOnMaximized
            {
                get { return fTransitionOnMaximized > 0; }
                set
                {
                    fTransitionOnMaximized = value ? 1 : 0;
                    dwFlags |= BlurBehindFlags.TransitionOnMaximized;
                }
            }

            public void SetRegion(System.Drawing.Graphics graphics, System.Drawing.Region region)
            {
                hRgnBlur = region.GetHrgn(graphics);
                dwFlags |= BlurBehindFlags.BlurRegion;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ColourisationParams
        {
            public uint Colour1, Colour2, Intensity, Unk1, Unk2, Unk3, Opaque;
        }

        /// <summary>Margins structure for theme related functions.</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Margins
        {
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;

            public static readonly Margins Empty = new Margins(0);
            public static readonly Margins Infinite = new Margins(-1);

            public Margins(int left, int right, int top, int bottom)
            {
                Left = left;
                Right = right;
                Top = top;
                Bottom = bottom;
            }

            public Margins(int allMargins)
            {
                Left = Right = Top = Bottom = allMargins;
            }

            public Margins(System.Windows.Forms.Padding padding)
                : this(padding.Left, padding.Right, padding.Top, padding.Bottom)
            {
            }

            public static bool operator !=(Margins m1, Margins m2) => !m1.Equals(m2);

            public static bool operator ==(Margins m1, Margins m2) => m1.Equals(m2);

            public override bool Equals(object obj)
            {
                if (obj is Margins)
                {
                    Margins m2 = (Margins)obj;
                    return Left == m2.Left && Right == m2.Right && Top == m2.Top && Bottom == m2.Bottom;
                }
                return base.Equals(obj);
            }

            public override int GetHashCode() => (((Left ^ RotateLeft(Top, 8)) ^ RotateLeft(Right, 0x10)) ^ RotateLeft(Bottom, 0x18));

            public override string ToString() => $"{{Left={Left},Right={Right},Top={Top},Bottom={Bottom}}}";

            internal static int RotateLeft(int value, int nBits)
            {
                nBits = nBits % 0x20;
                return ((value << nBits) | (value >> (0x20 - nBits)));
            }
        }

        [DllImport(DWMAPI, EntryPoint = "#127", PreserveSig = false)]
        [System.Security.SecurityCritical]
        public static extern void DwmGetColorizationParameters(ref ColourisationParams parameters);

        [DllImport(DWMAPI, EntryPoint = "#131", PreserveSig = false)]
        [System.Security.SecurityCritical]
        public static extern void DwmSetColorizationParameters(ref ColourisationParams parameters, uint unk);

        [DllImport(DWMAPI, ExactSpelling = true, PreserveSig = false)]
        [System.Security.SecurityCritical]
        public static extern void DwmEnableBlurBehindWindow(IntPtr hWnd, ref BlurBehind pBlurBehind);

        [DllImport(DWMAPI, ExactSpelling = true, PreserveSig = false)]
        [System.Security.SecurityCritical]
        public static extern void DwmEnableComposition(int compositionAction);

        [DllImport(DWMAPI, ExactSpelling = true, PreserveSig = false)]
        [System.Security.SecurityCritical]
        public static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);

        //[DllImport(DWMAPI, ExactSpelling = true, PreserveSig = false)]
        //public static extern void DwmGetColorizationColor(out uint ColorizationColor, [MarshalAs(UnmanagedType.Bool)]out bool ColorizationOpaqueBlend);

        [DllImport(DWMAPI, ExactSpelling = true, PreserveSig = false)]
        [System.Security.SecurityCritical]
        public static extern void DwmGetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, IntPtr pvAttribute, int cbAttribute);

        [DllImport(DWMAPI, ExactSpelling = true, PreserveSig = false)]
        [System.Security.SecurityCritical]
        public static extern void DwmIsCompositionEnabled(ref int pfEnabled);

        [DllImport(DWMAPI, ExactSpelling = true, PreserveSig = false)]
        [System.Security.SecurityCritical]
        public static extern void DwmSetWindowAttribute(IntPtr hwnd, DWMWINDOWATTRIBUTE dwAttribute, [In] IntPtr pvAttribute, int cbAttribute);
    }
}
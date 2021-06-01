#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    internal static partial class NativeMethods
    {
        private const string UXTHEME = "uxtheme.dll";

        public class SafeThemeHandle : SafeHandle
        {
            public SafeThemeHandle(IntPtr hTheme, bool ownsHandle = true) : base(IntPtr.Zero, ownsHandle) { SetHandle(hTheme); }
            protected override bool ReleaseHandle() => CloseThemeData(handle) == 0;
            public override bool IsInvalid => handle == IntPtr.Zero;
            public static implicit operator SafeThemeHandle(VisualStyleRenderer r) => new SafeThemeHandle(r.Handle, false);
        }

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        public delegate int DrawThemeTextCallback(SafeDCHandle hdc, string text, int textLen, ref RECT rc, int flags, IntPtr lParam);

        [Flags]
        public enum DrawThemeParentBackgroundFlags
        {
            None = 0,
            /// <summary>If set, hdc is assumed to be a window DC, not a client DC.</summary>
            /// <remarks>DTPB_WINDOWDC</remarks>
            WindowDC = 1,
            /// <summary>If set, this function sends a WM_CTLCOLORSTATIC message to the parent and uses the brush if one is provided. Otherwise, it uses COLOR_BTNFACE.</summary>
            /// <remarks>DTPB_USECTLCOLORSTATIC</remarks>
            UseCtlColorStaticMsg = 2,
            /// <summary>If set, this function returns S_OK without sending a WM_CTLCOLORSTATIC message if the parent actually painted on WM_ERASEBKGND.</summary>
            /// <remarks>DTPB_USEERASEBKGND</remarks>
            UseEraseBkgndMsg = 4
        }

        public enum DrawThemeTextSystemFonts
        {
            Caption = 801,
            SmallCaption = 802,
            Menu = 803,
            Status = 804,
            MessageBox = 805,
            IconTitle = 806
        }

        public enum IntegerListProperty
        {
            TransitionDuration = 6000
        }

        public enum OpenThemeDataOptions
        {
            None = 0,
            /// <summary>Forces drawn images from this theme to stretch to fit the rectangles specified by drawing functions.</summary>
            /// <remarks>OTD_FORCE_RECT_SIZING</remarks>
            ForceRectSizing = 1,
            /// <summary>Allows theme elements to be drawn in the non-client area of the window.</summary>
            /// <remarks>OTD_NONCLIENT</remarks>
            NonClient = 2
        }

        public enum ThemePropertyOrigin
        {
            /// <summary>Property was found in the state section.</summary>
            /// <remarks>PO_STATE</remarks>
            State = 0,
            /// <summary>Property was found in the part section.</summary>
            /// <remarks>PO_PART</remarks>
            Part = 1,
            /// <summary>Property was found in the class section.</summary>
            /// <remarks>PO_CLASS</remarks>
            Class = 2,
            /// <summary>Property was found in the list of global variables.</summary>
            /// <remarks>PO_GLOBAL</remarks>
            Global = 3,
            /// <summary>Property was not found.</summary>
            /// <remarks>PO_NOTFOUND</remarks>
            NotFound = 4
        }

        public enum TextShadowType
        {
            /// <summary>No shadow will be drawn.</summary>
            /// <remarks>TST_NONE</remarks>
            None = 0,
            /// <summary>The shadow will be drawn to appear detailed underneath text.</summary>
            /// <remarks>TST_SINGLE</remarks>
            Single = 1,
            /// <summary>The shadow will be drawn to appear blurred underneath text.</summary>
            /// <remarks>TST_CONTINUOUS</remarks>
            Continuous = 2
        }

        public enum ThemeSize
        {
            /// <summary>Receives the minimum size of a visual style part.</summary>
            /// <remarks>TS_MIN</remarks>
            Min,
            /// <summary>Receives the size of the visual style part that will best fit the available space.</summary>
            /// <remarks>TS_TRUE</remarks>
            True,
            /// <summary>Receives the size that the theme manager uses to draw a part.</summary>
            /// <remarks>TS_DRAW</remarks>
            Draw
        }

        [Flags]
        public enum WindowThemeNonClientAttributes : int
        {
            /// <summary>Do Not Draw The Caption (Text)</summary>
            NoDrawCaption = 0x00000001,
            /// <summary>Do Not Draw the Icon</summary>
            NoDrawIcon = 0x00000002,
            /// <summary>Do Not Show the System Menu</summary>
            NoSysMenu = 0x00000004,
            /// <summary>Do Not Mirror the Question mark Symbol</summary>
            NoMirrorHelp = 0x00000008
        }

        [Flags]
        private enum DrawThemeTextOptionsMasks
        {
            TextColor = 1,
            BorderColor = 2,
            ShadowColor = 4,
            ShadowType = 8,
            ShadowOffset = 16,
            BorderSize = 32,
            FontProp = 64,
            ColorProp = 128,
            StateId = 256,
            CalcRect = 512,
            ApplyOverlay = 1024,
            GlowSize = 2048,
            Callback = 4096,
            Composited = 8192
        }

        private enum WindowThemeAttributeType
        {
            NonClient = 1,
        }

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int CloseThemeData(IntPtr hTheme);

        [DllImport(UXTHEME, ExactSpelling = true)]
        [System.Security.SecurityCritical]
        public static extern int DrawThemeBackground(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, ref RECT pRect, PRECT pClipRect);

        [DllImport(UXTHEME, ExactSpelling = true)]
        [System.Security.SecurityCritical]
        public static extern int DrawThemeBackgroundEx(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, ref RECT pRect, DrawThemeBackgroundOptions opts);

        [DllImport(UXTHEME, ExactSpelling = true)]
        [System.Security.SecurityCritical]
        public static extern int DrawThemeIcon(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, ref RECT pRect, IntPtr himl, int iImageIndex);

        [DllImport(UXTHEME, ExactSpelling = true)]
        [System.Security.SecurityCritical]
        public static extern int DrawThemeParentBackground(IntPtr hwnd, SafeDCHandle hdc, PRECT pRect);

        [DllImport(UXTHEME, ExactSpelling = true)]
        [System.Security.SecurityCritical]
        public static extern int DrawThemeParentBackgroundEx(IntPtr hwnd, SafeDCHandle hdc, DrawThemeParentBackgroundFlags dwFlags, PRECT pRect);

        [DllImport(UXTHEME, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int DrawThemeText(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, string text, int textLength, TextFormatFlags textFlags, int textFlags2, ref RECT pRect);

        [DllImport(UXTHEME, ExactSpelling = true, CharSet = CharSet.Unicode)]
        [System.Security.SecurityCritical]
        public static extern int DrawThemeTextEx(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, string text, int iCharCount, TextFormatFlags dwFlags, ref RECT pRect, ref DrawThemeTextOptions pOptions);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemeBackgroundContentRect(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, ref RECT pBoundingRect, out RECT pContentRect);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemeBitmap(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, int iPropId, int dwFlags, out IntPtr phBitmap);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemeBool(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, [MarshalAs(UnmanagedType.Bool)] out bool pfVal);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemeColor(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out int pColor);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemeEnumValue(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out int piVal);

        [DllImport(UXTHEME, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GetThemeFilename(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, ref System.Text.StringBuilder pszBuff, int buffLength);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemeInt(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out int piVal);

        public static int[] GetThemeIntList(SafeThemeHandle hTheme, int partId, int stateId, int propId)
        {
            if (Environment.OSVersion.Version.Major < 6)
            {
                INTLIST_OLD l;
                if (0 != GetThemeIntListPreVista(hTheme, partId, stateId, propId, out l))
                    return null;
                var outlist = new int[l.iValueCount];
                Array.Copy(l.iValues, outlist, l.iValueCount);
                return outlist;
            }
            else
            {
                INTLIST l;
                if (0 != GetThemeIntList(hTheme, partId, stateId, propId, out l))
                    return null;
                var outlist = new int[l.iValueCount];
                Array.Copy(l.iValues, outlist, l.iValueCount);
                return outlist;
            }
        }

        [DllImport(UXTHEME, ExactSpelling = true)]
        [System.Security.SecurityCritical]
        public static extern int GetThemeMargins(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, int iPropId, IntPtr prc, out RECT pMargins);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemeMetric(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, int iPropId, out int piVal);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemePartSize(SafeThemeHandle hTheme, SafeDCHandle hdc, int part, int state, PRECT pRect, ThemeSize eSize, out Size size);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemePosition(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out Point piVal);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemePropertyOrigin(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out ThemePropertyOrigin pOrigin);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemeRect(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out RECT pRect);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemeStream(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] out byte[] pvStream, out int cbStream, IntPtr hInst);

        [DllImport(UXTHEME, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GetThemeString(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, ref System.Text.StringBuilder themeString, int themeStringLength);

        [DllImport(UXTHEME, ExactSpelling = true)]
        public static extern int GetThemeSysInt(SafeThemeHandle hTheme, int iIntID, out int piVal);

        [DllImport(UXTHEME, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GetThemeTextExtent(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, string text, int textLength, TextFormatFlags textFlags, ref RECT boundingRect, out RECT extentRect);

        [DllImport(UXTHEME, ExactSpelling = true)]
        [System.Security.SecurityCritical]
        public static extern int GetThemeTransitionDuration(SafeThemeHandle hTheme, int iPartId, int iStateIdFrom, int iStateIdTo, int iPropId, out int pdwDuration);

        [DllImport(UXTHEME, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsThemeBackgroundPartiallyTransparent(SafeThemeHandle hTheme, int iPartId, int iStateId);

        [DllImport(UXTHEME, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsThemePartDefined(SafeThemeHandle hTheme, int iPartId, int iStateId);

        [DllImport(UXTHEME, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr OpenThemeData(IntPtr hWnd, string classList);

        [DllImport(UXTHEME, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr OpenThemeDataEx(IntPtr hWnd, string classList, OpenThemeDataOptions dwFlags);

        [DllImport(UXTHEME, ExactSpelling = true, CharSet = CharSet.Unicode)]
        [System.Security.SecurityCritical]
        public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        public static int SetWindowThemeAttribute(IWin32Window wnd, WindowThemeNonClientAttributes ncAttrs, int ncAttrMasks = int.MaxValue)
        {
            var opt = new WTA_OPTIONS { Flags = ncAttrs, Mask = ncAttrMasks == int.MaxValue ? (int)ncAttrs : ncAttrMasks };
            return SetWindowThemeAttribute(wnd?.Handle ?? IntPtr.Zero, WindowThemeAttributeType.NonClient, ref opt, Marshal.SizeOf(opt));
        }

        [DllImport(UXTHEME, ExactSpelling = true)]
        private static extern int GetThemeIntList(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out INTLIST pIntList);

        [DllImport(UXTHEME, ExactSpelling = true, EntryPoint = "GetThemeIntList")]
        private static extern int GetThemeIntListPreVista(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out INTLIST_OLD pIntList);

        [DllImport(UXTHEME, ExactSpelling = true)]
        [System.Security.SecurityCritical]
        private static extern int SetWindowThemeAttribute(IntPtr hWnd, WindowThemeAttributeType wtype, ref WTA_OPTIONS attributes, int size);

        /// <summary>
        /// Defines the options for the <see cref="DrawThemeTextEx"/> function.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DrawThemeTextOptions
        {
            private int dwSize;
            private DrawThemeTextOptionsMasks dwMasks;
            private int crText;
            private int crBorder;
            private int crShadow;
            private TextShadowType iTextShadowType;
            private Point ptShadowOffset;
            private int iBorderSize;
            private int iFontPropId;
            private int iColorPropId;
            private int iStateId;
            [MarshalAs(UnmanagedType.Bool)]
            private bool fApplyOverlay;
            private int iGlowSize;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            private DrawThemeTextCallback pfnDrawTextCallback;
            private IntPtr lParam;

            /// <summary>Initializes a new instance of the <see cref="DrawThemeTextOptions"/> struct.</summary>
            /// <param name="init">This value must be specified to initialize.</param>
            public DrawThemeTextOptions(bool init) : this()
            {
                dwSize = Marshal.SizeOf(typeof(DrawThemeTextOptions));
            }

            /// <summary>Gets or sets a value that specifies an alternate color property to use when drawing text.</summary>
            /// <value>The alternate color of the text.</value>
            public Color AlternateColor
            {
                get { return ColorTranslator.FromWin32(iColorPropId); }
                set
                {
                    iColorPropId = ColorTranslator.ToWin32(value);
                    dwMasks |= DrawThemeTextOptionsMasks.ColorProp;
                }
            }

            /// <summary>Gets or sets an alternate font property to use when drawing text.</summary>
            /// <value>The alternate font.</value>
            public DrawThemeTextSystemFonts AlternateFont
            {
                get { return (DrawThemeTextSystemFonts)iFontPropId; }
                set
                {
                    iFontPropId = (int)value;
                    dwMasks |= DrawThemeTextOptionsMasks.FontProp;
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether to draw text with antialiased alpha. Use of this flag requires a
            /// top-down DIB section. This flag works only if the HDC passed to function DrawThemeTextEx has a top-down
            /// DIB section currently selected in it. For more information, see Device-Independent Bitmaps.
            /// </summary>
            /// <value><c>true</c> if antialiased alpha; otherwise, <c>false</c>.</value>
            public bool AntiAliasedAlpha
            {
                get { return (dwMasks & DrawThemeTextOptionsMasks.Composited) == DrawThemeTextOptionsMasks.Composited; }
                set { SetFlag(DrawThemeTextOptionsMasks.Composited, value); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether text will be drawn on top of the shadow and outline effects
            /// (<c>true</c>) or if just the shadow and outline effects will be drawn (<c>false</c>).
            /// </summary>
            /// <value><c>true</c> if drawn on top; otherwise, <c>false</c>.</value>
            public bool ApplyOverlay
            {
                get { return fApplyOverlay; }
                set
                {
                    fApplyOverlay = value;
                    dwMasks |= DrawThemeTextOptionsMasks.ApplyOverlay;
                }
            }

            /// <summary>Gets or sets the color of the outline that will be drawn around the text.</summary>
            /// <value>The color of the border.</value>
            public Color BorderColor
            {
                get { return ColorTranslator.FromWin32(crBorder); }
                set
                {
                    crBorder = ColorTranslator.ToWin32(value);
                    dwMasks |= DrawThemeTextOptionsMasks.BorderColor;
                }
            }

            /// <summary>Gets or sets the radius of the outline that will be drawn around the text.</summary>
            /// <value>The size of the border.</value>
            public int BorderSize
            {
                get { return iBorderSize; }
                set
                {
                    iBorderSize = value;
                    dwMasks |= DrawThemeTextOptionsMasks.BorderSize;
                }
            }

            /// <summary>Gets or sets the callback function.</summary>
            /// <value>The callback function.</value>
            public DrawThemeTextCallback Callback
            {
                get { return pfnDrawTextCallback; }
                set
                {
                    pfnDrawTextCallback = value;
                    dwMasks |= DrawThemeTextOptionsMasks.Callback;
                }
            }

            /// <summary>Gets or sets the size of a glow that will be drawn on the background prior to any text being drawn.</summary>
            /// <value>The size of the glow.</value>
            public int GlowSize
            {
                get { return iGlowSize; }
                set
                {
                    iGlowSize = value;
                    dwMasks |= DrawThemeTextOptionsMasks.GlowSize;
                }
            }

            /// <summary>Gets or sets the parameter for callback back function specified by <see cref="Callback"/>.</summary>
            /// <value>The parameter.</value>
            public IntPtr LParam
            {
                get { return lParam; }
                set { lParam = value; }
            }

            /// <summary>
            /// Gets or sets a value indicating whether the pRect parameter of the <see cref="DrawThemeTextEx"/> function
            /// that uses this structure will be used as both an in and an out parameter. After the function returns, the
            /// pRect parameter will contain the rectangle that corresponds to the region calculated to be drawn.
            /// </summary>
            /// <value><c>true</c> if returning the calculated rectangle; otherwise, <c>false</c>.</value>
            public bool ReturnCalculatedRectangle
            {
                get { return (dwMasks & DrawThemeTextOptionsMasks.CalcRect) == DrawThemeTextOptionsMasks.CalcRect; }
                set { SetFlag(DrawThemeTextOptionsMasks.CalcRect, value); }
            }

            /// <summary>Gets or sets the color of the shadow drawn behind the text.</summary>
            /// <value>The color of the shadow.</value>
            public Color ShadowColor
            {
                get { return ColorTranslator.FromWin32(crShadow); }
                set
                {
                    crShadow = ColorTranslator.ToWin32(value);
                    dwMasks |= DrawThemeTextOptionsMasks.ShadowColor;
                }
            }

            /// <summary>Gets or sets the amount of offset, in logical coordinates, between the shadow and the text.</summary>
            /// <value>The shadow offset.</value>
            public Point ShadowOffset
            {
                get { return new Point(ptShadowOffset.X, ptShadowOffset.Y); }
                set
                {
                    ptShadowOffset = value;
                    dwMasks |= DrawThemeTextOptionsMasks.ShadowOffset;
                }
            }

            /// <summary>Gets or sets the type of the shadow that will be drawn behind the text.</summary>
            /// <value>The type of the shadow.</value>
            public TextShadowType ShadowType
            {
                get { return iTextShadowType; }
                set
                {
                    iTextShadowType = value;
                    dwMasks |= DrawThemeTextOptionsMasks.ShadowType;
                }
            }

            /// <summary>Gets or sets the color of the text that will be drawn.</summary>
            /// <value>The color of the text.</value>
            public Color TextColor
            {
                get { return ColorTranslator.FromWin32(crText); }
                set
                {
                    crText = ColorTranslator.ToWin32(value);
                    dwMasks |= DrawThemeTextOptionsMasks.TextColor;
                }
            }

            /// <summary>Gets an instance with default values set.</summary>
            public static DrawThemeTextOptions Default => new DrawThemeTextOptions(true);

            private void SetFlag(DrawThemeTextOptionsMasks f, bool value) { if (value) dwMasks |= f; else dwMasks &= ~f; }
        }

        /// <summary>
        /// The Options of What Attributes to Add/Remove
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct WTA_OPTIONS
        {
            public WindowThemeNonClientAttributes Flags;
            public int Mask;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct INTLIST
        {
            public int iValueCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 402)]
            public int[] iValues;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct INTLIST_OLD
        {
            public int iValueCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public int[] iValues;
        }

        /// <summary>
        /// Defines the options for the DrawThemeBackgroundEx function.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class DrawThemeBackgroundOptions
        {
            private int dwSize;
            private DrawThemeBackgroundFlags dwFlags;
            private RECT rcClip;

            [Flags]
            private enum DrawThemeBackgroundFlags
            {
                None = 0,
                /// <summary>The ClipRectangle value is defined.</summary>
                ClipRect = 1,
                /// <summary>Deprecated. Draw transparent and alpha images as solid.</summary>
                DrawSolid = 2,
                /// <summary>Do not draw the border of the part (currently this value is only supported for bgtype=borderfill).</summary>
                OmitBorder = 4,
                /// <summary>Do not draw the content area of the part (currently this value is only supported for bgtype=borderfill).</summary>
                OmitContent = 8,
                /// <summary>Deprecated.</summary>
                ComputingRegion = 16,
                /// <summary>Assume the hdc is mirrored and flip images as appropriate (currently this value is only supported for bgtype=imagefile).</summary>
                HasMirroredDC = 32,
                /// <summary>Do not mirror the output; even in right-to-left (RTL) layout.</summary>
                DoNotMirror = 64
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="DrawThemeBackgroundOptions"/> class.
            /// </summary>
            /// <param name="clipRect">The rectangle to which drawing is clipped.</param>
            public DrawThemeBackgroundOptions(Rectangle? clipRect)
            {
                dwSize = Marshal.SizeOf(this);
                ClipRectangle = clipRect;
            }

            /// <summary>Gets or sets the bounding rectangle of the clip region.</summary>
            /// <value>The clip rectangle.</value>
            public Rectangle? ClipRectangle
            {
                get
                {
                    Rectangle r = rcClip;
                    return r.IsEmpty ? (Rectangle?)null : r;
                }
                set
                {
                    rcClip = value ?? default(RECT);
                    SetFlag(DrawThemeBackgroundFlags.ClipRect, value.HasValue);
                }
            }

            /// <summary>Gets or sets a value indicating whether omit drawing the border.</summary>
            /// <value><c>true</c> if omit border; otherwise, <c>false</c>.</value>
            public bool OmitBorder { get { return GetFlag(DrawThemeBackgroundFlags.OmitBorder); } set { SetFlag(DrawThemeBackgroundFlags.OmitBorder, value); } }

            /// <summary>Gets or sets a value indicating whether omit drawing the content area of the part.</summary>
            /// <value><c>true</c> if omit content area of the part; otherwise, <c>false</c>.</value>
            public bool OmitContent { get { return GetFlag(DrawThemeBackgroundFlags.OmitContent); } set { SetFlag(DrawThemeBackgroundFlags.OmitContent, value); } }

            /// <summary>Gets or sets a value indicating the hdc is mirrored and flip images as appropriate.</summary>
            /// <value><c>true</c> if mirrored; otherwise, <c>false</c>.</value>
            public bool HasMirroredDC { get { return GetFlag(DrawThemeBackgroundFlags.HasMirroredDC); } set { SetFlag(DrawThemeBackgroundFlags.HasMirroredDC, value); } }

            /// <summary>Gets or sets a value indicating whether to mirror the output; even in right-to-left (RTL) layout.</summary>
            /// <value><c>true</c> if not mirroring; otherwise, <c>false</c>.</value>
            public bool DoNotMirror { get { return GetFlag(DrawThemeBackgroundFlags.DoNotMirror); } set { SetFlag(DrawThemeBackgroundFlags.DoNotMirror, value); } }

            /// <summary>Performs an implicit conversion from <see cref="Rectangle"/> to <see cref="DrawThemeBackgroundOptions"/>.</summary>
            /// <param name="clipRectangle">The clipping rectangle.</param>
            /// <returns>The result of the conversion.</returns>
            public static implicit operator DrawThemeBackgroundOptions(Rectangle clipRectangle) => new DrawThemeBackgroundOptions(clipRectangle);

            private bool GetFlag(DrawThemeBackgroundFlags f) => (dwFlags & f) == f;

            private void SetFlag(DrawThemeBackgroundFlags f, bool value) { if (value) dwFlags |= f; else dwFlags &= ~f; }
        }
    }
}
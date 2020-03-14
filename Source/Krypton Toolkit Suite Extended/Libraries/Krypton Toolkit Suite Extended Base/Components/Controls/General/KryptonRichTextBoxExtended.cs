using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Extended.Base
{
    /// <summary>
    /// A <see cref="KryptonRichTextBox"/> control with some extra features.
    /// </summary>
    [Description("A KryptonRichTextBox control with some extra features."), ToolboxBitmap(typeof(KryptonRichTextBox)), ToolboxItem(true)]
    public class KryptonRichTextBoxExtended : KryptonRichTextBox
    {
        #region Variables
        private int _updating = 0, _oldEventMask = 0;

        private PARAFORMAT _pARAFORMAT;
        #endregion

        #region Constants
        private const double anInch = 14.5;

        private const int WM_USER = 1024;

        private const int EM_FORMATRANGE = 1081;

        private const int EM_SETEVENTMASK = 1073;

        private const int EM_GETPARAFORMAT = 1085;

        private const int EM_SETPARAFORMAT = 1095;

        private const int EM_SETTYPOGRAPHYOPTIONS = 1226;

        private const int WM_SETREDRAW = 11;

        private const int TO_ADVANCEDTYPOGRAPHY = 1;

        private const int PFM_ALIGNMENT = 8;

        private const int SCF_SELECTION = 1;
        #endregion

        #region Properties
#if NET47
        /// <summary>
        /// Gets or sets the selection alignment.
        /// </summary>
        /// <value>
        /// The selection alignment.
        /// </value>
        [DefaultValue(TextAlignment.LEFT), Description("Gets or sets the selection alignment."), Category("Appearance")]
        public new TextAlignment SelectionAlignment
        {
            get
            {
                TextAlignment alignment;

                PARAFORMAT pARAFORMAT = new PARAFORMAT()
                {
                    cbSize = Marshal.SizeOf<PARAFORMAT>(_pARAFORMAT)
                };

                _pARAFORMAT = pARAFORMAT;

                SendMessage(new HandleRef(this, Handle), 1085, 1, ref _pARAFORMAT);

                if ((_pARAFORMAT.dwMask & 8) == 0)
                {
                    alignment = TextAlignment.LEFT;
                }
                else
                {
                    alignment = (TextAlignment)_pARAFORMAT.wAlignment;
                }

                return alignment;
            }

            set
            {
                PARAFORMAT pARAFORMAT = new PARAFORMAT()
                {
                    cbSize = Marshal.SizeOf<PARAFORMAT>(_pARAFORMAT),
                    dwMask = 8,
                    wAlignment = (short)value
                };

                _pARAFORMAT = pARAFORMAT;

                SendMessage(new HandleRef(this, Handle), 1095, 1, ref _pARAFORMAT);
            }
        }
#endif
        #endregion

        #region Constructor
        /// <summary>
        /// Initialises a new instance of the <see cref="KryptonRichTextBoxExtended"/> class.
        /// </summary>
        [DebuggerNonUserCode]
        public KryptonRichTextBoxExtended()
        {
            Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
        }
        #endregion

        #region Methods        
        /// <summary>
        /// Begins the update.
        /// </summary>
        public void BeginUpdate()
        {
            _updating++;

            if (_updating < 1)
            {
                _oldEventMask = SendMessage(new HandleRef(this, Handle), 1073, 0, 0);

                SendMessage(new HandleRef(this, Handle), 11, 0, 0);
            }
        }

        /// <summary>
        /// Ends the update.
        /// </summary>
        public void EndUpdate()
        {
            _updating--;

            if (_updating < 0)
            {
                SendMessage(new HandleRef(this, Handle), 11, 1, 0);

                SendMessage(new HandleRef(this, Handle), 1073, 0, _oldEventMask);
            }
        }

#if NET47
        /// <summary>Prints the specified character from.</summary>
        /// <param name="charFrom">The character from.</param>
        /// <param name="charTo">The character to.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        public int Print(int charFrom, int charTo, PrintPageEventArgs e)
        {
            CHARRANGE cHARRANGE = new CHARRANGE();

            FORMATRANGE fORMATRANGE = new FORMATRANGE();

            RECT rECT = new RECT(), rECT1 = new RECT();

            cHARRANGE.cpMin = charFrom;

            cHARRANGE.cpMax = charTo;

            Rectangle marginBounds = e.MarginBounds;

            rECT1.Top = checked((int)Math.Round((double)marginBounds.Top * 14.4));

            marginBounds = e.MarginBounds;

            rECT1.Bottom = checked((int)Math.Round((double)marginBounds.Bottom * 14.4));

            marginBounds = e.MarginBounds;

            rECT1.Left = checked((int)Math.Round((double)marginBounds.Left * 14.4));

            marginBounds = e.MarginBounds;

            rECT1.Right = checked((int)Math.Round((double)marginBounds.Right * 14.4));

            marginBounds = e.PageBounds;

            rECT.Top = checked((int)Math.Round((double)marginBounds.Top * 14.4));

            marginBounds = e.PageBounds;

            rECT.Bottom = checked((int)Math.Round((double)marginBounds.Bottom * 14.4));

            marginBounds = e.PageBounds;

            rECT.Left = checked((int)Math.Round((double)marginBounds.Left * 14.4));

            marginBounds = e.PageBounds;

            rECT.Right = checked((int)Math.Round((double)marginBounds.Right * 14.4));

            IntPtr hdc = e.Graphics.GetHdc();

            fORMATRANGE.chrg = cHARRANGE;

            fORMATRANGE.hdc = hdc;

            fORMATRANGE.hdcTarget = hdc;

            fORMATRANGE.rc = rECT1;

            fORMATRANGE.rcPage = rECT;

            IntPtr zero = IntPtr.Zero, intPtr = IntPtr.Zero;

            intPtr = new IntPtr(1);

            IntPtr zero1 = IntPtr.Zero;

            zero1 = Marshal.AllocCoTaskMem(Marshal.SizeOf<FORMATRANGE>(fORMATRANGE));

            Marshal.StructureToPtr<FORMATRANGE>(fORMATRANGE, zero1, false);

            zero = SendMessage(Handle, 1081, intPtr, zero1);

            Marshal.FreeCoTaskMem(zero1);

            e.Graphics.ReleaseHdc(hdc);

            return zero.ToInt32();
        }
#endif
        #endregion

        #region Overrides        
        /// <summary>
        /// Raises the <see cref="E:HandleCreated" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            SendMessage(new HandleRef(this, Handle), 1226, 1, 1);
        }
        #endregion

        #region WIN32 API Calls
        [DllImport("USER32", CharSet = CharSet.Ansi, EntryPoint = "SendMessageA", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        [DllImport("user32", CharSet = CharSet.Auto, ExactSpelling = false)]
        private static extern int SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);

        [DllImport("user32", CharSet = CharSet.Auto, ExactSpelling = false)]
        private static extern int SendMessage(HandleRef hWnd, int msg, int wParam, ref PARAFORMAT lp);
        #endregion

        #region Structs
        private struct CHARRANGE
        {
            public int cpMin;

            public int cpMax;
        }

        private struct FORMATRANGE
        {
            public IntPtr hdc;

            public IntPtr hdcTarget;

            public KryptonRichTextBoxExtended.RECT rc;

            public KryptonRichTextBoxExtended.RECT rcPage;

            public KryptonRichTextBoxExtended.CHARRANGE chrg;
        }

        private struct PARAFORMAT
        {
            public int cbSize;

            public uint dwMask;

            public short wNumbering;

            public short wReserved;

            public int dxStartIndent;

            public int dxRightIndent;

            public int dxOffset;

            public short wAlignment;

            public short cTabCount;

            public int[] rgxTabs;

            public int dySpaceBefore;

            public int dySpaceAfter;

            public int dyLineSpacing;

            public short sStyle;

            public byte bLineSpacingRule;

            public byte bOutlineLevel;

            public short wShadingWeight;

            public short wShadingStyle;

            public short wNumberingStart;

            public short wNumberingStyle;

            public short wNumberingTab;

            public short wBorderSpace;

            public short wBorderWidth;

            public short wBorders;
        }

        private struct RECT
        {
            public int Left;

            public int Top;

            public int Right;

            public int Bottom;
        }
        #endregion
    }
}
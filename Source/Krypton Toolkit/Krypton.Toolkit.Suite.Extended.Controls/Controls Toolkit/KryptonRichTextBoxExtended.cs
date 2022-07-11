﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    public class KryptonRichTextBoxExtended : KryptonTextBox
    {
        #region Instance Fields

        private int _oldEventMask = 0;

        private int _updating = 0;

        private NativeMethods.PARAFORMAT _paraformat;

        #endregion

        #region WIN32 Stuff

        private const double AN_INCH = 14.5;

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

        #region Public

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
                
                NativeMethods.PARAFORMAT pARAFORMAT = new NativeMethods.PARAFORMAT()
                {
                    cbSize = Marshal.SizeOf<NativeMethods.PARAFORMAT>(_paraformat)

                };
                
                _paraformat = pARAFORMAT;

                SendMessage(new HandleRef(this, Handle), 1085, 1, ref _paraformat);

                if ((_paraformat.dwMask & 8) == 0)
                {
                    alignment = TextAlignment.LEFT;
                }
                else
{
                    alignment = (TextAlignment)_paraformat.wAlignment;
                }

                return alignment;
            }

            set
            {
                NativeMethods.PARAFORMAT pARAFORMAT = new NativeMethods.PARAFORMAT()
                {
                    cbSize = Marshal.SizeOf<NativeMethods.PARAFORMAT>(_paraformat),
                    dwMask = 8,
                    wAlignment = (short)value
                };

                _paraformat = pARAFORMAT;

                SendMessage(new HandleRef(this, Handle), 1095, 1, ref _paraformat);
            }
        }

        #endregion

        #region Identity

        /// <summary>
        /// Initialises a new instance of the <see cref="KryptonRichTextBoxExtended"/> class.
        /// </summary>
        [DebuggerNonUserCode]
        public KryptonRichTextBoxExtended()
        {
            Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        #endregion

        #region Implementation

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

        /// <summary>Prints the specified character from.</summary>
        /// <param name="charFrom">The character from.</param>
        /// <param name="charTo">The character to.</param>
        /// <param name="e">The <see cref="PrintPageEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        public int Print(int charFrom, int charTo, PrintPageEventArgs e)
        {
            NativeMethods.CHARRANGE cHARRANGE = new NativeMethods.CHARRANGE();

            NativeMethods.FORMATRANGE fORMATRANGE = new NativeMethods.FORMATRANGE();

            NativeMethods.KryptonRichTextBoxExtendedRECT rECT, rECT1 = new NativeMethods.KryptonRichTextBoxExtendedRECT();

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

            zero1 = Marshal.AllocCoTaskMem(Marshal.SizeOf<NativeMethods.FORMATRANGE>(fORMATRANGE));

            Marshal.StructureToPtr<NativeMethods.FORMATRANGE>(fORMATRANGE, zero1, false);

            zero = SendMessage(Handle, 1081, intPtr, zero1);

            Marshal.FreeCoTaskMem(zero1);

            e.Graphics.ReleaseHdc(hdc);

            return zero.ToInt32();
        }

        #endregion

        #region Overrides

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
        private static extern int SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.PARAFORMAT lp);
        #endregion
    }
}
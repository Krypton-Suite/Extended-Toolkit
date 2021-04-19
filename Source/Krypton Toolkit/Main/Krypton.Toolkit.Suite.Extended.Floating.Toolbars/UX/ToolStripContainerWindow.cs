#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Floating.Toolbars
{
    public class ToolStripContainerWindow : KryptonForm
    {
        #region Designer Code
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ToolStripContainerWindow
            // 
            this.ClientSize = new System.Drawing.Size(710, 26);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ToolStripContainerWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ToolStripContainerForm";
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private FloatableToolStrip _floatableToolStrip;

        private int _dFrameWidth = 8, _captionWidth = 18, _maxWidth = 0, _minWidth = 0;
        #endregion

        #region Properties
        public FloatableToolStrip FloatableToolStrip
        {
            get => _floatableToolStrip;

            set
            {
                _floatableToolStrip = value;

                if (_floatableToolStrip != null)
                {
                    Text = _floatableToolStrip.FloatingToolBarWindowText;

                    SuspendLayout();

                    _floatableToolStrip.Dock = DockStyle.Top;

                    _floatableToolStrip.LayoutStyle = ToolStripLayoutStyle.Flow;

                    Controls.Add(_floatableToolStrip);

                    ResumeLayout();

                    _maxWidth = _floatableToolStrip.PreferredSize.Width + _dFrameWidth;

                    CalculateMinimumWidth();

                    Size = new Size(_maxWidth, _floatableToolStrip.PreferredSize.Height + _dFrameWidth + _captionWidth);
                }
            }
        }
        #endregion

        #region Runtime Routines
        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        static extern int GetMenuItemCount(IntPtr hMenu);

        [DllImport("user32.dll")]
        static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);
        #endregion

        #region Constants
        //private const int SC_SIZE = 0xF000;
        //private const int SC_MOVE = 0xF010;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_RESTORE = 0xF120;
        private const int MF_BYCOMMAND = 0x0000;
        //private const int MF_BYPOSITION = 0x400;

        //private const int SC_NEXTWINDOW = 0xF040;
        //private const int SC_PREVWINDOW = 0xF050;
        //private const int SC_CLOSE = 0xF060;
        //private const int SC_VSCROLL = 0xF070;
        //private const int SC_HSCROLL = 0xF080;
        //private const int SC_MOUSEMENU = 0xF090;
        //private const int SC_KEYMENU = 0xF100;
        //private const int SC_ARRANGE = 0xF110;

        //private const int SC_TASKLIST = 0xF130;
        //private const int SC_SCREENSAVE = 0xF140;
        //private const int SC_HOTKEY = 0xF150;

        private const int WM_NCLBUTTONDBLCLK = 0xA3;
        #endregion

        #region Event Handlers
        public event EventHandler NCLBUTTONDBLCLK;
        #endregion

        #region Constructor
        public ToolStripContainerWindow()
        {
            InitializeComponent();

            _dFrameWidth = (Width - ClientSize.Width);

            _captionWidth = Height - ClientSize.Height - _dFrameWidth;

            IntPtr pm = GetSystemMenu(Handle, false);

            RemoveMenu(pm, SC_RESTORE, MF_BYCOMMAND);

            RemoveMenu(pm, SC_MINIMIZE, MF_BYCOMMAND);

            RemoveMenu(pm, SC_MAXIMIZE, MF_BYCOMMAND);
        }
        #endregion

        #region Methods
        private void CalculateMinimumWidth()
        {
            foreach (ToolStripItem items in _floatableToolStrip.Items)
            {
                if (items.Width > _minWidth)
                {
                    _minWidth = items.Width;
                }
            }

            _minWidth += (_dFrameWidth + 3);

            if (_minWidth < 46)
            {
                _minWidth = 48 + _dFrameWidth;
            }
        }
        #endregion

        #region Overrides
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_floatableToolStrip != null)
            {
                Height = _floatableToolStrip.Size.Height + _dFrameWidth + _captionWidth;

                if (Width > _maxWidth)
                {
                    Width = _maxWidth;
                }
                else if (Width < (_minWidth + 23))
                {
                    Width = _minWidth;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                if (NCLBUTTONDBLCLK != null)
                {
                    NCLBUTTONDBLCLK(this, new EventArgs());
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        #endregion
    }
}
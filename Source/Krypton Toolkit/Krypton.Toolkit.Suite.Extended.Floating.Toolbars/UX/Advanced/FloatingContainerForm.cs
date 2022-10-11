namespace Krypton.Toolkit.Suite.Extended.Floating.Toolbars
{
    public partial class FloatingContainerForm : KryptonForm
    {
        #region Instance Fields

        private bool _showWindowFrame;

        private FloatableMenuStrip _floatableMenuStrip;

        private FloatableToolStrip _floatableToolStrip;

        private int _dFrameWidth = 8, _captionWidth = 18, _maxWidth = 0, _minWidth = 0;

        #endregion

        #region Public

        public bool ShowWindowFrame { get => _showWindowFrame; set { _showWindowFrame = value; Invalidate(); } }

        public FloatableMenuStrip FloatableMenuStrip
        {
            get => _floatableMenuStrip;

            set
            {
                if (_floatableMenuStrip != null && _floatableMenuStrip != value)
                {
                    _floatableMenuStrip = value;
                }
            }
        }

        public FloatableToolStrip FloatableToolStrip
        {
            get => _floatableToolStrip;

            set
            {
                if (_floatableToolStrip != null && _floatableToolStrip != value)
                {
                    _floatableToolStrip = value;
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

        #region Identity

        public FloatingContainerForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void CalculateMinimumWidth()
        {
            if (_floatableMenuStrip != null)
            {
                foreach (ToolStripItem item in _floatableMenuStrip.Items)
                {
                    if (item.Width > _minWidth)
                    {
                        _minWidth = item.Width;
                    }
                }

                _minWidth += (_dFrameWidth + 3);

                if (_minWidth < 46)
                {
                    _minWidth = 48 + _dFrameWidth;
                }
            }
            else if (_floatableToolStrip != null)
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
        }

        private void FloatingContainerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NCLBUTTONDBLCLK != null)
            {
                NCLBUTTONDBLCLK(this, new());
            }
        }

        #endregion

        #region Overrides

        protected override void OnResize(EventArgs e)
        {
            if (_floatableMenuStrip != null)
            {
                Height = _floatableMenuStrip.Size.Height + _dFrameWidth + _captionWidth;

                if (Width > _maxWidth)
                {
                    Width = _maxWidth;
                }
                else if (Width < (_minWidth + 23))
                {
                    Width = _minWidth;
                }
            }
            else if (_floatableToolStrip != null)
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

            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_showWindowFrame)
            {
                FormBorderStyle = FormBorderStyle.Fixed3D;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
            }

            if (_floatableMenuStrip != null)
            {
                FloatableToolStrip = null;
            }
            else if (_floatableToolStrip != null)
            {
                FloatableMenuStrip = null;
            }

            base.OnPaint(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                if (NCLBUTTONDBLCLK != null)
                {
                    NCLBUTTONDBLCLK(this, new());
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

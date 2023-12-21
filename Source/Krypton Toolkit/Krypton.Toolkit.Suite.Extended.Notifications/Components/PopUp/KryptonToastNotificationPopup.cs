#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    /// <summary>
    /// Non-visual component to show a notification window in the right lower
    /// corner of the screen. Created/modified in 2011 by Simon Baer
    /// Based on the Code Project article by Nicolas Wälti:
    /// http://www.codeproject.com/KB/cpp/PopupNotifier.aspx
    /// </summary>
    [ToolboxBitmap(typeof(KryptonToastNotificationPopup)), DefaultEvent("Click")]
    public class KryptonToastNotificationPopup : Component
    {
        #region Windows API
        private const int SW_SHOWNOACTIVATE = 4;
        private const int HWND_TOPMOST = -1;
        private const uint SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
         int hWnd,             // Window handle
         int hWndInsertAfter,  // Placement-order handle
         int x,                // Horizontal position
         int y,                // Vertical position
         int cx,               // Width
         int cy,               // Height
         uint uFlags);         // Window positioning flags

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void ShowInactiveTopmost(KryptonForm frm)
        {
            ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
            SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
            frm.Left, frm.Top, frm.Width, frm.Height,
            SWP_NOACTIVATE);
        }
        #endregion

        #region Events
        /// <summary>
        /// Event that is raised when the text in the notification window is clicked.
        /// </summary>
        public event EventHandler Click;

        /// <summary>
        /// Event that is raised when the notification window is manually closed.
        /// </summary>
        public event EventHandler Close;

        /// <summary>
        /// Event that is raised when the notification Appears.
        /// </summary>
        public event EventHandler Appear;

        /// <summary>
        /// Event that is raised when the notification Disappears 
        /// </summary>
        public event EventHandler Disappear;
        #endregion

        #region Variables
        private bool _disposed = false;
        private KryptonPopUpNotificationWindow _frmPopup;
        private Timer _tmrAnimation, _tmrWait;

        private bool _isAppearing = true;
        private bool _markedForDisposed = false;
        private bool _mouseIsOn = false;
        private int _maxPosition;
        private double _maxOpacity;
        private int _posStart;
        private int _posStop;
        private double _opacityStart;
        private double _opacityStop;
        private int _realAnimationDuration;
        private Stopwatch _sw;
        #endregion

        #region Properties
        [Category("Header"), DefaultValue(typeof(Color), "ControlDark")]
        [Description("Colour of the window header.")]
        public Color HeaderColour { get; set; }

        [Category("Appearance"), DefaultValue(typeof(Color), "Control")]
        [Description("Colour of the window background.")]
        public Color BodyColour { get; set; }

        [Category("Title"), DefaultValue(typeof(Color), "Gray")]
        [Description("Colour of the title text.")]
        public Color TitleColour { get; set; }

        [Category("Content"), DefaultValue(typeof(Color), "ControlText")]
        [Description("Colour of the content text.")]
        public Color ContentColour { get; set; }

        [Category("Appearance"), DefaultValue(typeof(Color), "WindowFrame")]
        [Description("Colour of the window border.")]
        public Color BorderColour { get; set; }

        [Category("Buttons"), DefaultValue(typeof(Color), "WindowFrame")]
        [Description("Border colour of the close and options buttons when the mouse is over them.")]
        public Color ButtonBorderColour { get; set; }

        [Category("Buttons"), DefaultValue(typeof(Color), "Highlight")]
        [Description("Background colour of the close and options buttons when the mouse is over them.")]
        public Color ButtonHoverColour { get; set; }

        [Category("Content"), DefaultValue(typeof(Color), "HotTrack")]
        [Description("Colour of the content text when the mouse is hovering over it.")]
        public Color ContentHoverColour { get; set; }

        [Category("Appearance"), DefaultValue(50)]
        [Description("Gradient of window background colour.")]
        public int GradientPower { get; set; }

        [Category("Content")]
        [Description("Font of the content text.")]
        public Font ContentFont { get; set; }

        [Category("Title")]
        [Description("Font of the title.")]
        public Font TitleFont { get; set; }

        [Category("Image")]
        [Description("Size of the icon image.")]
        public Size ImageSize
        {
            get
            {
                if (_imageSize.Width == 0)
                {
                    if (Image != null)
                    {
                        return Image.Size;
                    }
                    else
                    {
                        return new Size(0, 0);
                    }
                }
                else
                {
                    return _imageSize;
                }
            }
            set => _imageSize = value;
        }

        public void ResetImageSize()
        {
            _imageSize = Size.Empty;
        }

        private bool ShouldSerializeImageSize()
        {
            return (!_imageSize.Equals(Size.Empty));
        }

        private Size _imageSize = new Size(0, 0);

        [Category("Image")]
        [Description("Icon image to display.")]
        public Image? Image { get; set; }

        [Category("Header"), DefaultValue(true)]
        [Description("Whether to show a 'grip' image within the window header.")]
        public bool ShowGrip { get; set; }

        [Category("Behavior"), DefaultValue(true)]
        [Description("Whether to scroll the window or only fade it.")]
        public bool Scroll { get; set; }

        [Category("Content")]
        [Description("Content text to display.")]
        public string ContentText { get; set; }

        [Category("Title")]
        [Description("Title text to display.")]
        public string TitleText { get; set; }

        [Category("Title")]
        [Description("Padding of title text.")]
        public Padding TitlePadding { get; set; }

        private void ResetTitlePadding()
        {
            TitlePadding = Padding.Empty;
        }

        private bool ShouldSerializeTitlePadding()
        {
            return (!TitlePadding.Equals(Padding.Empty));
        }

        [Category("Content")]
        [Description("Padding of content text.")]
        public Padding ContentPadding { get; set; }

        private void ResetContentPadding()
        {
            ContentPadding = Padding.Empty;
        }

        private bool ShouldSerializeContentPadding()
        {
            return (!ContentPadding.Equals(Padding.Empty));
        }

        [Category("Image")]
        [Description("Padding of icon image.")]
        public Padding ImagePadding { get; set; }

        private void ResetImagePadding()
        {
            ImagePadding = Padding.Empty;
        }

        private bool ShouldSerializeImagePadding()
        {
            return (!ImagePadding.Equals(Padding.Empty));
        }

        [Category("Header"), DefaultValue(9)]
        [Description("Height of window header.")]
        public int HeaderHeight { get; set; }

        [Category("Buttons"), DefaultValue(true)]
        [Description("Whether to show the close button.")]
        public bool ShowCloseButton { get; set; }

        [Category("Buttons"), DefaultValue(false)]
        [Description("Whether to show the options button.")]
        public bool ShowOptionsButton { get; set; }

        [Category("Behavior")]
        [Description("Context menu to open when clicking on the options button.")]
        public ContextMenuStrip OptionsMenu { get; set; }

        [Category("Behavior"), DefaultValue(3000)]
        [Description("Time in milliseconds the window is displayed.")]
        public int Delay { get; set; }

        [Category("Behavior"), DefaultValue(1000)]
        [Description("Time in milliseconds needed to make the window appear or disappear.")]
        public int AnimationDuration { get; set; }

        [Category("Behavior"), DefaultValue(10)]
        [Description("Interval in milliseconds used to draw the animation.")]
        public int AnimationInterval { get; set; }

        [Category("Appearance")]
        [Description("Size of the window.")]
        public Size Size { get; set; }

        [Category("Content")]
        [Description("Show Content Right To Left,نمایش پیغام چپ به راست فعال شود")]
        public bool IsRightToLeft { get; set; }
        #endregion

        #region Constructor
        public KryptonToastNotificationPopup()
        {
            HeaderColour = SystemColors.ControlDark;
            BodyColour = SystemColors.Control;
            TitleColour = System.Drawing.Color.Gray;
            ContentColour = SystemColors.ControlText;
            BorderColour = SystemColors.WindowFrame;
            ButtonBorderColour = SystemColors.WindowFrame;
            ButtonHoverColour = SystemColors.Highlight;
            ContentHoverColour = SystemColors.HotTrack;
            GradientPower = 50;
            ContentFont = SystemFonts.DialogFont;
            TitleFont = SystemFonts.CaptionFont;
            ShowGrip = true;
            Scroll = true;
            TitlePadding = new Padding(0);
            ContentPadding = new Padding(0);
            ImagePadding = new Padding(0);
            HeaderHeight = 9;
            ShowCloseButton = true;
            ShowOptionsButton = false;
            Delay = 3000;
            AnimationInterval = 10;
            AnimationDuration = 1000;
            Size = new Size(400, 100);

            _frmPopup = new KryptonPopUpNotificationWindow(this);
            _frmPopup.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            _frmPopup.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            _frmPopup.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            _frmPopup.MouseEnter += new EventHandler(frmPopup_MouseEnter);
            _frmPopup.MouseLeave += new EventHandler(frmPopup_MouseLeave);
            _frmPopup.CloseClick += new EventHandler(frmPopup_CloseClick);
            _frmPopup.LinkClick += new EventHandler(frmPopup_LinkClick);
            _frmPopup.ContextMenuOpened += new EventHandler(frmPopup_ContextMenuOpened);
            _frmPopup.ContextMenuClosed += new EventHandler(frmPopup_ContextMenuClosed);
            _frmPopup.VisibleChanged += new EventHandler(frmPopup_VisibleChanged);

            _tmrAnimation = new System.Windows.Forms.Timer();
            _tmrAnimation.Tick += new EventHandler(tmAnimation_Tick);

            _tmrWait = new System.Windows.Forms.Timer();
            _tmrWait.Tick += new EventHandler(tmWait_Tick);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Show the notification window if it is not already visible.
        /// If the window is currently disappearing, it is shown again.
        /// </summary>
        public void PopUp()
        {
            if (!_disposed)
            {
                if (!_frmPopup.Visible)
                {
                    _frmPopup.Size = Size;
                    if (Scroll)
                    {
                        _posStart = Screen.PrimaryScreen.WorkingArea.Bottom;
                        _posStop = Screen.PrimaryScreen.WorkingArea.Bottom - _frmPopup.Height;
                    }
                    else
                    {
                        _posStart = Screen.PrimaryScreen.WorkingArea.Bottom - _frmPopup.Height;
                        _posStop = Screen.PrimaryScreen.WorkingArea.Bottom - _frmPopup.Height;
                    }
                    _opacityStart = 0;
                    _opacityStop = 1;

                    _frmPopup.Opacity = _opacityStart;
                    _frmPopup.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - _frmPopup.Size.Width - 1, _posStart);
                    ShowInactiveTopmost(_frmPopup);
                    _isAppearing = true;

                    _tmrWait.Interval = Delay;
                    _tmrAnimation.Interval = AnimationInterval;
                    _realAnimationDuration = AnimationDuration;
                    _tmrAnimation.Start();
                    _sw = Stopwatch.StartNew();
                    Debug.WriteLine("Animation started.");
                }
                else
                {
                    if (!_isAppearing)
                    {
                        _frmPopup.Size = Size;
                        if (Scroll)
                        {
                            _posStart = _frmPopup.Top;
                            _posStop = Screen.PrimaryScreen.WorkingArea.Bottom - _frmPopup.Height;
                        }
                        else
                        {
                            _posStart = Screen.PrimaryScreen.WorkingArea.Bottom - _frmPopup.Height;
                            _posStop = Screen.PrimaryScreen.WorkingArea.Bottom - _frmPopup.Height;
                        }
                        _opacityStart = _frmPopup.Opacity;
                        _opacityStop = 1;
                        _isAppearing = true;
                        _realAnimationDuration = Math.Max((int)_sw.ElapsedMilliseconds, 1);
                        _sw.Restart();
                        Debug.WriteLine("Animation direction changed.");
                    }
                    _frmPopup.Invalidate();
                }
            }
        }

        /// <summary>
        /// Hide the notification window.
        /// </summary>
        public void Hide()
        {
            Debug.WriteLine("Animation stopped.");
            Debug.WriteLine("Wait timer stopped.");
            _tmrAnimation.Stop();
            _tmrWait.Stop();
            _frmPopup.Hide();
            if (_markedForDisposed)
            {
                Dispose();
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// The custom options menu has been closed. Restart the timer for
        /// closing the notification window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPopup_ContextMenuClosed(object sender, EventArgs e)
        {
            Debug.WriteLine("Menu closed.");
            if (!_mouseIsOn)
            {
                _tmrWait.Interval = Delay;
                _tmrWait.Start();
                Debug.WriteLine("Wait timer started.");
            }
        }


        /// <summary>
        /// The custom options menu has been opened. The window must not be closed
        /// as long as the menu is open.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPopup_ContextMenuOpened(object sender, EventArgs e)
        {
            Debug.WriteLine("Menu opened.");
            _tmrWait.Stop();
            Debug.WriteLine("Wait timer stopped.");
        }

        /// <summary>
        /// The text has been clicked. Raise the 'Click' event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPopup_LinkClick(object sender, EventArgs e)
        {
            if (Click != null)
            {
                Click(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// The close button has been clicked. Hide the notification window
        /// and raise the 'Close' event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPopup_CloseClick(object sender, EventArgs e)
        {
            Hide();
            if (Close != null)
            {
                Close(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Visibility has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPopup_VisibleChanged(object sender, EventArgs e)
        {
            if (_frmPopup.Visible)
            {
                if (Appear != null)
                {
                    Appear(this, EventArgs.Empty);
                }
            }
            else
            {
                if (Disappear != null)
                {
                    Disappear(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Update form position and opacity to show/hide the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmAnimation_Tick(object sender, EventArgs e)
        {
            long elapsed = _sw.ElapsedMilliseconds;

            int posCurrent = (int)(_posStart + ((_posStop - _posStart) * elapsed / _realAnimationDuration));
            bool neg = (_posStop - _posStart) < 0;
            if ((neg && posCurrent < _posStop) ||
                (!neg && posCurrent > _posStop))
            {
                posCurrent = _posStop;
            }

            double opacityCurrent = _opacityStart + ((_opacityStop - _opacityStart) * elapsed / _realAnimationDuration);
            neg = (_opacityStop - _opacityStart) < 0;
            if ((neg && opacityCurrent < _opacityStop) ||
                (!neg && opacityCurrent > _opacityStop))
            {
                opacityCurrent = _opacityStop;
            }

            _frmPopup.Top = posCurrent;
            _frmPopup.Opacity = opacityCurrent;

            // animation has ended
            if (elapsed > _realAnimationDuration)
            {

                _sw.Reset();
                _tmrAnimation.Stop();
                Debug.WriteLine("Animation stopped.");

                if (_isAppearing)
                {
                    if (Scroll)
                    {
                        _posStart = Screen.PrimaryScreen.WorkingArea.Bottom - _frmPopup.Height;
                        _posStop = Screen.PrimaryScreen.WorkingArea.Bottom;
                    }
                    else
                    {
                        _posStart = Screen.PrimaryScreen.WorkingArea.Bottom - _frmPopup.Height;
                        _posStop = Screen.PrimaryScreen.WorkingArea.Bottom - _frmPopup.Height;
                    }
                    _opacityStart = 1;
                    _opacityStop = 0;

                    _realAnimationDuration = AnimationDuration;

                    _isAppearing = false;
                    _maxPosition = _frmPopup.Top;
                    _maxOpacity = _frmPopup.Opacity;
                    if (!_mouseIsOn)
                    {
                        _tmrWait.Stop();
                        _tmrWait.Start();
                        Debug.WriteLine("Wait timer started.");
                    }
                }
                else
                {
                    _frmPopup.Hide();
                    if (_markedForDisposed)
                    {
                        Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// The wait timer has elapsed, start the animation to hide the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmWait_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Wait timer elapsed.");
            _tmrWait.Stop();
            _tmrAnimation.Interval = AnimationInterval;
            _tmrAnimation.Start();
            _sw.Restart();
            Debug.WriteLine("Animation started.");
        }

        /// <summary>
        /// Start wait timer if the mouse leaves the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPopup_MouseLeave(object sender, EventArgs e)
        {
            Debug.WriteLine("MouseLeave");
            if (_frmPopup.Visible && (OptionsMenu == null || !OptionsMenu.Visible))
            {
                _tmrWait.Interval = Delay;
                _tmrWait.Start();
                Debug.WriteLine("Wait timer started.");
            }
            _mouseIsOn = false;
        }

        /// <summary>
        /// Stop wait timer if the mouse enters the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPopup_MouseEnter(object sender, EventArgs e)
        {
            Debug.WriteLine("MouseEnter");
            if (!_isAppearing)
            {
                _frmPopup.Top = _maxPosition;
                _frmPopup.Opacity = _maxOpacity;
                _tmrAnimation.Stop();
                Debug.WriteLine("Animation stopped.");
            }

            _tmrWait.Stop();
            Debug.WriteLine("Wait timer stopped.");

            _mouseIsOn = true;
        }
        #endregion

        #region Overrides
        /// <summary>Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component">Component</see> and optionally releases the managed resources.</summary>
        /// <param name="disposing">
        ///   <span class="keyword">
        ///     <span class="languageSpecificText">
        ///       <span class="cs">true</span>
        ///       <span class="vb">True</span>
        ///       <span class="cpp">true</span>
        ///     </span>
        ///   </span>
        ///   <span class="nu">
        ///     <span class="keyword">true</span> (<span class="keyword">True</span> in Visual Basic)</span> to release both managed and unmanaged resources; <span class="keyword"><span class="languageSpecificText"><span class="cs">false</span><span class="vb">False</span><span class="cpp">false</span></span></span><span class="nu"><span class="keyword">false</span> (<span class="keyword">False</span> in Visual Basic)</span> to release only unmanaged resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_isAppearing)
                {
                    _markedForDisposed = true;
                    return;
                }

                if (disposing)
                {
                    if (_frmPopup != null)
                    {
                        _frmPopup.Dispose();
                    }

                    _tmrAnimation.Tick -= tmAnimation_Tick;
                    _tmrWait.Tick -= tmWait_Tick;
                    _tmrAnimation.Dispose();
                    _tmrWait.Dispose();

                }
                _disposed = true;
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}
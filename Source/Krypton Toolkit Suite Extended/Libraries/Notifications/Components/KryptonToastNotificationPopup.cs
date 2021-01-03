using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    /// <summary>
    /// Non-visual component to show a notification window in the right lower
    /// corner of the screen. Adapted from: https://github.com/Tulpep/Notification-Popup-Window/blob/master/Tulpep.NotificationWindow/PopupNotifier.cs
    /// </summary>
    [ToolboxBitmap(typeof(KryptonToastNotificationPopup), "Resources.KR 48 x 48 Orange.ico"), DefaultEvent("Click")]
    public class KryptonToastNotificationPopup : Component
    {
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
        /// Event that is raised when the notification Disappears.
        /// </summary>
        public event EventHandler Disappear;
        #endregion

        #region Variables
        private bool _disposed = false, _isAppearing = true, _mouseIsOn = false;
        private double _maximumOpacity, _startOpacity, _stopOpacity;
        private int _maximumPosition, _startPosition, _stopPosision, _realAnimationDuration;
        private Timer _animationTimer, _waitTimer;
        private Stopwatch _stopwatch;
        private Size _imageSize = new Size(0, 0);
        private KryptonPalette _palette;
        private KryptonToastNotificationPopupForm _toastNotificationPopupForm;
        private Point _notificationLocationPosition;
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

        [Category("Appearance"), Description("Set or get a custom location for the notification.")]
        public Point NotificationLocationPosition { get => _notificationLocationPosition; set => _notificationLocationPosition = value; }

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
            set { _imageSize = value; }
        }

        [Category("Image")]
        [Description("Icon image to display.")]
        public Image Image { get; set; }

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

        [Category("Content")]
        [Description("Padding of content text.")]
        public Padding ContentPadding { get; set; }

        [Category("Image")]
        [Description("Padding of icon image.")]
        public Padding ImagePadding { get; set; }

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
        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonToastNotificationPopup"/> class.
        /// </summary>
        public KryptonToastNotificationPopup()
        {
            // Set default values
            //? TODO: Use krypton values
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

            AnimationDuration = 1000;

            AnimationInterval = 10;

            Size = new Size(400, 100);

            NotificationLocationPosition = new Point(Screen.PrimaryScreen.WorkingArea.Right - _toastNotificationPopupForm.Size.Width - 1, _startPosition);

            _toastNotificationPopupForm = new KryptonToastNotificationPopupForm(this);

            _toastNotificationPopupForm.TopMost = true;

            _toastNotificationPopupForm.FormBorderStyle = FormBorderStyle.None;

            _toastNotificationPopupForm.StartPosition = FormStartPosition.Manual;

            _toastNotificationPopupForm.FormBorderStyle = FormBorderStyle.None;

            _toastNotificationPopupForm.MouseEnter += ToastNotificationPopupForm_MouseEnter;

            _toastNotificationPopupForm.MouseLeave += ToastNotificationPopupForm_MouseLeave;

            _toastNotificationPopupForm.CloseClick += ToastNotificationPopupForm_CloseClick;

            _toastNotificationPopupForm.LinkClick += ToastNotificationPopupForm_LinkClick;

            _toastNotificationPopupForm.ContextMenuOpened += ToastNotificationPopupForm_ContextMenuOpened;

            _toastNotificationPopupForm.ContextMenuClosed += ToastNotificationPopupForm_ContextMenuClosed;

            _toastNotificationPopupForm.VisibleChanged += ToastNotificationPopupForm_VisibleChanged;

            _animationTimer = new Timer();

            _animationTimer.Tick += AnimationTimer_Tick;

            _waitTimer = new Timer();

            _waitTimer.Tick += WaitTimer_Tick;
        }
        #endregion

        #region Event Handlers
        private void WaitTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Wait timer elapsed.");

            _waitTimer.Stop();

            _animationTimer.Interval = AnimationInterval;

            _animationTimer.Start();

            _stopwatch.Restart();

            Debug.WriteLine("Animation started.");
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            long _elapsed = _stopwatch.ElapsedMilliseconds;

            int _currentPosition = (int)(_startPosition + ((_stopPosision - _startPosition) * _elapsed / _realAnimationDuration));

            bool _neg = (_stopPosision - _startPosition) < 0;

            if ((_neg && _currentPosition < _stopPosision) || (!_neg && _currentPosition > _stopPosision)) _currentPosition = _stopPosision;

            double _currentOpacity = _startOpacity + ((_stopOpacity - _startOpacity) * _elapsed / _realAnimationDuration);

            _neg = (_stopOpacity - _startOpacity) < 0;

            if ((_neg && _currentOpacity < _stopOpacity) || (!_neg && _currentOpacity > _stopOpacity)) _currentOpacity = _stopOpacity;

            _toastNotificationPopupForm.Top = _currentPosition;

            _toastNotificationPopupForm.Opacity = _currentOpacity;

            if (_elapsed > _realAnimationDuration)
            {
                _stopwatch.Reset();

                _animationTimer.Stop();

                Debug.WriteLine("Animation stopped.");

                if (_isAppearing)
                {
                    if (Scroll)
                    {
                        _startPosition = Screen.PrimaryScreen.WorkingArea.Bottom - _toastNotificationPopupForm.Height;

                        _stopPosision = Screen.PrimaryScreen.WorkingArea.Bottom;
                    }
                    else
                    {
                        _startPosition = Screen.PrimaryScreen.WorkingArea.Bottom - _toastNotificationPopupForm.Height;

                        _stopPosision = Screen.PrimaryScreen.WorkingArea.Bottom - _toastNotificationPopupForm.Height;
                    }

                    _startOpacity = 1;

                    _stopOpacity = 0;

                    _realAnimationDuration = AnimationDuration;

                    _isAppearing = false;

                    _maximumPosition = _toastNotificationPopupForm.Top;

                    _maximumOpacity = _toastNotificationPopupForm.Opacity;

                    if (!_mouseIsOn)
                    {
                        _waitTimer.Stop();

                        _waitTimer.Start();

                        Debug.WriteLine("Wait timer started.");
                    }
                }
                else
                {
                    _toastNotificationPopupForm.Hide();
                }
            }
        }

        private void ToastNotificationPopupForm_CloseClick(object sender, EventArgs e)
        {
            Hide();

            if (Close != null)
            {
                Close(this, EventArgs.Empty);
            }
        }

        private void ToastNotificationPopupForm_MouseLeave(object sender, EventArgs e)
        {
            Debug.WriteLine("MouseLeave");

            if (_toastNotificationPopupForm.Visible && (OptionsMenu == null || !OptionsMenu.Visible))
            {
                _waitTimer.Interval = Delay;

                _waitTimer.Start();

                Debug.WriteLine("Wait timer started.");
            }

            _mouseIsOn = false;
        }

        private void ToastNotificationPopupForm_MouseEnter(object sender, EventArgs e)
        {
            Debug.WriteLine("MouseEnter");

            if (!_isAppearing)
            {
                _toastNotificationPopupForm.Top = _maximumPosition;

                _toastNotificationPopupForm.Opacity = _maximumOpacity;

                _animationTimer.Stop();

                Debug.WriteLine("Animation stopped.");
            }

            _waitTimer.Stop();

            Debug.WriteLine("Wait timer stopped.");

            _mouseIsOn = true;
        }

        private void ToastNotificationPopupForm_VisibleChanged(object sender, EventArgs e)
        {
            if (_toastNotificationPopupForm.Visible)
            {
                if (Appear != null) Appear(this, EventArgs.Empty);
            }
            else
            {
                if (Disappear != null) Disappear(this, EventArgs.Empty);
            }
        }

        private void ToastNotificationPopupForm_ContextMenuClosed(object sender, EventArgs e)
        {
            Debug.WriteLine("Menu closed.");

            if (!_mouseIsOn)
            {
                _waitTimer.Interval = Delay;

                _waitTimer.Start();

                Debug.WriteLine("Wait timer started.");
            }
        }

        private void ToastNotificationPopupForm_ContextMenuOpened(object sender, EventArgs e)
        {
            Debug.WriteLine("Menu opened.");

            _waitTimer.Stop();

            Debug.WriteLine("Wait timer stopped.");
        }

        private void ToastNotificationPopupForm_LinkClick(object sender, EventArgs e)
        {
            if (Click != null)
            {
                Click(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Methods
        public void ResetImageSize()
        {
            _imageSize = Size.Empty;
        }

        private bool ShouldSerializeImageSize()
        {
            return (!_imageSize.Equals(Size.Empty));
        }

        private void ResetTitlePadding()
        {
            TitlePadding = Padding.Empty;
        }

        private bool ShouldSerializeTitlePadding()
        {
            return (!TitlePadding.Equals(Padding.Empty));
        }

        private void ResetContentPadding()
        {
            ContentPadding = Padding.Empty;
        }

        private bool ShouldSerializeContentPadding()
        {
            return (!ContentPadding.Equals(Padding.Empty));
        }

        private void ResetImagePadding()
        {
            ImagePadding = Padding.Empty;
        }

        private bool ShouldSerializeImagePadding()
        {
            return (!ImagePadding.Equals(Padding.Empty));
        }

        /// <summary>
        /// Show the notification window if it is not already visible.
        /// If the window is currently disappearing, it is shown again.
        /// </summary>
        public void Popup()
        {
            if (!_disposed)
            {
                if (!_toastNotificationPopupForm.Visible)
                {
                    _toastNotificationPopupForm.Size = Size;
                    if (Scroll)
                    {
                        _startPosition = Screen.PrimaryScreen.WorkingArea.Bottom;
                        _stopPosision = Screen.PrimaryScreen.WorkingArea.Bottom - _toastNotificationPopupForm.Height;
                    }
                    else
                    {
                        _startPosition = Screen.PrimaryScreen.WorkingArea.Bottom - _toastNotificationPopupForm.Height;
                        _stopPosision = Screen.PrimaryScreen.WorkingArea.Bottom - _toastNotificationPopupForm.Height;
                    }
                    _startOpacity = 0;
                    _stopOpacity = 1;

                    _toastNotificationPopupForm.Opacity = _stopOpacity;

                    // Use custom location
                    if (_notificationLocationPosition != Point.Empty)
                    {
                        _toastNotificationPopupForm.Location = _notificationLocationPosition;
                    }
                    else
                    {
                        // Bottom right
                        _toastNotificationPopupForm.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - _toastNotificationPopupForm.Size.Width - 1, _startPosition);
                    }

                    _toastNotificationPopupForm.Visible = true;
                    _isAppearing = true;

                    _waitTimer.Interval = Delay;
                    _animationTimer.Interval = AnimationInterval;
                    _realAnimationDuration = AnimationDuration;
                    _animationTimer.Start();
                    _stopwatch = System.Diagnostics.Stopwatch.StartNew();
                    System.Diagnostics.Debug.WriteLine("Animation started.");
                }
                else
                {
                    if (!_isAppearing)
                    {
                        _toastNotificationPopupForm.Size = Size;
                        if (Scroll)
                        {
                            _startPosition = _toastNotificationPopupForm.Top;
                            _stopPosision = Screen.PrimaryScreen.WorkingArea.Bottom - _toastNotificationPopupForm.Height;
                        }
                        else
                        {
                            _startPosition = Screen.PrimaryScreen.WorkingArea.Bottom - _toastNotificationPopupForm.Height;
                            _stopPosision = Screen.PrimaryScreen.WorkingArea.Bottom - _toastNotificationPopupForm.Height;
                        }
                        _startOpacity = _toastNotificationPopupForm.Opacity;
                        _stopOpacity = 1;
                        _isAppearing = true;
                        _realAnimationDuration = Math.Max((int)_stopwatch.ElapsedMilliseconds, 1);
                        _stopwatch.Restart();
                        System.Diagnostics.Debug.WriteLine("Animation direction changed.");
                    }
                    _toastNotificationPopupForm.Invalidate();
                }
            }
        }

        /// <summary>
        /// Hide the notification window.
        /// </summary>
        public void Hide()
        {
            System.Diagnostics.Debug.WriteLine("Animation stopped.");
            System.Diagnostics.Debug.WriteLine("Wait timer stopped.");
            _animationTimer.Stop();
            _waitTimer.Stop();
            _toastNotificationPopupForm.Hide();
        }
        #endregion

        #region Protected
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing && _toastNotificationPopupForm != null)
                {
                    _toastNotificationPopupForm.Dispose();
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}
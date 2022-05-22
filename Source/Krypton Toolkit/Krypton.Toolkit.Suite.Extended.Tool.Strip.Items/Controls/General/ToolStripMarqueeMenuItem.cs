#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    public class ToolStripMarqueeMenuItem : EnhancedToolStripMenuItem
    {
        #region Constants
        const MarqueeScrollDirection DEFAULT_MARQUEE_SCROLL_DIRECTION = MarqueeScrollDirection.RIGHTTOLEFT;
        const int DEFAULT_REFRESH_INTERVAL = 30;
        const int DEFAULT_SCROLL_STEP = 1;
        const bool DEFAULT_STOP_SCROLL_ON_MOUSE_OVER = true;
        #endregion

        #region Variables
        //If <=0, minimum text width is equal text width. If value is greater than zero, this value is used as text area width.
        int _minimumTextWidth;

        // Marquee text.
        string _text;

        //Every time new text is assigned, text is measured ans stored here
        Size _textSize;

        //Timer used to repaint scrolled text
        System.Windows.Forms.Timer _timer;

        //Value modified in Timer tick event. Used to represent ever changing text offset.
        int _pixelOffest;
        #endregion

        #region Properties
        /// <summary>
        /// Determines if text is scrolled left-to-right or right-to-left.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(DEFAULT_MARQUEE_SCROLL_DIRECTION)]
        [Description("Determines if text is scrolled left-to-right or right-to-left.")]
        public MarqueeScrollDirection MarqueeScrollDirection { set; get; }

        /// <summary>
        /// Value less or equal zero indicates that text area width is defined by with of Text string.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(-1)]
        [Description("Value less or equal zero indicates that text area width is defined by with of Text string.")]
        public int MinimumTextWidth
        {
            set
            {
                _minimumTextWidth = value;

                MeasureText();
            }
            get
            {
                return _minimumTextWidth;
            }
        }

        /// <summary>
        /// Determines how often new text position is recalculated. 
        /// Together with 'ScrollStep' property defines speed of moving text.
        /// Smaller value means faster moving text.
        /// Text scrolling speed in pixels per seconds can be expressed with the following formula:
        /// <br></br>
        /// 1000 * ScrolStep/RefreshInterval
        /// </summary>
        /// <remarks>
        /// On most computers fastest scrolling speed is achieved for property value around 20 milliseconds.
        /// Values smaller than 20 will not increase speed. If faster scrolling is needed,
        /// it can be achieved by increasing value of 'ScrollStep' property.
        /// </remarks>
        [Browsable(true)]
        [DefaultValue(DEFAULT_REFRESH_INTERVAL)]
        [Description("Interval in milliseconds when new position is calculated and refreshed.")]
        public int RefreshInterval
        {
            get { return _timer.Interval; }
            set { _timer.Interval = value; }
        }

        /// <summary>
        /// Determines how many pixels text shifts when position is recalculated. 
        /// Together with 'RefreshInterval' property defines speed of moving text.
        /// Bigger value means faster moving text.
        /// Text scrolling speed in pixels per seconds can be expressed with the following formula:
        /// <br></br>
        /// 1000 * ScrolStep/RefreshInterval
        /// </summary>
        /// </summary>
        [Browsable(true)]
        [DefaultValue(DEFAULT_SCROLL_STEP)]
        [Description("Number of pixels text position shifts when new position is calculated and refreshed")]
        public int ScrollStep { set; get; }

        /// <summary>
        /// When sets to 'true', every time mouse pointer moves over tool strip item, scrolling stops.
        /// Otherwise scrolling never stops.
        /// </summary>
        [Browsable(true)]
        [DefaultValue(DEFAULT_STOP_SCROLL_ON_MOUSE_OVER)]
        [Description(" When sets to 'true', every time mouse pointer moves over scrolling stops.  Otherwise scrolling never stops.")]
        public bool StopScrollOnMouseOver { set; get; }

        /// <summary>
        /// Sets or gets text value of menu item text.
        /// </summary>
        [Browsable(true)]
        [Description("Sets or gets text value of menu item text.")]
        public new string Text
        {
            get { return _text; }
            set
            {
                _text = value;

                MeasureText();

                //Assign only spaces text to the base;
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor. Instantiates Timer used to tick scrolling events and initializes default values.
        /// </summary>
        public ToolStripMarqueeMenuItem()
        {
            MarqueeScrollDirection = DEFAULT_MARQUEE_SCROLL_DIRECTION;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = DEFAULT_REFRESH_INTERVAL;
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Enabled = true;

            if (MarqueeScrollDirection == MarqueeScrollDirection.RIGHTTOLEFT)
                _pixelOffest = -_textSize.Width;
            else
                _pixelOffest = _textSize.Width;

            DisplayStyle = CheckMarkDisplayStyle.CHECKBOX;
            CheckOnClick = false;
            CheckState = CheckState.Unchecked;

            StopScrollOnMouseOver = DEFAULT_STOP_SCROLL_ON_MOUSE_OVER;
            ScrollStep = DEFAULT_SCROLL_STEP;

            MinimumTextWidth = -1;
        }

        #endregion

        #region Timer event

        /// <summary>
        /// Recalculate new text position and and calls Invalidate to repaint.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            //Change offset only when menu item is visible, mouse is not hovering over or StopScrollOnMouseOver is not set to 'false'
            if ((Visible) && ((!Selected) || (!StopScrollOnMouseOver)))
            {
                _pixelOffest = (_pixelOffest + ScrollStep + _textSize.Width) % (2 * _textSize.Width + 1) - _textSize.Width;
                Invalidate();
            }
        }

        #endregion

        #region Private helper methods

        /// <summary>
        /// Every time Text or Font properties change this method is called to recalculate
        /// commonly used text metrics.
        /// </summary>
        private void MeasureText()
        {
            _textSize = TextRenderer.MeasureText(_text, Font);

            //Calculate size of masked text passed to the base class. Base class doesn't know
            //real value of Text property. It  uses only white spaced string with length
            //equal to length of Text.
            StringBuilder allSpacesString = new StringBuilder(" ");

            int maxWidth = MinimumTextWidth > 0 ? MinimumTextWidth : _textSize.Width;

            while (TextRenderer.MeasureText(allSpacesString.ToString(), Font).Width < maxWidth)
                allSpacesString.Append(' ');

            base.Text = allSpacesString.ToString();

        }

        #endregion

        #region Overrides
        protected override void Dispose(bool disposing)
        {
            _timer.Enabled = false;

            _timer.Dispose();

            base.Dispose(disposing);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            MeasureText();

            base.OnFontChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //Paint scrolling text
            ToolStrip parent = GetCurrentParent();
            Rectangle displayRect = parent.DisplayRectangle;
            int horizPadding = parent.Padding.Horizontal;

            Rectangle clipRectangle = new Rectangle(displayRect.X, displayRect.Y, displayRect.Width - horizPadding, displayRect.Height);

            e.Graphics.FillRectangle(Brushes.Transparent, e.ClipRectangle);

            int textYPosition = (Size.Height - _textSize.Height) / 2;

            Region savedClip = e.Graphics.Clip;
            Region clipRegion = new Region(clipRectangle);
            e.Graphics.Clip = clipRegion;
            if (MarqueeScrollDirection == MarqueeScrollDirection.RIGHTTOLEFT)
                e.Graphics.DrawString(_text, Font, Brushes.Black, -_pixelOffest + horizPadding, textYPosition);
            else
                e.Graphics.DrawString(_text, Font, Brushes.Black, +_pixelOffest + horizPadding, textYPosition);

            clipRegion.Dispose();
            e.Graphics.Clip = savedClip;
        }
        #endregion
    }
}
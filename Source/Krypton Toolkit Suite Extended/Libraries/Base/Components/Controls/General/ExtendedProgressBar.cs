using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    /// <summary>
    /// A progress bar that used a solid bar instead of the ugly chucks from the default WinForm ProgressBar.
    /// </summary>
    [DefaultProperty("BarForeColor"), ToolboxBitmap(typeof(ProgressBar))]
    public partial class ExtendedProgressBar : ProgressBar
    {
        #region Private Fields
        private Color _backColour = SystemColors.Window, _fillColour = Color.SkyBlue;

        private Font _font = SystemFonts.DefaultFont;

        private string _text = "{0}%";
        #endregion

        #region Constructor
        public ExtendedProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }
        #endregion

        #region Properties
        /// <summary>
        /// The bar's background colour (the unfilled part).
        /// </summary>
        [Browsable(true), Description("The bar's background colour (the unfilled part)."), Category("Appearance")]
        public Color BarBackColour
        {
            get
            {
                return _backColour;
            }

            set
            {
                _backColour = value;
            }
        }

        /// <summary>
        /// The bar's fill colour.
        /// </summary>
        [Browsable(true), Description("The bar's fill colour."), Category("Appearance")]
        public Color BarFillColour
        {
            get
            {
                return _fillColour;
            }

            set
            {
                _fillColour = value;
            }
        }

        /// <summary>
        /// The bar's typeface.
        /// </summary>
        [Browsable(true), Description("The bar's typeface."), Category("Appearance")]
        public Font Typeface
        {
            get
            {
                return _font;
            }

            set
            {
                _font = value;
            }
        }
        #endregion

        #region Overrides
        /// <summary>
        /// The font used for displaying text.
        /// </summary>
        [Browsable(true), Description("The font used for displaying text."), Category("Appearance")]
        public override Font Font
        {
            get
            {
                return _font;
            }

            set
            {
                if (value == null)
                {
                    _font = SystemFonts.DefaultFont;
                }
                else
                {
                    _font = value;
                }

                Invalidate();
            }
        }

        /// <summary>
        /// The MarqueeAnimationSpeed is hidden from view, as this implementation is not meant to
        /// be used as a marquee.
        /// </summary>
        [Browsable(false)]
        public new int MarqueeAnimationSpeed
        {
            get
            {
                return -1;
            }

            set { }
        }

        /// <summary>
        /// Paints the control.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rectangle = ClientRectangle, rectangleFill;

            Graphics graphics = e.Graphics;

            if (ProgressBarRenderer.IsSupported)
            {
                ProgressBarRenderer.DrawHorizontalBar(graphics, rectangle);
            }
            else
            {
                graphics.DrawRectangle(Pens.Black, rectangle);
            }

            rectangle.Inflate(-3, -3);

            float fraction = 1.0f - (Value - Minimum) / (Maximum - Minimum);

            int filledWidth = (int)(fraction * rectangle.Width);

            if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
            {
                rectangleFill = new Rectangle(rectangle.Right - filledWidth, rectangle.Top, filledWidth, rectangle.Height);
            }
            else
            {
                rectangleFill = new Rectangle(rectangle.Left, rectangle.Top, filledWidth, rectangle.Height);
            }

            using (Brush brush = new SolidBrush(_backColour))
            {
                graphics.FillRectangle(brush, rectangle);
            }

            using (Brush brushFill = new SolidBrush(_fillColour))
            {
                graphics.FillRectangle(brushFill, rectangleFill);
            }

            if (_text != null)
            {
                string printText = String.Format(_text, Value.ToString());

                SizeF sizeText = graphics.MeasureString(printText, _font);

                float x = 0.5f * (ClientRectangle.Width - sizeText.Width), y = 0.5f * (ClientRectangle.Height - sizeText.Height), height = sizeText.Height;

                RectangleF layoutRectangle = new RectangleF(x, y, sizeText.Width, height);

                using (Brush brushFill = new SolidBrush(_fillColour))
                {
                    graphics.DrawString(printText, _font, brushFill, layoutRectangle);
                }

                graphics.Clip = new Region(rectangleFill);

                using (Brush b = new SolidBrush(_backColour))
                {
                    graphics.DrawString(printText, _font, b, x, y);
                }
            }
        }

        /// <summary>
        /// The Style is hidden from view, as this implementation is not meant to
        /// be used as a marquee.
        /// </summary>
        [Browsable(false)]
        public new ProgressBarStyle Style
        {
            get
            {
                return ProgressBarStyle.Continuous;
            }

            set
            {

            }
        }

        /// <summary>
        /// The text to display. May contain placeholder {0} for the actual value.
        /// </summary>
        [Browsable(true), Description("The text to display. May contain placeholder {0} for the actual value."), Category("Appearance")]
        public override string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;

                Invalidate();
            }
        }
        #endregion
    }
}
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class EnhancedProgressBar : Panel
    {
        #region Variables
        private Color _statusColour1, _statusColour2, _firstColour, _secondColour;

        private int _statusBarColourIndex, _fillDegree = 50;

        private bool _isDragging = false;
        private int _DDradius = 40;
        private int _mX = 0;
        private int _mY = 0;
        #endregion

        #region Properties
        public bool AllowDrag { get; set; }
        public int RoundedCornerAngle { get; set; }
        public int LeftBarSize { get; set; }
        public int RightBarSize { get; set; }
        public int StatusBarSize { get; set; }
        public Padding Padding { get; set; }

        public Font Font { get; set; }
        public string MainText { get; set; }
        public string LeftText { get; set; }
        public string RightText { get; set; }
        public string StatusText { get; set; }

        /// <summary>
        /// ColorIndex. [0 - Raw active] [1 - Raw inactive] [2 - Dry active] [3 - Dry inactive].
        /// </summary>
        public int StatusBarColour
        {
            get => _statusBarColourIndex;

            set
            {
                switch (value)
                {
                    case 0:
                        // Raw active
                        _statusColour1 = Color.OliveDrab;
                        _statusColour2 = Color.DarkOliveGreen;
                        break;
                    case 1:
                        // Raw inactive
                        _statusColour1 = Color.OliveDrab;
                        _statusColour2 = Color.Gray;
                        break;
                    case 2:
                        // Dry active
                        _statusColour1 = Color.Goldenrod;
                        _statusColour2 = Color.DarkGoldenrod;
                        break;
                    case 3:
                        // Dry inactive
                        _statusColour1 = Color.Goldenrod;
                        _statusColour2 = Color.Gray;
                        break;
                    default:
                        _statusColour1 = Color.DimGray;
                        _statusColour2 = Color.DimGray;
                        break;
                }
            }
        }

        public int FillDegree
        {
            get { return _fillDegree; }
            set
            {
                if (value >= 100)
                {
                    _firstColour = Color.Red;
                    _secondColour = Color.DarkRed;
                }
                else if (value > 90)
                {
                    _firstColour = Color.Orange;
                    _secondColour = Color.DarkOrange;
                }
                else if (value > 80)
                {
                    _firstColour = Color.Gold;
                    _secondColour = Color.DarkGoldenrod;
                }
                else
                {
                    _firstColour = Color.Green;
                    _secondColour = Color.DarkGreen;
                }

                _fillDegree = value;
            }
        }
        #endregion

        #region Constructor
        public EnhancedProgressBar()
        {
            Font = new Font("Arial", 10);
            FillDegree = 50;
            RoundedCornerAngle = 10;
            Margin = new Padding(0);
            LeftText = "LT";
            StatusText = "Not set";
            MainText = "MainText";
            RightText = "RT";
            LeftBarSize = 30;
            StatusBarSize = 60;
            RightBarSize = 30;
            StatusBarColour = 99;
            AllowDrag = true;
        }
        #endregion

        #region Overrides
        protected override void OnGotFocus(EventArgs e)
        {
            BackColor = Color.SandyBrown;

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            BackColor = Color.Transparent;

            base.OnLostFocus(e);
        }

        protected override void OnClick(EventArgs e)
        {
            Focus();

            base.OnClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();

            base.OnMouseDown(e);

            _mX = e.X;

            _mY = e.Y;

            _isDragging = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!_isDragging)
            {
                // This is a check to see if the mouse is moving while pressed.
                // Without this, the DragDrop is fired directly when the control is clicked, now you have to drag a few pixels first.
                if (e.Button == MouseButtons.Left && _DDradius > 0 && this.AllowDrag)
                {
                    int num1 = _mX - e.X, num2 = _mY - e.Y;
                    if (((num1 * num1) + (num2 * num2)) > _DDradius)
                    {
                        DoDragDrop(this, DragDropEffects.All);
                        _isDragging = true;
                        return;
                    }
                }
                base.OnMouseMove(e);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isDragging = false;

            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            PaintThis(e.Graphics);
        }
        #endregion

        #region Methods
        public void PaintThis(Graphics g)
        {
            // Textformat
            StringFormat f = new StringFormat();
            f.Alignment = StringAlignment.Center;
            f.LineAlignment = StringAlignment.Center;

            // Misc
            g = this.CreateGraphics();
            System.Drawing.Drawing2D.LinearGradientBrush _LeftAndRightBrush = new LinearGradientBrush(GetMainArea(), Color.DimGray, Color.Black, LinearGradientMode.Vertical);
            System.Drawing.Drawing2D.LinearGradientBrush _StatusBrush = new LinearGradientBrush(GetMainArea(), _statusColour1, _statusColour2, LinearGradientMode.Vertical);
            System.Drawing.Drawing2D.LinearGradientBrush _MainBrush = new LinearGradientBrush(GetMainArea(), _firstColour, _secondColour, LinearGradientMode.Vertical);

            // Draw left
            if (LeftBarSize > 0)
            {
                g.FillRoundedRectangle(_LeftAndRightBrush, this.GetLeftArea(), this.RoundedCornerAngle, RectangleEdgeFilter.TOPLEFT | RectangleEdgeFilter.BOTTOMLEFT);
                g.DrawString(this.LeftText, this.Font, Brushes.White, this.GetLeftArea(), f);
            }

            // Draw status
            if (StatusBarSize > 0)
            {
                g.FillRoundedRectangle(_StatusBrush, this.StatusArea, this.RoundedCornerAngle, RectangleEdgeFilter.NONE);
                g.DrawString(this.StatusText, this.Font, Brushes.White, this.StatusArea, f);
            }

            // Draw main background
            g.FillRoundedRectangle(Brushes.DimGray, GetMainAreaBackground(), this.RoundedCornerAngle, RectangleEdgeFilter.NONE);

            // Draw main
            g.FillRoundedRectangle(_MainBrush, this.GetMainArea(), this.RoundedCornerAngle, RectangleEdgeFilter.NONE);
            g.DrawString(this.MainText, this.Font, Brushes.White, this.GetMainAreaBackground(), f);

            // Draw right
            if (RightBarSize > 0)
            {
                g.FillRoundedRectangle(_LeftAndRightBrush, this.GetRightArea(), this.RoundedCornerAngle, RectangleEdgeFilter.TOPRIGHT | RectangleEdgeFilter.BOTTOMRIGHT);
                g.DrawString(this.RightText, this.Font, Brushes.White, this.GetRightArea(), f);
            }

            // Clean up
            _LeftAndRightBrush.Dispose();
            _MainBrush.Dispose();
            _StatusBrush.Dispose();
        }

        private Rectangle GetLeftArea() => new Rectangle(Padding.Left, Padding.Top, LeftBarSize, ClientRectangle.Height - Padding.Bottom - Padding.Top);

        private Rectangle StatusArea => new Rectangle(Padding.Left + LeftBarSize, Padding.Top, StatusBarSize, this.ClientRectangle.Height - Padding.Bottom - Padding.Top);

        private Rectangle GetMainArea() => new Rectangle(
                Padding.Left + LeftBarSize + StatusBarSize,
                Padding.Top,
                Convert.ToInt32(((this.ClientRectangle.Width - (Padding.Left + LeftBarSize + StatusBarSize + RightBarSize + Padding.Right)) * FillDegree) / 100),
                this.ClientRectangle.Height - Padding.Bottom - Padding.Top);

        private Rectangle GetMainAreaBackground() => new Rectangle(
                   Padding.Left + LeftBarSize + StatusBarSize,
                   Padding.Top,
                   this.ClientRectangle.Width - (Padding.Left + LeftBarSize + StatusBarSize + RightBarSize + Padding.Right),
                   this.ClientRectangle.Height - Padding.Bottom - Padding.Top);

        private Rectangle GetRightArea() => new Rectangle(
                this.ClientRectangle.Width - (RightBarSize + Padding.Right),
                Padding.Top,
                RightBarSize,
                this.ClientRectangle.Height - Padding.Bottom - Padding.Top);
        #endregion
    }
}
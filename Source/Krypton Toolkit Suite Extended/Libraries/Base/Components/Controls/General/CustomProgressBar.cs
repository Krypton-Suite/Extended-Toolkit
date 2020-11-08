#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class CustomProgressBar : Panel
    {
        #region Variables
        private bool _isDragging = false;

        private Color _statusColourOne, _statusColourTwo, _firstColour, _secondColour;

        private int _statusBarColourIndex, _fillDegree = 50, _ddRadius = 40, _mX = 0, _mY = 0;
        #endregion

        #region Properties
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
                        _statusColourOne = Color.OliveDrab;

                        _statusColourTwo = Color.DarkOliveGreen;
                        break;
                    case 1:
                        // Raw inactive
                        _statusColourOne = Color.OliveDrab;

                        _statusColourTwo = Color.Gray;
                        break;
                    case 2:
                        // Dry active
                        _statusColourOne = Color.Goldenrod;

                        _statusColourTwo = Color.DarkGoldenrod;
                        break;
                    case 3:
                        // Dry inactive
                        _statusColourOne = Color.Goldenrod;

                        _statusColourTwo = Color.Gray;
                        break;
                    default:
                        _statusColourOne = Color.DimGray;

                        _statusColourTwo = Color.DimGray;
                        break;
                }
            }
        }

        public int FillDegree
        {
            get => _fillDegree;

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

        public bool AllowDrag { get; set; }
        #endregion

        #region Constructor
        public CustomProgressBar()
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
                if (e.Button == MouseButtons.Left && _ddRadius > 0 && AllowDrag)
                {
                    int num1 = _mX - e.X, num2 = _mY - e.Y;

                    if (((num1 * num1) + (num2 * num2)) > _ddRadius)
                    {
                        DoDragDrop(this, DragDropEffects.All);

                        _isDragging = true;

                        return;
                    }
                }
            }

            base.OnMouseMove(e);
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
        public void PaintThis(Graphics graphics)
        {
            StringFormat stringFormat = new StringFormat();

            stringFormat.Alignment = StringAlignment.Center;

            stringFormat.LineAlignment = StringAlignment.Center;

            graphics = CreateGraphics();

            LinearGradientBrush lrgb = new LinearGradientBrush(GetMainArea(), Color.DimGray, Color.Black, LinearGradientMode.Vertical), sb = new LinearGradientBrush(GetMainArea(), _statusColourOne, _statusColourTwo, LinearGradientMode.Vertical), mb = new LinearGradientBrush(GetMainArea(), _firstColour, _secondColour, LinearGradientMode.Vertical);

            if (LeftBarSize > 0)
            {
                //graphics.FillRectangle(lrgb)
            }
        }

        private Rectangle GetMainArea()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
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

namespace Krypton.Toolkit.Suite.Extended.Tool.Box
{
    [Serializable]
    public class ToolScrollButton : ToolObject
    {
        #region Private Attributes

        private bool _mouseDown;
        private bool _mouseHover;
        private bool _enabled;
        private ToolBoxScrollDirection _direction;

        #endregion //Private Attributes

        #region Properties

        [Browsable(false), XmlIgnore]
        public bool MouseDown
        {
            get => _mouseDown;
            set => _mouseDown = value;
        }

        [Browsable(false), XmlIgnore]
        public bool MouseHover
        {
            get => _mouseHover;
            set => _mouseHover = value;
        }

        [Category("General")]
        public bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }

        [Category("General")]
        public ToolBoxScrollDirection ScrollDirection
        {
            get => _direction;
            set => _direction = value;
        }

        #endregion //Properties

        #region Construction
        public ToolScrollButton(ToolBoxScrollDirection direction, int width, int height)
        {
            _rectangle = new Rectangle(0, 0, width, height);
            _direction = direction;
            _toolTip = ToolBoxScrollDirection.Up == direction ? "Scroll Up" : "Scroll Down";
        }
        #endregion //Construction

        #region Public Methods

        public void Paint(Graphics g, Rectangle clipRect, bool ctrlEnabled)
        {
            Rectangle rect = Rectangle.Empty;
            Pen pen = null;
            int length = 0;
            Point p1;
            Point p2;

            if (_rectangle.IntersectsWith(clipRect))
            {
                pen = !_enabled || !ctrlEnabled ? SystemPens.GrayText : Pens.Black;
                rect = _rectangle;

                KryptonToolBox.DrawBorders(g, rect, _mouseDown);

                rect.Inflate(-rect.Width / 3, -rect.Height / 3);

                if (0 != rect.Width % 2)
                {
                    rect.Width--;
                }

                if (0 != rect.Height % 2)
                {
                    rect.Height--;
                }

                rect.Width = Math.Max(8, rect.Width);
                rect.Height = Math.Max(8, rect.Height);

                rect.X -= rect.Width / 4;
                //rect.Y -= rect.Height/4;

                if (_mouseDown)
                {
                    rect.Offset(1, 1);
                }

                //g.DrawRectangle(Pens.Red,rect);

                //rect.X = _rectangle.X + (_rectangle.Width - rect.Width)/2;
                length = (int)rect.Width;
                p1 = rect.Location;
                p2 = rect.Location;

                if (ToolBoxScrollDirection.Down == _direction)
                {
                    p2.X = rect.Right;

                    while (0 <= length)
                    {
                        g.DrawLine(pen, p1, p2);
                        p1.X++; p2.X--;
                        p1.Y++; p2.Y++;
                        length -= 2;
                    }

                    p1.X = rect.Left + rect.Width / 2;
                    p1.Y = rect.Top;
                    p2.X = p1.X;
                    p2.Y = rect.Top + rect.Height / 2;

                    g.DrawLine(pen, p1, p2);
                }
                else if (ToolBoxScrollDirection.Up == _direction)
                {
                    p1.X = rect.Left + rect.Width / 2;
                    p1.Y = rect.Top;
                    p2.X = p1.X;
                    p2.Y = p1.Y;

                    while (0 <= length)
                    {
                        g.DrawLine(pen, p1, p2);
                        p1.X--; p2.X++;
                        p1.Y++; p2.Y++;
                        length -= 2;
                    }

                    p1.X = rect.Left + rect.Width / 2;
                    p1.Y = rect.Bottom - rect.Height / 2;
                    p2.X = p1.X;
                    p2.Y = rect.Top;

                    g.DrawLine(pen, p1, p2);

                }

            }
        }

        public bool HitTest(int x, int y)
        {
            return _rectangle.Contains(x, y);
        }

        #endregion //Public Methods
    }
}
#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Floating.Toolbars
{
    public class FloatablePanelHost : ToolStripPanel
    {
        #region Instance Fields

        private FloatableMenuStrip _floatableMenuStrip;

        private FloatableToolStrip _floatableToolStrip;

        private Rectangle _activeArea;

        #endregion

        #region Public

        public FloatableMenuStrip FloatableMenuStrip { get => _floatableMenuStrip; set => _floatableMenuStrip = value; } 

        public FloatableToolStrip FloatableToolStrip { get => _floatableToolStrip; set => _floatableToolStrip = value; }

        public Rectangle ActiveArea => _activeArea;

        #endregion

        #region Overrides

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (FloatableMenuStrip != null)
            {
                MenuStrip ms = e.Control as MenuStrip;

                if (ms != null)
                {
                    if (Orientation == Orientation.Horizontal)
                    {
                        ms.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                    }
                    else
                    {
                        ms.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                    }
                }
            }
            else if (FloatableToolStrip != null)
            {
                ToolStrip ts = e.Control as ToolStrip;

                if (ts != null)
                {
                    if (Orientation == Orientation.Horizontal)
                    {
                        ts.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                    }
                    else
                    {
                        ts.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                    }
                }
            }

            base.OnControlAdded(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            _activeArea = ClientRectangle;

            if (_activeArea.Width < 23 || _activeArea.Height < 23)
            {
                if (Orientation == Orientation.Horizontal)
                {
                    _activeArea.Height = 23;
                }
                else
                {
                    _activeArea.Width = 23;
                }

                switch (base.Dock)
                {
                    case DockStyle.Bottom:
                        _activeArea.Y -= 23;
                        break;
                    case DockStyle.Left:
                        _activeArea.X += 23;
                        break;
                    case DockStyle.Right:
                        _activeArea.X -= 23;
                        break;
                }
            }

            base.OnSizeChanged(e);
        }

        #endregion
    }
}

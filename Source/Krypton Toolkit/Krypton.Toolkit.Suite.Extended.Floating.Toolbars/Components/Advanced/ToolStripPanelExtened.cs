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
    [Serializable]
    public class ToolStripPanelExtened : ToolStripPanel
    {
        #region Variables
        private Rectangle _activeRectangle;
        #endregion

        #region Property
        public Rectangle ActiveRectangle => _activeRectangle;

        #endregion

        #region Overrides
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            _activeRectangle = ClientRectangle;

            if (_activeRectangle.Width < 23 || _activeRectangle.Height < 23)
            {
                if (Orientation == Orientation.Horizontal)
                {
                    _activeRectangle.Height = 23;
                }
                else
                {
                    _activeRectangle.Width = 23;
                }

                switch (base.Dock)
                {
                    case DockStyle.Bottom:
                        _activeRectangle.Y -= 23;
                        break;
                    case DockStyle.Left:
                        _activeRectangle.X += 23;
                        break;
                    case DockStyle.Right:
                        _activeRectangle.X -= 23;
                        break;
                    default:
                        break;
                }
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            ToolStrip toolStrip = e.Control as ToolStrip;

            if (toolStrip != null)
            {
                if (Orientation == Orientation.Horizontal)
                {
                    toolStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                }
                else
                {
                    toolStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
                }
            }
        }
        #endregion
    }
}
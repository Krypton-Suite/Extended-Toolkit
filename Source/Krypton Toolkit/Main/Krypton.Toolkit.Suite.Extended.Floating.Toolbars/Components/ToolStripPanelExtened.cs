#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Floating.Toolbars
{
    [Serializable]
    public class ToolStripPanelExtened : ToolStripPanel
    {
        #region Variables
        private Rectangle _activeRectangle;
        #endregion

        #region Property
        public Rectangle ActiveRectangle { get => _activeRectangle; }
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
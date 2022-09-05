using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

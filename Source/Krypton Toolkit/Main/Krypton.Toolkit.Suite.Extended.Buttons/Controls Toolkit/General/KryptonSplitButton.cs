using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonSplitButton : KryptonButton
    {
        #region Constants
        private const int PUSH_BUTTON_WIDTH = 14;
        #endregion

        #region Variables
        private bool _skipNextOpen = false, _showSplitOption = true;

        private Rectangle _dropDownRectangle = new Rectangle();
        #endregion

        #region Readonly
        private static readonly int BORDER_SIZE = SystemInformation.Border3DSize.Width * 2;
        #endregion

        #region Properties
        public bool ShowSplitOption
        {
            get => _showSplitOption;

            set
            {
                if (value != _showSplitOption)
                {
                    _showSplitOption = value;

                    Invalidate();

                    if (Parent != null)
                    {
                        Parent.PerformLayout();
                    }
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonSplitButton"/> class.</summary>
        public KryptonSplitButton()
        {
            AutoSize = true;

            ShowSplitOption = true;
        }
        #endregion

        #region Overrides
        public override Size GetPreferredSize(Size proposedSize)
        {
            Size preferredSize = base.GetPreferredSize(proposedSize);

            if (ShowSplitOption && !string.IsNullOrEmpty(Text) && TextRenderer.MeasureText(Text, Font).Width + PUSH_BUTTON_WIDTH > preferredSize.Width)
            {
                return preferredSize + new Size(PUSH_BUTTON_WIDTH + BORDER_SIZE * 2, 0);
            }

            return preferredSize;
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData.Equals(Keys.Down) && ShowSplitOption)
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (ShowSplitOption && e.KeyCode.Equals(Keys.Down))
            {
                ShowContextMenuStrip();
            }

            base.OnKeyDown(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!ShowSplitOption)
            {
                base.OnMouseDown(e);
                return;
            }

            if (_dropDownRectangle.Contains(e.Location))
            {
                ShowContextMenuStrip();
            }
            else
            {
                base.OnMouseDown(e);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!ShowSplitOption)
            {
                base.OnMouseUp(e);

                return;
            }

            if (ContextMenuStrip == null || !ContextMenuStrip.Visible)
            {
                base.OnMouseUp(e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!ShowSplitOption) return;

            Graphics g = e.Graphics;

            Rectangle bounds = ClientRectangle;

            _dropDownRectangle = new Rectangle(bounds.Right - PUSH_BUTTON_WIDTH - 1, BORDER_SIZE, PUSH_BUTTON_WIDTH, bounds.Height - BORDER_SIZE * 2);

            int internalBorder = BORDER_SIZE;

            Rectangle focusRectangle = new Rectangle(internalBorder, internalBorder, bounds.Width - _dropDownRectangle.Width - internalBorder, bounds.Height - (internalBorder * 2));

            IPalette palette = KryptonManager.CurrentGlobalPalette;

            Pen shadow = SystemPens.ButtonShadow, face = SystemPens.ButtonFace;

            if (palette != null)
            {
                shadow = new Pen(palette.ColorTable.GripDark);

                face = new Pen(palette.ColorTable.GripLight);
            }

            if (RightToLeft == RightToLeft.Yes)
            {
                _dropDownRectangle.X = bounds.Left + 1;

                focusRectangle.X = _dropDownRectangle.Right;

                g.DrawLine(shadow, bounds.Left + PUSH_BUTTON_WIDTH, BORDER_SIZE, bounds.Left + PUSH_BUTTON_WIDTH, bounds.Bottom - BORDER_SIZE);

                g.DrawLine(face, bounds.Left + PUSH_BUTTON_WIDTH + 1, BORDER_SIZE, bounds.Left + PUSH_BUTTON_WIDTH + 1, bounds.Bottom - BORDER_SIZE);
            }
            else
            {
                // draw two lines at the edge of the dropdown button 
                g.DrawLine(shadow, bounds.Right - PUSH_BUTTON_WIDTH, BORDER_SIZE, bounds.Right - PUSH_BUTTON_WIDTH, bounds.Bottom - BORDER_SIZE);

                g.DrawLine(face, bounds.Right - PUSH_BUTTON_WIDTH - 1, BORDER_SIZE, bounds.Right - PUSH_BUTTON_WIDTH - 1, bounds.Bottom - BORDER_SIZE);
            }

            // Draw an arrow in the correct location 
            PaintArrow(g, _dropDownRectangle);
        }
        #endregion

        #region Methods
        private static void PaintArrow(Graphics graphics, Rectangle rectangle)
        {
            Point midPoint = new Point(Convert.ToInt32(rectangle.Left + rectangle.Width / 2), Convert.ToInt32(rectangle.Top + rectangle.Height / 2));

            midPoint.X += (rectangle.Width % 2);

            Point[] arrow = new Point[] { new Point(midPoint.X - 2, midPoint.Y - 1), new Point(midPoint.X + 3, midPoint.Y - 1), new Point(midPoint.X, midPoint.Y + 2) };

            graphics.FillPolygon(SystemBrushes.ControlText, arrow);
        }

        private void ShowContextMenuStrip()
        {
            if (_skipNextOpen)
            {
                // we were called because we're closing the context menu strip 
                // when clicking the dropdown button. 
                _skipNextOpen = false;

                return;
            }

            if (KryptonContextMenu != null)
            {
                KryptonContextMenu.Show(FindForm().PointToScreen(Location) + new Size(0, Height));

                KryptonContextMenu.Closed += KryptonContextMenu_Closed;
            }
            else if (ContextMenuStrip != null)
            {
                ContextMenuStrip.Closing += ContextMenuStrip_Closing;

                ContextMenuStrip.Show(this, new Point(0, Height), ToolStripDropDownDirection.BelowRight);
            }
        }
        #endregion

        #region Event Handlers
        private void KryptonContextMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            KryptonContextMenu kcm = sender as KryptonContextMenu;
            if (kcm != null)
            {
                kcm.Closed -= KryptonContextMenu_Closed;
            }

            //if (e.CloseReason == ToolStripDropDownCloseReason.AppClicked) 
            //{ 
            _skipNextOpen = (_dropDownRectangle.Contains(PointToClient(Cursor.Position)));
            //} 
        }

        private void ContextMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            ContextMenuStrip cms = sender as ContextMenuStrip;
            if (cms != null)
            {
                cms.Closing -= ContextMenuStrip_Closing;
            }

            if (e.CloseReason == ToolStripDropDownCloseReason.AppClicked)
            {
                _skipNextOpen = (_dropDownRectangle.Contains(PointToClient(Cursor.Position)));
            }
        }
        #endregion
    }
}
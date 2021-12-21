#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class ToolstripNonClientRenderer : ToolStripSystemRenderer
    {
        #region Overrides
        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderToolStripBackground"/> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs"/> that contains the event data.</param>
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip.IsDropDown)
            {
                base.OnRenderToolStripBackground(e);
            }
            else
            {
                e.Graphics.Clear(Color.Transparent);
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderToolStripBorder"/> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs"/> that contains the event data.</param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip.IsDropDown)
            {
                base.OnRenderToolStripBorder(e);
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderItemText"/> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemTextRenderEventArgs"/> that contains the event data.</param>
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.ToolStrip.IsDropDown)
            {
                base.OnRenderItemText(e);
            }
            else
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddString(e.Text, e.TextFont.FontFamily, (int)e.TextFont.Style, e.TextFont.Size + 2, e.TextRectangle.Location, new StringFormat());

                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                    e.Graphics.FillPath(Brushes.Black, path);
                }
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderOverflowButtonBackground"/> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs"/> that contains the event data.</param>
        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Graphics.Clear(Color.FromArgb(20, Color.Navy));
            }

            Rectangle r = Rectangle.Empty;

            if (e.Item.RightToLeft == RightToLeft.Yes)
            {
                r = new Rectangle(0, e.Item.Height - 8, 9, 5);
            }
            else
            {
                r = new Rectangle(e.Item.Width - 12, e.Item.Height - 16, 9, 5);
            }

            base.DrawArrow(new ToolStripArrowRenderEventArgs(e.Graphics, e.Item, r, SystemColors.ControlText, ArrowDirection.Down));

            e.Graphics.DrawLine(SystemPens.ControlText, (int)(r.Right - 7), (int)(r.Y - 2), (int)(r.Right - 3), (int)(r.Y - 2));
        }
        #endregion
    }
}
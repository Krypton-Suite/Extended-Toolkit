using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class ToolStripNonClientAreaRenderer : ToolStripProfessionalRenderer
    {
        #region Overrides
        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderToolStripBackground">RenderToolStripBackground</see> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs">ToolStripRenderEventArgs</see> that contains the event data.</param>
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

        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderToolStripBorder">RenderToolStripBorder</see> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripRenderEventArgs">ToolStripRenderEventArgs</see> that contains the event data.</param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip.IsDropDown)
            {
                base.OnRenderToolStripBorder(e);
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderItemText">RenderItemText</see> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemTextRenderEventArgs">ToolStripItemTextRenderEventArgs</see> that contains the event data.</param>
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.ToolStrip.IsDropDown)
            {
                base.OnRenderItemText(e);
            }
            else
            {
                GraphicsPath path = new GraphicsPath();

                path.AddString(e.Text, e.TextFont.FontFamily, (int)e.TextFont.Style, e.TextFont.Size + 2, e.TextRectangle.Location, new StringFormat());

                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                e.Graphics.FillPath(Brushes.Black, path);

                path.Dispose();
            }
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripRenderer.RenderOverflowButtonBackground">RenderOverflowButtonBackground</see> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemRenderEventArgs">ToolStripItemRenderEventArgs</see> that contains the event data.</param>
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
                r = new Rectangle(e.Item.Width - 12, e.Item.Height - 16, 8, 5);
            }

            base.DrawArrow(new ToolStripArrowRenderEventArgs(e.Graphics, e.Item, r, SystemColors.ControlText, ArrowDirection.Down));

            e.Graphics.DrawLine(SystemPens.ControlText, (int)(r.Right - 7), (int)(r.Y - 2), (int)(r.Right - 3), (int)(r.Y - 2));
        }
        #endregion
    }
}
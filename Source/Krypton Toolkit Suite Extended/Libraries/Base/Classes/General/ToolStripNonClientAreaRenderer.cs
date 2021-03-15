using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class ToolStripNonClientAreaRenderer : ToolStripProfessionalRenderer
    {
        #region Overrides
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

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip.IsDropDown)
            {
                base.OnRenderToolStripBorder(e);
            }
        }

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

        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderOverflowButtonBackground(e);
        }
        #endregion
    }
}
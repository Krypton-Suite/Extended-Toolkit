using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class ExpandFoldingMarker : VisualMarker
    {
        public readonly int iLine;

        public ExpandFoldingMarker(int iLine, Rectangle rectangle)
            : base(rectangle)
        {
            this.iLine = iLine;
        }

        public void Draw(Graphics gr, Pen pen, Brush backgroundBrush, Pen forePen)
        {
            //draw plus
            gr.FillRectangle(backgroundBrush, rectangle);
            gr.DrawRectangle(pen, rectangle);
            gr.DrawLine(forePen, rectangle.Left + 2, rectangle.Top + rectangle.Height / 2, rectangle.Right - 2, rectangle.Top + rectangle.Height / 2);
            gr.DrawLine(forePen, rectangle.Left + rectangle.Width / 2, rectangle.Top + 2, rectangle.Left + rectangle.Width / 2, rectangle.Bottom - 2);
        }
    }
}
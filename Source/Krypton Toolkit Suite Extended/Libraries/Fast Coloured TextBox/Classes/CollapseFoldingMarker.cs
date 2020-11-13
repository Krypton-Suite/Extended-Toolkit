using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class CollapseFoldingMarker : VisualMarker
    {
        public readonly int iLine;

        public CollapseFoldingMarker(int iLine, Rectangle rectangle)
            : base(rectangle)
        {
            this.iLine = iLine;
        }

        public void Draw(Graphics gr, Pen pen, Brush backgroundBrush, Pen forePen)
        {
            //draw minus
            gr.FillRectangle(backgroundBrush, rectangle);
            gr.DrawRectangle(pen, rectangle);
            gr.DrawLine(forePen, rectangle.Left + 2, rectangle.Top + rectangle.Height / 2, rectangle.Right - 2, rectangle.Top + rectangle.Height / 2);
        }
    }
}
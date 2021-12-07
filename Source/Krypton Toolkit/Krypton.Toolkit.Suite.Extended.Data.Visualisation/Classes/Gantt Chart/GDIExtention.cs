namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    internal static class GDIExtention
    {
        public static void DrawRectangle(this Graphics graphics, Pen pen, RectangleF rectangle)
        {
            graphics.DrawRectangle(pen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public static RectangleF TextBoxAlign(this Graphics graphics, string text, ChartTextAlign align, Font font, RectangleF textbox, float margin = 0)
        {
            var size = graphics.MeasureString(text, font);
            if (align == ChartTextAlign.MiddleCenter)
            {
                return new RectangleF(new PointF(textbox.Left + (textbox.Width - size.Width) / 2, textbox.Top + (textbox.Height - size.Height) / 2), size);
            }
            else if (align == ChartTextAlign.MiddleLeft)
            {
                return new RectangleF(new PointF(textbox.Left + margin, textbox.Top + (textbox.Height - size.Height) / 2), size);
            }
            else
            {
                throw new NotImplementedException("Need to implement more alignment types");
            }
        }
    }
}
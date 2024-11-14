namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public static class SystemDrawingExtensions
    {
        public static Color ToColor(this System.Drawing.Color color) => new Color(color.R, color.G, color.B, color.A);

        public static PixelRect ToPixelRect(this System.Drawing.Rectangle rect) => new PixelRect(rect.Left, rect.Right, rect.Bottom, rect.Top);

        public static PixelRect ToPixelRect(this System.Drawing.RectangleF rect) => new PixelRect(rect.Left, rect.Right, rect.Bottom, rect.Top);

        public static PixelSize ToPixelSize(this System.Drawing.Size size) => new PixelSize(size.Width, size.Height);

        public static PixelSize ToPixelSize(this System.Drawing.SizeF size) => new PixelSize(size.Width, size.Height);

        public static Pixel ToPixel(this System.Drawing.Point point) => new Pixel(point.X, point.Y);

        public static Pixel ToPixel(this System.Drawing.PointF point) => new Pixel(point.X, point.Y);
    }
}
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public static class SystemDrawingExtensions
    {
        public static Color ToColor(this Color color) => new Color(color.R, color.G, color.B, color.A);

        public static PixelRect ToPixelRect(this Rectangle rect) => new PixelRect(rect.Left, rect.Right, rect.Bottom, rect.Top);

        public static PixelRect ToPixelRect(this RectangleF rect) => new PixelRect(rect.Left, rect.Right, rect.Bottom, rect.Top);

        public static PixelSize ToPixelSize(this Size size) => new PixelSize(size.Width, size.Height);

        public static PixelSize ToPixelSize(this SizeF size) => new PixelSize(size.Width, size.Height);

        public static Pixel ToPixel(this Point point) => new Pixel(point.X, point.Y);

        public static Pixel ToPixel(this PointF point) => new Pixel(point.X, point.Y);
    }
}
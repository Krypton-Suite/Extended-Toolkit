namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Square : IHatch
    {
        static Square()
        {
            _bmp = CreateBitmap();
        }
        private static readonly SKBitmap _bmp;
        private static SKBitmap CreateBitmap()
        {
            var bitmap = new SKBitmap(20, 20);
            using var paint = new SKPaint() { Color = Colors.White.ToSkColor() };
            using var path = new SKPath();
            using var canvas = new SKCanvas(bitmap);

            canvas.Clear(Colors.Black.ToSkColor());
            canvas.DrawRect(new SKRect(0, 0, 10, 10), paint);

            return bitmap;
        }

        public SKShader GetShader(Color backgroundColor, Color hatchColor)
        {
            return SKShader.CreateBitmap(
                    _bmp,
                    SKShaderTileMode.Repeat,
                    SKShaderTileMode.Repeat,
                    SKMatrix.CreateScale(0.5f, 0.5f))
                .WithColorFilter(Drawing.GetMaskColorFilter(hatchColor, backgroundColor));
        }
    }
}
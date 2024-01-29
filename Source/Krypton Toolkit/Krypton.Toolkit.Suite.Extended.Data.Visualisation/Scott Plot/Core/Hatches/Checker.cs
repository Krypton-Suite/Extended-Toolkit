namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Checker : IHatch
    {
        static Checker()
        {
            _bmp = CreateBitmap();
        }
        private static readonly SKBitmap _bmp;
        private static SKBitmap CreateBitmap()
        {
            var bmp = new SKBitmap(20, 20);
            using var paint = new SKPaint()
            {
                Color = Colors.White.ToSKColor()
            };
            using var path = new SKPath();
            using var canvas = new SKCanvas(bmp);

            canvas.Clear(Colors.Black.ToSKColor());
            canvas.DrawRect(new SKRect(0, 0, 10, 10), paint);
            canvas.DrawRect(new SKRect(10, 10, 20, 20), paint);

            return bmp;
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
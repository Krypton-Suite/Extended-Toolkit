namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Grid : IHatch
    {
        public bool Rotate { get; set; }

        static Grid()
        {
            _bmp = CreateBitmap();
        }
        public Grid(bool rotate = false)
        {
            Rotate = rotate;
        }

        private static readonly SKBitmap _bmp;
        private static SKBitmap CreateBitmap()
        {
            var bmp = new SKBitmap(20, 20);
            using var paint = new SKPaint()
            {
                Color = Colors.White.ToSKColor(),
                IsStroke = true,
                StrokeWidth = 3
            };
            using var path = new SKPath();
            using var canvas = new SKCanvas(bmp);

            canvas.Clear(Colors.Black.ToSKColor());
            canvas.DrawRect(0, 0, 20, 20, paint);

            return bmp;
        }

        public SKShader GetShader(Color backgroundColor, Color hatchColor)
        {
            var rotationMatrix = Rotate ? SKMatrix.CreateRotationDegrees(45) : SKMatrix.Identity;

            return SKShader.CreateBitmap(
                    _bmp,
                    SKShaderTileMode.Repeat,
                    SKShaderTileMode.Repeat,
                    SKMatrix.CreateScale(0.5f, 0.5f)
                        .PostConcat(rotationMatrix))
                .WithColorFilter(Drawing.GetMaskColorFilter(hatchColor, backgroundColor));
        }
    }
}
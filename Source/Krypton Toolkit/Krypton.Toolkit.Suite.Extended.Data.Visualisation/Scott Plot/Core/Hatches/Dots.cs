namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class Dots : IHatch
{
    static Dots()
    {
        _bmp = CreateBitmap();
    }
    private static readonly SKBitmap _bmp;
    private static SKBitmap CreateBitmap()
    {
        var bmp = new SKBitmap(20, 20);
        using var paint = new SKPaint()
        {
            Color = Colors.White.ToSkColor()
        };
        using var path = new SKPath();
        using var canvas = new SKCanvas(bmp);

        paint.IsAntialias = true; // AA is especially important for circles, it seems to do little for the other shapes

        canvas.Clear(Colors.Black.ToSkColor());
        canvas.DrawCircle(5, 5, 5, paint);

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
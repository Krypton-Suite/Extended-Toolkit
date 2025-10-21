namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

internal class SvgImage : IDisposable
{
    private bool _isDisposed = false;
    public readonly int Width;
    public readonly int Height;
    private readonly MemoryStream _stream;
    public readonly SKCanvas Canvas;

    public SvgImage(int width, int height)
    {
        Width = width;
        Height = height;
        SKRect rect = new(0, 0, width, height);
        _stream = new MemoryStream();
        Canvas = SKSvgCanvas.Create(rect, _stream);
    }

    public string GetXml()
    {
        return Encoding.ASCII.GetString(_stream.ToArray()) + "</svg>";
    }

    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        Canvas.Dispose();
        _isDisposed = true;

        GC.SuppressFinalize(this);
    }
}
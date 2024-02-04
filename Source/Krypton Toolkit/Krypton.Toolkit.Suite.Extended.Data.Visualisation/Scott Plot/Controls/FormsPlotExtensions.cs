using StandardKeys = System.Windows.Forms.Keys;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    internal static class FormsPlotExtensions
    {
        internal static Pixel Pixel(this MouseEventArgs e)
        {
            return new Pixel(e.X, e.Y);
        }

        internal static MouseButton Button(this MouseEventArgs e)
        {
            return e.Button switch
            {
                MouseButtons.Left => MouseButton.Left,
                MouseButtons.Right => MouseButton.Right,
                MouseButtons.Middle => MouseButton.Middle,
                _ => MouseButton.Unknown,
            };
        }

        internal static Key Key(this KeyEventArgs e)
        {
            return e.KeyCode switch
            {
                StandardKeys.ControlKey => ScottPlot.Key.Ctrl,
                StandardKeys.Menu => ScottPlot.Key.Alt,
                StandardKeys.ShiftKey => ScottPlot.Key.Shift,
                _ => ScottPlot.Key.Unknown,
            };
        }

        internal static Bitmap GetBitmap(this Plot plot, int width, int height)
        {
            byte[] bytes = plot.GetImage(width, height).GetImageBytes();
            using MemoryStream ms = new(bytes);
            Bitmap bmp = new(ms);
            return bmp;
        }
    }
}
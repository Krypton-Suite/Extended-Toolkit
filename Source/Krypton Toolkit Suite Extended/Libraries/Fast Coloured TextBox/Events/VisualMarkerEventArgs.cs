using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class VisualMarkerEventArgs : MouseEventArgs
    {
        public Style Style { get; private set; }
        public StyleVisualMarker Marker { get; private set; }

        public VisualMarkerEventArgs(Style style, StyleVisualMarker marker, MouseEventArgs args)
            : base(args.Button, args.Clicks, args.X, args.Y, args.Delta)
        {
            Style = style;

            Marker = marker;
        }
    }
}
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class StyleVisualMarker : VisualMarker
    {
        public Style Style { get; private set; }

        public StyleVisualMarker(Rectangle rectangle, Style style)
            : base(rectangle)
        {
            Style = style;
        }
    }
}
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class FigureBackground : IRenderable
    {
        public Color Colour { get; set; } = Color.White;

        public void Render(Settings settings)
        {
            if (settings.gfxFigure is null)
                return;

            settings.gfxFigure.Clear(Colour);
        }
    }
}
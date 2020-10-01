using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class DataBackground : IRenderable
    {
        public Color Colour { get; set; } = Color.White;

        public void Render(Settings settings)
        {
            if (settings.gfxData is null)
                return;

            settings.gfxData.Clear(Colour);
        }
    }
}
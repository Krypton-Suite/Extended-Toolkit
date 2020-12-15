#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
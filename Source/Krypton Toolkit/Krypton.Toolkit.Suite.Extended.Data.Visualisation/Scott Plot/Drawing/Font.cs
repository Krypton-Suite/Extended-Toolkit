#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Font
    {
        public float Size = 12;
        public Color Color = Color.Black;
        public Alignment Alignment = Alignment.UpperLeft;
        public bool Bold = false;
        public float Rotation = 0;

        private string _Name;
        public string Name
        {
            get => _Name;
            set => _Name = InstalledFont.ValidFontName(value); // ensure only valid font names can be assigned
        }

        public Font() => Name = InstalledFont.Sans();
    }
}
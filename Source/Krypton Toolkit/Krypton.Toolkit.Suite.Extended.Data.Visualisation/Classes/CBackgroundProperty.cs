#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class CBackgroundProperty
    {
        // Firs Gradient color( at the moment top)
        private Color gradientColour1;
        public Color GradientColour1
        {
            get { return gradientColour1; }
            set { gradientColour1 = value; }
        }

        // Second gradient color (at the moment, bottom)
        private Color gradientColour2;
        public Color GradientColour2
        {
            get { return gradientColour2; }
            set { gradientColour2 = value; }
        }

        // Color for solid background
        private Color solidColour;
        public Color SolidColour
        {
            get { return solidColour; }
            set { solidColour = value; }
        }

        // How to paint background
        public enum PaintingModes
        {
            SolidColour,
            LinearGradient
        }

        private PaintingModes paintingMode;
        public PaintingModes PaintingMode
        {
            get { return paintingMode; }
            set { paintingMode = value; }
        }

        public CBackgroundProperty()
        {
            paintingMode = PaintingModes.LinearGradient;
            gradientColour1 = Color.FromArgb(255, 200, 210, 255);
            gradientColour2 = Color.FromArgb(255, 100, 100, 155);
            solidColour = gradientColour2;
        }
    }
}
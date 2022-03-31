#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    /// Code from: https://github.com/aalitor/AltoControls/blob/on-development/AltoControls/Helpers/RoundedRectangleF.cs
    /// </summary>
    public class RoundedRectangleF
    {
        private Point location;
        private float radius;
        private GraphicsPath grPath;
        private float x, y;
        private float width, height;


        public RoundedRectangleF(float width, float height, float radius, float x = 0, float y = 0)
        {

            location = new Point(0, 0);
            this.radius = radius;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            grPath = new GraphicsPath();
            if (radius <= 0)
            {
                grPath.AddRectangle(new RectangleF(x, y, width, height));
                return;
            }
            RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
            RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
            RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
            RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

            grPath.AddArc(upperLeftRect, 180, 90);
            grPath.AddArc(upperRightRect, 270, 90);
            grPath.AddArc(lowerRightRect, 0, 90);
            grPath.AddArc(lowerLeftRect, 90, 90);
            grPath.CloseAllFigures();

        }
        public RoundedRectangleF()
        {
        }
        public GraphicsPath Path
        {
            get
            {
                return grPath;
            }
        }
        public RectangleF Rect
        {
            get
            {
                return new RectangleF(x, y, width, height);
            }
        }
        public float Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

    }
}
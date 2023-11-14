#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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
        public GraphicsPath Path => grPath;

        public RectangleF Rect => new RectangleF(x, y, width, height);

        public float Radius
        {
            get => radius;
            set => radius = value;
        }

    }
}
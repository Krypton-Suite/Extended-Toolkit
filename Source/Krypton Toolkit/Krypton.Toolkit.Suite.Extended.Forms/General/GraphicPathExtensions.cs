#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2024 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    /// <summary>
    /// Class with extensions for GraphicsPath objects
    /// </summary>
    public static class GraphicPathExtensions
    {
        #region Round Rectangle

        /// <summary>
        /// Adds a rectangle with round corners to the current GraphicsPath.
        /// </summary>
        /// <param name="gp">The current GraphicsPath object.</param>
        /// <param name="rectangle">The rectangle which defines the area to be added.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        /// <returns>The current GraphicsPath object.</returns>
        public static GraphicsPath AddRoundRectangle(this GraphicsPath gp, Rectangle rectangle, params float[] radius)
        {
            return gp.AddRoundRectangle((RectangleF)rectangle, radius);
        }

        /// <summary>
        /// Adds a rectangle with round corners to the current GraphicsPath.
        /// </summary>
        /// <param name="gp">The current GraphicsPath object.</param>
        /// <param name="rectangle">The rectangle which defines the area to be added.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        /// <returns>The current GraphicsPath object.</returns>
        public static GraphicsPath AddRoundRectangle(this GraphicsPath gp, RectangleF rectangle, params float[] radius)
        {
            return gp.AddRoundRectangle(rectangle.Location, rectangle.Size, radius);
        }

        /// <summary>
        /// Adds a rectangle with round corners to the current GraphicsPath.
        /// </summary>
        /// <param name="gp">The current GraphicsPath object.</param>
        /// <param name="point">The coordinates of the upper left corner.</param>
        /// <param name="size">The dimension of the rectangle.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        /// <returns>The current GraphicsPath object.</returns>
        public static GraphicsPath AddRoundRectangle(this GraphicsPath gp, PointF point, SizeF size, params float[] radius)
        {
            var r = new float[4];
            var d = new float[4];
            var bottom = point.Y + size.Height;
            var right = point.X + size.Width;

            for (int i = 0; i < r.Length; i++)
            {
                r[i] = radius.Length > 0 ? radius[i % radius.Length] : 0f;
                d[i] = 2f * r[i];
            }

            if (r[0] > 0f)
            {
                gp.AddArc(new RectangleF(point.X, point.Y, d[0], d[0]), 180, 90);
            }

            gp.AddLine(new PointF(point.X + r[0], point.Y), new PointF(right - r[1], point.Y));

            if (r[1] > 0f)
            {
                gp.AddArc(new RectangleF(right - d[1], point.Y, d[1], d[1]), 270, 90);
            }

            gp.AddLine(new PointF(right, point.Y + r[1]), new PointF(right, bottom - r[2]));

            if (r[2] > 0f)
            {
                gp.AddArc(new RectangleF(right - d[2], bottom - d[2], d[2], d[2]), 0, 90);
            }

            gp.AddLine(new PointF(right - r[2], bottom), new PointF(point.X + r[3], bottom));

            if (r[3] > 0f)
            {
                gp.AddArc(new RectangleF(point.X, bottom - d[3], d[3], d[3]), 90, 90);
            }

            gp.AddLine(new PointF(point.X, bottom - r[3]), new PointF(point.X, point.Y + r[0]));
            gp.CloseFigure();
            return gp;
        }

        #endregion
    }
}
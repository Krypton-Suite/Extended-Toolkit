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
    /// Class with extensions for Graphics objects
    /// </summary>
    public static class GraphicsExtensions
    {
        #region Round Rectangle

        /// <summary>
        /// Draws a rectangle with round corners.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="pen">The Pen object which draws the border with a certain color and width.</param>
        /// <param name="rectangle">The rectangle which defines the area to be drawn.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        public static void DrawRoundRectangle(this Graphics g, Pen pen, RectangleF rectangle, params float[] radius) => g.DrawRoundRectangle(pen, rectangle.Location, rectangle.Size, radius);

        /// <summary>
        /// Draws a rectangle with round corners.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="pen">The Pen object which draws the border with a certain color and width.</param>
        /// <param name="rectangle">The rectangle which defines the area to be drawn.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        public static void DrawRoundRectangle(this Graphics g, Pen pen, Rectangle rectangle, params float[] radius) => g.DrawRoundRectangle(pen, (RectangleF)rectangle, radius);

        /// <summary>
        /// Draws a rectangle with round corners.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="pen">The Pen object which draws the border with a certain color and width.</param>
        /// <param name="point">The coordinates of the upper left corner.</param>
        /// <param name="size">The dimension of the rectangle.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        public static void DrawRoundRectangle(this Graphics g, Pen pen, PointF point, SizeF size, params float[] radius)
        {
            var gp = new GraphicsPath().AddRoundRectangle(point, size, radius);
            g.DrawPath(pen, gp);
        }

        /// <summary>
        /// Fills a rectangle with round corners.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="brush">The Brush object which fills the rectangle with colors.</param>
        /// <param name="rectangle">The rectangle which defines the area to be filled.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        public static void FillRoundRectangle(this Graphics g, Brush brush, Rectangle rectangle, params float[] radius)
        {
            g.FillRoundRectangle(brush, (RectangleF)rectangle, radius);
        }

        /// <summary>
        /// Fills a rectangle with round corners.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="brush">The Brush object which fills the rectangle with colors.</param>
        /// <param name="rectangle">The rectangle which defines the area to be filled.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        public static void FillRoundRectangle(this Graphics g, Brush brush, RectangleF rectangle, params float[] radius)
        {
            g.FillRoundRectangle(brush, rectangle.Location, rectangle.Size, radius);
        }

        /// <summary>
        /// Fills a rectangle with round corners.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="brush">The Brush object which fills the rectangle with colors.</param>
        /// <param name="point">The coordinates of the upper left corner.</param>
        /// <param name="size">The dimension of the rectangle.</param>
        /// <param name="radius">The radius of the different corners starting with the upper left corner.</param>
        public static void FillRoundRectangle(this Graphics g, Brush brush, PointF point, SizeF size, params float[] radius)
        {
            var gp = new GraphicsPath().AddRoundRectangle(point, size, radius);
            g.FillPath(brush, gp);
        }

        #endregion

        #region Shadow

        /// <summary>
        /// Draws a shadow around a defined path.
        /// </summary>
        /// <param name="g">The current Graphics handle.</param>
        /// <param name="path">The path which should have a shadow.</param>
        /// <param name="color">The color of the shadow.</param>
        /// <param name="dx">The horizontal shift.</param>
        /// <param name="dy">The vertical shift.</param>
        /// <param name="blur">The blurness.</param>
        public static void DrawShadow(this Graphics g, GraphicsPath path, Color color, float dx, float dy, float blur)
        {
            var bounds = path.GetBounds();
            var bpw = blur / (float)bounds.Width / 2f;
            var bph = blur / (float)bounds.Height / 2f;
            var tdx = -(float)bounds.Left - (float)bounds.Width / 2f;
            var tdy = -(float)bounds.Top - (float)bounds.Height / 2f;
            path.Transform(new Matrix(1f, 0f, 0f, 1f, tdx, tdy));
            Region original = new Region(path);
            path.Transform(new Matrix(1f + bpw, 0f, 0f, 1f + bph, dx, dy));
            Region transform = new Region(path);
            transform.Exclude(original);

            var gs = g.Save();
            g.TranslateTransform(-tdx, -tdy);

            if (blur <= 0f)
            {
                g.FillRegion(new SolidBrush(color), transform);
            }
            else
            {
                var lgb = new PathGradientBrush(path);
                lgb.CenterColor = color;
                lgb.SurroundColors = new Color[] { Color.Transparent };
                var colors = new Color[3];
                var positions = new float[3];

                for (var i = 0; i < 3; i++)
                {
                    colors[i] = Color.FromArgb(255 * (2 - i) / 2, color);
                    positions[i] = (2f - i) / 2f;
                }

                lgb.InterpolationColors.Colors = colors;
                lgb.InterpolationColors.Positions = positions;
                g.FillRegion(lgb, transform);
            }

            g.Restore(gs);
        }

        /// <summary>
        /// Draws a shadow around a rectangle.
        /// </summary>
        /// <param name="g">The current Graphics handle.</param>
        /// <param name="path">The path which should have a shadow.</param>
        /// <param name="color">The color of the shadow.</param>
        /// <param name="shift">The horizontal and vertical shift.</param>
        /// <param name="blur">The blurness.</param>
        public static void DrawShadow(this Graphics g, GraphicsPath path, Color color, PointF shift, float blur)
        {
            g.DrawShadow(path, color, shift.X, shift.Y, blur);
        }

        /// <summary>
        /// Draws a shadow around a rectangle.
        /// </summary>
        /// <param name="g">The current Graphics handle.</param>
        /// <param name="origin">The rectangle which should have a shadow.</param>
        /// <param name="color">The color of the shadow.</param>
        /// <param name="dx">The horizontal shift.</param>
        /// <param name="dy">The vertical shift.</param>
        /// <param name="blur">The blurness.</param>
        public static void DrawShadow(this Graphics g, RectangleF origin, Color color, float dx, float dy, float blur)
        {
            var gp = new GraphicsPath();
            gp.AddRectangle(origin);

            if (gp.PointCount > 0)
                g.DrawShadow(gp, color, dx, dy, blur);
        }

        /// <summary>
        /// Draws a shadow around a rectangle.
        /// </summary>
        /// <param name="g">The current Graphics handle.</param>
        /// <param name="origin">The rectangle which should have a shadow.</param>
        /// <param name="color">The color of the shadow.</param>
        /// <param name="shift">The horizontal and vertical shift.</param>
        /// <param name="blur">The blurness.</param>
        public static void DrawShadow(this Graphics g, RectangleF origin, Color color, PointF shift, float blur)
        {
            g.DrawShadow(origin, color, shift.X, shift.Y, blur);
        }

        #endregion

        #region Glow

        /// <summary>
        /// Draws a glowing border around a given rectangle.
        /// </summary>
        /// <param name="g">The current Graphics object.</param>
        /// <param name="content">The rectangle that should contain the content.</param>
        /// <param name="glowColor">The color of the glow effect (will become 50 percent transparent).</param>
        /// <param name="size">The size of the glow effect.</param>
        /// <param name="radius">The optional radius for rounded corners.</param>
        public static void Glow(this Graphics g, Rectangle content, Color glowColor, int size = 10, float radius = 0)
        {
            var rect = new Rectangle(content.Left - size, content.Top - size, content.Width + 2 * size, 2 * size + content.Height);
            var gp = new GraphicsPath();
            gp.AddRoundRectangle(rect, radius);
            var pgb = new PathGradientBrush(gp);
            pgb.CenterColor = glowColor;
            pgb.SurroundColors = new Color[] { Color.FromArgb(0, 0, 0, 0) };
            g.FillRectangle(pgb, rect);
        }

        #endregion

        #region Reflection

        /// <summary>
        /// Draws a reflection effect on the current canvas.
        /// </summary>
        /// <param name="g">The current graphics object.</param>
        /// <param name="data">The underlying image with the pixels to reflect.</param>
        /// <param name="origin">The rectangle where the pixels should be taken from.</param>
        /// <param name="gap">The gap between the reflection part and the original in pixels.</param>
        /// <param name="height">The height of the reflection.</param>
        /// <param name="startAlpha">The opacity (0 to 1) at the beginning of the reflection.</param>
        /// <param name="endAlpha">The opacity (0 to 1) at the end of the reflection.</param>
        public static void DrawReflection(this Graphics g, Image data, RectangleF origin, int gap, int height, float startAlpha, float endAlpha)
        {
            var ia = new ImageAttributes();
            var cm = new ColorMatrix();

            for (int i = 0; i < height; i++)
            {
                cm.Matrix33 = startAlpha - i * (startAlpha - endAlpha) / height;
                ia.SetColorMatrix(cm);
                g.DrawImage(data,
                    new Rectangle((int)origin.Left, (int)origin.Bottom + gap + i, (int)origin.Width, 1),
                    origin.Left, origin.Bottom - 1 - i, origin.Width, 1, GraphicsUnit.Pixel, ia);
            }
        }

        /// <summary>
        /// Draws a reflection effect on the current canvas.
        /// </summary>
        /// <param name="g">The current graphics object.</param>
        /// <param name="data">The underlying image with the pixels to reflect.</param>
        /// <param name="origin">The rectangle where the pixels should be taken from.</param>
        /// <param name="gap">The gap between the reflection part and the original in pixels.</param>
        /// <param name="height">The height of the reflection.</param>
        /// <param name="endAlpha">The opacity (0 to 1) in the end of the reflection.</param>
        public static void DrawReflection(this Graphics g, Image data, RectangleF origin, int gap, int height, float endAlpha)
        {
            g.DrawReflection(data, origin, gap, height, 1f, endAlpha);
        }

        /// <summary>
        /// Draws a reflection effect on the current canvas.
        /// </summary>
        /// <param name="g">The current graphics object.</param>
        /// <param name="data">The underlying image with the pixels to reflect.</param>
        /// <param name="origin">The rectangle where the pixels should be taken from.</param>
        /// <param name="endAlpha">The opacity (0 to 1) in the end of the reflection.</param>
        public static void DrawReflection(this Graphics g, Image data, RectangleF origin, float endAlpha)
        {
            g.DrawReflection(data, origin, 0, (int)origin.Height, 1f, endAlpha);
        }

        /// <summary>
        /// Draws a reflection effect on the current canvas.
        /// </summary>
        /// <param name="g">The current graphics object.</param>
        /// <param name="data">The underlying image with the pixels to reflect.</param>
        /// <param name="origin">The rectangle where the pixels should be taken from.</param>
        public static void DrawReflection(this Graphics g, Image data, RectangleF origin)
        {
            g.DrawReflection(data, origin, 0f);
        }

        #endregion

        #region Smoothness

        /// <summary>
        /// Draws an image with 20% smoothed corners (gradient to transparency)
        /// </summary>
        /// <param name="g">The Graphics object</param>
        /// <param name="image">The image to smoothen</param>
        /// <param name="destination">The destination rectangle of the image</param>
        public static void DrawImageSmooth(this Graphics g, Image image, RectangleF destination)
        {
            g.DrawImageSmooth(image, new RectangleF(Point.Empty, image.Size), destination, (AnchorStyles)15, 0.2f);
        }

        /// <summary>
        /// Draws an image with smoothed corners (gradient to transparency)
        /// </summary>
        /// <param name="g">The Graphics object</param>
        /// <param name="image">The image to smoothen</param>
        /// <param name="destination">The destination rectangle of the image</param>
        /// <param name="smoothness">The smoothness in percent (0 = none to 1.0 = complete gradient)</param>
        public static void DrawImageSmooth(this Graphics g, Image image, RectangleF destination, float smoothness)
        {
            g.DrawImageSmooth(image, new RectangleF(Point.Empty, image.Size), destination, (AnchorStyles)15, smoothness);
        }

        /// <summary>
        /// Draws an image with smoothed corners (gradient to transparency)
        /// </summary>
        /// <param name="g">The Graphics object</param>
        /// <param name="image">The image to smoothen</param>
        /// <param name="destination">The destination rectangle of the image</param>
        /// <param name="sides">The sides of the image to smoothen (bitflag enumeration)</param>
        /// <param name="smoothness">The smoothness in percent (0 = none to 1.0 = complete gradient)</param>
        public static void DrawImageSmooth(this Graphics g, Image image, RectangleF destination, AnchorStyles sides, float smoothness)
        {
            g.DrawImageSmooth(image, new RectangleF(Point.Empty, image.Size), destination, sides, smoothness);
        }

        /// <summary>
        /// Draws an image with smoothed corners (gradient to transparency)
        /// </summary>
        /// <param name="g">The Graphics object</param>
        /// <param name="image">The image to smoothen</param>
        /// <param name="destination">The top-left point where the image should be placed</param>
        /// <param name="sides">The sides of the image to smoothen (bitflag enumeration)</param>
        /// <param name="smoothness">The smoothness in percent (0 = none to 1.0 = complete gradient)</param>
        public static void DrawImageSmooth(this Graphics g, Image image, PointF destination, AnchorStyles sides, float smoothness)
        {
            g.DrawImageSmooth(image, new RectangleF(Point.Empty, image.Size), new RectangleF(destination, image.Size), sides, smoothness);
        }

        /// <summary>
        /// Draws an image with smoothed corners (gradient to transparency)
        /// </summary>
        /// <param name="g">The Graphics object</param>
        /// <param name="image">The image to smoothen</param>
        /// <param name="source">The source rectangle of the image (from where to take?)</param>
        /// <param name="destination">The destination rectangle of the image (where to place?)</param>
        /// <param name="sides">The sides of the image to smoothen (bitflag enumeration)</param>
        /// <param name="smoothness">The smoothness in percent (0 = none to 1.0 = complete gradient)</param>
        public static void DrawImageSmooth(this Graphics g, Image image, RectangleF source, RectangleF destination, AnchorStyles sides, float smoothness)
        {
            var innerSource = source;
            var s = (int)(Math.Min(source.Width, source.Height) * Math.Min(0.5f, smoothness / 2f));
            var tmp = new Bitmap((int)source.Width, (int)source.Height);
            var gt = Graphics.FromImage(tmp);

            var left = false;
            var right = false;
            var top = false;
            var bottom = false;

            if ((AnchorStyles.Top & sides) == AnchorStyles.Top)
            {
                top = true;
                innerSource.Y += s;
                innerSource.Height -= s;
            }

            if ((AnchorStyles.Bottom & sides) == AnchorStyles.Bottom)
            {
                bottom = true;
                innerSource.Height -= s;
            }

            if ((AnchorStyles.Left & sides) == AnchorStyles.Left)
            {
                left = true;
                innerSource.X += s;
                innerSource.Width -= s;
            }

            if ((AnchorStyles.Right & sides) == AnchorStyles.Right)
            {
                right = true;
                innerSource.Width -= s;
            }

            var innerRect = new Rectangle((int)(innerSource.X - source.X), (int)(innerSource.Y - source.Y), (int)innerSource.Width, (int)innerSource.Height);
            var topRect = top ? new RectangleF(source.X, source.Y, source.Width, s) : RectangleF.Empty;
            var leftRect = left ? new RectangleF(source.X, source.Y, s, source.Height) : RectangleF.Empty;
            var bottomRect = bottom ? new RectangleF(source.X, source.Bottom - s, source.Width, s) : RectangleF.Empty;
            var rightRect = right ? new RectangleF(source.Right - s, source.Y, s, source.Height) : RectangleF.Empty;

            //Draw Center
            gt.DrawImage(image, innerRect, innerSource, GraphicsUnit.Pixel);

            //Draw Top Left Corner
            if (topRect.IntersectsWith(leftRect))
            {
                var corner = topRect;
                corner.Intersect(leftRect);
                topRect.X += corner.Width;
                topRect.Width -= corner.Width;
                leftRect.Y += corner.Height;
                leftRect.Height -= corner.Height;
                DrawCorner(gt, image, source, corner, s, AnchorStyles.Top | AnchorStyles.Left);
            }

            //Draw Top Right Corner
            if (topRect.IntersectsWith(rightRect))
            {
                var corner = topRect;
                corner.Intersect(rightRect);
                topRect.Width -= corner.Width;
                rightRect.Y += corner.Height;
                rightRect.Height -= corner.Height;
                DrawCorner(gt, image, source, corner, s, AnchorStyles.Top | AnchorStyles.Right);
            }

            //Draw Bottom Left Corner
            if (bottomRect.IntersectsWith(leftRect))
            {
                var corner = bottomRect;
                corner.Intersect(leftRect);
                bottomRect.X += corner.Width;
                bottomRect.Width -= corner.Width;
                leftRect.Height -= corner.Height;
                DrawCorner(gt, image, source, corner, s, AnchorStyles.Bottom | AnchorStyles.Left);
            }

            //Draw Bottom Right Corner
            if (bottomRect.IntersectsWith(rightRect))
            {
                var corner = bottomRect;
                corner.Intersect(rightRect);
                bottomRect.Width -= corner.Width;
                rightRect.Height -= corner.Height;
                DrawCorner(gt, image, source, corner, s, AnchorStyles.Bottom | AnchorStyles.Right);
            }

            //Draw Left Side
            if (left)
                DrawSide(gt, image, source, leftRect, s, AnchorStyles.Left);

            //Draw Right Side
            if (right)
                DrawSide(gt, image, source, rightRect, s, AnchorStyles.Right);

            //Draw Top Side
            if (top)
                DrawSide(gt, image, source, topRect, s, AnchorStyles.Top);

            //Draw Bottom Side
            if (bottom)
                DrawSide(gt, image, source, bottomRect, s, AnchorStyles.Bottom);

            g.DrawImage(tmp, destination);
        }

        #region Helpers

        static void DrawCorner(Graphics g, Image image, RectangleF destSource, RectangleF src, float smoothness, AnchorStyles corner)
        {
            var dest = new RectangleF(src.X - destSource.X, src.Y - destSource.Y, src.Width, src.Height);
            var ia = new ImageAttributes();
            var cm = new ColorMatrix();
            var left = (AnchorStyles.Left & corner) == AnchorStyles.Left;
            var top = (AnchorStyles.Top & corner) == AnchorStyles.Top;
            var s = Math.Ceiling(smoothness);

            /* NEW CODE --- not working yet*/
            /*
            var b = new Bitmap((int)dest.Width, (int)dest.Height);
            var r = new Rectangle(0, 0, (int)src.Width, (int)src.Height);
            Graphics.FromImage(b).DrawImage(image, r, );
            var data = b.LockBits(r, ImageLockMode.ReadWrite, b.PixelFormat);
            var ptr = data.Scan0;
            var bytes = Math.Abs(data.Stride) * b.Height;
            var values = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, values, 0, bytes);
            var i = 3;

            for (var x = 0; x < b.Width; x++)
            {
                for (var y = 0; y < b.Height; y++)
                {
                    var xr = Math.Min((x + 1) / s, 1.0);
                    var yr = Math.Min((y + 1) / s, 1.0);
                    var sq = (float)Math.Max(1.0 - Math.Sqrt(xr * xr + yr * yr), 0.0);
                    values[i] = (byte)(255f * sq);
                    i += 4;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(values, 0, ptr, bytes);
            b.UnlockBits(data);

            g.DrawImage(b, dest, src, GraphicsUnit.Pixel);
            */

            for (var x = 0; x < dest.Width; x++)
            {
                for (var y = 0; y < dest.Height; y++)
                {
                    var xr = Math.Min((x + 1) / s, 1.0);
                    var yr = Math.Min((y + 1) / s, 1.0);
                    var r = Math.Sqrt(xr * xr + yr * yr);

                    if (r > 1.0)
                        continue;

                    var d = new Rectangle((int)(left ? dest.Right - x - 1 : dest.Left + x), (int)(top ? dest.Bottom - y - 1 : dest.Top + y), 1, 1);
                    cm.Matrix33 = 1f - (float)r;
                    ia.SetColorMatrix(cm);
                    g.DrawImage(image, d, left ? src.Right - x - 1 : src.Left + x, top ? src.Bottom - y - 1 : src.Top + y, 1, 1, GraphicsUnit.Pixel, ia);
                }
            }
        }

        static void DrawSide(Graphics g, Image image, RectangleF destSource, RectangleF src, float smoothness, AnchorStyles side)
        {
            var dest = new RectangleF(src.X - destSource.X, src.Y - destSource.Y, src.Width, src.Height);
            var ia = new ImageAttributes();
            var cm = new ColorMatrix();
            var rest = (float)Math.Ceiling(smoothness);
            var take = 1f;
            var inv = ((AnchorStyles.Bottom & side) == AnchorStyles.Bottom) || ((AnchorStyles.Right & side) == AnchorStyles.Right);
            var top = ((AnchorStyles.Bottom & side) == AnchorStyles.Bottom) || ((AnchorStyles.Top & side) == AnchorStyles.Top);

            while (rest > 0f)
            {
                take = Math.Min(1f, rest);
                rest -= take;
                var d = new Rectangle((int)Math.Floor(dest.X + (top ? 0f : rest)), (int)Math.Floor(dest.Y + (top ? rest : 0f)),
                                        (int)Math.Ceiling(top ? dest.Width : take), (int)Math.Ceiling(top ? take : dest.Height));
                cm.Matrix33 = inv ? 1f - Math.Max(0f, rest / smoothness) : Math.Max(0f, rest / smoothness);
                ia.SetColorMatrix(cm);
                g.DrawImage(image, d,
                    src.X + (top ? 0f : rest), src.Y + (top ? rest : 0f), top ? src.Width : 1f, top ? 1f : src.Height,
                    GraphicsUnit.Pixel, ia);
            }
        }

        #endregion

        #endregion
    }
}
#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class ExtDrawing
    {
        /// <summary>
        /// Draws a vertical gradient on a Graphics canvas
        /// </summary>
        /// <param name="g">The graphics canvas</param>
        /// <param name="bounds">The bounds of the gradient</param>
        /// <param name="colors">The colors of the gradient</param>
        /// <param name="positions">The position of the colors inside the gradient</param>
        public static void DrawVertGradient(Graphics g, Rectangle bounds, Color[] colors,
           float[] positions)
        {
            ColorBlend blend = new ColorBlend();

            blend.Colors = colors;
            blend.Positions = positions;

            // To prevent out of memory exceptions when the width or height is 0
            if (bounds.Height == 0)
                bounds.Height = 1;
            if (bounds.Width == 0)
                bounds.Width = 1;

            // Make the linear brush and assign the custom blend to it
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(bounds.Left, bounds.Bottom),
                                                              new Point(bounds.Left, bounds.Top),
                                                              Color.White,
                                                              Color.Black))
            {
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, bounds);
            }
        }

        /// <summary>
        /// Draws a horizontal gradient on a Graphics canvas
        /// </summary>
        /// <param name="g">The graphics canvas</param>
        /// <param name="bounds">The bounds of the gradient</param>
        /// <param name="colors">The colors of the gradient</param>
        /// <param name="positions">The position of the colors inside the gradient</param>
        public static void DrawHorGradient(Graphics g, Rectangle bounds, Color[] colors,
           float[] positions)
        {
            ColorBlend blend = new ColorBlend();

            blend.Colors = colors;
            blend.Positions = positions;

            // To prevent out of memory exceptions when the width or height is 0
            if (bounds.Height == 0)
                bounds.Height = 1;
            if (bounds.Width == 0)
                bounds.Width = 1;

            // Make the linear brush and assign the custom blend to it
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(bounds.Left, bounds.Bottom),
                                                              new Point(bounds.Right, bounds.Bottom),
                                                              Color.White,
                                                              Color.Black))
            {
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, bounds);
            }
        }

        /// <summary>
        /// Draws a radial gradient on a Graphics canvas
        /// </summary>      
        public static void DrawRadialGradient(Graphics g, GraphicsPath path, Rectangle bounds,
           Color centerColor, Color[] colors)
        {
            PathGradientBrush pathGradient = new PathGradientBrush(path);
            pathGradient.CenterColor = centerColor;
            pathGradient.SurroundColors = colors;
            using (Bitmap b = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppPArgb))
            {
                using (Graphics bitmapG = Graphics.FromImage(b))
                {
                    bitmapG.FillPath(pathGradient, path);
                }
                g.DrawImageUnscaled(b, new Point(bounds.X, bounds.Y));
            }
        }
    }
}
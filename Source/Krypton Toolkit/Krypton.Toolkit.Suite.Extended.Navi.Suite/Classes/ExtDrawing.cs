﻿#region MIT License
/*
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
            {
                bounds.Height = 1;
            }

            if (bounds.Width == 0)
            {
                bounds.Width = 1;
            }

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
            {
                bounds.Height = 1;
            }

            if (bounds.Width == 0)
            {
                bounds.Width = 1;
            }

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
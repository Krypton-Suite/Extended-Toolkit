#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class KryptonKnobUtilities
    {
        public static float GetRadian(float val)
        {
            return (float)(val * Math.PI / 180);
        }


        public static Color GetDarkColour(Color c, byte d)
        {
            byte r = 0;
            byte g = 0;
            byte b = 0;

            if (c.R > d) r = (byte)(c.R - d);
            if (c.G > d) g = (byte)(c.G - d);
            if (c.B > d) b = (byte)(c.B - d);

            Color c1 = Color.FromArgb(r, g, b);
            return c1;
        }
        public static Color GetLightColour(Color c, byte d)
        {
            byte r = 255;
            byte g = 255;
            byte b = 255;

            if (c.R + d < 255) r = (byte)(c.R + d);
            if (c.G + d < 255) g = (byte)(c.G + d);
            if (c.B + d < 255) b = (byte)(c.B + d);

            Color c2 = Color.FromArgb(r, g, b);
            return c2;
        }

        /// <summary>
        /// Method which checks is particular point is in rectangle
        /// </summary>
        /// <param name="p">Point to be Chaecked</param>
        /// <param name="r">Rectangle</param>
        /// <returns>true is Point is in rectangle, else false</returns>
        public static bool IsPointinRectangle(Point p, Rectangle r)
        {
            bool flag = false;
            if (p.X > r.X && p.X < r.X + r.Width && p.Y > r.Y && p.Y < r.Y + r.Height)
            {
                flag = true;
            }
            return flag;

        }

        public static void DrawInsetCircle(ref Graphics g, Rectangle r, Pen p)
        {

            Pen p1 = new Pen(GetDarkColour(p.Color, 50));
            Pen p2 = new Pen(GetLightColour(p.Color, 50));
            for (int i = 0; i < p.Width; i++)
            {
                Rectangle r1 = new Rectangle(r.X + i, r.Y + i, r.Width - i * 2, r.Height - i * 2);
                g.DrawArc(p2, r1, -45, 180);
                g.DrawArc(p1, r1, 135, 180);
            }
        }
    }
}
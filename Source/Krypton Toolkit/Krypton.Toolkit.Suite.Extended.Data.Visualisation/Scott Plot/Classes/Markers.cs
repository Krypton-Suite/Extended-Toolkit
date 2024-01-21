#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class MarkerTools
    {
        public static void DrawMarker(Graphics gfx, PointF pixelLocation, MarkerShape shape, float size, Color color)
        {
            if (size == 0 || shape == MarkerShape.None)
            {
                return;
            }

            Pen pen = new Pen(color);

            Brush brush = new SolidBrush(color);

            PointF corner1 = new PointF(pixelLocation.X - size / 2, pixelLocation.Y - size / 2);
            PointF corner2 = new PointF(pixelLocation.X + size / 2, pixelLocation.Y + size / 2);
            SizeF bounds = new SizeF(size, size);
            RectangleF rect = new RectangleF(corner1, bounds);

            switch (shape)
            {
                case MarkerShape.FilledCircle:
                    gfx.FillEllipse(brush, rect);
                    break;
                case MarkerShape.OpenCircle:
                    gfx.DrawEllipse(pen, rect);
                    break;
                case MarkerShape.FilledSquare:
                    gfx.FillRectangle(brush, rect);
                    break;
                case MarkerShape.OpenSquare:
                    gfx.DrawRectangle(pen, corner1.X, corner1.Y, size, size);
                    break;
                case MarkerShape.FilledDiamond:

                    // Create points that define polygon.
                    PointF point1 = new PointF(pixelLocation.X, pixelLocation.Y + size / 2);
                    PointF point2 = new PointF(pixelLocation.X - size / 2, pixelLocation.Y);
                    PointF point3 = new PointF(pixelLocation.X, pixelLocation.Y - size / 2);
                    PointF point4 = new PointF(pixelLocation.X + size / 2, pixelLocation.Y);

                    PointF[] curvePoints = { point1, point2, point3, point4 };

                    //Draw polygon to screen
                    gfx.FillPolygon(brush, curvePoints);
                    break;
                case MarkerShape.OpenDiamond:

                    // Create points that define polygon.
                    PointF point5 = new PointF(pixelLocation.X, pixelLocation.Y + size / 2);
                    PointF point6 = new PointF(pixelLocation.X - size / 2, pixelLocation.Y);
                    PointF point7 = new PointF(pixelLocation.X, pixelLocation.Y - size / 2);
                    PointF point8 = new PointF(pixelLocation.X + size / 2, pixelLocation.Y);

                    PointF[] curvePoints2 = { point5, point6, point7, point8 };

                    //Draw polygon to screen
                    gfx.DrawPolygon(pen, curvePoints2);

                    break;
                case MarkerShape.Asterisk:
                    System.Drawing.Font drawFont = new System.Drawing.Font("CourierNew", size * 3);
                    SizeF textSize = GDI.MeasureString(gfx, "*", drawFont);
                    PointF asteriskPoint = new PointF(pixelLocation.X - textSize.Width / 2, pixelLocation.Y - textSize.Height / 4);
                    gfx.DrawString("*", drawFont, brush, asteriskPoint);

                    break;
                case MarkerShape.HashTag:
                    System.Drawing.Font drawFont2 = new System.Drawing.Font("CourierNew", size * 2);
                    SizeF textSize2 = GDI.MeasureString(gfx, "#", drawFont2);
                    PointF asteriskPoint2 = new PointF(pixelLocation.X - textSize2.Width / 2, pixelLocation.Y - textSize2.Height / 3);
                    gfx.DrawString("#", drawFont2, brush, asteriskPoint2);

                    break;
                case MarkerShape.Cross:
                    System.Drawing.Font drawFont3 = new System.Drawing.Font("CourierNew", size * 2);
                    SizeF textSize3 = GDI.MeasureString(gfx, "+", drawFont3);
                    PointF asteriskPoint3 = new PointF(pixelLocation.X - textSize3.Width / (5 / 2), pixelLocation.Y - textSize3.Height / 2);
                    gfx.DrawString("+", drawFont3, brush, asteriskPoint3);

                    break;
                case MarkerShape.Eks:
                    System.Drawing.Font drawFont4 = new System.Drawing.Font("CourierNew", size * 2);
                    SizeF textSize4 = GDI.MeasureString(gfx, "x", drawFont4);
                    PointF asteriskPoint4 = new PointF(pixelLocation.X - textSize4.Width / (5 / 2), pixelLocation.Y - textSize4.Height / 2);
                    gfx.DrawString("x", drawFont4, brush, asteriskPoint4);

                    break;
                case MarkerShape.VerticalBar:
                    System.Drawing.Font drawFont5 = new System.Drawing.Font("CourierNew", size * 2);
                    SizeF textSize5 = GDI.MeasureString(gfx, "|", drawFont5);
                    PointF asteriskPoint5 = new PointF(pixelLocation.X - textSize5.Width / (5 / 2), pixelLocation.Y - textSize5.Height / 2);
                    gfx.DrawString("|", drawFont5, brush, asteriskPoint5);

                    break;
                case MarkerShape.TriUp:
                    // Create points that define polygon.
                    PointF point9 = new PointF(pixelLocation.X, pixelLocation.Y - size);
                    PointF point10 = new PointF(pixelLocation.X, pixelLocation.Y);
                    PointF point11 = new PointF(pixelLocation.X - size * (float)0.866, pixelLocation.Y + size * (float)0.5);
                    PointF point12 = new PointF(pixelLocation.X, pixelLocation.Y);
                    PointF point13 = new PointF(pixelLocation.X + size * (float)0.866, (pixelLocation.Y + size * (float)0.5));


                    PointF[] curvePoints3 = { point12, point9, point10, point11, point12, point13 };

                    //Draw polygon to screen
                    gfx.DrawPolygon(pen, curvePoints3);

                    break;
                case MarkerShape.TriDown:
                    // Create points that define polygon.
                    PointF point14 = new PointF(pixelLocation.X, pixelLocation.Y + size);
                    PointF point15 = new PointF(pixelLocation.X, pixelLocation.Y);
                    PointF point16 = new PointF(pixelLocation.X - size * (float)0.866, pixelLocation.Y - size * (float)0.5);
                    PointF point17 = new PointF(pixelLocation.X, pixelLocation.Y);
                    PointF point18 = new PointF(pixelLocation.X + size * (float)0.866, (pixelLocation.Y - size * (float)0.5));


                    PointF[] curvePoints4 = { point17, point14, point15, point16, point17, point18 };

                    //Draw polygon to screen
                    gfx.DrawPolygon(pen, curvePoints4);

                    break;
                case MarkerShape.None:
                    break;
                default:
                    throw new NotImplementedException($"unsupported marker type: {shape}");
            }
        }
    }
}
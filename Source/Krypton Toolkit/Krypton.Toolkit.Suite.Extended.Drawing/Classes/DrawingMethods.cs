#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Drawing
{
    public static class DrawingMethods
    {
        #region ... DrawMethods ...
        public static void DrawLinearGradientTwoParts(Graphics g, Rectangle rect, Color LightColour, Color MiddleColour1, Color MiddleColour2, Color DarkColour, float Angle)
        {
            Rectangle upbounds = new Rectangle();
            Rectangle downbounds = new Rectangle();
            upbounds = rect;
            downbounds = rect;

            upbounds.Height = (rect.Height / 2);
            upbounds.Width = rect.Width - 0;
            upbounds.X = rect.X + 0;
            upbounds.Y = rect.Y + 0;

            downbounds.Height = rect.Height - upbounds.Height - 0;
            downbounds.Width = rect.Width - 0;
            downbounds.X = rect.X + 0;
            downbounds.Y = rect.Y + upbounds.Height;

            LinearGradientBrush background1 = new LinearGradientBrush(upbounds, LightColour, MiddleColour1, LinearGradientMode.Vertical);
            LinearGradientBrush background2 = new LinearGradientBrush(downbounds, MiddleColour2, DarkColour, LinearGradientMode.Vertical);

            g.FillRectangle(background1, upbounds);
            g.FillRectangle(background2, downbounds);
        }

        public static void DrawGradient(Graphics g, Rectangle rect, Color DarkColour, Color LightColour, float Angle, bool EnableBorder, Color BorderColour, float BorderSize)
        {
            using (LinearGradientBrush lb = new LinearGradientBrush(rect, LightColour, DarkColour, Angle))
            {
                Blend blend1 = new Blend(4);
                blend1.Positions[0] = 0f;
                blend1.Factors[0] = 0.9f;
                blend1.Positions[1] = 0.4f;
                blend1.Factors[1] = 0.5f;
                blend1.Positions[2] = 0.4f;
                blend1.Factors[2] = 0.2f; //0 darker 0.3 lighter (middle line)
                blend1.Positions[3] = 1f;
                blend1.Factors[3] = 1f;
                lb.Blend = blend1;
                g.FillRectangle(lb, rect);
            }

            if (EnableBorder) g.DrawRectangle(new Pen(BorderColour, BorderSize), rect);
        }

        public static void DrawStatusBlend(Graphics g, Rectangle rect, Color LightColor, Color DarkColor, float Angle)
        {
            // One time creation of the blend for the status strip gradient brush
            Blend _statusStripBlend = new Blend();
            _statusStripBlend.Positions = new float[] { 0.0f, 0.25f, 0.25f, 0.57f, 0.86f, 1.0f };
            _statusStripBlend.Factors = new float[] { 0.1f, 0.6f, 1.0f, 0.4f, 0.0f, 0.95f };


            // We do not paint the top two pixel lines, so are drawn by the status strip border render method
            RectangleF backRect = new RectangleF(0, 1.5f, rect.Width, rect.Height - 2);

            // Cannot paint a zero sized area
            if ((backRect.Width > 0) && (backRect.Height > 0))
            {
                using (LinearGradientBrush backBrush = new LinearGradientBrush(backRect,
                                                                               LightColor,
                                                                               DarkColor,
                                                                               90f))
                {
                    backBrush.Blend = _statusStripBlend;
                    g.FillRectangle(backBrush, backRect);
                }
            }
        }

        public static void DrawContentFromOneColour(Graphics g, Rectangle rect, float baseHue, float Angle)
        {
            Color topTopColour = ColourFromAHSB(255, baseHue, 0.2958f, 0.7292f);
            Color topBottomColour = ColourFromAHSB(255, baseHue, 0.5875f, 0.35f);
            Color bottomTopColour = ColourFromAHSB(255, baseHue, 0.7458f, 0.2f);
            Color bottomBottomColour = ColourFromAHSB(255, baseHue, 0.6f, 0.4042f);

            Rectangle topRect = new Rectangle(0, 0, rect.Width, rect.Height / 2);
            Rectangle bottomRect = new Rectangle(0, topRect.Height, rect.Width, rect.Height - topRect.Height - 1);

            using (Brush topBrush = new LinearGradientBrush(topRect, topTopColour, topBottomColour, Angle))
            {
                g.FillRectangle(topBrush, topRect);
            }
            using (Brush bottomBrush = new LinearGradientBrush(bottomRect, bottomTopColour, bottomBottomColour, Angle))
            {
                g.FillRectangle(bottomBrush, bottomRect);
            }
        }
        public static void DrawBar(Graphics g, RectangleF rect, Color BaseColour, bool DrawBorder)
        {
            // Some calculations
            if (rect.Height <= 0) rect.Height = 1;
            int nAlphaStart = (int)(185 + 5 * rect.Width / 24),
                nAlphaEnd = (int)(10 + 4 * rect.Width / 24);

            if (nAlphaStart > 255) nAlphaStart = 255;
            else if (nAlphaStart < 0) nAlphaStart = 0;

            if (nAlphaEnd > 255) nAlphaEnd = 255;
            else if (nAlphaEnd < 0) nAlphaEnd = 0;


            Color ColourBacklight = BaseColour;
            Color ColourBacklightEnd = Color.FromArgb(50, 0, 0, 0);
            Color ColourGlowStart = Color.FromArgb(nAlphaEnd, 255, 255, 255);
            Color ColourGlowEnd = Color.FromArgb(nAlphaStart, 255, 255, 255);
            Color ColourFillBK = GetDarkerColour(BaseColour, 85);
            Color ColourBorder = GetDarkerColour(BaseColour, 100);

            // Draw a single bar.
            #region BarItself
            RectangleF er = new RectangleF(rect.Left, rect.Top - rect.Height / 2, rect.Width * 2, rect.Height * 2);
            GraphicsPath rctPath = new GraphicsPath();
            rctPath.AddEllipse(er);

            PathGradientBrush pgr = new PathGradientBrush(rctPath);
            pgr.CenterPoint = new PointF(rect.Right, rect.Top + rect.Height / 2);
            pgr.CenterColor = ColourBacklight;
            pgr.SurroundColors = new Color[] { ColourBacklightEnd };

            RectangleF rectGlow = new RectangleF(rect.Left, rect.Top, rect.Width / 2, rect.Height);
            LinearGradientBrush brGlow = new LinearGradientBrush(
                new PointF(rectGlow.Right + 1, rectGlow.Top), new PointF(rectGlow.Left - 1, rectGlow.Top),
                ColourGlowStart, ColourGlowEnd);

            g.FillRectangle(new SolidBrush(ColourFillBK), rect);
            //gr.FillRectangle(new SolidBrush(Color.FromArgb(255, 0, 0, 0)), rectBar);
            g.FillRectangle(pgr, rect);
            g.FillRectangle(brGlow, rectGlow);
            if (DrawBorder) g.DrawRectangle(new Pen(ColourBorder, 1), rect.Left, rect.Top, rect.Width, rect.Height);
            #endregion
        }

        public static void DrawColumn(Graphics g, RectangleF rect, Color BaseColour, bool DrawBorder)
        {
            // Some calculations
            if (rect.Width <= 0) rect.Width = 1;
            int nAlphaStart = (int)(185 + 5 * rect.Height / 24),
                nAlphaEnd = (int)(10 + 4 * rect.Height / 24);

            if (nAlphaStart > 255) nAlphaStart = 255;
            else if (nAlphaStart < 0) nAlphaStart = 0;

            if (nAlphaEnd > 255) nAlphaEnd = 255;
            else if (nAlphaEnd < 0) nAlphaEnd = 0;


            Color ColorBacklight = BaseColour;
            Color ColorBacklightEnd = Color.FromArgb(50, 0, 0, 0);
            Color ColorGlowStart = Color.FromArgb(nAlphaEnd, 255, 255, 255);
            Color ColorGlowEnd = Color.FromArgb(nAlphaStart, 255, 255, 255);
            Color ColorFillBK = GetDarkerColour(BaseColour, 85);
            Color ColorBorder = GetDarkerColour(BaseColour, 100);

            // Draw a single colummn.
            #region BarItself
            RectangleF er = new RectangleF(rect.Left - rect.Width / 2, rect.Top - 10, rect.Width * 2F, rect.Height * 1.5F + 10);
            GraphicsPath rctPath = new GraphicsPath();
            rctPath.AddEllipse(er);

            PathGradientBrush pgr = new PathGradientBrush(rctPath);
            pgr.CenterPoint = new PointF(rect.Left + rect.Width / 2, rect.Bottom);
            pgr.CenterColor = ColorBacklight;
            pgr.SurroundColors = new Color[] { ColorBacklightEnd };

            RectangleF rectGlow = new RectangleF(rect.Left, rect.Top, rect.Width, rect.Height / 2);
            LinearGradientBrush brGlow = new LinearGradientBrush(new PointF(rectGlow.Right, rectGlow.Bottom + 1),
                new PointF(rectGlow.Right, rectGlow.Top - 1),
                ColorGlowStart, ColorGlowEnd);

            g.FillRectangle(new SolidBrush(ColorFillBK), rect);
            //gr.FillRectangle(new SolidBrush(Color.FromArgb(255, 0, 0, 0)), rectBar);
            g.FillRectangle(pgr, rect);
            g.FillRectangle(brGlow, rectGlow);
            if (DrawBorder) g.DrawRectangle(new Pen(ColorBorder, 1), rect.Left, rect.Top, rect.Width, rect.Height);
            #endregion
        }

        private static Image DrawReflection(Image img, Color toBG) // img is the original image.
        {
            //This is the static function that generates the reflection...
            int height = img.Height + 100; //Added height from the original height of the image.
            Bitmap bmp = new Bitmap(img.Width, height, System.Drawing.Imaging.PixelFormat.Format64bppPArgb); //A new bitmap.
            Brush brsh = new LinearGradientBrush(new Rectangle(0, 0, img.Width + 10, height), Color.Transparent, toBG, LinearGradientMode.Vertical);//The Brush that generates the fading effect to a specific color of your background.
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution); //Sets the new bitmap's resolution.
            using (Graphics grfx = Graphics.FromImage(bmp)) //A graphics to be generated from an image (here, the new Bitmap we've created (bmp)).
            {
                Bitmap bm = (Bitmap)img; //Generates a bitmap from the original image (img).
                grfx.DrawImage(bm, 0, 0, img.Width, img.Height); //Draws the generated bitmap (bm) to the new bitmap (bmp).
                Bitmap bm1 = (Bitmap)img; //Generates a bitmap again from the original image (img).
                bm1.RotateFlip(RotateFlipType.Rotate180FlipX); //Flips and rotates the image (bm1).
                grfx.DrawImage(bm1, 0, img.Height); //Draws (bm1) below (bm) so it serves as the reflection image.
                Rectangle rt = new Rectangle(0, img.Height, img.Width, 100); //A new rectangle to paint our gradient effect.
                grfx.FillRectangle(brsh, rt); //Brushes the gradient on (rt).
            }
            return bmp; //Returns the (bmp) with the generated image.
        }
        #endregion

        #region ... TabControl ...
        public enum TabHeaderStatus : int
        {
            Normal = 0,
            NormalPreserve = 1,
            Hot = 2,
            Selected = 3,
            HotSelected = 4
        };

        public static void DrawTabHeader(Graphics g, Point[] pt, Rectangle rect, Color LightColour, Color MiddleColour, Color ExtraColour, float Angle, TabAlignment Ta, bool Extended, TabHeaderStatus Status, bool PreserveColour)
        {
            switch (Ta)
            {
                case TabAlignment.Top:
                    Angle = 90F;
                    break;

                case TabAlignment.Bottom:
                    break;

                case TabAlignment.Left:
                    Angle = 0F;
                    break;

                case TabAlignment.Right:
                    Angle = 180F;
                    if (Extended)
                    {
                        switch (Status)
                        {
                            case TabHeaderStatus.Selected:
                                LightColour = ExtraColour;
                                break;
                            case TabHeaderStatus.HotSelected:
                                LightColour = ExtraColour;
                                break;
                        }
                    }
                    break;
            }

            //check on all whites
            if (MiddleColour == Color.White)
            {
                //MiddleColor = GetDarkerColor(Color.White);
            }
            //If Extended or not
            if (Extended)
            {
                g.FillPolygon(new LinearGradientBrush(rect, MiddleColour, LightColour, Angle), pt);
            }
            else
            {
                g.FillPolygon(GetBrush(rect, LightColour, MiddleColour, PaletteColourStyle.Default, Angle, (VisualOrientation)Ta, PreserveColour), pt);
            }
        }

        public static void DrawTabHeader(Graphics g, GraphicsPath path, Rectangle rect, Color LightColour, Color MiddleColour, Color ExtraColour, float Angle, TabAlignment Ta, bool Extended, TabHeaderStatus Status, bool PreserveColour)
        {
            switch (Ta)
            {
                case TabAlignment.Top:
                    Angle = 90F;
                    break;

                case TabAlignment.Bottom:
                    break;

                case TabAlignment.Left:
                    Angle = 0F;
                    break;

                case TabAlignment.Right:
                    Angle = 180F;
                    if (Extended)
                    {
                        switch (Status)
                        {
                            case TabHeaderStatus.Selected:
                                LightColour = ExtraColour;
                                break;
                            case TabHeaderStatus.HotSelected:
                                LightColour = ExtraColour;
                                break;
                        }
                    }
                    break;
            }

            //check on all whites
            if (MiddleColour == Color.White)
            {
                MiddleColour = GetDarkerColour(Color.White);
            }
            //If Extended or not
            if (Extended)
            {
                g.FillPath(new LinearGradientBrush(rect, MiddleColour, LightColour, Angle), path);
            }
            else
            {
                g.FillPath(DrawingMethods.GetBrush(rect, LightColour, MiddleColour, PaletteColourStyle.Default, Angle, (VisualOrientation)Ta, PreserveColour), path);
            }
        }

        public static void DrawTabHeader(Graphics g, PointF[] pt, Rectangle rect, Color LightColour, Color MiddleColour, Color DarkColour, Color ExtraColour, float Angle, TabAlignment Ta, bool Extended, TabHeaderStatus Status)
        {
            //Split the area, new half height

            float HalfSize = (int)rect.Height / 2 - 2;

            //Calc new points
            PointF[] NewUpPt = new PointF[5];

            switch (Ta)
            {
                case TabAlignment.Top:
                    NewUpPt[0] = pt[0];
                    NewUpPt[1] = new PointF(pt[0].X, pt[2].Y + HalfSize);
                    NewUpPt[2] = new PointF(pt[5].X, pt[3].Y + HalfSize);
                    NewUpPt[3] = pt[5];
                    NewUpPt[4] = pt[6];
                    Angle = 90F;
                    DarkColour = DrawingMethods.GetModifiedColour(DarkColour, 5, 0, 0);
                    MiddleColour = DrawingMethods.GetModifiedColour(MiddleColour, -10, 0, 0);
                    break;

                case TabAlignment.Bottom:
                    NewUpPt[0] = new PointF(pt[5].X, pt[4].Y - HalfSize);
                    NewUpPt[1] = pt[0];
                    NewUpPt[2] = pt[1];
                    NewUpPt[3] = new PointF(pt[1].X, pt[3].Y - HalfSize);
                    NewUpPt[4] = new PointF(pt[5].X, pt[4].Y - HalfSize);
                    Angle = 270F;
                    DarkColour = DrawingMethods.GetModifiedColour(DarkColour, 10, 0, 0);
                    MiddleColour = DrawingMethods.GetModifiedColour(MiddleColour, -10, 0, 0);
                    break;

                case TabAlignment.Left:
                    HalfSize = (int)rect.Width / 2 - 2;
                    NewUpPt[0] = new PointF(pt[3].X + HalfSize, pt[2].Y);
                    NewUpPt[1] = new PointF(pt[4].X + HalfSize, pt[5].Y);
                    NewUpPt[2] = pt[0];
                    NewUpPt[3] = pt[1];
                    NewUpPt[4] = new PointF(pt[3].X + HalfSize, pt[2].Y);
                    Angle = 0F;
                    DarkColour = DrawingMethods.GetModifiedColour(DarkColour, 10, 0, 0);
                    MiddleColour = DrawingMethods.GetModifiedColour(MiddleColour, -10, 0, 0);
                    break;

                case TabAlignment.Right:
                    if (!Extended)
                    {
                        HalfSize = (int)rect.Width / 2 - 2;
                        NewUpPt[0] = pt[1];
                        NewUpPt[1] = pt[0];
                        NewUpPt[2] = new PointF(pt[4].X - HalfSize, pt[5].Y);
                        NewUpPt[3] = new PointF(pt[3].X - HalfSize, pt[2].Y);
                        NewUpPt[4] = pt[1];
                        /*
                        NewUpPt[0] = pt[0];
                        NewUpPt[1] = pt[1];
                        NewUpPt[2] = new Point(pt[1].X + HalfSize, pt[1].Y);
                        NewUpPt[3] = new Point(pt[0].X + HalfSize, pt[0].Y);
                        NewUpPt[4] = pt[0];
                        */

                        Angle = 180F;
                        DarkColour = DrawingMethods.GetModifiedColour(DarkColour, 10, 0, 0);
                        MiddleColour = DrawingMethods.GetModifiedColour(MiddleColour, -10, 0, 0);
                    }
                    else
                    {
                        NewUpPt = new PointF[7];
                        NewUpPt[0] = pt[0];
                        NewUpPt[1] = pt[1];
                        NewUpPt[2] = pt[2];
                        NewUpPt[3] = pt[3];
                        NewUpPt[4] = pt[4];
                        NewUpPt[5] = pt[5];
                        NewUpPt[6] = pt[6];
                        Angle = 180F;
                        //DarkColor = DrawingMethods.GetModifiedColor(DarkColor, 10);
                        //MiddleColor = DrawingMethods.GetModifiedColor(MiddleColor, -10);
                        switch (Status)
                        {
                            case TabHeaderStatus.NormalPreserve:
                                if (DarkColour == Color.White)
                                { DarkColour = Color.WhiteSmoke; }
                                else { DarkColour = DrawingMethods.GetModifiedColour(DarkColour, 5, 0, 0); }
                                MiddleColour = LightColour;

                                break;

                            case TabHeaderStatus.Normal:
                                LightColour = DarkColour; //to store value (buffer)
                                DarkColour = DrawingMethods.GetModifiedColour(MiddleColour, 5, 0, 0);
                                MiddleColour = LightColour;
                                break;

                            case TabHeaderStatus.Selected:
                                MiddleColour = ExtraColour;
                                break;

                            case TabHeaderStatus.Hot:
                                //MiddleColor = Color.White;
                                //DarkColor = DrawingMethods.GetModifiedColor(DarkColor, 5);
                                break;

                            case TabHeaderStatus.HotSelected:
                                //LightColor = DrawingMethods.GetModifiedColor(LightColor, +50);
                                break;
                        }

                    }
                    break;
            }



            //check on all whites
            if ((MiddleColour == Color.White) && (DarkColour == Color.White))
            {
                MiddleColour = Color.WhiteSmoke;
                DarkColour = Color.Snow;
            }

            //fill the light part (top)
            using (LinearGradientBrush b = new LinearGradientBrush(rect, LightColour, MiddleColour, Angle))
            {
                //DrawGradientPolygon(g, pt, rect,  MiddleColor,LightColor);
                g.FillPolygon(b, pt, FillMode.Winding);
            }

            //White Effect
            using (LinearGradientBrush b = new LinearGradientBrush(rect, Color.FromArgb(180, Color.White), Color.FromArgb(20, Color.White), Angle))
            {
                //DrawGradientPolygon(g, pt, rect,  MiddleColor,LightColor);
                g.FillPolygon(b, pt, FillMode.Winding);
            }


            //Fill the rest
            using (LinearGradientBrush b = new LinearGradientBrush(rect, MiddleColour, DarkColour, Angle))
            {

                g.FillPolygon(b, NewUpPt);
            }
        }

        public static GraphicsPath GetTabRoundedPath(Rectangle bounds, int radius, TabAlignment orientation, bool IsForBorder, DrawingMethods.TabHeaderStatus Status, TabAppearance Appearance, int allowSelectedTabHighSize)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            switch (orientation)
            {
                case TabAlignment.Top:
                    if (IsForBorder)
                    {
                        bounds.Offset(1, 1);
                        bounds.Width -= 2;
                        if ((Status != TabHeaderStatus.HotSelected) && (Status != TabHeaderStatus.Selected))
                        {
                            bounds.Height -= 2;
                        }
                    }
                    return GetRoundedTopPath(bounds, radius, Appearance, Status, allowSelectedTabHighSize);
                //break;

                case TabAlignment.Bottom:
                    if (IsForBorder)
                    {
                        if ((Status != TabHeaderStatus.HotSelected) && (Status != TabHeaderStatus.Selected))
                        {
                            bounds.Offset(1, +1);
                            bounds.Height -= 2;
                        }
                        else
                        {
                            bounds.Offset(1, -1);
                        }
                        bounds.Width -= 2;
                    }
                    return GetRoundedBottomPath(bounds, radius, Appearance, Status, allowSelectedTabHighSize);
                // break;

                case TabAlignment.Left:
                    if (IsForBorder)
                    {
                        bounds.Offset(1, 1);
                        bounds.Height -= 2;
                        if ((Status != TabHeaderStatus.HotSelected) && (Status != TabHeaderStatus.Selected))
                        {
                            bounds.Width -= 2;
                        }
                    }
                    return GetRoundedLeftPath(bounds, radius);
                // break;

                case TabAlignment.Right:
                    if (IsForBorder)
                    {
                        if ((Status != TabHeaderStatus.HotSelected) && (Status != TabHeaderStatus.Selected))
                        {
                            bounds.Offset(1, 1);
                            bounds.Width -= 2;
                        }
                        else
                        {
                            bounds.Offset(-1, 1);
                        }
                        bounds.Height -= 2;
                    }
                    return GetRoundedRightPath(bounds, radius);
                    //break;
            }

            return graphicsPath;
        }

        public static Point[] GetTabSquaredPoints(Rectangle bounds, int cornerWidth, TabAlignment orientation, int cornerLeftWidth, int cornerRightWidth, TabAppearance Appearance, DrawingMethods.TabHeaderStatus Status, int allowSelectedTabHighSize, bool IsForBorder)
        {
            Point[] pt = new Point[7];

            switch (orientation)
            {
                case TabAlignment.Top:
                    if (IsForBorder)
                    {
                        bounds.Offset(1, 1);
                        bounds.Width -= 2;
                        if ((Status != TabHeaderStatus.HotSelected) && (Status != TabHeaderStatus.Selected))
                        {
                            bounds.Height -= 2;
                        }
                    }
                    return GetSquaredTopPoints(bounds, cornerWidth, cornerLeftWidth, cornerRightWidth, Appearance, Status, allowSelectedTabHighSize);
                // break;

                case TabAlignment.Bottom:
                    if (IsForBorder)
                    {
                        if ((Status != TabHeaderStatus.HotSelected) && (Status != TabHeaderStatus.Selected))
                        {
                            bounds.Offset(1, +1);
                            bounds.Height -= 2;
                        }
                        else
                        {
                            bounds.Offset(1, -1);
                        }
                        bounds.Width -= 2;
                    }
                    return GetSquaredBottomPoints(bounds, cornerWidth, cornerLeftWidth, cornerRightWidth, Appearance, Status, allowSelectedTabHighSize);
                //break;

                case TabAlignment.Left:
                    if (IsForBorder)
                    {
                        bounds.Offset(1, 1);
                        bounds.Height -= 2;
                        if ((Status != TabHeaderStatus.HotSelected) && (Status != TabHeaderStatus.Selected))
                        {
                            bounds.Width -= 2;
                        }
                    }
                    return GetSquaredLeftPoints(bounds, cornerWidth, cornerLeftWidth, cornerRightWidth, Appearance, Status, allowSelectedTabHighSize);
                //break;

                case TabAlignment.Right:
                    if (IsForBorder)
                    {
                        if ((Status != TabHeaderStatus.HotSelected) && (Status != TabHeaderStatus.Selected))
                        {
                            bounds.Offset(1, 1);
                            bounds.Width -= 2;
                        }
                        else
                        {
                            bounds.Offset(-1, 1);
                        }
                        bounds.Height -= 2;
                    }
                    return GetSquaredRightPoints(bounds, cornerWidth, cornerLeftWidth, cornerRightWidth, Appearance, Status, allowSelectedTabHighSize);
                    //break;
            }

            return pt;
        }

        public static Point[] GetSquaredTopPoints(Rectangle recBounds, int cornerWidth, int cornerLeftWidth, int cornerRightWidth, TabAppearance Appearance, DrawingMethods.TabHeaderStatus Status, int allowSelectedTabHighSize)
        {
            Point[] pt = new Point[7];

            pt[0] = new Point(recBounds.Left, recBounds.Bottom);
            pt[1] = new Point(recBounds.Left, recBounds.Top + cornerLeftWidth + allowSelectedTabHighSize); //little lower
            pt[2] = new Point(recBounds.Left + cornerLeftWidth, recBounds.Top + allowSelectedTabHighSize); //little lower
            pt[3] = new Point(recBounds.Right - cornerRightWidth, recBounds.Top + allowSelectedTabHighSize); //little lower
            pt[4] = new Point(recBounds.Right, recBounds.Top + cornerRightWidth + allowSelectedTabHighSize); //little lower
            if ((Appearance == TabAppearance.Normal) && ((Status == DrawingMethods.TabHeaderStatus.Selected) || (Status == DrawingMethods.TabHeaderStatus.HotSelected)))
            { //a litte Higher if selected
                pt[1] = new Point(pt[1].X, pt[1].Y - allowSelectedTabHighSize);
                pt[2] = new Point(pt[2].X, pt[2].Y - allowSelectedTabHighSize);
                pt[3] = new Point(pt[3].X, pt[3].Y - allowSelectedTabHighSize);
                pt[4] = new Point(pt[4].X, pt[4].Y - allowSelectedTabHighSize);
            }

            pt[5] = new Point(recBounds.Right, recBounds.Bottom);
            pt[6] = new Point(recBounds.Left, recBounds.Bottom);

            return pt;

        }

        public static Point[] GetSquaredBottomPoints(Rectangle recBounds, int cornerWidth, int cornerLeftWidth, int cornerRightWidth, TabAppearance Appearance, DrawingMethods.TabHeaderStatus Status, int allowSelectedTabHighSize)
        {
            Point[] pt = new Point[7];

            pt[0] = new Point(recBounds.Left, recBounds.Top);
            pt[1] = new Point(recBounds.Right, recBounds.Top);
            pt[2] = new Point(recBounds.Right, recBounds.Bottom - cornerRightWidth - allowSelectedTabHighSize);//little lower
            pt[3] = new Point(recBounds.Right - cornerRightWidth, recBounds.Bottom - allowSelectedTabHighSize);//little lower
            pt[4] = new Point(recBounds.Left + cornerLeftWidth, recBounds.Bottom - allowSelectedTabHighSize);//little lower
            pt[5] = new Point(recBounds.Left, recBounds.Bottom - cornerLeftWidth - allowSelectedTabHighSize);//little lower
            if ((Appearance == TabAppearance.Normal) && ((Status == DrawingMethods.TabHeaderStatus.Selected) || (Status == DrawingMethods.TabHeaderStatus.HotSelected)))
            { //a litte Higher if selected
                pt[2] = new Point(pt[2].X, pt[2].Y + allowSelectedTabHighSize);
                pt[3] = new Point(pt[3].X, pt[3].Y + allowSelectedTabHighSize);
                pt[4] = new Point(pt[4].X, pt[4].Y + allowSelectedTabHighSize);
                pt[5] = new Point(pt[5].X, pt[5].Y + allowSelectedTabHighSize);
            }
            pt[6] = new Point(recBounds.Left, recBounds.Top);

            return pt;
        }

        public static Point[] GetSquaredLeftPoints(Rectangle recBounds, int cornerWidth, int cornerLeftWidth, int cornerRightWidth, TabAppearance Appearance, DrawingMethods.TabHeaderStatus Status, int allowSelectedTabHighSize)
        {
            Point[] pt = new Point[7];
            pt[0] = new Point(recBounds.Right, recBounds.Top);
            pt[1] = new Point(recBounds.Right, recBounds.Bottom);
            pt[2] = new Point(recBounds.Left + cornerWidth, recBounds.Bottom);
            pt[3] = new Point(recBounds.Left, recBounds.Bottom - cornerWidth);
            pt[4] = new Point(recBounds.Left, recBounds.Top + cornerWidth);
            pt[5] = new Point(recBounds.Left + cornerWidth, recBounds.Top);
            pt[6] = new Point(recBounds.Right, recBounds.Top);
            return pt;
        }

        public static Point[] GetSquaredRightPoints(Rectangle recBounds, int cornerWidth, int cornerLeftWidth, int cornerRightWidth, TabAppearance Appearance, DrawingMethods.TabHeaderStatus Status, int allowSelectedTabHighSize)
        {
            Point[] pt = new Point[7];

            pt[0] = new Point(recBounds.Left, recBounds.Top);
            pt[1] = new Point(recBounds.Left, recBounds.Bottom);
            pt[2] = new Point(recBounds.Right - cornerWidth, recBounds.Bottom);
            pt[3] = new Point(recBounds.Right, recBounds.Bottom - cornerWidth);
            pt[4] = new Point(recBounds.Right, recBounds.Top + cornerWidth);
            pt[5] = new Point(recBounds.Right - cornerWidth, recBounds.Top);
            pt[6] = new Point(recBounds.Left, recBounds.Top);

            return pt;
        }

        public static void ClearTabSelectedBottomLine(Graphics g, Rectangle recBounds, Pen pen, TabAlignment Alignment)
        {

            switch (Alignment)
            {
                case TabAlignment.Top:
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom, recBounds.Right - 1, recBounds.Bottom);
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom + 1, recBounds.Right - 1, recBounds.Bottom + 1);
                    break;

                case TabAlignment.Bottom:
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Top, recBounds.Right - 1, recBounds.Top);
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 1, recBounds.Right - 1, recBounds.Top - 1);
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 2, recBounds.Right - 1, recBounds.Top - 2);
                    break;

                case TabAlignment.Right:
                    g.DrawLine(pen, recBounds.Left, recBounds.Top + 1, recBounds.Left, recBounds.Bottom - 1);
                    g.DrawLine(pen, recBounds.Left - 1, recBounds.Top + 1, recBounds.Left - 1, recBounds.Bottom - 1);
                    g.DrawLine(pen, recBounds.Left - 2, recBounds.Top + 1, recBounds.Left - 2, recBounds.Bottom - 1);
                    g.DrawLine(pen, recBounds.Left - 3, recBounds.Top + 1, recBounds.Left - 3, recBounds.Bottom - 1);
                    break;

                case TabAlignment.Left:
                    g.DrawLine(pen, recBounds.Right, recBounds.Top + 1, recBounds.Right, recBounds.Bottom - 1);
                    g.DrawLine(pen, recBounds.Right + 1, recBounds.Top + 1, recBounds.Right + 1, recBounds.Bottom - 1);
                    g.DrawLine(pen, recBounds.Right + 2, recBounds.Top + 1, recBounds.Right + 2, recBounds.Bottom - 1);
                    g.DrawLine(pen, recBounds.Right + 3, recBounds.Top + 1, recBounds.Right + 3, recBounds.Bottom - 1);
                    break;
            }

        }
        #endregion

        #region ... ListView ...
        public static void DrawListViewHeader2(Graphics g, Rectangle rect, Color LightColour, Color MiddleColour, Color DarkColour, Color ExtraColour, float Angle)
        {

            //Split the area, new half height
            int HalfSize = (int)rect.Height / 2 - 2;

            Rectangle Newrect = new Rectangle(rect.X, rect.Y + HalfSize, rect.Width, rect.Height - HalfSize);

            //check on all whites
            if ((MiddleColour == Color.White) && (DarkColour == Color.White))
            {
                MiddleColour = Color.WhiteSmoke;
                DarkColour = Color.Snow;
            }

            //fill the light part (top)
            using (LinearGradientBrush b = new LinearGradientBrush(rect, LightColour, MiddleColour, Angle))
            {
                //DrawGradient(g, rect, MiddleColor, LightColor);
                g.FillRectangle(b, rect);
            }


            //Fill the rest
            using (LinearGradientBrush b = new LinearGradientBrush(Newrect, MiddleColour, DarkColour, Angle))
            {
                g.FillRectangle(b, Newrect);
            }
        }
        public static void DrawListViewHeader(Graphics g, Rectangle rect, Color LightColor, Color DarkColor, float Angle)
        {
            //check on all whites
            if (DarkColor == Color.White) DarkColor = Color.Snow;

            //fill the light part (top)
            using (Brush b = GetBrush(rect, LightColor, DarkColor, PaletteColourStyle.Default, Angle, VisualOrientation.Top, false))
            {
                g.FillRectangle(b, rect);
            }
        }

        #endregion

        #region ... ColourManipulation ...
        public static Color GetDarkerColour(Color clr)
        {
            Color c = new Color();
            int r, g, b;

            r = clr.R - 18;
            g = clr.G - 18;
            b = clr.B - 18;

            if (r < 0) r = 0;
            if (g < 0) g = 0;
            if (b < 0) b = 0;

            c = Color.FromArgb(r, g, b);
            return c;
        }

        public static Color GetDarkerColour(Color clr, int amount)
        {
            Color c = new Color();
            int r, g, b;

            r = clr.R - amount;
            g = clr.G - amount;
            b = clr.B - amount;

            if (r < 0) r = 0;
            if (g < 0) g = 0;
            if (b < 0) b = 0;

            c = Color.FromArgb(r, g, b);
            return c;
        }

        public static Color GetLighterColour(Color clr, int amount)
        {
            Color c = new Color();
            int r, g, b;

            r = clr.R + amount;
            g = clr.G + amount;
            b = clr.B + amount;

            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;

            c = Color.FromArgb(r, g, b);
            return c; // System.Windows.Forms.ControlPaint.Light(clr, 0.5F);
        }

        public static Color GetLighterColour(Color clr)
        {
            Color c = new Color();
            int r, g, b;

            r = clr.R + 18;
            g = clr.G + 18;
            b = clr.B + 18;

            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;

            c = Color.FromArgb(r, g, b);
            return c; // System.Windows.Forms.ControlPaint.Light(clr, 0.5F);
        }

        public static Color GetModifiedColour(Color clr, int britness, int saturation, int hue)
        {
            Color c = new Color();

            ColourHandler.RGB rgb = new ColourHandler.RGB(clr.R, clr.G, clr.B);
            ColourHandler.HSV hsv = ColourHandler.RGBtoHSV(rgb);

            hsv.value += britness;
            hsv.Saturation += saturation;
            hsv.Hue += hue;

            rgb = ColourHandler.HSVtoRGB(hsv);

            int r, g, b;

            r = rgb.Red;
            g = rgb.Green;
            b = rgb.Blue;

            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;

            if (r < 0) r = 0;
            if (g < 0) g = 0;
            if (b < 0) b = 0;

            c = Color.FromArgb(r, g, b);

            return c;
        }
        public static Color GetSystemDarkerColour(Color clr)
        {
            return ControlPaint.Dark(clr);
        }
        public static Color GetSystemDarkerDarkColour(Color clr)
        {
            return ControlPaint.DarkDark(clr);
        }

        public static Color GetSystemLighterColour(Color clr)
        {
            return ControlPaint.Light(clr);
        }
        public static Color GetSystemLighterLightColour(Color clr)
        {
            return ControlPaint.LightLight(clr);
        }

        public static Brush GetBrush(Rectangle rect, Color ColourBegin, Color ColourEnd, PaletteColourStyle ColourStyle, float Angle, VisualOrientation orientation, bool PreserveColours)
        {
            Blend blend1 = new Blend(4);
            Blend blend2;
            Blend blend3;
            Blend blend4;
            Blend blend5;
            Blend blend6;
            Blend blend7;
            Blend blend8;
            Blend blend9;
            Blend blend10;
            Blend blend11;
            Blend blend12;

            // One time creation of the blend for the status strip gradient brush
            Blend blend13 = new Blend();
            blend13.Positions = new float[] { 0.0f, 0.25f, 0.25f, 0.57f, 0.86f, 1.0f };
            blend13.Factors = new float[] { 0.1f, 0.6f, 1.0f, 0.4f, 0.0f, 0.95f };

            //Default
            blend1.Positions[0] = 0f;
            blend1.Factors[0] = 1f;
            blend1.Positions[1] = 0.4f;
            blend1.Factors[1] = 0.5f;
            blend1.Positions[2] = 0.4f;
            blend1.Factors[2] = 0.1f; //0 darker 0.3 lighter (middle line)
            blend1.Positions[3] = 1f;
            blend1.Factors[3] = 0.9f;

            float[] numArray = new float[4];
            numArray[2] = 1f;
            numArray[3] = 1f;
            blend2 = new Blend();
            float[] numArray2 = new float[4];
            numArray2[2] = 1f;
            numArray2[3] = 1f;
            blend2.Factors = numArray2;
            blend2.Positions = new float[] { 0f, 0.33f, 0.33f, 1f };
            blend3 = new Blend();
            float[] numArray3 = new float[4];
            numArray3[2] = 1f;
            numArray3[3] = 1f;
            blend3.Factors = numArray3;
            blend3.Positions = new float[] { 0f, 0.5f, 0.5f, 1f };
            blend4 = new Blend();
            float[] numArray4 = new float[4];
            numArray4[3] = 1f;
            blend4.Factors = numArray4;
            blend4.Positions = new float[] { 0f, 0.9f, 0.9f, 1f };
            blend5 = new Blend();
            blend5.Factors = new float[] { 0f, 0.5f, 1f, 0.05f };
            blend5.Positions = new float[] { 0f, 0.45f, 0.45f, 1f };
            blend6 = new Blend();
            blend6.Factors = new float[] { 0f, 0f, 0.25f, 0.7f, 1f, 1f };
            blend6.Positions = new float[] { 0f, 0.1f, 0.2f, 0.3f, 0.5f, 1f };
            blend7 = new Blend();
            blend7.Factors = new float[] { 0.15f, 0.75f, 1f, 1f };
            blend7.Positions = new float[] { 0f, 0.45f, 0.45f, 1f };
            blend8 = new Blend();
            blend8.Factors = new float[] { 0.8f, 0.2f, 0f, 0.07f, 1f };
            blend8.Positions = new float[] { 0f, 0.33f, 0.33f, 0.43f, 1f };
            blend9 = new Blend();
            blend9.Factors = new float[] { 1f, 0.7f, 0.7f, 0f, 0.1f, 0.55f, 1f, 1f };
            blend9.Positions = new float[] { 0f, 0.16f, 0.33f, 0.35f, 0.51f, 0.85f, 0.85f, 1f };
            blend10 = new Blend();
            blend10.Factors = new float[] { 1f, 0.78f, 0.48f, 1f, 1f };
            blend10.Positions = new float[] { 0f, 0.33f, 0.33f, 0.9f, 1f };
            blend11 = new Blend();
            blend12 = new Blend();
            blend12.Factors = numArray;
            blend12.Positions = new float[] { 0f, 0.25f, 0.25f, 1f };


            //For Gefault Type Only
            if (ColourStyle == PaletteColourStyle.Default)
            {
                LinearGradientBrush lb;
                if (PreserveColours)
                { lb = new LinearGradientBrush(rect, ColourEnd, ColourBegin, Angle); }
                else
                { lb = new LinearGradientBrush(rect, GetDarkerColour(ColourEnd), GetLighterColour(ColourBegin), Angle); }

                lb.Blend = blend1;
                return lb;
            }


            //Solid
            if (ColourStyle == PaletteColourStyle.Solid)
            {
                return new SolidBrush(ColourBegin);
            }

            switch (orientation)
            {
                case VisualOrientation.Bottom:
                    Angle += 180f;
                    break;

                case VisualOrientation.Left:
                    Angle -= 90f;
                    break;

                case VisualOrientation.Right:
                    Angle += 90f;
                    break;
            }

            //One Note Specific
            if (ColourStyle == PaletteColourStyle.OneNote)
            {
                ColourBegin = Color.White;
            }

            //Others
            LinearGradientBrush brush = new LinearGradientBrush(rect, ColourBegin, ColourEnd, Angle);
            switch (ColourStyle)
            {
                case PaletteColourStyle.Status:
                    brush.Blend = blend13;
                    return brush;

                case PaletteColourStyle.Switch25:
                    brush.Blend = blend12;
                    return brush;

                case PaletteColourStyle.Switch33:
                    brush.Blend = blend2;
                    return brush;

                case PaletteColourStyle.Switch50:
                    brush.Blend = blend3;
                    return brush;

                case PaletteColourStyle.Switch90:
                    brush.Blend = blend4;
                    return brush;

                case PaletteColourStyle.Linear:
                    return brush;

                case PaletteColourStyle.Rounded:
                    brush.SetSigmaBellShape(1f, 1f);
                    return brush;

                case PaletteColourStyle.Rounding2:
                    brush.Blend = blend8;
                    return brush;

                case PaletteColourStyle.Rounding3:
                    brush.Blend = blend9;
                    return brush;

                case PaletteColourStyle.Rounding4:
                    brush.Blend = blend10;
                    return brush;

                case PaletteColourStyle.Sigma:
                    brush.SetSigmaBellShape(0.5f);
                    return brush;

                case PaletteColourStyle.HalfCut:
                    brush.Blend = blend5;
                    return brush;

                case PaletteColourStyle.QuarterPhase:
                    brush.Blend = blend6;
                    return brush;

                case PaletteColourStyle.OneNote:
                    brush.Blend = blend7;
                    return brush;
            }
            return brush;
        }

        public enum CornerType
        {
            Rounded,
            Squared
        }

        public enum VisualOrientation
        {
            Top,
            Bottom,
            Left,
            Right
        }

        public enum PaletteColourStyle
        {
            Default,
            Solid,
            Switch25,
            Switch33,
            Switch50,
            Switch90,
            Linear,
            Rounded,
            Rounding2,
            Rounding3,
            Rounding4,
            Sigma,
            HalfCut,
            QuarterPhase,
            OneNote,
            Status
            /*GlassThreeEdge,
            GlassNormalFull,
            GlassTrackingFull,
            GlassPressedFull,
            GlassCheckedFull,
            GlassCheckedTrackingFull,
            GlassNormalStump,
            GlassTrackingStump,
            GlassPressedStump,
            GlassCheckedStump,
            GlassCheckedTrackingStump,
            GlassNormalSimple,
            GlassTrackingSimple,
            GlassPressedSimple,
            GlassCheckedSimple,
            GlassCheckedTrackingSimple,
            GlassCenter,
            GlassBottom,
            GlassFade*/
        }

        public static Color ColourFromAHSB(int Alpha, float Hue, float Saturation, float Brightness)
        {

            if (0 > Alpha || 255 < Alpha)
            {
                throw new ArgumentOutOfRangeException("a", Alpha, "InvalidAlpha");
            }
            if (0f > Hue || 360f < Hue)
            {
                throw new ArgumentOutOfRangeException("h", Hue, "InvalidHue");
            }
            if (0f > Saturation || 1f < Saturation)
            {
                throw new ArgumentOutOfRangeException("s", Saturation, "InvalidSaturation");
            }
            if (0f > Brightness || 1f < Brightness)
            {
                throw new ArgumentOutOfRangeException("b", Brightness, "InvalidBrightness");
            }

            if (0 == Saturation)
            {
                return Color.FromArgb(Alpha, Convert.ToInt32(Brightness * 255),
                  Convert.ToInt32(Brightness * 255), Convert.ToInt32(Brightness * 255));
            }

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < Brightness)
            {
                fMax = Brightness - (Brightness * Saturation) + Saturation;
                fMin = Brightness + (Brightness * Saturation) - Saturation;
            }
            else
            {
                fMax = Brightness + (Brightness * Saturation);
                fMin = Brightness - (Brightness * Saturation);
            }

            iSextant = (int)Math.Floor(Hue / 60f);
            if (300f <= Hue)
            {
                Hue -= 360f;
            }
            Hue /= 60f;
            Hue -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = Hue * (fMax - fMin) + fMin;
            }
            else
            {
                fMid = fMin - Hue * (fMax - fMin);
            }

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb(Alpha, iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(Alpha, iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(Alpha, iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(Alpha, iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(Alpha, iMax, iMin, iMid);
                default:
                    return Color.FromArgb(Alpha, iMax, iMid, iMin);
            }
        }

        #endregion

        #region ... Graphic Paths ...

        public static GraphicsPath CreateRectGraphicsPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            return path;
        }

        public static GraphicsPath GetRoundedTopPath(Rectangle bounds, int radius, TabAppearance Appearance, DrawingMethods.TabHeaderStatus Status, int allowSelectedTabHighSize)
        {
            int x = bounds.X;
            int y = bounds.Y;
            int width = bounds.Width;
            int height = bounds.Height;
            GraphicsPath graphicsPath = new GraphicsPath();
            if ((Appearance == TabAppearance.Normal) && ((Status == DrawingMethods.TabHeaderStatus.Selected) || (Status == DrawingMethods.TabHeaderStatus.HotSelected)))
            {
                //graphicsPath.AddLine(x, y + height, x, y - radius);                     //Left Line
                graphicsPath.AddArc(x, y, radius, radius, 180, 90);                     //Upper left corner
                graphicsPath.AddLine(x + radius, y, x + width - radius - radius, y);    //top Line
                graphicsPath.AddArc(x + width - radius, y, radius, radius, 270, 90);    //Upper right corner
                //graphicsPath.AddLine(x + width, y + radius, x + width, y + height-radius); //Right Line
                graphicsPath.AddLine(x + width, y + height, x, y + height);             //Bottom Line
            }
            else
            {
                //graphicsPath.AddLine(x, y + height, x, y - radius);                     //Left Line
                graphicsPath.AddArc(x, y + allowSelectedTabHighSize, radius, radius, 180, 90);                     //Upper left corner
                graphicsPath.AddLine(x + radius, y + allowSelectedTabHighSize, x + width - radius - radius, y + allowSelectedTabHighSize);    //top Line
                graphicsPath.AddArc(x + width - radius, y + allowSelectedTabHighSize, radius, radius, 270, 90);    //Upper right corner
                //graphicsPath.AddLine(x + width, y + radius, x + width, y + height-radius); //Right Line
                graphicsPath.AddLine(x + width, y + height, x, y + height);             //Bottom Line
            }



            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        public static GraphicsPath GetRoundedBottomPath(Rectangle bounds, int radius, TabAppearance Appearance, DrawingMethods.TabHeaderStatus Status, int allowSelectedTabHighSize)
        {
            int x = bounds.X;
            int y = bounds.Y;
            int width = bounds.Width;
            int height = bounds.Height;
            GraphicsPath graphicsPath = new GraphicsPath();

            if ((Appearance == TabAppearance.Normal) && ((Status == DrawingMethods.TabHeaderStatus.Selected) || (Status == DrawingMethods.TabHeaderStatus.HotSelected)))
            {
                //girare sempre in senso orario
                graphicsPath.AddLine(x, y, x + width, y); //top
                graphicsPath.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);//Lower right corner
                graphicsPath.AddLine(x + width - radius, y + height, x + radius, y + height); //Bottom
                graphicsPath.AddArc(x, y + height - radius, radius, radius, 90, 90); //LowerLeft Corner
            }

            else
            {
                //girare sempre in senso orario
                graphicsPath.AddLine(x, y, x + width, y); //top
                graphicsPath.AddArc(x + width - radius, y + height - radius - allowSelectedTabHighSize, radius, radius, 0, 90);//Lower right corner
                graphicsPath.AddLine(x + width - radius, y + height - allowSelectedTabHighSize, x + radius, y + height - allowSelectedTabHighSize); //Bottom
                graphicsPath.AddArc(x, y + height - radius - allowSelectedTabHighSize, radius, radius, 90, 90); //LowerLeft Corner
            }

            graphicsPath.CloseFigure();
            return graphicsPath;
        }
        public static GraphicsPath GetRoundedLeftPath(Rectangle bounds, int radius)
        {
            //to implement
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(bounds);
            return path;
        }

        public static GraphicsPath GetRoundedRightPath(Rectangle bounds, int radius)
        {
            //to implement
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(bounds);
            return path;
        }

        public static GraphicsPath GetRoundedSquarePath(Rectangle bounds, int radius)
        {
            int x = bounds.X, y = bounds.Y, w = bounds.Width, h = bounds.Height;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(x, y, radius, radius, 180, 90);				//Upper left corner
            path.AddArc(x + w - radius, y, radius, radius, 270, 90);			//Upper right corner
            path.AddArc(x + w - radius, y + h - radius, radius, radius, 0, 90);		//Lower right corner
            path.AddArc(x, y + h - radius, radius, radius, 90, 90);			//Lower left corner
            path.CloseFigure();
            return path;
        }
        #endregion

        #region ... Graphic Polygon ...
        public static PointF[] GetPoligonPointsFromPath(GraphicsPath path)
        {
            return path.PathPoints;
        }
        #endregion
    }
}
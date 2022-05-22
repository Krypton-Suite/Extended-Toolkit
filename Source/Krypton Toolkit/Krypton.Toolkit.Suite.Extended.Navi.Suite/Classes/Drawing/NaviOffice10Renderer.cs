#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviOffice10Renderer : NaviRenderer
    {
        // Fields 
        private Image activeBandBg;

        #region Initialization Methods

        /// <summary>
        /// Initializes the drawing functionality
        /// </summary>
        public override void Initialize(NaviLayoutStyle layoutStyle)
        {
            switch (layoutStyle)
            {
                case NaviLayoutStyle.Office2010Blue:
                    ColourTable = new NaviColourTableOff10Blue();
                    break;
                case NaviLayoutStyle.Office2010Silver:
                    ColourTable = new NaviColourTableOff10Silver();
                    break;
                case NaviLayoutStyle.Office2010Black:
                    ColourTable = new NaviColourTableOff10Black();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region NaviBandCollapsed

        /// <summary>
        /// Draws the background of the collapsed band
        /// </summary>
        /// <param name="g">The canvas to draw on</param>
        /// <param name="bounds">The bounds of the drawing</param>
        /// <param name="text">The text that should appear into the bar</param>
        /// <param name="font">The font to use when drawing the text</param>
        /// <param name="state">The inputstate of the collapsed band</param>
        public override void DrawNaviBandCollapsedBg(Graphics g, Rectangle bounds, string text, Font font,
           bool rightToLeft, InputState state)
        {
            // Gradient background
            Color[] endColors = new Color[] { ColourTable.BandCollapsedBgColor1, ColourTable.BandCollapsedBgColor2 };

            if (state == InputState.Clicked)
                endColors = new Color[] { ColourTable.BandCollapsedClickedColor1, ColourTable.BandCollapsedClickedColor1 };
            else if (state == InputState.Hovered)
                endColors = new Color[] { ColourTable.BandCollapsedHoveredColor1, ColourTable.BandCollapsedHoveredColor1 };

            float[] ColorPositions = { 0.0f, 1.0f };
            ExtDrawing.DrawVertGradient(g, bounds, endColors, ColorPositions);

            bounds.Width -= 1;
            bounds.Height -= 1;

            if ((state == InputState.Hovered))
            {
                bounds.Inflate(new Size(-1, -1));
                using (Pen p = new Pen(ColourTable.Border))
                {
                    g.DrawRectangle(p, bounds);
                }

                bounds.Inflate(new Size(-1, -1));

                // Background gradient 
                if (state == InputState.Hovered)
                    endColors = new Color[] { ColourTable.ButtonHoveredColor1, ColourTable.ButtonHoveredColor2,
                     ColourTable.ButtonHoveredColor3 };
                else
                    endColors = new Color[] { ColourTable.ButtonActiveColor1, ColourTable.ButtonActiveColor2,
                     ColourTable.ButtonActiveColor3 };

                float[] ColorPositions2 = { 0.0f, 0.4f, 1.0f };
                ExtDrawing.DrawHorGradient(g, bounds, endColors, ColorPositions2);

                // Draws a nice shiney glow on the bottom of the button
                endColors = new Color[] { Color.FromArgb(1, ColourTable.ButtonActiveColor4) };
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, bounds.Height / 2, bounds.Width, bounds.Height);
                ExtDrawing.DrawRadialGradient(g, path, bounds, Color.FromArgb(150,
                   ColourTable.ButtonActiveColor4), endColors);

                // Inner borders
                if (state == InputState.Hovered)
                {
                    using (Pen p = new Pen(ColourTable.BorderInner))
                    {
                        g.DrawRectangle(p, bounds);
                    }
                }
            }
            else if (state == InputState.Clicked)
            {
                bounds.Inflate(new Size(-1, -1));
                using (Pen p = new Pen(ColourTable.Border))
                {
                    g.DrawRectangle(p, bounds);
                }

                // Background gradient 
                endColors = new Color[] { ColourTable.ButtonClickedColor3, ColourTable.ButtonClickedColor2,
                  ColourTable.ButtonClickedColor1 };

                float[] ColorPositions2 = { 0.0f, 0.8f, 1.0f };
                ExtDrawing.DrawVertGradient(g, bounds, endColors, ColorPositions2);
            }



            using (Brush brush = new SolidBrush(ColourTable.Text))
            {
                if (rightToLeft)
                {
                    Point ptCenter = new Point(bounds.X + bounds.Width / 2 + 7, bounds.Y +
                       bounds.Height / 2);
                    System.Drawing.Drawing2D.Matrix transform = g.Transform;
                    transform.RotateAt(90, ptCenter);
                    g.Transform = transform;
                    using (StringFormat format = new StringFormat())
                    {
                        format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
                        g.DrawString(text, font, brush, ptCenter, format);
                    }
                }
                else
                {
                    Point ptCenter = new Point(bounds.X + bounds.Width / 2 - 7, bounds.Y +
                       bounds.Height / 2);
                    System.Drawing.Drawing2D.Matrix transform = g.Transform;
                    transform.RotateAt(270, ptCenter);
                    g.Transform = transform;
                    g.DrawString(text, font, brush, ptCenter);
                }
            }
        }

        #endregion

        #region NaviBandPopup

        /// <summary>
        /// Draws the background of the popped up band
        /// </summary>
        /// <param name="g">The canvas to draw on</param>
        /// <param name="bounds">The bounds of the drawing</param>
        public override void DrawNaviBandPopupBg(Graphics g, Rectangle bounds)
        {
            bounds.Width -= 1;
            bounds.Height -= 1;

            using (Pen p = new Pen(ColourTable.Border))
            using (Brush b = new SolidBrush(ColourTable.PopupBandBackground1))
            {
                g.FillRectangle(b, bounds);
                g.DrawRectangle(p, bounds);
            }
        }

        #endregion

        #region NaviBand

        /// <summary>
        /// Draws the background of an Navigation band Client Area
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        /// <param name="state"></param>
        public override void DrawNaviBandClientAreaBg(Graphics g, Rectangle bounds)
        {
            // Gradient background
            activeBandBg = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppPArgb);
            using (Graphics bitmapG = Graphics.FromImage(activeBandBg))
            {
                Color[] endColors = new Color[] { ColourTable.NaviClientareaBgColor1,
               ColourTable.NaviClientareaBgColor2};

                float[] ColorPositions = { 0.0f, 1.0f };
                ExtDrawing.DrawVertGradient(bitmapG, bounds, endColors, ColorPositions);
            }

            g.DrawImageUnscaled(activeBandBg, new Point(bounds.X, bounds.Y));
        }

        #endregion

        #region NaviBar

        /// <summary>
        /// Draws the background of the NavigationBar
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the background</param>
        /// <remarks>Its sufficient to supply the ClientRectangle property of the control</remarks>
        public override void DrawNaviBarBg(Graphics g, Rectangle bounds)
        {
            bounds.Width -= 1;
            bounds.Height -= 1;

            using (Brush b = new SolidBrush(ColourTable.Background))
            {
                g.FillRectangle(b, bounds);
            }
        }

        /// <summary>
        /// Draws the background of the rectangle containing the small buttons on the bottom 
        /// of the NavigationBar
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the small rectangle</param>
        public override void DrawNaviBarOverFlowPanelBg(Graphics g, Rectangle bounds)
        {
            bounds.Width -= 1;
            bounds.Height -= 1;

            using (Brush b = new SolidBrush(ColourTable.OverflowColor1))
            {
                g.FillRectangle(b, bounds);
            }
        }

        /// <summary>
        /// Draws the header region on top of the NavigationBar
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the header</param>
        public override void DrawNaviBarHeaderBg(Graphics g, Rectangle bounds)
        {
            using (Brush b = new SolidBrush(ColourTable.HeaderColor1))
            {
                g.FillRectangle(b, bounds);
            }
        }

        #endregion

        #region NaviButton

        /// <summary>
        /// Draws the background gradients of an Button
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        public override void DrawButtonBg(Graphics g, Rectangle bounds, ControlState state, InputState inputState)
        {
            Color[] endColors = new Color[1];

            using (Brush b = new SolidBrush(ColourTable.ButtonNormalColor1))
            {
                g.FillRectangle(b, bounds);
            }

            bounds.Width -= 1;
            bounds.Height -= 1;

            if (((state == ControlState.Active) && (inputState == InputState.Normal)) ||
               (inputState == InputState.Hovered))
            {
                bounds.Inflate(new Size(-1, -1));
                using (Pen p = new Pen(ColourTable.Border))
                {
                    g.DrawRectangle(p, bounds);
                }

                bounds.Inflate(new Size(-1, -1));

                // Background gradient 
                if (inputState == InputState.Hovered)
                    endColors = new Color[] { ColourTable.ButtonHoveredColor1, ColourTable.ButtonHoveredColor2,
                     ColourTable.ButtonHoveredColor3 };
                else
                    endColors = new Color[] { ColourTable.ButtonActiveColor1, ColourTable.ButtonActiveColor2,
                     ColourTable.ButtonActiveColor3 };

                float[] ColorPositions = { 0.0f, 0.4f, 1.0f };
                ExtDrawing.DrawVertGradient(g, bounds, endColors, ColorPositions);

                // Draws a nice shiney glow on the bottom of the button

                if (inputState == InputState.Hovered)
                    endColors = new Color[] { Color.FromArgb(1, ColourTable.ButtonHoveredColor4) };
                else
                    endColors = new Color[] { Color.FromArgb(1, ColourTable.ButtonActiveColor4) };

                Color startColor;
                if (inputState == InputState.Hovered)
                    startColor = Color.FromArgb(150, ColourTable.ButtonHoveredColor4);
                else
                    startColor = Color.FromArgb(150, ColourTable.ButtonActiveColor4);

                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, bounds.Height / 2, bounds.Width, bounds.Height);
                ExtDrawing.DrawRadialGradient(g, path, bounds, startColor, endColors);

                // Inner borders
                if (inputState == InputState.Hovered)
                {
                    using (Pen p = new Pen(ColourTable.BorderInner))
                    {
                        g.DrawRectangle(p, bounds);
                    }
                }
            }
            else if (inputState == InputState.Clicked)
            {
                bounds.Inflate(new Size(-1, -1));
                using (Pen p = new Pen(ColourTable.Border))
                {
                    g.DrawRectangle(p, bounds);
                }

                // Background gradient 
                endColors = new Color[] { ColourTable.ButtonClickedColor3, ColourTable.ButtonClickedColor2,
                  ColourTable.ButtonClickedColor1 };

                float[] ColorPositions = { 0.0f, 0.8f, 1.0f };
                ExtDrawing.DrawVertGradient(g, bounds, endColors, ColorPositions);
            }
        }

        #endregion

        #region NaviButtonOptions

        /// <summary>
        /// Draws the surface of the options button
        /// </summary>
        /// <param name="g">The graphics canvas to draw on</param>
        /// <param name="bounds">The bounds of the text</param>
        public override void DrawOptionsTriangle(Graphics g, Rectangle bounds)
        {
            Point[] points = new Point[] {
            new Point(bounds.Width /2 +3,bounds.Height /2 -1),
            new Point(bounds.Width /2, bounds.Height /2 +2),
            new Point(bounds.Width /2 -2,bounds.Height /2 -1) };

            Point[] pointsRec2 = new Point[] {
            new Point(bounds.Width /2 +3,bounds.Height /2),
            new Point(bounds.Width /2, bounds.Height /2 +3),
            new Point(bounds.Width /2 -2,bounds.Height /2) };

            using (SolidBrush b = new SolidBrush(ColourTable.BorderInner))
            {
                g.FillPolygon(b, pointsRec2);
                b.Color = ColourTable.ShapesFront;
                g.FillPolygon(b, points);
            }
        }

        #endregion

        #region NaviGroup

        /// <summary>
        /// Draws the background of a NaviGroup
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the background</param>
        public override void DrawNaviGroupBg(Graphics g, Rectangle bounds)
        {
            using (Brush b = new SolidBrush(ColourTable.Background))
            {
                g.FillRectangle(b, bounds);
            }
        }

        /// <summary>
        /// Draws NaviGroup header 
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the background</param>
        /// <param name="state">The input state of the control</param>
        /// <param name="expanded">Wether the group is expanded or not</param>
        /// <param name="rightToLeft">Whether the group should be drawn from left to right</param>
        public override void DrawNaviGroupHeader(Graphics g, Rectangle bounds, InputState state, bool expanded,
           bool rightToLeft)
        {
            g.InterpolationMode = InterpolationMode.Bicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle triBounds = new Rectangle(bounds.Location, new Size(bounds.Height, bounds.Height));

            if (expanded)
            {
                Point[] points = new Point[] {
                  new Point(triBounds.Width/2-3,triBounds.Height/2+1),
                  new Point(triBounds.Width/2+2,triBounds.Height/2+1),
                  new Point(triBounds.Width/2+2,triBounds.Height/2-4) };

                using (Pen pen = new Pen(ColourTable.GroupExpandedColor1))
                using (SolidBrush b = new SolidBrush(ColourTable.GroupExpandedColor2))
                {
                    g.FillPolygon(b, points);
                    g.DrawPolygon(pen, points);
                }
            }
            else
            {
                Point[] points = new Point[] {
                  new Point(triBounds.Width/2-2, triBounds.Height/2+3),
                  new Point(triBounds.Width/2+2, triBounds.Height/2),
                  new Point(triBounds.Width/2-2, triBounds.Height/2-4) };

                using (Pen pen = new Pen(ColourTable.Border))
                using (SolidBrush b = new SolidBrush(Color.White))
                {
                    g.FillPolygon(b, points);
                    g.DrawPolygon(pen, points);
                }
            }

            using (Pen pen = new Pen(ColourTable.Border))
            {
                g.InterpolationMode = InterpolationMode.Bicubic;
                g.SmoothingMode = SmoothingMode.None;

                // Line bottom
                pen.Color = ColourTable.Border;
                pen.DashStyle = DashStyle.Dash;
                g.DrawLine(pen, new Point(0, 0), new Point(bounds.Width, 0));
            }
        }

        /// <summary>
        /// Calculates the text bounds for the text in the header. 
        /// </summary>
        /// <param name="bounds">The bounds</param>
        /// <returns>The new text bounds</returns>
        public override Rectangle CalcGroupTextbounds(Rectangle bounds)
        {
            bounds.Location = new Point(bounds.X + 12, bounds.Y);
            bounds.Width -= 12;

            return bounds;
        }

        #endregion

        #region NaviSplitter

        /// <summary>
        /// Draws the background of the gradient splitter class to a graphics surface
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the drawing relative to the graphics surface</param>
        public override void DrawSplitterBg(Graphics g, Rectangle bounds)
        {
            bool vertical = bounds.Width > bounds.Height;

            // Background
            Color[] EndColors = { ColourTable.SplitterColor2, ColourTable.SplitterColor1 };
            float[] ColorPositions = { 0.0f, 1.0f };

            ColorBlend blend = new ColorBlend();

            blend.Colors = EndColors;
            blend.Positions = ColorPositions;

            if (bounds.Height == 0)
                bounds.Height = 1;
            if (bounds.Width == 0)
                bounds.Width = 1; // its to prevent an out of memory exception

            Point beginPoint;
            Point endPoint;
            if (vertical)
            {
                beginPoint = new Point(0, bounds.Top);
                endPoint = new Point(0, bounds.Bottom);
            }
            else
            {
                beginPoint = new Point(bounds.Left, 0);
                endPoint = new Point(bounds.Right, 0);
            }

            bounds.Width -= 1;
            bounds.Height -= 2;

            // Make the linear brush and assign the custom blend to it
            using (LinearGradientBrush brush = new LinearGradientBrush(beginPoint,
                                                              endPoint,
                                                              Color.White,
                                                              Color.Black))
            {
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, bounds);
            }

            using (Pen p = new Pen(ColourTable.Border))
            {
                g.DrawRectangle(p, bounds);
            }
        }

        #endregion

        #region NaviButtonCollapse

        /// <summary>
        /// Draws the surface of the Collapse button
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        /// <param name="inputState">The input state of the control</param>
        /// <param name="rightToLeft">Right to left or left to right</param>
        /// <param name="collapsed">The bar is collasped or not</param>
        public override void DrawButtonCollapseBg(Graphics g, Rectangle bounds, InputState inputState, bool rightToLeft,
           bool collapsed)
        {
            Color[] endColors = new Color[1];

            using (Brush b = new SolidBrush(ColourTable.HeaderColor1))
            {
                g.FillRectangle(b, bounds);
            }

            Rectangle buttonBounds = bounds;

            buttonBounds.Width -= 1;
            buttonBounds.Height -= 1;

            if (inputState == InputState.Hovered)
            {
                buttonBounds.Inflate(new Size(-1, -1));
                using (Pen p = new Pen(ColourTable.Border))
                {
                    g.DrawRectangle(p, buttonBounds);
                }

                buttonBounds.Inflate(new Size(-1, -1));

                // Background gradient 
                endColors = new Color[] { ColourTable.ButtonHoveredColor1, ColourTable.ButtonHoveredColor2,
               ColourTable.ButtonHoveredColor3 };

                float[] ColorPositions = { 0.0f, 0.4f, 1.0f };
                ExtDrawing.DrawVertGradient(g, buttonBounds, endColors, ColorPositions);

                // Draws a nice shiney glow on the bottom of the button
                endColors = new Color[] { Color.FromArgb(1, ColourTable.ButtonActiveColor4) };
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, buttonBounds.Height / 2, buttonBounds.Width, buttonBounds.Height);
                ExtDrawing.DrawRadialGradient(g, path, buttonBounds, Color.FromArgb(150,
                   ColourTable.ButtonActiveColor4), endColors);

                // Inner borders
                using (Pen p = new Pen(ColourTable.BorderInner))
                {
                    g.DrawRectangle(p, buttonBounds);
                }
            }

            using (Pen pen = new Pen(ColourTable.Border, 2.0f))
            {
                // Arrows
                //pen.Width = 2;
                pen.EndCap = LineCap.Triangle;
                pen.StartCap = LineCap.Triangle;
                pen.Color = ColourTable.ShapesFront;

                //width-7
                //(height/2)+1
                // w=7 h=4
                float x = 0;
                float y = 0;

                if (bounds.Height != 0)
                    y = (bounds.Height / 2) - 3;

                if (bounds.Width != 0)
                    x = (bounds.Width / 2) - 1;

                if (((rightToLeft) && (!collapsed)) || (!rightToLeft) && (collapsed))
                {
                    PointF[] points = {new PointF(x -2, y),
                               new PointF(x+1,y + 3),
                               new PointF(x-2, y + 3 + 3) };

                    g.DrawLines(pen, points);
                }
                else
                {
                    PointF[] points = {new PointF(x + 1, y),
                               new PointF(x - 2,y + 3),
                               new PointF(x + 1, y + 3 + 3) };
                    g.DrawLines(pen, points);
                }
            }
        }

        #endregion
    }
}
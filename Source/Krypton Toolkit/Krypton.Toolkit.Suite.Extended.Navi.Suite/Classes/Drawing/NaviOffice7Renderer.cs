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
    /// <summary>
    /// Contains the drawing logic for the Office view of the Navigation bar
    /// </summary>
    public class NaviOffice7Renderer : NaviRenderer
    {
        #region Initialization Methods

        /// <summary>
        /// Initializes the drawing functionality
        /// </summary>
        public override void Initialize(NaviLayoutStyle layoutStyle)
        {
            switch (layoutStyle)
            {
                case NaviLayoutStyle.Office2007Blue:
                    ColourTable = new NaviColourTableOff7Blue();
                    break;
                case NaviLayoutStyle.Office2007Silver:
                    ColourTable = new NaviColourTableOff7Silver();
                    break;
                case NaviLayoutStyle.Office2007Black:
                    ColourTable = new NaviColourTableOff7Black();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region NaviBand
        #endregion

        #region NaviBandClientArea
        #endregion

        #region NaviBandCollapsed

        /// <summary>
        /// Draws the background of the collapsed band
        /// </summary>
        /// <param name="g">The canvas to draw on</param>
        /// <param name="bounds">The bounds of the drawing</param>
        /// <param name="text">The text that should appear into the bar</param>
        /// <param name="font">The font to use when drawing the text</param>
        /// <param name="rightToLeft"></param>
        /// <param name="state">The inputstate of the collapsed band</param>
        public override void DrawNaviBandCollapsedBg(Graphics g, Rectangle bounds, string text, Font font,
           bool rightToLeft, InputState state)
        {
            using (SolidBrush b = new SolidBrush(ColourTable.BandCollapsedBgColor1))
            {
                if (state == InputState.Hovered)
                    b.Color = ColourTable.BandCollapsedHoveredColor1;
                else if (state == InputState.Clicked)
                    b.Color = ColourTable.BandCollapsedClickedColor1;

                g.FillRectangle(b, bounds);
            }

            // inner border
            using (Pen p = new Pen(ColourTable.Border))
            {
                g.DrawLine(p, new Point(bounds.Left, bounds.Top), new Point(bounds.Right,
                   bounds.Top));
                p.Color = ColourTable.BorderInner;
                if (state == InputState.Normal)
                {
                    g.DrawLine(p, new Point(bounds.Left, bounds.Top + 1), new Point(bounds.Right,
                       bounds.Top + 1));
                    g.DrawLine(p, new Point(bounds.Left, bounds.Top + 1), new Point(bounds.Left,
                       bounds.Bottom));
                }
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
            // Gradient background
            Color[] endColors = new Color[] { ColourTable.PopupBandBackground1, ColourTable.PopupBandBackground2 };

            float[] ColorPositions = { 0.0f, 1.0f };
            ExtDrawing.DrawVertGradient(g, bounds, endColors, ColorPositions);

            //bounds.Width -= 1;
            //bounds.Height -= 1;

            //using (Pen p = new Pen(ColorTable.Border))
            //using (Brush b = new SolidBrush(ColorTable.PopupBandBackground1))
            //{
            //   g.FillRectangle(b, bounds);
            //   g.DrawRectangle(p, bounds);
            //}
        }

        #endregion

        #region NaviBar

        /// <summary>
        /// Draws the background of the rectangle containing the small buttons on the bottom 
        /// of the NavigationBar
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the small rectangle</param>
        public override void DrawNaviBarOverFlowPanelBg(Graphics g, Rectangle bounds)
        {
            // Background
            Color[] EndColors = { ColourTable.ButtonNormalColor1, ColourTable.ButtonNormalColor2,
                                ColourTable.ButtonNormalColor3, ColourTable.ButtonNormalColor4 };
            float[] ColorPositions = { 0.0f, 0.62f, 0.62f, 1.0f };

            ColorBlend blend = new ColorBlend();

            blend.Colors = EndColors;
            blend.Positions = ColorPositions;

            if (bounds.Height == 0)
                bounds.Height = 1; // its to prevent an out of memory exception
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

            using (Pen p = new Pen(ColourTable.Border))
            {
                g.DrawLine(p, bounds.Left, bounds.Top, bounds.Right, bounds.Top);
            }
        }

        /// <summary>
        /// Draws the header region on top of the NavigationBar
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the header</param>
        public override void DrawNaviBarHeaderBg(Graphics g, Rectangle bounds)
        {
            Color[] endColors = new Color[] { ColourTable.HeaderColor1, ColourTable.HeaderColor2 };
            float[] ColorPositions = { 0.0f, 1.0f };

            ColorBlend blend = new ColorBlend();

            blend.Colors = endColors;
            blend.Positions = ColorPositions;

            if (bounds.Height == 0)
                bounds.Height = 1; // its to prevent an out of memory exception
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

            using (Pen p = new Pen(ColourTable.BorderInner))
            {
                g.DrawLine(p, new Point(bounds.Left, bounds.Top), new Point(bounds.Right - 1, bounds.Top));
                g.DrawLine(p, new Point(bounds.Left, bounds.Top), new Point(bounds.Left, bounds.Bottom));
            }
        }

        #endregion

        #region NaviButton

        /// <summary>
        /// Draws the background gradients of an Button
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        /// <param name="state"></param>
        /// <param name="inputState"></param>
        public override void DrawButtonBg(Graphics g, Rectangle bounds, ControlState state, InputState inputState)
        {
            Color[] endColors = new Color[1];

            if ((state == ControlState.Normal) && (inputState == InputState.Normal))
            {
                endColors = new Color[] { ColourTable.ButtonNormalColor1, ColourTable.ButtonNormalColor2,
                                ColourTable.ButtonNormalColor3, ColourTable.ButtonNormalColor4 };
            }
            else if ((state == ControlState.Normal) && (inputState == InputState.Hovered))
            {
                endColors = new Color[] { ColourTable.ButtonHoveredColor1, ColourTable.ButtonHoveredColor2,
                                ColourTable.ButtonHoveredColor3, ColourTable.ButtonHoveredColor4 };
            }
            else if ((state == ControlState.Active) && (inputState == InputState.Normal))
            {
                endColors = new Color[] { ColourTable.ButtonActiveColor1, ColourTable.ButtonActiveColor2,
                                ColourTable.ButtonActiveColor3, ColourTable.ButtonActiveColor4 };
            }
            else if ((inputState == InputState.Clicked)
               || ((state == ControlState.Active) && (inputState == InputState.Hovered)))
            {
                endColors = new Color[] { ColourTable.ButtonClickedColor1, ColourTable.ButtonClickedColor2,
                                ColourTable.ButtonClickedColor3, ColourTable.ButtonClickedColor4 };
            }

            float[] ColorPositions = { 0.0f, 0.62f, 0.62f, 1.0f };

            ExtDrawing.DrawVertGradient(g, bounds, endColors, ColorPositions);

            using (Pen p = new Pen(ColourTable.Border))
            {
                g.DrawLine(p, bounds.Left, bounds.Top, bounds.Right, bounds.Top);
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
            Color[] smallColors = new Color[1];

            if (inputState == InputState.Clicked)
            {
                smallColors = new Color[] { ColourTable.CollapseButtonClickedColor1,
               ColourTable.CollapseButtonClickedColor2 };
            }
            else if (inputState == InputState.Hovered)
            {
                smallColors = new Color[] { ColourTable.CollapseButtonHoveredColor2,
               ColourTable.CollapseButtonHoveredColor1 };
            }

            endColors = new Color[] { ColourTable.CollapseButtonNormalColor1, ColourTable.CollapseButtonNormalColor2 };

            float[] ColorPositions = { 0.0f, 1.0f };

            ColorBlend blend = new ColorBlend();

            blend.Colors = endColors;
            blend.Positions = ColorPositions;

            if (bounds.Height == 0) // To prevent an out of memory exception
                bounds.Height = 1;
            if (bounds.Width == 0)
                bounds.Width = 1;

            // TODO use ExtDrawing

            // Make the linear brush and assign the custom blend to it
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(bounds.Left, bounds.Top),
                                                              new Point(bounds.Left, bounds.Bottom),
                                                              Color.White,
                                                              Color.Black))
            {
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, bounds);
            }

            if ((inputState == InputState.Clicked) || (inputState == InputState.Hovered))
            {
                Rectangle smallBounds = bounds;
                smallBounds.Location = new Point(smallBounds.Left + 4, smallBounds.Top + 3);
                smallBounds.Size = new Size(smallBounds.Width - 8, smallBounds.Height - 6);

                using (LinearGradientBrush brush = new LinearGradientBrush(new Point(smallBounds.Left, smallBounds.Top),
                                                               new Point(smallBounds.Left, smallBounds.Bottom),
                                                               Color.White,
                                                               Color.Black))
                {
                    blend.Colors = smallColors;
                    brush.InterpolationColors = blend;
                    g.FillRectangle(brush, smallBounds);
                }
            }

            using (Pen pen = new Pen(ColourTable.Border))
            {
                // Arrows
                pen.Color = ColourTable.ShapesFront;

                pen.Width = 1.5f;
                float x = 0;
                float y = 0;

                if (bounds.Height != 0)
                    y = (bounds.Height / 2) - 3;

                if (bounds.Width != 0)
                    x = (bounds.Width / 2) - 1;

                if (((rightToLeft) && (!collapsed)) || (!rightToLeft) && (collapsed))
                {
                    PointF[] points = {new(x -3, y),
                               new(x,y + 3),
                               new(x-3, y + 3 + 3) };
                    g.DrawLines(pen, points);

                    PointF[] points2 = {new(x + 1, y),
                               new(x + 4,y + 3),
                               new(x + 1, y + 3 + 3) };
                    g.DrawLines(pen, points2);
                }
                else
                {
                    PointF[] points = {new(x, y),
                               new(x - 3,y + 3),
                               new(x, y + 3 + 3) };
                    g.DrawLines(pen, points);

                    PointF[] points2 = {new(x + 4, y),
                               new(x + 1,y + 3),
                               new(x + 4, y + 3 + 3) };
                    g.DrawLines(pen, points2);
                }
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
            new(bounds.Width /2 +3,bounds.Height /2 -1),
            new(bounds.Width /2, bounds.Height /2 +2),
            new(bounds.Width /2 -2,bounds.Height /2 -1) };

            Point[] pointsRec2 = new Point[] {
            new(bounds.Width /2 +3,bounds.Height /2),
            new(bounds.Width /2, bounds.Height /2 +3),
            new(bounds.Width /2 -2,bounds.Height /2) };

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
        public override void DrawNaviGroupHeader(Graphics g, Rectangle bounds, InputState state, bool expanded, bool rightToLeft)
        {
            Color dark, light;
            bounds.Height--;

            if (state == InputState.Hovered)
            {
                dark = ColourTable.GroupHoveredColor1;
                light = ColourTable.GroupHoveredColor2;
            }
            else
            {
                dark = ColourTable.GroupColor1;
                light = ColourTable.GroupColor2;
            }

            // Background
            Color[] EndColors = { dark, light, dark };
            float[] ColorPositions = { 0.0f, .50f, 1.0f };

            ColorBlend blend = new ColorBlend();

            blend.Colors = EndColors;
            blend.Positions = ColorPositions;

            if (bounds.Width == 0)
                bounds.Width = 1; // its to prevent an out of memory exception

            //Make the linear brush and assign the custom blend to it
            using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0),
                                                              new Point(bounds.Width, 0),
                                                              Color.White,
                                                              Color.Black))
            {
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, bounds);
            }

            using (Pen pen = new Pen(ColourTable.Border))
            {
                // Dark border
                //g.DrawRectangle(pen, bounds);
                g.DrawLine(pen, new Point(0, 0), new Point(bounds.Width, 0));

                // Light line bottom
                pen.Color = ColourTable.GroupBorderLight;
                g.DrawLine(pen, new Point(0, bounds.Height),
                   new Point(bounds.Width, bounds.Height));

                // Light inner border
                pen.Color = ColourTable.BorderInner;
                g.DrawLine(pen, new Point(0, 1), new Point(bounds.Width, 1));
                g.DrawLine(pen, new Point(0, 1), new Point(0, bounds.Height - 1));

                // Arrows
                pen.Color = ColourTable.ShapesFront;

                pen.Width = 1.5f;
                float x = 0;
                float y = 0;

                if (bounds.Height != 0)
                    y = (bounds.Height / 2) - 3; // + 1px border and - 4 size

                if (rightToLeft)
                    x = 7;
                else
                    x = bounds.Width - 7 - 7; // 7 px spacing and - 7 width            

                if (expanded)
                {
                    PointF[] points = { new(x, y + 3 + 4),
                               new(x + 3,y + 4),
                               new(x + 3 + 3, y + 3 + 4) };
                    g.DrawLines(pen, points);

                    PointF[] points2 = { new(x, y + 3),
                               new(x + 3,y ),
                               new(x + 3 + 3, y + 3) };
                    g.DrawLines(pen, points2);
                }
                else
                {
                    PointF[] points = { new(x, y + 4),
                               new(x + 3,y + 3 + 4),
                               new(x + 3 + 3, y + 4) };
                    g.DrawLines(pen, points);

                    PointF[] points2 = { new(x, y ),
                               new(x + 3,y + 3 ),
                               new(x + 3 + 3, y) };
                    g.DrawLines(pen, points2);
                }
            }

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

            // Make the linear brush and assign the custom blend to it
            using (LinearGradientBrush brush = new LinearGradientBrush(beginPoint,
                                                              endPoint,
                                                              Color.White,
                                                              Color.Black))
            {
                brush.InterpolationColors = blend;
                g.FillRectangle(brush, bounds);
            }

            int centerX = bounds.Right - (bounds.Width / 2);
            int centerY = bounds.Bottom - (bounds.Height / 2);

            using (SolidBrush b = new SolidBrush(ColourTable.Border))
            {
                if (vertical)
                {
                    g.FillRectangle(b, centerX - 8, centerY - 1, 2, 2);
                    g.FillRectangle(b, centerX - 4, centerY - 1, 2, 2);
                    g.FillRectangle(b, centerX, centerY - 1, 2, 2);
                    g.FillRectangle(b, centerX + 4, centerY - 1, 2, 2);
                    g.FillRectangle(b, centerX + 8, centerY - 1, 2, 2);

                    b.Color = ColourTable.SplitterColor3;

                    g.FillRectangle(b, centerX - 7, centerY, 2, 2);
                    g.FillRectangle(b, centerX - 3, centerY, 2, 2);
                    g.FillRectangle(b, centerX + 1, centerY, 2, 2);
                    g.FillRectangle(b, centerX + 5, centerY, 2, 2);
                    g.FillRectangle(b, centerX + 9, centerY, 2, 2);
                }
                else
                {
                    g.FillRectangle(b, centerX - 1, centerY - 8, 2, 2);
                    g.FillRectangle(b, centerX - 1, centerY - 4, 2, 2);
                    g.FillRectangle(b, centerX - 1, centerY, 2, 2);
                    g.FillRectangle(b, centerX - 1, centerY + 4, 2, 2);
                    g.FillRectangle(b, centerX - 1, centerY + 8, 2, 2);

                    b.Color = ColourTable.SplitterColor3;

                    g.FillRectangle(b, centerX, centerY - 7, 2, 2);
                    g.FillRectangle(b, centerX, centerY - 3, 2, 2);
                    g.FillRectangle(b, centerX, centerY + 1, 2, 2);
                    g.FillRectangle(b, centerX, centerY + 5, 2, 2);
                    g.FillRectangle(b, centerX, centerY + 9, 2, 2);
                }

                b.Color = ColourTable.Border;
                using (Pen p = new Pen(b, 1))
                {
                    g.DrawLine(p, new Point(bounds.Left, bounds.Top),
                       new Point(bounds.Right, bounds.Top));
                }
            }
        }

        #endregion
    }
}
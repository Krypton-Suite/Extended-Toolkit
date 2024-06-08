﻿#region MIT License
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

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    public class ToggleSwitchPlainAndSimpleRenderer : ToggleSwitchRendererBase, IPlainAndSimpleValues
    {
        #region Constructor

        public ToggleSwitchPlainAndSimpleRenderer()
        {
            BorderColourChecked = Color.Black;
            BorderColourUnchecked = Color.Black;
            BorderWidth = 2;
            ButtonMargin = 1;
            InnerBackgroundColour = Color.White;
            ButtonColour = Color.Black;
        }

        #endregion Constructor

        #region Public Properties

        public Color BorderColourChecked { get; set; }
        public Color BorderColourUnchecked { get; set; }
        public int BorderWidth { get; set; }
        public int ButtonMargin { get; set; }
        public Color InnerBackgroundColour { get; set; }
        public Color ButtonColour { get; set; }

        #endregion Public Properties

        #region Render Method Implementations

        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
            //Draw this one AFTER the button is drawn in the RenderButton method
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int buttonWidth = GetButtonWidth();

            Rectangle controlRectangle = new Rectangle(0, 0, ToggleSwitch.Width, ToggleSwitch.Height);
            GraphicsPath innerBorderClipPath = GetInnerBorderClipPath(controlRectangle);

            g.SetClip(innerBorderClipPath);
            g.IntersectClip(leftRectangle);

            using (Brush innerBackgroundBrush = new SolidBrush(InnerBackgroundColour))
            {
                g.FillPath(innerBackgroundBrush, innerBorderClipPath);
            }

            g.ResetClip();
        }

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int buttonWidth = GetButtonWidth();

            Rectangle controlRectangle = new Rectangle(0, 0, ToggleSwitch.Width, ToggleSwitch.Height);
            GraphicsPath innerBorderClipPath = GetInnerBorderClipPath(controlRectangle);

            g.SetClip(innerBorderClipPath);
            g.IntersectClip(rightRectangle);

            using (Brush innerBackgroundBrush = new SolidBrush(InnerBackgroundColour))
            {
                g.FillPath(innerBackgroundBrush, innerBorderClipPath);
            }

            g.ResetClip();
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            GraphicsPath buttonClipPath = GetButtonClipPath();

            Rectangle controlRectangle = new Rectangle(0, 0, ToggleSwitch.Width, ToggleSwitch.Height);
            GraphicsPath outerBorderClipPath = GetControlClipPath(controlRectangle);
            GraphicsPath innerBorderClipPath = GetInnerBorderClipPath(controlRectangle);

            g.SetClip(innerBorderClipPath);
            g.IntersectClip(buttonRectangle);

            //Fill the button surface with the background color

            using (Brush innerBackgroundBrush = new SolidBrush(InnerBackgroundColour))
            {
                g.FillRectangle(innerBackgroundBrush, buttonRectangle);
            }

            g.ResetClip();

            g.SetClip(GetButtonClipPath());
            g.IntersectClip(controlRectangle);

            //Render the button

            using (Brush buttonBrush = new SolidBrush(ButtonColour))
            {
                g.FillPath(buttonBrush, buttonClipPath);
            }

            g.ResetClip();

            //Render the border

            g.SetClip(outerBorderClipPath);
            g.ExcludeClip(new Region(innerBorderClipPath));

            Color borderColour = ToggleSwitch.Checked ? BorderColourChecked : BorderColourUnchecked;

            using (Brush borderBrush = new SolidBrush(borderColour))
            {
                g.FillPath(borderBrush, outerBorderClipPath);
            }

            g.ResetClip();
        }

        #endregion Render Method Implementations

        #region Helper Method Implementations

        public GraphicsPath GetControlClipPath(Rectangle controlRectangle)
        {
            GraphicsPath borderPath = new GraphicsPath();
            borderPath.AddArc(controlRectangle.X, controlRectangle.Y, controlRectangle.Height, controlRectangle.Height, 90, 180);
            borderPath.AddArc(controlRectangle.X + controlRectangle.Width - controlRectangle.Height, controlRectangle.Y, controlRectangle.Height, controlRectangle.Height, 270, 180);
            borderPath.CloseFigure();

            return borderPath;
        }

        public GraphicsPath GetInnerBorderClipPath(Rectangle controlRectangle)
        {
            Rectangle innerBorderRectangle = new Rectangle(controlRectangle.X + BorderWidth,
                                                           controlRectangle.Y + BorderWidth,
                                                           controlRectangle.Width - 2 * BorderWidth,
                                                           controlRectangle.Height - 2 * BorderWidth);

            GraphicsPath borderPath = new GraphicsPath();
            borderPath.AddArc(innerBorderRectangle.X, innerBorderRectangle.Y, innerBorderRectangle.Height, innerBorderRectangle.Height, 90, 180);
            borderPath.AddArc(innerBorderRectangle.X + innerBorderRectangle.Width - innerBorderRectangle.Height, innerBorderRectangle.Y, innerBorderRectangle.Height, innerBorderRectangle.Height, 270, 180);
            borderPath.CloseFigure();

            return borderPath;
        }

        public GraphicsPath GetButtonClipPath()
        {
            Rectangle buttonRectangle = GetButtonRectangle();

            GraphicsPath buttonPath = new GraphicsPath();

            buttonPath.AddArc(buttonRectangle.X + ButtonMargin, buttonRectangle.Y + ButtonMargin, buttonRectangle.Height - 2 * ButtonMargin, buttonRectangle.Height - 2 * ButtonMargin, 0, 360);

            return buttonPath;
        }

        public override int GetButtonWidth()
        {
            int buttonWidth = ToggleSwitch.Height - 2 * BorderWidth;
            return buttonWidth > 0 ? buttonWidth : 0;
        }

        public override Rectangle GetButtonRectangle()
        {
            int buttonWidth = GetButtonWidth();
            return GetButtonRectangle(buttonWidth);
        }

        public override Rectangle GetButtonRectangle(int buttonWidth)
        {
            if (buttonWidth <= 0)
            {
                return Rectangle.Empty;
            }

            Rectangle buttonRect = new Rectangle(ToggleSwitch.ButtonValue, BorderWidth, buttonWidth, buttonWidth);

            if (buttonRect.X < BorderWidth + ButtonMargin - 1)
            {
                buttonRect.X = BorderWidth + ButtonMargin - 1;
            }

            if (buttonRect.X + buttonRect.Width > ToggleSwitch.Width - BorderWidth - ButtonMargin + 1)
            {
                buttonRect.X = ToggleSwitch.Width - buttonRect.Width - BorderWidth - ButtonMargin + 1;
            }

            return buttonRect;
        }

        #endregion Helper Method Implementations
    }
}
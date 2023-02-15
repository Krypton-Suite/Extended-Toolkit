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

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    public class ToggleSwitchOSXRenderer : ToggleSwitchRendererBase, IDisposable, IGlobalValues, IOSXValues
    {
        #region Constructor

        private GraphicsPath _innerControlPath = null;

        public ToggleSwitchOSXRenderer()
        {
            OuterBorderColour = Color.FromArgb(255, 108, 108, 108);
            InnerBorderColour1 = Color.FromArgb(255, 137, 138, 139);
            InnerBorderColour2 = Color.FromArgb(255, 167, 168, 169);
            BackColour1 = Color.FromArgb(255, 108, 108, 108);
            BackColour2 = Color.FromArgb(255, 163, 163, 163);
            ButtonNormalBorderColour1 = Color.FromArgb(255, 147, 147, 148);
            ButtonNormalBorderColour2 = Color.FromArgb(255, 167, 168, 169);
            ButtonNormalSurfaceColour1 = Color.FromArgb(255, 250, 250, 250);
            ButtonNormalSurfaceColour2 = Color.FromArgb(255, 224, 224, 224);
            ButtonHoverBorderColour1 = Color.FromArgb(255, 145, 146, 147);
            ButtonHoverBorderColour2 = Color.FromArgb(255, 164, 165, 166);
            ButtonHoverSurfaceColour1 = Color.FromArgb(255, 238, 238, 238);
            ButtonHoverSurfaceColour2 = Color.FromArgb(255, 213, 213, 213);
            ButtonPressedBorderColour1 = Color.FromArgb(255, 138, 138, 140);
            ButtonPressedBorderColour2 = Color.FromArgb(255, 158, 158, 160);
            ButtonPressedSurfaceColour1 = Color.FromArgb(255, 187, 187, 187);
            ButtonPressedSurfaceColour2 = Color.FromArgb(255, 168, 168, 168);
            ButtonShadowColour1 = Color.FromArgb(50, 0, 0, 0);
            ButtonShadowColour2 = Color.FromArgb(0, 0, 0, 0);

            ButtonShadowWidth = 7;
            CornerRadius = 4;
        }

        public void Dispose()
        {
            if (_innerControlPath != null)
                _innerControlPath.Dispose();
        }

        #endregion Constructor

        #region Public Properties

        public Color OuterBorderColour { get; set; }
        public Color InnerBorderColour1 { get; set; }
        public Color InnerBorderColour2 { get; set; }
        public Color BackColour1 { get; set; }
        public Color BackColour2 { get; set; }
        public Color ButtonNormalBorderColour1 { get; set; }
        public Color ButtonNormalBorderColour2 { get; set; }
        public Color ButtonNormalSurfaceColour1 { get; set; }
        public Color ButtonNormalSurfaceColour2 { get; set; }
        public Color ButtonHoverBorderColour1 { get; set; }
        public Color ButtonHoverBorderColour2 { get; set; }
        public Color ButtonHoverSurfaceColour1 { get; set; }
        public Color ButtonHoverSurfaceColour2 { get; set; }
        public Color ButtonPressedBorderColour1 { get; set; }
        public Color ButtonPressedBorderColour2 { get; set; }
        public Color ButtonPressedSurfaceColour1 { get; set; }
        public Color ButtonPressedSurfaceColour2 { get; set; }
        public Color ButtonShadowColour1 { get; set; }
        public Color ButtonShadowColour2 { get; set; }

        public int ButtonShadowWidth { get; set; }
        public int CornerRadius { get; set; }

        #endregion Public Properties

        #region Render Method Implementations

        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            //Draw outer border
            using (GraphicsPath outerBorderPath = GetRoundedRectanglePath(borderRectangle, CornerRadius))
            {
                g.SetClip(outerBorderPath);

                Color outerBorderColour = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? OuterBorderColour.ToGrayScale() : OuterBorderColour;

                using (Brush outerBorderBrush = new SolidBrush(outerBorderColour))
                {
                    g.FillPath(outerBorderBrush, outerBorderPath);
                }

                g.ResetClip();
            }

            //Draw inner border
            Rectangle innerborderRectangle = new Rectangle(borderRectangle.X + 1, borderRectangle.Y + 1, borderRectangle.Width - 2, borderRectangle.Height - 2);

            using (GraphicsPath innerBorderPath = GetRoundedRectanglePath(innerborderRectangle, CornerRadius))
            {
                g.SetClip(innerBorderPath);

                Color borderColour1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? InnerBorderColour1.ToGrayScale() : InnerBorderColour1;
                Color borderColour2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? InnerBorderColour2.ToGrayScale() : InnerBorderColour2;

                using (Brush borderBrush = new LinearGradientBrush(borderRectangle, borderColour1, borderColour2, LinearGradientMode.Vertical))
                {
                    g.FillPath(borderBrush, innerBorderPath);
                }

                g.ResetClip();
            }

            //Draw inner background
            Rectangle backgroundRectangle = new Rectangle(borderRectangle.X + 2, borderRectangle.Y + 2, borderRectangle.Width - 4, borderRectangle.Height - 4);

            _innerControlPath = GetRoundedRectanglePath(backgroundRectangle, CornerRadius);

            g.SetClip(_innerControlPath);

            Color backColour1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? BackColour1.ToGrayScale() : BackColour1;
            Color backColour2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? BackColour2.ToGrayScale() : BackColour2;

            using (Brush backgroundBrush = new LinearGradientBrush(borderRectangle, backColour1, backColour2, LinearGradientMode.Vertical))
            {
                g.FillPath(backgroundBrush, _innerControlPath);
            }

            g.ResetClip();
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            Rectangle leftShadowRectangle = new Rectangle();
            leftShadowRectangle.X = leftRectangle.X + leftRectangle.Width - ButtonShadowWidth;
            leftShadowRectangle.Y = leftRectangle.Y;
            leftShadowRectangle.Width = ButtonShadowWidth + CornerRadius;
            leftShadowRectangle.Height = leftRectangle.Height;

            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(leftShadowRectangle);
            }
            else
            {
                g.SetClip(leftShadowRectangle);
            }

            using (Brush buttonShadowBrush = new LinearGradientBrush(leftShadowRectangle, ButtonShadowColour2, ButtonShadowColour1, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(buttonShadowBrush, leftShadowRectangle);
            }

            g.ResetClip();

            //Draw image or text
            if (ToggleSwitch.OnSideImage != null || !string.IsNullOrEmpty(ToggleSwitch.OnText))
            {
                RectangleF fullRectangle = new RectangleF(leftRectangle.X + 1 - (totalToggleFieldWidth - leftRectangle.Width), 1, totalToggleFieldWidth - 1, ToggleSwitch.Height - 2);

                if (_innerControlPath != null)
                {
                    g.SetClip(_innerControlPath);
                    g.IntersectClip(fullRectangle);
                }
                else
                {
                    g.SetClip(fullRectangle);
                }

                if (ToggleSwitch.OnSideImage != null)
                {
                    Size imageSize = ToggleSwitch.OnSideImage.Size;
                    Rectangle imageRectangle;

                    int imageXPos = (int)fullRectangle.X;

                    if (ToggleSwitch.OnSideScaleImageToFit)
                    {
                        Size canvasSize = new Size((int)fullRectangle.Width, (int)fullRectangle.Height);
                        Size resizedImageSize = ImageHelper.RescaleImageToFit(imageSize, canvasSize);

                        if (ToggleSwitch.OnSideAlignment == ToggleSwitchAlignment.Center)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (((float)fullRectangle.Width - (float)resizedImageSize.Width) / 2));
                        }
                        else if (ToggleSwitch.OnSideAlignment == ToggleSwitchAlignment.Near)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (float)fullRectangle.Width - (float)resizedImageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)fullRectangle.Y + (((float)fullRectangle.Height - (float)resizedImageSize.Height) / 2)), resizedImageSize.Width, resizedImageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(ToggleSwitch.OnSideImage, imageRectangle, 0, 0, ToggleSwitch.OnSideImage.Width, ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImage(ToggleSwitch.OnSideImage, imageRectangle);
                    }
                    else
                    {
                        if (ToggleSwitch.OnSideAlignment == ToggleSwitchAlignment.Center)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (((float)fullRectangle.Width - (float)imageSize.Width) / 2));
                        }
                        else if (ToggleSwitch.OnSideAlignment == ToggleSwitchAlignment.Near)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (float)fullRectangle.Width - (float)imageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)fullRectangle.Y + (((float)fullRectangle.Height - (float)imageSize.Height) / 2)), imageSize.Width, imageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(ToggleSwitch.OnSideImage, imageRectangle, 0, 0, ToggleSwitch.OnSideImage.Width, ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImageUnscaled(ToggleSwitch.OnSideImage, imageRectangle);
                    }
                }
                else if (!string.IsNullOrEmpty(ToggleSwitch.OnText))
                {
                    SizeF textSize = g.MeasureString(ToggleSwitch.OnText, ToggleSwitch.OnFont);

                    float textXPos = fullRectangle.X;

                    if (ToggleSwitch.OnSideAlignment == ToggleSwitchAlignment.Center)
                    {
                        textXPos = (float)fullRectangle.X + (((float)fullRectangle.Width - (float)textSize.Width) / 2);
                    }
                    else if (ToggleSwitch.OnSideAlignment == ToggleSwitchAlignment.Near)
                    {
                        textXPos = (float)fullRectangle.X + (float)fullRectangle.Width - (float)textSize.Width;
                    }

                    RectangleF textRectangle = new RectangleF(textXPos, (float)fullRectangle.Y + (((float)fullRectangle.Height - (float)textSize.Height) / 2), textSize.Width, textSize.Height);

                    Color textForeColour = ToggleSwitch.OnForeColour;

                    if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                        textForeColour = textForeColour.ToGrayScale();

                    using (Brush textBrush = new SolidBrush(textForeColour))
                    {
                        g.DrawString(ToggleSwitch.OnText, ToggleSwitch.OnFont, textBrush, textRectangle);
                    }
                }

                g.ResetClip();
            }
        }

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            Rectangle rightShadowRectangle = new Rectangle();
            rightShadowRectangle.X = rightRectangle.X - CornerRadius;
            rightShadowRectangle.Y = rightRectangle.Y;
            rightShadowRectangle.Width = ButtonShadowWidth + CornerRadius;
            rightShadowRectangle.Height = rightRectangle.Height;

            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(rightShadowRectangle);
            }
            else
            {
                g.SetClip(rightShadowRectangle);
            }

            using (Brush buttonShadowBrush = new LinearGradientBrush(rightShadowRectangle, ButtonShadowColour1, ButtonShadowColour2, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(buttonShadowBrush, rightShadowRectangle);
            }

            g.ResetClip();

            //Draw image or text
            if (ToggleSwitch.OffSideImage != null || !string.IsNullOrEmpty(ToggleSwitch.OffText))
            {
                RectangleF fullRectangle = new RectangleF(rightRectangle.X, 1, totalToggleFieldWidth - 1, ToggleSwitch.Height - 2);

                if (_innerControlPath != null)
                {
                    g.SetClip(_innerControlPath);
                    g.IntersectClip(fullRectangle);
                }
                else
                {
                    g.SetClip(fullRectangle);
                }

                if (ToggleSwitch.OffSideImage != null)
                {
                    Size imageSize = ToggleSwitch.OffSideImage.Size;
                    Rectangle imageRectangle;

                    int imageXPos = (int)fullRectangle.X;

                    if (ToggleSwitch.OffSideScaleImageToFit)
                    {
                        Size canvasSize = new Size((int)fullRectangle.Width, (int)fullRectangle.Height);
                        Size resizedImageSize = ImageHelper.RescaleImageToFit(imageSize, canvasSize);

                        if (ToggleSwitch.OffSideAlignment == ToggleSwitchAlignment.Center)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (((float)fullRectangle.Width - (float)resizedImageSize.Width) / 2));
                        }
                        else if (ToggleSwitch.OffSideAlignment == ToggleSwitchAlignment.Far)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (float)fullRectangle.Width - (float)resizedImageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)fullRectangle.Y + (((float)fullRectangle.Height - (float)resizedImageSize.Height) / 2)), resizedImageSize.Width, resizedImageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(ToggleSwitch.OnSideImage, imageRectangle, 0, 0, ToggleSwitch.OnSideImage.Width, ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImage(ToggleSwitch.OnSideImage, imageRectangle);
                    }
                    else
                    {
                        if (ToggleSwitch.OffSideAlignment == ToggleSwitchAlignment.Center)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (((float)fullRectangle.Width - (float)imageSize.Width) / 2));
                        }
                        else if (ToggleSwitch.OffSideAlignment == ToggleSwitchAlignment.Far)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (float)fullRectangle.Width - (float)imageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)fullRectangle.Y + (((float)fullRectangle.Height - (float)imageSize.Height) / 2)), imageSize.Width, imageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(ToggleSwitch.OnSideImage, imageRectangle, 0, 0, ToggleSwitch.OnSideImage.Width, ToggleSwitch.OnSideImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImageUnscaled(ToggleSwitch.OffSideImage, imageRectangle);
                    }
                }
                else if (!string.IsNullOrEmpty(ToggleSwitch.OffText))
                {
                    SizeF textSize = g.MeasureString(ToggleSwitch.OffText, ToggleSwitch.OffFont);

                    float textXPos = fullRectangle.X;

                    if (ToggleSwitch.OffSideAlignment == ToggleSwitchAlignment.Center)
                    {
                        textXPos = (float)fullRectangle.X + (((float)fullRectangle.Width - (float)textSize.Width) / 2);
                    }
                    else if (ToggleSwitch.OffSideAlignment == ToggleSwitchAlignment.Far)
                    {
                        textXPos = (float)fullRectangle.X + (float)fullRectangle.Width - (float)textSize.Width;
                    }

                    RectangleF textRectangle = new RectangleF(textXPos, (float)fullRectangle.Y + (((float)fullRectangle.Height - (float)textSize.Height) / 2), textSize.Width, textSize.Height);

                    Color textForeColour = ToggleSwitch.OffForeColour;

                    if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                        textForeColour = textForeColour.ToGrayScale();

                    using (Brush textBrush = new SolidBrush(textForeColour))
                    {
                        g.DrawString(ToggleSwitch.OffText, ToggleSwitch.OffFont, textBrush, textRectangle);
                    }
                }

                g.ResetClip();
            }
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            buttonRectangle.Inflate(-1, -1);

            using (GraphicsPath buttonPath = GetRoundedRectanglePath(buttonRectangle, CornerRadius))
            {
                g.SetClip(buttonPath);

                //Draw button surface
                Color buttonSurfaceColour1 = ButtonNormalSurfaceColour1;
                Color buttonSurfaceColour2 = ButtonNormalSurfaceColour2;

                if (ToggleSwitch.IsButtonPressed)
                {
                    buttonSurfaceColour1 = ButtonPressedSurfaceColour1;
                    buttonSurfaceColour2 = ButtonPressedSurfaceColour2;
                }
                else if (ToggleSwitch.IsButtonHovered)
                {
                    buttonSurfaceColour1 = ButtonHoverSurfaceColour1;
                    buttonSurfaceColour2 = ButtonHoverSurfaceColour2;
                }

                if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                {
                    buttonSurfaceColour1 = buttonSurfaceColour1.ToGrayScale();
                    buttonSurfaceColour2 = buttonSurfaceColour2.ToGrayScale();
                }

                using (Brush buttonSurfaceBrush = new LinearGradientBrush(buttonRectangle, buttonSurfaceColour1, buttonSurfaceColour2, LinearGradientMode.Vertical))
                {
                    g.FillPath(buttonSurfaceBrush, buttonPath);
                }

                //Draw button border
                Color buttonBorderColour1 = ButtonNormalBorderColour1;
                Color buttonBorderColour2 = ButtonNormalBorderColour2;

                if (ToggleSwitch.IsButtonPressed)
                {
                    buttonBorderColour1 = ButtonPressedBorderColour1;
                    buttonBorderColour2 = ButtonPressedBorderColour2;
                }
                else if (ToggleSwitch.IsButtonHovered)
                {
                    buttonBorderColour1 = ButtonHoverBorderColour1;
                    buttonBorderColour2 = ButtonHoverBorderColour2;
                }

                if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                {
                    buttonBorderColour1 = buttonBorderColour1.ToGrayScale();
                    buttonBorderColour2 = buttonBorderColour2.ToGrayScale();
                }

                using (Brush buttonBorderBrush = new LinearGradientBrush(buttonRectangle, buttonBorderColour1, buttonBorderColour2, LinearGradientMode.Vertical))
                {
                    using (Pen buttonBorderPen = new Pen(buttonBorderBrush))
                    {
                        g.DrawPath(buttonBorderPen, buttonPath);
                    }
                }

                g.ResetClip();

                //Draw button image
                Image buttonImage = ToggleSwitch.ButtonImage ?? (ToggleSwitch.Checked ? ToggleSwitch.OnButtonImage : ToggleSwitch.OffButtonImage);

                if (buttonImage != null)
                {
                    g.SetClip(buttonPath);

                    ToggleSwitchButtonAlignment alignment = ToggleSwitch.ButtonImage != null ? ToggleSwitch.ButtonAlignment : (ToggleSwitch.Checked ? ToggleSwitch.OnButtonAlignment : ToggleSwitch.OffButtonAlignment);

                    Size imageSize = buttonImage.Size;

                    Rectangle imageRectangle;

                    int imageXPos = buttonRectangle.X;

                    bool scaleImage = ToggleSwitch.ButtonImage != null ? ToggleSwitch.ButtonScaleImageToFit : (ToggleSwitch.Checked ? ToggleSwitch.OnButtonScaleImageToFit : ToggleSwitch.OffButtonScaleImageToFit);

                    if (scaleImage)
                    {
                        Size canvasSize = buttonRectangle.Size;
                        Size resizedImageSize = ImageHelper.RescaleImageToFit(imageSize, canvasSize);

                        if (alignment == ToggleSwitchButtonAlignment.Center)
                        {
                            imageXPos = (int)((float)buttonRectangle.X + (((float)buttonRectangle.Width - (float)resizedImageSize.Width) / 2));
                        }
                        else if (alignment == ToggleSwitchButtonAlignment.Right)
                        {
                            imageXPos = (int)((float)buttonRectangle.X + (float)buttonRectangle.Width - (float)resizedImageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)buttonRectangle.Y + (((float)buttonRectangle.Height - (float)resizedImageSize.Height) / 2)), resizedImageSize.Width, resizedImageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(buttonImage, imageRectangle, 0, 0, buttonImage.Width, buttonImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImage(buttonImage, imageRectangle);
                    }
                    else
                    {
                        if (alignment == ToggleSwitchButtonAlignment.Center)
                        {
                            imageXPos = (int)((float)buttonRectangle.X + (((float)buttonRectangle.Width - (float)imageSize.Width) / 2));
                        }
                        else if (alignment == ToggleSwitchButtonAlignment.Right)
                        {
                            imageXPos = (int)((float)buttonRectangle.X + (float)buttonRectangle.Width - (float)imageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)buttonRectangle.Y + (((float)buttonRectangle.Height - (float)imageSize.Height) / 2)), imageSize.Width, imageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(buttonImage, imageRectangle, 0, 0, buttonImage.Width, buttonImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImageUnscaled(buttonImage, imageRectangle);
                    }

                    g.ResetClip();
                }
            }
        }

        #endregion Render Method Implementations

        #region Helper Method Implementations

        public GraphicsPath GetRoundedRectanglePath(Rectangle rectangle, int radius)
        {
            GraphicsPath gp = new GraphicsPath();
            int diameter = 2 * radius;

            if (diameter > ToggleSwitch.Height)
                diameter = ToggleSwitch.Height;

            if (diameter > ToggleSwitch.Width)
                diameter = ToggleSwitch.Width;

            gp.AddArc(rectangle.X, rectangle.Y, diameter, diameter, 180, 90);
            gp.AddArc(rectangle.X + rectangle.Width - diameter, rectangle.Y, diameter, diameter, 270, 90);
            gp.AddArc(rectangle.X + rectangle.Width - diameter, rectangle.Y + rectangle.Height - diameter, diameter, diameter, 0, 90);
            gp.AddArc(rectangle.X, rectangle.Y + rectangle.Height - diameter, diameter, diameter, 90, 90);
            gp.CloseFigure();

            return gp;
        }

        public override int GetButtonWidth()
        {
            float buttonWidth = 1.53f * (ToggleSwitch.Height - 2);
            return (int)buttonWidth;
        }

        public override Rectangle GetButtonRectangle()
        {
            int buttonWidth = GetButtonWidth();
            return GetButtonRectangle(buttonWidth);
        }

        public override Rectangle GetButtonRectangle(int buttonWidth)
        {
            Rectangle buttonRect = new Rectangle(ToggleSwitch.ButtonValue, 0, buttonWidth, ToggleSwitch.Height);
            return buttonRect;
        }

        #endregion Helper Method Implementations
    }
}
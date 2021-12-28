#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;
using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    public class ToggleSwitchFancyKryptonRenderer : ToggleSwitchRendererBase, IDisposable, IGlobalValues, IFancyValues
    {
        #region Constructor

        private GraphicsPath _innerControlPath = null;

        public ToggleSwitchFancyKryptonRenderer()
        {
            OuterBorderColour1 = Color.FromArgb(255, 197, 199, 201);
            OuterBorderColour2 = Color.FromArgb(255, 207, 209, 212);
            InnerBorderColour1 = Color.FromArgb(200, 205, 208, 207);
            InnerBorderColour2 = Color.FromArgb(255, 207, 209, 212);
            LeftSideBackColour1 = Color.FromArgb(255, 61, 110, 6);
            LeftSideBackColour2 = Color.FromArgb(255, 93, 170, 9);
            RightSideBackColour1 = Color.FromArgb(255, 149, 0, 0);
            RightSideBackColour2 = Color.FromArgb(255, 198, 0, 0);
            ButtonNormalBorderColour1 = Color.FromArgb(255, 212, 209, 211);
            ButtonNormalBorderColour2 = Color.FromArgb(255, 197, 199, 201);
            ButtonNormalUpperSurfaceColour1 = Color.FromArgb(255, 252, 251, 252);
            ButtonNormalUpperSurfaceColour2 = Color.FromArgb(255, 247, 247, 247);
            ButtonNormalLowerSurfaceColour1 = Color.FromArgb(255, 233, 233, 233);
            ButtonNormalLowerSurfaceColour2 = Color.FromArgb(255, 225, 225, 225);
            ButtonHoverBorderColour1 = Color.FromArgb(255, 212, 207, 209);
            ButtonHoverBorderColour2 = Color.FromArgb(255, 223, 223, 223);
            ButtonHoverUpperSurfaceColour1 = Color.FromArgb(255, 240, 239, 240);
            ButtonHoverUpperSurfaceColour2 = Color.FromArgb(255, 235, 235, 235);
            ButtonHoverLowerSurfaceColour1 = Color.FromArgb(255, 221, 221, 221);
            ButtonHoverLowerSurfaceColour2 = Color.FromArgb(255, 214, 214, 214);
            ButtonPressedBorderColour1 = Color.FromArgb(255, 176, 176, 176);
            ButtonPressedBorderColour2 = Color.FromArgb(255, 176, 176, 176);
            ButtonPressedUpperSurfaceColour1 = Color.FromArgb(255, 189, 188, 189);
            ButtonPressedUpperSurfaceColour2 = Color.FromArgb(255, 185, 185, 185);
            ButtonPressedLowerSurfaceColour1 = Color.FromArgb(255, 175, 175, 175);
            ButtonPressedLowerSurfaceColour2 = Color.FromArgb(255, 169, 169, 169);
            ButtonShadowColour1 = Color.FromArgb(50, 0, 0, 0);
            ButtonShadowColour2 = Color.FromArgb(0, 0, 0, 0);

            ButtonShadowWidth = 7;
            CornerRadius = 6;
        }

        public void Dispose()
        {
            if (_innerControlPath != null)
                _innerControlPath.Dispose();
        }

        #endregion Constructor

        #region Public Properties       
        public int ButtonShadowWidth { get; set; }
        public int CornerRadius { get; set; }
        public Color OuterBorderColour1 { get; set; }
        public Color OuterBorderColour2 { get; set; }
        public Color InnerBorderColour1 { get; set; }
        public Color InnerBorderColour2 { get; set; }
        public Color LeftSideBackColour1 { get; set; }
        public Color LeftSideBackColour2 { get; set; }
        public Color RightSideBackColour1 { get; set; }
        public Color RightSideBackColour2 { get; set; }
        public Color ButtonNormalBorderColour1 { get; set; }
        public Color ButtonNormalBorderColour2 { get; set; }
        public Color ButtonNormalUpperSurfaceColour1 { get; set; }
        public Color ButtonNormalUpperSurfaceColour2 { get; set; }
        public Color ButtonNormalLowerSurfaceColour1 { get; set; }
        public Color ButtonNormalLowerSurfaceColour2 { get; set; }
        public Color ButtonHoverBorderColour1 { get; set; }
        public Color ButtonHoverBorderColour2 { get; set; }
        public Color ButtonHoverUpperSurfaceColour1 { get; set; }
        public Color ButtonHoverUpperSurfaceColour2 { get; set; }
        public Color ButtonHoverLowerSurfaceColour1 { get; set; }
        public Color ButtonHoverLowerSurfaceColour2 { get; set; }
        public Color ButtonPressedBorderColour1 { get; set; }
        public Color ButtonPressedBorderColour2 { get; set; }
        public Color ButtonPressedUpperSurfaceColour1 { get; set; }
        public Color ButtonPressedUpperSurfaceColour2 { get; set; }
        public Color ButtonPressedLowerSurfaceColour1 { get; set; }
        public Color ButtonPressedLowerSurfaceColour2 { get; set; }
        public Color ButtonShadowColour1 { get; set; }
        public Color ButtonShadowColour2 { get; set; }
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

                Color outerBorderColour1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? OuterBorderColour1.ToGrayScale() : OuterBorderColour1;
                Color outerBorderColour2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? OuterBorderColour2.ToGrayScale() : OuterBorderColour2;

                using (Brush outerBorderBrush = new LinearGradientBrush(borderRectangle, outerBorderColour1, outerBorderColour2, LinearGradientMode.Vertical))
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

                Color innerBorderColour1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? InnerBorderColour1.ToGrayScale() : InnerBorderColour1;
                Color innerBorderColour2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? InnerBorderColour2.ToGrayScale() : InnerBorderColour2;

                using (Brush borderBrush = new LinearGradientBrush(borderRectangle, innerBorderColour1, innerBorderColour2, LinearGradientMode.Vertical))
                {
                    g.FillPath(borderBrush, innerBorderPath);
                }

                g.ResetClip();
            }

            Rectangle backgroundRectangle = new Rectangle(borderRectangle.X + 2, borderRectangle.Y + 2, borderRectangle.Width - 4, borderRectangle.Height - 4);
            _innerControlPath = GetRoundedRectanglePath(backgroundRectangle, CornerRadius);
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            int buttonWidth = GetButtonWidth();

            //Draw inner background
            int gradientRectWidth = leftRectangle.Width + buttonWidth / 2;
            Rectangle gradientRectangle = new Rectangle(leftRectangle.X, leftRectangle.Y, gradientRectWidth, leftRectangle.Height);

            Color leftSideBackColour1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? LeftSideBackColour1.ToGrayScale() : LeftSideBackColour1;
            Color leftSideBackColour2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? LeftSideBackColour2.ToGrayScale() : LeftSideBackColour2;

            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(gradientRectangle);
            }
            else
            {
                g.SetClip(gradientRectangle);
            }

            using (Brush backgroundBrush = new LinearGradientBrush(gradientRectangle, leftSideBackColour1, leftSideBackColour2, LinearGradientMode.Vertical))
            {
                g.FillRectangle(backgroundBrush, gradientRectangle);
            }

            g.ResetClip();

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

                        if (ToggleSwitch.OnSideAlignment == ToggleSwitchAlignment.CENTER)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (((float)fullRectangle.Width - (float)resizedImageSize.Width) / 2));
                        }
                        else if (ToggleSwitch.OnSideAlignment == ToggleSwitchAlignment.NEAR)
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
                        if (ToggleSwitch.OnSideAlignment == ToggleSwitchAlignment.CENTER)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (((float)fullRectangle.Width - (float)imageSize.Width) / 2));
                        }
                        else if (ToggleSwitch.OnSideAlignment == ToggleSwitchAlignment.NEAR)
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

                    if (ToggleSwitch.OnSideAlignment == ToggleSwitchAlignment.CENTER)
                    {
                        textXPos = (float)fullRectangle.X + (((float)fullRectangle.Width - (float)textSize.Width) / 2);
                    }
                    else if (ToggleSwitch.OnSideAlignment == ToggleSwitchAlignment.NEAR)
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

            int buttonWidth = GetButtonWidth();

            //Draw inner background
            int gradientRectWidth = rightRectangle.Width + buttonWidth / 2;
            Rectangle gradientRectangle = new Rectangle(rightRectangle.X - buttonWidth / 2, rightRectangle.Y, gradientRectWidth, rightRectangle.Height);

            Color rightSideBackColour1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? RightSideBackColour1.ToGrayScale() : RightSideBackColour1;
            Color rightSideBackColour2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? RightSideBackColour2.ToGrayScale() : RightSideBackColour2;

            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(gradientRectangle);
            }
            else
            {
                g.SetClip(gradientRectangle);
            }

            using (Brush backgroundBrush = new LinearGradientBrush(gradientRectangle, rightSideBackColour1, rightSideBackColour2, LinearGradientMode.Vertical))
            {
                g.FillRectangle(backgroundBrush, gradientRectangle);
            }

            g.ResetClip();

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

                        if (ToggleSwitch.OffSideAlignment == ToggleSwitchAlignment.CENTER)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (((float)fullRectangle.Width - (float)resizedImageSize.Width) / 2));
                        }
                        else if (ToggleSwitch.OffSideAlignment == ToggleSwitchAlignment.FAR)
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
                        if (ToggleSwitch.OffSideAlignment == ToggleSwitchAlignment.CENTER)
                        {
                            imageXPos = (int)((float)fullRectangle.X + (((float)fullRectangle.Width - (float)imageSize.Width) / 2));
                        }
                        else if (ToggleSwitch.OffSideAlignment == ToggleSwitchAlignment.FAR)
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

                    if (ToggleSwitch.OffSideAlignment == ToggleSwitchAlignment.CENTER)
                    {
                        textXPos = (float)fullRectangle.X + (((float)fullRectangle.Width - (float)textSize.Width) / 2);
                    }
                    else if (ToggleSwitch.OffSideAlignment == ToggleSwitchAlignment.FAR)
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

            //Draw button surface
            Color buttonUpperSurfaceColour1 = ButtonNormalUpperSurfaceColour1;
            Color buttonUpperSurfaceColour2 = ButtonNormalUpperSurfaceColour2;
            Color buttonLowerSurfaceColour1 = ButtonNormalLowerSurfaceColour1;
            Color buttonLowerSurfaceColour2 = ButtonNormalLowerSurfaceColour2;

            if (ToggleSwitch.IsButtonPressed)
            {
                buttonUpperSurfaceColour1 = ButtonPressedUpperSurfaceColour1;
                buttonUpperSurfaceColour2 = ButtonPressedUpperSurfaceColour2;
                buttonLowerSurfaceColour1 = ButtonPressedLowerSurfaceColour1;
                buttonLowerSurfaceColour2 = ButtonPressedLowerSurfaceColour2;
            }
            else if (ToggleSwitch.IsButtonHovered)
            {
                buttonUpperSurfaceColour1 = ButtonHoverUpperSurfaceColour1;
                buttonUpperSurfaceColour2 = ButtonHoverUpperSurfaceColour2;
                buttonLowerSurfaceColour1 = ButtonHoverLowerSurfaceColour1;
                buttonLowerSurfaceColour2 = ButtonHoverLowerSurfaceColour2;
            }

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
            {
                buttonUpperSurfaceColour1 = buttonUpperSurfaceColour1.ToGrayScale();
                buttonUpperSurfaceColour2 = buttonUpperSurfaceColour2.ToGrayScale();
                buttonLowerSurfaceColour1 = buttonLowerSurfaceColour1.ToGrayScale();
                buttonLowerSurfaceColour2 = buttonLowerSurfaceColour2.ToGrayScale();
            }

            buttonRectangle.Inflate(-1, -1);

            int upperHeight = buttonRectangle.Height / 2;

            Rectangle upperGradientRect = new Rectangle(buttonRectangle.X, buttonRectangle.Y, buttonRectangle.Width, upperHeight);
            Rectangle lowerGradientRect = new Rectangle(buttonRectangle.X, buttonRectangle.Y + upperHeight, buttonRectangle.Width, buttonRectangle.Height - upperHeight);

            using (GraphicsPath buttonPath = GetRoundedRectanglePath(buttonRectangle, CornerRadius))
            {
                g.SetClip(buttonPath);
                g.IntersectClip(upperGradientRect);

                //Draw upper button surface gradient
                using (Brush buttonUpperSurfaceBrush = new LinearGradientBrush(buttonRectangle, buttonUpperSurfaceColour1, buttonUpperSurfaceColour2, LinearGradientMode.Vertical))
                {
                    g.FillPath(buttonUpperSurfaceBrush, buttonPath);
                }

                g.ResetClip();

                g.SetClip(buttonPath);
                g.IntersectClip(lowerGradientRect);

                //Draw lower button surface gradient
                using (Brush buttonLowerSurfaceBrush = new LinearGradientBrush(buttonRectangle, buttonLowerSurfaceColour1, buttonLowerSurfaceColour2, LinearGradientMode.Vertical))
                {
                    g.FillPath(buttonLowerSurfaceBrush, buttonPath);
                }

                g.ResetClip();

                g.SetClip(buttonPath);

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

                        if (alignment == ToggleSwitchButtonAlignment.CENTER)
                        {
                            imageXPos = (int)((float)buttonRectangle.X + (((float)buttonRectangle.Width - (float)resizedImageSize.Width) / 2));
                        }
                        else if (alignment == ToggleSwitchButtonAlignment.RIGHT)
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
                        if (alignment == ToggleSwitchButtonAlignment.CENTER)
                        {
                            imageXPos = (int)((float)buttonRectangle.X + (((float)buttonRectangle.Width - (float)imageSize.Width) / 2));
                        }
                        else if (alignment == ToggleSwitchButtonAlignment.RIGHT)
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
            float buttonWidth = 1.61f * ToggleSwitch.Height;
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
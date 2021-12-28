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
    public class ToggleSwitchModernKryptonRenderer : ToggleSwitchRendererBase, IDisposable, IGlobalValues, IModernValues
    {
        #region Constructor

        private GraphicsPath _innerControlPath = null;

        public ToggleSwitchModernKryptonRenderer()
        {
            OuterBorderColour = Color.FromArgb(255, 31, 31, 31);
            InnerBorderColour1 = Color.FromArgb(255, 80, 80, 82);
            InnerBorderColour2 = Color.FromArgb(255, 109, 110, 112);
            LeftSideBackColour1 = Color.FromArgb(255, 57, 166, 222);
            LeftSideBackColour2 = Color.FromArgb(255, 53, 155, 229);
            RightSideBackColour1 = Color.FromArgb(255, 48, 49, 45);
            RightSideBackColour2 = Color.FromArgb(255, 51, 52, 48);
            ButtonNormalBorderColour1 = Color.FromArgb(255, 31, 31, 31);
            ButtonNormalBorderColour2 = Color.FromArgb(255, 31, 31, 31);
            ButtonNormalSurfaceColour1 = Color.FromArgb(255, 51, 52, 48);
            ButtonNormalSurfaceColour2 = Color.FromArgb(255, 51, 52, 48);
            ArrowNormalColour = Color.FromArgb(255, 53, 156, 230);
            ButtonHoverBorderColour1 = Color.FromArgb(255, 29, 29, 29);
            ButtonHoverBorderColour2 = Color.FromArgb(255, 29, 29, 29);
            ButtonHoverSurfaceColour1 = Color.FromArgb(255, 48, 49, 45);
            ButtonHoverSurfaceColour2 = Color.FromArgb(255, 48, 49, 45);
            ArrowHoverColour = Color.FromArgb(255, 50, 148, 219);
            ButtonPressedBorderColour1 = Color.FromArgb(255, 23, 23, 23);
            ButtonPressedBorderColour2 = Color.FromArgb(255, 23, 23, 23);
            ButtonPressedSurfaceColour1 = Color.FromArgb(255, 38, 39, 36);
            ButtonPressedSurfaceColour2 = Color.FromArgb(255, 38, 39, 36);
            ArrowPressedColour = Color.FromArgb(255, 39, 117, 172);
            ButtonShadowColour1 = Color.FromArgb(50, 0, 0, 0);
            ButtonShadowColour2 = Color.FromArgb(0, 0, 0, 0);

            ButtonShadowWidth = 7;
            CornerRadius = 6;
            ButtonCornerRadius = 6;
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
        public Color LeftSideBackColour1 { get; set; }
        public Color LeftSideBackColour2 { get; set; }
        public Color RightSideBackColour1 { get; set; }
        public Color RightSideBackColour2 { get; set; }
        public Color ButtonNormalBorderColour1 { get; set; }
        public Color ButtonNormalBorderColour2 { get; set; }
        public Color ButtonNormalSurfaceColour1 { get; set; }
        public Color ButtonNormalSurfaceColour2 { get; set; }
        public Color ArrowNormalColour { get; set; }
        public Color ButtonHoverBorderColour1 { get; set; }
        public Color ButtonHoverBorderColour2 { get; set; }
        public Color ButtonHoverSurfaceColour1 { get; set; }
        public Color ButtonHoverSurfaceColour2 { get; set; }
        public Color ArrowHoverColour { get; set; }
        public Color ButtonPressedBorderColour1 { get; set; }
        public Color ButtonPressedBorderColour2 { get; set; }
        public Color ButtonPressedSurfaceColour1 { get; set; }
        public Color ButtonPressedSurfaceColour2 { get; set; }
        public Color ArrowPressedColour { get; set; }
        public Color ButtonShadowColour1 { get; set; }
        public Color ButtonShadowColour2 { get; set; }

        public int ButtonShadowWidth { get; set; }
        public int CornerRadius { get; set; }
        public int ButtonCornerRadius { get; set; }

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

            if (_innerControlPath != null)
            {
                g.SetClip(_innerControlPath);
                g.IntersectClip(buttonRectangle);
            }
            else
            {
                g.SetClip(buttonRectangle);
            }

            using (GraphicsPath buttonPath = GetRoundedRectanglePath(buttonRectangle, ButtonCornerRadius))
            {
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
            }

            g.ResetClip();

            //Draw button arrows
            Color arrowColour = ArrowNormalColour;

            if (ToggleSwitch.IsButtonPressed)
                arrowColour = ArrowPressedColour;
            else if (ToggleSwitch.IsButtonHovered)
                arrowColour = ArrowHoverColour;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                arrowColour = arrowColour.ToGrayScale();

            Rectangle arrowRectangle = new Rectangle();
            arrowRectangle.Height = 9;
            arrowRectangle.Width = 22;
            arrowRectangle.X = buttonRectangle.X + (int)(((double)buttonRectangle.Width - (double)arrowRectangle.Width) / 2);
            arrowRectangle.Y = buttonRectangle.Y + (int)(((double)buttonRectangle.Height - (double)arrowRectangle.Height) / 2);

            using (Brush arrowBrush = new SolidBrush(arrowColour))
            {
                using (GraphicsPath arrowLeftPath = GetArrowLeftPath(arrowRectangle))
                {
                    g.FillPath(arrowBrush, arrowLeftPath);
                }

                using (GraphicsPath arrowRightPath = GetArrowRightPath(arrowRectangle))
                {
                    g.FillPath(arrowBrush, arrowRightPath);
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

        public GraphicsPath GetArrowLeftPath(Rectangle arrowRectangle)
        {
            GraphicsPath gp = new GraphicsPath();

            Point top = new Point(arrowRectangle.X + 8, arrowRectangle.Y);
            Point bottom = new Point(arrowRectangle.X + 8, arrowRectangle.Y + arrowRectangle.Height);
            Point tip = new Point(arrowRectangle.X, arrowRectangle.Y + (arrowRectangle.Height / 2));

            gp.AddLine(top, bottom);
            gp.AddLine(bottom, tip);
            gp.AddLine(tip, top);

            return gp;
        }

        public GraphicsPath GetArrowRightPath(Rectangle arrowRectangle)
        {
            GraphicsPath gp = new GraphicsPath();

            Point top = new Point(arrowRectangle.X + 14, arrowRectangle.Y);
            Point bottom = new Point(arrowRectangle.X + 14, arrowRectangle.Y + arrowRectangle.Height);
            Point tip = new Point(arrowRectangle.X + arrowRectangle.Width, arrowRectangle.Y + (arrowRectangle.Height / 2));

            gp.AddLine(top, bottom);
            gp.AddLine(bottom, tip);
            gp.AddLine(tip, top);

            return gp;
        }

        public override int GetButtonWidth()
        {
            float buttonWidth = 1.41f * ToggleSwitch.Height;
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
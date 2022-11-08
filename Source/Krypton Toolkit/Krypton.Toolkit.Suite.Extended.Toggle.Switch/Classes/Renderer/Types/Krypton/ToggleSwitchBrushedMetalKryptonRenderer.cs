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
    public class ToggleSwitchBrushedMetalKryptonRenderer : ToggleSwitchRendererBase, IBrushedMetalValues
    {
        #region Constructor

        public ToggleSwitchBrushedMetalKryptonRenderer()
        {
            BorderColour1 = Color.FromArgb(255, 145, 146, 149);
            BorderColour2 = Color.FromArgb(255, 227, 229, 232);
            BackColour1 = Color.FromArgb(255, 125, 126, 128);
            BackColour2 = Color.FromArgb(255, 224, 226, 228);
            UpperShadowColour1 = Color.FromArgb(150, 0, 0, 0);
            UpperShadowColour2 = Color.FromArgb(5, 0, 0, 0);
            ButtonNormalBorderColour = Color.FromArgb(255, 144, 144, 145);
            ButtonNormalSurfaceColour = Color.FromArgb(255, 251, 251, 251);
            ButtonHoverBorderColour = Color.FromArgb(255, 166, 167, 168);
            ButtonHoverSurfaceColour = Color.FromArgb(255, 238, 238, 238);
            ButtonPressedBorderColour = Color.FromArgb(255, 123, 123, 123);
            ButtonPressedSurfaceColour = Color.FromArgb(255, 184, 184, 184);

            UpperShadowHeight = 8;
        }

        #endregion Constructor

        #region Public Properties

        public Color BorderColour1 { get; set; }
        public Color BorderColour2 { get; set; }
        public Color BackColour1 { get; set; }
        public Color BackColour2 { get; set; }
        public Color UpperShadowColour1 { get; set; }
        public Color UpperShadowColour2 { get; set; }
        public Color ButtonNormalBorderColour { get; set; }
        public Color ButtonNormalSurfaceColour { get; set; }
        public Color ButtonHoverBorderColour { get; set; }
        public Color ButtonHoverSurfaceColour { get; set; }
        public Color ButtonPressedBorderColour { get; set; }
        public Color ButtonPressedSurfaceColour { get; set; }

        public int UpperShadowHeight { get; set; }

        #endregion Public Properties

        #region Render Method Implementations

        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            //Draw outer border
            using (GraphicsPath outerControlPath = GetRectangleClipPath(borderRectangle))
            {
                g.SetClip(outerControlPath);

                Color borderColour1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? BorderColour1.ToGrayScale() : BorderColour1;
                Color borderColour2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? BorderColour2.ToGrayScale() : BorderColour2;

                using (Brush borderBrush = new LinearGradientBrush(borderRectangle, borderColour1, borderColour2, LinearGradientMode.Vertical))
                {
                    g.FillPath(borderBrush, outerControlPath);
                }

                g.ResetClip();
            }

            //Draw inner background
            Rectangle innercontrolRectangle = new Rectangle(borderRectangle.X + 1, borderRectangle.Y + 1, borderRectangle.Width - 1, borderRectangle.Height - 2);

            using (GraphicsPath innerControlPath = GetRectangleClipPath(innercontrolRectangle))
            {
                g.SetClip(innerControlPath);

                Color backColour1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? BackColour1.ToGrayScale() : BackColour1;
                Color backColour2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? BackColour2.ToGrayScale() : BackColour2;

                using (Brush backgroundBrush = new LinearGradientBrush(borderRectangle, backColour1, backColour2, LinearGradientMode.Horizontal))
                {
                    g.FillPath(backgroundBrush, innerControlPath);
                }

                //Draw inner top shadow
                Rectangle upperShadowRectangle = new Rectangle(innercontrolRectangle.X, innercontrolRectangle.Y, innercontrolRectangle.Width, UpperShadowHeight);

                g.IntersectClip(upperShadowRectangle);

                using (Brush shadowBrush = new LinearGradientBrush(upperShadowRectangle, UpperShadowColour1, UpperShadowColour2, LinearGradientMode.Vertical))
                {
                    g.FillRectangle(shadowBrush, upperShadowRectangle);
                }

                g.ResetClip();
            }
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            Rectangle innercontrolRectangle = new Rectangle(1, 1, ToggleSwitch.Width - 1, ToggleSwitch.Height - 2);

            using (GraphicsPath innerControlPath = GetRectangleClipPath(innercontrolRectangle))
            {
                g.SetClip(innerControlPath);

                //Draw image or text
                if (ToggleSwitch.OnSideImage != null || !string.IsNullOrEmpty(ToggleSwitch.OnText))
                {
                    RectangleF fullRectangle = new RectangleF(leftRectangle.X + 2 - (totalToggleFieldWidth - leftRectangle.Width), 2, totalToggleFieldWidth - 2, ToggleSwitch.Height - 4);

                    g.IntersectClip(fullRectangle);

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
                }

                g.ResetClip();
            }
        }

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            Rectangle innercontrolRectangle = new Rectangle(1, 1, ToggleSwitch.Width - 1, ToggleSwitch.Height - 2);

            using (GraphicsPath innerControlPath = GetRectangleClipPath(innercontrolRectangle))
            {
                g.SetClip(innerControlPath);

                //Draw image or text
                if (ToggleSwitch.OffSideImage != null || !string.IsNullOrEmpty(ToggleSwitch.OffText))
                {
                    RectangleF fullRectangle = new RectangleF(rightRectangle.X, 2, totalToggleFieldWidth - 2, ToggleSwitch.Height - 4);

                    g.IntersectClip(fullRectangle);

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
                }

                g.ResetClip();
            }
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            g.SetClip(buttonRectangle);

            //Draw button surface
            Color buttonSurfaceColor = ButtonNormalSurfaceColour;

            if (ToggleSwitch.IsButtonPressed)
                buttonSurfaceColor = ButtonPressedSurfaceColour;
            else if (ToggleSwitch.IsButtonHovered)
                buttonSurfaceColor = ButtonHoverSurfaceColour;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                buttonSurfaceColor = buttonSurfaceColor.ToGrayScale();

            using (Brush buttonSurfaceBrush = new SolidBrush(buttonSurfaceColor))
            {
                g.FillEllipse(buttonSurfaceBrush, buttonRectangle);
            }

            //Draw "metal" surface
            PointF centerPoint1 = new PointF(buttonRectangle.X + (buttonRectangle.Width / 2f), buttonRectangle.Y + 1.2f * (buttonRectangle.Height / 2f));

            using (PathGradientBrush firstMetalBrush = GetBrush(new Color[]
                                                                  {
                                                                      Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent,
                                                                      Color.Transparent, Color.Transparent, Color.Transparent, Color.FromArgb(255, 110, 110, 110), Color.Transparent, Color.Transparent,
                                                                      Color.Transparent
                                                                  }, buttonRectangle, centerPoint1))
            {
                g.FillEllipse(firstMetalBrush, buttonRectangle);
            }

            PointF centerPoint2 = new PointF(buttonRectangle.X + 0.8f * (buttonRectangle.Width / 2f), buttonRectangle.Y + (buttonRectangle.Height / 2f));

            using (PathGradientBrush secondMetalBrush = GetBrush(new Color[]
                                                                  {
                                                                      Color.FromArgb(255, 110, 110, 110), Color.Transparent,  Color.Transparent, Color.Transparent,
                                                                      Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent,
                                                                      Color.FromArgb(255, 110, 110, 110)
                                                                  }, buttonRectangle, centerPoint2))
            {
                g.FillEllipse(secondMetalBrush, buttonRectangle);
            }

            PointF centerPoint3 = new PointF(buttonRectangle.X + 1.2f * (buttonRectangle.Width / 2f), buttonRectangle.Y + (buttonRectangle.Height / 2f));

            using (PathGradientBrush thirdMetalBrush = GetBrush(new Color[]
                                                                  {
                                                                      Color.Transparent, Color.Transparent,  Color.Transparent, Color.Transparent,
                                                                      Color.FromArgb(255, 98, 98, 98), Color.Transparent, Color.Transparent, Color.Transparent,
                                                                      Color.Transparent
                                                                  }, buttonRectangle, centerPoint3))
            {
                g.FillEllipse(thirdMetalBrush, buttonRectangle);
            }

            PointF centerPoint4 = new PointF(buttonRectangle.X + 0.9f * (buttonRectangle.Width / 2f), buttonRectangle.Y + 0.9f * (buttonRectangle.Height / 2f));

            using (PathGradientBrush fourthMetalBrush = GetBrush(new Color[]
                                                                  {
                                                                      Color.Transparent, Color.FromArgb(255, 188, 188, 188), Color.FromArgb(255, 110, 110, 110), Color.Transparent, Color.Transparent, Color.Transparent,
                                                                      Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent, Color.Transparent,
                                                                      Color.Transparent
                                                                  }, buttonRectangle, centerPoint4))
            {
                g.FillEllipse(fourthMetalBrush, buttonRectangle);
            }

            //Draw button border
            Color buttonBorderColor = ButtonNormalBorderColour;

            if (ToggleSwitch.IsButtonPressed)
                buttonBorderColor = ButtonPressedBorderColour;
            else if (ToggleSwitch.IsButtonHovered)
                buttonBorderColor = ButtonHoverBorderColour;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                buttonBorderColor = buttonBorderColor.ToGrayScale();

            using (Pen buttonBorderPen = new Pen(buttonBorderColor))
            {
                g.DrawEllipse(buttonBorderPen, buttonRectangle);
            }

            g.ResetClip();
        }

        #endregion Render Method Implementations

        #region Helper Method Implementations

        public GraphicsPath GetRectangleClipPath(Rectangle rect)
        {
            GraphicsPath borderPath = new GraphicsPath();
            borderPath.AddArc(rect.X, rect.Y, rect.Height, rect.Height, 90, 180);
            borderPath.AddArc(rect.Width - rect.Height, rect.Y, rect.Height, rect.Height, 270, 180);
            borderPath.CloseFigure();

            return borderPath;
        }

        public GraphicsPath GetButtonClipPath()
        {
            Rectangle buttonRectangle = GetButtonRectangle();

            GraphicsPath buttonPath = new GraphicsPath();

            buttonPath.AddArc(buttonRectangle.X, buttonRectangle.Y, buttonRectangle.Height, buttonRectangle.Height, 0, 360);

            return buttonPath;
        }

        public override int GetButtonWidth()
        {
            return ToggleSwitch.Height - 2;
        }

        public override Rectangle GetButtonRectangle()
        {
            int buttonWidth = GetButtonWidth();
            return GetButtonRectangle(buttonWidth);
        }

        public override Rectangle GetButtonRectangle(int buttonWidth)
        {
            Rectangle buttonRect = new Rectangle(ToggleSwitch.ButtonValue, 1, buttonWidth, buttonWidth);
            return buttonRect;
        }

        private PathGradientBrush GetBrush(Color[] Colors, RectangleF r, PointF centerPoint)
        {
            int i = Colors.Length - 1;
            PointF[] points = new PointF[i + 1];

            float a = 0f;
            int n = 0;
            float cx = r.Width / 2f;
            float cy = r.Height / 2f;

            int w = (int)(Math.Floor((180.0 * (i - 2.0) / i) / 2.0));
            double wi = w * Math.PI / 180.0;
            double faktor = 1.0 / Math.Sin(wi);

            float radx = (float)(cx * faktor);
            float rady = (float)(cy * faktor);

            while (a <= Math.PI * 2)
            {
                points[n] = new PointF((float)((cx + (Math.Cos(a) * radx))) + r.Left, (float)((cy + (Math.Sin(a) * rady))) + r.Top);
                n += 1;
                a += (float)(Math.PI * 2 / i);
            }

            points[i] = points[0];
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLines(points);

            PathGradientBrush fBrush = new PathGradientBrush(graphicsPath);
            fBrush.CenterPoint = centerPoint;
            fBrush.CenterColor = Color.Transparent;
            fBrush.SurroundColors = new Color[] { Color.White };

            try
            {
                fBrush.SurroundColors = Colors;
            }
            catch (Exception ex)
            {
                throw new Exception("Too may colors!", ex);
            }

            return fBrush;
        }

        #endregion Helper Method Implementations
    }
}
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
    public class ToggleSwitchIOS5Renderer : ToggleSwitchRendererBase, IIOS5Content
    {
        #region Constructor
        public ToggleSwitchIOS5Renderer()
        {
            BorderColour = Color.FromArgb(255, 202, 202, 202);
            LeftSideUpperColour1 = Color.FromArgb(255, 48, 115, 189);
            LeftSideUpperColour2 = Color.FromArgb(255, 17, 123, 220);
            LeftSideLowerColour1 = Color.FromArgb(255, 65, 143, 218);
            LeftSideLowerColour2 = Color.FromArgb(255, 130, 190, 243);
            LeftSideUpperBorderColour = Color.FromArgb(150, 123, 157, 196);
            LeftSideLowerBorderColour = Color.FromArgb(150, 174, 208, 241);
            RightSideUpperColour1 = Color.FromArgb(255, 191, 191, 191);
            RightSideUpperColour2 = Color.FromArgb(255, 229, 229, 229);
            RightSideLowerColour1 = Color.FromArgb(255, 232, 232, 232);
            RightSideLowerColour2 = Color.FromArgb(255, 251, 251, 251);
            RightSideUpperBorderColour = Color.FromArgb(150, 175, 175, 175);
            RightSideLowerBorderColour = Color.FromArgb(150, 229, 230, 233);
            ButtonShadowColour = Color.Transparent;
            ButtonNormalOuterBorderColour = Color.FromArgb(255, 149, 172, 194);
            ButtonNormalInnerBorderColour = Color.FromArgb(255, 235, 235, 235);
            ButtonNormalSurfaceColour1 = Color.FromArgb(255, 216, 215, 216);
            ButtonNormalSurfaceColour2 = Color.FromArgb(255, 251, 250, 251);
            ButtonHoverOuterBorderColour = Color.FromArgb(255, 141, 163, 184);
            ButtonHoverInnerBorderColour = Color.FromArgb(255, 223, 223, 223);
            ButtonHoverSurfaceColour1 = Color.FromArgb(255, 205, 204, 205);
            ButtonHoverSurfaceColour2 = Color.FromArgb(255, 239, 238, 239);
            ButtonPressedOuterBorderColour = Color.FromArgb(255, 111, 128, 145);
            ButtonPressedInnerBorderColour = Color.FromArgb(255, 176, 176, 176);
            ButtonPressedSurfaceColour1 = Color.FromArgb(255, 162, 161, 162);
            ButtonPressedSurfaceColour2 = Color.FromArgb(255, 187, 187, 187);
        }

        #endregion Constructor

        #region Public Properties
        public Color BorderColour { get; set; }
        public Color LeftSideUpperColour1 { get; set; }
        public Color LeftSideUpperColour2 { get; set; }
        public Color LeftSideLowerColour1 { get; set; }
        public Color LeftSideLowerColour2 { get; set; }
        public Color LeftSideUpperBorderColour { get; set; }
        public Color LeftSideLowerBorderColour { get; set; }
        public Color RightSideUpperColour1 { get; set; }
        public Color RightSideUpperColour2 { get; set; }
        public Color RightSideLowerColour1 { get; set; }
        public Color RightSideLowerColour2 { get; set; }
        public Color RightSideUpperBorderColour { get; set; }
        public Color RightSideLowerBorderColour { get; set; }
        public Color ButtonShadowColour { get; set; }
        public Color ButtonNormalOuterBorderColour { get; set; }
        public Color ButtonNormalInnerBorderColour { get; set; }
        public Color ButtonNormalSurfaceColour1 { get; set; }
        public Color ButtonNormalSurfaceColour2 { get; set; }
        public Color ButtonHoverOuterBorderColour { get; set; }
        public Color ButtonHoverInnerBorderColour { get; set; }
        public Color ButtonHoverSurfaceColour1 { get; set; }
        public Color ButtonHoverSurfaceColour2 { get; set; }
        public Color ButtonPressedOuterBorderColour { get; set; }
        public Color ButtonPressedInnerBorderColour { get; set; }
        public Color ButtonPressedSurfaceColour1 { get; set; }
        public Color ButtonPressedSurfaceColour2 { get; set; }
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

            //Draw upper gradient field
            int gradientRectWidth = leftRectangle.Width + buttonWidth / 2;
            int upperGradientRectHeight = (int)((double)0.8 * (double)(leftRectangle.Height - 2));

            Rectangle controlRectangle = new Rectangle(0, 0, ToggleSwitch.Width, ToggleSwitch.Height);
            GraphicsPath controlClipPath = GetControlClipPath(controlRectangle);

            Rectangle upperGradientRectangle = new Rectangle(leftRectangle.X, leftRectangle.Y + 1, gradientRectWidth, upperGradientRectHeight - 1);

            g.SetClip(controlClipPath);
            g.IntersectClip(upperGradientRectangle);

            using (GraphicsPath upperGradientPath = new GraphicsPath())
            {
                upperGradientPath.AddArc(upperGradientRectangle.X, upperGradientRectangle.Y, ToggleSwitch.Height, ToggleSwitch.Height, 135, 135);
                upperGradientPath.AddLine(upperGradientRectangle.X, upperGradientRectangle.Y, upperGradientRectangle.X + upperGradientRectangle.Width, upperGradientRectangle.Y);
                upperGradientPath.AddLine(upperGradientRectangle.X + upperGradientRectangle.Width, upperGradientRectangle.Y, upperGradientRectangle.X + upperGradientRectangle.Width, upperGradientRectangle.Y + upperGradientRectangle.Height);
                upperGradientPath.AddLine(upperGradientRectangle.X, upperGradientRectangle.Y + upperGradientRectangle.Height, upperGradientRectangle.X + upperGradientRectangle.Width, upperGradientRectangle.Y + upperGradientRectangle.Height);

                Color upperColour1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? LeftSideUpperColour1.ToGrayScale() : LeftSideUpperColour1;
                Color upperColour2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? LeftSideUpperColour2.ToGrayScale() : LeftSideUpperColour2;

                using (Brush upperGradientBrush = new LinearGradientBrush(upperGradientRectangle, upperColour1, upperColour2, LinearGradientMode.Vertical))
                {
                    g.FillPath(upperGradientBrush, upperGradientPath);
                }
            }

            g.ResetClip();

            //Draw lower gradient field
            int lowerGradientRectHeight = (int)Math.Ceiling((double)0.5 * (double)(leftRectangle.Height - 2));

            Rectangle lowerGradientRectangle = new Rectangle(leftRectangle.X, leftRectangle.Y + (leftRectangle.Height / 2), gradientRectWidth, lowerGradientRectHeight);

            g.SetClip(controlClipPath);
            g.IntersectClip(lowerGradientRectangle);

            using (GraphicsPath lowerGradientPath = new GraphicsPath())
            {
                lowerGradientPath.AddArc(1, lowerGradientRectangle.Y, (int)(0.75 * (ToggleSwitch.Height - 1)), ToggleSwitch.Height - 1, 215, 45); //Arc from side to top
                lowerGradientPath.AddLine(lowerGradientRectangle.X + buttonWidth / 2, lowerGradientRectangle.Y, lowerGradientRectangle.X + lowerGradientRectangle.Width, lowerGradientRectangle.Y);
                lowerGradientPath.AddLine(lowerGradientRectangle.X + lowerGradientRectangle.Width, lowerGradientRectangle.Y, lowerGradientRectangle.X + lowerGradientRectangle.Width, lowerGradientRectangle.Y + lowerGradientRectangle.Height);
                lowerGradientPath.AddLine(lowerGradientRectangle.X + buttonWidth / 4, lowerGradientRectangle.Y + lowerGradientRectangle.Height, lowerGradientRectangle.X + lowerGradientRectangle.Width, lowerGradientRectangle.Y + lowerGradientRectangle.Height);
                lowerGradientPath.AddArc(1, 1, ToggleSwitch.Height - 1, ToggleSwitch.Height - 1, 90, 70); //Arc from side to bottom

                Color lowerColour1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? LeftSideLowerColour1.ToGrayScale() : LeftSideLowerColour1;
                Color lowerColour2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? LeftSideLowerColour2.ToGrayScale() : LeftSideLowerColour2;

                using (Brush lowerGradientBrush = new LinearGradientBrush(lowerGradientRectangle, lowerColour1, lowerColour2, LinearGradientMode.Vertical))
                {
                    g.FillPath(lowerGradientBrush, lowerGradientPath);
                }
            }

            g.ResetClip();

            controlRectangle = new Rectangle(0, 0, ToggleSwitch.Width, ToggleSwitch.Height);
            controlClipPath = GetControlClipPath(controlRectangle);

            g.SetClip(controlClipPath);

            //Draw upper inside border
            Color upperBordercolor = LeftSideUpperBorderColour;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                upperBordercolor = upperBordercolor.ToGrayScale();

            using (Pen upperBorderPen = new Pen(upperBordercolor))
            {
                g.DrawLine(upperBorderPen, leftRectangle.X, leftRectangle.Y + 1, leftRectangle.X + leftRectangle.Width + (buttonWidth / 2), leftRectangle.Y + 1);
            }

            //Draw lower inside border
            Color lowerBordercolor = LeftSideLowerBorderColour;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                lowerBordercolor = lowerBordercolor.ToGrayScale();

            using (Pen lowerBorderPen = new Pen(lowerBordercolor))
            {
                g.DrawLine(lowerBorderPen, leftRectangle.X, leftRectangle.Y + leftRectangle.Height - 1, leftRectangle.X + leftRectangle.Width + (buttonWidth / 2), leftRectangle.Y + leftRectangle.Height - 1);
            }

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

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle buttonRectangle = GetButtonRectangle();

            Rectangle controlRectangle = new Rectangle(0, 0, ToggleSwitch.Width, ToggleSwitch.Height);
            GraphicsPath controlClipPath = GetControlClipPath(controlRectangle);

            //Draw upper gradient field
            int gradientRectWidth = rightRectangle.Width + buttonRectangle.Width / 2;
            int upperGradientRectHeight = (int)((double)0.8 * (double)(rightRectangle.Height - 2));

            Rectangle upperGradientRectangle = new Rectangle(rightRectangle.X - buttonRectangle.Width / 2, rightRectangle.Y + 1, gradientRectWidth - 1, upperGradientRectHeight - 1);

            g.SetClip(controlClipPath);
            g.IntersectClip(upperGradientRectangle);

            using (GraphicsPath upperGradientPath = new GraphicsPath())
            {
                upperGradientPath.AddLine(upperGradientRectangle.X, upperGradientRectangle.Y, upperGradientRectangle.X + upperGradientRectangle.Width, upperGradientRectangle.Y);
                upperGradientPath.AddArc(upperGradientRectangle.X + upperGradientRectangle.Width - ToggleSwitch.Height + 1, upperGradientRectangle.Y - 1, ToggleSwitch.Height, ToggleSwitch.Height, 270, 115);
                upperGradientPath.AddLine(upperGradientRectangle.X + upperGradientRectangle.Width, upperGradientRectangle.Y + upperGradientRectangle.Height, upperGradientRectangle.X, upperGradientRectangle.Y + upperGradientRectangle.Height);
                upperGradientPath.AddLine(upperGradientRectangle.X, upperGradientRectangle.Y + upperGradientRectangle.Height, upperGradientRectangle.X, upperGradientRectangle.Y);

                Color upperColour1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? RightSideUpperColour1.ToGrayScale() : RightSideUpperColour1;
                Color upperColour2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? RightSideUpperColour2.ToGrayScale() : RightSideUpperColour2;

                using (Brush upperGradientBrush = new LinearGradientBrush(upperGradientRectangle, upperColour1, upperColour2, LinearGradientMode.Vertical))
                {
                    g.FillPath(upperGradientBrush, upperGradientPath);
                }
            }

            g.ResetClip();

            //Draw lower gradient field
            int lowerGradientRectHeight = (int)Math.Ceiling((double)0.5 * (double)(rightRectangle.Height - 2));

            Rectangle lowerGradientRectangle = new Rectangle(rightRectangle.X - buttonRectangle.Width / 2, rightRectangle.Y + (rightRectangle.Height / 2), gradientRectWidth - 1, lowerGradientRectHeight);

            g.SetClip(controlClipPath);
            g.IntersectClip(lowerGradientRectangle);

            using (GraphicsPath lowerGradientPath = new GraphicsPath())
            {
                lowerGradientPath.AddLine(lowerGradientRectangle.X, lowerGradientRectangle.Y, lowerGradientRectangle.X + lowerGradientRectangle.Width, lowerGradientRectangle.Y);
                lowerGradientPath.AddArc(lowerGradientRectangle.X + lowerGradientRectangle.Width - (int)(0.75 * (ToggleSwitch.Height - 1)), lowerGradientRectangle.Y, (int)(0.75 * (ToggleSwitch.Height - 1)), ToggleSwitch.Height - 1, 270, 45);  //Arc from top to side
                lowerGradientPath.AddArc(ToggleSwitch.Width - ToggleSwitch.Height, 0, ToggleSwitch.Height, ToggleSwitch.Height, 20, 70); //Arc from side to bottom
                lowerGradientPath.AddLine(lowerGradientRectangle.X + lowerGradientRectangle.Width, lowerGradientRectangle.Y + lowerGradientRectangle.Height, lowerGradientRectangle.X, lowerGradientRectangle.Y + lowerGradientRectangle.Height);
                lowerGradientPath.AddLine(lowerGradientRectangle.X, lowerGradientRectangle.Y + lowerGradientRectangle.Height, lowerGradientRectangle.X, lowerGradientRectangle.Y);

                Color lowerColour1 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? RightSideLowerColour1.ToGrayScale() : RightSideLowerColour1;
                Color lowerColour2 = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? RightSideLowerColour2.ToGrayScale() : RightSideLowerColour2;

                using (Brush lowerGradientBrush = new LinearGradientBrush(lowerGradientRectangle, lowerColour1, lowerColour2, LinearGradientMode.Vertical))
                {
                    g.FillPath(lowerGradientBrush, lowerGradientPath);
                }
            }

            g.ResetClip();

            controlRectangle = new Rectangle(0, 0, ToggleSwitch.Width, ToggleSwitch.Height);
            controlClipPath = GetControlClipPath(controlRectangle);

            g.SetClip(controlClipPath);

            //Draw upper inside border
            Color upperBordercolour = RightSideUpperBorderColour;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                upperBordercolour = upperBordercolour.ToGrayScale();

            using (Pen upperBorderPen = new Pen(upperBordercolour))
            {
                g.DrawLine(upperBorderPen, rightRectangle.X - (buttonRectangle.Width / 2), rightRectangle.Y + 1, rightRectangle.X + rightRectangle.Width, rightRectangle.Y + 1);
            }

            //Draw lower inside border
            Color lowerBordercolour = RightSideLowerBorderColour;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                lowerBordercolour = lowerBordercolour.ToGrayScale();

            using (Pen lowerBorderPen = new Pen(lowerBordercolour))
            {
                g.DrawLine(lowerBorderPen, rightRectangle.X - (buttonRectangle.Width / 2), rightRectangle.Y + rightRectangle.Height - 1, rightRectangle.X + rightRectangle.Width, rightRectangle.Y + rightRectangle.Height - 1);
            }

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

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            if (ToggleSwitch.IsButtonOnLeftSide)
                buttonRectangle.X += 1;
            else if (ToggleSwitch.IsButtonOnRightSide)
                buttonRectangle.X -= 1;

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            //Draw button shadow
            buttonRectangle.Inflate(1, 1);

            Rectangle shadowClipRectangle = new Rectangle(buttonRectangle.Location, buttonRectangle.Size);
            shadowClipRectangle.Inflate(0, -1);

            if (ToggleSwitch.IsButtonOnLeftSide)
            {
                shadowClipRectangle.X += shadowClipRectangle.Width / 2;
                shadowClipRectangle.Width = shadowClipRectangle.Width / 2;
            }
            else if (ToggleSwitch.IsButtonOnRightSide)
            {
                shadowClipRectangle.Width = shadowClipRectangle.Width / 2;
            }

            g.SetClip(shadowClipRectangle);

            Color buttonShadowColour = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? ButtonShadowColour.ToGrayScale() : ButtonShadowColour;

            using (Pen buttonShadowPen = new Pen(buttonShadowColour))
            {
                g.DrawEllipse(buttonShadowPen, buttonRectangle);
            }

            g.ResetClip();

            buttonRectangle.Inflate(-1, -1);

            //Draw outer button border
            Color buttonOuterBorderColour = ButtonNormalOuterBorderColour;

            if (ToggleSwitch.IsButtonPressed)
                buttonOuterBorderColour = ButtonPressedOuterBorderColour;
            else if (ToggleSwitch.IsButtonHovered)
                buttonOuterBorderColour = ButtonHoverOuterBorderColour;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                buttonOuterBorderColour = buttonOuterBorderColour.ToGrayScale();

            using (Brush outerBorderBrush = new SolidBrush(buttonOuterBorderColour))
            {
                g.FillEllipse(outerBorderBrush, buttonRectangle);
            }

            //Draw inner button border
            buttonRectangle.Inflate(-1, -1);

            Color buttonInnerBorderColour = ButtonNormalInnerBorderColour;

            if (ToggleSwitch.IsButtonPressed)
                buttonInnerBorderColour = ButtonPressedInnerBorderColour;
            else if (ToggleSwitch.IsButtonHovered)
                buttonInnerBorderColour = ButtonHoverInnerBorderColour;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                buttonInnerBorderColour = buttonInnerBorderColour.ToGrayScale();

            using (Brush innerBorderBrush = new SolidBrush(buttonInnerBorderColour))
            {
                g.FillEllipse(innerBorderBrush, buttonRectangle);
            }

            //Draw button surface
            buttonRectangle.Inflate(-1, -1);

            Color buttonUpperSurfaceColour = ButtonNormalSurfaceColour1;

            if (ToggleSwitch.IsButtonPressed)
                buttonUpperSurfaceColour = ButtonPressedSurfaceColour1;
            else if (ToggleSwitch.IsButtonHovered)
                buttonUpperSurfaceColour = ButtonHoverSurfaceColour1;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                buttonUpperSurfaceColour = buttonUpperSurfaceColour.ToGrayScale();

            Color buttonLowerSurfaceColour = ButtonNormalSurfaceColour2;

            if (ToggleSwitch.IsButtonPressed)
                buttonLowerSurfaceColour = ButtonPressedSurfaceColour2;
            else if (ToggleSwitch.IsButtonHovered)
                buttonLowerSurfaceColour = ButtonHoverSurfaceColour2;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                buttonLowerSurfaceColour = buttonLowerSurfaceColour.ToGrayScale();

            using (Brush buttonSurfaceBrush = new LinearGradientBrush(buttonRectangle, buttonUpperSurfaceColour, buttonLowerSurfaceColour, LinearGradientMode.Vertical))
            {
                g.FillEllipse(buttonSurfaceBrush, buttonRectangle);
            }

            g.CompositingMode = CompositingMode.SourceOver;
            g.CompositingQuality = CompositingQuality.HighQuality;

            //Draw outer control border
            Rectangle controlRectangle = new Rectangle(0, 0, ToggleSwitch.Width, ToggleSwitch.Height);

            using (GraphicsPath borderPath = GetControlClipPath(controlRectangle))
            {
                Color controlBorderColour = (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled) ? BorderColour.ToGrayScale() : BorderColour;

                using (Pen borderPen = new Pen(controlBorderColour))
                {
                    g.DrawPath(borderPen, borderPath);
                }
            }

            g.ResetClip();

            //Draw button image
            Image buttonImage = ToggleSwitch.ButtonImage ?? (ToggleSwitch.Checked ? ToggleSwitch.OnButtonImage : ToggleSwitch.OffButtonImage);

            if (buttonImage != null)
            {
                g.SetClip(GetButtonClipPath());

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

        #endregion Helper Method Implementations
    }
}
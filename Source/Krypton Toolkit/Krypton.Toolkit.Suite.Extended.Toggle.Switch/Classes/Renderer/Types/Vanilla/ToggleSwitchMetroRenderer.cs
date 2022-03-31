#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    public class ToggleSwitchMetroRenderer : ToggleSwitchRendererBase, IMetroValues
    {
        #region Constructor

        public ToggleSwitchMetroRenderer()
        {
            BackColour = Color.White;
            LeftSideColour = Color.FromArgb(255, 23, 153, 0);
            LeftSideColourHovered = Color.FromArgb(255, 36, 182, 9);
            LeftSideColourPressed = Color.FromArgb(255, 121, 245, 100);
            RightSideColour = Color.FromArgb(255, 166, 166, 166);
            RightSideColourHovered = Color.FromArgb(255, 181, 181, 181);
            RightSideColourPressed = Color.FromArgb(255, 189, 189, 189);
            BorderColour = Color.FromArgb(255, 166, 166, 166);
            ButtonColour = Color.Black;
            ButtonColourHovered = Color.Black;
            ButtonColourPressed = Color.Black;
        }

        #endregion Constructor

        #region Public Properties
        public Color BackColour { get; set; }
        public Color LeftSideColour { get; set; }
        public Color LeftSideColourHovered { get; set; }
        public Color LeftSideColourPressed { get; set; }
        public Color RightSideColour { get; set; }
        public Color RightSideColourHovered { get; set; }
        public Color RightSideColourPressed { get; set; }
        public Color BorderColour { get; set; }
        public Color ButtonColour { get; set; }
        public Color ButtonColourHovered { get; set; }
        public Color ButtonColourPressed { get; set; }
        #endregion Public Properties

        #region Render Method Implementations

        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
            Color borderColour = !ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled ? BorderColour.ToGrayScale() : BorderColour;

            g.SetClip(borderRectangle);

            using (Pen borderPen = new Pen(borderColour))
            {
                g.DrawRectangle(borderPen, borderRectangle.X, borderRectangle.Y, borderRectangle.Width - 1, borderRectangle.Height - 1);
            }

            g.ResetClip();
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            Rectangle adjustedLeftRect = new Rectangle(leftRectangle.X + 2, 2, leftRectangle.Width - 2, leftRectangle.Height - 4);

            if (adjustedLeftRect.Width > 0)
            {
                Color leftColour = LeftSideColour;

                if (ToggleSwitch.IsLeftSidePressed)
                    leftColour = LeftSideColourPressed;
                else if (ToggleSwitch.IsLeftSideHovered)
                    leftColour = LeftSideColourHovered;

                if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                    leftColour = leftColour.ToGrayScale();

                g.SetClip(adjustedLeftRect);

                using (Brush leftBrush = new SolidBrush(leftColour))
                {
                    g.FillRectangle(leftBrush, adjustedLeftRect);
                }

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
            Rectangle adjustedRightRect = new Rectangle(rightRectangle.X, 2, rightRectangle.Width - 2, rightRectangle.Height - 4);

            if (adjustedRightRect.Width > 0)
            {
                Color rightColour = RightSideColour;

                if (ToggleSwitch.IsRightSidePressed)
                    rightColour = RightSideColourPressed;
                else if (ToggleSwitch.IsRightSideHovered)
                    rightColour = RightSideColourHovered;

                if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                    rightColour = rightColour.ToGrayScale();

                g.SetClip(adjustedRightRect);

                using (Brush rightBrush = new SolidBrush(rightColour))
                {
                    g.FillRectangle(rightBrush, adjustedRightRect);
                }

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
            }
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            Color buttonColour = ButtonColour;

            if (ToggleSwitch.IsButtonPressed)
            {
                buttonColour = ButtonColourPressed;
            }
            else if (ToggleSwitch.IsButtonHovered)
            {
                buttonColour = ButtonColourHovered;
            }

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                buttonColour = buttonColour.ToGrayScale();

            g.SetClip(buttonRectangle);

            using (Brush backBrush = new SolidBrush(buttonColour))
            {
                g.FillRectangle(backBrush, buttonRectangle);
            }

            g.ResetClip();
        }

        #endregion Render Method Implementations

        #region Helper Method Implementations

        public override int GetButtonWidth()
        {
            return (int)((double)ToggleSwitch.Height / 3 * 2);
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
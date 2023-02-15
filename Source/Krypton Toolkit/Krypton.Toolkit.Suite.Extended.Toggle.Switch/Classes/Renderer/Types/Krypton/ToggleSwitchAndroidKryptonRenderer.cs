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

#pragma warning disable CS0649

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    public class ToggleSwitchAndroidKryptonRenderer : ToggleSwitchRendererBase, IAndroidValues
    {
        #region Variables
        private PaletteBase _palette;
        private PaletteRedirect _paletteRedirect;
        #endregion

        #region Constructor

        public ToggleSwitchAndroidKryptonRenderer()
        {
            InitiliseColours();

            SlantAngle = 8;
        }

        #endregion Constructor

        #region Public Properties

        public Color BorderColour { get; set; }
        public Color BackColour { get; set; }
        public Color LeftSideColour { get; set; }
        public Color RightSideColour { get; set; }
        public Color OffButtonColour { get; set; }
        public Color OnButtonColour { get; set; }
        public Color OffButtonBorderColour { get; set; }
        public Color OnButtonBorderColour { get; set; }
        public int SlantAngle { get; set; }

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
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            Color leftColour = LeftSideColour;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                leftColour = leftColour.ToGrayScale();

            Rectangle controlRectangle = GetInnerControlRectangle();

            g.SetClip(controlRectangle);

            int halfCathetusLength = GetHalfCathetusLengthBasedOnAngle();

            Rectangle adjustedLeftRect = new Rectangle(leftRectangle.X, leftRectangle.Y, leftRectangle.Width + halfCathetusLength, leftRectangle.Height);

            g.IntersectClip(adjustedLeftRect);

            using (Brush leftBrush = new SolidBrush(leftColour))
            {
                g.FillRectangle(leftBrush, adjustedLeftRect);
            }

            g.ResetClip();
        }

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            Color rightColour = RightSideColour;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                rightColour = rightColour.ToGrayScale();

            Rectangle controlRectangle = GetInnerControlRectangle();

            g.SetClip(controlRectangle);

            int halfCathetusLength = GetHalfCathetusLengthBasedOnAngle();

            Rectangle adjustedRightRect = new Rectangle(rightRectangle.X - halfCathetusLength, rightRectangle.Y, rightRectangle.Width + halfCathetusLength, rightRectangle.Height);

            g.IntersectClip(adjustedRightRect);

            using (Brush rightBrush = new SolidBrush(rightColour))
            {
                g.FillRectangle(rightBrush, adjustedRightRect);
            }

            g.ResetClip();
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            Rectangle controlRectangle = GetInnerControlRectangle();

            g.SetClip(controlRectangle);

            int fullCathetusLength = GetCathetusLengthBasedOnAngle();
            int dblFullCathetusLength = 2 * fullCathetusLength;

            Point[] polygonPoints = new Point[4];

            Rectangle adjustedButtonRect = new Rectangle(buttonRectangle.X - fullCathetusLength, controlRectangle.Y, buttonRectangle.Width + dblFullCathetusLength, controlRectangle.Height);

            if (SlantAngle > 0)
            {
                polygonPoints[0] = new Point(adjustedButtonRect.X + fullCathetusLength, adjustedButtonRect.Y);
                polygonPoints[1] = new Point(adjustedButtonRect.X + adjustedButtonRect.Width - 1, adjustedButtonRect.Y);
                polygonPoints[2] = new Point(adjustedButtonRect.X + adjustedButtonRect.Width - fullCathetusLength - 1, adjustedButtonRect.Y + adjustedButtonRect.Height - 1);
                polygonPoints[3] = new Point(adjustedButtonRect.X, adjustedButtonRect.Y + adjustedButtonRect.Height - 1);
            }
            else
            {
                polygonPoints[0] = new Point(adjustedButtonRect.X, adjustedButtonRect.Y);
                polygonPoints[1] = new Point(adjustedButtonRect.X + adjustedButtonRect.Width - fullCathetusLength - 1, adjustedButtonRect.Y);
                polygonPoints[2] = new Point(adjustedButtonRect.X + adjustedButtonRect.Width - 1, adjustedButtonRect.Y + adjustedButtonRect.Height - 1);
                polygonPoints[3] = new Point(adjustedButtonRect.X + fullCathetusLength, adjustedButtonRect.Y + adjustedButtonRect.Height - 1);
            }

            g.IntersectClip(adjustedButtonRect);

            Color buttonColour = ToggleSwitch.Checked ? OnButtonColour : OffButtonColour;
            Color buttonBorderColour = ToggleSwitch.Checked ? OnButtonBorderColour : OffButtonBorderColour;

            if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
            {
                buttonColour = buttonColour.ToGrayScale();
                buttonBorderColour = buttonBorderColour.ToGrayScale();
            }

            using (Pen buttonPen = new Pen(buttonBorderColour))
            {
                g.DrawPolygon(buttonPen, polygonPoints);
            }

            using (Brush buttonBrush = new SolidBrush(buttonColour))
            {
                g.FillPolygon(buttonBrush, polygonPoints);
            }

            Image buttonImage = ToggleSwitch.ButtonImage ?? (ToggleSwitch.Checked ? ToggleSwitch.OnButtonImage : ToggleSwitch.OffButtonImage);
            string buttonText = ToggleSwitch.Checked ? ToggleSwitch.OnText : ToggleSwitch.OffText;

            if (buttonImage != null || !string.IsNullOrEmpty(buttonText))
            {
                ToggleSwitchButtonAlignment alignment = ToggleSwitch.ButtonImage != null ? ToggleSwitch.ButtonAlignment : (ToggleSwitch.Checked ? ToggleSwitch.OnButtonAlignment : ToggleSwitch.OffButtonAlignment);

                if (buttonImage != null)
                {
                    Size imageSize = buttonImage.Size;
                    Rectangle imageRectangle;

                    int imageXPos = (int)adjustedButtonRect.X;

                    bool scaleImage = ToggleSwitch.ButtonImage != null ? ToggleSwitch.ButtonScaleImageToFit : (ToggleSwitch.Checked ? ToggleSwitch.OnButtonScaleImageToFit : ToggleSwitch.OffButtonScaleImageToFit);

                    if (scaleImage)
                    {
                        Size canvasSize = adjustedButtonRect.Size;
                        Size resizedImageSize = ImageHelper.RescaleImageToFit(imageSize, canvasSize);

                        if (alignment == ToggleSwitchButtonAlignment.Center)
                        {
                            imageXPos = (int)((float)adjustedButtonRect.X + (((float)adjustedButtonRect.Width - (float)resizedImageSize.Width) / 2));
                        }
                        else if (alignment == ToggleSwitchButtonAlignment.Right)
                        {
                            imageXPos = (int)((float)adjustedButtonRect.X + (float)adjustedButtonRect.Width - (float)resizedImageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)adjustedButtonRect.Y + (((float)adjustedButtonRect.Height - (float)resizedImageSize.Height) / 2)), resizedImageSize.Width, resizedImageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(buttonImage, imageRectangle, 0, 0, buttonImage.Width, buttonImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImage(buttonImage, imageRectangle);
                    }
                    else
                    {
                        if (alignment == ToggleSwitchButtonAlignment.Center)
                        {
                            imageXPos = (int)((float)adjustedButtonRect.X + (((float)adjustedButtonRect.Width - (float)imageSize.Width) / 2));
                        }
                        else if (alignment == ToggleSwitchButtonAlignment.Right)
                        {
                            imageXPos = (int)((float)adjustedButtonRect.X + (float)adjustedButtonRect.Width - (float)imageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)adjustedButtonRect.Y + (((float)adjustedButtonRect.Height - (float)imageSize.Height) / 2)), imageSize.Width, imageSize.Height);

                        if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                            g.DrawImage(buttonImage, imageRectangle, 0, 0, buttonImage.Width, buttonImage.Height, GraphicsUnit.Pixel, ImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImageUnscaled(buttonImage, imageRectangle);
                    }
                }
                else if (!string.IsNullOrEmpty(buttonText))
                {
                    Font buttonFont = ToggleSwitch.Checked ? ToggleSwitch.OnFont : ToggleSwitch.OffFont;
                    Color buttonForeColour = ToggleSwitch.Checked ? ToggleSwitch.OnForeColour : ToggleSwitch.OffForeColour;

                    if (!ToggleSwitch.Enabled && ToggleSwitch.GrayWhenDisabled)
                        buttonForeColour = buttonForeColour.ToGrayScale();

                    SizeF textSize = g.MeasureString(buttonText, buttonFont);

                    float textXPos = adjustedButtonRect.X;

                    if (alignment == ToggleSwitchButtonAlignment.Center)
                    {
                        textXPos = (float)adjustedButtonRect.X + (((float)adjustedButtonRect.Width - (float)textSize.Width) / 2);
                    }
                    else if (alignment == ToggleSwitchButtonAlignment.Right)
                    {
                        textXPos = (float)adjustedButtonRect.X + (float)adjustedButtonRect.Width - (float)textSize.Width;
                    }

                    RectangleF textRectangle = new RectangleF(textXPos, (float)adjustedButtonRect.Y + (((float)adjustedButtonRect.Height - (float)textSize.Height) / 2), textSize.Width, textSize.Height);

                    using (Brush textBrush = new SolidBrush(buttonForeColour))
                    {
                        g.DrawString(buttonText, buttonFont, textBrush, textRectangle);
                    }
                }
            }

            g.ResetClip();
        }

        #endregion Render Method Implementations

        #region Helper Method Implementations

        public Rectangle GetInnerControlRectangle()
        {
            return new Rectangle(1, 1, ToggleSwitch.Width - 2, ToggleSwitch.Height - 2);
        }

        public int GetCathetusLengthBasedOnAngle()
        {
            if (SlantAngle == 0)
                return 0;

            double degrees = Math.Abs(SlantAngle);
            double radians = degrees * (Math.PI / 180);
            double length = Math.Tan(radians) * ToggleSwitch.Height;

            return (int)length;
        }

        public int GetHalfCathetusLengthBasedOnAngle()
        {
            if (SlantAngle == 0)
                return 0;

            double degrees = Math.Abs(SlantAngle);
            double radians = degrees * (Math.PI / 180);
            double length = (Math.Tan(radians) * ToggleSwitch.Height) / 2;

            return (int)length;
        }

        public override int GetButtonWidth()
        {
            double buttonWidth = (double)ToggleSwitch.Width / 2;
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

        #region ... Krypton ...

        //Kripton Palette Events
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;

            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                //repaint with new values

                InitiliseColours();
            }
        }

        //Kripton Palette Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void InitiliseColours()
        {
            BorderColour = _palette.ColorTable.MenuBorder;
            BackColour = _palette.ColorTable.MenuStripGradientBegin;
            LeftSideColour = _palette.ColorTable.MenuStripGradientBegin;
            RightSideColour = _palette.ColorTable.MenuStripGradientEnd;
            OffButtonColour = Color.FromArgb(255, 70, 70, 70);
            OnButtonColour = Color.FromArgb(255, 27, 161, 226);
            OffButtonBorderColour = Color.FromArgb(255, 70, 70, 70);
            OnButtonBorderColour = Color.FromArgb(255, 27, 161, 226);
        }
        #endregion
    }
}
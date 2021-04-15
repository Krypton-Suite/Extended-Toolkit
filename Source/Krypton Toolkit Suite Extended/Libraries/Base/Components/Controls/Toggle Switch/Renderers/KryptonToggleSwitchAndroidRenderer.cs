#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonToggleSwitchAndroidRenderer : KryptonToggleSwitchRendererBase
    {
        #region Variables
        private KryptonManager _manager = new KryptonManager();

        private PaletteBackInheritRedirect _paletteBack;

        private PaletteBorderInheritRedirect _paletteBorder;

        private PaletteContentInheritRedirect _paletteContent;

        private IPalette _palette;

        private PaletteRedirect _paletteRedirect;
        #endregion

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
        #endregion

        #region Constructor
        public KryptonToggleSwitchAndroidRenderer()
        {
            if (((_palette != null)))
            {
                _palette.PalettePaint += OnPalettePaint;
            }

            KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;

            _palette = KryptonManager.CurrentGlobalPalette;

            _paletteRedirect = new PaletteRedirect(_palette);

            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);

            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);

            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            InitialiseColours();
        }
        #endregion

        #region Methods
        private void InitialiseColours()
        {

        }
        #endregion

        #region Renderer Base Implementation
        public override Rectangle GetButtonRectangle()
        {
            int buttonWidth = GetButtonWidth();

            return GetButtonRectangle(buttonWidth);
        }

        public override Rectangle GetButtonRectangle(int buttonWidth)
        {
            KryptonToggleSwitch toggleSwitch = new KryptonToggleSwitch();

            Rectangle buttonRect = new Rectangle(toggleSwitch.ButtonValue, 0, buttonWidth, toggleSwitch.Height);

            return buttonRect;
        }

        public override int GetButtonWidth()
        {
            double buttonWidth = (double)ToggleSwitch.Width / 2;

            return (int)buttonWidth;
        }

        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
            KryptonToggleSwitch toggleSwitch = new KryptonToggleSwitch();

            Color borderColour = !toggleSwitch.Enabled && toggleSwitch.GrayWhenDisabled ? BorderColour.ToGrayScale() : BorderColour;

            g.SetClip(borderRectangle);

            using (Pen borderPen = new Pen(borderColour))
            {
                g.DrawRectangle(borderPen, borderRectangle.X, borderRectangle.Y, borderRectangle.Width - 1, borderRectangle.Height - 1);
            }
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            Rectangle controlRectangle = GetInnerControlRectangle();

            g.SetClip(controlRectangle);

            int fullCathetusLength = GetCathetusLengthBasedOnAngle();
            int dblFullCathetusLength = 2 * fullCathetusLength;

            KryptonToggleSwitch toggleSwitch = new KryptonToggleSwitch();

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

            Color buttonColour = toggleSwitch.Checked ? OnButtonColour : OffButtonColour;
            Color buttonBorderColour = toggleSwitch.Checked ? OnButtonBorderColour : OffButtonBorderColour;

            if (!toggleSwitch.Enabled && toggleSwitch.GrayWhenDisabled)
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

            Image buttonImage = toggleSwitch.ButtonImage ?? (toggleSwitch.Checked ? toggleSwitch.OnButtonImage : toggleSwitch.OffButtonImage);
            string buttonText = toggleSwitch.Checked ? toggleSwitch.OnText : toggleSwitch.OffText;

            if (buttonImage != null || !string.IsNullOrEmpty(buttonText))
            {
                ToggleSwitchButtonAlignment alignment = toggleSwitch.ButtonImage != null ? toggleSwitch.ButtonAlignment : (toggleSwitch.Checked ? toggleSwitch.OnButtonAlignment : toggleSwitch.OffButtonAlignment);

                if (buttonImage != null)
                {
                    Size imageSize = buttonImage.Size;
                    Rectangle imageRectangle;

                    int imageXPos = (int)adjustedButtonRect.X;

                    bool scaleImage = toggleSwitch.ButtonImage != null ? toggleSwitch.ButtonScaleImageToFit : (toggleSwitch.Checked ? toggleSwitch.OnButtonScaleImageToFit : toggleSwitch.OffButtonScaleImageToFit);

                    if (scaleImage)
                    {
                        Size canvasSize = adjustedButtonRect.Size;
                        Size resizedImageSize = KryptonToggleSwitchImageHelper.RescaleImageToFit(imageSize, canvasSize);

                        if (alignment == ToggleSwitchButtonAlignment.Center)
                        {
                            imageXPos = (int)((float)adjustedButtonRect.X + (((float)adjustedButtonRect.Width - (float)resizedImageSize.Width) / 2));
                        }
                        else if (alignment == ToggleSwitchButtonAlignment.Right)
                        {
                            imageXPos = (int)((float)adjustedButtonRect.X + (float)adjustedButtonRect.Width - (float)resizedImageSize.Width);
                        }

                        imageRectangle = new Rectangle(imageXPos, (int)((float)adjustedButtonRect.Y + (((float)adjustedButtonRect.Height - (float)resizedImageSize.Height) / 2)), resizedImageSize.Width, resizedImageSize.Height);

                        if (!toggleSwitch.Enabled && toggleSwitch.GrayWhenDisabled)
                            g.DrawImage(buttonImage, imageRectangle, 0, 0, buttonImage.Width, buttonImage.Height, GraphicsUnit.Pixel, KryptonToggleSwitchImageHelper.GetGrayscaleAttributes());
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

                        if (!toggleSwitch.Enabled && toggleSwitch.GrayWhenDisabled)
                            g.DrawImage(buttonImage, imageRectangle, 0, 0, buttonImage.Width, buttonImage.Height, GraphicsUnit.Pixel, KryptonToggleSwitchImageHelper.GetGrayscaleAttributes());
                        else
                            g.DrawImageUnscaled(buttonImage, imageRectangle);
                    }
                }
                else if (!string.IsNullOrEmpty(buttonText))
                {
                    Font buttonFont = toggleSwitch.Checked ? toggleSwitch.OnFont : toggleSwitch.OffFont;
                    Color buttonForeColor = toggleSwitch.Checked ? toggleSwitch.OnForeColour : toggleSwitch.OffForeColour;

                    if (!toggleSwitch.Enabled && toggleSwitch.GrayWhenDisabled)
                        buttonForeColor = buttonForeColor.ToGrayScale();

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

                    using (Brush textBrush = new SolidBrush(buttonForeColor))
                    {
                        g.DrawString(buttonText, buttonFont, textBrush, textRectangle);
                    }
                }
            }

            g.ResetClip();
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            Color leftColour = LeftSideColour;

            KryptonToggleSwitch toggleSwitch = new KryptonToggleSwitch();

            if (!toggleSwitch.Enabled && toggleSwitch.GrayWhenDisabled)
            {
                leftColour = leftColour.ToGrayScale();
            }

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

            KryptonToggleSwitch toggleSwitch = new KryptonToggleSwitch();

            if (!toggleSwitch.Enabled && toggleSwitch.GrayWhenDisabled)
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
        #endregion

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
        #endregion Helper Method

        #region Krypton
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            InitialiseColours();
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (((_palette != null)))
            {
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;
            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                InitialiseColours();
            }

        }
        #endregion
    }
}
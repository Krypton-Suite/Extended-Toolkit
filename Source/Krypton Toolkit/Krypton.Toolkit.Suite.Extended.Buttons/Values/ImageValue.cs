#region MIT License
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


namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    public class ImageValue : Storage, IContentValues
    {
        #region Static Fields
        private static readonly Image _defaultImage = Properties.Resources.Question_32_x_32;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the HeaderValuesBase class.
        /// </summary>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public ImageValue(NeedPaintHandler needPaint)
        {
            // Store the provided paint notification delegate
            NeedPaint = needPaint;

            // Set initial values to the default
            ResetImage();
            ResetImageTransparentColor();
        }
        #endregion

        #region Instance Fields
        private Color _transparent;

        private Image _image;

        [Localizable(true)]
        [Category("Visuals")]
        [Description("Image.")]
        [RefreshProperties(RefreshProperties.All)]
        public Image Image
        {
            get => _image;
            set
            {
                if (_image != value)
                {
                    _image = value;
                    PerformNeedPaint(true);
                }
            }

        }
        #endregion

        #region IsDefault
        /// <summary>
        /// Gets a value indicating if all values are default.
        /// </summary>
        [Browsable(false)]
        public override bool IsDefault => Image == _defaultImage &&
                                           ImageTransparentColor == Color.Empty
                                           ;

        #endregion

        private bool ShouldSerializeImage() => Image != _defaultImage;

        #region IContentValues
        /// <summary>
        /// Resets the Image property to its default value.
        /// </summary>
        public void ResetImage()
        {
            Image = _defaultImage;
        }

        /// <summary>
        /// Gets the content short text.
        /// </summary>
        /// <returns>String value.</returns>
        public Image GetImage(PaletteState state)
        {
            return Image;
        }

        public string GetShortText()
        {
            return string.Empty;
        }

        public string GetLongText()
        {
            return string.Empty;
        }

        #endregion

        #region ImageTransparentColor
        /// <summary>
        /// Gets and sets the heading image transparent color.
        /// </summary>
        [Localizable(true)]
        [Category("Visuals")]
        [Description("Image transparent color.")]
        [RefreshProperties(RefreshProperties.All)]
        [KryptonDefaultColor()]
        public Color ImageTransparentColor
        {
            get => _transparent;

            set
            {
                if (_transparent != value)
                {
                    _transparent = value;
                    PerformNeedPaint(true);
                }
            }
        }

        private bool ShouldSerializeImageTransparentColor()
        {
            return ImageTransparentColor != Color.Empty;
        }

        /// <summary>
        /// Resets the ImageTransparentColor property to its default value.
        /// </summary>
        public void ResetImageTransparentColor()
        {
            ImageTransparentColor = Color.Empty;
        }

        /// <summary>
        /// Gets the content image transparent color.
        /// </summary>
        /// <param name="state">The state for which the image color is needed.</param>
        /// <returns>Color value.</returns>
        public virtual Color GetImageTransparentColor(PaletteState state)
        {
            return ImageTransparentColor;
        }
        #endregion


    }
}
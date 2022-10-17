#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    public class ImageValue : Storage, IContentValues
    {
        #region Static Fields
        private static readonly Image defaultImage = Properties.Resources.Question_32_x_32;
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
        public override bool IsDefault => ((Image == defaultImage) &&
                                           (ImageTransparentColor == Color.Empty)
                                           );

        #endregion

        private bool ShouldSerializeImage()
        {
            return Image != defaultImage;
        }

        #region IContentValues
        /// <summary>
        /// Resets the Image property to its default value.
        /// </summary>
        public void ResetImage()
        {
            Image = defaultImage;
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
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        [KryptonDefaultColorAttribute()]
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
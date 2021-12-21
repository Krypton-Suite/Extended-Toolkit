#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourButtonValues : Storage, IContentValues
    {
        #region Fields
        private Color _transparent, _selectedColour, _emptyBorderColour;

        private Image _image, _sourceImage, _compositeImage;

        private Rectangle _selectedRect;

        private string _text, _extraText;
        #endregion

        #region Static Fields
        private const string DEFAULT_TEXT = "&Colour";

        private static readonly string _defaultExtraText = string.Empty;

        private static readonly Image _defaultImage = Properties.Resources.ColourButton;
        #endregion

        #region Events        
        /// <summary>
        /// Occurs when [text changed].
        /// </summary>
        public event EventHandler TextChanged;
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ColourButtonValues"/> class.
        /// </summary>
        /// <param name="needPaint">The need paint.</param>
        public ColourButtonValues(NeedPaintHandler needPaint)
        {
            NeedPaint = needPaint;

            _image = _defaultImage;

            _transparent = Color.Empty;

            _text = DEFAULT_TEXT;

            _extraText = _defaultExtraText;

            ImageStates = CreateImageStates();

            ImageStates.NeedPaint = needPaint;

            _emptyBorderColour = Color.Gray;

            _selectedColour = Color.Red;

            _selectedRect = new Rectangle(0, 12, 16, 4);
        }
        #endregion

        #region IsDefault
        [Browsable(false)]
        public override bool IsDefault => (ImageStates.IsDefault &&
                                           (Image == _defaultImage) &&
                                           (ImageTransparentColour == Color.Empty) &&
                                           (Text == DEFAULT_TEXT) &&
                                           (ExtraText == _defaultExtraText));
        #endregion

        #region Image
        /// <summary>
        /// Gets and sets the button image.
        /// </summary>
        [Localizable(true)]
        [Category("Visuals")]
        [Description("Button image.")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
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

        private bool ShouldSerializeImage()
        {
            return Image != _defaultImage;
        }

        /// <summary>
        /// Resets the Image property to its default value.
        /// </summary>
        public void ResetImage()
        {
            Image = _defaultImage;
        }
        #endregion

        #region ImageTransparentColor
        /// <summary>
        /// Gets and sets the label image transparent color.
        /// </summary>
        [Localizable(true)]
        [Category("Visuals")]
        [Description("Label image transparent color.")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        [KryptonDefaultColorAttribute()]
        public Color ImageTransparentColour
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

        private bool ShouldSerializeImageTransparentColour()
        {
            return ImageTransparentColour != Color.Empty;
        }

        /// <summary>
        /// Resets the ImageTransparentColor property to its default value.
        /// </summary>
        public void ResetImageTransparentColour()
        {
            ImageTransparentColour = Color.Empty;
        }

        /// <summary>
        /// Gets the content image transparent color.
        /// </summary>
        /// <param name="state">The state for which the image color is needed.</param>
        /// <returns>Color value.</returns>
        public Color GetImageTransparentColor(PaletteState state)
        {
            return ImageTransparentColour;
        }
        #endregion

        #region ImageStates
        /// <summary>
        /// Gets access to the state specific images for the button.
        /// </summary>
        [Category("Visuals")]
        [Description("State specific images for the button.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ButtonImageStates ImageStates { get; }

        private bool ShouldSerializeImageStates()
        {
            return !ImageStates.IsDefault;
        }
        #endregion

        #region Text
        /// <summary>
        /// Gets and sets the button text.
        /// </summary>
        [Localizable(true)]
        [Category("Visuals")]
        [Description("Button text.")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string Text
        {
            get => _text;

            set
            {
                if (_text != value)
                {
                    _text = value;
                    PerformNeedPaint(true);
                    TextChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private bool ShouldSerializeText()
        {
            return Text != DEFAULT_TEXT;
        }

        /// <summary>
        /// Resets the Text property to its default value.
        /// </summary>
        public void ResetText()
        {
            Text = DEFAULT_TEXT;
        }
        #endregion

        #region ExtraText
        /// <summary>
        /// Gets and sets the button extra text.
        /// </summary>
        [Localizable(true)]
        [Category("Visuals")]
        [Description("Button extra text.")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DefaultValue("")]
        public string ExtraText
        {
            get => _extraText;

            set
            {
                if (_extraText != value)
                {
                    _extraText = value;
                    PerformNeedPaint(true);
                }
            }
        }

        private bool ShouldSerializeExtraText()
        {
            return ExtraText != _defaultExtraText;
        }

        /// <summary>
        /// Resets the Description property to its default value.
        /// </summary>
        public void ResetExtraText()
        {
            ExtraText = _defaultExtraText;
        }
        #endregion

        #region SelectedColor
        /// <summary>
        /// Gets and sets the selected color for the composite image.
        /// </summary>
        internal Color SelectedColour
        {
            get => _selectedColour;

            set
            {
                _selectedColour = value;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _compositeImage = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            }
        }
        #endregion

        #region EmptyBorderColor
        /// <summary>
        /// Gets and sets the empty border color for the composite image.
        /// </summary>
        internal Color EmptyBorderColour
        {
            get => _emptyBorderColour;

            set
            {
                _emptyBorderColour = value;
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                _compositeImage = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            }
        }
        #endregion

        #region SelectedRect
        /// <summary>
        /// Gets and sets the selected rectangle for the composite image.
        /// </summary>
        internal Rectangle SelectedRect
        {
            get => _selectedRect;

            set
            {
                _selectedRect = value;
                _compositeImage = null;
            }
        }
        #endregion

        #region CreateImageStates
        /// <summary>
        /// Create the storage for the image states.
        /// </summary>
        /// <returns>Storage object.</returns>
        protected virtual ButtonImageStates CreateImageStates() => new ButtonImageStates();
        #endregion

        #region IContentValues
        /// <summary>
        /// Gets the content image.
        /// </summary>
        /// <param name="state">The state for which the image is needed.</param>
        /// <returns>Image value.</returns>
        public virtual Image GetImage(PaletteState state)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Image image = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            // Try and find a state specific image
            switch (state)
            {
                case PaletteState.Disabled:
                    image = ImageStates.ImageDisabled;
                    break;
                case PaletteState.Normal:
                    image = ImageStates.ImageNormal;
                    break;
                case PaletteState.Pressed:
                    image = ImageStates.ImagePressed;
                    break;
                case PaletteState.Tracking:
                    image = ImageStates.ImageTracking;
                    break;
            }

            // If there is no image then use the generic image
            if (image == null)
            {
                image = Image;
            }

            // Do we need to create another composite image?
            if ((_sourceImage != image) || (_compositeImage == null))
            {
                // Remember image used to create the composite image
                _sourceImage = image;

                if (image == null)
                {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                    _compositeImage = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
                }
                else
                {
                    // Create a copy of the source image
                    Bitmap copyBitmap = new Bitmap(image);

                    // Paint over the image with a color indicator
                    using (Graphics g = Graphics.FromImage(copyBitmap))
                    {
                        // If the color is not defined, i.e. it is empty then...
                        if (_selectedColour.Equals(Color.Empty))
                        {
                            // Indicate the absense of a color by drawing a border around 
                            // the selected color area, thus indicating the area inside the
                            // block is blank/empty.
                            using (Pen borderPen = new Pen(_emptyBorderColour))
                            {
                                g.DrawRectangle(borderPen, new Rectangle(_selectedRect.X,
                                                                         _selectedRect.Y,
                                                                         _selectedRect.Width - 1,
                                                                         _selectedRect.Height - 1));
                            }
                        }
                        else
                        {
                            // We have a valid selected color so draw a solid block of color
                            using (SolidBrush colourBrush = new SolidBrush(_selectedColour))
                            {
                                g.FillRectangle(colourBrush, _selectedRect);
                            }
                        }
                    }

                    // Cache it for future use
                    _compositeImage = copyBitmap;
                }
            }

#pragma warning disable CS8603 // Possible null reference return.
            return _compositeImage;
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Gets the content short text.
        /// </summary>
        public virtual string GetShortText()
        {
            return Text;
        }

        /// <summary>
        /// Gets the content long text.
        /// </summary>
        public virtual string GetLongText()
        {
            return ExtraText;
        }
        #endregion
    }
}
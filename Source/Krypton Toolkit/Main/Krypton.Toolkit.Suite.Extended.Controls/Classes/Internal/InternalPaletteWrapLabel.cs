using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>
    /// Provide wrap label state storage.
    /// </summary>
    public class InternalPaletteWrapLabel : Storage
    {
        #region Instance Fields
        private Font _font;
        private Color _textColor;
        private PaletteTextHint _hint;
        private readonly KryptonBorderedWrapLabel _wrapLabel;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the PaletteWrapLabel class.
        /// </summary>
        /// <param name="wrapLabel">Reference to owning control.</param>
        public InternalPaletteWrapLabel(KryptonBorderedWrapLabel wrapLabel)
        {
            _wrapLabel = wrapLabel;
            _font = null;
            _textColor = Color.Empty;
            _hint = PaletteTextHint.Inherit;
        }
        #endregion

        #region IsDefault
        /// <summary>
        /// Gets a value indicating if all values are default.
        /// </summary>
        [Browsable(false)]
        public override bool IsDefault => (_font == null) &&
                                          (_textColor == Color.Empty) &&
                                          (_hint == PaletteTextHint.Inherit);

        #endregion

        #region Font
        /// <summary>
        /// Gets the font for label text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Font for drawing the label text.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual Font Font
        {
            get => _font;

            set
            {
                _font = value;
                _wrapLabel.PerformLayout();
                _wrapLabel.Invalidate();
            }
        }
        #endregion

        #region TextColor
        /// <summary>
        /// Gets and sets the olor for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Color for the text.")]
        [KryptonDefaultColorAttribute()]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual Color TextColor
        {
            get => _textColor;

            set
            {
                _textColor = value;
                _wrapLabel.Invalidate();
            }
        }
        #endregion

        #region Hint
        /// <summary>
        /// Gets the text rendering hint for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Text rendering hint for the content text.")]
        [DefaultValue(typeof(PaletteTextHint), "Inherit")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual PaletteTextHint Hint
        {
            get => _hint;

            set
            {
                _hint = value;
                _wrapLabel.Invalidate();
            }
        }
        #endregion
    }
}
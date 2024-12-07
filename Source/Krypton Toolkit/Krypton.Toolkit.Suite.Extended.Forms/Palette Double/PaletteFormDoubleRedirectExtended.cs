using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    /// <summary>
    /// Implement storage for palette border and background.
    /// </summary>
    public class PaletteFormDoubleRedirectExtended : PaletteDoubleRedirect
    {
        #region Identity
        /// <summary>
        /// Initialize a new instance of the PaletteDoubleRedirect class.
        /// </summary>
        /// <param name="redirect">inheritance redirection instance.</param>
        /// <param name="backStyle">Initial background style.</param>
        /// <param name="borderStyle">Initial border style.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        /// <param name="ownerForm"></param>
        public PaletteFormDoubleRedirectExtended(PaletteRedirect redirect,
                                     PaletteBackStyle backStyle,
                                     PaletteBorderStyle borderStyle,
                                     NeedPaintHandler? needPaint,
                                     VisualKryptonFormExtended ownerForm)
        {
            // Store the inherit instances
            var backInherit = new PaletteBackInheritRedirect(redirect, backStyle);
            var borderInherit = new PaletteBorderInheritRedirect(redirect, borderStyle);

            // Create storage that maps onto the inherit instances
            var back = new PaletteBack(backInherit, needPaint);
            var border = new PaletteFormBorderExtended(borderInherit, needPaint, ownerForm);

            Construct(redirect, back, backInherit, border, borderInherit, needPaint);
        }

        /// <summary>
        /// Initialize a new instance of the PaletteDoubleRedirect class.
        /// </summary>
        /// <param name="redirect">inheritance redirection instance.</param>
        /// <param name="back">Storage for back values.</param>
        /// <param name="backInherit">inheritance for back values.</param>
        /// <param name="border">Storage for border values.</param>
        /// <param name="borderInherit">inheritance for border values.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public PaletteFormDoubleRedirectExtended(PaletteRedirect redirect,
                                     PaletteBack back,
                                     PaletteBackInheritRedirect backInherit,
                                     PaletteFormBorder border,
                                     PaletteBorderInheritRedirect borderInherit,
                                     NeedPaintHandler needPaint)
        {
            Construct(redirect, back, backInherit, border, borderInherit, needPaint);
        }
        #endregion

    }
}
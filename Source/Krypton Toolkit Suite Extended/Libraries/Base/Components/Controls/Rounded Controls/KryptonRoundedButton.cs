using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    /// <summary>A <seealso cref="KryptonButton"/> with rounded corners.</summary>
    [ToolboxBitmap(typeof(KryptonButton)), Description("A KryptonButton with exposed rounding property")]
    public class KryptonRoundedButton : KryptonButton
    {
        #region Variables
        private int _cornerRadius;

        private PaletteDrawBorders _paletteDrawBorders;
        #endregion

        #region Properties
        /// <summary>Gets or sets the corner radius.</summary>
        /// <value>The corner radius.</value>
        [Category("Appearance"), DefaultValue(25), Description("Size of corner radius. (-1 is the 'default system look' value)")]
        public int CornerRadius { get => _cornerRadius; set { _cornerRadius = value; Invalidate(); } }

        public PaletteDrawBorders Borders { get => _paletteDrawBorders; set { _paletteDrawBorders = value; Invalidate(); } }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonRoundedButton"/> class.</summary>
        public KryptonRoundedButton()
        {
            Borders = PaletteDrawBorders.All;

            CornerRadius = 25;

            StateCommon.Border.DrawBorders = Borders;

            StateCommon.Border.Rounding = CornerRadius;
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            StateCommon.Border.DrawBorders = Borders;

            StateCommon.Border.Rounding = CornerRadius;

            base.OnPaint(e);
        }
        #endregion
    }
}
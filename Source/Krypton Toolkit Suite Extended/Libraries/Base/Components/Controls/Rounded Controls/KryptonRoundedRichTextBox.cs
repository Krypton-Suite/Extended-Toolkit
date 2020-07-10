using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    /// <summary>Provides a rounded <seealso cref="KryptonRichTextBox"/> like Google Chrome's current Omnibox design.</summary>
    [ToolboxBitmap(typeof(KryptonRichTextBox)), ToolboxItem(true), Description("Provides a rounded rich textbox like Google Chrome's current Omnibox design.")]
    public class KryptonRoundedRichTextBox : KryptonRichTextBox
    {
        #region Variables
        private int _cornerRadius;
        #endregion

        #region Properties
        [Category("Appearance"), DefaultValue(25), Description("Size of corner radius. (-1 is the 'default system look' value)")]
        public int CornerRadius { get => _cornerRadius; set { _cornerRadius = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonRoundedRichTextBox()
        {
            CornerRadius = 25;

            StateCommon.Border.Rounding = CornerRadius;
        }
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            StateCommon.Border.Rounding = CornerRadius;

            base.OnPaint(e);
        }
        #endregion
    }
}
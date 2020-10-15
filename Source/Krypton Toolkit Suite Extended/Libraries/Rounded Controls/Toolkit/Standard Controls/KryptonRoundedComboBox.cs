using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Rounded.Controls
{
    public class KryptonRoundedComboBox : KryptonComboBox
    {
        #region Variables
        private int _cornerRoundness;
        #endregion

        #region Properties
        [DefaultValue(-1)]
        public int CornerRoundness { get => _cornerRoundness; set { _cornerRoundness = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonRoundedComboBox()
        {
            CornerRoundness = -1;
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            StateCommon.ComboBox.Border.Rounding = CornerRoundness;

            base.OnPaint(e);
        }
        #endregion
    }
}
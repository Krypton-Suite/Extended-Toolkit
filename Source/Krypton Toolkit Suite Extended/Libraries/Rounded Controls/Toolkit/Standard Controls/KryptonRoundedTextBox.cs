using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Rounded.Controls
{
    public class KryptonRoundedTextBox : KryptonTextBox
    {
        #region Variables
        private int _cornerRoundness;
        #endregion

        #region Properties
        [DefaultValue(-1)]
        public int CornerRoundness { get => _cornerRoundness; set { _cornerRoundness = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonRoundedTextBox()
        {
            CornerRoundness = -1;
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            StateCommon.Border.Rounding = CornerRoundness;

            base.OnPaint(e);
        }
        #endregion
    }
}
using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Rounded.Controls
{
    public class KryptonRoundedMaskedTextBox : KryptonMaskedTextBox
    {
        #region Variables
        private int _cornerRoundness;
        #endregion

        #region Properties
        [DefaultValue(-1)]
        public int CornerRoundness { get => _cornerRoundness; set { _cornerRoundness = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonRoundedMaskedTextBox()
        {
            CornerRoundness = -1;
        }
        #endregion

        #region Overrides
        //protected override
        #endregion
    }
}
using System.Drawing;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonAlphaValueLabel : KryptonLabel
    {
        #region Variables
        private Font _textSize;

        private int _value;
        #endregion

        #region Properties
        public Font TextSize { get => _textSize; set { _textSize = value; Invalidate(); } }

        public int AlphaValue { get => _value; set { _value = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonAlphaValueLabel()
        {
            TextSize = new Font("Segoe UI", 12f, FontStyle.Bold);

            AlphaValue = 255;

            StateCommon.LongText.Font = TextSize;

            StateCommon.ShortText.Font = TextSize;

            Text = $"Alpha Value: { AlphaValue }";
        }
        #endregion
    }
}
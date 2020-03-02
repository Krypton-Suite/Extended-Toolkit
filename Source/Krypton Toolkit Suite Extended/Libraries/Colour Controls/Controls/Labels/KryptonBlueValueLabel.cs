using System.Drawing;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonBlueValueLabel : KryptonLabel
    {
        #region Variables
        private Color _textColour = Color.Blue;

        private Font _textSize;

        private int _value;
        #endregion

        #region Properties
        public Color TextColour { get => _textColour; }

        public Font TextSize { get => _textSize; set { _textSize = value; Invalidate(); } }

        public int RedValue { get => _value; set { _value = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonBlueValueLabel()
        {
            TextSize = new Font("Segoe UI", 12f, FontStyle.Bold);

            RedValue = 255;

            StateCommon.LongText.Color1 = TextColour;

            StateCommon.LongText.Color2 = TextColour;

            StateCommon.LongText.Font = TextSize;

            StateCommon.ShortText.Color1 = TextColour;

            StateCommon.ShortText.Color2 = TextColour;

            StateCommon.ShortText.Font = TextSize;

            Text = $"Blue Value: { RedValue }";
        }
        #endregion
    }
}
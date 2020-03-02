using System.Drawing;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonRedValueNumericBox : KryptonNumericUpDown
    {
        #region Constants
        private const int DEFAULT_VALUE = 0, MINIMUM_DEFAULT_VALUE = 0, MAXIMUM_DEFAULT_VALUE = 255;

        private Color DEFAULT_BACK_COLOUR = Color.Red, DEFAULT_FORECOLOUR = Color.White;

        private Font DEFAULT_TYPEFACE = new Font("Segoe UI", 11f);
        #endregion

        #region Constructor
        public KryptonRedValueNumericBox()
        {
            Minimum = MINIMUM_DEFAULT_VALUE;

            Maximum = MAXIMUM_DEFAULT_VALUE;

            Value = DEFAULT_VALUE;

            StateCommon.Back.Color1 = DEFAULT_BACK_COLOUR;

            StateCommon.Content.Color1 = DEFAULT_FORECOLOUR;

            StateCommon.Content.Font = DEFAULT_TYPEFACE;
        }
        #endregion
    }
}
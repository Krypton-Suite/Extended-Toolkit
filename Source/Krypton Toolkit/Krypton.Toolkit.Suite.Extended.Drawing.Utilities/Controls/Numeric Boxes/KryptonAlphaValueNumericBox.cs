#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class KryptonAlphaValueNumericBox : KryptonNumericUpDown
    {
        #region Constants
        private const int DEFAULT_VALUE = 0, MINIMUM_DEFAULT_VALUE = 0, MAXIMUM_DEFAULT_VALUE = 255;

        private Font DEFAULT_TYPEFACE = new Font("Segoe UI", 11f);
        #endregion

        #region Variable
        private Font _typeface;
        #endregion

        #region Property
        public Font Typeface { get => _typeface; set { _typeface = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonAlphaValueNumericBox()
        {
            Minimum = MINIMUM_DEFAULT_VALUE;

            Maximum = MAXIMUM_DEFAULT_VALUE;

            Value = DEFAULT_VALUE;
        }
        #endregion

        #region Method
        private void AlterTypeface(Font typeface) => StateCommon.Content.Font = typeface;
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            AlterTypeface(_typeface);

            base.OnPaint(e);
        }
        #endregion
    }
}
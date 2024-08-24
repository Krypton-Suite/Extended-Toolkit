#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

#pragma warning disable CS0169
namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class KryptonBlueValueNumericBox : KryptonNumericUpDown
    {
        #region Constants
        private const int DEFAULT_VALUE = 0, MINIMUM_DEFAULT_VALUE = 0, MAXIMUM_DEFAULT_VALUE = 255;
        #endregion 

        #region Variables
        private bool _useAccessibleUi;

        private Color _backColour, _foreColour;

        private Font _typeface;
        #endregion

        #region Properties
        public bool UseAccessibleUi { get => _useAccessibleUi; set { _useAccessibleUi = value; Invalidate(); } }

        public Font Typeface { get => _typeface; set { _typeface = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonBlueValueNumericBox()
        {
            Minimum = MINIMUM_DEFAULT_VALUE;

            Maximum = MAXIMUM_DEFAULT_VALUE;

            Value = DEFAULT_VALUE;

            UseAccessibleUi = false;

            StateCommon.Content.Font = Typeface;

            ToolTipValues.Description = @"The blue value";

            ToolTipValues.Heading = @"Blue Value";

            ToolTipValues.EnableToolTips = true;

            _backColour = Color.Empty;

            _foreColour = Color.Empty;

            //ToolTipValues.Image = Properties.Resources.Blue;
        }
        #endregion

        #region Methods
        private void AlterAppearance(bool useAccessibleUi)
        {
            if (useAccessibleUi)
            {
                StateCommon.Back.Color1 = Color.Empty;

                StateCommon.Content.Color1 = Color.Empty;
            }
            else
            {
                StateCommon.Back.Color1 = Color.Blue;

                StateCommon.Content.Color1 = Color.White;
            }
        }

        private void AlterTypeface(Font typeface) => StateCommon.Content.Font = typeface;
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            AlterAppearance(_useAccessibleUi);

            AlterTypeface(_typeface);

            base.OnPaint(e);
        }
        #endregion
    }
}
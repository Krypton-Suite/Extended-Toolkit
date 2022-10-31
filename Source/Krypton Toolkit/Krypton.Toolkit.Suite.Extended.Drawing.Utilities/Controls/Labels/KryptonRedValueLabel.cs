#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class KryptonRedValueLabel : KryptonLabel
    {
        #region Variables
        private bool _useAccessibleUI, _showCurrentColourValue, _showColon;

        private Color _textColour;

        private Font _typeface;

        private int _value;

        private string _extraText;
        #endregion

        #region Properties
        public bool ShowCurrentColourValue { get => _showCurrentColourValue; set { _showCurrentColourValue = value; Invalidate(); } }

        public bool UseAccessibleUI { get => _useAccessibleUI; set { _useAccessibleUI = value; Invalidate(); } }

        public bool ShowColon { get => _showColon; set { _showColon = value; Invalidate(); } }

        public Color TextColour { get => _textColour; private set { _textColour = value; Invalidate(); } }

        public Font Typeface { get => _typeface; set { _typeface = value; Invalidate(); } }

        public int RedValue { get => _value; set { _value = value; Invalidate(); } }

        public string ExtraText { get => _extraText; set { _extraText = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonRedValueLabel()
        {
            Typeface = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold);

            RedValue = 0;

            TextColour = Color.Red;

            ExtraText = "Red Value";

            ShowColon = false;
        }
        #endregion

        #region Methods
        private void ShowCurrentColourValueOnLabel(bool value, string text = "Red Value", bool showColon = false)
        {
            if (value)
            {
                Text = $"{ text }: { RedValue }";
            }
            else if (_showColon)
            {
                Text = $"{ text }";
            }
            else
            {
                Text = $"{ text }:";
            }
        }

        private void AlterLabelTypeface(Font typeface)
        {
            StateCommon.LongText.Font = typeface;

            StateCommon.ShortText.Font = typeface;
        }

        private void AlterLabelUI(bool useAccessibleUI)
        {
            if (useAccessibleUI)
            {
                StateCommon.LongText.Color1 = Color.Empty;

                StateCommon.LongText.Color2 = Color.Empty;

                StateCommon.ShortText.Color1 = Color.Empty;

                StateCommon.ShortText.Color2 = Color.Empty;
            }
            else
            {
                StateCommon.LongText.Color1 = TextColour;

                StateCommon.LongText.Color2 = TextColour;

                StateCommon.ShortText.Color1 = TextColour;

                StateCommon.ShortText.Color2 = TextColour;
            }
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            ShowCurrentColourValueOnLabel(_showCurrentColourValue, _extraText, _showColon);

            AlterLabelTypeface(_typeface);

            AlterLabelUI(_useAccessibleUI);

            base.OnPaint(e);
        }
        #endregion
    }
}
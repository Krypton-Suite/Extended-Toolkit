#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class KryptonAlphaValueLabel : KryptonLabel
    {
        #region Variables
        private bool _showCurrentColourValue, _showColon;

        private Font _textSize;

        private int _value;

        private string _extraText;
        #endregion

        #region Properties
        public bool ShowCurrentColourValue { get => _showCurrentColourValue; set { _showCurrentColourValue = value; Invalidate(); } }

        public bool ShowColon { get => _showColon; set { _showColon = value; Invalidate(); } }

        public Font Typeface { get => _textSize; set { _textSize = value; Invalidate(); } }

        public int AlphaValue { get => _value; set { _value = value; Invalidate(); } }

        public string ExtraText { get => _extraText; set { _extraText = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonAlphaValueLabel()
        {
            Typeface = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold);

            AlphaValue = 0;

            ExtraText = "Alpha Value";

            ShowColon = false;
        }
        #endregion

        #region Methods
        private void ShowCurrentColourValueOnLabel(bool value, string text = "Alpha Value", bool showColon = false)
        {
            if (value)
            {
                Text = $"{ text }: { AlphaValue }";
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
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            string tmpText = Text;

            ShowCurrentColourValueOnLabel(_showCurrentColourValue, _extraText, _showColon);

            AlterLabelTypeface(_textSize);

            if (ShowColon)
            {
                if (!tmpText.EndsWith(":"))
                {
                    Text = tmpText + ":";
                }
            }
            else
            {

            }

            base.OnPaint(e);
        }
        #endregion
    }
}
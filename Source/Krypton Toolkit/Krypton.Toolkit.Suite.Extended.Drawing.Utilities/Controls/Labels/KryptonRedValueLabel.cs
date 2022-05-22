#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
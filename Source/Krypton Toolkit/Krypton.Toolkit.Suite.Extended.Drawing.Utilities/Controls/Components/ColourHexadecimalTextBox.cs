#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using ExtendedMessageBoxButtons = Krypton.Toolkit.Suite.Extended.Messagebox.ExtendedMessageBoxButtons;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourHexadecimalTextBox : KryptonTextBox
    {
        private Color _colour;

        public Color Colour { get => _colour; set { _colour = value; Invalidate(); } }

        public ColourHexadecimalTextBox()
        {
            MaxLength = 6;

            CueHint.CueHintText = "000000";

            StateCommon.Content.TextH = PaletteRelativeAlign.Center;

            Text = string.Empty;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Colour != Color.Empty || Colour != Color.Transparent || Colour != null)
            {
                Text = ColorTranslator.ToHtml(Colour);
            }

            if (Colour == Color.Empty || Colour == Color.Transparent)
            {
                Text = "000000";
            }

            base.OnPaint(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            char[] allowedCharacters = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'a', 'b', 'c', 'd', 'e', 'f' };

            foreach (char character in Text.ToUpper().ToArray())
            {
                if (!allowedCharacters.Contains(character))
                {
                    KryptonMessageBoxExtended.Show($"'{character}' is not a hexadecimal character", "Illegal Character",
                        ExtendedMessageBoxButtons.OK, ExtendedKryptonMessageBoxIcon.INFORMATION, null);

                    e.Cancel = true;
                }
            }

            base.OnValidating(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {


            base.OnKeyDown(e);
        }
    }
}
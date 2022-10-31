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
                        ExtendedMessageBoxButtons.OK, Messagebox.ExtendedKryptonMessageBoxIcon.Information, null);

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
namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourHexadecimalTextBox : KryptonTextBox
    {
        private Color _colour;

        public Color Colour { get => _colour; set { _colour = value; Invalidate(); } }

        public ColourHexadecimalTextBox()
        {
            Validating += ColourHexadecimalTextBox_Validating;

            //TextChanged += ColourHexadecimalTextBox_TextChanged;

            MaxLength = 6;

            Hint = "000000";

            StateCommon.Content.TextH = PaletteRelativeAlign.Center;

            Text = string.Empty;
        }

        //private void ColourHexadecimalTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    ColorConverter converter = new ColorConverter();

        //    if (Text.Length == 4 || Text.Length == 6 || Text.Length > 6) Colour = (Color)converter.ConvertFromString(Text);
        //}

        private void ColourHexadecimalTextBox_Validating(object sender, CancelEventArgs e)
        {
            char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            foreach (char character in Text.ToUpper().ToArray())
            {
                if (!allowedChars.Contains(character))
                {
                    KryptonMessageBoxExtendedManager manager = new KryptonMessageBoxExtendedManager()
                    {
                        MessageBoxCaption = "Illegal Character",
                        MessageBoxContentText = $"'{ character }' is not a hexadecimal character",
                        MessageBoxButtons = ExtendedMessageBoxButtons.OK,
                        MessageBoxIcon = ExtendedKryptonMessageBoxIcon.INFORMATION
                    };

                    manager.DisplayKryptonMessageBox();

                    e.Cancel = true;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Colour != Color.Empty || Colour != Color.Transparent || Colour != null) Text = ColorTranslator.ToHtml(Colour);

            //if (Text == null || Text == string.Empty) Colour = Color.Empty;

            base.OnPaint(e);
        }
    }
}
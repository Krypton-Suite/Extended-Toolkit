namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourHexadecimalValuesEventArgs : EventArgs
    {
        #region Variables
        private Color _colour;

        private string _colourHexadecimalValue;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set => _colour = value; }

        public string ColourHexadecimalValue { get => _colourHexadecimalValue; set => _colourHexadecimalValue = value; }
        #endregion

        #region Constructors
        public ColourHexadecimalValuesEventArgs(Color colour)
        {
            Colour = colour;
        }

        public ColourHexadecimalValuesEventArgs(string colourHexadecimalValue)
        {
            ColourHexadecimalValue = colourHexadecimalValue;
        }
        #endregion

        #region Methods
        public string TranslateColourToHexadecimal(Color colour) => ColorTranslator.ToHtml(colour);

        public Color TranslateHexadecimalToColour(string hexadecimalValue)
        {
            Color result;

            try
            {
                if (!hexadecimalValue.StartsWith("#"))
                {
                    string tempString = $"#{ hexadecimalValue }";

                    return ColorTranslator.FromHtml(tempString);
                }
                else
                {
                    return ColorTranslator.FromHtml(hexadecimalValue);
                }
            }
            catch (Exception e)
            {
                return Color.Empty;
            }

            return Color.Empty;
        }
        #endregion
    }
}
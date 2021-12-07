namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class TextLabel
    {
        #region Fields

        private Color _colour, _borderColour, _backgroundColour;

        private bool _bold, _visable;

        private float _fontSize;

        private Graphics _graphics;

        private string _text, _fontName;

        #endregion

        #region Properties

        public string FontName
        {
            get => _fontName;

            set => Fonts.GetValidFontName(value);
        }

        public Font Font
        {
            get
            {
                FontFamily family = new FontFamily(_fontName);

                FontStyle style = (_bold) ? FontStyle.Bold : FontStyle.Regular;

                Font font = new Font(family, _fontSize, style, GraphicsUnit.Pixel);

                return font;
            }
        }

        public SizeF Size => GDI.MeasureString(_graphics, _text, Font);

        public float Width => Size.Width;

        public float Height => Size.Height;

        #endregion

        #region Constructor

        public TextLabel(Graphics graphics = null)
        {
            _text = "";

            _visable = true;

            _fontSize = 12;

            _bold = false;

            _graphics = graphics ?? Graphics.FromImage(new Bitmap(1, 1));

            _colour = Color.Black;

            _backgroundColour = Color.Magenta;

            _borderColour = Color.Black;

            _fontName = Fonts.GetDefaultFontName();
        }

        #endregion
    }
}
namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class TextLabel
    {
        #region Fields

        private Color _colour, _borderColour, _backgroundColour;

        private bool _bold, _visible;

        private float _fontSize;

        private Graphics _graphics;

        private string _text, _fontName;

        #endregion

        #region Properties

        public Color Colour
        {
            get => _colour;

            set => _colour = value;
        }

        public bool Visible
        {
            get => _visible;

            set => _visible = value;
        }

        public Color BorderColour
        {
            get => _borderColour;

            set => _borderColour = value;
        }

        public Color BackgroundColour
        {
            get => _backgroundColour;

            set => _backgroundColour = value;
        }

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

        public string Text
        {
            get => _text;

            set => _text = value;
        }

        public float FontSize
        {
            get => _fontSize;

            set => _fontSize = value;
        }

        public bool Bold
        {
            get => _bold;

            set => _bold = value;
        }

        #endregion

        #region Constructor

        public TextLabel(Graphics graphics = null)
        {
            _text = "";

            _visible = true;

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
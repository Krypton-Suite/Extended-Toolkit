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

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// Contains information about something's bounds and text to draw on the calendar
    /// </summary>
    public class CalendarRendererBoxEventArgs : CalendarRendererEventArgs
    {
        #region Fields
        private Color _backgroundColour;
        private Rectangle _bounds;
        private Font _font;
        private TextFormatFlags _format;
        private string _text;
        private Color _textColour;
        private Size _textSize;
        #endregion

        #region Ctor

        /// <summary>
        /// Initializes some fields
        /// </summary>
        private CalendarRendererBoxEventArgs()
        {

        }

        public CalendarRendererBoxEventArgs(CalendarRendererEventArgs original)
            : base(original)
        {
            Font = original.Calendar.Font;
            Format |= TextFormatFlags.Default | TextFormatFlags.WordBreak | TextFormatFlags.PreserveGraphicsClipping;// | TextFormatFlags.WordEllipsis;
            TextColour = SystemColors.ControlText;
        }

        public CalendarRendererBoxEventArgs(CalendarRendererEventArgs original, Rectangle bounds)
            : this(original)
        {
            Bounds = bounds;
        }

        public CalendarRendererBoxEventArgs(CalendarRendererEventArgs original, Rectangle bounds, string text)
            : this(original)
        {
            Bounds = bounds;
            Text = text;
        }

        public CalendarRendererBoxEventArgs(CalendarRendererEventArgs original, Rectangle bounds, string text, TextFormatFlags flags)
            : this(original)
        {
            Bounds = bounds;
            Text = text;
            Format |= flags;
        }

        public CalendarRendererBoxEventArgs(CalendarRendererEventArgs original, Rectangle bounds, string text, Color textColour)
            : this(original)
        {
            Bounds = bounds;
            Text = text;
            TextColour = textColour;
        }

        public CalendarRendererBoxEventArgs(CalendarRendererEventArgs original, Rectangle bounds, string text, Color textColour, TextFormatFlags flags)
            : this(original)
        {
            Bounds = bounds;
            Text = text;
            TextColour = TextColour;
            Format |= flags;
        }

        public CalendarRendererBoxEventArgs(CalendarRendererEventArgs original, Rectangle bounds, string text, Color textColour, Color backgroundColour)
            : this(original)
        {
            Bounds = bounds;
            Text = text;
            TextColour = TextColour;
            BackgroundColour = backgroundColour;
        }


        #endregion

        #region Props

        /// <summary>
        /// Gets or sets the background color of the text
        /// </summary>
        public Color BackgroundColour
        {
            get => _backgroundColour;
            set => _backgroundColour = value;
        }

        /// <summary>
        /// Gets or sets the bounds to draw the text
        /// </summary>
        public Rectangle Bounds
        {
            get => _bounds;
            set => _bounds = value;
        }

        /// <summary>
        /// Gets or sets the font of the text to be rendered
        /// </summary>
        public Font Font
        {
            get => _font;
            set { _font = value; _textSize = Size.Empty; }
        }

        /// <summary>
        /// Gets or sets the format to draw the text
        /// </summary>
        public TextFormatFlags Format
        {
            get => _format;
            set { _format = value; _textSize = Size.Empty; }
        }

        /// <summary>
        /// Gets or sets the text to draw
        /// </summary>
        public string Text
        {
            get => _text;
            set { _text = value; _textSize = Size.Empty; }
        }

        /// <summary>
        /// Gets the result of measuring the text
        /// </summary>
        public Size TextSize
        {
            get
            {
                if (_textSize.IsEmpty)
                {
                    _textSize = TextRenderer.MeasureText(Text, Font);
                }
                return _textSize;
            }
        }


        /// <summary>
        /// Gets or sets the color to draw the text
        /// </summary>
        public Color TextColour
        {
            get => _textColour;
            set => _textColour = value;
        }



        #endregion

        #region Methods

        #endregion
    }
}
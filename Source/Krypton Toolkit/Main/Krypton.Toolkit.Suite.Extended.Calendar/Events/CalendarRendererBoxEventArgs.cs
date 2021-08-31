#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;
using System.Windows.Forms;

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
            get { return _backgroundColour; }
            set { _backgroundColour = value; }
        }

        /// <summary>
        /// Gets or sets the bounds to draw the text
        /// </summary>
        public Rectangle Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

        /// <summary>
        /// Gets or sets the font of the text to be rendered
        /// </summary>
        public Font Font
        {
            get { return _font; }
            set { _font = value; _textSize = Size.Empty; }
        }

        /// <summary>
        /// Gets or sets the format to draw the text
        /// </summary>
        public TextFormatFlags Format
        {
            get { return _format; }
            set { _format = value; _textSize = Size.Empty; }
        }

        /// <summary>
        /// Gets or sets the text to draw
        /// </summary>
        public string Text
        {
            get { return _text; }
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
            get { return _textColour; }
            set { _textColour = value; }
        }



        #endregion

        #region Methods

        #endregion
    }
}
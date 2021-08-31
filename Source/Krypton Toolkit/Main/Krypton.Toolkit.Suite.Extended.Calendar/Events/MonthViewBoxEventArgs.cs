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
    /// Holds data about a box of text to be rendered on the month view
    /// </summary>
    public class MonthViewBoxEventArgs
    {
        #region Fields
        private Graphics _graphics;
        private Color _textColor;
        private Color _backgroundColor;
        private string _text;
        private Color _borderColor;
        private Rectangle _bounds;
        private Font _font;
        private TextFormatFlags _TextFlags;
        #endregion

        #region Ctor

        internal MonthViewBoxEventArgs(Graphics g, Rectangle bounds, string text, StringAlignment textAlign, Color textColor, Color backColor, Color borderColor)
        {
            _graphics = g;
            _bounds = bounds;
            Text = text;
            TextColour = textColor;
            BackgroundColour = backColor;
            BorderColour = borderColor;

            switch (textAlign)
            {
                case StringAlignment.Center:
                    TextFlags |= TextFormatFlags.HorizontalCenter;
                    break;
                case StringAlignment.Far:
                    TextFlags |= TextFormatFlags.Right;
                    break;
                case StringAlignment.Near:
                    TextFlags |= TextFormatFlags.Left;
                    break;
                default:
                    break;
            }

            TextFlags |= TextFormatFlags.VerticalCenter;
        }

        internal MonthViewBoxEventArgs(Graphics g, Rectangle bounds, string text, Color textColor)
            : this(g, bounds, text, StringAlignment.Center, textColor, Color.Empty, Color.Empty)
        { }

        internal MonthViewBoxEventArgs(Graphics g, Rectangle bounds, string text, Color textColor, Color backColor)
            : this(g, bounds, text, StringAlignment.Center, textColor, backColor, Color.Empty)
        { }

        internal MonthViewBoxEventArgs(Graphics g, Rectangle bounds, string text, StringAlignment textAlign, Color textColor, Color backColor)
            : this(g, bounds, text, textAlign, textColor, backColor, Color.Empty)
        { }

        internal MonthViewBoxEventArgs(Graphics g, Rectangle bounds, string text, StringAlignment textAlign, Color textColor)
            : this(g, bounds, text, textAlign, textColor, Color.Empty, Color.Empty)
        { }

        #endregion

        #region Props

        /// <summary>
        /// Gets or sets the bounds of the box
        /// </summary>
        public Rectangle Bounds
        {
            get { return _bounds; }
        }

        /// <summary>
        /// Gets or sets the font of the text. If null, default will be used.
        /// </summary>
        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        /// <summary>
        /// Gets or sets the Graphics object where to draw
        /// </summary>
        public Graphics Graphics
        {
            get { return _graphics; }
        }

        /// <summary>
        /// Gets or sets the border color of the box
        /// </summary>
        public Color BorderColour
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        /// <summary>
        /// Gets or sets the text of the box
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// Gets or sets the background color of the box
        /// </summary>
        public Color BackgroundColour
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        /// <summary>
        /// Gets or sets the text color of the box
        /// </summary>
        public Color TextColour
        {
            get { return _textColor; }
            set { _textColor = value; }
        }

        /// <summary>
        /// Gets or sets the flags of the text
        /// </summary>
        public TextFormatFlags TextFlags
        {
            get { return _TextFlags; }
            set { _TextFlags = value; }
        }


        #endregion
    }
}
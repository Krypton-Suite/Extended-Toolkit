#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>
    /// A control that acts like an LED display
    /// </summary>
    [ToolboxItem(false), EditorBrowsable(EditorBrowsableState.Advanced)]
    public class HostLEDControl : Control, ISupportInitialize
    {
        #region Nested Types
        /// <summary>
        /// Specify how the text or value is aligned.
        /// </summary>
        public enum Alignment
        {
            /// <summary>
            /// The text or value will align on the left side of the control.
            /// </summary>
            Left = 0,
            /// <summary>
            /// The text or value will align on the right side of the control.
            /// </summary>
            Right = 1
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Construct one HostLEDControl instance.
        /// </summary>
        public HostLEDControl()
        {
            // double buffered
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            // support transplant background
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            // default color
            ForeColor = Color.LightGreen;
            BackColor = Color.Transparent;
            // event handler
            Click += new EventHandler(EvClick);
            KeyDown += new KeyEventHandler(EvKeyDown);
            GotFocus += new EventHandler(EvFocus);
            LostFocus += new EventHandler(EvFocus);
        }

        /// <summary>
        /// Destructor
        /// </summary>
        /// <param name="disposing">whether this method is called by Dispose()</param>
        protected override void Dispose(bool disposing)
        {
            DestoryCache();
            base.Dispose(disposing);
        }
        #endregion

        #region Helper Function
        /// <summary>
        /// Paint one segment.
        /// </summary>
        /// <param name="g">The graphics object which will be painted on.</param>
        /// <param name="rectBound">The paint rectangle.</param>
        /// <param name="colSegment">segment color.</param>
        /// <param name="nIndex">the segment index.</param>
        /// <param name="bevelRate">corner rate.</param>
        /// <param name="segmentWidth">segment width.</param>
        /// <param name="segmentInterval">segment interval.</param>
        private void DrawSegment(Graphics g, Rectangle rectBound, Color colSegment, int nIndex,
            float bevelRate, float segmentWidth, float segmentInterval)
        {
            GraphicsPath segmentPath = null;
            SolidBrush segmentBrush = null;
            Matrix offsetMatrix = null;
            if (!m_bIsCacheBuild)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("Rebuilding cache...");
#endif
                DestoryCache();
                CreateCache(rectBound, bevelRate, segmentWidth, segmentInterval);
            }
            segmentPath = (GraphicsPath)(m_CachedPaths[nIndex - 1].Clone());
            // offset path to desired position
            offsetMatrix = new Matrix();
            offsetMatrix.Translate((float)rectBound.X, (float)rectBound.Y);
            segmentPath.Transform(offsetMatrix);
            // clip drawing(optimize drawing)
            segmentBrush = new SolidBrush(colSegment);
            g.Clip = new Region(ClientRectangle);
            g.FillPath(segmentBrush, segmentPath);
            // clear resources
            segmentBrush.Dispose();
            offsetMatrix.Dispose();
            segmentPath.Dispose();
        }
        /// <summary>
        /// Paint one character.
        /// </summary>
        /// <param name="g">The graphics object which will be painted on.</param>
        /// <param name="rectBound">The paint rectangle.</param>
        /// <param name="colCharacter">Character color.</param>
        /// <param name="character">The character to paint.</param>
        /// <param name="bevelRate">The bevel rate.</param>
        /// <param name="segmentWidth">segment width.</param>
        /// <param name="segmentInterval">segment interval.</param>
        private void DrawSingleChar(Graphics g, Rectangle rectBound, Color colCharacter, char character,
            float bevelRate, float segmentWidth, float segmentInterval)
        {
            switch (character)
            {
                case '0':
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '1':
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '2':
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '3':
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '4':
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '5':
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '6':
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '7':
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '8':
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '9':
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '-':
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '.':
                    DrawSegment(g, rectBound, colCharacter, 8, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '_':
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '(':
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case ')':
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'E':
                    // Relative frequency of 'E' in English spellings is 0.1268
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'T':
                    // Relative frequency of 'T' in English spellings is 0.0978
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'A':
                    // Relative frequency of 'A' in English spellings is 0.0788
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'O':
                    // Relative frequency of 'O' in English spellings is 0.0766
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'I':
                    // Relative frequency of 'I' in English spellings is 0.0707
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'N':
                    // Relative frequency of 'I' in English spellings is 0.0706
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'S':
                    // Relative frequency of 'S' in English spellings is 0.0634
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'R':
                    // Relative frequency of 'R' in English spellings is 0.0594
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'H':
                    // Relative frequency of 'H' in English spellings is 0.0573
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'L':
                    // Relative frequency of 'L' in English spellings is 0.0394
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'D':
                    // Relative frequency of 'L' in English spellings is 0.0389
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'U':
                    // Relative frequency of 'U' in English spellings is 0.0280
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'C':
                    // Relative frequency of 'C' in English spellings is 0.0268
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'F':
                    // Relative frequency of 'F' in English spellings is 0.0256
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'Y':
                    // Relative frequency of 'Y' in English spellings is 0.0202
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'G':
                    // Relative frequency of 'G' in English spellings is 0.0187
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'P':
                    // Relative frequency of 'P' in English spellings is 0.0186
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'B':
                    // Relative frequency of 'B' in English spellings is 0.0156
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'V':
                    // Relative frequency of 'B' in English spellings is 0.0102
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'J':
                    // Relative frequency of 'J' in English spellings is 0.0010
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'Z':
                    // Relative frequency of 'Z' in English spellings is 0.0006
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Paint one character with faded background
        /// </summary>
        /// <param name="g">The graphics object which will be painted on</param>
        /// <param name="rectBound">The paint rectangle</param>
        /// <param name="colCharacter">Character color</param>
        /// <param name="colFaded">Faded background color</param>
        /// <param name="character">Character to paint</param>
        /// <param name="bevelRate">bevel rate</param>
        /// <param name="segmentWidth">width of the segment</param>
        /// <param name="segmentInterval">Interval of the segment</param>
        private void DrawSingleCharWithFadedBk(Graphics g, Rectangle rectBound, Color colCharacter,
            Color colFaded, char character, float bevelRate, float segmentWidth, float segmentInterval)
        {
            switch (character)
            {
                case '0':
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '1':
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '2':
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '3':
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '4':
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '5':
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '6':
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '7':
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '8':
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '9':
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '-':
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '.':
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 8, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '_':
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case '(':
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case ')':
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'E':
                    // Relative frequency of 'E' in English spellings is 0.1268
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'T':
                    // Relative frequency of 'T' in English spellings is 0.0978
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'A':
                    // Relative frequency of 'A' in English spellings is 0.0788
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'O':
                    // Relative frequency of 'O' in English spellings is 0.0766
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'I':
                    // Relative frequency of 'I' in English spellings is 0.0707
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'N':
                    // Relative frequency of 'N' in English spellings is 0.0706
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'S':
                    // Relative frequency of 'S' in English spellings is 0.0634
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'R':
                    // Relative frequency of 'R' in English spellings is 0.0594
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'H':
                    // Relative frequency of 'H' in English spellings is 0.0573
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'L':
                    // Relative frequency of 'L' in English spellings is 0.0394
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'D':
                    // Relative frequency of 'D' in English spellings is 0.0389
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'U':
                    // Relative frequency of 'U' in English spellings is 0.0280
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'C':
                    // Relative frequency of 'C' in English spellings is 0.0268
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'F':
                    // Relative frequency of 'F' in English spellings is 0.0256
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'Y':
                    // Relative frequency of 'Y' in English spellings is 0.0202
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'G':
                    // Relative frequency of 'G' in English spellings is 0.0187
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'P':
                    // Relative frequency of 'P' in English spellings is 0.0186
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'B':
                    // Relative frequency of 'B' in English spellings is 0.0156
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'V':
                    // Relative frequency of 'B' in English spellings is 0.0102
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 6, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'J':
                    // Relative frequency of 'J' in English spellings is 0.0010
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                case 'Z':
                    // Relative frequency of 'Z' in English spellings is 0.0006
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 7, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colCharacter, 4, bevelRate, segmentWidth, segmentInterval);
                    break;
                default:
                    DrawSegment(g, rectBound, colFaded, 1, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 2, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 3, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 4, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 5, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 6, bevelRate, segmentWidth, segmentInterval);
                    DrawSegment(g, rectBound, colFaded, 7, bevelRate, segmentWidth, segmentInterval);
                    break;
            }
        }
        /// <summary>
        /// Destory cache
        /// </summary>
        private void DestoryCache()
        {
            for (int i = 0; i < 8; ++i)
            {
                if (m_CachedPaths[i] != null)
                {
                    m_CachedPaths[i].Dispose();
                    m_CachedPaths[i] = null;
                }
            }
        }
        /// <summary>
        /// Create cache
        /// </summary>
        /// <param name="rectBound">The bound rectangle</param>
        /// <param name="bevelRate">Bevel rate</param>
        /// <param name="segmentWidth">Width of the segment</param>
        /// <param name="segmentInterval">Interval between segments</param>
        private void CreateCache(Rectangle rectBound, float bevelRate, float segmentWidth, float segmentInterval)
        {
            Matrix mx = new Matrix(1, 0, 0, 1, 0, 0);
            mx.Shear(-0.1f, 0);
            PointF[] pathPointCollection = new PointF[6];
            PointF[] pathDotCollection = new PointF[4];
            for (int i = 0; i < 8; ++i)
            {
                if (m_CachedPaths[i] == null)
                    m_CachedPaths[i] = new GraphicsPath();
            }
            // top '-'
            pathPointCollection[0].X = segmentWidth * bevelRate + segmentInterval;
            pathPointCollection[0].Y = segmentWidth * bevelRate;
            pathPointCollection[1].X = segmentInterval + segmentWidth * bevelRate * 2;
            pathPointCollection[1].Y = 0;
            pathPointCollection[2].X = rectBound.Width - segmentInterval - segmentWidth * bevelRate * 2;
            pathPointCollection[2].Y = 0;
            pathPointCollection[3].X = rectBound.Width - segmentInterval - segmentWidth * bevelRate;
            pathPointCollection[3].Y = segmentWidth * bevelRate;
            pathPointCollection[4].X = rectBound.Width - segmentInterval - segmentWidth;
            pathPointCollection[4].Y = segmentWidth;
            pathPointCollection[5].X = segmentWidth + segmentInterval;
            pathPointCollection[5].Y = segmentWidth;
            m_CachedPaths[0].AddPolygon(pathPointCollection);
            m_CachedPaths[0].CloseFigure();
            if (UseItalicStyle) m_CachedPaths[0].Transform(mx);

            // upper right '|'
            pathPointCollection[0].X = rectBound.Width - segmentWidth;
            pathPointCollection[0].Y = segmentWidth + segmentInterval;
            pathPointCollection[1].X = rectBound.Width - segmentWidth * bevelRate;
            pathPointCollection[1].Y = segmentWidth * bevelRate + segmentInterval;
            pathPointCollection[2].X = rectBound.Width + 1;
            pathPointCollection[2].Y = segmentWidth * bevelRate * 2 + segmentInterval + 1;
            pathPointCollection[3].X = rectBound.Width + 1;
            pathPointCollection[3].Y = (rectBound.Height >> 1) - segmentWidth * 0.5f - segmentInterval - 1;
            pathPointCollection[4].X = rectBound.Width - segmentWidth * 0.5f;
            pathPointCollection[4].Y = (rectBound.Height >> 1) - segmentInterval;
            pathPointCollection[5].X = rectBound.Width - segmentWidth;
            pathPointCollection[5].Y = (rectBound.Height >> 1) - segmentWidth * 0.5f - segmentInterval;
            m_CachedPaths[1].AddPolygon(pathPointCollection);
            m_CachedPaths[1].CloseFigure();
            if (UseItalicStyle) m_CachedPaths[1].Transform(mx);

            // bottom right '|'
            pathPointCollection[0].X = rectBound.Width - segmentWidth;
            pathPointCollection[0].Y = (rectBound.Height >> 1) + segmentInterval + segmentWidth * 0.5f;
            pathPointCollection[1].X = rectBound.Width - segmentWidth * 0.5f;
            pathPointCollection[1].Y = (rectBound.Height >> 1) + segmentInterval;
            pathPointCollection[2].X = rectBound.Width + 1;
            pathPointCollection[2].Y = (rectBound.Height >> 1) + segmentInterval + segmentWidth * 0.5f + 1;
            pathPointCollection[3].X = rectBound.Width + 1;
            pathPointCollection[3].Y = rectBound.Height - segmentInterval - segmentWidth * bevelRate * 2 - 1;
            pathPointCollection[4].X = rectBound.Width - segmentWidth * bevelRate;
            pathPointCollection[4].Y = rectBound.Height - segmentWidth * bevelRate - segmentInterval;
            pathPointCollection[5].X = rectBound.Width - segmentWidth;
            pathPointCollection[5].Y = rectBound.Height - segmentWidth - segmentInterval;
            m_CachedPaths[2].AddPolygon(pathPointCollection);
            m_CachedPaths[2].CloseFigure();
            if (UseItalicStyle) m_CachedPaths[2].Transform(mx);

            // bottom '-'
            pathPointCollection[0].X = segmentWidth * bevelRate + segmentInterval;
            pathPointCollection[0].Y = rectBound.Height - segmentWidth * bevelRate;
            pathPointCollection[1].X = segmentWidth + segmentInterval;
            pathPointCollection[1].Y = rectBound.Height - segmentWidth;
            pathPointCollection[2].X = rectBound.Width - segmentInterval - segmentWidth;
            pathPointCollection[2].Y = rectBound.Height - segmentWidth;
            pathPointCollection[3].X = rectBound.Width - segmentInterval - segmentWidth * bevelRate;
            pathPointCollection[3].Y = rectBound.Height - segmentWidth * bevelRate;
            pathPointCollection[4].X = rectBound.Width - segmentInterval - segmentWidth * bevelRate * 2;
            pathPointCollection[4].Y = rectBound.Height;
            pathPointCollection[5].X = segmentWidth * bevelRate * 2 + segmentInterval;
            pathPointCollection[5].Y = rectBound.Height;
            m_CachedPaths[3].AddPolygon(pathPointCollection);
            m_CachedPaths[3].CloseFigure();
            if (UseItalicStyle) m_CachedPaths[3].Transform(mx);

            // bottom left '|'
            pathPointCollection[0].X = 0f;
            pathPointCollection[0].Y = (rectBound.Height >> 1) + segmentInterval + segmentWidth * 0.5f;
            pathPointCollection[1].X = segmentWidth * 0.5f;
            pathPointCollection[1].Y = (rectBound.Height >> 1) + segmentInterval;
            pathPointCollection[2].X = segmentWidth;
            pathPointCollection[2].Y = (rectBound.Height >> 1) + segmentInterval + segmentWidth * 0.5f;
            pathPointCollection[3].X = segmentWidth;
            pathPointCollection[3].Y = rectBound.Height - segmentWidth - segmentInterval;
            pathPointCollection[4].X = segmentWidth * bevelRate;
            pathPointCollection[4].Y = rectBound.Height - segmentWidth * bevelRate - segmentInterval;
            pathPointCollection[5].X = 0f;
            pathPointCollection[5].Y = rectBound.Height - segmentInterval - segmentWidth * bevelRate * 2;
            m_CachedPaths[4].AddPolygon(pathPointCollection);
            m_CachedPaths[4].CloseFigure();
            if (UseItalicStyle) m_CachedPaths[4].Transform(mx);

            // upper left '|'
            pathPointCollection[0].X = 0f;
            pathPointCollection[0].Y = segmentWidth * bevelRate * 2 + segmentInterval;
            pathPointCollection[1].X = segmentWidth * bevelRate;
            pathPointCollection[1].Y = segmentWidth * bevelRate + segmentInterval;
            pathPointCollection[2].X = segmentWidth;
            pathPointCollection[2].Y = segmentWidth + segmentInterval;
            pathPointCollection[3].X = segmentWidth;
            pathPointCollection[3].Y = (rectBound.Height >> 1) - segmentWidth * 0.5f - segmentInterval;
            pathPointCollection[4].X = segmentWidth * 0.5f;
            pathPointCollection[4].Y = (rectBound.Height >> 1) - segmentInterval;
            pathPointCollection[5].X = 0f;
            pathPointCollection[5].Y = (rectBound.Height >> 1) - segmentWidth * 0.5f - segmentInterval;
            m_CachedPaths[5].AddPolygon(pathPointCollection);
            m_CachedPaths[5].CloseFigure();
            if (UseItalicStyle) m_CachedPaths[5].Transform(mx);

            // draw med '-'
            pathPointCollection[0].X = (segmentWidth * 0.5f) + segmentInterval;
            pathPointCollection[0].Y = (rectBound.Height >> 1);
            pathPointCollection[1].X = segmentWidth + segmentInterval;
            pathPointCollection[1].Y = (rectBound.Height >> 1) - segmentWidth * 0.5f;
            pathPointCollection[2].X = rectBound.Width - segmentInterval - segmentWidth;
            pathPointCollection[2].Y = (rectBound.Height >> 1) - segmentWidth * 0.5f;
            pathPointCollection[3].X = rectBound.Width - segmentInterval - segmentWidth * 0.5f;
            pathPointCollection[3].Y = rectBound.Height >> 1;
            pathPointCollection[4].X = rectBound.Width - segmentInterval - segmentWidth;
            pathPointCollection[4].Y = (rectBound.Height >> 1) + segmentWidth * 0.5f;
            pathPointCollection[5].X = segmentWidth + segmentInterval;
            pathPointCollection[5].Y = (rectBound.Height >> 1) + segmentWidth * 0.5f;
            m_CachedPaths[6].AddPolygon(pathPointCollection);
            m_CachedPaths[6].CloseFigure();
            if (UseItalicStyle) m_CachedPaths[6].Transform(mx);

            // draw dot
            pathDotCollection[0].X = 0f;
            pathDotCollection[0].Y = rectBound.Height;
            pathDotCollection[1].X = segmentWidth;
            pathDotCollection[1].Y = rectBound.Height;
            pathDotCollection[2].X = segmentWidth;
            pathDotCollection[2].Y = rectBound.Height - segmentWidth;
            pathDotCollection[3].X = 0;
            pathDotCollection[3].Y = rectBound.Height - segmentWidth;
            m_CachedPaths[7].AddPolygon(pathDotCollection);
            m_CachedPaths[7].CloseFigure();
            if (UseItalicStyle) m_CachedPaths[7].Transform(mx);
            // ok change state
            m_bIsCacheBuild = true;
        }
        /// <summary>
        /// Draw character(s).
        /// </summary>
        private void DrawChars(Graphics g, float segmentWidth, float segmentInterval)
        {
            Rectangle clientRect = ClientRectangle;
            Rectangle subRect = new Rectangle();
            int subRectWidth = (int)(clientRect.Height * WIDTHHEIGHTRATIO);
            int subRectHeight = clientRect.Height;
            int totalElements = m_nCharacterNumber;
            int charIntervals = segmentInterval > 0.5 ? (int)(segmentInterval * 2) : 1;
            // for right alignemnt only
            int beginIndex_right = 0;
            if (m_enumAlign == Alignment.Right)
            {
                if (Text.Length >= totalElements)
                    beginIndex_right = 0;
                else
                    beginIndex_right = totalElements - Text.Length;
            }
            for (int i = 0; i < totalElements; ++i)
            {
                // draw faded led(s)
                subRect.Width = subRectWidth;
                subRect.Height = subRectHeight;
                subRect.X = (int)(i * subRect.Width + 5);
                subRect.Y = 0;
                subRect.Inflate(-charIntervals, -charIntervals);
                // draw foreground led(s)
                if (m_enumAlign == Alignment.Left)
                {
                    if (i < Text.Length)
                    {
                        DrawSingleCharWithFadedBk(g, subRect, ForeColor, m_colFadedColour, Text[i],
                            m_fBevelRate, segmentWidth, segmentInterval);
                    }
                    else
                    {
                        DrawSingleChar(g, subRect, m_colFadedColour, '8', m_fBevelRate, segmentWidth,
                                segmentInterval);
                    }
                }
                else
                {
                    if (i >= beginIndex_right)
                    {
                        DrawSingleCharWithFadedBk(g, subRect, ForeColor, m_colFadedColour, Text[i - beginIndex_right],
                            m_fBevelRate, segmentWidth, segmentInterval);
                    }
                    else
                    {
                        DrawSingleChar(g, subRect, m_colFadedColour, '8', m_fBevelRate, segmentWidth,
                                segmentInterval);
                    }
                }
            }
        }
        /// <summary>
        /// Calculate the width of the segment and the interval between segments.
        /// </summary>
        /// <param name="segmentWidth">[out] the width of the segment.</param>
        /// <param name="segmentInterval">[out] the interval between segments.</param>
        private void CalculateDrawingParams(out float segmentWidth, out float segmentInterval)
        {
            float subRectWidth = ClientRectangle.Height * WIDTHHEIGHTRATIO;
            segmentWidth = subRectWidth * m_fWidthSegWidthRatio;
            segmentInterval = subRectWidth * m_fWidthIntervalRatio;
        }
        /// <summary>
        /// Draw a round rectangle at the specified position
        /// </summary>
        /// <param name="g">Graphics object</param>
        /// <param name="rect">The bound rectangle</param>
        /// <param name="radius">The radius of the round corner in pixels</param>
        /// <param name="col1">The first color</param>
        /// <param name="col2">The second color(ignored if no gradient is used)</param>
        /// <param name="bGradient">Whether to use gradient color</param>
        /// <param name="colBorder">The color of the border</param>
        /// <param name="nBorderWidth">The width of the border</param>
        /// <param name="bDrawBorder">Whether to draw the border</param>
        private void DrawRoundRect(Graphics g, Rectangle rect, float radius, Color col1,
            Color col2, Color colBorder, int nBorderWidth, bool bGradient, bool bDrawBorder)
        {
            GraphicsPath roundRect = new GraphicsPath();
            float diameter = radius + radius;
            RectangleF arcRect = new RectangleF(0, 0, diameter, diameter);
            Brush br = null;
            // create round rect
            arcRect.X = rect.Left;
            arcRect.Y = rect.Top;
            roundRect.AddArc(arcRect, 180, 90);
            arcRect.X = rect.Right - 1 - diameter;
            roundRect.AddArc(arcRect, 270, 90);
            arcRect.Y = rect.Bottom - 1 - diameter;
            roundRect.AddArc(arcRect, 0, 90);
            arcRect.X = rect.Left;
            roundRect.AddArc(arcRect, 90, 90);
            roundRect.CloseFigure();
            // paint
            if (bGradient)
            {
                br =
                    new LinearGradientBrush(
                    rect, col1, col2, 90, false);
            }
            else
            {
                br = new SolidBrush(col1);
            }
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillPath(br, roundRect);
            if (bDrawBorder)
            {
                Pen pen = new Pen(colBorder);
                pen.Width = nBorderWidth;
                g.DrawPath(pen, roundRect);
                pen.Dispose();
            }
            g.SmoothingMode = UseSmoothingMode ? SmoothingMode.AntiAlias : SmoothingMode.None;
            // release resource
            br.Dispose();
            roundRect.Dispose();
        }
        /// <summary>
        /// Draw a normal rectangle
        /// </summary>
        /// <param name="g">Graphcis object</param>
        /// <param name="rect">The bound rectangle</param>
        /// <param name="col1">The first color</param>
        /// <param name="col2">The second color(ignored if no gradient is used)</param>
        /// <param name="colBorder">The border color</param>
        /// <param name="nBorderWidth">The width of the border</param>
        /// <param name="bGradient">Whether to use gradient color</param>
        /// <param name="bDrawBorder">Whether to draw border</param>
        private void DrawNormalRect(Graphics g, Rectangle rect, Color col1, Color col2,
            Color colBorder, int nBorderWidth, bool bGradient, bool bDrawBorder)
        {
            Brush br = null;
            if (bGradient)
            {
                br = new LinearGradientBrush(rect, col1, col2, 90);
                g.FillRectangle(br, rect);
            }
            else
            {
                br = new SolidBrush(col1);
                g.FillRectangle(br, rect);
            }
            if (bDrawBorder)
            {
                // Bug fixed: or the bottom line and right line are invisible.
                rect.Width -= 1;
                rect.Height -= 1;
                // Bug fixed: the border color will not changed when the control has focus.
                Pen pen = new Pen(colBorder);
                g.DrawRectangle(pen, rect);
                pen.Dispose();
            }
            br.Dispose();
        }
        /// <summary>
        /// Draw background of the control
        /// </summary>
        /// <param name="g">The graphics object</param>
        private void DrawBackground(Graphics g)
        {
            Rectangle rect = ClientRectangle;
            Color borderColor = Focused ? m_colFocusedBorderColour : m_colBorderColour;
            if (m_bRoundRect)
            {
                DrawRoundRect(g, rect, m_nCornerRadius, m_colCustomBk1, m_colCustomBk2,
                    borderColor, m_nBorderWidth, m_bGradientBackground, m_nBorderWidth != 0);
            }
            else
            {
                if (m_colCustomBk1 == Color.Transparent)
                    return;
                DrawNormalRect(g, rect, m_colCustomBk1, m_colCustomBk2,
                    borderColor, m_nBorderWidth, m_bGradientBackground, m_nBorderWidth != 0);
            }
        }
        /// <summary>
        /// Draw highlight of the control
        /// </summary>
        /// <param name="g">The graphics object</param>
        private void DrawHighlight(Graphics g)
        {
            if (m_bShowHighlight)
            {
                Rectangle topRect = ClientRectangle;
                topRect.Height = (topRect.Height >> 1);
                topRect.Inflate(-2, -2);
                Color col1 = Color.FromArgb(100, 255, 255, 255);
                Color col2 = Color.FromArgb(m_nHighlightOpaque, 255, 255, 255);
                DrawRoundRect(g, topRect,
                    m_nCornerRadius - 1 > 1 ? m_nCornerRadius - 1 : 1,
                    col1, col2, Color.Empty, 0, true, false);
            }
        }
        #endregion

        #region Override
        /// <summary>
        /// Paint the whole control.
        /// </summary>
        /// <param name="e">Painting parameter.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // needed params
            Graphics g = e.Graphics;
            g.SmoothingMode = UseSmoothingMode ? SmoothingMode.AntiAlias : SmoothingMode.None;
            float segmentWidth = 0;
            float segmentInterval = 0;
            if (ClientRectangle.Height >= 20 && ClientRectangle.Width >= 20)
            {
                DrawBackground(g);
                CalculateDrawingParams(out segmentWidth, out segmentInterval);
                DrawChars(g, segmentWidth, segmentInterval);
                DrawHighlight(g);
            }
        }
        /// <summary>
        /// Do nothing in paint background
        /// </summary>
        /// <param name="pevent">Painting parameter</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }
        /// <summary>
        /// On size changed
        /// </summary>
        /// <param name="e">Size change parameter</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            // need rebuild cache
            m_bIsCacheBuild = false;
            base.OnSizeChanged(e);
        }
        #endregion

        #region Constant(s)
        /// <summary>
        /// The ratio of the width to the height of one character.
        /// </summary>
        private const float WIDTHHEIGHTRATIO = 0.5f;
        #endregion

        #region Member Var(s)
        /// <summary>
        /// The cached path information
        /// </summary>
        private GraphicsPath[] m_CachedPaths = new GraphicsPath[8];
        /// <summary>
        /// Indicate whether the cached painting information is built.
        /// </summary>
        private bool m_bIsCacheBuild = false;
        /// <summary>
        /// Border width
        /// </summary>
        private int m_nBorderWidth = 1;
        /// <summary>
        /// Border color
        /// </summary>
        private Color m_colBorderColour = Color.Gray;
        /// <summary>
        /// Focused border color
        /// </summary>
        private Color m_colFocusedBorderColour = Color.Cyan;
        /// <summary>
        /// The radius of the round corner of the background rectangle
        /// </summary>
        private int m_nCornerRadius = 5;
        /// <summary>
        /// The total number of digits to display.
        /// </summary>
        private int m_nCharacterNumber = 5;
        /// <summary>
        /// The bevel rate of each segment.
        /// </summary>
        private float m_fBevelRate = 0.25f;
        /// <summary>
        /// The faded color.
        /// </summary>
        private Color m_colFadedColour = Color.DimGray;
        /// <summary>
        /// The custom background color
        /// </summary>
        private Color m_colCustomBk1 = Color.Black;
        /// <summary>
        /// The custom background color
        /// </summary>
        private Color m_colCustomBk2 = Color.DimGray;
        /// <summary>
        /// The ratio of the segment width to the width of one character.
        /// </summary>
        private float m_fWidthSegWidthRatio = 0.2f;
        /// <summary>
        /// The ratio of the segment interval to the width of one character.
        /// </summary>
        private float m_fWidthIntervalRatio = 0.05f;
        /// <summary>
        /// How the displaying text or value is aligned.
        /// </summary>
        private Alignment m_enumAlign = Alignment.Left;
        /// <summary>
        /// If the background was round rectangle
        /// </summary>
        private bool m_bRoundRect = false;
        /// <summary>
        /// If the background was filled in gradient colors
        /// </summary>
        private bool m_bGradientBackground = false;
        /// <summary>
        /// Whether to draw high light area
        /// </summary>
        private bool m_bShowHighlight = false;
        /// <summary>
        /// The opaque value of highlight, 0 is transparent, 255 is solid
        /// </summary>
        private byte m_nHighlightOpaque = 50;
        /// <summary>
        /// The smoothing mode.
        /// </summary>
        private bool m_smoothingMode = false;
        /// <summary>
        /// The italic text mode.
        /// </summary>
        private bool m_italicMode = false;
        #endregion

        #region Properties

        /// <summary>
        /// Get or set whether the italic text style is turned on.
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Turn on/off the italic text style."),
        DefaultValue(false)]
        public bool UseItalicStyle
        {
            get
            {
                return m_italicMode;
            }
            set
            {
                if (m_italicMode == value)
                    return;
                m_italicMode = value;
                // rebuild cache
                m_bIsCacheBuild = false;
                if (!m_bIsInitializing)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set whether the smoothing mode is turned on.
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Turn on/off the smoothing mode."),
        DefaultValue(false)]
        public bool UseSmoothingMode
        {
            get
            {
                return m_smoothingMode;
            }
            set
            {
                if (m_smoothingMode == value)
                    return;
                m_smoothingMode = value;
                if (!m_bIsInitializing)
                {
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the width of the border
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set the border style"),
        DefaultValue(1)]
        public int BorderWidth
        {
            get
            {
                return m_nBorderWidth;
            }
            set
            {
                if (m_nBorderWidth == value)
                    return;
                if (value >= 0 && value <= 5)
                {
                    m_nBorderWidth = value;
                    // avoid multiple invalidation
                    if (!m_bIsInitializing)
                    {
                        Invalidate();
                    }
                }
                else
                {
                    throw new ArgumentException("This value should be between 0 and 5");
                }
            }
        }
        /// <summary>
        /// Get or set the border color
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set the border color"),
        DefaultValue(typeof(Color), "Gray")]
        public Color BorderColour
        {
            get
            {
                return m_colBorderColour;
            }
            set
            {
                if (value == m_colBorderColour)
                    return;
                m_colBorderColour = value;
                if (!m_bIsInitializing)
                {
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Ger or set the border color when the control got focus.
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set the focused border color."),
        DefaultValue(typeof(Color), "Cyan")]
        public Color FocusedBorderColour
        {
            get
            {
                return m_colFocusedBorderColour;
            }
            set
            {
                if (value == m_colFocusedBorderColour)
                    return;
                m_colFocusedBorderColour = value;
                if (!m_bIsInitializing)
                {
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the opaque value of the highlight
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set the opaque value of the highlight"),
        DefaultValue(50)]
        public byte HighlightOpaque
        {
            get
            {
                return m_nHighlightOpaque;
            }
            set
            {
                if (value <= 100)
                {
                    if (m_nHighlightOpaque == value)
                        return;
                    m_nHighlightOpaque = value;
                    if (!m_bIsInitializing)
                    {
                        Invalidate();
                    }
                }
                else
                {
                    throw new ArgumentException("This value should be between 0 and 50");
                }
            }
        }
        /// <summary>
        /// Get or set whether to show highlight area on the control
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set whether to show highlight area on the control"),
        DefaultValue(false)]
        public bool ShowHighlight
        {
            get
            {
                return m_bShowHighlight;
            }
            set
            {
                if (m_bShowHighlight == value)
                    return;
                m_bShowHighlight = value;
                if (!m_bIsInitializing)
                {
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the corner radius for the background rectangle.
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set the corner radius for the background rectangle."),
        DefaultValue(5)]
        public int CornerRadius
        {
            get
            {
                return m_nCornerRadius;
            }
            set
            {
                if (value >= 1 && value <= 10)
                {
                    if (m_nCornerRadius == value)
                        return;
                    m_nCornerRadius = value;
                    if (m_bIsInitializing)
                    {
                        Invalidate();
                    }
                }
                else
                {
                    throw new ArgumentException("This value should be between 1 and 10");
                }
            }
        }
        /// <summary>
        /// Get or set if the background was filled in gradient colors
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set if the background was filled in gradient colors"),
        DefaultValue(false)]
        public bool GradientBackground
        {
            get
            {
                return m_bGradientBackground;
            }
            set
            {
                if (m_bGradientBackground == value)
                    return;
                m_bGradientBackground = value;
                if (!m_bIsInitializing)
                {
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the first custom background color
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set thr first custom background color"),
        DefaultValue(typeof(Color), "System.Drawing.Color.Black")]
        public Color BackColour_1
        {
            get
            {
                return m_colCustomBk1;
            }
            set
            {
                m_colCustomBk1 = value;
                if (!m_bIsInitializing)
                {
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the second custom background color
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set thr second custom background color"),
        DefaultValue(typeof(Color), "System.Drawing.Color.DimGray")]
        public Color BackColour_2
        {
            get
            {
                return m_colCustomBk2;
            }
            set
            {
                m_colCustomBk2 = value;
                if (!m_bIsInitializing)
                {
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the background bound style
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set the background bound style"),
        DefaultValue(false)]
        public bool RoundCorner
        {
            get
            {
                return m_bRoundRect;
            }
            set
            {
                if (m_bRoundRect == value)
                    return;
                m_bRoundRect = value;
                if (!m_bIsInitializing)
                {
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the segment interval ratio
        /// </summary>
        [Browsable(true),
        Category("Behavior"),
        Description("Set segment interval ratio"),
        DefaultValue(40)]
        public int SegmentIntervalRatio
        {
            get
            {
                return (int)((m_fWidthIntervalRatio - 0.01f) * 1000);
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    m_fWidthIntervalRatio = 0.01f + value * 0.001f;
                    if (!m_bIsInitializing)
                    {
                        // need rebuild cache
                        m_bIsCacheBuild = false;
                        Invalidate();
                    }
                }
                else
                {
                    throw new ArgumentException("This value should be between 0 and 100");
                }
            }
        }
        /// <summary>
        /// Get or set the aligment of the text
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set the alignment of the text"),
        DefaultValue(typeof(HostLEDControl.Alignment), "Left")]
        public Alignment TextAlignment
        {
            get
            {
                return m_enumAlign;
            }
            set
            {
                m_enumAlign = value;
                if (!m_bIsInitializing)
                {
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the segment width ratio
        /// </summary>
        [Browsable(true),
        Category("Behavior"),
        Description("Set the segment width ratio"),
        DefaultValue(50)]
        public int SegmentWidthRatio
        {
            get
            {
                // :-(
                return (int)((m_fWidthSegWidthRatio - 0.1f) * 500);
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    m_fWidthSegWidthRatio = 0.1f + value * 0.002f;
                    if (!m_bIsInitializing)
                    {
                        // need rebuild cache
                        m_bIsCacheBuild = false;
                        Invalidate();
                    }
                }
                else
                {
                    throw new ArgumentException("This value should be between 0 and 100");
                }
            }
        }
        /// <summary>
        /// Get or set the total number of characters to display
        /// </summary>
        [Browsable(true),
        Category("Behavior"),
        Description("Set the total number of characters to display"),
        DefaultValue(5)]
        public int TotalCharCount
        {
            get
            {
                return m_nCharacterNumber;
            }
            set
            {
                if (value >= 2)
                {
                    m_nCharacterNumber = value;
                    if (!m_bIsInitializing)
                    {
                        Invalidate();
                    }
                }
                else
                {
                    throw new ArgumentException("This value should be greater than 2.");
                }
            }
        }
        /// <summary>
        /// Get or set the bevel rate of each segment
        /// </summary>
        [Browsable(true),
        Category("Behavior"),
        Description("Set the bevel rate of each segment"),
        DefaultValue(0.25)]
        public float BevelRate
        {
            get
            {
                return m_fBevelRate * 2;
            }
            set
            {
                if (value >= 0 && value <= 1)
                {
                    m_fBevelRate = value / 2;
                    if (!m_bIsInitializing)
                    {
                        // need rebuild cache
                        m_bIsCacheBuild = false;
                        Invalidate();
                    }
                }
                else
                {
                    throw new ArgumentException("This value should be between 0.0 and 1");
                }
            }
        }
        /// <summary>
        /// Get or set the color of background characters
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set the color of background characters"),
        DefaultValue(typeof(Color), "System.Color.DimGray")]
        public Color FadedColour
        {
            get
            {
                return m_colFadedColour;
            }
            set
            {
                if (m_colFadedColour == value)
                    return;
                m_colFadedColour = value;
                if (!m_bIsInitializing)
                {
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the text of the control
        /// </summary>
        [Browsable(true),
        Category("Appearance"),
        Description("Set text of the control"),
        DefaultValue("HELLO")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value.ToUpper();
                if (!m_bIsInitializing)
                {
                    Invalidate();
                }
            }
        }
        /// <summary>
        /// Does not support background image
        /// </summary>
        [Browsable(false)]
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = null;
            }
        }
        /// <summary>
        /// Does not support background image layout
        /// </summary>
        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                // do nothing
            }
        }
        /// <summary>
        /// Does not support font
        /// </summary>
        [Browsable(false)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                // do nothing
            }
        }
        #endregion

        #region ISupportInitialize Members
        private bool m_bIsInitializing = false;
        void ISupportInitialize.BeginInit()
        {
            m_bIsInitializing = true;
        }

        void ISupportInitialize.EndInit()
        {
            m_bIsInitializing = false;
            Invalidate();
        }

        #endregion

        #region Event Handlers

        private void EvClick(object sender, EventArgs e)
        {
            Focus();
        }

        private void EvKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                // the clip-board is not always stable
                try
                {
                    Clipboard.SetText(Text);
                }
                catch
                {
                    // do nothing...
                }
            }
        }

        private void EvFocus(object sender, EventArgs e)
        {
            Invalidate();
        }

        #endregion
    }
}
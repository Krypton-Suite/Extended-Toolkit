using System.Drawing;
using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Bookmark of FastColouredTextBox
    /// </summary>
    public class Bookmark
    {
        public FastColouredTextBox TB { get; private set; }
        /// <summary>
        /// Name of bookmark
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Line index
        /// </summary>
        public int LineIndex { get; set; }
        /// <summary>
        /// Color of bookmark sign
        /// </summary>
        public Color Colour { get; set; }

        /// <summary>
        /// Scroll textbox to the bookmark
        /// </summary>
        public virtual void DoVisible()
        {
            TB.Selection.SetStartAndEnd(new Place(0, LineIndex));
            TB.DoRangeVisible(TB.Selection, true);
            TB.Invalidate();
        }

        public Bookmark(FastColouredTextBox tb, string name, int lineIndex)
        {
            this.TB = tb;
            this.Name = name;
            this.LineIndex = lineIndex;
            Colour = tb.BookmarkColour;
        }

        public virtual void Paint(Graphics gr, Rectangle lineRect)
        {
            var size = TB.CharHeight - 1;
            using (var brush = new LinearGradientBrush(new Rectangle(0, lineRect.Top, size, size), Color.White, Colour, 45))
                gr.FillEllipse(brush, 0, lineRect.Top, size, size);
            using (var pen = new Pen(Colour))
                gr.DrawEllipse(pen, 0, lineRect.Top, size, size);
        }
    }
}
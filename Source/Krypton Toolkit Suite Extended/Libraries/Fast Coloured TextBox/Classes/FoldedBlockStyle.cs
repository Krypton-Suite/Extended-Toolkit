using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Renderer for folded block
    /// </summary>
    public class FoldedBlockStyle : TextStyle
    {
        public FoldedBlockStyle(Brush foreBrush, Brush backgroundBrush, FontStyle fontStyle) :
            base(foreBrush, backgroundBrush, fontStyle)
        {
        }

        public override void Draw(Graphics gr, Point position, Range range)
        {
            if (range.End.iChar > range.Start.iChar)
            {
                base.Draw(gr, position, range);

                int firstNonSpaceSymbolX = position.X;

                //find first non space symbol
                for (int i = range.Start.iChar; i < range.End.iChar; i++)
                    if (range.tb[range.Start.iLine][i].c != ' ')
                        break;
                    else
                        firstNonSpaceSymbolX += range.tb.CharWidth;

                //create marker
                range.tb.AddVisualMarker(new FoldedAreaMarker(range.Start.iLine, new Rectangle(firstNonSpaceSymbolX, position.Y, position.X + (range.End.iChar - range.Start.iChar) * range.tb.CharWidth - firstNonSpaceSymbolX, range.tb.CharHeight)));
            }
            else
            {
                //draw '...'
                using (Font f = new Font(range.tb.Font, FontStyle))
                    gr.DrawString("...", f, ForeBrush, range.tb.LeftIndent, position.Y - 2);
                //create marker
                range.tb.AddVisualMarker(new FoldedAreaMarker(range.Start.iLine, new Rectangle(range.tb.LeftIndent + 2, position.Y, 2 * range.tb.CharHeight, range.tb.CharHeight)));
            }
        }
    }
}
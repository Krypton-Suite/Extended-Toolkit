using System;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Clear selected text
    /// </summary>
    public class ClearSelectedCommand : UndoableCommand
    {
        string deletedText;

        /// <summary>
        /// Construstor
        /// </summary>
        /// <param name="tb">Underlaying textbox</param>
        public ClearSelectedCommand(TextSource ts) : base(ts)
        {
        }

        /// <summary>
        /// Undo operation
        /// </summary>
        public override void Undo()
        {
            ts.CurrentTB.Selection.SetStartAndEnd(new Place(sel.FromX, Math.Min(sel.Start.iLine, sel.End.iLine)));
            ts.OnTextChanging();
            InsertTextCommand.InsertText(deletedText, ts);
            ts.OnTextChanged(sel.Start.iLine, sel.End.iLine);
            ts.CurrentTB.Selection.Start = sel.Start;
            ts.CurrentTB.Selection.End = sel.End;
        }

        /// <summary>
        /// Execute operation
        /// </summary>
        public override void Execute()
        {
            var tb = ts.CurrentTB;

            string temp = null;
            ts.OnTextChanging(ref temp);
            if (temp == "")
                throw new ArgumentOutOfRangeException();

            deletedText = tb.Selection.Text;
            ClearSelected(ts);
            lastSel = new RangeInfo(tb.Selection);
            ts.OnTextChanged(lastSel.Start.iLine, lastSel.Start.iLine);
        }

        internal static void ClearSelected(TextSource ts)
        {
            var tb = ts.CurrentTB;

            Place start = tb.Selection.Start;
            Place end = tb.Selection.End;
            int fromLine = Math.Min(end.iLine, start.iLine);
            int toLine = Math.Max(end.iLine, start.iLine);
            int fromChar = tb.Selection.FromX;
            int toChar = tb.Selection.ToX;
            if (fromLine < 0) return;
            //
            if (fromLine == toLine)
                ts[fromLine].RemoveRange(fromChar, toChar - fromChar);
            else
            {
                ts[fromLine].RemoveRange(fromChar, ts[fromLine].Count - fromChar);
                ts[toLine].RemoveRange(0, toChar);
                ts.RemoveLine(fromLine + 1, toLine - fromLine - 1);
                InsertCharCommand.MergeLines(fromLine, ts);
            }
            //
            tb.Selection.SetStartAndEnd(new Place(fromChar, fromLine));
            //
            ts.NeedRecalc(new TextSource.TextChangedEventArgs(fromLine, toLine));
        }

        public override UndoableCommand Clone()
        {
            return new ClearSelectedCommand(ts);
        }
    }

}
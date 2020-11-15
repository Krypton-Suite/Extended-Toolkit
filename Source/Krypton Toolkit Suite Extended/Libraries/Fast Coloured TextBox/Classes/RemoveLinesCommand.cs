using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Removes lines
    /// </summary>
    public class RemoveLinesCommand : UndoableCommand
    {
        List<int> iLines;
        List<string> prevText = new List<string>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tb">Underlaying textbox</param>
        /// <param name="ranges">List of ranges for replace</param>
        /// <param name="insertedText">Text for inserting</param>
        public RemoveLinesCommand(TextSource ts, List<int> iLines)
            : base(ts)
        {
            //sort iLines
            iLines.Sort();
            //
            this.iLines = iLines;
            lastSel = sel = new RangeInfo(ts.CurrentTB.Selection);
        }

        /// <summary>
        /// Undo operation
        /// </summary>
        public override void Undo()
        {
            var tb = ts.CurrentTB;

            ts.OnTextChanging();

            tb.Selection.BeginUpdate();
            //tb.BeginUpdate();
            for (int i = 0; i < iLines.Count; i++)
            {
                var iLine = iLines[i];

                if (iLine < ts.Count)
                    tb.Selection.SetStartAndEnd(new Place(0, iLine));
                else
                    tb.Selection.SetStartAndEnd(new Place(ts[ts.Count - 1].Count, ts.Count - 1));

                InsertCharCommand.InsertLine(ts);
                tb.Selection.SetStartAndEnd(new Place(0, iLine));
                var text = prevText[prevText.Count - i - 1];
                InsertTextCommand.InsertText(text, ts);
                ts[iLine].IsChanged = true;
                if (iLine < ts.Count - 1)
                    ts[iLine + 1].IsChanged = true;
                else
                    ts[iLine - 1].IsChanged = true;
                if (text.Trim() != string.Empty)
                    ts.OnTextChanged(iLine, iLine);
            }
            //tb.EndUpdate();
            tb.Selection.EndUpdate();

            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
        }

        /// <summary>
        /// Execute operation
        /// </summary>
        public override void Execute()
        {
            var tb = ts.CurrentTB;
            prevText.Clear();

            ts.OnTextChanging();

            tb.Selection.BeginUpdate();
            for (int i = iLines.Count - 1; i >= 0; i--)
            {
                var iLine = iLines[i];

                prevText.Add(ts[iLine].Text);//backward
                ts.RemoveLine(iLine);
                //ts.OnTextChanged(ranges[i].Start.iLine, ranges[i].End.iLine);
            }
            tb.Selection.SetStartAndEnd(new Place(0, 0));
            tb.Selection.EndUpdate();
            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));

            lastSel = new RangeInfo(tb.Selection);
        }

        public override UndoableCommand Clone()
        {
            return new RemoveLinesCommand(ts, new List<int>(iLines));
        }
    }
}
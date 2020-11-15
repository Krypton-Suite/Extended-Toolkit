using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    //// <summary>
    /// Insert text into given ranges
    /// </summary>
    public class ReplaceTextCommand : UndoableCommand
    {
        string insertedText;
        List<Range> ranges;
        List<string> prevText = new List<string>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tb">Underlaying textbox</param>
        /// <param name="ranges">List of ranges for replace</param>
        /// <param name="insertedText">Text for inserting</param>
        public ReplaceTextCommand(TextSource ts, List<Range> ranges, string insertedText)
            : base(ts)
        {
            //sort ranges by place
            ranges.Sort((r1, r2) =>
            {
                if (r1.Start.iLine == r2.Start.iLine)
                    return r1.Start.iChar.CompareTo(r2.Start.iChar);
                return r1.Start.iLine.CompareTo(r2.Start.iLine);
            });
            //
            this.ranges = ranges;
            this.insertedText = insertedText;
            lastSel = sel = new RangeInfo(ts.CurrentTB.Selection);
        }

        /// <summary>
        /// Undo operation
        /// </summary>
        public override void Undo()
        {
            var tb = ts.CurrentTB;

            ts.OnTextChanging();
            tb.BeginUpdate();

            tb.Selection.BeginUpdate();
            for (int i = 0; i < ranges.Count; i++)
            {
                tb.Selection.SetStartAndEnd(ranges[i].Start);
                for (int j = 0; j < insertedText.Length; j++)
                    tb.Selection.GoRight(true);
                ClearSelected(ts);
                InsertTextCommand.InsertText(prevText[prevText.Count - i - 1], ts);
            }
            tb.Selection.EndUpdate();
            tb.EndUpdate();

            if (ranges.Count > 0)
                ts.OnTextChanged(ranges[0].Start.iLine, ranges[ranges.Count - 1].End.iLine);

            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
        }

        /// <summary>
        /// Execute operation
        /// </summary>
        public override void Execute()
        {
            var tb = ts.CurrentTB;
            prevText.Clear();

            ts.OnTextChanging(ref insertedText);

            tb.Selection.BeginUpdate();
            tb.BeginUpdate();
            for (int i = ranges.Count - 1; i >= 0; i--)
            {
                tb.Selection.Start = ranges[i].Start;
                tb.Selection.End = ranges[i].End;
                prevText.Add(tb.Selection.Text);
                ClearSelected(ts);
                if (insertedText != "")
                    InsertTextCommand.InsertText(insertedText, ts);
            }
            if (ranges.Count > 0)
                ts.OnTextChanged(ranges[0].Start.iLine, ranges[ranges.Count - 1].End.iLine);
            tb.EndUpdate();
            tb.Selection.EndUpdate();
            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));

            lastSel = new RangeInfo(tb.Selection);
        }

        public override UndoableCommand Clone()
        {
            return new ReplaceTextCommand(ts, new List<Range>(ranges), insertedText);
        }

        internal static void ClearSelected(TextSource ts)
        {
            var tb = ts.CurrentTB;

            tb.Selection.Normalize();

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
        }
    }

}
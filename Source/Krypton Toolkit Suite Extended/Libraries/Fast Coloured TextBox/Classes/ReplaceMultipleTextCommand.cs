using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Replaces text
    /// </summary>
    public class ReplaceMultipleTextCommand : UndoableCommand
    {
        List<ReplaceRange> ranges;
        List<string> prevText = new List<string>();

        public class ReplaceRange
        {
            public Range ReplacedRange { get; set; }
            public String ReplaceText { get; set; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ts">Underlaying textsource</param>
        /// <param name="ranges">List of ranges for replace</param>
        public ReplaceMultipleTextCommand(TextSource ts, List<ReplaceRange> ranges)
            : base(ts)
        {
            //sort ranges by place
            ranges.Sort((r1, r2) =>
            {
                if (r1.ReplacedRange.Start.iLine == r2.ReplacedRange.Start.iLine)
                    return r1.ReplacedRange.Start.iChar.CompareTo(r2.ReplacedRange.Start.iChar);
                return r1.ReplacedRange.Start.iLine.CompareTo(r2.ReplacedRange.Start.iLine);
            });
            //
            this.ranges = ranges;
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
            for (int i = 0; i < ranges.Count; i++)
            {
                tb.Selection.Start = ranges[i].ReplacedRange.Start;
                for (int j = 0; j < ranges[i].ReplaceText.Length; j++)
                    tb.Selection.GoRight(true);
                ClearSelectedCommand.ClearSelected(ts);
                var prevTextIndex = ranges.Count - 1 - i;
                InsertTextCommand.InsertText(prevText[prevTextIndex], ts);
                ts.OnTextChanged(ranges[i].ReplacedRange.Start.iLine, ranges[i].ReplacedRange.Start.iLine);
            }
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
            for (int i = ranges.Count - 1; i >= 0; i--)
            {
                tb.Selection.Start = ranges[i].ReplacedRange.Start;
                tb.Selection.End = ranges[i].ReplacedRange.End;
                prevText.Add(tb.Selection.Text);
                ClearSelectedCommand.ClearSelected(ts);
                InsertTextCommand.InsertText(ranges[i].ReplaceText, ts);
                ts.OnTextChanged(ranges[i].ReplacedRange.Start.iLine, ranges[i].ReplacedRange.End.iLine);
            }
            tb.Selection.EndUpdate();
            ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));

            lastSel = new RangeInfo(tb.Selection);
        }

        public override UndoableCommand Clone()
        {
            return new ReplaceMultipleTextCommand(ts, new List<ReplaceRange>(ranges));
        }
    }
}
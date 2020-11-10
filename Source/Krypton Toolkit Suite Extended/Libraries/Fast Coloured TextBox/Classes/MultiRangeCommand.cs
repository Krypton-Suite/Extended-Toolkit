using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Wrapper for multirange commands
    /// </summary>
    public class MultiRangeCommand : UndoableCommand
    {
        private UndoableCommand cmd;
        private Range range;
        private List<UndoableCommand> commandsByRanges = new List<UndoableCommand>();

        public MultiRangeCommand(UndoableCommand command) : base(command.ts)
        {
            this.cmd = command;
            range = ts.CurrentTB.Selection.Clone();
        }

        public override void Execute()
        {
            commandsByRanges.Clear();
            var prevSelection = range.Clone();
            var iChar = -1;
            var iStartLine = prevSelection.Start.iLine;
            var iEndLine = prevSelection.End.iLine;
            ts.CurrentTB.Selection.ColumnSelectionMode = false;
            ts.CurrentTB.Selection.BeginUpdate();
            ts.CurrentTB.BeginUpdate();
            ts.CurrentTB.AllowInsertRemoveLines = false;
            try
            {
                if (cmd is InsertTextCommand)
                    ExecuteInsertTextCommand(ref iChar, (cmd as InsertTextCommand).InsertedText);
                else
                if (cmd is InsertCharCommand && (cmd as InsertCharCommand).c != '\x0' && (cmd as InsertCharCommand).c != '\b')//if not DEL or BACKSPACE
                    ExecuteInsertTextCommand(ref iChar, (cmd as InsertCharCommand).c.ToString());
                else
                    ExecuteCommand(ref iChar);
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            finally
            {
                ts.CurrentTB.AllowInsertRemoveLines = true;
                ts.CurrentTB.EndUpdate();

                ts.CurrentTB.Selection = range;
                if (iChar >= 0)
                {
                    ts.CurrentTB.Selection.Start = new Place(iChar, iStartLine);
                    ts.CurrentTB.Selection.End = new Place(iChar, iEndLine);
                }
                ts.CurrentTB.Selection.ColumnSelectionMode = true;
                ts.CurrentTB.Selection.EndUpdate();
            }
        }

        private void ExecuteInsertTextCommand(ref int iChar, string text)
        {
            var lines = text.Split('\n');
            var iLine = 0;
            foreach (var r in range.GetSubRanges(true))
            {
                var line = ts.CurrentTB[r.Start.iLine];
                var lineIsEmpty = r.End < r.Start && line.StartSpacesCount == line.Count;
                if (!lineIsEmpty)
                {
                    var insertedText = lines[iLine % lines.Length];
                    if (r.End < r.Start && insertedText != "")
                    {
                        //add forwarding spaces
                        insertedText = new string(' ', r.Start.iChar - r.End.iChar) + insertedText;
                        r.Start = r.End;
                    }
                    ts.CurrentTB.Selection = r;
                    var c = new InsertTextCommand(ts, insertedText);
                    c.Execute();
                    if (ts.CurrentTB.Selection.End.iChar > iChar)
                        iChar = ts.CurrentTB.Selection.End.iChar;
                    commandsByRanges.Add(c);
                }
                iLine++;
            }
        }

        private void ExecuteCommand(ref int iChar)
        {
            foreach (var r in range.GetSubRanges(false))
            {
                ts.CurrentTB.Selection = r;
                var c = cmd.Clone();
                c.Execute();
                if (ts.CurrentTB.Selection.End.iChar > iChar)
                    iChar = ts.CurrentTB.Selection.End.iChar;
                commandsByRanges.Add(c);
            }
        }

        public override void Undo()
        {
            ts.CurrentTB.BeginUpdate();
            ts.CurrentTB.Selection.BeginUpdate();
            try
            {
                for (int i = commandsByRanges.Count - 1; i >= 0; i--)
                    commandsByRanges[i].Undo();
            }
            finally
            {
                ts.CurrentTB.Selection.EndUpdate();
                ts.CurrentTB.EndUpdate();
            }
            ts.CurrentTB.Selection = range.Clone();
            ts.CurrentTB.OnTextChanged(range);
            ts.CurrentTB.OnSelectionChanged();
            ts.CurrentTB.Selection.ColumnSelectionMode = true;
        }

        public override UndoableCommand Clone()
        {
            throw new NotImplementedException();
        }
    }
}
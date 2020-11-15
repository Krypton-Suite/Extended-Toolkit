namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Insert text
    /// </summary>
    public class InsertTextCommand : UndoableCommand
    {
        public string InsertedText;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tb">Underlaying textbox</param>
        /// <param name="insertedText">Text for inserting</param>
        public InsertTextCommand(TextSource ts, string insertedText) : base(ts)
        {
            this.InsertedText = insertedText;
        }

        /// <summary>
        /// Undo operation
        /// </summary>
        public override void Undo()
        {
            ts.CurrentTB.Selection.Start = sel.Start;
            ts.CurrentTB.Selection.End = lastSel.Start;
            ts.OnTextChanging();
            ClearSelectedCommand.ClearSelected(ts);
            base.Undo();
        }

        /// <summary>
        /// Execute operation
        /// </summary>
        public override void Execute()
        {
            ts.OnTextChanging(ref InsertedText);
            InsertText(InsertedText, ts);
            base.Execute();
        }

        internal static void InsertText(string insertedText, TextSource ts)
        {
            var tb = ts.CurrentTB;
            try
            {
                tb.Selection.BeginUpdate();
                char cc = '\x0';

                if (ts.Count == 0)
                {
                    InsertCharCommand.InsertLine(ts);
                    tb.Selection.SetStartAndEnd(Place.Empty);
                }
                tb.ExpandBlock(tb.Selection.Start.iLine);
                var len = insertedText.Length;
                for (int i = 0; i < len; i++)
                {
                    var c = insertedText[i];
                    if (c == '\r' && (i >= len - 1 || insertedText[i + 1] != '\n'))
                        InsertCharCommand.InsertChar('\n', ref cc, ts);
                    else
                        InsertCharCommand.InsertChar(c, ref cc, ts);
                }
                ts.NeedRecalc(new TextSource.TextChangedEventArgs(0, 1));
            }
            finally
            {
                tb.Selection.EndUpdate();
            }
        }

        public override UndoableCommand Clone()
        {
            return new InsertTextCommand(ts, InsertedText);
        }
    }
}
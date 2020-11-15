namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{


    /// <summary>
    /// Remembers current selection and restore it after Undo
    /// </summary>
    public class SelectCommand : UndoableCommand
    {
        public SelectCommand(TextSource ts) : base(ts)
        {
        }

        public override void Execute()
        {
            //remember selection
            lastSel = new RangeInfo(ts.CurrentTB.Selection);
        }

        protected override void OnTextChanged(bool invert)
        {
        }

        public override void Undo()
        {
            //restore selection
            ts.CurrentTB.Selection = new Range(ts.CurrentTB, lastSel.Start, lastSel.End);
        }

        public override UndoableCommand Clone()
        {
            var result = new SelectCommand(ts);
            if (lastSel != null)
                result.lastSel = new RangeInfo(new Range(ts.CurrentTB, lastSel.Start, lastSel.End));
            return result;
        }
    }
}
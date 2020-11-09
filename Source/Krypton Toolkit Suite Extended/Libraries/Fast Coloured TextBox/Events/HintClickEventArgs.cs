using System;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// HintClick event args
    /// </summary>
    public class HintClickEventArgs : EventArgs
    {
        public HintClickEventArgs(Hint hint)
        {
            Hint = hint;
        }

        public Hint Hint { get; private set; }
    }
}
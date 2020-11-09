using System;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class SelectedEventArgs : EventArgs
    {
        public AutoCompleteItem Item { get; internal set; }
        public FastColouredTextBox Tb { get; set; }
    }
}
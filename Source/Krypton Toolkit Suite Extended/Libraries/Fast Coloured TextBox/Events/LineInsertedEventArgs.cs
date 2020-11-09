using System;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class LineInsertedEventArgs : EventArgs
    {
        public LineInsertedEventArgs(int index, int count)
        {
            Index = index;
            Count = count;
        }

        /// <summary>
        /// Inserted line index
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Count of inserted lines
        /// </summary>
        public int Count { get; private set; }
    }
}
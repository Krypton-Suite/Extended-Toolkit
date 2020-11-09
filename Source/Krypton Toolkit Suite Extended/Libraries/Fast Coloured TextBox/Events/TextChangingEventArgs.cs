using System;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class TextChangingEventArgs : EventArgs
    {
        public string InsertingText { get; set; }

        /// <summary>
        /// Set to true if you want to cancel text inserting
        /// </summary>
        public bool Cancel { get; set; }
    }
}
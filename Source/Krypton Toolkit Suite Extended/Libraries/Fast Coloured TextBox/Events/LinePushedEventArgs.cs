using System;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class LinePushedEventArgs : EventArgs
    {
        public string SourceLineText { get; private set; }
        public int DisplayedLineIndex { get; private set; }
        /// <summary>
        /// This property contains only changed text.
        /// If text of line is not changed, this property contains null.
        /// </summary>
        public string DisplayedLineText { get; private set; }
        /// <summary>
        /// This text will be saved in the file
        /// </summary>
        public string SavedText { get; set; }

        public LinePushedEventArgs(string sourceLineText, int displayedLineIndex, string displayedLineText)
        {
            this.SourceLineText = sourceLineText;
            this.DisplayedLineIndex = displayedLineIndex;
            this.DisplayedLineText = displayedLineText;
            this.SavedText = displayedLineText;
        }
    }
}
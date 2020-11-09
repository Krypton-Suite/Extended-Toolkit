using System;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class AutoIndentEventArgs : EventArgs
    {
        public AutoIndentEventArgs(int iLine, string lineText, string prevLineText, int tabLength, int currentIndentation)
        {
            this.iLine = iLine;
            LineText = lineText;
            PrevLineText = prevLineText;
            TabLength = tabLength;
            AbsoluteIndentation = currentIndentation;
        }

        public int iLine { get; internal set; }
        public int TabLength { get; internal set; }
        public string LineText { get; internal set; }
        public string PrevLineText { get; internal set; }

        /// <summary>
        /// Additional spaces count for this line, relative to previous line
        /// </summary>
        public int Shift { get; set; }

        /// <summary>
        /// Additional spaces count for next line, relative to previous line
        /// </summary>
        public int ShiftNextLines { get; set; }

        /// <summary>
        /// Absolute indentation of current line. You can change this property if you want to set absolute indentation.
        /// </summary>
        public int AbsoluteIndentation { get; set; }
    }
}
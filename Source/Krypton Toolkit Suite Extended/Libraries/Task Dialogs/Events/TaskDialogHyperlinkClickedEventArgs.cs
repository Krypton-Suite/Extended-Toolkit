using System;

namespace Krypton.Toolkit.Suite.Extended.Task.Dialogs
{
    public class TaskDialogHyperlinkClickedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hyperlink"></param>
        internal TaskDialogHyperlinkClickedEventArgs(string hyperlink) : base()
        {
            Hyperlink = hyperlink;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Hyperlink
        {
            get;
        }
    }
}
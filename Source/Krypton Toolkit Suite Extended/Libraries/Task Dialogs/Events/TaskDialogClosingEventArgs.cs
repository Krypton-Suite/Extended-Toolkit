using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Task.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskDialogClosingEventArgs : CancelEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        internal TaskDialogClosingEventArgs(TaskDialogButton closeButton) : base() => CloseButton = closeButton;

        /// <summary>
        /// Gets the <see cref="TaskDialogButton"/> that is causing the task dialog
        /// to close.
        /// </summary>
        public TaskDialogButton CloseButton { get; }
    }
}
using System;

namespace Krypton.Toolkit.Suite.Extended.Task.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum TaskDialogButtons : int
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        OK = 1 << 0,

        /// <summary>
        /// 
        /// </summary>
        Yes = 1 << 1,

        /// <summary>
        /// 
        /// </summary>
        No = 1 << 2,

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Note: Adding a Cancel button will automatically add a close button
        /// to the task dialog's title bar and will allow to close the dialog by
        /// pressing ESC or Alt+F4 (just as if you enabled
        /// <see cref="TaskDialogPage.AllowCancel"/>).
        /// </remarks>
        Cancel = 1 << 3,

        /// <summary>
        /// 
        /// </summary>
        Retry = 1 << 4,

        /// <summary>
        /// 
        /// </summary>
        Close = 1 << 5,

        /// <summary>
        /// 
        /// </summary>
        Abort = 1 << 16,

        /// <summary>
        /// 
        /// </summary>
        Ignore = 1 << 17,

        /// <summary>
        /// 
        /// </summary>
        TryAgain = 1 << 18,

        /// <summary>
        /// 
        /// </summary>
        Continue = 1 << 19,

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Note: Clicking this button will not close the dialog, but will raise the
        /// <see cref="TaskDialogPage.Help"/> event.
        /// </remarks>
        Help = 1 << 20
    }
}
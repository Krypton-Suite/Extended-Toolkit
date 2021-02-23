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

    /// <summary>
    /// 
    /// </summary>
    public enum TaskDialogCustomButtonStyle
    {
        /// <summary>
        /// Custom buttons should be displayed as normal buttons.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Custom buttons should be displayed as command links.
        /// </summary>
        CommandLinks = 1,

        /// <summary>
        /// Custom buttons should be displayed as command links, but without an icon.
        /// </summary>
        CommandLinksNoIcon = 2
    }

    /// <summary>
    /// 
    /// </summary>
    public enum TaskDialogProgressBarState : int
    {
        /// <summary>
        /// Shows a regular progress bar.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Shows a paused (yellow) progress bar.
        /// </summary>
        Paused,

        /// <summary>
        /// Shows an error (red) progress bar.
        /// </summary>
        Error,

        /// <summary>
        /// Shows a marquee progress bar.
        /// </summary>
        Marquee,

        /// <summary>
        /// Shows a marquee progress bar where the marquee animation is paused.
        /// </summary>
        /// <remarks>
        /// For example, if you switch from <see cref="Marquee"/> to 
        /// <see cref="MarqueePaused"/> while the dialog is shown, the 
        /// marquee animation will stop.
        /// </remarks>
        MarqueePaused,

        /// <summary>
        /// The progress bar will not be displayed.
        /// </summary>
        /// <remarks>
        /// Note that while the dialog is showing, you cannot switch from
        /// <see cref="None"/> to any other state, and vice versa.
        /// </remarks>
        None
    }
}
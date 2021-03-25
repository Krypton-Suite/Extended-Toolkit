﻿using System;

namespace Krypton.Toolkit.Suite.Extended.Task.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskDialogButtonClickedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        internal TaskDialogButtonClickedEventArgs()
            : base()
        {
        }

        /// <summary>
        /// Gets or sets a value that indicates if the dialog should not be closed
        /// after the event handler returns.
        /// </summary>
        /// <remarks>
        /// When you don't set this property to <c>true</c>, the
        /// <see cref="TaskDialog.Closing"/> event will occur afterwards.
        /// </remarks>
        public bool CancelClose { get; set; }
    }
}
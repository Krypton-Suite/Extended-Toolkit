﻿namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Base class OutlookGridRowNode cancellable events
    /// </summary>
    /// <seealso cref="System.ComponentModel.CancelEventArgs" />
    public class OutlookGridRowNodeCancelEventBase : CancelEventArgs
    {
        private OutlookGridRow _row;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridRowNodeCancelEventBase"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public OutlookGridRowNodeCancelEventBase(OutlookGridRow node)
        {
            _row = node;
        }

        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <value>
        /// The node.
        /// </value>
        public OutlookGridRow Node
        {
            get { return _row; }
        }
    }
}
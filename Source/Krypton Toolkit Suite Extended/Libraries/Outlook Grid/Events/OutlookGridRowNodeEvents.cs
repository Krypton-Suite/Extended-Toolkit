#region MS-PL License
/*
* Copyright (C) 2013 - 2018 JDH Software - <support@jdhsoftware.com>
*
* This program is provided to you under the terms of the Microsoft Public
* License (Ms-PL) as published at https://kryptonoutlookgrid.codeplex.com/license
*
* Visit http://www.jdhsoftware.com and follow @jdhsoftware on Twitter
*/
#endregion

using System;
using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Base class for OutlookGridRowNode events
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class OutlookGridRowNodeEventBase : EventArgs
    {
        private OutlookGridRow _row;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridRowNodeEventBase"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public OutlookGridRowNodeEventBase(OutlookGridRow node)
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

    /// <summary>
    /// Class for Node collapsing events
    /// </summary>
    /// <seealso cref="OutlookGridRowNodeCancelEventBase" />
    public class CollapsingEventArgs : OutlookGridRowNodeCancelEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollapsingEventArgs"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public CollapsingEventArgs(OutlookGridRow node)
            : base(node)
        {
        }
    }

    /// <summary>
    /// Class for Node collapsed events 
    /// </summary>
    /// <seealso cref="OutlookGridRowNodeEventBase" />
    public class CollapsedEventArgs : OutlookGridRowNodeEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollapsedEventArgs"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public CollapsedEventArgs(OutlookGridRow node)
            : base(node)
        {
        }
    }


    /// <summary>
    /// Class for Node expanding events
    /// </summary>
    /// <seealso cref="OutlookGridRowNodeCancelEventBase" />
    public class ExpandingEventArgs : OutlookGridRowNodeCancelEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpandingEventArgs"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public ExpandingEventArgs(OutlookGridRow node) : base(node)
        {
        }
    }


    /// <summary>
    /// Class for Node expanding events
    /// </summary>
    /// <seealso cref="OutlookGridRowNodeEventBase" />
    public class ExpandedEventArgs : OutlookGridRowNodeEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpandedEventArgs"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public ExpandedEventArgs(OutlookGridRow node) : base(node)
        {
        }
    }
}
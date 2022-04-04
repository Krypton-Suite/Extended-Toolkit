#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

//--------------------------------------------------------------------------------
// Copyright (C) 2013-2021 JDH Software - <support@jdhsoftware.com>
//
// This program is provided to you under the terms of the Microsoft Public
// License (Ms-PL) as published at https://github.com/Cocotteseb/Krypton-OutlookGrid/blob/master/LICENSE.md
//
// Visit https://www.jdhsoftware.com and follow @jdhsoftware on Twitter
//
//--------------------------------------------------------------------------------
#endregion

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Base class for OutlookGridRowNode events
    /// </summary>
    /// <seealso cref="EventArgs" />
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
        public OutlookGridRow Node => _row;
    }
}
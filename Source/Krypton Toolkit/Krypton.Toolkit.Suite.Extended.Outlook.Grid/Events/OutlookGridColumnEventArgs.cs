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
    /// Class for events of the column in the groupbox.
    /// </summary>
    public class OutlookGridColumnEventArgs : EventArgs
    {
        private OutlookGridColumn _column;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="col">The OutlookGridColumn.</param>
        public OutlookGridColumnEventArgs(OutlookGridColumn col)
        {
            _column = col;
        }

        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        public OutlookGridColumn Column
        {
            get => _column;
            set => _column = value;
        }
    }
}
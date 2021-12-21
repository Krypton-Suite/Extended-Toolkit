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
    /// Special column used to enable nodes in the grid.
    /// </summary>
    /// <seealso cref="KryptonDataGridViewTextBoxColumn" />
    public class KryptonDataGridViewTreeTextColumn : KryptonDataGridViewTextBoxColumn
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonDataGridViewTreeTextColumn"/> class.
        /// </summary>
        public KryptonDataGridViewTreeTextColumn()
            : base()
        {
            CellTemplate = new KryptonDataGridViewTreeTextCell();
        }
    }
}
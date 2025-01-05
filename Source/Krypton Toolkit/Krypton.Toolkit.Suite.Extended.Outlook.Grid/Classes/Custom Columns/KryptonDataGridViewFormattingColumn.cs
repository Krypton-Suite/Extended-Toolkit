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
    /// Class for a KryptonDataGridViewFormattingColumn : KryptonDataGridViewTextBoxColumn with conditionnal formatting abilities
    /// </summary>
    /// <seealso cref="KryptonDataGridViewTextBoxColumn" />
    public class KryptonDataGridViewFormattingColumn : KryptonDataGridViewTextBoxColumn
    {
        private bool _contrastTextColour;

        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonDataGridViewFormattingColumn"/> class.
        /// </summary>
        public KryptonDataGridViewFormattingColumn()
            : base()
        {
            CellTemplate = new FormattingCell();
            DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ValueType = typeof(FormattingCell);
            ContrastTextColour = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [contrast text color].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [contrast text color]; otherwise, <c>false</c>.
        /// </value>
        public bool ContrastTextColour { get => _contrastTextColour; set => _contrastTextColour = value; }
    }
}
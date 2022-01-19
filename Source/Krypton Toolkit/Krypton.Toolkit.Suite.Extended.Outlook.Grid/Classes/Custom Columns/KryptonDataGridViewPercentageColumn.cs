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
    /// Hosts a collection of KryptonDataGridViewPercentageColumn cells.
    /// </summary>
    /// <seealso cref="DataGridViewColumn" />
    public class KryptonDataGridViewPercentageColumn : DataGridViewColumn// KryptonDataGridViewTextBoxColumn
    {
        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonDataGridViewPercentageColumn class.
        /// </summary>
        public KryptonDataGridViewPercentageColumn()
            : base(new DataGridViewPercentageCell()) => DefaultCellStyle.Format = "P";

        /// <summary>
        /// Returns a standard compact string representation of the column.
        /// </summary>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x40);
            builder.Append("KryptonDataGridViewPercentageColumn { Name=");
            builder.Append(base.Name);
            builder.Append(", Index=");
            builder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
            builder.Append(" }");
            return builder.ToString();
        }

        #endregion

        /// <summary>
        /// Overrides CellTemplate
        /// </summary>
        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }

            set
            {
                // Ensure that the cell used for the template is a DataGridViewPercentageCell.
                if ((value != null) && !value.GetType().IsAssignableFrom(typeof(DataGridViewPercentageCell)))
                {
                    throw new InvalidCastException("Must be a DataGridViewPercentageCell");
                }
                base.CellTemplate = value;

            }
        }

    }
}
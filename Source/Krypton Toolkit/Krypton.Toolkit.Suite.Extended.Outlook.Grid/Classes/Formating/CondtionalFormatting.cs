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
    /// Conditional Formatting class
    /// </summary>
    public class ConditionalFormatting
    {
        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        /// <value>
        /// The name of the column.
        /// </value>
        public string ColumnName { get; set; }
        /// <summary>
        /// Gets or sets the type of the Conditional Formatting.
        /// </summary>
        /// <value>
        /// The type of the Conditional Formatting.
        /// </value>
        public EnumConditionalFormatType FormatType { get; set; }
        /// <summary>
        /// Gets or sets the Conditional Formatting parameters.
        /// </summary>
        /// <value>
        /// The Conditional Formatting parameters.
        /// </value>
        public IFormatParams FormatParams { get; set; }
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>
        /// The minimum value.
        /// </value>
        public double MinValue { get; set; }
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public double MaxValue { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalFormatting"/> class.
        /// </summary>
        public ConditionalFormatting() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalFormatting"/> class. (Only use for context menu !)
        /// </summary>
        /// <param name="formatType">Type of the Conditional Formatting.</param>
        /// <param name="formatParams">The Conditional Formatting parameters.</param>
        public ConditionalFormatting(EnumConditionalFormatType formatType, IFormatParams formatParams)
        {
            FormatType = formatType;
            FormatParams = formatParams;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalFormatting"/> class.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="formatType">Type of the Conditional Formatting.</param>
        /// <param name="formatParams">The Conditional Formatting parameters.</param>
        public ConditionalFormatting(string columnName, EnumConditionalFormatType formatType, IFormatParams formatParams)
        {
            ColumnName = columnName;
            FormatType = formatType;
            FormatParams = formatParams;
        }

        internal void Persist(XmlWriter writer)
        {
            writer.WriteStartElement("Condition");
            writer.WriteElementString("ColumnName", ColumnName);
            writer.WriteElementString("FormatType", FormatType.ToString());
            writer.WriteStartElement("FormatParams");
            FormatParams.Persist(writer);
            writer.WriteEndElement(); //FormatParams
            //No need to persist min/max Value.
            writer.WriteEndElement(); //Condition
        }
    }
}
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
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Column for the OutlookGrid
    /// </summary>
    public class OutlookGridColumn : IEquatable<OutlookGridColumn>
    {
        private IOutlookGridGroup groupingType;
        private DataGridViewColumn column;
        private SortOrder sortDirection;
        private int groupIndex;
        private int sortIndex;
        private string name;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="col">The DataGridViewColumn.</param>
        /// <param name="group">The group type for the column.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="groupIndex">The column's position in grouping and at which level.</param>
        /// <param name="sortIndex">the column's position among sorted columns.</param>
        public OutlookGridColumn(DataGridViewColumn col, IOutlookGridGroup group, SortOrder sortDirection, int groupIndex, int sortIndex)
        {
            this.column = col;
            this.name = col.Name;
            this.groupingType = group;
            this.sortDirection = sortDirection;
            this.groupIndex = groupIndex;
            this.sortIndex = sortIndex;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="columnName">The name.</param>
        /// <param name="col">The DataGridViewColumn.</param>
        /// <param name="group">The group type for the column.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="groupIndex">The column's position in grouping and at which level.</param>
        /// <param name="sortIndex">the column's position among sorted columns.</param>
        public OutlookGridColumn(string columnName, DataGridViewColumn col, IOutlookGridGroup group, SortOrder sortDirection, int groupIndex, int sortIndex)
        {
            this.column = col;
            this.name = columnName;
            this.groupingType = group;
            this.sortDirection = sortDirection;
            this.groupIndex = groupIndex;
            this.sortIndex = sortIndex;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the column name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets if the column is grouped
        /// </summary>
        public bool IsGrouped
        {
            get { return groupIndex > -1; }
        }

        /// <summary>
        /// Gets or sets the sort direction
        /// </summary>
        public SortOrder SortDirection
        {
            get { return sortDirection; }
            set { sortDirection = value; }
        }

        /// <summary>
        /// Gets or sets the associated DataGridViewColumn
        /// </summary>
        public DataGridViewColumn DataGridViewColumn
        {
            get { return column; }
            set { column = value; }
        }

        /// <summary>
        /// Gets or sets the group
        /// </summary>
        public IOutlookGridGroup GroupingType
        {
            get { return groupingType; }
            set { groupingType = value; }
        }

        /// <summary>
        /// Gets or sets the column's position in grouping and at which level
        /// </summary>
        public int GroupIndex
        {
            get { return groupIndex; }
            set { groupIndex = value; }
        }

        /// <summary>
        /// Gets or sets the column's position among sorted columns
        /// </summary>
        public int SortIndex
        {
            get { return sortIndex; }
            set { sortIndex = value; }
        }

        #endregion

        #region Implements

        /// <summary>
        /// Defines Equals methode (interface IEquatable)
        /// </summary>
        /// <param name="other">The OutlookGridColumn to compare with</param>
        /// <returns></returns>
        public bool Equals(OutlookGridColumn other)
        {
            return column.Name.Equals(other.DataGridViewColumn.Name);
        }

        #endregion
    }
}
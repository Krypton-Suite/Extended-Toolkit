// Copyright 2006 Herre Kuijpers - <herre@xs4all.nl>
//
// This source file(s) may be redistributed, altered and customized
// by any means PROVIDING the authors name and all copyright
// notices remain intact.
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED. USE IT AT YOUR OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//-----------------------------------------------------------------------

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
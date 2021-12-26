using System.Linq;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// List of the current columns of the OutlookGrid
    /// </summary>
    public class OutlookGridColumnCollection : List<OutlookGridColumn>
    {
        private int maxGroupIndex;
        private int maxSortIndex;

        /// <summary>
        /// Constructor
        /// </summary>
        public OutlookGridColumnCollection()
            : base()
        {
            maxGroupIndex = -1;
            maxSortIndex = -1;
        }

        /// <summary>
        /// Gets the OutlookGridColumn in the list by its name
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <returns>OutlookGridColumn</returns>
        public OutlookGridColumn this[string columnName]
        {
            get
            {
                return this.Find(c => c.DataGridViewColumn.Name.Equals(columnName));
            }
        }

        /// <summary>
        /// Add an OutlookGridColumn to the collection.
        /// </summary>
        /// <param name="item">The OutlookGridColumn to add.</param>
        public new void Add(OutlookGridColumn item)
        {
            base.Add(item);

            if (item.GroupIndex > -1)
                maxGroupIndex++;
            if (item.SortIndex > -1)
                maxSortIndex++;
        }

        /// <summary>
        /// Gets or Sets the maximum GroupIndex in the collection
        /// </summary>
        public int MaxGroupIndex
        {
            get
            {
                return maxGroupIndex;
            }
            set
            {
                maxGroupIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum SortIndex in the collection
        /// </summary>
        public int MaxSortIndex
        {
            get
            {
                return maxSortIndex;
            }
            set
            {
                maxSortIndex = value;
            }
        }

        /// <summary>
        /// Gets the number of columns grouped
        /// </summary>
        /// <returns>the number of columns grouped.</returns>
        public int CountGrouped()
        {
            return this.Count(c => c.IsGrouped == true);
        }

        /// <summary>
        /// Gets the list of grouped columns
        /// </summary>
        /// <returns>The list of grouped columns.</returns>
        public List<OutlookGridColumn> FindGroupedColumns()
        {
            return this.Where(c => c.IsGrouped).OrderBy(c => c.GroupIndex).ToList();
        }

        /// <summary>
        /// Gets a list of columns which are sorted and not grouped.
        /// </summary>
        /// <returns>List of Column indexes and SortDirection ordered by SortIndex.</returns>
        public List<Tuple<int, SortOrder, IComparer>> GetIndexAndSortGroupedColumns()
        {
            List<Tuple<int, SortOrder, IComparer>> res = new List<Tuple<int, SortOrder, IComparer>>();
            var tmp = this.OrderBy(x => x.GroupIndex);
            foreach (OutlookGridColumn col in tmp)
            {
                if (col.IsGrouped && col.GroupIndex > -1)
                    res.Add(Tuple.Create<int, SortOrder, IComparer>(col.DataGridViewColumn.Index, col.SortDirection, col.RowsComparer));
            }
            return res;
        }

        /// <summary>
        /// Gets the column from its real index (from the underlying DataGridViewColumn)
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The OutlookGridColumn.</returns>
        public OutlookGridColumn FindFromColumnIndex(int index)
        {
            return this.FirstOrDefault(c => c.DataGridViewColumn.Index == index);
        }

        /// <summary>
        /// Gets the column from its name
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The associated OutlookGridColumn.</returns>
        public OutlookGridColumn FindFromColumnName(string name)
        {
            return this.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Gets a list of columns which are sorted and not grouped.
        /// </summary>
        /// <returns>List of Column indexes and SortDirection ordered by SortIndex.</returns>
        public List<Tuple<int, SortOrder, IComparer>> GetIndexAndSortSortedOnlyColumns()
        {
            var res = new List<Tuple<int, SortOrder, IComparer>>();
            var tmp = this.OrderBy(x => x.SortIndex);
            foreach (OutlookGridColumn col in tmp)
            {
                if (!col.IsGrouped && col.SortIndex > -1)
                {
                    res.Add(Tuple.Create(col.DataGridViewColumn.Index, col.SortDirection, col.RowsComparer));
                }
            }
            return res;
        }

        /// <summary>
        /// Removes a groupIndex and update the GroupIndex for all columns
        /// </summary>
        /// <param name="col">The OutlookGridColumn that will be removed.</param>
        internal void RemoveGroupIndex(OutlookGridColumn col)
        {
            int removed = col.GroupIndex;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].GroupIndex > removed)
                {
                    this[i].GroupIndex--;
                }
            }
            maxGroupIndex--;
            col.GroupIndex = -1;
        }

        /// <summary>
        ///  Removes a SortIndex and update the SortIndex for all columns
        /// </summary>
        /// <param name="col">The OutlookGridColumn that will be removed.</param>
        internal void RemoveSortIndex(OutlookGridColumn col)
        {
            int removed = col.SortIndex;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].SortIndex > removed)
                {
                    this[i].SortIndex--;
                }
            }
            maxSortIndex--;
            col.SortIndex = -1;
        }

        internal void ChangeGroupIndex(OutlookGridColumn outlookGridColumn)
        {
            int currentGroupIndex = -1;
            int newGroupIndex = outlookGridColumn.GroupIndex;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Name == outlookGridColumn.Name)
                {
                    currentGroupIndex = this[i].GroupIndex;
                }
            }

            if (currentGroupIndex == -1)
                throw new Exception("OutlookGrid : Unable to interpret the change of GroupIndex!");

#if (DEBUG)
            Console.WriteLine("currentGroupIndex=" + currentGroupIndex.ToString());
            Console.WriteLine("newGroupIndex=" + newGroupIndex.ToString());
            Console.WriteLine("Before");
            DebugOutput();
#endif

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].IsGrouped)
                {
                    if (this[i].GroupIndex == currentGroupIndex)
                    {
                        this[i].GroupIndex = newGroupIndex;
                    }
                    else if ((this[i].GroupIndex >= newGroupIndex) && (this[i].GroupIndex < currentGroupIndex))
                    {
                        this[i].GroupIndex++;
                    }
                    else if ((this[i].GroupIndex <= newGroupIndex) && (this[i].GroupIndex > currentGroupIndex))
                    {
                        this[i].GroupIndex--;
                    }
                }
            }
#if (DEBUG)
            Console.WriteLine("After");
            DebugOutput();
#endif
        }

        /// <summary>
        /// Outputs Debug information to the console.
        /// </summary>
        public void DebugOutput()
        {
            for (int i = 0; i < this.Count; i++)
            {
                Console.WriteLine(this[i].Name + " , GroupIndex=" + this[i].GroupIndex.ToString() + ", SortIndex=" + this[i].SortIndex.ToString());
            }
            Console.WriteLine("MaxGroupIndex=" + maxGroupIndex.ToString() + ", MaxSortIndex=" + maxSortIndex.ToString());
        }
    }
}
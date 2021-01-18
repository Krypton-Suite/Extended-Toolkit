using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// List of IOutlookGridGroups
    /// </summary>
    public class OutlookGridGroupCollection
    {
        #region "Variables"
        private IOutlookGridGroup parentGroup;
        private List<IOutlookGridGroup> groupList;
        #endregion

        #region "Constructor"        
        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridGroupCollection"/> class.
        /// </summary>
        public OutlookGridGroupCollection()
        {
            groupList = new List<IOutlookGridGroup>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridGroupCollection"/> class.
        /// </summary>
        /// <param name="parentGroup">The parent group, if any.</param>
        public OutlookGridGroupCollection(IOutlookGridGroup parentGroup)
        {
            groupList = new List<IOutlookGridGroup>();
            this.parentGroup = parentGroup;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the parent group
        /// </summary>
        public IOutlookGridGroup ParentGroup
        {
            get
            {
                return this.parentGroup;
            }
            internal set
            {
                this.parentGroup = value;
            }
        }

        /// <summary>
        /// Gets the list of IOutlookGridGroup.
        /// </summary>
        public List<IOutlookGridGroup> List
        {
            get
            {
                return groupList;
            }
        }

        /// <summary>
        /// Gets the number of groups
        /// </summary>
        public int Count
        {
            get
            {
                return groupList.Count;
            }
        }

        #endregion

        #region "Public methods"

        /// <summary>
        /// Gets the Group object
        /// </summary>
        /// <param name="index">Index in the list of groups.</param>
        /// <returns>The IOutlookGridGroup.</returns>
        public IOutlookGridGroup this[int index]
        {
            get
            {
                return groupList[index];
            }
        }

        /// <summary>
        /// Adds a new group
        /// </summary>
        /// <param name="group">The IOutlookGridGroup.</param>
        public void Add(IOutlookGridGroup group)
        {
            groupList.Add(group);
        }

        /// <summary>
        /// Sorts the groups
        /// </summary>
        public void Sort()
        {
            groupList.Sort();
        }

        /// <summary>
        /// Sorts the groups
        /// </summary>
        internal void Sort(OutlookGridGroupCountComparer comparer)
        {
            groupList.Sort(comparer);
        }

        /// <summary>
        /// Find a group by its value
        /// </summary>
        /// <param name="value">The value of the group</param>
        /// <returns>The IOutlookGridGroup.</returns>
        public IOutlookGridGroup FindGroup(object value)
        {
            //We must return null if no group exist, then the OutlookGrid will create one. But we must return a group even for a null value.
            if (value == null)
            {
                return groupList.Find(x => x.Value == null);
                //return null;
            }
            //return groupList.Find(x => x.Value.Equals(value));
            return groupList.Find(x => x.Value != null && x.Value.Equals(value));
        }

        #endregion

        #region "Internals"

        internal void Clear()
        {
            parentGroup = null;
            //If a group is collapsed the rows will not appear. Then if we clear the group the rows should not remain "collapsed"
            for (int i = 0; i < groupList.Count; i++)
            {
                groupList[i].Collapsed = false;
            }
            groupList.Clear();
        }

        #endregion
    }
}
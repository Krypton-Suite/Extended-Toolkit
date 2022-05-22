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
    /// List of IOutlookGridGroups
    /// </summary>
    public class OutlookGridGroupCollection
    {
        #region "Variables"
        private IOutlookGridGroup _parentGroup;
        private List<IOutlookGridGroup> _groupList;
        #endregion

        #region "Constructor"        
        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridGroupCollection"/> class.
        /// </summary>
        public OutlookGridGroupCollection()
        {
            _groupList = new List<IOutlookGridGroup>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridGroupCollection"/> class.
        /// </summary>
        /// <param name="parentGroup">The parent group, if any.</param>
        public OutlookGridGroupCollection(IOutlookGridGroup parentGroup)
        {
            _groupList = new List<IOutlookGridGroup>();
            this._parentGroup = parentGroup;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the parent group
        /// </summary>
        public IOutlookGridGroup ParentGroup { get => _parentGroup; internal set => _parentGroup = value; }

        /// <summary>
        /// Gets the list of IOutlookGridGroup.
        /// </summary>
        public List<IOutlookGridGroup> List => _groupList;

        /// <summary>
        /// Gets the number of groups
        /// </summary>
        public int Count => _groupList.Count;

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
                return _groupList[index];
            }
        }

        /// <summary>
        /// Adds a new group
        /// </summary>
        /// <param name="group">The IOutlookGridGroup.</param>
        public void Add(IOutlookGridGroup group)
        {
            _groupList.Add(group);
        }

        /// <summary>
        /// Sorts the groups
        /// </summary>
        public void Sort()
        {
            _groupList.Sort();
        }

        /// <summary>
        /// Sorts the groups
        /// </summary>
        internal void Sort(OutlookGridGroupCountComparer comparer)
        {
            _groupList.Sort(comparer);
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
                return _groupList.Find(x => x.Value == null);
                //return null;
            }
            //return groupList.Find(x => x.Value.Equals(value));
            return _groupList.Find(x => x.Value != null && x.Value.Equals(value));
        }

        #endregion

        #region "Internals"

        internal void Clear()
        {
            _parentGroup = null;
            //If a group is collapsed the rows will not appear. Then if we clear the group the rows should not remain "collapsed"
            for (int i = 0; i < _groupList.Count; i++)
            {
                _groupList[i].Collapsed = false;
            }
            _groupList.Clear();
        }

        #endregion
    }
}

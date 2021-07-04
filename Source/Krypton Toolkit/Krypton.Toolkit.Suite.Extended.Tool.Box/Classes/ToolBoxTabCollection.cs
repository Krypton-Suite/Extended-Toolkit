#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections;

namespace Krypton.Toolkit.Suite.Extended.Tool.Box
{
    [Serializable]
    public class ToolBoxTabCollection : CollectionBase
    {
        #region Constructor
        public ToolBoxTabCollection()
        {
        }
        #endregion //Constructor

        #region Properties
        public ToolBoxTab this[int index]
        {
            get { return (ToolBoxTab)base.List[index]; }
            set { base.List[index] = value; }
        }
        #endregion //Properties

        #region Public Methods
        public int Add(ToolBoxTab tab)
        {
            return base.InnerList.Add(tab);
        }

        public void Insert(int index, ToolBoxTab tab)
        {
            base.InnerList.Insert(index, tab);
        }

        public void Remove(ToolBoxTab tab)
        {
            base.InnerList.Remove(tab);
        }

        public int IndexOf(ToolBoxTab tab)
        {
            return base.InnerList.IndexOf(tab);
        }

        public bool Contains(ToolBoxTab tab)
        {
            return base.InnerList.Contains(tab);
        }

        #endregion //Public Methods
    }
}
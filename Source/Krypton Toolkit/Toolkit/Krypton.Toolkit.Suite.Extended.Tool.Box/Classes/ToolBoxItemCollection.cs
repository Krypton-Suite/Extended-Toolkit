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
    public class ToolBoxItemCollection : CollectionBase
    {
        #region Constructor
        public ToolBoxItemCollection()
        {
        }
        #endregion //Constructor

        #region Properties
        public ToolBoxItem this[int index]
        {
            get { return (ToolBoxItem)base.List[index]; }
            set { base.List[index] = value; }
        }
        #endregion //Properties

        #region Public Methods
        public int Add(ToolBoxItem item)
        {
            return base.InnerList.Add(item);
        }

        public void Insert(int index, ToolBoxItem item)
        {
            base.InnerList.Insert(index, item);
        }

        public void Remove(ToolBoxItem item)
        {
            base.InnerList.Remove(item);
        }

        public int IndexOf(ToolBoxItem item)
        {
            return base.InnerList.IndexOf(item);
        }

        public bool Contains(ToolBoxItem item)
        {
            return base.InnerList.Contains(item);
        }

        #endregion //Public Methods
    }
}
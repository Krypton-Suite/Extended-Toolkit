#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Tree.Grid.View
{
    public class TreeGridNodeCollection : IList<TreeGridNode>, System.Collections.IList
    {
        internal System.Collections.Generic.List<TreeGridNode> _list;
        internal TreeGridNode _owner;
        internal TreeGridNodeCollection(TreeGridNode owner)
        {
            _owner = owner;
            _list = new List<TreeGridNode>();
        }

        #region Public Members
        public void Add(TreeGridNode item)
        {
            // The row needs to exist in the child collection before the parent is notified.
            item._grid = _owner._grid;

            bool hadChildren = _owner.HasChildren;
            item._owner = this;

            _list.Add(item);

            _owner.AddChildNode(item);

            // if the owner didn't have children but now does (asserted) and it is sited update it
            if (!hadChildren && _owner.IsSited)
            {
                _owner._grid.InvalidateRow(_owner.RowIndex);
            }
        }

        public TreeGridNode Add(string text)
        {
            TreeGridNode node = new TreeGridNode();
            Add(node);

            node.Cells[0].Value = text;
            return node;
        }

        public TreeGridNode Add(params object[] values)
        {
            TreeGridNode node = new TreeGridNode();
            Add(node);

            int cell = 0;

            if (values.Length > node.Cells.Count)
                throw new ArgumentOutOfRangeException("values");

            foreach (object o in values)
            {
                node.Cells[cell].Value = o;
                cell++;
            }
            return node;
        }

        public void Insert(int index, TreeGridNode item)
        {
            // The row needs to exist in the child collection before the parent is notified.
            item._grid = _owner._grid;
            item._owner = this;

            _list.Insert(index, item);

            _owner.InsertChildNode(index, item);
        }

        public bool Remove(TreeGridNode item)
        {
            // The parent is notified first then the row is removed from the child collection.
            _owner.RemoveChildNode(item);
            item._grid = null;
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            TreeGridNode row = _list[index];

            // The parent is notified first then the row is removed from the child collection.
            _owner.RemoveChildNode(row);
            row._grid = null;
            _list.RemoveAt(index);
        }

        public void Clear()
        {
            // The parent is notified first then the row is removed from the child collection.
            _owner.ClearNodes();
            _list.Clear();
        }

        public TreeGridNode GetNodeByUniqueValue(int UniqueValue)
        {
            TreeGridNode ReturnNode = new TreeGridNode();
            ReturnNode.UniqueValue = -10;
            foreach (TreeGridNode node in _list)
            {
                if (node.UniqueValue == UniqueValue)
                {
                    return node;
                }
            }
            return ReturnNode;
        }

        public int IndexOf(TreeGridNode item)
        {
            return _list.IndexOf(item);
        }

        public TreeGridNode this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool Contains(TreeGridNode item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(TreeGridNode[] array, int arrayIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
        #endregion

        #region IList Interface
        void System.Collections.IList.Remove(object value)
        {
            Remove(value as TreeGridNode);
        }


        int System.Collections.IList.Add(object value)
        {
            TreeGridNode item = value as TreeGridNode;
            Add(item);
            return item.Index;
        }

        void System.Collections.IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }


        void System.Collections.IList.Clear()
        {
            Clear();
        }

        bool System.Collections.IList.IsReadOnly
        {
            get { return IsReadOnly; }
        }

        bool System.Collections.IList.IsFixedSize
        {
            get { return false; }
        }

        int System.Collections.IList.IndexOf(object item)
        {
            return IndexOf(item as TreeGridNode);
        }

        void System.Collections.IList.Insert(int index, object value)
        {
            Insert(index, value as TreeGridNode);
        }
        int System.Collections.ICollection.Count
        {
            get { return Count; }
        }
        bool System.Collections.IList.Contains(object value)
        {
            return Contains(value as TreeGridNode);
        }
        void System.Collections.ICollection.CopyTo(Array array, int index)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        object System.Collections.IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }



        #region IEnumerable<ExpandableRow> Members

        public IEnumerator<TreeGridNode> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion


        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
        #endregion

        #region ICollection Members

        bool System.Collections.ICollection.IsSynchronized
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        object System.Collections.ICollection.SyncRoot
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }

}
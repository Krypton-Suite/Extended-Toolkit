#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace Krypton.Toolkit.Suite.Extended.TreeGridView
{
    public class TreeGridNodeCollection : IList<KryptonTreeGridNodeRow>, System.Collections.IList
    {
        internal readonly List<KryptonTreeGridNodeRow> List;
        internal readonly KryptonTreeGridNodeRow Owner;
        internal TreeGridNodeCollection(KryptonTreeGridNodeRow owner)
        {
            Owner = owner;
            List = new List<KryptonTreeGridNodeRow>();
        }

        #region Public Members
        public void Add(KryptonTreeGridNodeRow item)
        {
            // The row needs to exist in the child collection before the parent is notified.
            if (item == null)
            {
                return;
            }

            item.Grid = Owner.Grid;

            var hadChildren = Owner.HasChildren;
            item.Owner = this;

            List.Add(item);

            Owner.AddChildNode(item);

            // if the owner didn't have children but now does (asserted) and it is sited update it
            if (!hadChildren && Owner.IsSited)
            {
                Owner.Grid.InvalidateRow(Owner.RowIndex);
            }
        }

        public KryptonTreeGridNodeRow Add(string text)
        {
            var node = new KryptonTreeGridNodeRow();
            Add(node);

            node.Cells[0].Value = text;
            return node;
        }

        public KryptonTreeGridNodeRow Add(params object[] values)
        {
            var node = new KryptonTreeGridNodeRow();
            Add(node);

            var cell = 0;

            if (values.Length > node.Cells.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(values));
            }

            foreach (var o in values)
            {
                node.Cells[cell].Value = o;
                cell++;
            }
            return node;
        }

        public void Insert(int index, KryptonTreeGridNodeRow item)
        {
            // The row needs to exist in the child collection before the parent is notified.
            if (item == null)
            {
                return;
            }

            item.Grid = Owner.Grid;
            item.Owner = this;

            List.Insert(index, item);

            Owner.InsertChildNode(index, item);
        }

        public bool Remove(KryptonTreeGridNodeRow item)
        {
            if (item == null)
            {
                return false;
            }
            // The parent is notified first then the row is removed from the child collection.
            Owner.RemoveChildNode(item);
            item.Grid = null;
            return List.Remove(item);
        }

        public void RemoveAt(int index)
        {
            KryptonTreeGridNodeRow row = List[index];

            // The parent is notified first then the row is removed from the child collection.
            Owner.RemoveChildNode(row);
            row.Grid = null;
            List.RemoveAt(index);
        }

        public void Clear()
        {
            // The parent is notified first then the row is removed from the child collection.
            Owner.ClearNodes();
            List.Clear();
        }

        public KryptonTreeGridNodeRow GetNodeByUniqueValue(int uniqueValue)
        {
            foreach (KryptonTreeGridNodeRow node in List.Where(node => node.UniqueValue == uniqueValue))
            {
                return node;
            }
            var returnNode = new KryptonTreeGridNodeRow
            {
                UniqueValue = -10
            };
            return returnNode;
        }

        public int IndexOf(KryptonTreeGridNodeRow item) => List.IndexOf(item);

        public KryptonTreeGridNodeRow? this[int index]
        {
            get => List[index];
            set => throw new Exception(@"The method or operation is not implemented.");
        }

        public bool Contains(KryptonTreeGridNodeRow item) => List.Contains(item);

        public void CopyTo(KryptonTreeGridNodeRow[] array, int arrayIndex) => throw new Exception(@"The method or operation is not implemented.");

        public int Count => List.Count;

        public bool IsReadOnly => false;

        #endregion

        #region IList Interface
        void System.Collections.IList.Remove(object value) => Remove(value as KryptonTreeGridNodeRow);


        int System.Collections.IList.Add(object value)
        {
            var item = value as KryptonTreeGridNodeRow;
            Add(item);
            return item.Index;
        }

        void System.Collections.IList.RemoveAt(int index) => RemoveAt(index);


        void System.Collections.IList.Clear() => Clear();

        bool System.Collections.IList.IsReadOnly => IsReadOnly;

        bool System.Collections.IList.IsFixedSize => false;

        int System.Collections.IList.IndexOf(object item) => IndexOf(item as KryptonTreeGridNodeRow);

        void System.Collections.IList.Insert(int index, object value)
        {
            Insert(index, value as KryptonTreeGridNodeRow);
        }
        int System.Collections.ICollection.Count => Count;

        bool System.Collections.IList.Contains(object value) => Contains(value as KryptonTreeGridNodeRow);

        void System.Collections.ICollection.CopyTo(Array array, int index) => throw new Exception(@"The method or operation is not implemented.");

        object System.Collections.IList.this[int index]
        {
            get => this[index];
            set => throw new Exception(@"The method or operation is not implemented.");
        }



        #region IEnumerable<ExpandableRow> Members

        public IEnumerator<KryptonTreeGridNodeRow> GetEnumerator() => List.GetEnumerator();

        #endregion


        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #endregion

        #region ICollection Members

        bool System.Collections.ICollection.IsSynchronized => throw new Exception(@"The method or operation is not implemented.");

        object System.Collections.ICollection.SyncRoot => throw new Exception(@"The method or operation is not implemented.");

        #endregion
    }

}
// Copyright 2006 Herre Kuijpers - <herre@xs4all.nl>
//
// This source file(s) may be redistributed, altered and customized
// by any means PROVIDING the authors name and all copyright
// notices remain intact.
// THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED. USE IT AT YOUR OWN RISK. THE AUTHOR ACCEPTS NO
// LIABILITY FOR ANY DATA DAMAGE/LOSS THAT THIS PRODUCT MAY CAUSE.
//-----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// List of IOutlookGridGroups
    /// </summary>
    public class OutlookGridRowNodeCollection : ICollection<OutlookGridRow>, IList<OutlookGridRow>
    {
        #region "Variables"
        private OutlookGridRow _parentNode;
        private List<OutlookGridRow> subNodes;
        #endregion

        #region "Constructor"
        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridRowNodeCollection"/> class.
        /// </summary>
        /// <param name="parentNode">The parent node.</param>
        public OutlookGridRowNodeCollection(OutlookGridRow parentNode)
        {
            _parentNode = parentNode;
            subNodes = new List<OutlookGridRow>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the parent node.
        /// </summary>
        /// <value>
        /// The parent node.
        /// </value>
        public OutlookGridRow ParentNode
        {
            get
            {
                return _parentNode;
            }
            internal set
            {
                _parentNode = value;
            }
        }

        /// <summary>
        /// Gets the nodes.
        /// </summary>
        /// <value>
        /// The nodes.
        /// </value>
        public List<OutlookGridRow> Nodes
        {
            get
            {
                return subNodes;
            }
        }


        /// <summary>
        /// Gets the number of groups
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count
        {
            get
            {
                return subNodes.Count;
            }
        }

        /// <summary>
        /// Gets the readonly state of the list
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        OutlookGridRow IList<OutlookGridRow>.this[int index] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        #endregion

        #region "Public methods"


        /// <summary>
        /// Gets the <see cref="OutlookGridRow"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="OutlookGridRow"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>The IOutlookGridGroup.</returns>
        public OutlookGridRow this[int index]
        {
            get
            {
                return subNodes[index];
            }
            set
            {
                subNodes[index] = value;
                value.ParentNode = _parentNode;
                value.NodeLevel = ParentNode.NodeLevel + 1; //Not ++
            }
        }

        /// <summary>
        /// Adds the specified <see cref="OutlookGridRow"/>.
        /// </summary>
        /// <param name="row">The row.</param>
        public void Add(OutlookGridRow row)
        {
            row.ParentNode = _parentNode;
            row.NodeLevel = ParentNode.NodeLevel + 1; //Not ++
            subNodes.Add(row);
        }

        /// <summary>
        /// Inserts the specified <see cref="OutlookGridRow"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero based index to add the row</param>
        /// <param name="row">The row to insert</param>
        public void Insert(int index, OutlookGridRow row)
        {
            subNodes.Insert(index, row);
            row.ParentNode = _parentNode;
            row.NodeLevel = ParentNode.NodeLevel + 1; //Not ++
        }

        /// <summary>
        /// Removes the <see cref="OutlookGridRow"/> at the specified index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            OutlookGridRow row = subNodes[index];
            subNodes.RemoveAt(index);
            row.ParentNode = null;
            row.NodeLevel = 0;
            row.Collapsed = false;
        }

        /// <summary>
        /// Sorts this instance.
        /// </summary>
        public void Sort()
        {
            subNodes.Sort();
        }

        /// <summary>
        /// Sorts the specified comparer.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        internal void Sort(OutlookGridRowComparer comparer)
        {
            subNodes.Sort(comparer);
        }

        /// <summary>
        /// Gets the Index of a <see cref="OutlookGridRow"/>
        /// </summary>
        /// <param name="row">The OutlookGrid row.</param>
        /// <returns></returns>
        public int IndexOf(OutlookGridRow row)
        {
            return subNodes.IndexOf(row);
        }

        /// <summary>
        /// Determines if specified <see cref="OutlookGridRow"/> is in list
        /// </summary>
        /// <param name="row"></param>
        /// <returns>Returns true if specified row is in list</returns>
        public bool Contains(OutlookGridRow row)
        {
            return subNodes.Contains(row);
        }

        /// <summary>
        /// Copies all <see cref="OutlookGridRow"/> in the list to the specified array
        /// </summary>
        /// <param name="array">Destination Array</param>
        /// <param name="arrayIndex">Startindex in the array</param>
        public void CopyTo(OutlookGridRow[] array, int arrayIndex)
        {
            subNodes.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the specified <see cref="OutlookGridRow"/> from the list
        /// </summary>
        /// <param name="row">Row to remove</param>
        /// <returns></returns>
        public bool Remove(OutlookGridRow row)
        {
            bool ret = subNodes.Remove(row);
            if (ret)
            {
                row.ParentNode = null;
                row.NodeLevel = 0;
                row.Collapsed = false;
            }
            return ret;
        }

        /// <summary>
        /// Gets the enumerator for this collection
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<OutlookGridRow> GetEnumerator()
        {
            return subNodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return subNodes.GetEnumerator();
        }

        /// <summary>
        /// Clears all subnodes.
        /// </summary>
        public void Clear()
        {
            _parentNode = null;
            //If a group is collapsed the rows will not appear. Then if we clear the group the rows should not remain "collapsed"
            for (int i = 0; i < subNodes.Count; i++)
            {
                subNodes[i].Collapsed = false;
            }
            subNodes.Clear();
        }


        #endregion

        #region "Internals"

        #endregion
    }
}
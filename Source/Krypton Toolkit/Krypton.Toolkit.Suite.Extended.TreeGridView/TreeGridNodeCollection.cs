#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

#pragma warning disable CS8613, CS8766, CS8602, CS8769
namespace Krypton.Toolkit.Suite.Extended.TreeGridView;

public class TreeGridNodeCollection : IList<KryptonTreeGridNodeRow>, IList
{
    internal readonly List<KryptonTreeGridNodeRow?> List;
    internal readonly KryptonTreeGridNodeRow Owner;
    internal TreeGridNodeCollection(KryptonTreeGridNodeRow owner)
    {
        Owner = owner;
        List = [];
    }

    #region Public Members
    public void Add(KryptonTreeGridNodeRow? item)
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

    public KryptonTreeGridNodeRow? Add(string text)
    {
        var node = new KryptonTreeGridNodeRow();
        Add(node);

        node.Cells[0].Value = text;
        return node;
    }

    public KryptonTreeGridNodeRow? Add(params object[] values)
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

    public void Insert(int index, KryptonTreeGridNodeRow? item)
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

    public bool Remove(KryptonTreeGridNodeRow? item)
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
        KryptonTreeGridNodeRow? row = List[index];

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

    public KryptonTreeGridNodeRow? GetNodeByUniqueValue(int uniqueValue)
    {
        foreach (KryptonTreeGridNodeRow? node in List.Where(node => node.UniqueValue == uniqueValue))
        {
            return node;
        }
        var returnNode = new KryptonTreeGridNodeRow
        {
            UniqueValue = -10
        };
        return returnNode;
    }

    public int IndexOf(KryptonTreeGridNodeRow? item) => List.IndexOf(item);

    public KryptonTreeGridNodeRow? this[int index]
    {
        get => List[index];
        set => throw new Exception(@"The method or operation is not implemented.");
    }

    public bool Contains(KryptonTreeGridNodeRow? item) => List.Contains(item);

    public void CopyTo(KryptonTreeGridNodeRow[] array, int arrayIndex) => throw new Exception(@"The method or operation is not implemented.");

    public int Count => List.Count;

    public bool IsReadOnly => false;

    #endregion

    #region IList Interface
    void IList.Remove(object value) => Remove(value as KryptonTreeGridNodeRow);


    int IList.Add(object value)
    {
        var item = value as KryptonTreeGridNodeRow;
        Add(item);
        return item.Index;
    }

    void IList.RemoveAt(int index) => RemoveAt(index);


    void IList.Clear() => Clear();

    bool IList.IsReadOnly => IsReadOnly;

    bool IList.IsFixedSize => false;

    int IList.IndexOf(object item) => IndexOf(item as KryptonTreeGridNodeRow);

    void IList.Insert(int index, object value)
    {
        Insert(index, value as KryptonTreeGridNodeRow);
    }
    int ICollection.Count => Count;

    bool IList.Contains(object value) => Contains(value as KryptonTreeGridNodeRow);

    void ICollection.CopyTo(Array array, int index) => throw new Exception(@"The method or operation is not implemented.");

    object? IList.this[int index]
    {
        get => this[index];
        set => throw new Exception(@"The method or operation is not implemented.");
    }



    #region IEnumerable<ExpandableRow> Members

    public IEnumerator<KryptonTreeGridNodeRow?> GetEnumerator() => List.GetEnumerator();

    #endregion


    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    #endregion
    #endregion

    #region ICollection Members

    bool ICollection.IsSynchronized => throw new Exception(@"The method or operation is not implemented.");

    object ICollection.SyncRoot => throw new Exception(@"The method or operation is not implemented.");

    #endregion
}
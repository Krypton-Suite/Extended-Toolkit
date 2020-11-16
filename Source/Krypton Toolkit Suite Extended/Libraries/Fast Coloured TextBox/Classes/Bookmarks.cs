#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
* KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
* IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
* PURPOSE.
*
* License: GNU Lesser General Public License (LGPLv3)
*
* Email: pavel_torgashov@ukr.net.
*
* Copyright (C) Pavel Torgashov, 2011-2016.
*/
#endregion

using System.Collections.Generic;
using System.Linq;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Collection of bookmarks
    /// </summary>
    public class Bookmarks : BaseBookmarks
    {
        protected FastColouredTextBox tb;
        protected List<Bookmark> items = new List<Bookmark>();
        protected int counter;

        public Bookmarks(FastColouredTextBox tb)
        {
            this.tb = tb;
            tb.LineInserted += tb_LineInserted;
            tb.LineRemoved += tb_LineRemoved;
        }

        protected virtual void tb_LineRemoved(object sender, LineRemovedEventArgs e)
        {
            for (int i = 0; i < Count; i++)
                if (items[i].LineIndex >= e.Index)
                {
                    if (items[i].LineIndex >= e.Index + e.Count)
                    {
                        items[i].LineIndex = items[i].LineIndex - e.Count;
                        continue;
                    }

                    var was = e.Index <= 0;
                    foreach (var b in items)
                        if (b.LineIndex == e.Index - 1)
                            was = true;

                    if (was)
                    {
                        items.RemoveAt(i);
                        i--;
                    }
                    else
                        items[i].LineIndex = e.Index - 1;

                    //if (items[i].LineIndex == e.Index + e.Count - 1)
                    //{
                    //    items[i].LineIndex = items[i].LineIndex - e.Count;
                    //    continue;
                    //}
                    //
                    //items.RemoveAt(i);
                    //i--;
                }
        }

        protected virtual void tb_LineInserted(object sender, LineInsertedEventArgs e)
        {
            for (int i = 0; i < Count; i++)
                if (items[i].LineIndex >= e.Index)
                {
                    items[i].LineIndex = items[i].LineIndex + e.Count;
                }
                else
                if (items[i].LineIndex == e.Index - 1 && e.Count == 1)
                {
                    if (tb[e.Index - 1].StartSpacesCount == tb[e.Index - 1].Count)
                        items[i].LineIndex = items[i].LineIndex + e.Count;
                }
        }

        public override void Dispose()
        {
            tb.LineInserted -= tb_LineInserted;
            tb.LineRemoved -= tb_LineRemoved;
        }

        public override IEnumerator<Bookmark> GetEnumerator()
        {
            foreach (var item in items)
                yield return item;
        }

        public override void Add(int lineIndex, string bookmarkName)
        {
            Add(new Bookmark(tb, bookmarkName ?? "Bookmark " + counter, lineIndex));
        }

        public override void Add(int lineIndex)
        {
            Add(new Bookmark(tb, "Bookmark " + counter, lineIndex));
        }

        public override void Clear()
        {
            items.Clear();
            counter = 0;
        }

        public override void Add(Bookmark bookmark)
        {
            foreach (var bm in items)
                if (bm.LineIndex == bookmark.LineIndex)
                    return;

            items.Add(bookmark);
            counter++;
            tb.Invalidate();
        }

        public override bool Contains(Bookmark item)
        {
            return items.Contains(item);
        }

        public override bool Contains(int lineIndex)
        {
            foreach (var item in items)
                if (item.LineIndex == lineIndex)
                    return true;
            return false;
        }

        public override void CopyTo(Bookmark[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override bool Remove(Bookmark item)
        {
            tb.Invalidate();
            return items.Remove(item);
        }

        /// <summary>
        /// Removes bookmark by line index
        /// </summary>
        public override bool Remove(int lineIndex)
        {
            bool was = false;
            for (int i = 0; i < Count; i++)
                if (items[i].LineIndex == lineIndex)
                {
                    items.RemoveAt(i);
                    i--;
                    was = true;
                }
            tb.Invalidate();

            return was;
        }

        /// <summary>
        /// Returns Bookmark by index.
        /// </summary>
        public override Bookmark GetBookmark(int i)
        {
            return items[i];
        }
    }
}
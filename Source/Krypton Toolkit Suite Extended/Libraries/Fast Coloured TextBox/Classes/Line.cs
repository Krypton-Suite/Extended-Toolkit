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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Line of text
    /// </summary>
    public class Line : IList<Char>
    {
        protected List<Char> chars;

        public string FoldingStartMarker { get; set; }
        public string FoldingEndMarker { get; set; }
        /// <summary>
        /// Text of line was changed
        /// </summary>
        public bool IsChanged { get; set; }
        /// <summary>
        /// Time of last visit of caret in this line
        /// </summary>
        /// <remarks>This property can be used for forward/backward navigating</remarks>
        public DateTime LastVisit { get; set; }
        /// <summary>
        /// Background brush.
        /// </summary>
        public Brush BackgroundBrush { get; set; }
        /// <summary>
        /// Unique ID
        /// </summary>
        public int UniqueId { get; private set; }
        /// <summary>
        /// Count of needed start spaces for AutoIndent
        /// </summary>
        public int AutoIndentSpacesNeededCount
        {
            get;
            set;
        }

        internal Line(int uid)
        {
            this.UniqueId = uid;
            chars = new List<Char>();
        }


        /// <summary>
        /// Clears style of chars, delete folding markers
        /// </summary>
        public void ClearStyle(StyleIndex styleIndex)
        {
            FoldingStartMarker = null;
            FoldingEndMarker = null;
            for (int i = 0; i < Count; i++)
            {
                Char c = this[i];
                c.style &= ~styleIndex;
                this[i] = c;
            }
        }

        /// <summary>
        /// Text of the line
        /// </summary>
        public virtual string Text
        {
            get
            {
                StringBuilder sb = new StringBuilder(Count);
                foreach (Char c in this)
                    sb.Append(c.c);
                return sb.ToString();
            }
        }

        /// <summary>
        /// Clears folding markers
        /// </summary>
        public void ClearFoldingMarkers()
        {
            FoldingStartMarker = null;
            FoldingEndMarker = null;
        }

        /// <summary>
        /// Count of start spaces
        /// </summary>
        public int StartSpacesCount
        {
            get
            {
                int spacesCount = 0;
                for (int i = 0; i < Count; i++)
                    if (this[i].c == ' ')
                        spacesCount++;
                    else
                        break;
                return spacesCount;
            }
        }

        public int IndexOf(Char item)
        {
            return chars.IndexOf(item);
        }

        public void Insert(int index, Char item)
        {
            chars.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            chars.RemoveAt(index);
        }

        public Char this[int index]
        {
            get
            {
                return chars[index];
            }
            set
            {
                chars[index] = value;
            }
        }

        public void Add(Char item)
        {
            chars.Add(item);
        }

        public void Clear()
        {
            chars.Clear();
        }

        public bool Contains(Char item)
        {
            return chars.Contains(item);
        }

        public void CopyTo(Char[] array, int arrayIndex)
        {
            chars.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Chars count
        /// </summary>
        public int Count
        {
            get { return chars.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Char item)
        {
            return chars.Remove(item);
        }

        public IEnumerator<Char> GetEnumerator()
        {
            return chars.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return chars.GetEnumerator() as System.Collections.IEnumerator;
        }

        public virtual void RemoveRange(int index, int count)
        {
            if (index >= Count)
                return;
            chars.RemoveRange(index, Math.Min(Count - index, count));
        }

        public virtual void TrimExcess()
        {
            chars.TrimExcess();
        }

        public virtual void AddRange(IEnumerable<Char> collection)
        {
            chars.AddRange(collection);
        }
    }
}
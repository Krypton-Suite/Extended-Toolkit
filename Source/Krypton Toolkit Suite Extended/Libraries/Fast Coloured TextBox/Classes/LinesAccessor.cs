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

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class LinesAccessor : IList<string>
    {
        IList<Line> ts;

        public LinesAccessor(IList<Line> ts)
        {
            this.ts = ts;
        }

        public int IndexOf(string item)
        {
            for (int i = 0; i < ts.Count; i++)
                if (ts[i].Text == item)
                    return i;

            return -1;
        }

        public void Insert(int index, string item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public string this[int index]
        {
            get
            {
                return ts[index].Text;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(string item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(string item)
        {
            for (int i = 0; i < ts.Count; i++)
                if (ts[i].Text == item)
                    return true;

            return false;
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            for (int i = 0; i < ts.Count; i++)
                array[i + arrayIndex] = ts[i].Text;
        }

        public int Count
        {
            get { return ts.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(string item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < ts.Count; i++)
                yield return ts[i].Text;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
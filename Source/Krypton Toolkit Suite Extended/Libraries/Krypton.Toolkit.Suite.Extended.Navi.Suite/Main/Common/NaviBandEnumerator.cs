#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* MIT License
*
* Copyright (c) 2017 - 2018 Jacob Mesu
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
*/
#endregion

using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviBandEnumerator : IEnumerator<NaviBand>
    {
        private int curIndex;
        private NaviBand current;
        private NaviBandCollection collection;

        public NaviBandEnumerator(NaviBandCollection collection)
        {
            this.collection = collection;
            curIndex = -1;
            current = default(NaviBand);
        }

        #region IEnumerator<NaviBand> Members

        public NaviBand Current
        {
            get { return current; }
        }

        #endregion

        #region IDisposable Members

        public void Dispose() { }

        #endregion

        #region IEnumerator Members

        object System.Collections.IEnumerator.Current
        {
            get { return current; }
        }

        public bool MoveNext()
        {
            if (++curIndex >= collection.Count)
                return false;
            else
                current = collection[curIndex];
            return true;
        }

        public void Reset()
        {
            curIndex = -1;
        }

        #endregion
    }
}
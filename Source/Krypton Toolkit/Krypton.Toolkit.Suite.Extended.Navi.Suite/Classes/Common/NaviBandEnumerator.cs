#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
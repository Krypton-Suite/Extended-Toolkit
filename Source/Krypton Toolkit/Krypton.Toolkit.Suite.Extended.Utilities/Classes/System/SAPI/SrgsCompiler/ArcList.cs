#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal class ArcList : RedBackList
    {
        internal new Arc First => (Arc)base.First;

        internal List<Arc> ToList()
        {
            List<Arc> list = new List<Arc>();
            IEnumerator enumerator = GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Arc item = (Arc)enumerator.Current;
                    list.Add(item);
                }
                return list;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
        }

        protected override int CompareTo(object arc1, object arc2)
        {
            return Arc.CompareContentForKey((Arc)arc1, (Arc)arc2);
        }
    }
}
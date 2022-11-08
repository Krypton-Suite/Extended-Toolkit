#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviBandOrgOrderComparer : IComparer
    {
        #region IComparer Members

        public int Compare(object x, object y)
        {
            if (!(x is NaviBand) || !(y is NaviBand))
                throw new ArgumentException("Both of the argument should be of type NaviBand");

            NaviBand bandx = (NaviBand)x;
            NaviBand bandy = (NaviBand)y;

            return bandx.OriginalOrder.CompareTo(bandy.OriginalOrder);
        }

        #endregion
    }
}
#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class OSHelper
    {
        public OSHelper()
        {

        }

        /// <summary>Determines whether [is seven or higher].</summary>
        /// <returns>
        ///   <c>true</c> if [is seven or higher]; otherwise, <c>false</c>.</returns>
        public static bool IsSevenOrHigher()
        {
            if (Environment.OSVersion.Version.Major >= 6 && Environment.OSVersion.Version.Minor >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
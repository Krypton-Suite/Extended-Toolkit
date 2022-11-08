#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// An implementation of IScreenshooter that does nothing
    /// </summary>
    public class NoScreenShot : IScreenShooter
    {
        /// <summary>
        /// Do nothing
        /// </summary>
        /// <returns>an empty string</returns>
        public string TakeScreenShot()
        {
            return "";
        }
    }
}
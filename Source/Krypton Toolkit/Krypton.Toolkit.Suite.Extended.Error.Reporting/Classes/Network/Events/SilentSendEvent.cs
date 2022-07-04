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
    /// A fake/slient version of the events responding to sending
    /// </summary>
    public class SilentSendEvent : IReportSendEvent
    {
        /// <summary>
        /// silent complete
        /// </summary>
        public void Completed(bool success)
        {
            // silent
        }

        /// <summary>
        /// silent error
        /// </summary>
        public void ShowError(string message, Exception exception)
        {
            // silent
        }
    }
}
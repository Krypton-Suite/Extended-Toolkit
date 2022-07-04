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
    /// Represents the events required of a report sender
    /// </summary>
    public interface IReportSendEvent
    {
        /// <summary>
        /// send completed
        /// </summary>
        void Completed(bool success);

        /// <summary>
        /// show an error
        /// </summary>
        void ShowError(string message, Exception exception);
    }
}
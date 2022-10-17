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
    /// One who sends reports - generally separated by communication method
    /// </summary>
    public interface IReportSender
    {
        /// <summary>
        /// Send the report using implementation destination
        /// </summary>
        void Send(string report);

        /// <summary>
        /// One-word description of the sender type
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Message to describe connection impending
        /// </summary>
        string ConnectingMessage { get; }
    }
}
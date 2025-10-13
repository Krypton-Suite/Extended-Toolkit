#region License

/*
 * Copyright(c) 2022 Deadpikle
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core;

/// <summary>
/// Provides data for a progress event for downloading an AppCastItem from a
/// web server.
/// </summary>
public class ItemDownloadProgressEventArgs : ProgressChangedEventArgs
{
    /// <summary>
    /// Create an <see cref="ItemDownloadProgressEventArgs"/> object based on
    /// the total percentage (0-100, inclusive) and the custom user state.
    /// </summary>
    /// <param name="progressPercentage">the total download progress as an int (between 0-100)</param>
    /// <param name="userState">the custom user state sent along with the download progress</param>
    public ItemDownloadProgressEventArgs(int progressPercentage, object userState) : base(progressPercentage, userState)
    {
        BytesReceived = 0;
        TotalBytesToReceive = 0;
    }

    /// <summary>
    /// Create an <see cref="ItemDownloadProgressEventArgs"/> object based on
    /// the total percentage (0-100, inclusive), the custom user state, the
    /// number of bytes received, and the number of total bytes that need to
    /// be downloaded.
    /// </summary>
    /// <param name="progressPercentage">the total download progress as an int (between 0-100)</param>
    /// <param name="userState">the custom user state sent along with the download progress</param>
    /// <param name="bytesReceived">the number of bytes received by the downloader</param>
    /// <param name="totalBytesToReceive">the total number of bytes that need to be downloadeds</param>
    public ItemDownloadProgressEventArgs(int progressPercentage, object userState, long bytesReceived, long totalBytesToReceive) : base(progressPercentage, userState)
    {
        BytesReceived = bytesReceived;
        TotalBytesToReceive = totalBytesToReceive;
    }

    /// <summary>
    /// The number of bytes received by the downloader
    /// </summary>
    public long BytesReceived { get; private set; }

    /// <summary>
    /// The total number of bytes that need to be downloaded
    /// </summary>
    public long TotalBytesToReceive { get; private set; }
}
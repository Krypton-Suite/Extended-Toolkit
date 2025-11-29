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
/// Interface for objects that can download (or otherwise obtain) update files
/// for a given <see cref="AppCastItem"/>. These objects should send back
/// progress updates and handle other exceptions or other event changes as necessary.
/// </summary>
public interface IUpdateDownloader
{
    /// <summary>
    /// Return true if the update downloader is currently downloading the update
    /// </summary>
    bool IsDownloading { get; }

    /// <summary>
    /// Event to call when some progress has been made on the download
    /// </summary>
    event DownloadProgressEvent DownloadProgressChanged;

    /// <summary>
    /// Event to call when the download of the update file has been completed
    /// </summary>
    event AsyncCompletedEventHandler DownloadFileCompleted;

    /// <summary>
    /// Start the download of the file. The file download should be asynchronous!
    /// </summary>
    /// <param name="uri">URL for the download</param>
    /// <param name="downloadFilePath">Where to download the file</param>
    void StartFileDownload(Uri uri, string downloadFilePath);

    /// <summary>
    /// Cancel the download.
    /// </summary>
    void CancelDownload();

    /// <summary>
    /// Clean up and dispose of anything that has to be disposed of
    /// (cancel the download if needed, etc.)
    /// </summary>
    void Dispose();

    /// <summary>
    /// Retrieve the download file name of the app cast item from the server.
    /// This is useful if the server has any sort of redirects that take place
    /// when starting the download process. The client will use this file name
    /// when saving the file on disk.
    /// NetSparkle.CheckServerFileName = false can be set to avoid this call.
    /// </summary>
    /// <param name="item">The AppCastItem that will be downloaded</param>
    /// <returns>The file name of the file to download from the server 
    /// (including file extension). Null if not found/had error/not applicable.</returns>
    Task<string> RetrieveDestinationFileNameAsync(AppCastItem? item);
}
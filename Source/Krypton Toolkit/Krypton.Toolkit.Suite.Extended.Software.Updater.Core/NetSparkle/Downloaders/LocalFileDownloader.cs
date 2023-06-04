﻿#region License

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

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core
{
    /// <summary>
    /// Class that downloads files from the internet and reports
    /// progress on those files being downloaded. Uses a <seealso cref="WebClient"/>
    /// object as its main method for downloading.
    /// </summary>
    public class LocalFileDownloader : IUpdateDownloader, IDisposable
    {
        private ILogger _logger;
        private CancellationTokenSource _cancellationTokenSource;

        /// <summary>
        /// Default constructor for the local file downloader.
        /// </summary>
        public LocalFileDownloader()
        {
            _logger = new LogWriter();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Default constructor for the web client file downloader.
        /// Uses default credentials and default proxy.
        /// </summary>
        /// <param name="logger">ILogger to write logs to</param>
        public LocalFileDownloader(ILogger logger)
        {
            _logger = logger;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// ILogger to log data from WebClientFileDownloader
        /// </summary>
        public ILogger LogWriter
        {
            set { _logger = value; }
            get { return _logger; }
        }

        /// <inheritdoc/>
        public bool IsDownloading { get; private set; }

        /// <inheritdoc/>
        public event DownloadProgressEvent DownloadProgressChanged;
        /// <inheritdoc/>
        public event AsyncCompletedEventHandler DownloadFileCompleted;

        /// <inheritdoc/>
        public void CancelDownload()
        {
            _cancellationTokenSource.Cancel();
            DownloadFileCompleted?.Invoke(this, new AsyncCompletedEventArgs(null, true, null));
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        /// <inheritdoc/>
        public async Task<string> RetrieveDestinationFileNameAsync(AppCastItem item)
        {
            return await Task.Run(() => Path.GetFileName(item.DownloadLink));
        }

        /// <inheritdoc/>
        public async void StartFileDownload(Uri uri, string downloadFilePath)
        {
            await CopyFileAsync(uri.AbsolutePath, downloadFilePath, _cancellationTokenSource.Token);
        }

        // https://stackoverflow.com/a/36925751/3938401 and
        // https://stackoverflow.com/questions/39742515/stream-copytoasync-with-progress-reporting-progress-is-reported-even-after-cop
        private async Task CopyFileAsync(string sourceFile, string destinationFile, CancellationToken cancellationToken)
        {
            var fileOptions = FileOptions.Asynchronous | FileOptions.SequentialScan;
            var bufferSize = 4096;
            var buffer = new byte[bufferSize];
            int bytesRead = 0;
            long totalRead = 0;
            try
            {
                using (var sourceStream =
                      new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, fileOptions))
                using (var destinationStream =
                      new FileStream(destinationFile, FileMode.CreateNew, FileAccess.Write, FileShare.None, bufferSize, fileOptions))
                {
                    IsDownloading = true;
                    var wasCanceled = false;
                    long totalFileLength = sourceStream.Length;
                    while ((bytesRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                    {
                        await destinationStream.WriteAsync(buffer, 0, bytesRead, cancellationToken);
                        if (cancellationToken.IsCancellationRequested)
                        {
                            Cancel(destinationFile);
                            wasCanceled = true;
                            break;
                        }
                        totalRead += bytesRead;
                        UpdateDownloadProgress(totalRead, totalFileLength);
                    }
                    IsDownloading = false;
                    DownloadFileCompleted?.Invoke(this, new AsyncCompletedEventArgs(null, wasCanceled, null));
                }
            }
            catch (Exception e)
            {
                LogWriter.PrintMessage("Error: {0}", e.Message);
                Cancel(destinationFile);
                DownloadFileCompleted?.Invoke(this, new AsyncCompletedEventArgs(e, true, null));
            }
        }

        private void Cancel(string destinationFile)
        {
            if (File.Exists(destinationFile))
            {
                File.Delete(destinationFile);
            }
            IsDownloading = false;
        }

        private void UpdateDownloadProgress(long totalRead, long totalLength)
        {
            int percentage = Convert.ToInt32(Math.Round((double)totalRead / totalLength * 100, 0));

            DownloadProgressChanged?.Invoke(this, new ItemDownloadProgressEventArgs(percentage, null, totalRead, totalLength));
        }
    }
}
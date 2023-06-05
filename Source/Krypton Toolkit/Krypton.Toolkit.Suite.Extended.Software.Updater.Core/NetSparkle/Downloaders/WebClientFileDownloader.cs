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

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core
{
    /// <summary>
    /// Class that downloads files from the internet and reports
    /// progress on those files being downloaded. Uses a <seealso cref="WebClient"/>
    /// object as its main method for downloading.
    /// </summary>
    public class WebClientFileDownloader : IUpdateDownloader, IDisposable
    {
        private HttpClient _httpClient;
        private ILogger _logger;
        private CancellationTokenSource _cts;

        /// <summary>
        /// Default constructor for the web client file downloader.
        /// Uses default credentials and default proxy.
        /// </summary>
        public WebClientFileDownloader()
        {
            PrepareToDownloadFile();
        }

        /// <summary>
        /// Default constructor for the web client file downloader.
        /// Uses default credentials and default proxy.
        /// </summary>
        /// <param name="logger">ILogger to write logs to</param>
        public WebClientFileDownloader(ILogger logger)
        {
            _logger = logger;
            PrepareToDownloadFile();
        }

        /// <summary>
        /// ILogger to log data from WebClientFileDownloader
        /// </summary>
        public ILogger LogWriter
        {
            set { _logger = value; }
            get { return _logger; }
        }

        /// <summary>
        /// Do preparation work necessary to download a file,
        /// aka set up the WebClient for use.
        /// </summary>
        public void PrepareToDownloadFile()
        {
            _logger?.PrintMessage("IUpdateDownloader: Preparing to download file...");
            if (_httpClient != null)
            {
                _logger?.PrintMessage("IUpdateDownloader: HttpClient existed already. Canceling...");
                // can't re-use WebClient, so cancel old requests
                // and start a new request as needed
                if (IsDownloading)
                {
                    try
                    {
                        _httpClient.CancelPendingRequests();
                    }
                    catch { }
                }
            }
            _logger?.PrintMessage("IUpdateDownloader: Creating new HttpClient...");
            _cts = new CancellationTokenSource();
            _httpClient = CreateHttpClient();
        }

        /// <summary>
        /// Create the HttpClient used for file downloads
        /// </summary>
        /// <returns>The client used for file downloads</returns>
        protected virtual HttpClient CreateHttpClient()
        {
            return CreateHttpClient(null);
        }

        /// <summary>
        /// Create the HttpClient used for file downloads (with nullable handler)
        /// </summary>
        /// <param name="handler">HttpClientHandler for messages</param>
        /// <returns>The client used for file downloads</returns>
        protected virtual HttpClient CreateHttpClient(HttpClientHandler handler)
        {
            if (handler != null)
            {
                return new HttpClient(handler);
            }
            else
            {
                return new HttpClient();
            }
        }

        /// <inheritdoc/>
        public bool IsDownloading { get; private set; }

        /// <inheritdoc/>
        public event DownloadProgressEvent DownloadProgressChanged;
        /// <inheritdoc/>
        public event AsyncCompletedEventHandler DownloadFileCompleted;

        /// <inheritdoc/>
        public void Dispose()
        {
            _cts.Cancel();
            _cts.Dispose();
            _httpClient?.Dispose();
        }

        /// <inheritdoc/>
        public async void StartFileDownload(Uri uri, string downloadFilePath)
        {
            _logger?.PrintMessage("IUpdateDownloader: Starting file download from {0} to {1}", uri, downloadFilePath);

            await StartFileDownloadAsync(uri, downloadFilePath);
        }

        private async Task StartFileDownloadAsync(Uri uri, string downloadFilePath)
        {
            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri))
                using (HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, _cts.Token))
                {
                    if (!response.IsSuccessStatusCode || !response.Content.Headers.ContentLength.HasValue)
                    {
                        return;
                    }
                    using (FileStream fileStream = new FileStream(downloadFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                    using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                    {
                        long totalLength = response.Content.Headers.ContentLength ?? 0;
                        long totalRead = 0;
                        long readCount = 0;
                        byte[] buffer = new byte[32 * 1024]; // read 32 KB at a time -- increased on 9/27/2022 from 4 KB
                        UpdateDownloadProgress(0, totalLength);
                        IsDownloading = true;

                        do
                        {
                            if (_cts.IsCancellationRequested)
                            {
                                DownloadFileCompleted?.Invoke(this, new AsyncCompletedEventArgs(null, true, null));
                            }

                            int bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length, _cts.Token);
                            if (bytesRead == 0)
                            {
                                UpdateDownloadProgress(totalRead, totalLength);
                                break;
                            }
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalRead += bytesRead;
                            readCount += 1;
                            //await Task.Delay(1000); // for TESTING ONLY ("throttling" the download)
                            UpdateDownloadProgress(totalRead, totalLength);
                        } while (IsDownloading);
                        IsDownloading = false;
                        fileStream.Close();
                        contentStream.Close();
                        UpdateDownloadProgress(totalRead, totalLength);
                        DownloadFileCompleted?.Invoke(this, new AsyncCompletedEventArgs(null, false, null));
                    }
                }
            }
            catch (Exception e)
            {
                LogWriter.PrintMessage("Error: {0}", e.Message);
                IsDownloading = false;
                DownloadFileCompleted?.Invoke(this, new AsyncCompletedEventArgs(e, true, null));
            }
        }

        private void UpdateDownloadProgress(long totalRead, long totalLength)
        {
            int percentage = Convert.ToInt32(Math.Round((double)totalRead / totalLength * 100, 0));

            DownloadProgressChanged?.Invoke(this, new ItemDownloadProgressEventArgs(percentage, null, totalRead, totalLength));
        }

        /// <inheritdoc/>
        public void CancelDownload()
        {
            _logger?.PrintMessage("IUpdateDownloader: Canceling download");
            try
            {
                _cts.Cancel();
                _httpClient.CancelPendingRequests();
            }
            catch { }
        }

        /// <inheritdoc/>
        public async Task<string> RetrieveDestinationFileNameAsync(AppCastItem item)
        {
            var httpClient = CreateHttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(30);
            try
            {
                using (var response =
                    await httpClient.SendAsync(new HttpRequestMessage
                    {
                        Method = HttpMethod.Head,
                        RequestUri = new Uri(item.DownloadLink)
                    }, HttpCompletionOption.ResponseHeadersRead, _cts.Token).ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //var totalBytes = response.Content.Headers.ContentLength; // TODO: Use this value as well for a more accurate download %?
                        string destFilename = response.RequestMessage?.RequestUri?.LocalPath;

                        return Path.GetFileName(destFilename);
                    }
                    return null;
                }
            }
            catch
            {
            }
            return null;
        }
    }
}
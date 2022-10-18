#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    class WebClientFileDownloader : IUpdateDownloader, IDisposable
    {
        private WebClient _webClient;

        public WebClientFileDownloader()
        {
            _webClient = new WebClient
            {
                UseDefaultCredentials = true,
                Proxy = { Credentials = CredentialCache.DefaultNetworkCredentials },
            };
            _webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            _webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgressChanged?.Invoke(sender,
                new ItemDownloadProgressEventArgs(e.ProgressPercentage, e.UserState, e.BytesReceived, e.TotalBytesToReceive));
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadFileCompleted?.Invoke(sender, e);
        }

        public bool IsDownloading => _webClient.IsBusy;

        public event DownloadProgressEvent DownloadProgressChanged;
        public event AsyncCompletedEventHandler DownloadFileCompleted;

        public void Dispose()
        {
            _webClient.Dispose();
        }

        public void StartFileDownload(Uri uri, string downloadFilePath)
        {
            _webClient.DownloadFileAsync(uri, downloadFilePath);
        }

        public void CancelDownload()
        {
            _webClient.CancelAsync();
        }

        public async Task<string> RetrieveDestinationFileNameAsync(AppCastItem item)
        {
            var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
            try
            {
                using (var response =
                    await httpClient.GetAsync(item.DownloadLink, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
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
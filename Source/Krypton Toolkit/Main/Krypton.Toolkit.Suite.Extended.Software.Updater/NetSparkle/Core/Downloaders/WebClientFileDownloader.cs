#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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

        public bool IsDownloading
        {
            get => _webClient.IsBusy;
        }

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
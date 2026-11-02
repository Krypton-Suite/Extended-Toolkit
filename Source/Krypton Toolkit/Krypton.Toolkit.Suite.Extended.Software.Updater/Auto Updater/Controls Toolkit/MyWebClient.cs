using System.Net.Http.Headers;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>
    /// HTTP/FTP download client used by AutoUpdater. Replaces the obsolete <see cref="WebClient"/> API
    /// while preserving the same surface area for callers.
    /// </summary>
    public class MyWebClient : IDisposable
    {
        private readonly WebHeaderCollection _responseHeaders = new();
        private HttpClient? _httpClient;
        private HttpClientHandler? _handler;
        private CancellationTokenSource? _downloadCts;
        private readonly SynchronizationContext? _syncContext;

        public MyWebClient()
        {
            Headers = new WebHeaderCollection();
            _syncContext = SynchronizationContext.Current;
        }

        public WebHeaderCollection Headers { get; }

        public WebHeaderCollection ResponseHeaders => _responseHeaders;

        public Uri? ResponseUri { get; private set; }

        public IWebProxy? Proxy { get; set; }

        public ICredentials? Credentials { get; set; }

        public RequestCachePolicy? CachePolicy { get; set; }

        public Encoding Encoding { get; set; } = Encoding.UTF8;

        public bool IsBusy { get; private set; }

        public event DownloadProgressChangedEventHandler? DownloadProgressChanged;

        public event AsyncCompletedEventHandler? DownloadFileCompleted;

        public event UploadStringCompletedEventHandler? UploadStringCompleted;

        public string DownloadString(Uri address)
        {
            if (IsFtp(address))
            {
                return DownloadStringFtp(address);
            }

            using HttpRequestMessage request = CreateHttpRequest(HttpMethod.Get, address);
#if NETFRAMEWORK
            using HttpResponseMessage response = GetHttpClient().SendAsync(request).GetAwaiter().GetResult();
#else
            using HttpResponseMessage response = GetHttpClient().Send(request);
#endif
            CaptureResponse(response);
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public void DownloadFileAsync(Uri address, string fileName)
        {
            if (IsFtp(address))
            {
                _ = Task.Run(() => DownloadFileFtp(address, fileName));
                return;
            }

            _downloadCts = new CancellationTokenSource();
            IsBusy = true;
            _ = DownloadFileHttpAsync(address, fileName, _downloadCts.Token);
        }

        public void UploadStringAsync(Uri address, string data)
        {
            IsBusy = true;
            _ = UploadStringHttpAsync(address, data);
        }

        public void CancelAsync() => _downloadCts?.Cancel();

        public void Dispose()
        {
            try
            {
                _downloadCts?.Cancel();
            }
            catch
            {
                // ignored
            }

            _downloadCts?.Dispose();
            _httpClient?.Dispose();
            _handler?.Dispose();
        }

        private static bool IsFtp(Uri address) =>
            address.Scheme.Equals(Uri.UriSchemeFtp, StringComparison.OrdinalIgnoreCase);

        private HttpClient GetHttpClient()
        {
            if (_httpClient != null)
            {
                ApplyHeadersToHttpClient();
                return _httpClient;
            }

            _handler = new HttpClientHandler
            {
                UseProxy = Proxy != null,
                Proxy = Proxy,
#if NETFRAMEWORK
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
#else
                AutomaticDecompression = DecompressionMethods.All
#endif
            };

            _httpClient = new HttpClient(_handler);
            ApplyHeadersToHttpClient();
            return _httpClient;
        }

        private HttpRequestMessage CreateHttpRequest(HttpMethod method, Uri address)
        {
            HttpRequestMessage request = new(method, address);
            ApplyHeadersToRequest(request);
            return request;
        }

        private void ApplyHeadersToHttpClient()
        {
            if (_httpClient == null)
            {
                return;
            }

            _httpClient.DefaultRequestHeaders.Clear();
            foreach (string? key in Headers.AllKeys)
            {
                if (string.IsNullOrEmpty(key))
                {
                    continue;
                }

                string? value = Headers[key];
                if (value == null)
                {
                    continue;
                }

                if (key.Equals("User-Agent", StringComparison.OrdinalIgnoreCase))
                {
                    _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(value);
                }
                else if (key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(value);
                }
                else
                {
                    _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, value);
                }
            }
        }

        private void ApplyHeadersToRequest(HttpRequestMessage request)
        {
            foreach (string? key in Headers.AllKeys)
            {
                if (string.IsNullOrEmpty(key))
                {
                    continue;
                }

                string? value = Headers[key];
                if (value == null)
                {
                    continue;
                }

                if (key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
                {
                    request.Headers.Authorization = AuthenticationHeaderValue.Parse(value);
                }
                else
                {
                    request.Headers.TryAddWithoutValidation(key, value);
                }
            }
        }

        private void CaptureResponse(HttpResponseMessage response)
        {
            ResponseUri = response.RequestMessage?.RequestUri;
            _responseHeaders.Clear();

            foreach (KeyValuePair<string, IEnumerable<string>> header in response.Headers)
            {
                _responseHeaders[header.Key] = string.Join(", ", header.Value);
            }

            foreach (KeyValuePair<string, IEnumerable<string>> header in response.Content.Headers)
            {
                _responseHeaders[header.Key] = string.Join(", ", header.Value);
            }
        }

        private async Task DownloadFileHttpAsync(Uri address, string fileName, CancellationToken cancellationToken)
        {
            Exception? error = null;
            var cancelled = false;

            try
            {
                using HttpRequestMessage request = CreateHttpRequest(HttpMethod.Get, address);
                using HttpResponseMessage response = await GetHttpClient()
                    .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);

                CaptureResponse(response);
                response.EnsureSuccessStatusCode();

                long totalBytes = response.Content.Headers.ContentLength ?? -1;
#if NETFRAMEWORK
                using Stream contentStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                using FileStream fileStream = new(fileName, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);
#else
                await using Stream contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
                await using FileStream fileStream = new(fileName, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);
#endif

                byte[] buffer = new byte[32 * 1024];
                long bytesReceived = 0;
                int read;

                while (true)
                {
#if NETFRAMEWORK
                    read = await contentStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                    if (read <= 0)
                    {
                        break;
                    }

                    await fileStream.WriteAsync(buffer, 0, read, cancellationToken).ConfigureAwait(false);
#else
                    read = await contentStream.ReadAsync(buffer.AsMemory(0, buffer.Length), cancellationToken).ConfigureAwait(false);
                    if (read <= 0)
                    {
                        break;
                    }

                    await fileStream.WriteAsync(buffer.AsMemory(0, read), cancellationToken).ConfigureAwait(false);
#endif
                    bytesReceived += read;
                    RaiseDownloadProgress(bytesReceived, totalBytes);
                }
            }
            catch (OperationCanceledException)
            {
                cancelled = true;
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                IsBusy = false;
                RaiseDownloadCompleted(error, cancelled);
            }
        }

        private async Task UploadStringHttpAsync(Uri address, string data)
        {
            Exception? error = null;

            try
            {
                using StringContent content = new(data, Encoding);
                using HttpRequestMessage request = CreateHttpRequest(HttpMethod.Post, address);
                request.Content = content;

                using HttpResponseMessage response = await GetHttpClient().SendAsync(request).ConfigureAwait(false);
                CaptureResponse(response);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                IsBusy = false;
                RaiseUploadCompleted(error);
            }
        }

        private string DownloadStringFtp(Uri address)
        {
#pragma warning disable SYSLIB0014 // FTP via WebRequest retained for AutoUpdater FTP appcast support
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = Credentials ?? CredentialCache.DefaultCredentials;
            request.Proxy = Proxy;

            using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            ResponseUri = response.ResponseUri;
            using Stream stream = response.GetResponseStream() ?? Stream.Null;
            using StreamReader reader = new(stream, Encoding);
            return reader.ReadToEnd();
#pragma warning restore SYSLIB0014
        }

        private void DownloadFileFtp(Uri address, string fileName)
        {
            Exception? error = null;
            var cancelled = false;
            IsBusy = true;

            try
            {
#pragma warning disable SYSLIB0014
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = Credentials ?? CredentialCache.DefaultCredentials;
                request.Proxy = Proxy;

                using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                ResponseUri = response.ResponseUri;
                using Stream stream = response.GetResponseStream() ?? Stream.Null;
                using FileStream fileStream = new(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
                stream.CopyTo(fileStream);
#pragma warning restore SYSLIB0014
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                IsBusy = false;
                RaiseDownloadCompleted(error, cancelled);
            }
        }

        private static DownloadProgressChangedEventArgs CreateDownloadProgressChangedEventArgs(
            int progressPercentage,
            long bytesReceived,
            long totalBytesToReceive) =>
            (DownloadProgressChangedEventArgs)Activator.CreateInstance(
                typeof(DownloadProgressChangedEventArgs),
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                null,
                [progressPercentage, null, bytesReceived, totalBytesToReceive],
                null)!;

        private static UploadStringCompletedEventArgs CreateUploadStringCompletedEventArgs(Exception? error) =>
            (UploadStringCompletedEventArgs)Activator.CreateInstance(
                typeof(UploadStringCompletedEventArgs),
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                null,
                [null, error, false, null],
                null)!;

        private static AsyncCompletedEventArgs CreateAsyncCompletedEventArgs(Exception? error, bool cancelled) =>
            new(error, cancelled, null);

        private void RaiseDownloadProgress(long bytesReceived, long totalBytes)
        {
            if (DownloadProgressChanged == null)
            {
                return;
            }

            int progress = totalBytes > 0
                ? Convert.ToInt32(Math.Round(bytesReceived * 100.0 / totalBytes, 0))
                : 0;

            DownloadProgressChangedEventArgs args =
                CreateDownloadProgressChangedEventArgs(progress, bytesReceived, totalBytes);
            PostToUiThread(() => DownloadProgressChanged.Invoke(this, args));
        }

        private void RaiseDownloadCompleted(Exception? error, bool cancelled)
        {
            if (DownloadFileCompleted == null)
            {
                return;
            }

            AsyncCompletedEventArgs args = CreateAsyncCompletedEventArgs(error, cancelled);
            PostToUiThread(() => DownloadFileCompleted.Invoke(this, args));
        }

        private void RaiseUploadCompleted(Exception? error)
        {
            if (UploadStringCompleted == null)
            {
                return;
            }

            UploadStringCompletedEventArgs args = CreateUploadStringCompletedEventArgs(error);
            PostToUiThread(() => UploadStringCompleted.Invoke(this, args));
        }

        private void PostToUiThread(Action action)
        {
            if (_syncContext != null)
            {
                _syncContext.Post(_ => action(), null);
            }
            else
            {
                action();
            }
        }
    }
}

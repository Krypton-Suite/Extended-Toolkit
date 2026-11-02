#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * THE above copyright notice and this permission notice shall be included in all
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

using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting;

/// <summary>
/// HTTP client for exception report uploads with a configurable timeout.
/// </summary>
internal sealed class ExceptionReporterWebClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly SynchronizationContext? _syncContext;

    public ExceptionReporterWebClient(int timeoutSeconds)
    {
        _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(timeoutSeconds)
        };
        Headers = new WebHeaderCollection();
        _syncContext = SynchronizationContext.Current;
    }

    public WebHeaderCollection Headers { get; }

    public Encoding Encoding { get; set; } = Encoding.UTF8;

    public event UploadStringCompletedEventHandler? UploadStringCompleted;

    public void UploadStringAsync(Uri address, string data)
    {
        _ = UploadStringInternalAsync(address, data);
    }

    public void Dispose() => _httpClient.Dispose();

    private async Task UploadStringInternalAsync(Uri address, string data)
    {
        Exception? error = null;

        try
        {
            using StringContent content = new(data, Encoding);
            using HttpRequestMessage request = new(HttpMethod.Post, address)
            {
                Content = content
            };

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

                if (key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                {
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse(value);
                }
                else if (key.Equals("Authorization", StringComparison.OrdinalIgnoreCase))
                {
                    request.Headers.Authorization = AuthenticationHeaderValue.Parse(value);
                }
                else
                {
                    request.Headers.TryAddWithoutValidation(key, value);
                }
            }

            using HttpResponseMessage response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            error = ex;
        }

        if (UploadStringCompleted == null)
        {
            return;
        }

        UploadStringCompletedEventArgs args = (UploadStringCompletedEventArgs)Activator.CreateInstance(
            typeof(UploadStringCompletedEventArgs),
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
            null,
            [null, error, false, null],
            null)!;
        if (_syncContext != null)
        {
            _syncContext.Post(_ => UploadStringCompleted.Invoke(this, args), null);
        }
        else
        {
            UploadStringCompleted.Invoke(this, args);
        }
    }
}

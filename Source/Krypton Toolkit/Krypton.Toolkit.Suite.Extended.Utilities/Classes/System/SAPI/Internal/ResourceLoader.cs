#region MIT License
/*
 *
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

using System.Net.Http;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

internal class ResourceLoader
{
    internal Stream LoadFile(Uri uri, out string mimeType, out Uri baseUri, out string localPath)
    {
        localPath = null;
        Stream stream = null;
        if (!uri.IsAbsoluteUri || uri.IsFile)
        {
            string text = uri.IsAbsoluteUri ? uri.LocalPath : uri.OriginalString;
            try
            {
                stream = new FileStream(text, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch
            {
                if (Directory.Exists(text))
                {
                    throw new InvalidOperationException(SR.Get(SRID.CannotReadFromDirectory, text));
                }
                throw;
            }
            baseUri = null;
        }
        else
        {
            try
            {
                stream = DownloadData(uri, out baseUri);
            }
            catch (WebException ex)
            {
                throw new IOException(ex.Message, ex);
            }
        }
        mimeType = null;
        return stream;
    }

    internal void UnloadFile(string localPath)
    {
    }

    internal Stream LoadFile(Uri uri, out string localPath, out Uri redirectedUri)
    {
        string mimeType;
        return LoadFile(uri, out mimeType, out redirectedUri, out localPath);
    }

    private static Stream DownloadData(Uri uri, out Uri redirectedUri)
    {
        HttpClientHandler handler = new() { UseDefaultCredentials = true };
        using HttpClient httpClient = new(handler);
        using HttpResponseMessage response = httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead).GetAwaiter().GetResult();
        redirectedUri = response.RequestMessage?.RequestUri ?? uri;
        byte[] data = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
        return new MemoryStream(data);
    }
}
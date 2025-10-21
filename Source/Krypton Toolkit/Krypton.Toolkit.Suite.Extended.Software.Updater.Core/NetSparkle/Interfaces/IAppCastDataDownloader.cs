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
/// Interface used by objects that can download app casts from the internet.
/// Use this interface to provide a custom method of grabbing your app cast
/// from the internet or from a local file.
/// </summary>
public interface IAppCastDataDownloader
{
    /// <summary>
    /// Used for both downloading app cast and the app cast's .signature file.
    /// Note that you must handle your own exceptions if they occur. 
    /// Otherwise, <see cref="SparkleUpdater"></see> will act as though the appcast 
    /// failed to download.
    /// </summary>
    /// <param name="url">string URL for the place where the app cast can be downloaded</param>
    /// <returns>The app cast data encoded as a string</returns>
    string DownloadAndGetAppCastData(string url);

    /// <summary>
    /// Get the string encoding (e.g. UTF8 or ASCII) of the 
    /// app cast file so that it can be converted to bytes.
    /// (WebRequestAppCastDataDownloader defaults to UTF8.)
    /// </summary>
    /// <returns>The <seealso cref="Encoding"/> of the app cast</returns>
    Encoding GetAppCastEncoding();
}
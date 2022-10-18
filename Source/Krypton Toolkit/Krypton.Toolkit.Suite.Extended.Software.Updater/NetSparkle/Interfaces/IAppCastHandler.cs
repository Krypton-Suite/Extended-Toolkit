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
    /// <summary>
    /// Interface used by objects that initiate a download process
    /// for an app cast, perform any needed signature verification on
    /// the app cast, and parse the app cast's items into a list of
    /// <see cref="AppCastItem"/>.
    /// Implement this interface if you would like to use a custom parsing
    /// method for your app cast that isn't yet built into NetSparkle.
    /// </summary>
    public interface IAppCastHandler
    {
        /// <summary>
        /// Setup the app cast handler info for downloading and parsing app cast information
        /// </summary>
        /// <param name="dataDownloader">downloader that will manage the app cast download 
        /// (provided by <see cref="SparkleUpdater"/> via the 
        /// <see cref="SparkleUpdater.AppCastDataDownloader"/> property.</param>
        /// <param name="castUrl">full URL to the app cast file</param>
        /// <param name="config">configuration for handling update intervals/checks 
        /// (user skipped versions, etc.)</param>
        /// <param name="signatureVerifier">Object to check signatures of app cast information</param>
        /// <param name="logWriter">object that you can utilize to do any necessary logging</param>
        void SetupAppCastHandler(IAppCastDataDownloader dataDownloader, string castUrl, Configuration config,
            ISignatureVerifier signatureVerifier, LogWriter logWriter = null);

        /// <summary>
        /// Download the app cast file via the <see cref="IAppCastDataDownloader"/> 
        /// object and parse the downloaded information.
        /// If this function is successful, <see cref="SparkleUpdater"/> will call <see cref="GetAvailableUpdates"/>
        /// to get the <see cref="AppCastItem"/> information.
        /// Note that you must handle your own exceptions if they occur. Otherwise, <see cref="SparkleUpdater"/>
        /// will act as though the appc ast failed to download.
        /// </summary>
        /// <returns>true if downloading and parsing succeeded; false otherwise</returns>
        bool DownloadAndParse();

        /// <summary>
        /// Retrieve the available updates from the app cast.
        /// This should be called after <see cref="DownloadAndParse"/> has
        /// successfully completed.
        /// </summary>
        /// <returns>a list of <see cref="AppCastItem"/> updates. Can be empty if no updates are available.</returns>
        List<AppCastItem> GetAvailableUpdates();
    }
}
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
    /// The operation has started
    /// </summary>
    /// <param name="sender">the sender</param>
    public delegate void LoopStartedOperation(object sender);
    /// <summary>
    /// The operation has ended
    /// </summary>
    /// <param name="sender">the sender</param>
    /// <param name="updateRequired"><c>true</c> if an update is required</param>
    public delegate void LoopFinishedOperation(object sender, bool updateRequired);

    /// <summary>
    /// This delegate will be used when an update was detected to allow library 
    /// consumer to add own user interface capabilities.    
    /// </summary>
    public delegate void UpdateDetected(object sender, UpdateDetectedEventArgs e);

    /// <summary>
    /// Update check has started.
    /// </summary>
    /// <param name="sender">Sparkle updater that is checking for an update.</param>
    public delegate void UpdateCheckStarted(object sender);

    /// <summary>
    /// Update check has finished.
    /// </summary>
    /// <param name="sender">Sparkle updater that finished checking for an update.</param>
    /// <param name="status">Update status</param>
    public delegate void UpdateCheckFinished(object sender, UpdateStatus status);

    /// <summary>
    /// An asynchronous cancel event handler.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A System.ComponentModel.CancelEventArgs that contains the event data.</param>
    public delegate Task CancelEventHandlerAsync(object sender, CancelEventArgs e);

    /// <summary>
    /// Delegate for custom application shutdown logic
    /// </summary>
    public delegate void CloseApplication();

    /// <summary>
    /// Async version of CloseApplication().
    /// Delegate for custom application shutdown logic
    /// </summary>
    public delegate Task CloseApplicationAsync();

    /// <summary>
    /// A delegate for download events (start, canceled).
    /// </summary>
    public delegate void DownloadEvent(AppCastItem item, string path);

    /// <summary>
    /// A delegate for download progress events (TODO: docs update)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void DownloadProgressEvent(object sender, ItemDownloadProgressEventArgs args);

    /// <summary>
    /// A delegate for download progress events for a given item (TODO: docs update)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="item"></param>
    /// <param name="args"></param>
    public delegate void ItemDownloadProgressEvent(object sender, AppCastItem item, ItemDownloadProgressEventArgs args);

    /// <summary>
    /// A handler called when the user responsed to an available update
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An UpdateResponse object that contains the event data.</param>
    public delegate void UserRespondedToUpdate(object sender, UpdateResponseEventArgs e);

    /// <summary>
    /// A delegate for a download error
    /// </summary>
    public delegate void DownloadErrorEvent(AppCastItem item, string path, Exception exception);
}
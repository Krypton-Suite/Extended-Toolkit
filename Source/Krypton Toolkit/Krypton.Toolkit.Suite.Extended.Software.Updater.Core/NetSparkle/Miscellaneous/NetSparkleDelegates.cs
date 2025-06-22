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
/// The loop that checks for updates every now and again has started
/// </summary>
/// <param name="sender">the object that initiated the call</param>
public delegate void LoopStartedOperation(object sender);

/// <summary>
/// The loop that checks for updates has finished checking for updates
/// </summary>
/// <param name="sender">the object that initiated the call</param>
/// <param name="updateRequired"><c>true</c> if an update is required; false otherwise</param>
public delegate void LoopFinishedOperation(object sender, bool updateRequired);

/// <summary>
/// An update was detected for the user's currently running software  
/// </summary>
/// <param name="sender">the object that initiated the call</param>
/// <param name="e">Information about the update that was detected</param>
public delegate void UpdateDetected(object sender, UpdateDetectedEventArgs e);

/// <summary>
/// <see cref="SparkleUpdater"/> has started checking for updates
/// </summary>
/// <param name="sender">The <see cref="SparkleUpdater"/> instance that is checking for an update.</param>
public delegate void UpdateCheckStarted(object sender);

/// <summary>
/// <see cref="SparkleUpdater"/> has finished checking for updates
/// </summary>
/// <param name="sender"><see cref="SparkleUpdater"/> that finished checking for an update.</param>
/// <param name="status">Update status (e.g. whether an update is available)</param>
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
public delegate void DownloadEvent(AppCastItem? item, string path);

/// <summary>
/// Delegate that provides information about some download progress that has been made
/// </summary>
/// <param name="sender">The object that initiated the event</param>
/// <param name="args">The information on how much data has been downloaded and how much
/// needs to be downloaded</param>
public delegate void DownloadProgressEvent(object sender, ItemDownloadProgressEventArgs args);

/// <summary>
/// Delegate that provides information about some download progress that has been made
/// when downloading a specific <see cref="AppCastItem"/>.
/// </summary>
/// <param name="sender">The object that initiated the event</param>
/// <param name="item">The item that is being downloaded</param>
/// <param name="args">The information on how much data has been downloaded and how much
/// needs to be downloaded</param>
public delegate void ItemDownloadProgressEvent(object sender, AppCastItem? item, ItemDownloadProgressEventArgs args);

/// <summary>
/// A handler called when the user responsed to an available update
/// </summary>
/// <param name="sender">The object that initiated the event</param>
/// <param name="e">An UpdateResponse object that contains the information on how the user
/// responded to the available update (e.g. skip, remind me later). Be warned that 
/// <see cref="UpdateResponseEventArgs.UpdateItem"/> might be null.</param>
public delegate void UserRespondedToUpdate(object sender, UpdateResponseEventArgs e);

/// <summary>
/// A delegate for a download error that occurred for some reason
/// </summary>
/// <param name="item">The item that is being downloaded</param>
/// <param name="path">The path to the place where the file was being downloaded</param>
/// <param name="exception">The <seealso cref="Exception"/> that occurred to cause the error</param>
public delegate void DownloadErrorEvent(AppCastItem? item, string path, Exception exception);
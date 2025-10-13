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
/// Event called when the download/install window closes
/// </summary>
/// <param name="sender">Sender of this event</param>
/// <param name="args">DownloadInstallArgs with info on whether to install or not</param>
public delegate void DownloadInstallEventHandler(object sender, DownloadInstallEventArgs args);

/// <summary>
/// Args sent via the DownloadInstallEventHandler when the download/install window closes
/// </summary>
public class DownloadInstallEventArgs : EventArgs
{
    /// <summary>
    /// Whether or not the listener should perform the installation process
    /// </summary>
    public bool ShouldInstall { get; set; }

    /// <summary>
    /// True if the download/install event was already handled; false otherwise
    /// </summary>
    public bool WasHandled { get; set; }

    /// <summary>
    /// Constructor for DownloadInstallArgs
    /// </summary>
    /// <param name="shouldInstall">True if the listener should start the download process; false otherwise</param>
    public DownloadInstallEventArgs(bool shouldInstall) : base()
    {
        ShouldInstall = shouldInstall;
    }
}
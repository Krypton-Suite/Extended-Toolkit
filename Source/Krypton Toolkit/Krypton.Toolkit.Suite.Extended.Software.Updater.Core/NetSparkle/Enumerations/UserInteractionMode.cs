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
/// Allows for updating the application with or without user interaction.
/// </summary>
public enum UserInteractionMode
{
    /// <summary>
    /// Shows the changelog UI automatically (this is the default)
    /// </summary>
    NotSilent,
    /// <summary>
    /// Downloads the latest update file and changelog automatically, but does not
    /// show any UI until asked to show UI.
    /// </summary>
    DownloadNoInstall,
    /// <summary>
    /// Downloads the latest update file and automatically runs it as an installer file.
    /// <para>WARNING: if you don't tell the user that the application is about to quit
    /// to update/run an installer, this setting might be quite the shock to the user!
    /// Make sure to implement <see cref="SparkleUpdater.PreparingToExit"/> or
    /// <see cref="SparkleUpdater.PreparingToExitAsync"/> so that you can show your users 
    /// what is about to happen.</para>
    /// </summary>
    DownloadAndInstall,
}
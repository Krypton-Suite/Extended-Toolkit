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

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core
{
    /// <summary>
    /// Interface for UI element that shows the release notes, 
    /// and the skip, install, and later buttons
    /// </summary>
    public interface IUpdateAvailable
    {
        /// <summary>
        /// Event fired when the user has responded to the 
        /// skip, later, install question.
        /// </summary>
        event UserRespondedToUpdate UserResponded;

        /// <summary>
        /// Show the UI that displays release notes, etc.
        /// </summary>
        void Show(bool isOnMainThread);

        /// <summary>
        /// Hides the release notes 
        /// </summary>
        void HideReleaseNotes();

        /// <summary>
        /// Hides the remind me later button
        /// </summary>
        void HideRemindMeLaterButton();

        /// <summary>
        /// Hides the skip update button
        /// </summary>
        void HideSkipButton();

        /// <summary>
        /// Gets the user choice on how to handle this update (e.g. skip, remind me later)
        /// </summary>
        UpdateAvailableResult Result { get; }

        /// <summary>
        /// Gets or sets the current item being installed 
        /// (the item that the user should update to)
        /// </summary>
        AppCastItem CurrentItem { get; }

        /// <summary>
        /// Brings the update info UI to the front of all windows
        /// </summary>
        void BringToFront();

        /// <summary>
        /// Close the UI that shows update information
        /// </summary>
        void Close();
    }
}
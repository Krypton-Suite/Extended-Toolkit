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
    /// Event arguments for when a user responds to an available update UI
    /// </summary>
    public class UpdateResponseEventArgs : EventArgs
    {
        /// <summary>
        /// The user's response to the update
        /// </summary>
        public UpdateAvailableResult Result { get; set; }

        /// <summary>
        /// The AppCastItem that the user is responding to an update notice for
        /// </summary>
        public AppCastItem UpdateItem { get; set; }

        /// <summary>
        /// Constructor for UpdateResponseArgs that allows for easy setting
        /// of the result
        /// </summary>
        /// <param name="result">User's response of type <see cref="UpdateAvailableResult"/></param>
        /// <param name="item">Item that the user is responding to an update message for</param>
        public UpdateResponseEventArgs(UpdateAvailableResult result, AppCastItem item) : base()
        {
            Result = result;
            UpdateItem = item;
        }
    }
}
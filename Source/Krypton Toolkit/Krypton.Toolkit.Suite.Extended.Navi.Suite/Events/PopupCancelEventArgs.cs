#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

#pragma warning disable CS1574, CS1584, CS1581, CS1580
namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// Arguments to a <see cref="PopupCancelEvent"/>.  Provides a
    /// reference to the popup form that is to be closed and 
    /// allows the operation to be canceled.
    /// </summary>
    public class PopupCancelEventArgs : EventArgs
    {
        /// <summary>
        /// Whether to cancel the operation
        /// </summary>
        private bool cancel = false;
        /// <summary>
        /// Mouse down location
        /// </summary>
        private Point location;
        /// <summary>
        /// Popup form.
        /// </summary>
        private KryptonForm popup = null;

        /// <summary>
        /// Constructs a new instance of this class.
        /// </summary>
        /// <param name="popup">The popup form</param>
        /// <param name="location">The mouse location, if any, where the
        /// mouse event that would cancel the popup occured.</param>
        public PopupCancelEventArgs(KryptonForm popup, Point location)
        {
            this.popup = popup;
            this.location = location;
            this.cancel = false;
        }

        /// <summary>
        /// Gets the popup form
        /// </summary>
        public KryptonForm Popup => this.popup;

        /// <summary>
        /// Gets the location that the mouse down which would cancel this 
        /// popup occurred
        /// </summary>
        public Point CursorLocation => this.location;

        /// <summary>
        /// Gets/sets whether to cancel closing the form. Set to
        /// <c>true</c> to prevent the popup from being closed.
        /// </summary>
        public bool Cancel
        {
            get => this.cancel;
            set => this.cancel = value;
        }
    }

    /// <summary>
    /// Represents the method which responds to a <see cref="PopupCancel"/> event.
    /// </summary>
    public delegate void PopupCancelEventHandler(object sender, PopupCancelEventArgs e);
}
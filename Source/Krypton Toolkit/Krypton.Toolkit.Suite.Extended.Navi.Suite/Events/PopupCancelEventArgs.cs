#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
        public KryptonForm Popup
        {
            get
            {
                return this.popup;
            }
        }

        /// <summary>
        /// Gets the location that the mouse down which would cancel this 
        /// popup occurred
        /// </summary>
        public Point CursorLocation
        {
            get
            {
                return this.location;
            }
        }

        /// <summary>
        /// Gets/sets whether to cancel closing the form. Set to
        /// <c>true</c> to prevent the popup from being closed.
        /// </summary>
        public bool Cancel
        {
            get
            {
                return this.cancel;
            }
            set
            {
                this.cancel = value;
            }
        }
    }

    /// <summary>
    /// Represents the method which responds to a <see cref="PopupCancel"/> event.
    /// </summary>
    public delegate void PopupCancelEventHandler(object sender, PopupCancelEventArgs e);
}
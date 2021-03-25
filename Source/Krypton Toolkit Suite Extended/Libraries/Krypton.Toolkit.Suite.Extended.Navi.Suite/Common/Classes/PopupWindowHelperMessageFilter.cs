﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* MIT License
*
* Copyright (c) 2017 - 2018 Jacob Mesu
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
*/
#endregion

using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    // <summary>
    /// A Message Loop filter which detect mouse events whilst the popup form is shown
    /// and notifies the owning <see cref="PopupWindowHelper"/> class when a mouse
    /// click outside the popup occurs.
    /// </summary>
    public class PopupWindowHelperMessageFilter : IMessageFilter
    {
        /// <summary>
        /// Raised when the Popup Window is about to be cancelled.  The
        /// <see cref="PopupCancelEventArgs.Cancel"/> property can be
        /// set to <c>true</c> to prevent the form from being cancelled.
        /// </summary>
        public event PopupCancelEventHandler PopupCancel;

        /// <summary>
        /// The popup form
        /// </summary>
        private KryptonForm popup = null;
        /// <summary>
        /// The owning <see cref="PopupWindowHelper"/> object.
        /// </summary>
        private PopupWindowHelper owner = null;

        /// <summary>
        /// Constructs a new instance of this class and sets the owning
        /// object.
        /// </summary>
        /// <param name="owner">The <see cref="PopupWindowHelper"/> object
        /// which owns this class.</param>
        public PopupWindowHelperMessageFilter(PopupWindowHelper owner)
        {
            this.owner = owner;
        }

        /// <summary>
        /// Gets/sets the popup form which is being displayed.
        /// </summary>
        public KryptonForm Popup
        {
            get
            {
                return this.popup;
            }
            set
            {
                this.popup = value;
            }
        }

        /// <summary>
        /// Checks the message loop for mouse messages whilst the popup
        /// window is displayed.  If one is detected the position is
        /// checked to see if it is outside the form, and the owner
        /// is notified if so.
        /// </summary>
        /// <param name="m">Windows Message about to be processed by the
        /// message loop</param>
        /// <returns><c>true</c> to filter the message, <c>false</c> otherwise.
        /// This implementation always returns <c>false</c>.</returns>
        public bool PreFilterMessage(ref Message m)
        {
            if (this.popup != null)
            {
                switch (m.Msg)
                {
                    case NativeMethods.WM_LBUTTONDOWN:
                    case NativeMethods.WM_RBUTTONDOWN:
                    case NativeMethods.WM_MBUTTONDOWN:
                    case NativeMethods.WM_NCLBUTTONDOWN:
                    case NativeMethods.WM_NCRBUTTONDOWN:
                    case NativeMethods.WM_NCMBUTTONDOWN:
                        OnMouseDown();
                        break;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks the mouse location and calls the OnCancelPopup method
        /// if the mouse is outside the popup form.		
        /// </summary>
        private void OnMouseDown()
        {
            // Get the cursor location
            Point cursorPos = Cursor.Position;
            // Check if it is within the popup form
            if (!popup.Bounds.Contains(cursorPos))
            {
                // If not, then call to see if it should be closed
                OnCancelPopup(new PopupCancelEventArgs(popup, cursorPos));
            }
        }

        /// <summary>
        /// Raises the <see cref="PopupCancel"/> event.
        /// </summary>
        /// <param name="e">The <see cref="PopupCancelEventArgs"/> associated 
        /// with the cancel event.</param>
        protected virtual void OnCancelPopup(PopupCancelEventArgs e)
        {
            if (this.PopupCancel != null)
            {
                this.PopupCancel(this, e);
            }
            if (!e.Cancel)
            {
                owner.ClosePopup();
                // Clear reference for GC
                popup = null;
            }
        }
    }
}
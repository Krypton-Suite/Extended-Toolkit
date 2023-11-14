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

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    public class OwnerWindowChangedEventArgs : EventArgs
    {
        #region Variables
        private KryptonButton _button;

        private KryptonForm _window;
        #endregion

        #region Properties
        /// <summary>Gets or sets the button control.</summary>
        /// <value>The button control.</value>
        public KryptonButton ButtonControl { get => _button; set => _button = value; }

        /// <summary>Gets or sets the parent window.</summary>
        /// <value>The parent window.</value>
        public KryptonForm ParentWindow { get => _window; set => _window = value; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="OwnerWindowChangedEventArgs" /> class.</summary>
        /// <param name="buttonControl">The button control.</param>
        /// <param name="parentWindow">The parent window.</param>
        public OwnerWindowChangedEventArgs(KryptonButton buttonControl, KryptonForm parentWindow)
        {
            ButtonControl = buttonControl;

            ParentWindow = parentWindow;
        }
        #endregion

        #region Methods
        /// <summary>Associates the accept button.</summary>
        /// <param name="button">The button.</param>
        public void AssociateAcceptButton(KryptonButton button) => ParentWindow.AcceptButton = button;

        /// <summary>Associates the cancel button.</summary>
        /// <param name="button">The button.</param>
        public void AssociateCancelButton(KryptonButton button) => ParentWindow.CancelButton = button;
        #endregion
    }
}
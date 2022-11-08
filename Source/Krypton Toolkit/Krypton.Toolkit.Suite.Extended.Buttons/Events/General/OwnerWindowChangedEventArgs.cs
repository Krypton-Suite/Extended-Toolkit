#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
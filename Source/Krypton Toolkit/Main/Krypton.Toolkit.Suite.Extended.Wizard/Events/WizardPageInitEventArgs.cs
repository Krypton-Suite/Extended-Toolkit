#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// Arguments supplied to the <see cref="WizardPage.Initialize"/> event.
    /// </summary>
    public class WizardPageInitEventArgs : WizardPageConfirmEventArgs
    {
        internal WizardPageInitEventArgs(WizardPage page, WizardPage prevPage)
            : base(page)
        {
            PreviousPage = prevPage;
        }

        /// <summary>
        /// Gets the <see cref="WizardPage"/> that was previously selected when the event was raised.
        /// </summary>
        /// <value>The previous wizard page.</value>
        public WizardPage PreviousPage { get; }
    }
}
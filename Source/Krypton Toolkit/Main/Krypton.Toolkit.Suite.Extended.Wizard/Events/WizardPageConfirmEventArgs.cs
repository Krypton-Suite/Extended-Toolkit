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
    /// Arguments supplied to the <see cref="WizardPage"/> events.
    /// </summary>
    public class WizardPageConfirmEventArgs : EventArgs
    {
        internal WizardPageConfirmEventArgs(WizardPage page)
        {
            Cancel = false;
            Page = page;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this action is to be canceled or allowed.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c> to allow. Default is <c>false</c>.</value>
        [DefaultValue(false)]
        public bool Cancel { get; set; }

        /// <summary>
        /// Gets the <see cref="WizardPage"/> that has raised the event.
        /// </summary>
        /// <value>The wizard page.</value>
        public WizardPage Page { get; }
    }
}
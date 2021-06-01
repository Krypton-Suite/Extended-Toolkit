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
    /// A collection of <see cref="WizardPage"/> controls.
    /// </summary>
    public class WizardPageCollection : EventedList<WizardPage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WizardPageCollection"/> class.
        /// </summary>
        /// <param name="owner">The <see cref="WizardControl"/> that this collection belongs to.</param>
        internal WizardPageCollection(WizardPageContainer owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// Gets the <see cref="WizardControl"/> to which this collection belongs.
        /// </summary>
        /// <value>The <see cref="WizardControl"/>.</value>
        public WizardPageContainer Owner { get; }
    }
}
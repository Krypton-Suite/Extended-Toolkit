using System.Collections.Generic;

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
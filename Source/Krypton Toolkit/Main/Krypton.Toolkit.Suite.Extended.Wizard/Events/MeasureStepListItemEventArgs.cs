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
    /// Provides data for the <see cref="E:AeroWizard.StepWizardControl.MeasureStepListItem"/> event.
    /// </summary>
    public class MeasureStepListItemEventArgs : EventArgs
    {
        internal MeasureStepListItemEventArgs(Graphics graphics, Font font, WizardPage page, Size itemSize)
        {
            Graphics = graphics;
            Font = font;
            Item = page;
            ItemSize = itemSize;
        }

        /// <summary>
        /// Gets the <see cref="Font"/> used to draw the item.
        /// </summary>
        /// <value>
        /// The <see cref="Font"/> used to draw the item.
        /// </value>
        public Font Font { get; }

        /// <summary>
        /// Gets the <see cref="Graphics"/> used to draw the item.
        /// </summary>
        /// <value>
        /// The <see cref="Graphics"/> used to draw the item.
        /// </value>
        public Graphics Graphics { get; }

        /// <summary>
        /// Gets the <see cref="WizardPage"/> to which this item refers.
        /// </summary>
        /// <value>
        /// The <see cref="WizardPage"/> to which this item refers.
        /// </value>
        public WizardPage Item { get; }

        /// <summary>
        /// Gets or sets the size of the item.
        /// </summary>
        /// <value>
        /// The size of the item.
        /// </value>
        public Size ItemSize { get; set; }
    }
}
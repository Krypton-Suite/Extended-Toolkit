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
    /// Provides data for the <see cref="StepWizardControl.DrawStepListItem"/> event.
    /// </summary>
    public class DrawStepListItemEventArgs : EventArgs
    {
        internal DrawStepListItemEventArgs(Graphics graphics, Font font, Rectangle itemRect, WizardPage page, bool isSelected, bool isCompleted)
        {
            Graphics = graphics;
            Font = font;
            Bounds = itemRect;
            Item = page;
            Selected = isSelected;
            Completed = isCompleted;
        }

        /// <summary>
        /// Gets the size and location of the item to draw.
        /// </summary>
        /// <value>
        /// A rectangle that represents the bounds of the item to draw.
        /// </value>
        public Rectangle Bounds { get; }

        /// <summary>
        /// Gets a value indicating whether this step has already been completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if completed; otherwise, <c>false</c>.
        /// </value>
        public bool Completed { get; }

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
        /// Gets a value indicating whether this item is the one currently selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        public bool Selected { get; }
    }
}
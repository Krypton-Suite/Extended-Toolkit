#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourCollectionEventArgs : EventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ColourCollectionEventArgs"/> class for the specified color.
        /// </summary>
        /// <param name="index">The color index that the event is responding to.</param>
        /// <param name="colour">The %Color% that the event is responding to.</param>
        public ColourCollectionEventArgs(int index, Color colour)
        {
            this.Index = index;
            this.Colour = colour;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColourCollectionEventArgs"/> class.
        /// </summary>
        protected ColourCollectionEventArgs()
        { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the color that raised the event.
        /// </summary>
        /// <value>The color that raised the event.</value>
        public Color Colour { get; protected set; }

        /// <summary>
        /// Gets the color index that raised the event.
        /// </summary>
        /// <value>The color index that raised the event.</value>
        public int Index { get; protected set; }

        #endregion
    }
}
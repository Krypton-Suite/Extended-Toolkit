#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    /// <summary>
    /// Provides data for a cancelable event.
    /// </summary>
    public class ImageBoxExtendedCancelEventArgs : CancelEventArgs
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBoxExtendedCancelEventArgs"/> class.
        /// </summary>
        /// <param name="location">The location of the action being performed.</param>
        public ImageBoxExtendedCancelEventArgs(Point location)
          : this()
        {
            this.Location = location;
        }

        #endregion

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBoxExtendedCancelEventArgs"/> class.
        /// </summary>
        protected ImageBoxExtendedCancelEventArgs()
        { }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the location of the action being performed.
        /// </summary>
        /// <value>The location of the action being performed.</value>
        public Point Location { get; protected set; }

        #endregion
    }
}
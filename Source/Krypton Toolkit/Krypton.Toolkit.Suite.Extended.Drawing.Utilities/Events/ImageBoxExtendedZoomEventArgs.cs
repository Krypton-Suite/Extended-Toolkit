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
    /// Contains event data for the <see cref="ImageBoxExtended.ZoomChanged"/> event.
    /// </summary>
    public class ImageBoxExtendedZoomEventArgs : EventArgs
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBoxExtendedZoomEventArgs"/> class.
        /// </summary>
        /// <param name="actions">The zoom operation being performed.</param>
        /// <param name="source">The source of the operation.</param>
        /// <param name="oldZoom">The old zoom level.</param>
        /// <param name="newZoom">The new zoom level.</param>
        public ImageBoxExtendedZoomEventArgs(ImageBoxZoomActions actions, ImageBoxActionSources source, int oldZoom, int newZoom)
          : this()
        {
            this.Actions = actions;
            this.Source = source;
            this.OldZoom = oldZoom;
            this.NewZoom = newZoom;
        }

        #endregion

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageBoxExtendedZoomEventArgs"/> class.
        /// </summary>
        protected ImageBoxExtendedZoomEventArgs()
        { }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the actions that occured.
        /// </summary>
        /// <value>The zoom operation.</value>
        public ImageBoxZoomActions Actions { get; protected set; }

        /// <summary>
        /// Gets or sets the new zoom level.
        /// </summary>
        /// <value>The new zoom level.</value>
        public int NewZoom { get; protected set; }

        /// <summary>
        /// Gets or sets the old zoom level.
        /// </summary>
        /// <value>The old zoom level.</value>
        public int OldZoom { get; protected set; }

        /// <summary>
        /// Gets or sets the source of the operation..
        /// </summary>
        /// <value>The source.</value>
        public ImageBoxActionSources Source { get; protected set; }

        #endregion
    }
}
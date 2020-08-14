#region License
/*
 * Cyotek ImageBox
 * Copyright (c) 2010 - 2020 Cyotek Ltd.
 * http://cyotek.com
 * http://cyotek.com/blog/tag/imagebox
 *
 * Licensed under the MIT License.See license.txt for the full text.
 *
 *  If you use this control in your applications, attribution, donations or contributions are welcome.
 */
#endregion

using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
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
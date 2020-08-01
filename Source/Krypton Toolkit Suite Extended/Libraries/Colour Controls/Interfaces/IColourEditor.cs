using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    /// <summary>
    /// Provides functionality required by colour editors that are bindable
    /// </summary>
    public interface IColourEditor
    {
        #region Events

        /// <summary>
        /// Occurs when the <see cref="Color"/> property is changed.
        /// </summary>
        event EventHandler ColourChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the component colour.
        /// </summary>
        /// <value>The component colour.</value>
        Color Colour { get; set; }

        #endregion
    }
}
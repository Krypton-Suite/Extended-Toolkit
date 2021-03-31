using System;
using System.Drawing;

namespace Cyotek.Windows.Forms.Colour.Picker
{
    /// <summary>
    /// Provides functionality required by color editors that are bindable
    /// </summary>
    public interface IColourEditor
    {
        #region Events

        /// <summary>
        /// Occurs when the <see cref="Colour"/> property is changed.
        /// </summary>
        event EventHandler ColourChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the component color.
        /// </summary>
        /// <value>The component color.</value>
        Color Colour { get; set; }

        #endregion
    }
}
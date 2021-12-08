#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
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
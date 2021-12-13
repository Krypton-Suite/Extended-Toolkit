#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public interface IColourConfigurator
    {
        /// <summary>Gets or sets the alpha value.</summary>
        /// <value>The alpha value.</value>
        byte AlphaValue { get; set; }

        /// <summary>Gets or sets the red value.</summary>
        /// <value>The red value.</value>
        byte RedValue { get; set; }

        /// <summary>Gets or sets the green value.</summary>
        /// <value>The green value.</value>
        byte GreenValue { get; set; }

        /// <summary>Gets or sets the blue value.</summary>
        /// <value>The blue value.</value>
        byte BlueValue { get; set; }

        /// <summary>Gets or sets the colour.</summary>
        /// <value>The colour.</value>
        Color Colour { get; set; }
    }
}
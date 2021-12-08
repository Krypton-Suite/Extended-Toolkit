#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public interface IThemeOptions
    {
        /// <summary>Gets or sets the palette mode.</summary>
        /// <value>The palette mode.</value>
        PaletteMode PaletteMode { get; set; }

        /// <summary>
        /// Gets or sets the krypton manager.
        /// </summary>
        /// <value>
        /// The krypton manager.
        /// </value>
        KryptonManager KryptonManager { get; set; }

        /// <summary>Gets or sets the palette mode container.</summary>
        /// <value>The palette mode container.</value>
        ComboBox PaletteModesComboBox { get; set; }

        /// <summary>Gets or sets the palette modes krypton combo box.</summary>
        /// <value>The palette modes krypton combo box.</value>
        KryptonComboBox PaletteModesKryptonComboBox { get; set; }

        /// <summary>Gets or sets the reset to default control.</summary>
        /// <value>The reset to default control.</value>
        Control ResetToDefaultsControl { get; set; }

        /// <summary>Gets or sets the ok control.</summary>
        /// <value>The ok control.</value>
        Control OkControl { get; set; }

        /// <summary>Gets or sets the cancel control.</summary>
        /// <value>The cancel control.</value>
        Control CancelControl { get; set; }

        /// <summary>Gets or sets the apply control.</summary>
        /// <value>The apply control.</value>
        Control ApplyControl { get; set; }

        /// <summary>Gets or sets the palette file path control.</summary>
        /// <value>The palette file path control.</value>
        Control PaletteFilePathControl { get; set; }

        /// <summary>Gets or sets the browse for palette file path control.</summary>
        /// <value>The browse for palette file path control.</value>
        Control BrowseForPaletteFilePathControl { get; set; }

        /// <summary>Gets or sets the load palette file path control.</summary>
        /// <value>The load palette file path control.</value>
        Control LoadPaletteFilePathControl { get; set; }

        /// <summary>
        /// Gets or sets the custom palette label.
        /// </summary>
        /// <value>
        /// The custom palette label.
        /// </value>
        Control CustomPaletteLabel { get; set; }

        /// <summary>Gets or sets the update UI control.</summary>
        /// <value>The update UI control.</value>
        Timer UpdateUIControl { get; set; }
    }
}
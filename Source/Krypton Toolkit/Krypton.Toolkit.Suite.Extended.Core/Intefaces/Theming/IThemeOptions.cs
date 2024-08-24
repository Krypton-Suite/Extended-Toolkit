#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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
        System.Windows.Forms.Timer UpdateUIControl { get; set; }
    }
}
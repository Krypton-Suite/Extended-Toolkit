#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Ribbon
{
    public class KryptonRibbonGroupThemeComboBox : KryptonRibbonGroupComboBox
    {
        #region Instance Fields

        private readonly ICollection<string> _supportedThemesNames;
        private int _selectedIndex;

        #endregion

        #region Public

        /// <summary>
        /// Helper, to return a new list of names
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<string> SupportedThemesList => _supportedThemesNames.ToList();

        /// <summary>
        /// Gets and sets the ThemeSelectedIndex.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Theme Selected Index. (Default = `Office 365 - Blue`)")]
        [DefaultValue(33)]
        public int ThemeSelectedIndex
        {
            get => _selectedIndex;

            set => SelectedIndex = value;
        }

        private void ResetThemeSelectedIndex() => _selectedIndex = 33;

        private bool ShouldSerializeThemeSelectedIndex() => _selectedIndex != 33;

        /// <summary>
        /// Gets and sets the ThemeSelectedIndex.
        /// </summary>
        [Category(@"Visuals")]
        [Description(@"Custom Theme to use when `Custom` is selected")]
        [DefaultValue(null)]
        public KryptonCustomPaletteBase KryptonCustomPalette { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public KryptonManager Manager
        {
            get;

        } = new KryptonManager();

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="KryptonRibbonGroupThemeComboBox" /> class.</summary>
        public KryptonRibbonGroupThemeComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;

            _supportedThemesNames = KryptonRibbonThemeManager.SupportedInternalThemeNames;

            _selectedIndex = 33;
        }

        #endregion

        #region Implementation

        /// <summary>Returns the palette mode.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public PaletteMode ReturnPaletteMode() => Manager.GlobalPaletteMode;

        #endregion

        #region Protected Overrides

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            KryptonRibbonThemeManager.ApplyTheme(Text, Manager);

            ThemeSelectedIndex = SelectedIndex;

            base.OnSelectedIndexChanged(e);

            if (KryptonRibbonThemeManager.GetThemeManagerMode(Text) == PaletteMode.Custom && KryptonCustomPalette != null)
            {
                Manager.GlobalCustomPalette = KryptonCustomPalette;
            }
        }

        #endregion
    }
}
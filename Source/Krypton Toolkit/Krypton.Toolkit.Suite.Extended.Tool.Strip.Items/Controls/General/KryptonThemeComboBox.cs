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

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [Description("")]
    public class KryptonThemeComboBox : ToolStripComboBox
    {
        #region Instances

        private KryptonManager _manager = null;

        #endregion

        #region Properties

        public KryptonManager KryptonManager { get => _manager; set => _manager = value; }

        #endregion

        #region Identity

        public KryptonThemeComboBox()
        {
            // Set initial size
            Size = new Size(200, 23);

            // Set drop down width
            DropDownWidth = 200;

            // Set drop down style
            DropDownStyle = ComboBoxStyle.DropDownList;

            // Set autocomplete mode
            AutoCompleteSource = AutoCompleteSource.ListItems;

            AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            ThemeManager.PropagateThemeSelector(this);
        }

        #endregion

        #region Protected

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            ThemeManager.ApplyTheme(Text, KryptonManager);

            base.OnSelectedIndexChanged(e);
        }

        #endregion
    }
}
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

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    public class KryptonNavigatorEditor : KryptonNavigator
    {
        #region Properties

        public KryptonRichTextBox KryptonRichTextBox => GeKryptonRichTextBox(SelectedPage);

        public string? SelectedText => SelectedPage?.Controls[0].Text;

        #endregion

        #region Constructor

        public KryptonNavigatorEditor()
        {

        }

        #endregion

        #region Methods

        public KryptonRichTextBox CreateKryptonRichTextBox()
        {
            KryptonRichTextBox kryptonRichTextBox = new KryptonRichTextBox();

            kryptonRichTextBox.Multiline = true;

            kryptonRichTextBox.Dock = DockStyle.Fill;

            return kryptonRichTextBox;
        }

        public KryptonRichTextBox? GeKryptonRichTextBox(KryptonPage? page)
        {
            KryptonRichTextBox? kryptonRichTextBox = null;

            KryptonPage? kryptonPage = page;

            if (kryptonPage != null)
            {
                kryptonRichTextBox = kryptonPage.Controls[0] as KryptonRichTextBox;
            }

            return kryptonRichTextBox;
        }

        #endregion

        #region Overrides

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            e.Control.Controls.Add(CreateKryptonRichTextBox());
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        #endregion
    }
}

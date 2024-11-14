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
    [ToolboxBitmap(typeof(KryptonTextBox)), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class KryptonToolStripTextBox : ToolStripControlHost
    {
        #region Properties
        public KryptonTextBox? KryptonTextBox => Control as KryptonTextBox;

        #endregion

        #region Constructor
        public KryptonToolStripTextBox() : base(CreateControlInstance())
        {

        }
        #endregion

        #region Overrides
        protected override void OnSubscribeControlEvents(Control control)
        {
            var kryptonTextBox = control as KryptonTextBox;

            kryptonTextBox!.TextAlignChanged += TextAlignChanged;

            kryptonTextBox.TextChanged += Text_Changed;

            kryptonTextBox.FontChanged += FontChanged;

            base.OnSubscribeControlEvents(control);
        }

        protected override void OnUnsubscribeControlEvents(Control control)
        {
            var kryptonTextBox = control as KryptonTextBox;

            kryptonTextBox!.TextAlignChanged -= TextAlignChanged;

            kryptonTextBox.TextChanged -= Text_Changed;

            kryptonTextBox.FontChanged -= FontChanged;

            base.OnUnsubscribeControlEvents(control);
        }
        #endregion

        #region Methods
        private static Control CreateControlInstance()
        {
            KryptonTextBox kryptonTextBox = new KryptonTextBox();

            //TODO: Add other initialization code here.


            return kryptonTextBox;
        }
        #endregion

        #region Event Handlers
        private void Text_Changed(object sender, EventArgs e)
        {
            //if (KryptonTextBox.TextChanged)
            //{

            //}
        }

        private void TextAlignChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FontChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
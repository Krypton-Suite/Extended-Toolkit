#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    public class ClearClipboard : ToolStripItem // MenuItem
    {
        #region Variables

        #endregion

        #region Constructor
        public ClearClipboard()
        {
            Text = "Clear &&Clipboard";
        }
        #endregion

        #region Methods
        private bool IsClipboardEmpty() => Clipboard.ContainsText();
        #endregion

        #region Overrides
        protected override void OnClick(EventArgs e)
        {
            if (!IsClipboardEmpty()) Clipboard.Clear();

            base.OnClick(e);
        }
        #endregion
    }
}
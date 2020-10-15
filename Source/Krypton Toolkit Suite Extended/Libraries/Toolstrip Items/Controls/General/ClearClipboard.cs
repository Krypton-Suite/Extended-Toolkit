using System;
using System.Windows.Forms;

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
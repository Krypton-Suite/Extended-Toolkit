using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    public class KryptonEditorTabControlVersion1 : KryptonTabControlVersion1
    {
        #region Properties
        public bool IsRichTextBoxMultiline => ((KryptonRichTextBox)base.SelectedTab.Controls[0]).Multiline;

        public string SelectedText => base.SelectedTab.Controls[0].Text;
        #endregion

        #region Constructor
        public KryptonEditorTabControlVersion1()
        {

        }
        #endregion

        #region Methods
        public KryptonRichTextBox CreateKryptonRichTextBox() => new KryptonRichTextBox() { Multiline = true, Dock = DockStyle.Fill };

        public KryptonRichTextBox GetKryptonRichTextBox(TabPage page)
        {
            KryptonRichTextBox richTextBox = new KryptonRichTextBox();

            richTextBox = null;

            TabPage tabPage = page;

            if (tabPage != null)
            {
                richTextBox = tabPage.Controls[0] as KryptonRichTextBox;
            }

            return richTextBox;
        }
        #endregion

        #region Overrides
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            e.Control.Controls.Add(this.CreateKryptonRichTextBox());
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }
        #endregion
    }
}
using Krypton.Navigator;
using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    public class KryptonEditorNavigator : KryptonNavigator
    {
        #region Properties
        public bool IsRichTextBoxMultiline => ((KryptonRichTextBox)base.SelectedPage.Controls[0]).Multiline;

        public string SelectedText => base.SelectedPage.Controls[0].Text;
        #endregion

        #region Constructor
        public KryptonEditorNavigator()
        {

        }
        #endregion

        #region Methods
        public KryptonRichTextBox CreateKryptonRichTextBox() => new KryptonRichTextBox() { Multiline = true, Dock = DockStyle.Fill };

        public KryptonRichTextBox GetKryptonRichTextBox(KryptonPage page)
        {
            KryptonRichTextBox richTextBox = new KryptonRichTextBox();

            richTextBox = null;

            KryptonPage kryptonPage = page;

            if (kryptonPage != null)
            {
                richTextBox = kryptonPage.Controls[0] as KryptonRichTextBox;
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
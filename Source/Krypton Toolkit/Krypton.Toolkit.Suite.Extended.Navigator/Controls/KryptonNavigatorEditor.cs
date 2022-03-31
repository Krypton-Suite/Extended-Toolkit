namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    public class KryptonNavigatorEditor : KryptonNavigator
    {
        #region Properties

        public KryptonRichTextBox KryptonRichTextBox => GeKryptonRichTextBox(SelectedPage);

        public string SelectedText => SelectedPage.Controls[0].Text;

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

        public KryptonRichTextBox GeKryptonRichTextBox(KryptonPage page)
        {
            KryptonRichTextBox kryptonRichTextBox = null;

            KryptonPage kryptonPage = page;

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

            e.Control.Controls.Add((Control)CreateKryptonRichTextBox());
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        #endregion
    }
}

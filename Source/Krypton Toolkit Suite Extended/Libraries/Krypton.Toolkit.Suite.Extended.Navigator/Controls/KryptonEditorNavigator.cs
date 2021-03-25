using Krypton.Navigator;
using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class KryptonEditorNavigator : KryptonNavigator
    {
        #region Properties
        /// <summary>Gets a value indicating whether this instance is rich text box multiline.</summary>
        /// <value><c>true</c> if this instance is rich text box multiline; otherwise, <c>false</c>.</value>
        public bool IsRichTextBoxMultiline => ((KryptonRichTextBox)base.SelectedPage.Controls[0]).Multiline;

        /// <summary>Gets the selected text.</summary>
        /// <value>The selected text.</value>
        public string SelectedText => base.SelectedPage.Controls[0].Text;
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonEditorNavigator" /> class.</summary>
        public KryptonEditorNavigator()
        {

        }
        #endregion

        #region Methods
        /// <summary>Creates the krypton rich text box.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public KryptonRichTextBox CreateKryptonRichTextBox() => new KryptonRichTextBox() { Multiline = true, Dock = DockStyle.Fill };

        /// <summary>Gets the krypton rich text box.</summary>
        /// <param name="page">The page.</param>
        /// <returns>
        ///   <br />
        /// </returns>
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
        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.ControlAdded">ControlAdded</see> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs">ControlEventArgs</see> that contains the event data.</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            e.Control.Controls.Add(this.CreateKryptonRichTextBox());
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.TextChanged">TextChanged</see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs">EventArgs</see> that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }
        #endregion
    }
}
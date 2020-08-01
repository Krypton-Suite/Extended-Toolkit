using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonAbortDialogButton : KryptonButton
    {
        private Language.Model.Language _language;

        private KryptonForm _parent;

        public Language.Model.Language ChosenLanguage { get => _language; set { _language = value; Invalidate(); } }

        public KryptonForm ParentWindow { get => _parent; set { _parent = value; Invalidate(); } }

        public KryptonAbortDialogButton()
        {
            ChosenLanguage = Language.Model.Language.ENGLISH;

            DialogResult = DialogResult.Abort;

            ParentChanged += KryptonAbortDialogButton_ParentChanged;

            TextChanged += KryptonAbortDialogButton_TextChanged;
        }

        private void KryptonAbortDialogButton_TextChanged(object sender, EventArgs e)
        {
            if (Text == Name) Text = "&Abort";
        }

        private void KryptonAbortDialogButton_ParentChanged(object sender, EventArgs e)
        {
            Control parent = Parent;

            while (!(Parent is KryptonForm) && !(parent == null))
            {
                parent = parent.Parent;
            }

            if (parent is KryptonForm)
            {
                KryptonForm form = (KryptonForm)parent;

                form.CancelButton = this;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (ParentWindow != null)
            {
                ParentWindow.CancelButton = this;
            }

            base.OnPaint(e);
        }
    }
}
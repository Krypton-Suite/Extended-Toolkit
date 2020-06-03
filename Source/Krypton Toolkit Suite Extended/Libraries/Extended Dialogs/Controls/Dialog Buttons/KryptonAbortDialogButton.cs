using Krypton.Toolkit.Suite.Extended.Language.Model;
using Krypton.Toolkit.Suite.Extended.Standard.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    [ToolboxBitmap(typeof(KryptonButtonExtended))]
    public class KryptonAbortDialogButton : KryptonButtonExtended
    {
        private Language _language = Language.ENGLISH;

        public Language Language { get => _language; set { _language = value; Invalidate(); } }

        public KryptonAbortDialogButton()
        {
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
    }
}
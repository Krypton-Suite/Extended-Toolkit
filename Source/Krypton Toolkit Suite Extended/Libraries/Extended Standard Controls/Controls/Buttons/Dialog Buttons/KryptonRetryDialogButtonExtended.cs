using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Standard.Controls
{
    [ToolboxBitmap(typeof(KryptonButtonExtended))]
    public class KryptonRetryDialogButtonExtended : KryptonButtonExtended
    {
        public KryptonRetryDialogButtonExtended()
        {
            DialogResult = DialogResult.Retry;

            ParentChanged += KryptonRetryDialogButton_ParentChanged;

            TextChanged += KryptonRetryDialogButton_TextChanged;
        }

        private void KryptonRetryDialogButton_TextChanged(object sender, EventArgs e)
        {
            if (Text == Name) Text = "&Retry";
        }

        private void KryptonRetryDialogButton_ParentChanged(object sender, EventArgs e)
        {
            Control parent = Parent;

            while (!(Parent is KryptonForm) && !(parent == null))
            {
                parent = parent.Parent;
            }

            if (parent is KryptonForm)
            {
                KryptonForm form = (KryptonForm)parent;

                form.AcceptButton = this;
            }
        }
    }
}
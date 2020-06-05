using Krypton.Toolkit.Suite.Extended.Standard.Controls;
using System;

namespace Krypton.Toolkit.Extended.Standard.Controls
{
    [ToolboxBitmap(typeof(KryptonButtonExtended))]
    public class KryptonAbortDialogButtonExtended : KryptonButtonExtended
    {
        private Language _language = Language.ENGLISH;

        private KryptonForm _parent;

        public Language Language { get => _language; set { _language = value; Invalidate(); } }

        public KryptonForm Parent { get => _parent; set { _parent = value; Invalidate(); } }

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
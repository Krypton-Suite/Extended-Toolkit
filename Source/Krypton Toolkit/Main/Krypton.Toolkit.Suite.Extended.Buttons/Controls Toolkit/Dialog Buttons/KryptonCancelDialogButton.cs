using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonCancelDialogButton : KryptonButton
    {
        private KryptonForm _parent;

        public KryptonForm ParentWindow { get => _parent; set { _parent = value; Invalidate(); } }

        public KryptonCancelDialogButton()
        {
            DialogResult = DialogResult.Cancel;

            ParentChanged += KryptonCancelDialogButton_ParentChanged;

            TextChanged += KryptonCancelDialogButton_TextChanged;
        }

        private void KryptonCancelDialogButton_TextChanged(object sender, EventArgs e)
        {
            if (Text == Name)
            {
                Text = "C&ancel";
            }
        }

        private void KryptonCancelDialogButton_ParentChanged(object sender, EventArgs e)
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
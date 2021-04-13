using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonOKDialogButton : KryptonButton
    {
        private KryptonForm _parent;

        public KryptonForm ParentWindow { get => _parent; set { _parent = value; Invalidate(); } }

        public KryptonOKDialogButton()
        {
            DialogResult = DialogResult.OK;

            ParentChanged += KryptonOKDialogButton_ParentChanged;

            TextChanged += KryptonOKDialogButton_TextChanged;
        }

        private void KryptonOKDialogButton_TextChanged(object sender, EventArgs e)
        {
            if (Text == Name) Text = "&OK";
        }

        private void KryptonOKDialogButton_ParentChanged(object sender, EventArgs e)
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

        protected override void OnPaint(PaintEventArgs e)
        {
            if (ParentWindow != null)
            {
                ParentWindow.AcceptButton = this;
            }

            base.OnPaint(e);
        }
    }
}
﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonNODialogButton : KryptonButton
    {
        public KryptonNODialogButton()
        {
            DialogResult = DialogResult.No;

            TextChanged += KryptonNODialogButton_TextChanged;

            ParentChanged += KryptonNODialogButton_ParentChanged;
        }

        private void KryptonNODialogButton_ParentChanged(object sender, EventArgs e)
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

        private void KryptonNODialogButton_TextChanged(object sender, EventArgs e)
        {
            if (Text == Name) Text = "&No";
        }
    }
}
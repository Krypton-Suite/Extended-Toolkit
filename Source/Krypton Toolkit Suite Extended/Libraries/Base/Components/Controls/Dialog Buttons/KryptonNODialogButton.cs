﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Core;
using Krypton.Toolkit;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkt.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonNODialogButton : KryptonButton
    {
        private KryptonForm _parent;

        public KryptonForm ParentWindow { get => _parent; set { _parent = value; Invalidate(); OwnerWindowChangedEventArgs e = new OwnerWindowChangedEventArgs(this, value); OnParentWindowChanged(null, e); } }

        #region Custom Events
        public delegate void ParentWindowChangedEventHandler(object sender, OwnerWindowChangedEventArgs e);

        public event ParentWindowChangedEventHandler ParentWindowChanged;

        protected virtual void OnParentWindowChanged(object sender, OwnerWindowChangedEventArgs e) => ParentWindowChanged?.Invoke(sender, e);
        #endregion

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

        protected override void OnPaint(PaintEventArgs e)
        {
            if (ParentWindow != null)
            {
                OwnerWindowChangedEventArgs ev = new OwnerWindowChangedEventArgs(this, ParentWindow);

                ev.AssociateCancelButton(this);
            }

            base.OnPaint(e);
        }
    }
}
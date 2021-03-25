﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonOKDialogButton : KryptonButton
    {
        private KryptonForm _parent;

        public KryptonForm ParentWindow { get => _parent; set { _parent = value; Invalidate(); OwnerWindowChangedEventArgs e = new OwnerWindowChangedEventArgs(this, value); OnParentWindowChanged(null, e); } }

        #region Custom Events
        public delegate void ParentWindowChangedEventHandler(object sender, OwnerWindowChangedEventArgs e);

        public event ParentWindowChangedEventHandler ParentWindowChanged;

        protected virtual void OnParentWindowChanged(object sender, OwnerWindowChangedEventArgs e) => ParentWindowChanged?.Invoke(sender, e);
        #endregion

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
                OwnerWindowChangedEventArgs ev = new OwnerWindowChangedEventArgs(this, ParentWindow);

                ev.AssociateAcceptButton(this);
            }

            base.OnPaint(e);
        }
    }
}
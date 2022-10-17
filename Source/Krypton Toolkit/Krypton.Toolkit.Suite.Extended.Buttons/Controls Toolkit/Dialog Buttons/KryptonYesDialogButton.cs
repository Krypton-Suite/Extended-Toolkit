#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonYesDialogButton : KryptonButton
    {
        private KryptonForm _parent;

        public KryptonForm ParentWindow { get => _parent; set { _parent = value; Invalidate(); OwnerWindowChangedEventArgs e = new OwnerWindowChangedEventArgs(this, value); OnParentWindowChanged(null, e); } }

        #region Custom Events
        public delegate void ParentWindowChangedEventHandler(object sender, OwnerWindowChangedEventArgs e);

        public event ParentWindowChangedEventHandler ParentWindowChanged;

        protected virtual void OnParentWindowChanged(object sender, OwnerWindowChangedEventArgs e) => ParentWindowChanged?.Invoke(sender, e);
        #endregion

        public KryptonYesDialogButton()
        {
            DialogResult = DialogResult.Yes;

            ParentChanged += KryptonYesDialogButton_ParentChanged;

            TextChanged += KryptonYesDialogButton_TextChanged;
        }

        private void KryptonYesDialogButton_TextChanged(object sender, EventArgs e)
        {
            if (Text == Name) Text = "&Yes";
        }

        private void KryptonYesDialogButton_ParentChanged(object sender, EventArgs e)
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
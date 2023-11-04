#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonNODialogButton : KryptonButton
    {
        private KryptonForm _parent;

        public KryptonForm ParentWindow { get => _parent; set { _parent = value; Invalidate(); OwnerWindowChangedEventArgs e = new(this, value); OnParentWindowChanged(null, e); } }

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

            while (!(Parent is KryptonForm) && parent != null)
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
            if (Text == Name)
            {
                Text = KryptonLanguageManager.GeneralToolkitStrings.No;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (ParentWindow != null)
            {
                OwnerWindowChangedEventArgs ev = new(this, ParentWindow);

                ev.AssociateCancelButton(this);
            }

            base.OnPaint(e);
        }
    }
}
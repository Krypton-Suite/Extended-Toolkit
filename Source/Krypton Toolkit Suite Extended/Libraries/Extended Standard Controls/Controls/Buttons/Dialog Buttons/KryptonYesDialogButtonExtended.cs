#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Standard.Controls
{
    [ToolboxBitmap(typeof(KryptonButtonExtended))]
    public class KryptonYesDialogButtonExtended : KryptonButtonExtended
    {
        public KryptonYesDialogButtonExtended()
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
    }
}
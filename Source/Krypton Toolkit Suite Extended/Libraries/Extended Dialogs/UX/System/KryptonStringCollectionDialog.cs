#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonStringCollectionDialog : KryptonForm
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // KryptonStringCollectionDialog
            // 
            this.ClientSize = new System.Drawing.Size(579, 356);
            this.Name = "KryptonStringCollectionDialog";
            this.Load += new System.EventHandler(this.KryptonStringCollectionDialog_Load);
            this.ResumeLayout(false);

        }

        private void KryptonStringCollectionDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
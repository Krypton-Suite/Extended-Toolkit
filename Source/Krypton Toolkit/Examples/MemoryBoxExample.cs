using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Memory.Box;

namespace Examples
{
    public partial class MemoryBoxExample : KryptonForm
    {
        public MemoryBoxExample()
        {
            InitializeComponent();
        }

        private void kbtnShow_Click(object sender, EventArgs e)
        {
            KryptonMemoryBox.Show(@"Hello World",
                @"Hello, this is a KryptonMemoryBox example.", KryptonMemoryBoxIcon.Information, null,
                KryptonMemoryBoxDefaultButton.ButtonOne, KryptonMemoryBoxDialogResult.Cancel);
        }
    }
}

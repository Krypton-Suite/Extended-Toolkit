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

namespace TestApp
{
    public partial class FloatableToolStripsMenu : KryptonForm
    {
        public FloatableToolStripsMenu()
        {
            InitializeComponent();
        }

        private void kbtnFloatableMenuStrip_Click(object sender, EventArgs e)
        {
            FloatingMenuStripExample floatingMenuStrip = new FloatingMenuStripExample();

            floatingMenuStrip.Show();
        }

        private void kbtnFloatableToolStrip_Click(object sender, EventArgs e)
        {
            FloatingToolStripExample floatingToolStripExample = new FloatingToolStripExample();

            floatingToolStripExample.Show();
        }
    }
}

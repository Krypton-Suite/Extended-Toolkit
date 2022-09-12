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
    public partial class FloatingMenuToolbarExampleMain : KryptonForm
    {
        public FloatingMenuToolbarExampleMain()
        {
            InitializeComponent();
        }

        private void kbtnFloatingAdvanced_Click(object sender, EventArgs e)
        {
            FloatingMenuToolbarAdvancedExample floatingMenuToolbarAdvanced = new FloatingMenuToolbarAdvancedExample();

            floatingMenuToolbarAdvanced.Show();
        }
    }
}

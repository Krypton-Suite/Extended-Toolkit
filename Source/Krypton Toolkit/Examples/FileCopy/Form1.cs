using System;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.File.Copier;

namespace FileCopy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            KryptonFileCopier copier = new KryptonFileCopier();

            copier.ShowDialog();
        }
    }
}

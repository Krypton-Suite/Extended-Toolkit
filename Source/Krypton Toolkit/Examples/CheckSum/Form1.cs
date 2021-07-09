using System;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.CheckSum.Tools;

namespace CheckSum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            KryptonComputeFileCheckSum computeFileCheckSum = new KryptonComputeFileCheckSum();

            computeFileCheckSum.ShowDialog();
        }
    }
}

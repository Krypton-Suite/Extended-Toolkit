using System;

using Krypton.Toolkit;

using Krypton.Toolkit.Suite.Extended.CheckSum.Tools;

namespace CheckSum
{
    public partial class Form1 : KryptonForm
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

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            KryptonVarifyFileCheckSum varifyFileCheckSum = new KryptonVarifyFileCheckSum();

            varifyFileCheckSum.ShowDialog();
        }
    }
}

using System;
using Krypton.Toolkit;

namespace PropertyGrid
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void circularPictureBox1_Click(object sender, EventArgs e)
        {
            kpg.SelectedObject = circularPictureBox1;
        }

        private void kryptonBorderedLabel1_Click(object sender, EventArgs e)
        {
            kpg.SelectedObject = kryptonBorderedLabel1;
        }

        private void kryptonCommandLinkButton1_Click(object sender, EventArgs e)
        {
            kpg.SelectedObject = kryptonCommandLinkButton1;
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {
            kpg.SelectedObject = circularProgressBar1;
        }
    }
}

using System;

using Krypton.Toolkit;

namespace DrawingUtilities
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Form2 kryptonForm2 = new Form2();

            kryptonForm2.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Form3 kryptonForm3 = new Form3();

            kryptonForm3.ShowDialog();
        }
    }
}

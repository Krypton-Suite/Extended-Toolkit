using System;

using Krypton.Toolkit;

namespace Controls
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ktxtValidationText_TextChanged(object sender, EventArgs e)
        {
            kryptonValidationBox1.SetValidValue(ktxtValidationText.Text);
        }
    }
}

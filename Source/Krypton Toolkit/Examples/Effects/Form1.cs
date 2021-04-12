using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Effects;
using System;

namespace Effects
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            FadeController.FadeIn(new TestWindow(), 5);
        }
    }
}

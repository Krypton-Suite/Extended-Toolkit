using System;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Effects;

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
            var testWindow = new TestWindow();
            FadeController.FadeIn(testWindow, FadeSpeed.Slower, testWindow.FadeInComplete);
        }
    }
}

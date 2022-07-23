using Krypton.Toolkit;

namespace TestApp
{
    public partial class CircularProgressBarExample : KryptonForm
    {
        public CircularProgressBarExample()
        {
            InitializeComponent();
        }

        private void kryptonTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            circularProgressBar1.Value = (int)kryptonTrackBar1.Value;

            circularProgressBar1.Text = $"{kryptonTrackBar1.Value}%";
        }

        private void kryptonCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            circularProgressBar1.UseColourTrio = kryptonCheckBox1.Checked;
        }
    }
}

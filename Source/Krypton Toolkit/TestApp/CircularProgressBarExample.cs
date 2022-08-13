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
            circularProgressBar1.UseColourTrio = kcbUseColourTrio.Checked;

            EnableColourButtons(kcbUseColourTrio.Checked);
        }

        private void EnableColourButtons(bool enabled)
        {
            kcbFirstColour.Enabled = enabled;

            kcbSecondColour.Enabled = enabled;

            kcbThirdColour.Enabled = enabled;
        }

        private void CircularProgressBarExample_Load(object sender, EventArgs e)
        {
            EnableColourButtons(false);

            kcbFirstColour.SelectedColor = circularProgressBar1.FirstValueColour;

            kcbSecondColour.SelectedColor = circularProgressBar1.SecondValueColour;

            kcbThirdColour.SelectedColor = circularProgressBar1.ThirdValueColour;
        }

        private void kcbFirstColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            circularProgressBar1.FirstValueColour = kcbFirstColour.SelectedColor;
        }

        private void kcbSecondColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            circularProgressBar1.SecondValueColour = kcbSecondColour.SelectedColor;
        }

        private void kcbThirdColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            circularProgressBar1.ThirdValueColour = kcbThirdColour.SelectedColor;
        }
    }
}

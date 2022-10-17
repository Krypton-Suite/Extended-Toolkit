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

        private void kcbUseColourTrio_CheckedChanged(object sender, EventArgs e)
        {
            EnableColourTrioUI(kcbUseColourTrio.Checked);

            circularProgressBar1.UseColourTrio = kcbUseColourTrio.Checked;
        }

        private void EnableColourTrioUI(bool enabled)
        {
            kcbtnFirstColour.Enabled = enabled;

            kcbtnSecondColour.Enabled = enabled;

            kcbtnThirdColour.Enabled = enabled;
        }

        private void kcbtnFirstColour_SelectedColorChanged(object sender, ColorEventArgs e) => circularProgressBar1.FirstValueColour = e.Color;

        private void kcbtnSecondColour_SelectedColorChanged(object sender, ColorEventArgs e) => circularProgressBar1.SecondValueColour = e.Color;

        private void kcbtnThirdColour_SelectedColorChanged(object sender, ColorEventArgs e) => circularProgressBar1.ThirdValueColour = e.Color;

        private void kcbtnProgressColour_SelectedColorChanged(object sender, ColorEventArgs e) => circularProgressBar1.ProgressColour = e.Color;
    }
}

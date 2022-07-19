using Krypton.Toolkit;

namespace TestApp
{
    public partial class CircularProgressBarExample : KryptonForm
    {
        public CircularProgressBarExample()
        {
            InitializeComponent();
        }

        private void CircularProgressBarExample_Load(object sender, EventArgs e)
        {
            cpbExample.Text = "0%";
        }

        private void ktbProgressValue_ValueChanged(object sender, EventArgs e)
        {
            cpbExample.Value = ktbProgressValue.Value;

            cpbExample.Text = $"{cpbExample.Value}%";
        }

        private void kcbUseColourTrio_CheckedChanged(object sender, EventArgs e) => cpbExample.UseColourTrio = kcbUseColourTrio.Checked;
    }
}

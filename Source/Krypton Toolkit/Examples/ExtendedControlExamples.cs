namespace Examples
{
    public partial class ExtendedControlExamples : KryptonForm
    {
        public ExtendedControlExamples()
        {
            InitializeComponent();
        }

        private void kkTest1_ValueChanged(object sender, Krypton.Toolkit.Suite.Extended.Controls.KnobValueChangedEventArgs e)
        {
            kryptonProgressBarExtendedVersion11.Value = e.Value;

            kryptonProgressBarExtendedVersion11.DisplayText = $"{e.Value}%";
        }

        private void kkTest2_ValueChanged(object sender, Krypton.Toolkit.Suite.Extended.Controls.KnobValueChangedEventArgs e)
        {
            kryptonProgressBarExtendedVersion21.Value = e.Value;
        }
    }
}

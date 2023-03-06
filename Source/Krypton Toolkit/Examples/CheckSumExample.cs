using Krypton.Toolkit.Suite.Extended.CheckSum.Tools;

namespace Examples
{
    public partial class CheckSumExample : KryptonForm
    {
        public CheckSumExample()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            KryptonComputeFileCheckSum computeFileCheckSum = new(true);

            computeFileCheckSum.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            KryptonVerifyFileCheckSum varifyFileCheckSum = new(true);

            varifyFileCheckSum.ShowDialog();
        }
    }
}

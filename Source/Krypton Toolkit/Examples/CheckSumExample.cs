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
            KryptonComputeFileCheckSumOld computeFileCheckSum = new KryptonComputeFileCheckSumOld();

            computeFileCheckSum.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            KryptonVarifyFileCheckSum varifyFileCheckSum = new KryptonVarifyFileCheckSum();

            varifyFileCheckSum.ShowDialog();
        }
    }
}

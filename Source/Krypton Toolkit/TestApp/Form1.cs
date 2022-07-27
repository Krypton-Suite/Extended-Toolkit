using Krypton.Toolkit;

namespace TestApp
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ktnToolStripItems_Click(object sender, EventArgs e)
        {
            ToolStripItems tsi = new ToolStripItems();

            tsi.Show();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            CalendarItems calendar = new CalendarItems();

            calendar.Show();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            CircularProgressBarExample circularProgressBar = new CircularProgressBarExample();

            circularProgressBar.Show();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            CheckSumExample checkSum = new CheckSumExample();

            checkSum.Show();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            ControlExamples controlExamples = new ControlExamples();

            controlExamples.Show();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            MessageBoxExample messageBoxExample = new MessageBoxExample();

            messageBoxExample.Show();
        }
    }
}
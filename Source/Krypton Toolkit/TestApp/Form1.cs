using Krypton.Toolkit;

namespace TestApp
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kbtnButtonItems_Click(object sender, EventArgs e)
        {
            ButtonItems buttonItems = new ButtonItems();

            buttonItems.Show();
        }

        private void ktnToolStripItems_Click(object sender, EventArgs e)
        {
            ToolStripItems tsi = new ToolStripItems();

            tsi.Show();
        }

        private void kbtnCalendarItems_Click(object sender, EventArgs e)
        {
            CalendarItems calendar = new CalendarItems();

            calendar.Show();
        }

        private void kbtnCircularProgressBarItem_Click(object sender, EventArgs e)
        {
            CircularProgressBarExample circularProgressBar = new CircularProgressBarExample();

            circularProgressBar.Show();
        }

        private void kbtnCheckSum_Click(object sender, EventArgs e)
        {
            CheckSumExample checkSum = new CheckSumExample();

            checkSum.Show();
        }

        private void kbtnExtendedControls_Click(object sender, EventArgs e)
        {
            ExtendedControlExamples extendedControlExamples = new ExtendedControlExamples();

            extendedControlExamples.Show();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            MessageBoxExample messageBoxExample = new MessageBoxExample();

            messageBoxExample.Show();
        }
    }
}
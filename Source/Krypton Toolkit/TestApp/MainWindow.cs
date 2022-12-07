namespace TestApp
{
    public partial class MainWindow : KryptonForm
    {
        public MainWindow()
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

        private void kbtnOutlookGrid_Click(object sender, EventArgs e)
        {
            OutlookGridExample outlookGridExample = new OutlookGridExample();

            outlookGridExample.Show();
        }

        private void kbtnNotificationExample_Click(object sender, EventArgs e)
        {
            NotificationExample notificationExample = new NotificationExample();

            notificationExample.Show();
        }

        private void kbtnFloating_Click(object sender, EventArgs e)
        {
            FloatingMenuToolbarExampleMain floating = new FloatingMenuToolbarExampleMain();

            floating.Show();
        }

        private void kbtnKryptonFormExtendedExample_Click(object sender, EventArgs e)
        {
            KryptonFormExtended1 kryptonFormExtended = new KryptonFormExtended1();

            kryptonFormExtended.Show();
        }

        private void kbtnDialogExamples_Click(object sender, EventArgs e)
        {
            DialogExamples dialogExamples = new DialogExamples();

            dialogExamples.Show();
        }

        private void kbtnInputBoxExamples_Click(object sender, EventArgs e)
        {
            KryptonInputBoxExtendedExample example = new KryptonInputBoxExtendedExample();

            example.Show();
        }
    }
}
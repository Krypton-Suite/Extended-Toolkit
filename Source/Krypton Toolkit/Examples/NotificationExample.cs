namespace Examples
{
    public partial class NotificationExample : KryptonForm
    {
        public NotificationExample()
        {
            InitializeComponent();
        }

        private void kbtnShowToastNotification_Click(object sender, EventArgs e)
        {
            ktnmTest.DisplayNotificationToast();
        }
    }
}

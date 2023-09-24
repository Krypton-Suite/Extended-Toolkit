namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class SharpUpdateInfoForm : KryptonForm
    {
        public SharpUpdateInfoForm(SharpUpdateLocalAppInfo applicationInfo, SharpUpdateXml updateInfo)
        {
            InitializeComponent();

            // Sets the icon if it's not null
            if (applicationInfo.ApplicationIcon != null)
            {
                Icon = applicationInfo.ApplicationIcon;
            }

            // Fill in the UI
            Text = $@"{applicationInfo.ApplicationName} - Update Info";

            kwlNewVersion.Text = updateInfo.Tag == JobType.UPDATE ? $"Current Version: {applicationInfo.Version}\nUpdate version: {updateInfo.Version}" :
                (updateInfo.Tag == JobType.ADD ? $"Version: {updateInfo.Version}" : "");

            krtxtDescription.Text = updateInfo.Description;
        }

        private void kbtnBack_Click(object sender, EventArgs e) => Close();

        private void krtxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            // Only allow Ctrl + C to copy text
            if (!(e.Control && e.KeyCode == Keys.C))
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class RemindLaterForm : KryptonForm
    {
        #region Public

        public RemindLaterFormat RemindLaterFormat { get; private set; }

        public int RemindLaterAt { get; private set; }

        #endregion

        public RemindLaterForm()
        {
            InitializeComponent();

            TopMost = AutoUpdater.TopMost;

            SetupUI();
        }

        private void SetupUI()
        {
            klblTitle.Text = AutoUpdaterLanguageManager.LaterWindowStrings.HeaderText;

            kwlblDescription.Text = AutoUpdaterLanguageManager.LaterWindowStrings.Description;

            Text = AutoUpdaterLanguageManager.LaterWindowStrings.WindowTitle;

            krbNo.Text = AutoUpdaterLanguageManager.LaterWindowStrings.NoText;

            krbYes.Text = AutoUpdaterLanguageManager.LaterWindowStrings.YesText;

            kbtnOk.Text = KryptonManager.Strings.GeneralStrings.OK;

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.ThirtyMinutes);

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.TwelveHours);

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.OneDay);

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.TwoDays);

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.FourDays);

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.EightDays);

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.TenDays);
        }

        private void RemindLaterForm_Load(object sender, EventArgs e)
        {
            kcmbRemindLater.SelectedIndex = 0;

            krbYes.Checked = true;
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            if (krbYes.Checked)
            {
                switch (kcmbRemindLater.SelectedIndex)
                {
                    case 0:
                        RemindLaterFormat = RemindLaterFormat.Minutes;
                        RemindLaterAt = 30;
                        break;
                    case 1:
                        RemindLaterFormat = RemindLaterFormat.Hours;
                        RemindLaterAt = 12;
                        break;
                    case 2:
                        RemindLaterFormat = RemindLaterFormat.Days;
                        RemindLaterAt = 1;
                        break;
                    case 3:
                        RemindLaterFormat = RemindLaterFormat.Days;
                        RemindLaterAt = 2;
                        break;
                    case 4:
                        RemindLaterFormat = RemindLaterFormat.Days;
                        RemindLaterAt = 4;
                        break;
                    case 5:
                        RemindLaterFormat = RemindLaterFormat.Days;
                        RemindLaterAt = 8;
                        break;
                    case 6:
                        RemindLaterFormat = RemindLaterFormat.Days;
                        RemindLaterAt = 10;
                        break;
                }

                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Abort;
            }
        }

        private void krbYes_CheckedChanged(object sender, EventArgs e) => kcmbRemindLater.Enabled = krbYes.Checked;
    }
}

#region License

/*
 * MIT License
 *
 * Copyright (c) 2012 - 2023 RBSoft
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class RemindLaterWindow : KryptonForm
    {
        #region Public

        public RemindLaterFormat RemindLaterFormat { get; private set; }

        public int RemindLaterAt { get; private set; }

        #endregion

        #region Identity

        public RemindLaterWindow()
        {
            InitializeComponent();

            SetupRemindLaterComboBox();

            SetupUI();
        }

        #endregion

        #region Implementation

        private void RemindLaterWindow_Load(object sender, EventArgs e)
        {
            kbtnOk.Text = KryptonLanguageManager.Strings.OK;

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

        private void krbYes_CheckedChanged(object sender, EventArgs e)
        {
            kcmbRemindLater.Enabled = krbYes.Checked;
        }

        private void SetupRemindLaterComboBox()
        {
            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.ThirtyMinutes);

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.TwelveHours);

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.OneDay);

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.TwoDays);

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.FourDays);

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.EightDays);

            kcmbRemindLater.Items.Add(AutoUpdaterLanguageManager.TimingStrings.TenDays);
        }

        private void SetupUI()
        {
            Text = AutoUpdaterLanguageManager.LaterWindowStrings.WindowTitle;

            kwlHeader.Text = AutoUpdaterLanguageManager.LaterWindowStrings.HeaderText;

            kwlDescription.Text = AutoUpdaterLanguageManager.LaterWindowStrings.Description;

            krbYes.Text = AutoUpdaterLanguageManager.LaterWindowStrings.YesText;

            krbNo.Text = AutoUpdaterLanguageManager.LaterWindowStrings.NoText;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Notifications;

namespace Notifications
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kcmActionType.DataSource = Enum.GetNames(typeof(ActionType));

            kcmbIconType.DataSource = Enum.GetNames(typeof(IconType));
        }

        private void kbtnBrowseProcess_Click(object sender, EventArgs e)
        {

        }

        private void kbtnBrowseIconImage_Click(object sender, EventArgs e)
        {

        }

        private void kbtnBrowseSoundPath_Click(object sender, EventArgs e)
        {

        }

        private void kbtnShowToast_Click(object sender, EventArgs e)
        {
            KryptonToastNotificationManager notificationManager = new KryptonToastNotificationManager()
            {
                Action = (ActionType)Enum.Parse(typeof(ActionType), kcmActionType.Text, false),
                ShowActionButton = kchkShowActionButton.Checked,
                ShowControlBox = kchkShowControlBox.Checked,
                ShowTimeOutProgress = kchkShowTimeoutProgress.Checked,
                ShowSubScript = kchkShowSubScript.Checked,
                BorderColourOne = kcbBorderColourOne.SelectedColor,
                BorderColourTwo = kcbBorderColour2.SelectedColor,
                SoundPath = ktxtSoundPath.Text,
                //SoundStream = new Stream(ktxtSoundStream.Text),
                HeaderText = ktxtHeaderText.Text,
                ContentText = krtbContentText.Text,
                ProcessPath = ktxtProcessName.Text,
                DismissButtonText = ktxtDismissButtonText.Text,
                CustomIconImage = new Bitmap(ktxtIconImage.Text),
                Seconds = Convert.ToInt32(knudSeconds.Value),
                CornerRadius = Convert.ToInt32(knudCornerRadius.Value),
                TimeOutProgress = Convert.ToInt32(knudTimeout.Value),
                ActionButtonText = ktxActionButtonText.Text,
                IconType = (IconType)Enum.Parse(typeof(IconType), kcmbIconType.Text, false)
            };

            notificationManager.DisplayNotification();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Notifications;

namespace Notifications
{
    public class Form2 : KryptonForm
    {
        #region Design Code
        private KryptonButton kbtnToastV2;
        private KryptonButton kbtnToastV1;
        private Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationManager ktnmVersionOne;
        private Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationManager ktnmVersionTwo;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnToastV2 = new Krypton.Toolkit.KryptonButton();
            this.kbtnToastV1 = new Krypton.Toolkit.KryptonButton();
            this.ktnmVersionOne = new Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationManager();
            this.ktnmVersionTwo = new Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationManager();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnToastV2);
            this.kryptonPanel1.Controls.Add(this.kbtnToastV1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(284, 77);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnToastV2
            // 
            this.kbtnToastV2.Location = new System.Drawing.Point(12, 43);
            this.kbtnToastV2.Name = "kbtnToastV2";
            this.kbtnToastV2.Size = new System.Drawing.Size(260, 25);
            this.kbtnToastV2.TabIndex = 1;
            this.kbtnToastV2.Values.Text = "Show Toast V2";
            this.kbtnToastV2.Visible = false;
            this.kbtnToastV2.Click += new System.EventHandler(this.kbtnToastV2_Click);
            // 
            // kbtnToastV1
            // 
            this.kbtnToastV1.Location = new System.Drawing.Point(12, 12);
            this.kbtnToastV1.Name = "kbtnToastV1";
            this.kbtnToastV1.Size = new System.Drawing.Size(260, 25);
            this.kbtnToastV1.TabIndex = 0;
            this.kbtnToastV1.Values.Text = "Show Toast V1";
            this.kbtnToastV1.Click += new System.EventHandler(this.kbtnToastV1_Click);
            // 
            // ktnmVersionOne
            // 
            this.ktnmVersionOne.Action = Krypton.Toolkit.Suite.Extended.Notifications.ActionType.LAUCHPROCESS;
            this.ktnmVersionOne.ActionButtonText = "Launch";
            this.ktnmVersionOne.BorderColourOne = System.Drawing.Color.Empty;
            this.ktnmVersionOne.BorderColourTwo = System.Drawing.Color.Empty;
            this.ktnmVersionOne.ContentText = "Hello World!\\n\\nThis is a sample Krypton Toast Notification.\\n\\nYou can use this " +
    "area for your own messages.\\n\\nThe supported maximum image size is 128 x 128.";
            this.ktnmVersionOne.CornerRadius = -1;
            this.ktnmVersionOne.CustomIconImage = null;
            this.ktnmVersionOne.DismissButtonText = "&Dismiss";
            this.ktnmVersionOne.HeaderText = "Hello World!";
            this.ktnmVersionOne.IconType = Krypton.Toolkit.Suite.Extended.Notifications.IconType.INFORMATION;
            this.ktnmVersionOne.ProcessPath = "C:\\Windows\\notepad.exe";
            this.ktnmVersionOne.Seconds = 60;
            this.ktnmVersionOne.ShowActionButton = true;
            this.ktnmVersionOne.ShowControlBox = false;
            this.ktnmVersionOne.ShowSubScript = false;
            this.ktnmVersionOne.ShowTimeOutProgress = false;
            this.ktnmVersionOne.SoundPath = null;
            this.ktnmVersionOne.SoundStream = null;
            this.ktnmVersionOne.TimeOutProgress = 0;
            // 
            // ktnmVersionTwo
            // 
            this.ktnmVersionTwo.Action = Krypton.Toolkit.Suite.Extended.Notifications.ActionType.DEFAULT;
            this.ktnmVersionTwo.ActionButtonText = null;
            this.ktnmVersionTwo.BorderColourOne = System.Drawing.Color.Empty;
            this.ktnmVersionTwo.BorderColourTwo = System.Drawing.Color.Empty;
            this.ktnmVersionTwo.ContentText = null;
            this.ktnmVersionTwo.CornerRadius = 0;
            this.ktnmVersionTwo.CustomIconImage = null;
            this.ktnmVersionTwo.DismissButtonText = "&Dismiss";
            this.ktnmVersionTwo.HeaderText = "Krypton Toast Notification";
            this.ktnmVersionTwo.IconType = Krypton.Toolkit.Suite.Extended.Notifications.IconType.INFORMATION;
            this.ktnmVersionTwo.ProcessPath = null;
            this.ktnmVersionTwo.Seconds = 0;
            this.ktnmVersionTwo.ShowActionButton = false;
            this.ktnmVersionTwo.ShowControlBox = false;
            this.ktnmVersionTwo.ShowSubScript = false;
            this.ktnmVersionTwo.ShowTimeOutProgress = true;
            this.ktnmVersionTwo.SoundPath = null;
            this.ktnmVersionTwo.SoundStream = null;
            this.ktnmVersionTwo.TimeOutProgress = 100;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(284, 77);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "Notifications";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructor
        public Form2()
        {
            InitializeComponent();
        }
        #endregion

        private void kbtnToastV1_Click(object sender, EventArgs e)
        {
            ktnmVersionOne.DisplayNotification();
        }

        private void kbtnToastV2_Click(object sender, EventArgs e)
        {
            ktnmVersionTwo.DisplayNotification();
        }
    }
}
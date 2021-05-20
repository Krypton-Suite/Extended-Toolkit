using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Krypton.Toolkit;

namespace Notifications
{
    public class Form2 : KryptonForm
    {
        #region Design Code
        private KryptonButton kbtnToastV2;
        private KryptonButton kbtnToastV1;
        private Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationManager ktnmVersionOne;
        private Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationManager ktnmVersion2;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnToastV2 = new Krypton.Toolkit.KryptonButton();
            this.kbtnToastV1 = new Krypton.Toolkit.KryptonButton();
            this.ktnmVersionOne = new Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationManager();
            this.ktnmVersion2 = new Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationManager();
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
            this.ktnmVersionOne.ContentText = null;
            this.ktnmVersionOne.CornerRadius = -1;
            this.ktnmVersionOne.CustomIconImage = null;
            this.ktnmVersionOne.DismissButtonText = "&Dismiss";
            this.ktnmVersionOne.HeaderText = "Hello World!";
            this.ktnmVersionOne.IconType = Krypton.Toolkit.Suite.Extended.Notifications.IconType.INFORMATION;
            this.ktnmVersionOne.ProcessPath = "C:\\\\Windows\\\\notepad.exe";
            this.ktnmVersionOne.Seconds = 60;
            this.ktnmVersionOne.ShowActionButton = true;
            this.ktnmVersionOne.ShowControlBox = false;
            this.ktnmVersionOne.ShowSubScript = false;
            this.ktnmVersionOne.ShowTimeOutProgress = false;
            this.ktnmVersionOne.SoundPath = null;
            this.ktnmVersionOne.SoundStream = null;
            this.ktnmVersionOne.TimeOutProgress = 0;
            // 
            // ktnmVersion2
            // 
            this.ktnmVersion2.Action = Krypton.Toolkit.Suite.Extended.Notifications.ActionType.DEFAULT;
            this.ktnmVersion2.ActionButtonText = null;
            this.ktnmVersion2.BorderColourOne = System.Drawing.Color.Empty;
            this.ktnmVersion2.BorderColourTwo = System.Drawing.Color.Empty;
            this.ktnmVersion2.ContentText = null;
            this.ktnmVersion2.CornerRadius = 0;
            this.ktnmVersion2.CustomIconImage = null;
            this.ktnmVersion2.DismissButtonText = "&Dismiss";
            this.ktnmVersion2.HeaderText = "Krypton Toast Notification";
            this.ktnmVersion2.IconType = Krypton.Toolkit.Suite.Extended.Notifications.IconType.INFORMATION;
            this.ktnmVersion2.ProcessPath = null;
            this.ktnmVersion2.Seconds = 0;
            this.ktnmVersion2.ShowActionButton = false;
            this.ktnmVersion2.ShowControlBox = false;
            this.ktnmVersion2.ShowSubScript = false;
            this.ktnmVersion2.ShowTimeOutProgress = true;
            this.ktnmVersion2.SoundPath = null;
            this.ktnmVersion2.SoundStream = null;
            this.ktnmVersion2.TimeOutProgress = 100;
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
            ktnmVersion2.DisplayNotification();
        }
    }
}
namespace TestApp
{
    partial class NotificationExample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonToastNotificationPopup1 = new Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationPopup();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnShowToastNotification = new Krypton.Toolkit.KryptonButton();
            this.ktnmTest = new Krypton.Toolkit.Suite.Extended.Toast.KryptonToastNotificationManager();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonToastNotificationPopup1
            // 
            this.kryptonToastNotificationPopup1.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            this.kryptonToastNotificationPopup1.ContentText = null;
            this.kryptonToastNotificationPopup1.Image = null;
            this.kryptonToastNotificationPopup1.IsRightToLeft = false;
            this.kryptonToastNotificationPopup1.OptionsMenu = null;
            this.kryptonToastNotificationPopup1.Size = new System.Drawing.Size(400, 100);
            this.kryptonToastNotificationPopup1.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonToastNotificationPopup1.TitleText = null;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnShowToastNotification);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(360, 184);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnShowToastNotification
            // 
            this.kbtnShowToastNotification.CornerRoundingRadius = -1F;
            this.kbtnShowToastNotification.Location = new System.Drawing.Point(13, 13);
            this.kbtnShowToastNotification.Name = "kbtnShowToastNotification";
            this.kbtnShowToastNotification.Size = new System.Drawing.Size(335, 25);
            this.kbtnShowToastNotification.TabIndex = 0;
            this.kbtnShowToastNotification.Values.Text = "Show Toast Notification";
            this.kbtnShowToastNotification.Click += new System.EventHandler(this.kbtnShowToastNotification_Click);
            // 
            // ktnmTest
            // 
            this.ktnmTest.ContentAreaType = Krypton.Toolkit.Suite.Extended.Toast.ToastNotificationContentAreaType.WrappedLabel;
            this.ktnmTest.ContentText = "This is a sample notification.";
            this.ktnmTest.DismissText = "&Dismiss";
            this.ktnmTest.IconType = Krypton.Toolkit.Suite.Extended.Toast.IconType.Information;
            this.ktnmTest.RightToLeftSupport = Krypton.Toolkit.Suite.Extended.Toast.RightToLeftSupport.LeftToRight;
            this.ktnmTest.Title = "Sample Notification";
            this.ktnmTest.UserResponsePromptAlignHorizontal = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.ktnmTest.UserResponsePromptAlignVertical = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.ktnmTest.UserResponsePromptColour = System.Drawing.Color.Gray;
            this.ktnmTest.UserResponsePromptFont = new System.Drawing.Font("Segoe UI", 8.25F);
            // 
            // NotificationExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 184);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "NotificationExample";
            this.Text = "NotificationExample";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationPopup kryptonToastNotificationPopup1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnShowToastNotification;
        private Krypton.Toolkit.Suite.Extended.Toast.KryptonToastNotificationManager ktnmTest;
    }
}
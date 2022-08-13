namespace TestApp
{
    partial class ToastNotificationExample
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
            this.kryptonToastNotificationManager1 = new Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationManager();
            this.kryptonToastNotificationPopup1 = new Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationPopup();
            this.SuspendLayout();
            // 
            // kryptonToastNotificationManager1
            // 
            this.kryptonToastNotificationManager1.Action = Krypton.Toolkit.Suite.Extended.Notifications.KryptonNotificationActionType.Default;
            this.kryptonToastNotificationManager1.ActionButtonText = null;
            this.kryptonToastNotificationManager1.BorderColourOne = System.Drawing.Color.Empty;
            this.kryptonToastNotificationManager1.BorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonToastNotificationManager1.ContentText = null;
            this.kryptonToastNotificationManager1.CornerRadius = 0;
            this.kryptonToastNotificationManager1.CustomIconImage = null;
            this.kryptonToastNotificationManager1.DismissButtonText = null;
            this.kryptonToastNotificationManager1.HeaderText = null;
            this.kryptonToastNotificationManager1.IconType = Krypton.Toolkit.Suite.Extended.Notifications.KryptonNotificationIconType.Custom;
            this.kryptonToastNotificationManager1.ProcessPath = null;
            this.kryptonToastNotificationManager1.Seconds = 0;
            this.kryptonToastNotificationManager1.ShowActionButton = false;
            this.kryptonToastNotificationManager1.ShowControlBox = false;
            this.kryptonToastNotificationManager1.ShowSubScript = false;
            this.kryptonToastNotificationManager1.ShowTimeOutProgress = false;
            this.kryptonToastNotificationManager1.SoundPath = null;
            this.kryptonToastNotificationManager1.SoundStream = null;
            this.kryptonToastNotificationManager1.TimeOutProgress = 0;
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
            // ToastNotificationExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "ToastNotificationExample";
            this.Text = "ToastNotificationExample";
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationManager kryptonToastNotificationManager1;
        private Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationPopup kryptonToastNotificationPopup1;
    }
}
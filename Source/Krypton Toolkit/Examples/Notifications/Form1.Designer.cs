
namespace Notifications
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ktnmVersion1 = new Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationManager();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnTestNotificationToastV1 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ktnmVersion1
            // 
            this.ktnmVersion1.Action = Krypton.Toolkit.Suite.Extended.Notifications.ActionType.DEFAULT;
            this.ktnmVersion1.ActionButtonText = null;
            this.ktnmVersion1.BorderColourOne = System.Drawing.Color.Empty;
            this.ktnmVersion1.BorderColourTwo = System.Drawing.Color.Empty;
            this.ktnmVersion1.ContentText = "This is a toast notification";
            this.ktnmVersion1.CornerRadius = 0;
            this.ktnmVersion1.DismissButtonText = "&Auto Close";
            this.ktnmVersion1.HeaderText = "Hello World";
            this.ktnmVersion1.IconImage = null;
            this.ktnmVersion1.IconType = Krypton.Toolkit.Suite.Extended.Notifications.IconType.OK;
            this.ktnmVersion1.ProcessName = null;
            this.ktnmVersion1.Seconds = 60;
            this.ktnmVersion1.ShowActionButton = false;
            this.ktnmVersion1.ShowControlBox = false;
            this.ktnmVersion1.ShowSubScript = false;
            this.ktnmVersion1.ShowTimeOutProgress = false;
            this.ktnmVersion1.SoundPath = null;
            this.ktnmVersion1.SoundStream = null;
            this.ktnmVersion1.TimeOutProgress = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnTestNotificationToastV1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(294, 260);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnTestNotificationToastV1
            // 
            this.kbtnTestNotificationToastV1.Location = new System.Drawing.Point(68, 28);
            this.kbtnTestNotificationToastV1.Name = "kbtnTestNotificationToastV1";
            this.kbtnTestNotificationToastV1.Size = new System.Drawing.Size(158, 25);
            this.kbtnTestNotificationToastV1.TabIndex = 0;
            this.kbtnTestNotificationToastV1.Values.Text = "Test Notification Toast V1";
            this.kbtnTestNotificationToastV1.Click += new System.EventHandler(this.kbtnTestNotificationToastV1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 260);
            this.Controls.Add(this.kryptonPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Notifications.KryptonToastNotificationManager ktnmVersion1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnTestNotificationToastV1;
    }
}


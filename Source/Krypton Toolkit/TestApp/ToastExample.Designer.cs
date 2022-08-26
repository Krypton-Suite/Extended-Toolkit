namespace TestApp
{
    partial class ToastExample
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
            this.kryptonToastNotificationManager1 = new Krypton.Toolkit.Suite.Extended.Toast.KryptonToastNotificationManager();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonToastNotificationManager1
            // 
            this.kryptonToastNotificationManager1.ContentAreaType = Krypton.Toolkit.Suite.Extended.Toast.ContentAreaType.WrappedLabel;
            this.kryptonToastNotificationManager1.DismissText = "&Dismiss";
            this.kryptonToastNotificationManager1.IconType = Krypton.Toolkit.Suite.Extended.Toast.IconType.None;
            this.kryptonToastNotificationManager1.RightToLeftSupport = Krypton.Toolkit.Suite.Extended.Toast.RightToLeftSupport.LeftToRight;
            this.kryptonToastNotificationManager1.UserResponsePromptAlignHorizontal = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonToastNotificationManager1.UserResponsePromptAlignVertical = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonToastNotificationManager1.UserResponsePromptColour = System.Drawing.Color.Gray;
            this.kryptonToastNotificationManager1.UserResponsePromptFont = new System.Drawing.Font("Segoe UI", 8.25F);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1446, 730);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // ToastExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 730);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ToastExample";
            this.Text = "ToastExample";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Toast.KryptonToastNotificationManager kryptonToastNotificationManager1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}
namespace Toast
{
    partial class MainWindow
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnBasicNotificationWithUserResponseConfiguration = new Krypton.Toolkit.KryptonButton();
            this.kbtnBasicNotificationWithProgressBarConfiguration = new Krypton.Toolkit.KryptonButton();
            this.kbtnLTRBasicNotificationConfiguration = new Krypton.Toolkit.KryptonButton();
            this.kbtnBasicNotificationWithUserResponseAndProgressBar = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnBasicNotificationWithUserResponseAndProgressBar);
            this.kryptonPanel1.Controls.Add(this.kbtnBasicNotificationWithUserResponseConfiguration);
            this.kryptonPanel1.Controls.Add(this.kbtnBasicNotificationWithProgressBarConfiguration);
            this.kryptonPanel1.Controls.Add(this.kbtnLTRBasicNotificationConfiguration);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(464, 358);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnBasicNotificationWithUserResponseConfiguration
            // 
            this.kbtnBasicNotificationWithUserResponseConfiguration.Location = new System.Drawing.Point(12, 74);
            this.kbtnBasicNotificationWithUserResponseConfiguration.Name = "kbtnBasicNotificationWithUserResponseConfiguration";
            this.kbtnBasicNotificationWithUserResponseConfiguration.Size = new System.Drawing.Size(328, 25);
            this.kbtnBasicNotificationWithUserResponseConfiguration.TabIndex = 3;
            this.kbtnBasicNotificationWithUserResponseConfiguration.Values.Text = "LTR Basic Notification with User Response Configuration";
            this.kbtnBasicNotificationWithUserResponseConfiguration.Click += new System.EventHandler(this.kbtnBasicNotificationWithUserResponseConfiguration_Click);
            // 
            // kbtnBasicNotificationWithProgressBarConfiguration
            // 
            this.kbtnBasicNotificationWithProgressBarConfiguration.Location = new System.Drawing.Point(12, 43);
            this.kbtnBasicNotificationWithProgressBarConfiguration.Name = "kbtnBasicNotificationWithProgressBarConfiguration";
            this.kbtnBasicNotificationWithProgressBarConfiguration.Size = new System.Drawing.Size(315, 25);
            this.kbtnBasicNotificationWithProgressBarConfiguration.TabIndex = 2;
            this.kbtnBasicNotificationWithProgressBarConfiguration.Values.Text = "LTR Basic Notification with ProgressBar Configuration";
            this.kbtnBasicNotificationWithProgressBarConfiguration.Click += new System.EventHandler(this.kbtnBasicNotificationWithProgressBarConfiguration_Click);
            // 
            // kbtnLTRBasicNotificationConfiguration
            // 
            this.kbtnLTRBasicNotificationConfiguration.Location = new System.Drawing.Point(12, 12);
            this.kbtnLTRBasicNotificationConfiguration.Name = "kbtnLTRBasicNotificationConfiguration";
            this.kbtnLTRBasicNotificationConfiguration.Size = new System.Drawing.Size(224, 25);
            this.kbtnLTRBasicNotificationConfiguration.TabIndex = 1;
            this.kbtnLTRBasicNotificationConfiguration.Values.Text = "LTR Basic Notification Configuration";
            this.kbtnLTRBasicNotificationConfiguration.Click += new System.EventHandler(this.kbtnLTRBasicNotificationConfiguration_Click);
            // 
            // kbtnBasicNotificationWithUserResponseAndProgressBar
            // 
            this.kbtnBasicNotificationWithUserResponseAndProgressBar.Location = new System.Drawing.Point(12, 105);
            this.kbtnBasicNotificationWithUserResponseAndProgressBar.Name = "kbtnBasicNotificationWithUserResponseAndProgressBar";
            this.kbtnBasicNotificationWithUserResponseAndProgressBar.Size = new System.Drawing.Size(407, 25);
            this.kbtnBasicNotificationWithUserResponseAndProgressBar.TabIndex = 4;
            this.kbtnBasicNotificationWithUserResponseAndProgressBar.Values.Text = "LTR Basic Notification with User Response and ProgressBar Configuration";
            this.kbtnBasicNotificationWithUserResponseAndProgressBar.Click += new System.EventHandler(this.kbtnBasicNotificationWithUserResponseAndProgressBar_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 358);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnLTRBasicNotificationConfiguration;
        private Krypton.Toolkit.KryptonButton kbtnBasicNotificationWithProgressBarConfiguration;
        private Krypton.Toolkit.KryptonButton kbtnBasicNotificationWithUserResponseConfiguration;
        private Krypton.Toolkit.KryptonButton kbtnBasicNotificationWithUserResponseAndProgressBar;
    }
}
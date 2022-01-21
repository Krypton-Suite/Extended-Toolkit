namespace Toast.LTR
{
    partial class BasicNotificationWithProgressBarConfiguration
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
            this.kbtnPickSound = new Krypton.Toolkit.KryptonButton();
            this.kbtnShowNotification = new Krypton.Toolkit.KryptonButton();
            this.knudNotificationTimeOut = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtNotificationDismissButtonText = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnNotificationCustomImage = new Krypton.Toolkit.KryptonButton();
            this.kcmbNotificationIconType = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.krtbNotificationContentText = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtNotificationTitle = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbNotificationIconType)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnPickSound);
            this.kryptonPanel1.Controls.Add(this.kbtnShowNotification);
            this.kryptonPanel1.Controls.Add(this.knudNotificationTimeOut);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel1.Controls.Add(this.ktxtNotificationDismissButtonText);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.kbtnNotificationCustomImage);
            this.kryptonPanel1.Controls.Add(this.kcmbNotificationIconType);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.krtbNotificationContentText);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.ktxtNotificationTitle);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(719, 220);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnPickSound
            // 
            this.kbtnPickSound.Location = new System.Drawing.Point(517, 179);
            this.kbtnPickSound.Name = "kbtnPickSound";
            this.kbtnPickSound.Size = new System.Drawing.Size(90, 25);
            this.kbtnPickSound.TabIndex = 13;
            this.kbtnPickSound.Values.Text = "&Pick Sound";
            this.kbtnPickSound.Click += new System.EventHandler(this.kbtnPickSound_Click);
            // 
            // kbtnShowNotification
            // 
            this.kbtnShowNotification.Location = new System.Drawing.Point(613, 179);
            this.kbtnShowNotification.Name = "kbtnShowNotification";
            this.kbtnShowNotification.Size = new System.Drawing.Size(90, 25);
            this.kbtnShowNotification.TabIndex = 12;
            this.kbtnShowNotification.Values.Text = "&Show";
            this.kbtnShowNotification.Click += new System.EventHandler(this.kbtnShowNotification_Click);
            // 
            // knudNotificationTimeOut
            // 
            this.knudNotificationTimeOut.Location = new System.Drawing.Point(197, 179);
            this.knudNotificationTimeOut.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.knudNotificationTimeOut.Name = "knudNotificationTimeOut";
            this.knudNotificationTimeOut.Size = new System.Drawing.Size(69, 22);
            this.knudNotificationTimeOut.TabIndex = 11;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(12, 179);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(179, 20);
            this.kryptonLabel5.TabIndex = 10;
            this.kryptonLabel5.Values.Text = "Time in seconds (0 for none):";
            // 
            // ktxtNotificationDismissButtonText
            // 
            this.ktxtNotificationDismissButtonText.CueHint.CueHintText = "Enter dismiss button text...";
            this.ktxtNotificationDismissButtonText.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.ktxtNotificationDismissButtonText.Location = new System.Drawing.Point(437, 144);
            this.ktxtNotificationDismissButtonText.Name = "ktxtNotificationDismissButtonText";
            this.ktxtNotificationDismissButtonText.Size = new System.Drawing.Size(266, 23);
            this.ktxtNotificationDismissButtonText.TabIndex = 9;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(344, 143);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(87, 20);
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Dismiss Text:";
            // 
            // kbtnNotificationCustomImage
            // 
            this.kbtnNotificationCustomImage.Location = new System.Drawing.Point(248, 144);
            this.kbtnNotificationCustomImage.Name = "kbtnNotificationCustomImage";
            this.kbtnNotificationCustomImage.Size = new System.Drawing.Size(90, 25);
            this.kbtnNotificationCustomImage.TabIndex = 7;
            this.kbtnNotificationCustomImage.Values.Text = "Custom Im&age";
            this.kbtnNotificationCustomImage.Click += new System.EventHandler(this.kbtnNotificationCustomImage_Click);
            // 
            // kcmbNotificationIconType
            // 
            this.kcmbNotificationIconType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbNotificationIconType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbNotificationIconType.DropDownWidth = 135;
            this.kcmbNotificationIconType.IntegralHeight = false;
            this.kcmbNotificationIconType.Location = new System.Drawing.Point(107, 144);
            this.kcmbNotificationIconType.Name = "kcmbNotificationIconType";
            this.kcmbNotificationIconType.Size = new System.Drawing.Size(135, 21);
            this.kcmbNotificationIconType.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbNotificationIconType.TabIndex = 6;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 144);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(70, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Icon Type:";
            // 
            // krtbNotificationContentText
            // 
            this.krtbNotificationContentText.CueHint.CueHintText = "Type a message...";
            this.krtbNotificationContentText.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.krtbNotificationContentText.Location = new System.Drawing.Point(107, 41);
            this.krtbNotificationContentText.Name = "krtbNotificationContentText";
            this.krtbNotificationContentText.Size = new System.Drawing.Size(596, 96);
            this.krtbNotificationContentText.TabIndex = 4;
            this.krtbNotificationContentText.Text = "";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 41);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(89, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Content Text:";
            // 
            // ktxtNotificationTitle
            // 
            this.ktxtNotificationTitle.CueHint.CueHintText = "Enter a title...";
            this.ktxtNotificationTitle.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.ktxtNotificationTitle.Location = new System.Drawing.Point(107, 12);
            this.ktxtNotificationTitle.Name = "ktxtNotificationTitle";
            this.ktxtNotificationTitle.Size = new System.Drawing.Size(596, 23);
            this.ktxtNotificationTitle.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(40, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Title:";
            // 
            // BasicNotificationWithProgressBarConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 220);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasicNotificationWithProgressBarConfiguration";
            this.Text = "BasicNotificationWithProgressBarConfiguration";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbNotificationIconType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnPickSound;
        private Krypton.Toolkit.KryptonButton kbtnShowNotification;
        private Krypton.Toolkit.KryptonNumericUpDown knudNotificationTimeOut;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonTextBox ktxtNotificationDismissButtonText;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonButton kbtnNotificationCustomImage;
        private Krypton.Toolkit.KryptonComboBox kcmbNotificationIconType;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonRichTextBox krtbNotificationContentText;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonTextBox ktxtNotificationTitle;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    public class MessageNotificationDialog : KryptonForm
    {
        #region Designer Code
        private KryptonLabel klblMessage;
        private System.Windows.Forms.PictureBox pbxApplicationIcon;
        private KryptonButton kbtnOk;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.pbxApplicationIcon = new System.Windows.Forms.PictureBox();
            this.klblMessage = new Krypton.Toolkit.KryptonLabel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.klblMessage);
            this.kryptonPanel1.Controls.Add(this.pbxApplicationIcon);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(438, 174);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // pbxApplicationIcon
            // 
            this.pbxApplicationIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxApplicationIcon.Name = "pbxApplicationIcon";
            this.pbxApplicationIcon.Size = new System.Drawing.Size(48, 48);
            this.pbxApplicationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxApplicationIcon.TabIndex = 2;
            this.pbxApplicationIcon.TabStop = false;
            // 
            // klblMessage
            // 
            this.klblMessage.Location = new System.Drawing.Point(66, 12);
            this.klblMessage.Name = "klblMessage";
            this.klblMessage.Size = new System.Drawing.Size(349, 68);
            this.klblMessage.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold);
            this.klblMessage.TabIndex = 3;
            this.klblMessage.Values.Text = "Sorry, either our server is having a \r\nproblem, or your internet connection is \r\n" +
    "invalid.";
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnOk.Location = new System.Drawing.Point(174, 103);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 4;
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // MessageNotificationDialog
            // 
            this.AcceptButton = this.kbtnOk;
            this.ClientSize = new System.Drawing.Size(438, 174);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageNotificationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public MessageNotificationDialog()
        {
            InitializeComponent();
        }

        public MessageNotificationDialog(string title, string message, Icon applicationIcon = null)
        {
            InitializeComponent();

            Text = title;

            if (applicationIcon != null)
            {
                Icon = applicationIcon;

                pbxApplicationIcon.Image = new Icon(applicationIcon, new Size(48, 48)).ToBitmap();
            }

            klblMessage.Text = message;
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
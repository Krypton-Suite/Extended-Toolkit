using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    public class CheckingForUpdatesDialog : KryptonForm, ICheckingForUpdates
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private KryptonButton kbtnCancel;
        private KryptonLabel klblCheckingForUpdates;
        private System.Windows.Forms.PictureBox pbxApplicationIcon;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckingForUpdatesDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.pbxApplicationIcon = new System.Windows.Forms.PictureBox();
            this.klblCheckingForUpdates = new Krypton.Toolkit.KryptonLabel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.progressBar1);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.klblCheckingForUpdates);
            this.kryptonPanel1.Controls.Add(this.pbxApplicationIcon);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(485, 113);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // pbxApplicationIcon
            // 
            this.pbxApplicationIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxApplicationIcon.Name = "pbxApplicationIcon";
            this.pbxApplicationIcon.Size = new System.Drawing.Size(48, 48);
            this.pbxApplicationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxApplicationIcon.TabIndex = 1;
            this.pbxApplicationIcon.TabStop = false;
            // 
            // klblCheckingForUpdates
            // 
            this.klblCheckingForUpdates.AutoSize = false;
            this.klblCheckingForUpdates.Location = new System.Drawing.Point(66, 12);
            this.klblCheckingForUpdates.Name = "klblCheckingForUpdates";
            this.klblCheckingForUpdates.Size = new System.Drawing.Size(407, 33);
            this.klblCheckingForUpdates.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblCheckingForUpdates.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblCheckingForUpdates.TabIndex = 1;
            this.klblCheckingForUpdates.Values.Text = "Checking for Updates...";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(224, 80);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(85, 51);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(369, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // CheckingForUpdatesDialog
            // 
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(485, 113);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckingForUpdatesDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Software Update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckingForUpdatesDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public event EventHandler UpdatesUIClosing;

        public CheckingForUpdatesDialog()
        {
            InitializeComponent();
        }

        public CheckingForUpdatesDialog(Icon applicationIcon = null)
        {
            InitializeComponent();

            if (applicationIcon != null)
            {
                Icon = applicationIcon;

                pbxApplicationIcon.Image = new Icon(applicationIcon, new Size(48, 48)).ToBitmap();
            }
        }

        private void CheckingForUpdatesDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdatesUIClosing?.Invoke(sender, new EventArgs());

            FormClosing -= CheckingForUpdatesDialog_FormClosing;
        }

        void ICheckingForUpdates.Close()
        {
            Close();
        }

        void ICheckingForUpdates.Show()
        {
            Show();
        }

        private void CloseForm()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { Close(); });
            }
            else
            {
                Close();
            }
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
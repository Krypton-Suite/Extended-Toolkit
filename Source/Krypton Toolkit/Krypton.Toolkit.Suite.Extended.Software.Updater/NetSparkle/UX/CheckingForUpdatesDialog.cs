#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    public class CheckingForUpdatesDialog : KryptonForm, ICheckingForUpdates
    {
        #region Designer Code
        private ProgressBar progressBar1;
        private KryptonLabel klblCheckingForUpdates;
        private PictureBox pbxApplicationIcon;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonButton btnCancel;
        private KryptonPanel kryptonPanel1;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckingForUpdatesDialog));
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.klblCheckingForUpdates = new Krypton.Toolkit.KryptonLabel();
            this.pbxApplicationIcon = new System.Windows.Forms.PictureBox();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.btnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.progressBar1);
            this.kryptonPanel2.Controls.Add(this.klblCheckingForUpdates);
            this.kryptonPanel2.Controls.Add(this.pbxApplicationIcon);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(483, 88);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(85, 51);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(369, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // klblCheckingForUpdates
            // 
            this.klblCheckingForUpdates.AutoSize = false;
            this.klblCheckingForUpdates.Location = new System.Drawing.Point(66, 12);
            this.klblCheckingForUpdates.Name = "klblCheckingForUpdates";
            this.klblCheckingForUpdates.Size = new System.Drawing.Size(407, 33);
            this.klblCheckingForUpdates.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblCheckingForUpdates.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblCheckingForUpdates.TabIndex = 3;
            this.klblCheckingForUpdates.Values.Text = "Checking for Updates...";
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
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(483, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(381, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 88);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(483, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // CheckingForUpdatesDialog
            // 
            this.ClientSize = new System.Drawing.Size(483, 138);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckingForUpdatesDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checking for Updates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckingForUpdatesDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region ICheckingForUpdates
        public event EventHandler UpdatesUIClosing;
        #endregion

        #region Constructor
        public CheckingForUpdatesDialog(Icon appIcon = null)
        {
            InitializeComponent();

            if (appIcon != null)
            {
                Icon = appIcon;

                pbxApplicationIcon.Image = new Icon(appIcon, new Size(48, 48)).ToBitmap();
            }
            else
            {
                Icon = NetSparkleResources.update1;

                pbxApplicationIcon.Image = NetSparkleResources.update_48_x_48;
            }
        }
        #endregion

        private void CheckingForUpdatesDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdatesUIClosing?.Invoke(sender, new EventArgs());

            FormClosing -= CheckingForUpdatesDialog_FormClosing;
        }

        void ICheckingForUpdates.Close() => Close();

        void ICheckingForUpdates.Show() => Show();

        private void CloseForm()
        {
            if (InvokeRequired)
            {
                Invoke(delegate () { Close(); });
            }
            else
            {
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
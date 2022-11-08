#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.SharpUpdate
{
    public class SharpUpdateAcceptForm : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnYes;
        private KryptonButton kbtnNo;
        private KryptonButton kbtnDetails;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private PictureBox pictureBox;
        private KryptonWrapLabel kwlblNewVersion;
        private KryptonWrapLabel kwlblUpdateAvail;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharpUpdateAcceptForm));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnYes = new Krypton.Toolkit.KryptonButton();
            this.kbtnNo = new Krypton.Toolkit.KryptonButton();
            this.kbtnDetails = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.kwlblNewVersion = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlblUpdateAvail = new Krypton.Toolkit.KryptonWrapLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnYes);
            this.kryptonPanel1.Controls.Add(this.kbtnNo);
            this.kryptonPanel1.Controls.Add(this.kbtnDetails);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 153);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(399, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnYes
            // 
            this.kbtnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.kbtnYes.Location = new System.Drawing.Point(105, 13);
            this.kbtnYes.Name = "kbtnYes";
            this.kbtnYes.Size = new System.Drawing.Size(90, 25);
            this.kbtnYes.TabIndex = 2;
            this.kbtnYes.Values.Text = "&Yes";
            this.kbtnYes.Click += new System.EventHandler(this.kbtnYes_Click);
            // 
            // kbtnNo
            // 
            this.kbtnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.kbtnNo.Location = new System.Drawing.Point(201, 13);
            this.kbtnNo.Name = "kbtnNo";
            this.kbtnNo.Size = new System.Drawing.Size(90, 25);
            this.kbtnNo.TabIndex = 1;
            this.kbtnNo.Values.Text = "&No";
            this.kbtnNo.Click += new System.EventHandler(this.kbtnNo_Click);
            // 
            // kbtnDetails
            // 
            this.kbtnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnDetails.Location = new System.Drawing.Point(297, 13);
            this.kbtnDetails.Name = "kbtnDetails";
            this.kbtnDetails.Size = new System.Drawing.Size(90, 25);
            this.kbtnDetails.TabIndex = 0;
            this.kbtnDetails.Values.Text = "Detai&ls";
            this.kbtnDetails.Click += new System.EventHandler(this.kbtnDetails_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(399, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.pictureBox);
            this.kryptonPanel2.Controls.Add(this.kwlblNewVersion);
            this.kryptonPanel2.Controls.Add(this.kwlblUpdateAvail);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(399, 153);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.throbber_80;
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(80, 80);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // kwlblNewVersion
            // 
            this.kwlblNewVersion.AutoSize = false;
            this.kwlblNewVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlblNewVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlblNewVersion.Location = new System.Drawing.Point(106, 81);
            this.kwlblNewVersion.Name = "kwlblNewVersion";
            this.kwlblNewVersion.Size = new System.Drawing.Size(281, 58);
            this.kwlblNewVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kwlblUpdateAvail
            // 
            this.kwlblUpdateAvail.AutoSize = false;
            this.kwlblUpdateAvail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlblUpdateAvail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlblUpdateAvail.Location = new System.Drawing.Point(106, 12);
            this.kwlblUpdateAvail.Name = "kwlblUpdateAvail";
            this.kwlblUpdateAvail.Size = new System.Drawing.Size(281, 65);
            this.kwlblUpdateAvail.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlblUpdateAvail.Text = "An update is available!\r\nWould you like to update?";
            this.kwlblUpdateAvail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SharpUpdateAcceptForm
            // 
            this.ClientSize = new System.Drawing.Size(399, 203);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharpUpdateAcceptForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        /// <summary>
        /// The program to update's info
        /// </summary>
        private SharpUpdateLocalAppInfo _applicationInfo;

        /// <summary>
        /// The update info from the update.xml
        /// </summary>
        private SharpUpdateXml _updateInfo;

        /// <summary>
        /// The update info display form
        /// </summary>
        private SharpUpdateInfoForm _updateInfoForm;
        #endregion

        #region Constructor
        internal SharpUpdateAcceptForm(SharpUpdateLocalAppInfo updateLocalAppInfo, SharpUpdateXml updateXmlInfo, int numCurUpdate, int totalUpdate)
        {
            InitializeComponent();

            _applicationInfo = updateLocalAppInfo;

            _updateInfo = updateXmlInfo;

            Text = $"{_applicationInfo.ApplicationName} - ({numCurUpdate}/{totalUpdate} Available Update";

            if (_applicationInfo.ApplicationName != null)
            {
                Icon = _applicationInfo.ApplicationIcon;
            }

            kwlblNewVersion.Text = updateXmlInfo.Tag != JobType.REMOVE ? string.Format(updateXmlInfo.Tag == JobType.UPDATE ? "Update: {0}\nNew Version: {1}" : "New: {0}\nVersion: {1}", Path.GetFileName(_applicationInfo.ApplicationPath), _updateInfo.Version.ToString()) :
                $"Remove: {Path.GetFileName(_applicationInfo.ApplicationPath)}";
        }
        #endregion

        private void kbtnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;

            Close();
        }

        private void kbtnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;

            Close();
        }

        private void kbtnDetails_Click(object sender, EventArgs e)
        {
            if (_updateInfoForm == null)
            {
                _updateInfoForm = new SharpUpdateInfoForm(_applicationInfo, _updateInfo);
            }

            _updateInfoForm.Show(this);
        }
    }
}
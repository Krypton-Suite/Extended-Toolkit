using Krypton.Toolkit.Suite.Extended.Base;
using System;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonRunDialog : KryptonFormExtended
    {
        #region Designer Code
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonUACElevatedButtonVersion1 kuacbtnRun;
        private KryptonCancelDialogButton kdbtnCancel;
        private KryptonButton kbtnBrowse;
        private KryptonOKDialogButton kdbRun;
        private KryptonButton kbtnLocate;
        private KryptonWrapLabel kwlHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private KryptonLabel kryptonLabel1;
        private KryptonComboBox kcmbPath;
        private System.Windows.Forms.PictureBox pbxInputIcon;
        private KryptonButton kbtnRun;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnLocate = new Krypton.Toolkit.KryptonButton();
            this.kuacbtnRun = new Krypton.Toolkit.Suite.Extended.Base.KryptonUACElevatedButtonVersion1();
            this.kdbtnCancel = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonCancelDialogButton();
            this.kbtnBrowse = new Krypton.Toolkit.KryptonButton();
            this.kdbRun = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonOKDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kwlHeader = new Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kcmbPath = new Krypton.Toolkit.KryptonComboBox();
            this.pbxInputIcon = new System.Windows.Forms.PictureBox();
            this.kbtnRun = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInputIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnRun);
            this.kryptonPanel1.Controls.Add(this.kbtnLocate);
            this.kryptonPanel1.Controls.Add(this.kuacbtnRun);
            this.kryptonPanel1.Controls.Add(this.kdbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnBrowse);
            this.kryptonPanel1.Controls.Add(this.kdbRun);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 134);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(550, 43);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnLocate
            // 
            this.kbtnLocate.Location = new System.Drawing.Point(12, 6);
            this.kbtnLocate.Name = "kbtnLocate";
            this.kbtnLocate.Size = new System.Drawing.Size(83, 25);
            this.kbtnLocate.TabIndex = 9;
            this.kbtnLocate.Values.Text = "Loc&ate...";
            this.kbtnLocate.Visible = false;
            this.kbtnLocate.Click += new System.EventHandler(this.kbtnLocate_Click);
            // 
            // kuacbtnRun
            // 
            this.kuacbtnRun.Enabled = false;
            this.kuacbtnRun.Location = new System.Drawing.Point(262, 6);
            this.kuacbtnRun.Name = "kuacbtnRun";
            this.kuacbtnRun.ProcessToElevate = null;
            this.kuacbtnRun.Size = new System.Drawing.Size(90, 26);
            this.kuacbtnRun.TabIndex = 7;
            this.kuacbtnRun.Values.Text = "&Run";
            this.kuacbtnRun.ExecuteProcessAsAdministrator += new Krypton.Toolkit.Suite.Extended.Base.KryptonUACElevatedButtonVersion1.ExecuteProcessAsAdministratorEventHandler(this.kuacbtnRun_ExecuteProcessAsAdministrator);
            // 
            // kdbtnCancel
            // 
            this.kdbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kdbtnCancel.Location = new System.Drawing.Point(358, 6);
            this.kdbtnCancel.Name = "kdbtnCancel";
            this.kdbtnCancel.ParentWindow = null;
            this.kdbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kdbtnCancel.TabIndex = 8;
            this.kdbtnCancel.Values.Text = "C&ancel";
            this.kdbtnCancel.Click += new System.EventHandler(this.kdbtnCancel_Click);
            // 
            // kbtnBrowse
            // 
            this.kbtnBrowse.Location = new System.Drawing.Point(454, 6);
            this.kbtnBrowse.Name = "kbtnBrowse";
            this.kbtnBrowse.Size = new System.Drawing.Size(84, 25);
            this.kbtnBrowse.TabIndex = 6;
            this.kbtnBrowse.Values.Text = "Br&owse...";
            this.kbtnBrowse.Click += new System.EventHandler(this.kbtnBrowse_Click);
            // 
            // kdbRun
            // 
            this.kdbRun.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kdbRun.Enabled = false;
            this.kdbRun.Location = new System.Drawing.Point(262, 6);
            this.kdbRun.Name = "kdbRun";
            this.kdbRun.ParentWindow = null;
            this.kdbRun.Size = new System.Drawing.Size(90, 25);
            this.kdbRun.TabIndex = 5;
            this.kdbRun.Values.Text = "&Run";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 3);
            this.panel1.TabIndex = 3;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.pbxInputIcon);
            this.kryptonPanel2.Controls.Add(this.kcmbPath);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.kwlHeader);
            this.kryptonPanel2.Controls.Add(this.pictureBox1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.ControlCustom1;
            this.kryptonPanel2.Size = new System.Drawing.Size(550, 131);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Krypton.Toolkit.Suite.Extended.Dialogs.Properties.Resources.Run_48_x_48;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // kwlHeader
            // 
            this.kwlHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlHeader.Location = new System.Drawing.Point(67, 13);
            this.kwlHeader.Name = "kwlHeader";
            this.kwlHeader.Size = new System.Drawing.Size(428, 36);
            this.kwlHeader.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlHeader.Text = "Type the name of a application, file, directory or Internet\r\nresource, and Window" +
    "s will open it for you.\r\n";
            this.kwlHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 84);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(55, 21);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 7;
            this.kryptonLabel1.Values.Text = "Open:";
            // 
            // kcmbPath
            // 
            this.kcmbPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.kcmbPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.kcmbPath.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.kcmbPath.DropDownWidth = 426;
            this.kcmbPath.IntegralHeight = false;
            this.kcmbPath.Location = new System.Drawing.Point(74, 84);
            this.kcmbPath.Name = "kcmbPath";
            this.kcmbPath.Size = new System.Drawing.Size(426, 22);
            this.kcmbPath.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbPath.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbPath.TabIndex = 8;
            // 
            // pbxInputIcon
            // 
            this.pbxInputIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxInputIcon.Location = new System.Drawing.Point(506, 81);
            this.pbxInputIcon.Name = "pbxInputIcon";
            this.pbxInputIcon.Size = new System.Drawing.Size(32, 32);
            this.pbxInputIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxInputIcon.TabIndex = 9;
            this.pbxInputIcon.TabStop = false;
            // 
            // kbtnRun
            // 
            this.kbtnRun.Enabled = false;
            this.kbtnRun.Location = new System.Drawing.Point(262, 7);
            this.kbtnRun.Name = "kbtnRun";
            this.kbtnRun.Size = new System.Drawing.Size(90, 25);
            this.kbtnRun.TabIndex = 5;
            this.kbtnRun.Values.Text = "&Run";
            this.kbtnRun.Click += new System.EventHandler(this.kbtnRun_Click);
            // 
            // KryptonRunDialog
            // 
            this.ClientSize = new System.Drawing.Size(550, 177);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonRunDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Run";
            this.Load += new System.EventHandler(this.KryptonRunDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInputIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion


        #region Event Handlers
        private void KryptonRunDialog_Load(object sender, EventArgs e)
        {

        }

        private void kbtnLocate_Click(object sender, EventArgs e)
        {

        }

        private void kuacbtnRun_ExecuteProcessAsAdministrator(object sender, ExecuteProcessAsAdministratorEventArgs e)
        {

        }

        private void kdbtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void kbtnBrowse_Click(object sender, EventArgs e)
        {

        }

        private void kbtnRun_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
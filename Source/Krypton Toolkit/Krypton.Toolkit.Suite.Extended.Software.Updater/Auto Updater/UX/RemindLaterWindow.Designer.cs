namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    partial class RemindLaterWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindLaterWindow));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kwlHeader = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlDescription = new Krypton.Toolkit.KryptonWrapLabel();
            this.krbYes = new Krypton.Toolkit.KryptonRadioButton();
            this.kcmbRemindLater = new Krypton.Toolkit.KryptonComboBox();
            this.krbNo = new Krypton.Toolkit.KryptonRadioButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbRemindLater)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonTableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(596, 208);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel1.ColumnCount = 3;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kryptonTableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kwlHeader, 1, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kwlDescription, 1, 1);
            this.kryptonTableLayoutPanel1.Controls.Add(this.krbYes, 1, 2);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kcmbRemindLater, 2, 2);
            this.kryptonTableLayoutPanel1.Controls.Add(this.krbNo, 1, 3);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kbtnOk, 2, 4);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.RowCount = 5;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(596, 208);
            this.kryptonTableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.clock_go1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.kryptonTableLayoutPanel1.SetRowSpan(this.pictureBox1, 2);
            this.pictureBox1.Size = new System.Drawing.Size(80, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kwlHeader
            // 
            this.kwlHeader.AutoSize = false;
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kwlHeader, 2);
            this.kwlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlHeader.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlHeader.Location = new System.Drawing.Point(89, 0);
            this.kwlHeader.Name = "kwlHeader";
            this.kwlHeader.Size = new System.Drawing.Size(504, 23);
            this.kwlHeader.StateCommon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlHeader.Text = "Do you want to download updates later?";
            // 
            // kwlDescription
            // 
            this.kwlDescription.AutoSize = false;
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kwlDescription, 2);
            this.kwlDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlDescription.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlDescription.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlDescription.Location = new System.Drawing.Point(89, 23);
            this.kwlDescription.Name = "kwlDescription";
            this.kwlDescription.Size = new System.Drawing.Size(504, 93);
            this.kwlDescription.StateCommon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlDescription.Text = "You should download updates now. This only takes few minutes depending on your in" +
    "ternet connection and ensures you have latest version of the application.";
            this.kwlDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // krbYes
            // 
            this.krbYes.Checked = true;
            this.krbYes.Location = new System.Drawing.Point(89, 119);
            this.krbYes.Name = "krbYes";
            this.krbYes.Size = new System.Drawing.Size(218, 24);
            this.krbYes.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.krbYes.TabIndex = 3;
            this.krbYes.Values.Text = "Yes, please remind me later : ";
            this.krbYes.CheckedChanged += new System.EventHandler(this.krbYes_CheckedChanged);
            // 
            // kcmbRemindLater
            // 
            this.kcmbRemindLater.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcmbRemindLater.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbRemindLater.DropDownWidth = 249;
            this.kcmbRemindLater.IntegralHeight = false;
            this.kcmbRemindLater.Location = new System.Drawing.Point(344, 119);
            this.kcmbRemindLater.Name = "kcmbRemindLater";
            this.kcmbRemindLater.Size = new System.Drawing.Size(249, 25);
            this.kcmbRemindLater.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbRemindLater.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbRemindLater.TabIndex = 4;
            // 
            // krbNo
            // 
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.krbNo, 2);
            this.krbNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krbNo.Location = new System.Drawing.Point(89, 150);
            this.krbNo.Name = "krbNo";
            this.krbNo.Size = new System.Drawing.Size(504, 24);
            this.krbNo.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.krbNo.TabIndex = 5;
            this.krbNo.Values.Text = "No, download updates now (recommended)";
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnOk.Location = new System.Drawing.Point(344, 180);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(249, 25);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 6;
            this.kbtnOk.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.clock_go;
            this.kbtnOk.Values.Text = "Ok";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // RemindLaterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 208);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemindLaterWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remind me later to update";
            this.Load += new System.EventHandler(this.RemindLaterWindow_Load);
            this.Controls.SetChildIndex(this.kryptonPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbRemindLater)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private PictureBox pictureBox1;
        private KryptonWrapLabel kwlHeader;
        private KryptonWrapLabel kwlDescription;
        private KryptonRadioButton krbYes;
        private KryptonComboBox kcmbRemindLater;
        private KryptonRadioButton krbNo;
        private KryptonButton kbtnOk;
    }
}
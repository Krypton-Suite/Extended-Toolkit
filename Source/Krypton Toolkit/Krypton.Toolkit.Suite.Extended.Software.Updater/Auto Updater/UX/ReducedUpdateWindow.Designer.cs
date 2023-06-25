namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    partial class ReducedUpdateWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReducedUpdateWindow));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kwlHeader = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlDescription = new Krypton.Toolkit.KryptonWrapLabel();
            this.kbtnSkip = new Krypton.Toolkit.KryptonButton();
            this.kbtnRemind = new Krypton.Toolkit.KryptonButton();
            this.kbtnUpdate = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonTableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(697, 110);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel1.ColumnCount = 4;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.kryptonTableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kwlHeader, 1, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kwlDescription, 1, 1);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kbtnSkip, 1, 2);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kbtnRemind, 2, 2);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kbtnUpdate, 3, 2);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.kryptonTableLayoutPanel1.RowCount = 3;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(697, 110);
            this.kryptonTableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.update_48_x_48;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.kryptonTableLayoutPanel1.SetRowSpan(this.pictureBox1, 2);
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kwlHeader
            // 
            this.kwlHeader.AutoSize = false;
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kwlHeader, 3);
            this.kwlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kwlHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlHeader.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlHeader.Location = new System.Drawing.Point(78, 5);
            this.kwlHeader.Name = "kwlHeader";
            this.kwlHeader.Size = new System.Drawing.Size(616, 23);
            this.kwlHeader.StateCommon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kwlHeader.Text = "kryptonWrapLabel1";
            // 
            // kwlDescription
            // 
            this.kwlDescription.AutoSize = false;
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kwlDescription, 3);
            this.kwlDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlDescription.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlDescription.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlDescription.Location = new System.Drawing.Point(78, 28);
            this.kwlDescription.Name = "kwlDescription";
            this.kwlDescription.Size = new System.Drawing.Size(616, 47);
            this.kwlDescription.StateCommon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlDescription.Text = "kryptonWrapLabel2";
            // 
            // kbtnSkip
            // 
            this.kbtnSkip.AutoSize = true;
            this.kbtnSkip.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnSkip.Dock = System.Windows.Forms.DockStyle.Left;
            this.kbtnSkip.Location = new System.Drawing.Point(78, 78);
            this.kbtnSkip.Name = "kbtnSkip";
            this.kbtnSkip.Size = new System.Drawing.Size(133, 29);
            this.kbtnSkip.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSkip.TabIndex = 3;
            this.kbtnSkip.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.hand_point;
            this.kbtnSkip.Values.Text = "kryptonButton1";
            this.kbtnSkip.Click += new System.EventHandler(this.kbtnSkip_Click);
            // 
            // kbtnRemind
            // 
            this.kbtnRemind.AutoSize = true;
            this.kbtnRemind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnRemind.Dock = System.Windows.Forms.DockStyle.Right;
            this.kbtnRemind.Location = new System.Drawing.Point(353, 78);
            this.kbtnRemind.Name = "kbtnRemind";
            this.kbtnRemind.Size = new System.Drawing.Size(133, 29);
            this.kbtnRemind.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRemind.TabIndex = 4;
            this.kbtnRemind.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.clock_go;
            this.kbtnRemind.Values.Text = "kryptonButton2";
            this.kbtnRemind.Click += new System.EventHandler(this.kbtnRemind_Click);
            // 
            // kbtnUpdate
            // 
            this.kbtnUpdate.AutoSize = true;
            this.kbtnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.kbtnUpdate.Location = new System.Drawing.Point(561, 78);
            this.kbtnUpdate.Name = "kbtnUpdate";
            this.kbtnUpdate.Size = new System.Drawing.Size(133, 29);
            this.kbtnUpdate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnUpdate.TabIndex = 5;
            this.kbtnUpdate.Values.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.download;
            this.kbtnUpdate.Values.Text = "kryptonButton3";
            this.kbtnUpdate.Click += new System.EventHandler(this.kbtnUpdate_Click);
            // 
            // ReducedUpdateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 110);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReducedUpdateWindow";
            this.Text = "ReducedUpdateWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReducedUpdateWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReducedUpdateWindow_FormClosed);
            this.Controls.SetChildIndex(this.kryptonPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private PictureBox pictureBox1;
        private KryptonWrapLabel kwlHeader;
        private KryptonWrapLabel kwlDescription;
        private KryptonButton kbtnSkip;
        private KryptonButton kbtnRemind;
        private KryptonButton kbtnUpdate;
    }
}
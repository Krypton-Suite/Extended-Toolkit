namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    partial class KryptonRunDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonRunDialog));
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kryptonSplitButton1 = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonSplitButton();
            this.kctxRun = new Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems1 = new Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem1 = new Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuSeparator1 = new Krypton.Toolkit.KryptonContextMenuSeparator();
            this.kryptonContextMenuItems2 = new Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem2 = new Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kbtnBrowse = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.pbxResourceIcon = new System.Windows.Forms.PictureBox();
            this.kcmbRunPath = new Krypton.Toolkit.KryptonComboBox();
            this.bsReset = new Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonWrapLabel1 = new Krypton.Toolkit.KryptonWrapLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonContextMenuItems3 = new Krypton.Toolkit.KryptonContextMenuItems();
            this.kcmdRunAsAdministrator = new Krypton.Toolkit.KryptonCommand();
            this.kcmdOpenInExplorer = new Krypton.Toolkit.KryptonCommand();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxResourceIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbRunPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.kryptonSplitButton1);
            this.kpnlButtons.Controls.Add(this.kryptonButton2);
            this.kpnlButtons.Controls.Add(this.kbtnBrowse);
            this.kpnlButtons.Controls.Add(this.kryptonBorderEdge1);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 118);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlButtons.Size = new System.Drawing.Size(384, 50);
            this.kpnlButtons.TabIndex = 0;
            // 
            // kryptonSplitButton1
            // 
            this.kryptonSplitButton1.AutoSize = true;
            this.kryptonSplitButton1.CornerRoundingRadius = -1F;
            this.kryptonSplitButton1.KryptonContextMenu = this.kctxRun;
            this.kryptonSplitButton1.Location = new System.Drawing.Point(62, 13);
            this.kryptonSplitButton1.Name = "kryptonSplitButton1";
            this.kryptonSplitButton1.ProcessPath = null;
            this.kryptonSplitButton1.ShowSplitOption = true;
            this.kryptonSplitButton1.Size = new System.Drawing.Size(118, 25);
            this.kryptonSplitButton1.TabIndex = 3;
            this.kryptonSplitButton1.UseUACElevation = false;
            this.kryptonSplitButton1.Values.Text = "&Run...";
            // 
            // kctxRun
            // 
            this.kctxRun.Items.AddRange(new Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItems1,
            this.kryptonContextMenuSeparator1,
            this.kryptonContextMenuItems2});
            // 
            // kryptonContextMenuItems1
            // 
            this.kryptonContextMenuItems1.Items.AddRange(new Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem1});
            // 
            // kryptonContextMenuItem1
            // 
            this.kryptonContextMenuItem1.KryptonCommand = this.kcmdRunAsAdministrator;
            this.kryptonContextMenuItem1.Text = "Run as &Administrator";
            // 
            // kryptonContextMenuItems2
            // 
            this.kryptonContextMenuItems2.Items.AddRange(new Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem2});
            // 
            // kryptonContextMenuItem2
            // 
            this.kryptonContextMenuItem2.KryptonCommand = this.kcmdOpenInExplorer;
            this.kryptonContextMenuItem2.Text = "&Open in Explorer";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.CornerRoundingRadius = -1F;
            this.kryptonButton2.Location = new System.Drawing.Point(186, 13);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton2.TabIndex = 2;
            this.kryptonButton2.Values.Text = "kryptonButton2";
            // 
            // kbtnBrowse
            // 
            this.kbtnBrowse.CornerRoundingRadius = -1F;
            this.kbtnBrowse.Location = new System.Drawing.Point(282, 13);
            this.kbtnBrowse.Name = "kbtnBrowse";
            this.kbtnBrowse.Size = new System.Drawing.Size(90, 25);
            this.kbtnBrowse.TabIndex = 1;
            this.kbtnBrowse.Values.Text = "&Browse...";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(384, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pbxResourceIcon);
            this.kryptonPanel1.Controls.Add(this.kcmbRunPath);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel1);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(384, 118);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // pbxResourceIcon
            // 
            this.pbxResourceIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxResourceIcon.Location = new System.Drawing.Point(340, 74);
            this.pbxResourceIcon.Name = "pbxResourceIcon";
            this.pbxResourceIcon.Size = new System.Drawing.Size(32, 32);
            this.pbxResourceIcon.TabIndex = 4;
            this.pbxResourceIcon.TabStop = false;
            // 
            // kcmbRunPath
            // 
            this.kcmbRunPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.kcmbRunPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.kcmbRunPath.ButtonSpecs.AddRange(new Krypton.Toolkit.ButtonSpecAny[] {
            this.bsReset});
            this.kcmbRunPath.CornerRoundingRadius = -1F;
            this.kcmbRunPath.CueHint.CueHintText = "Enter a path here...";
            this.kcmbRunPath.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.kcmbRunPath.DropDownWidth = 261;
            this.kcmbRunPath.IntegralHeight = false;
            this.kcmbRunPath.Location = new System.Drawing.Point(68, 79);
            this.kcmbRunPath.Name = "kcmbRunPath";
            this.kcmbRunPath.Size = new System.Drawing.Size(266, 22);
            this.kcmbRunPath.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbRunPath.TabIndex = 3;
            this.kcmbRunPath.SelectedIndexChanged += new System.EventHandler(this.kcmbRunPath_SelectedIndexChanged);
            this.kcmbRunPath.TextChanged += new System.EventHandler(this.kcmbRunPath_TextChanged);
            // 
            // bsReset
            // 
            this.bsReset.Image = global::Krypton.Toolkit.Suite.Extended.Dialogs.Properties.Resources.Reset_16_x_16;
            this.bsReset.UniqueName = "507c0d829f7c4761888b3e000666f115";
            this.bsReset.Click += new System.EventHandler(this.bsReset_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 79);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Open:";
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.AutoSize = false;
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(68, 13);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(304, 48);
            this.kryptonWrapLabel1.Text = "Type the name of a application, directory, document or Internet resource, and Win" +
    "dows will open it for you.";
            this.kryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Krypton.Toolkit.Suite.Extended.Dialogs.Properties.Resources.Run_481;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kcmdRunAsAdministrator
            // 
            this.kcmdRunAsAdministrator.Text = "Run process as &administrator";
            // 
            // kcmdOpenInExplorer
            // 
            this.kcmdOpenInExplorer.Text = "&Open in file explorer";
            this.kcmdOpenInExplorer.Execute += new System.EventHandler(this.kcmdOpenInExplorer_Execute);
            // 
            // KryptonRunDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 168);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.FormTitleAlign = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonRunDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 5F;
            this.Text = "Run";
            this.Load += new System.EventHandler(this.KryptonRunDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxResourceIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbRunPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kpnlButtons;
        private KryptonButton kryptonButton2;
        private KryptonButton kbtnBrowse;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel1;
        private Dialogs.KryptonSplitButton kryptonSplitButton1;
        private PictureBox pictureBox1;
        private KryptonContextMenu kctxRun;
        private KryptonContextMenuItems kryptonContextMenuItems1;
        private KryptonContextMenuItem kryptonContextMenuItem1;
        private KryptonContextMenuSeparator kryptonContextMenuSeparator1;
        private KryptonContextMenuItems kryptonContextMenuItems2;
        private KryptonContextMenuItem kryptonContextMenuItem2;
        private KryptonContextMenuItems kryptonContextMenuItems3;
        private KryptonCommand kcmdRunAsAdministrator;
        private KryptonCommand kcmdOpenInExplorer;
        private KryptonWrapLabel kryptonWrapLabel1;
        private PictureBox pbxResourceIcon;
        private KryptonComboBox kcmbRunPath;
        private ButtonSpecAny bsReset;
        private KryptonLabel kryptonLabel1;
    }
}
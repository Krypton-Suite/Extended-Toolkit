#pragma warning disable CS0169
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
            this.components = new System.ComponentModel.Container();
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.ksbRun = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonSplitButton();
            this.kcmRunOptions = new Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems2 = new Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItem3 = new Krypton.Toolkit.KryptonContextMenuItem();
            this.kcmdOpenInExplorer = new Krypton.Toolkit.KryptonCommand();
            this.kryptonContextMenuSeparator2 = new Krypton.Toolkit.KryptonContextMenuSeparator();
            this.kryptonContextMenuItem4 = new Krypton.Toolkit.KryptonContextMenuItem();
            this.kcmdOpenAsAdministrator = new Krypton.Toolkit.KryptonCommand();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnSettings = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.kcmbFilePath = new Krypton.Toolkit.KryptonComboBox();
            this.bsBrowse = new Krypton.Toolkit.ButtonSpecAny();
            this.bsReset = new Krypton.Toolkit.ButtonSpecAny();
            this.pbxProcessIcon = new System.Windows.Forms.PictureBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kwlHeader = new Krypton.Toolkit.KryptonWrapLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ttAppIcon = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).BeginInit();
            this.kpnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProcessIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.ksbRun);
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Controls.Add(this.kbtnSettings);
            this.kpnlButtons.Controls.Add(this.kryptonBorderEdge1);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 118);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlButtons.Size = new System.Drawing.Size(394, 50);
            this.kpnlButtons.TabIndex = 0;
            // 
            // ksbRun
            // 
            this.ksbRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ksbRun.AutoSize = true;
            this.ksbRun.CornerRoundingRadius = -1F;
            this.ksbRun.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ksbRun.Enabled = false;
            this.ksbRun.KryptonContextMenu = this.kcmRunOptions;
            this.ksbRun.Location = new System.Drawing.Point(168, 13);
            this.ksbRun.Name = "ksbRun";
            this.ksbRun.Size = new System.Drawing.Size(118, 25);
            this.ksbRun.TabIndex = 2;
            this.ksbRun.Values.Text = "Ru&n...";
            // 
            // kcmRunOptions
            // 
            this.kcmRunOptions.Items.AddRange(new Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItems2});
            // 
            // kryptonContextMenuItems2
            // 
            this.kryptonContextMenuItems2.Items.AddRange(new Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItem3,
            this.kryptonContextMenuSeparator2,
            this.kryptonContextMenuItem4});
            // 
            // kryptonContextMenuItem3
            // 
            this.kryptonContextMenuItem3.KryptonCommand = this.kcmdOpenInExplorer;
            this.kryptonContextMenuItem3.Text = "Menu Item";
            // 
            // kcmdOpenInExplorer
            // 
            this.kcmdOpenInExplorer.Text = "kryptonCommand1";
            // 
            // kryptonContextMenuItem4
            // 
            this.kryptonContextMenuItem4.KryptonCommand = this.kcmdOpenAsAdministrator;
            this.kryptonContextMenuItem4.Text = "Menu Item";
            // 
            // kcmdOpenAsAdministrator
            // 
            this.kcmdOpenAsAdministrator.Text = "kryptonCommand2";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.CornerRoundingRadius = -1F;
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(292, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 3;
            this.kbtnCancel.Values.Text = "Can&cel";
            // 
            // kbtnSettings
            // 
            this.kbtnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnSettings.CornerRoundingRadius = -1F;
            this.kbtnSettings.Location = new System.Drawing.Point(12, 13);
            this.kbtnSettings.Name = "kbtnSettings";
            this.kbtnSettings.Size = new System.Drawing.Size(90, 25);
            this.kbtnSettings.TabIndex = 2;
            this.kbtnSettings.Values.Text = "&Settings";
            this.kbtnSettings.Click += new System.EventHandler(this.kbtnSettings_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(394, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kpnlContent
            // 
            this.kpnlContent.Controls.Add(this.kcmbFilePath);
            this.kpnlContent.Controls.Add(this.pbxProcessIcon);
            this.kpnlContent.Controls.Add(this.kryptonLabel1);
            this.kpnlContent.Controls.Add(this.kwlHeader);
            this.kpnlContent.Controls.Add(this.pictureBox1);
            this.kpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContent.Location = new System.Drawing.Point(0, 0);
            this.kpnlContent.Name = "kpnlContent";
            this.kpnlContent.Size = new System.Drawing.Size(394, 118);
            this.kpnlContent.TabIndex = 1;
            // 
            // kcmbFilePath
            // 
            this.kcmbFilePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.kcmbFilePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.kcmbFilePath.ButtonSpecs.AddRange(new Krypton.Toolkit.ButtonSpecAny[] {
            this.bsBrowse,
            this.bsReset});
            this.kcmbFilePath.CornerRoundingRadius = -1F;
            this.kcmbFilePath.DropDownWidth = 258;
            this.kcmbFilePath.IntegralHeight = false;
            this.kcmbFilePath.Location = new System.Drawing.Point(68, 79);
            this.kcmbFilePath.Name = "kcmbFilePath";
            this.kcmbFilePath.Size = new System.Drawing.Size(276, 24);
            this.kcmbFilePath.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbFilePath.TabIndex = 4;
            this.kcmbFilePath.TextChanged += new System.EventHandler(this.kcmbFilePath_TextChanged);
            // 
            // bsBrowse
            // 
            this.bsBrowse.Text = "..&.";
            this.bsBrowse.UniqueName = "8a1d6890727c478dade41dcbdbd74238";
            this.bsBrowse.Click += new System.EventHandler(this.bsBrowse_Click);
            // 
            // bsReset
            // 
            this.bsReset.UniqueName = "931933948ca64018931b454e39422fc6";
            this.bsReset.Visible = false;
            // 
            // pbxProcessIcon
            // 
            this.pbxProcessIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxProcessIcon.Location = new System.Drawing.Point(350, 76);
            this.pbxProcessIcon.Name = "pbxProcessIcon";
            this.pbxProcessIcon.Size = new System.Drawing.Size(32, 32);
            this.pbxProcessIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxProcessIcon.TabIndex = 3;
            this.pbxProcessIcon.TabStop = false;
            this.pbxProcessIcon.MouseEnter += new System.EventHandler(this.pbxProcessIcon_MouseEnter);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(16, 79);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Open:";
            // 
            // kwlHeader
            // 
            this.kwlHeader.AutoEllipsis = true;
            this.kwlHeader.AutoSize = false;
            this.kwlHeader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlHeader.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlHeader.Location = new System.Drawing.Point(68, 13);
            this.kwlHeader.Name = "kwlHeader";
            this.kwlHeader.Size = new System.Drawing.Size(314, 48);
            this.kwlHeader.Text = "kryptonWrapLabel1";
            this.kwlHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // KryptonRunDialog
            // 
            this.AcceptButton = this.ksbRun;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(394, 168);
            this.Controls.Add(this.kpnlContent);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
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
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            this.kpnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProcessIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kpnlButtons;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnSettings;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kpnlContent;
        private KryptonContextMenuItems kryptonContextMenuItems1;
        private KryptonContextMenuItem kryptonContextMenuItem1;
        private KryptonContextMenuSeparator kryptonContextMenuSeparator1;
        private KryptonContextMenuItem kryptonContextMenuItem2;
        private KryptonContextMenuHeading kryptonContextMenuHeading1;
        private Dialogs.KryptonSplitButton ksbRun;
        private KryptonContextMenu kcmRunOptions;
        private KryptonContextMenuItems kryptonContextMenuItems2;
        private KryptonContextMenuItem kryptonContextMenuItem3;
        private KryptonContextMenuSeparator kryptonContextMenuSeparator2;
        private KryptonContextMenuItem kryptonContextMenuItem4;
        private PictureBox pictureBox1;
        private KryptonWrapLabel kwlHeader;
        private KryptonLabel kryptonLabel1;
        private PictureBox pbxProcessIcon;
        private KryptonComboBox kcmbFilePath;
        private ButtonSpecAny bsBrowse;
        private ButtonSpecAny bsReset;
        private KryptonCommand kcmdOpenInExplorer;
        private KryptonCommand kcmdOpenAsAdministrator;
        private ToolTip ttAppIcon;
    }
}
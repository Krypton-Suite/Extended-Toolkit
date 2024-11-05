namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    partial class KryptonExternalThemeSelectorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonExternalThemeSelectorForm));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.klblPath = new Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel3 = new Krypton.Toolkit.KryptonPanel();
            this.klvThemesList = new Krypton.Toolkit.KryptonListView();
            this.klbThemesList = new Krypton.Toolkit.KryptonListBox();
            this.ktxtThemeLocation = new Krypton.Toolkit.KryptonTextBox();
            this.bsaReset = new Krypton.Toolkit.ButtonSpecAny();
            this.bsaBrowse = new Krypton.Toolkit.ButtonSpecAny();
            this.kmanCustom = new Krypton.Toolkit.KryptonManager(this.components);
            this.kcpbCustom = new Krypton.Toolkit.KryptonCustomPaletteBase(this.components);
            this.kchkSilent = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnApply = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnApply);
            this.kryptonPanel1.Controls.Add(this.kchkSilent);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 400);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(800, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonTableLayoutPanel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(800, 400);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel1.ColumnCount = 2;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.Controls.Add(this.klblPath, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonPanel3, 0, 1);
            this.kryptonTableLayoutPanel1.Controls.Add(this.ktxtThemeLocation, 1, 0);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.RowCount = 2;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(800, 400);
            this.kryptonTableLayoutPanel1.TabIndex = 0;
            // 
            // klblPath
            // 
            this.klblPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblPath.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.klblPath.Location = new System.Drawing.Point(3, 3);
            this.klblPath.Name = "klblPath";
            this.klblPath.Size = new System.Drawing.Size(60, 24);
            this.klblPath.TabIndex = 0;
            this.klblPath.Values.Text = "{0} Path:";
            // 
            // kryptonPanel3
            // 
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kryptonPanel3, 2);
            this.kryptonPanel3.Controls.Add(this.klvThemesList);
            this.kryptonPanel3.Controls.Add(this.klbThemesList);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(3, 33);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(794, 364);
            this.kryptonPanel3.TabIndex = 1;
            // 
            // klvThemesList
            // 
            this.klvThemesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.klvThemesList.HideSelection = false;
            this.klvThemesList.Location = new System.Drawing.Point(10, 4);
            this.klvThemesList.Name = "klvThemesList";
            this.klvThemesList.Size = new System.Drawing.Size(775, 357);
            this.klvThemesList.TabIndex = 1;
            // 
            // klbThemesList
            // 
            this.klbThemesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.klbThemesList.Location = new System.Drawing.Point(10, 4);
            this.klbThemesList.Name = "klbThemesList";
            this.klbThemesList.Size = new System.Drawing.Size(775, 357);
            this.klbThemesList.TabIndex = 0;
            this.klbThemesList.SelectedIndexChanged += new System.EventHandler(this.klbThemesList_SelectedIndexChanged);
            // 
            // ktxtThemeLocation
            // 
            this.ktxtThemeLocation.ButtonSpecs.AddRange(new Krypton.Toolkit.ButtonSpecAny[] {
            this.bsaReset,
            this.bsaBrowse});
            this.ktxtThemeLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktxtThemeLocation.Location = new System.Drawing.Point(69, 3);
            this.ktxtThemeLocation.Name = "ktxtThemeLocation";
            this.ktxtThemeLocation.Size = new System.Drawing.Size(728, 24);
            this.ktxtThemeLocation.TabIndex = 2;
            // 
            // bsaReset
            // 
            this.bsaReset.Enabled = Krypton.Toolkit.ButtonEnabled.False;
            this.bsaReset.Image = ((System.Drawing.Image)(resources.GetObject("bsaReset.Image")));
            this.bsaReset.UniqueName = "2cf6271f3bf34def81a5806bd986688e";
            this.bsaReset.Click += new System.EventHandler(this.bsaReset_Click);
            // 
            // bsaBrowse
            // 
            this.bsaBrowse.Text = "...";
            this.bsaBrowse.UniqueName = "88cf7c5da23f4b3a89a8338b2ee0bb92";
            this.bsaBrowse.Click += new System.EventHandler(this.bsaBrowse_Click);
            // 
            // kcpbCustom
            // 
            this.kcpbCustom.BasePaletteType = Krypton.Toolkit.BasePaletteType.Custom;
            this.kcpbCustom.ThemeName = null;
            // 
            // kchkSilent
            // 
            this.kchkSilent.Location = new System.Drawing.Point(13, 17);
            this.kchkSilent.Name = "kchkSilent";
            this.kchkSilent.Size = new System.Drawing.Size(54, 20);
            this.kchkSilent.TabIndex = 5;
            this.kchkSilent.Values.Text = "&Silent";
            // 
            // kbtnApply
            // 
            this.kbtnApply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnApply.Enabled = false;
            this.kbtnApply.Location = new System.Drawing.Point(698, 13);
            this.kbtnApply.Name = "kbtnApply";
            this.kbtnApply.Size = new System.Drawing.Size(90, 25);
            this.kbtnApply.TabIndex = 6;
            this.kbtnApply.Values.Text = "kryptonButton1";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(602, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 7;
            this.kbtnCancel.Values.Text = "kryptonButton2";
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(506, 13);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 8;
            this.kbtnOk.Values.Text = "kryptonButton3";
            // 
            // KryptonExternalThemeSelectorForm
            // 
            this.AcceptButton = this.kbtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonExternalThemeSelectorForm";
            this.ShowInTaskbar = false;
            this.Text = "Krypton External Theme Selector";
            this.Load += new System.EventHandler(this.KryptonExternalThemeSelectorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonManager kmanCustom;
        private KryptonCustomPaletteBase kcpbCustom;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private KryptonLabel klblPath;
        private KryptonPanel kryptonPanel3;
        private KryptonTextBox ktxtThemeLocation;
        private ButtonSpecAny bsaReset;
        private ButtonSpecAny bsaBrowse;
        private KryptonListBox klbThemesList;
        private KryptonListView klvThemesList;
        private KryptonCheckBox kchkSilent;
        private KryptonButton kbtnApply;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnOk;
    }
}
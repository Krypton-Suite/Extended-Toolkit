#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion



namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class ThemeSwitcherOptionsOld : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnApply;
        private KryptonButton kbtnCancel;
        private KryptonPanel klblCustomPalettePath;
        private KryptonComboBox kcmbPaletteMode;
        private KryptonLabel kryptonLabel1;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonCheckBox kchkReset;
        private KryptonCheckBox kchkImport;
        private KryptonButton kbtnReset;
        private KryptonButton kbtnImport;
        private KryptonButton kbtnLocate;
        private KryptonWrapLabel kwlPaletteName;
        private KryptonCheckBox kchkAskMe;
        private KryptonButton kbtnDownload;
        private KryptonButton kbtnSubmit;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnReset = new Krypton.Toolkit.KryptonButton();
            this.kbtnApply = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.klblCustomPalettePath = new Krypton.Toolkit.KryptonPanel();
            this.kbtnDownload = new Krypton.Toolkit.KryptonButton();
            this.kbtnSubmit = new Krypton.Toolkit.KryptonButton();
            this.kwlPaletteName = new Krypton.Toolkit.KryptonWrapLabel();
            this.kbtnLocate = new Krypton.Toolkit.KryptonButton();
            this.kbtnImport = new Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kchkAskMe = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkReset = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkImport = new Krypton.Toolkit.KryptonCheckBox();
            this.kcmbPaletteMode = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.klblCustomPalettePath)).BeginInit();
            this.klblCustomPalettePath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPaletteMode)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnReset);
            this.kryptonPanel1.Controls.Add(this.kbtnApply);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 309);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(626, 50);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kbtnReset
            // 
            this.kbtnReset.Enabled = false;
            this.kbtnReset.Location = new System.Drawing.Point(12, 13);
            this.kbtnReset.Name = "kbtnReset";
            this.kbtnReset.Size = new System.Drawing.Size(121, 25);
            this.kbtnReset.TabIndex = 3;
            this.kbtnReset.Values.Text = "Reset to &Defaults";
            this.kbtnReset.Click += new System.EventHandler(this.kbtnReset_Click);
            // 
            // kbtnApply
            // 
            this.kbtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnApply.Enabled = false;
            this.kbtnApply.Location = new System.Drawing.Point(428, 13);
            this.kbtnApply.Name = "kbtnApply";
            this.kbtnApply.Size = new System.Drawing.Size(90, 25);
            this.kbtnApply.TabIndex = 2;
            this.kbtnApply.Values.Text = "A&pply";
            this.kbtnApply.Click += new System.EventHandler(this.kbtnApply_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(524, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(626, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // klblCustomPalettePath
            // 
            this.klblCustomPalettePath.Controls.Add(this.kbtnDownload);
            this.klblCustomPalettePath.Controls.Add(this.kbtnSubmit);
            this.klblCustomPalettePath.Controls.Add(this.kwlPaletteName);
            this.klblCustomPalettePath.Controls.Add(this.kbtnLocate);
            this.klblCustomPalettePath.Controls.Add(this.kbtnImport);
            this.klblCustomPalettePath.Controls.Add(this.kryptonGroupBox1);
            this.klblCustomPalettePath.Controls.Add(this.kcmbPaletteMode);
            this.klblCustomPalettePath.Controls.Add(this.kryptonLabel1);
            this.klblCustomPalettePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblCustomPalettePath.Location = new System.Drawing.Point(0, 0);
            this.klblCustomPalettePath.Name = "klblCustomPalettePath";
            this.klblCustomPalettePath.Size = new System.Drawing.Size(626, 309);
            this.klblCustomPalettePath.TabIndex = 3;
            // 
            // kbtnDownload
            // 
            this.kbtnDownload.Location = new System.Drawing.Point(269, 108);
            this.kbtnDownload.Name = "kbtnDownload";
            this.kbtnDownload.Size = new System.Drawing.Size(189, 25);
            this.kbtnDownload.TabIndex = 7;
            this.kbtnDownload.Values.Text = "&Download Additional Themes";
            this.kbtnDownload.Click += new System.EventHandler(this.kbtnDownload_Click);
            // 
            // kbtnSubmit
            // 
            this.kbtnSubmit.Location = new System.Drawing.Point(464, 108);
            this.kbtnSubmit.Name = "kbtnSubmit";
            this.kbtnSubmit.Size = new System.Drawing.Size(138, 25);
            this.kbtnSubmit.TabIndex = 6;
            this.kbtnSubmit.Values.Text = "&Submit a Theme";
            this.kbtnSubmit.Click += new System.EventHandler(this.kbtnSubmit_Click);
            // 
            // kwlPaletteName
            // 
            this.kwlPaletteName.AutoSize = false;
            this.kwlPaletteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlPaletteName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlPaletteName.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kwlPaletteName.Location = new System.Drawing.Point(12, 58);
            this.kwlPaletteName.Name = "kwlPaletteName";
            this.kwlPaletteName.Size = new System.Drawing.Size(602, 37);
            this.kwlPaletteName.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlPaletteName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kbtnLocate
            // 
            this.kbtnLocate.Enabled = false;
            this.kbtnLocate.Location = new System.Drawing.Point(125, 108);
            this.kbtnLocate.Name = "kbtnLocate";
            this.kbtnLocate.Size = new System.Drawing.Size(138, 25);
            this.kbtnLocate.TabIndex = 5;
            this.kbtnLocate.Values.Text = "&Locate Theme File";
            this.kbtnLocate.Click += new System.EventHandler(this.kbtnLocate_Click);
            // 
            // kbtnImport
            // 
            this.kbtnImport.Location = new System.Drawing.Point(29, 108);
            this.kbtnImport.Name = "kbtnImport";
            this.kbtnImport.Size = new System.Drawing.Size(90, 25);
            this.kbtnImport.TabIndex = 4;
            this.kbtnImport.Values.Text = "Im&port";
            this.kbtnImport.Click += new System.EventHandler(this.kbtnImport_Click);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(72, 139);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkAskMe);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkReset);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkImport);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(506, 153);
            this.kryptonGroupBox1.TabIndex = 2;
            this.kryptonGroupBox1.Values.Heading = "User Interface Elements";
            // 
            // kchkAskMe
            // 
            this.kchkAskMe.Location = new System.Drawing.Point(17, 90);
            this.kchkAskMe.Name = "kchkAskMe";
            this.kchkAskMe.Size = new System.Drawing.Size(294, 20);
            this.kchkAskMe.TabIndex = 5;
            this.kchkAskMe.Values.Text = "&Always ask me to save or reset my theme settings";
            // 
            // kchkReset
            // 
            this.kchkReset.Location = new System.Drawing.Point(17, 53);
            this.kchkReset.Name = "kchkReset";
            this.kchkReset.Size = new System.Drawing.Size(182, 20);
            this.kchkReset.TabIndex = 4;
            this.kchkReset.Values.Text = "Allow a user to re&set a theme";
            this.kchkReset.CheckedChanged += new System.EventHandler(this.kchkReset_CheckedChanged);
            // 
            // kchkImport
            // 
            this.kchkImport.Location = new System.Drawing.Point(17, 16);
            this.kchkImport.Name = "kchkImport";
            this.kchkImport.Size = new System.Drawing.Size(192, 20);
            this.kchkImport.TabIndex = 3;
            this.kchkImport.Values.Text = "Allow a user to &import a theme";
            this.kchkImport.CheckedChanged += new System.EventHandler(this.kchkImport_CheckedChanged);
            // 
            // kcmbPaletteMode
            // 
            this.kcmbPaletteMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbPaletteMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbPaletteMode.DropDownWidth = 506;
            this.kcmbPaletteMode.IntegralHeight = false;
            this.kcmbPaletteMode.Location = new System.Drawing.Point(72, 24);
            this.kcmbPaletteMode.Name = "kcmbPaletteMode";
            this.kcmbPaletteMode.Size = new System.Drawing.Size(506, 21);
            this.kcmbPaletteMode.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbPaletteMode.TabIndex = 1;
            this.kcmbPaletteMode.SelectedIndexChanged += new System.EventHandler(this.kcmbPaletteMode_SelectedIndexChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 24);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Theme:";
            // 
            // ThemeSwitcherOptions
            // 
            this.ClientSize = new System.Drawing.Size(626, 359);
            this.Controls.Add(this.klblCustomPalettePath);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemeSwitcherOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Theme Switcher Options";
            this.Load += new System.EventHandler(this.ThemeSwitcherOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.klblCustomPalettePath)).EndInit();
            this.klblCustomPalettePath.ResumeLayout(false);
            this.klblCustomPalettePath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPaletteMode)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private SettingsManager _settingsManager = new SettingsManager();

        private ThemeManager _themeManager = new ThemeManager();

        private KryptonManager _manager = null;

        private KryptonPalette _palette = null;
        #endregion

        #region Properties
        public KryptonManager KryptonManager { get => _manager; private set => _manager = value; }

        public KryptonPalette KryptonPalette { get => _palette; private set => _palette = value; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="ThemeSwitcherOptionsOld" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="palette">The palette.</param>
        public ThemeSwitcherOptionsOld(KryptonManager manager, KryptonPalette palette)
        {
            InitializeComponent();

            KryptonManager = manager;

            KryptonPalette = palette;

            ThemeManager.PropagateThemeList(kcmbPaletteMode);
        }
        #endregion

        #region Event Handlers
        private void kcmbPaletteMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _themeManager.ApplyTheme(kcmbPaletteMode.Text, _manager);

            EnableApplyButton(true);

            EnableResetButton(true);
        }

        private void kbtnImport_Click(object sender, EventArgs e)
        {
            KryptonPalette.Import();

            kcmbPaletteMode.Text = "Custom";

            KryptonManager.GlobalPalette = KryptonPalette;

            KryptonManager.GlobalPaletteMode = PaletteModeManager.Custom;

            ChangePaletteName(KryptonPalette.GetCustomisedKryptonPaletteFilePath());

            EnableApplyButton(true);

            EnableResetButton(true);

            EnableLocateButton(true);
        }

        private void kchkImport_CheckedChanged(object sender, EventArgs e)
        {
            _settingsManager.SetShowImportButton(kchkImport.Checked);

            EnableApplyButton(true);

            EnableResetButton(true);
        }

        private void kchkReset_CheckedChanged(object sender, EventArgs e)
        {
            _settingsManager.SetShowResetButton(kchkReset.Checked);

            EnableApplyButton(true);

            EnableResetButton(true);
        }

        private void kbtnReset_Click(object sender, EventArgs e)
        {
            _settingsManager.ResetSettings(_settingsManager.GetAskMe());

            EnableResetButton(false);
        }

        private void kbtnApply_Click(object sender, EventArgs e)
        {
            _settingsManager.SaveSettings(_settingsManager.GetAskMe());

            EnableApplyButton(false);
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            if (kbtnReset.Enabled)
            {
                DialogResult result = KryptonMessageBox.Show("", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                }
            }
            else
            {
                Hide();
            }
        }
        #endregion

        #region Methods
        private void EnableApplyButton(bool enabled) => kbtnApply.Enabled = enabled;

        private void EnableResetButton(bool enabled) => kbtnReset.Enabled = enabled;

        private void EnableLocateButton(bool enabled) => kbtnLocate.Enabled = enabled;

        /// <summary>Applies the theme.</summary>
        /// <param name="theme">The theme.</param>
        private void ApplyTheme(PaletteModeManager theme) => _settingsManager.SetSelectedTheme(theme);
        private void ChangePaletteName(string paletteName) => kwlPaletteName.Text = $"Custom Palette Name: {Path.GetFileName(paletteName)}";

        private void LocateTheme(string palettePath) => Process.Start("explorer.exe", palettePath);
        #endregion 

        private void kbtnLocate_Click(object sender, EventArgs e) => LocateTheme(KryptonPalette.CustomisedKryptonPaletteFilePath);

        private void ThemeSwitcherOptions_Load(object sender, EventArgs e)
        {
            ThemeManager.SetPaletteTheme(_settingsManager.GetSelectedTheme(), kcmbPaletteMode);

            kcmbPaletteMode.Text = _settingsManager.GetSelectedTheme().ToString();

            kchkImport.Checked = _settingsManager.GetShowImportButton();

            kchkReset.Checked = _settingsManager.GetShowResetButton();

            kchkAskMe.Checked = _settingsManager.GetAskMe();

            EnableApplyButton(false);

            EnableResetButton(false);
        }

        private void kbtnSubmit_Click(object sender, EventArgs e)
        {
            UploadThemeBrowser uploadTheme = new UploadThemeBrowser();

            uploadTheme.Show();
        }

        private void kbtnDownload_Click(object sender, EventArgs e)
        {
            DownloadThemePackage downloadThemePackage = new DownloadThemePackage();

            downloadThemePackage.Show();
        }
    }
}
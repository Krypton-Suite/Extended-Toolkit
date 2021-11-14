namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class ThemeSelector : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnOptions;
        private KryptonButton kbtnResetTheme;
        private KryptonButton kbtnLoadTheme;
        private KryptonButton kbtnApply;
        private KryptonButton kbtnCancel;
        private KryptonPanel kryptonPanel2;
        private KryptonLabel kryptonLabel1;
        private KryptonComboBox kcmbSelectedTheme;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOptions = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetTheme = new Krypton.Toolkit.KryptonButton();
            this.kbtnLoadTheme = new Krypton.Toolkit.KryptonButton();
            this.kbtnApply = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kcmbSelectedTheme = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbSelectedTheme)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOptions);
            this.kryptonPanel1.Controls.Add(this.kbtnResetTheme);
            this.kryptonPanel1.Controls.Add(this.kbtnLoadTheme);
            this.kryptonPanel1.Controls.Add(this.kbtnApply);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 82);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(576, 50);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kbtnOptions
            // 
            this.kbtnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOptions.Location = new System.Drawing.Point(282, 13);
            this.kbtnOptions.Name = "kbtnOptions";
            this.kbtnOptions.Size = new System.Drawing.Size(90, 25);
            this.kbtnOptions.TabIndex = 6;
            this.kbtnOptions.Values.Image = global::Krypton.Toolkit.Suite.Extended.Theme.Switcher.Properties.Resources.Property_16x;
            this.kbtnOptions.Values.Text = "&Options";
            this.kbtnOptions.Click += new System.EventHandler(this.kbtnOptions_Click);
            // 
            // kbtnResetTheme
            // 
            this.kbtnResetTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnResetTheme.Enabled = false;
            this.kbtnResetTheme.Location = new System.Drawing.Point(108, 13);
            this.kbtnResetTheme.Name = "kbtnResetTheme";
            this.kbtnResetTheme.Size = new System.Drawing.Size(90, 25);
            this.kbtnResetTheme.TabIndex = 4;
            this.kbtnResetTheme.Values.Text = "&Reset Theme";
            this.kbtnResetTheme.Click += new System.EventHandler(this.kbtnResetTheme_Click);
            // 
            // kbtnLoadTheme
            // 
            this.kbtnLoadTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnLoadTheme.Location = new System.Drawing.Point(12, 13);
            this.kbtnLoadTheme.Name = "kbtnLoadTheme";
            this.kbtnLoadTheme.Size = new System.Drawing.Size(90, 25);
            this.kbtnLoadTheme.TabIndex = 2;
            this.kbtnLoadTheme.Values.Text = "Load Th&eme";
            this.kbtnLoadTheme.Click += new System.EventHandler(this.kbtnLoadTheme_Click);
            // 
            // kbtnApply
            // 
            this.kbtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnApply.Enabled = false;
            this.kbtnApply.Location = new System.Drawing.Point(378, 13);
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
            this.kbtnCancel.Location = new System.Drawing.Point(474, 13);
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
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(576, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kcmbSelectedTheme);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(576, 82);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // kcmbSelectedTheme
            // 
            this.kcmbSelectedTheme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbSelectedTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbSelectedTheme.DropDownWidth = 552;
            this.kcmbSelectedTheme.IntegralHeight = false;
            this.kcmbSelectedTheme.Location = new System.Drawing.Point(12, 38);
            this.kcmbSelectedTheme.Name = "kcmbSelectedTheme";
            this.kcmbSelectedTheme.Size = new System.Drawing.Size(552, 21);
            this.kcmbSelectedTheme.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbSelectedTheme.TabIndex = 1;
            this.kcmbSelectedTheme.SelectedIndexChanged += new System.EventHandler(this.kcmbSelectedTheme_SelectedIndexChanged);
            this.kcmbSelectedTheme.TextChanged += new System.EventHandler(this.kcmbSelectedTheme_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(106, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Selected Theme:";
            // 
            // ThemeSelector
            // 
            this.ClientSize = new System.Drawing.Size(576, 132);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemeSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select a Theme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThemeSelector_FormClosing);
            this.Load += new System.EventHandler(this.ThemeSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbSelectedTheme)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private SettingsManager _settingsManager = new SettingsManager();

        ThemeManager _themeManager = new ThemeManager();

        private KryptonManager _manager;

        private KryptonPalette _palette;
        #endregion

        #region Constructor
        public ThemeSelector(KryptonManager? manager)
        {
            InitializeComponent();

            _manager = manager ?? new KryptonManager();

            _palette = new KryptonPalette();

            ThemeManager.PropagateThemeList(kcmbSelectedTheme);
        }
        #endregion

        #region Methods
        private void EnableApplyButton(bool enabled) => kbtnApply.Enabled = enabled;

        private void EnableResetButton(bool enabled) => kbtnResetTheme.Enabled = enabled;

        private void UpdateUI()
        {
            if (_settingsManager.GetShowImportButton())
            {
                kbtnLoadTheme.Visible = true;

                UpdateControlLocation(kbtnResetTheme, new Point(108, 13));
            }
            else
            {
                kbtnLoadTheme.Visible = false;

                UpdateControlLocation(kbtnResetTheme, new Point(12, 13));
            }

            kbtnResetTheme.Visible = _settingsManager.GetShowResetButton();
        }

        private void UpdateControlLocation(Control control, Point location) => control.Location = location;
        #endregion

        private void kbtnApply_Click(object sender, EventArgs e)
        {
            _themeManager.ApplyTheme(kcmbSelectedTheme.Text, _manager);

            EnableApplyButton(false);

            EnableResetButton(true);
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void kbtnOptions_Click(object sender, EventArgs e)
        {
            ThemeSwitcherOptions options = new ThemeSwitcherOptions(_manager, _palette);

            options.Show();
        }

        private void kbtnResetTheme_Click(object sender, EventArgs e)
        {
            _settingsManager.SetSelectedTheme(PaletteModeManager.Office365Blue);

            _settingsManager.SetCustomThemePath(string.Empty);

            _settingsManager.SaveSettings(_settingsManager.GetAskMe());

            _manager.GlobalPalette = null;

            _manager.GlobalPaletteMode = PaletteModeManager.Office365Blue;

            kcmbSelectedTheme.Text = "Office 365 - Blue";

            EnableResetButton(false);
        }

        private void kbtnLoadTheme_Click(object sender, EventArgs e)
        {
            _palette.Import();

            _manager.GlobalPalette = _palette;

            _manager.GlobalPaletteMode = PaletteModeManager.Custom;

            kcmbSelectedTheme.Text = "Custom";

            EnableResetButton(true);
        }

        private void ThemeSelector_Load(object sender, EventArgs e)
        {
            ThemeManager.SetPaletteTheme(_settingsManager.GetSelectedTheme(), kcmbSelectedTheme);

            _themeManager.ApplyTheme(kcmbSelectedTheme.Text, _manager);

            EnableApplyButton(false);
        }

        private void ThemeSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settingsManager.SaveSettings(_settingsManager.GetAskMe());
        }

        private void kcmbSelectedTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableResetButton(true);
        }

        private void kcmbSelectedTheme_TextChanged(object sender, EventArgs e)
        {
            EnableResetButton(MissingFrameWorkAPIs.IsNullOrWhiteSpace(kcmbSelectedTheme.Text));
        }
    }
}
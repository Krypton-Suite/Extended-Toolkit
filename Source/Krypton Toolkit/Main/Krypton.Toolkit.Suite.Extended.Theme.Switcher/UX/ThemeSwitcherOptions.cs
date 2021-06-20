namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class ThemeSwitcherOptions : KryptonForm
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
        private KryptonLabel kryptonLabel2;
        private KryptonButton kbtnImport;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnReset = new Krypton.Toolkit.KryptonButton();
            this.kbtnApply = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.klblCustomPalettePath = new Krypton.Toolkit.KryptonPanel();
            this.kbtnImport = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
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
            this.klblCustomPalettePath.Controls.Add(this.kbtnImport);
            this.klblCustomPalettePath.Controls.Add(this.kryptonLabel2);
            this.klblCustomPalettePath.Controls.Add(this.kryptonGroupBox1);
            this.klblCustomPalettePath.Controls.Add(this.kcmbPaletteMode);
            this.klblCustomPalettePath.Controls.Add(this.kryptonLabel1);
            this.klblCustomPalettePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblCustomPalettePath.Location = new System.Drawing.Point(0, 0);
            this.klblCustomPalettePath.Name = "klblCustomPalettePath";
            this.klblCustomPalettePath.Size = new System.Drawing.Size(626, 309);
            this.klblCustomPalettePath.TabIndex = 3;
            // 
            // kbtnImport
            // 
            this.kbtnImport.Location = new System.Drawing.Point(268, 108);
            this.kbtnImport.Name = "kbtnImport";
            this.kbtnImport.Size = new System.Drawing.Size(90, 25);
            this.kbtnImport.TabIndex = 4;
            this.kbtnImport.Values.Text = "Im&port";
            this.kbtnImport.Click += new System.EventHandler(this.kbtnImport_Click);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(33, 72);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(163, 19);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Custom Palette Path: {0}";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(72, 139);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkReset);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkImport);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(506, 153);
            this.kryptonGroupBox1.TabIndex = 2;
            this.kryptonGroupBox1.Values.Heading = "User Interface Elements";
            // 
            // kchkReset
            // 
            this.kchkReset.Location = new System.Drawing.Point(17, 64);
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
        private ArrayList _themeList = new ArrayList();

        private SettingsManager _settingsManager = new SettingsManager();

        private KryptonManager _manager = null;

        private KryptonPalette _palette = null;
        #endregion

        #region Properties
        public KryptonManager KryptonManager { get => _manager; private set => _manager = value; }

        public KryptonPalette KryptonPalette { get => _palette; private set => _palette = value; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="ThemeSwitcherOptions" /> class.</summary>
        /// <param name="manager">The manager.</param>
        /// <param name="palette">The palette.</param>
        public ThemeSwitcherOptions(KryptonManager manager, KryptonPalette palette)
        {
            InitializeComponent();

            KryptonManager = manager;

            KryptonPalette = palette;

            PropagateThemeList();

            if (_themeList.Count > 0)
            {
                foreach (string item in _themeList)
                {
                    kcmbPaletteMode.Items.Add(item);
                }
            }
        }
        #endregion

        #region Event Handlers
        private void kcmbPaletteMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyTheme(kcmbPaletteMode.Text);

            EnableApplyButton(true);

            EnableResetButton(true);
        }

        private void kbtnImport_Click(object sender, EventArgs e)
        {
            KryptonPalette.Import();

            kcmbPaletteMode.Text = "Custom";

            KryptonManager.GlobalPalette = KryptonPalette;

            KryptonManager.GlobalPaletteMode = PaletteModeManager.Custom;

            EnableApplyButton(true);

            EnableResetButton(true);
        }

        private void kchkImport_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kchkReset_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kbtnReset_Click(object sender, EventArgs e)
        {

        }

        private void kbtnApply_Click(object sender, EventArgs e)
        {

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

        private void ApplyTheme(string themeType)
        {
            if (themeType == "Professional - System")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.ProfessionalSystem;

                ApplyTheme(PaletteModeManager.ProfessionalSystem);
            }
            else if (themeType == "Professional - Office 2003")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.ProfessionalOffice2003;

                ApplyTheme(PaletteModeManager.ProfessionalOffice2003);
            }
            else if (themeType == "Office 2007 - Black")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2007Black;

                ApplyTheme(PaletteModeManager.Office2007Black);
            }
            else if (themeType == "Office 2007 - Blue")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2007Blue;

                ApplyTheme(PaletteModeManager.Office2007Blue);
            }
            else if (themeType == "Office 2007 - Silver")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2007Silver;

                ApplyTheme(PaletteModeManager.Office2007Silver);
            }
            else if (themeType == "Office 2007 - White")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2007White;

                ApplyTheme(PaletteModeManager.Office2007White);
            }
            else if (themeType == "Office 2010 - Black")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2010Black;

                ApplyTheme(PaletteModeManager.Office2010Black);
            }
            else if (themeType == "Office 2010 - Blue")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2010Blue;

                ApplyTheme(PaletteModeManager.Office2010Blue);
            }
            else if (themeType == "Office 2010 - Silver")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2010Silver;

                ApplyTheme(PaletteModeManager.Office2010Silver);
            }
            else if (themeType == "Office 2010 - White")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2010White;

                ApplyTheme(PaletteModeManager.Office2010White);
            }
            else if (themeType == "Office 2013")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2013;
            }
            else if (themeType == "Office 2013 - White")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2013White;
            }
            else if (themeType == "Office 365 - Black")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office365Black;
            }
            else if (themeType == "Office 365 - Blue")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office365Blue;
            }
            else if (themeType == "Office 365 - Silver")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office365Silver;
            }
            else if (themeType == "Office 365 - White")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office365White;
            }
            else if (themeType == "Sparkle - Blue")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.SparkleBlue;
            }
            else if (themeType == "Sparkle - Orange")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.SparkleOrange;
            }
            else if (themeType == "Sparkle - Purple")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.SparklePurple;
            }
            else if (themeType == "Custom")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Custom;
            }
        }

        /// <summary>Applies the theme.</summary>
        /// <param name="theme">The theme.</param>
        private void ApplyTheme(PaletteModeManager theme) => _settingsManager.SetTheme(theme);

        /// <summary>Propagates the theme list.</summary>
        private void PropagateThemeList()
        {
            _themeList.Add("Professional - System");

            _themeList.Add("Professional - Office 2003");

            _themeList.Add("Office 2007 - Black");

            _themeList.Add("Office 2007 - Blue");

            _themeList.Add("Office 2007 - Silver");

            _themeList.Add("Office 2007 - White");

            _themeList.Add("Office 2010 - Black");

            _themeList.Add("Office 2010 - Blue");

            _themeList.Add("Office 2010 - Silver");

            _themeList.Add("Office 2010 - White");

            _themeList.Add("Office 2013");

            _themeList.Add("Office 2013 - White");

            _themeList.Add("Office 365 - Black");

            _themeList.Add("Office 365 - Blue");

            _themeList.Add("Office 365 - Silver");

            _themeList.Add("Office 365 - White");

            _themeList.Add("Sparkle - Blue");

            _themeList.Add("Sparkle - Orange");

            _themeList.Add("Sparkle - Purple");

            _themeList.Add("Custom");
            #endregion
        }
    }
}
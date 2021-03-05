using System;
using System.Collections;

namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class ThemeSelector : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnApply;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonComboBox kcmbPaletteMode;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnLoadTheme;
        private KryptonButton kbtnCancel;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemeSelector));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnApply = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kcmbPaletteMode = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnLoadTheme = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPaletteMode)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnLoadTheme);
            this.kryptonPanel1.Controls.Add(this.kbtnApply);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 53);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(544, 46);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnApply
            // 
            this.kbtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnApply.Enabled = false;
            this.kbtnApply.Location = new System.Drawing.Point(346, 9);
            this.kbtnApply.Name = "kbtnApply";
            this.kbtnApply.Size = new System.Drawing.Size(90, 25);
            this.kbtnApply.TabIndex = 1;
            this.kbtnApply.Values.Text = "A&pply";
            this.kbtnApply.Click += new System.EventHandler(this.kbtnApply_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(442, 9);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 2);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kcmbPaletteMode);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(544, 51);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kcmbPaletteMode
            // 
            this.kcmbPaletteMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbPaletteMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbPaletteMode.DropDownWidth = 459;
            this.kcmbPaletteMode.IntegralHeight = false;
            this.kcmbPaletteMode.Location = new System.Drawing.Point(73, 13);
            this.kcmbPaletteMode.Name = "kcmbPaletteMode";
            this.kcmbPaletteMode.Size = new System.Drawing.Size(459, 21);
            this.kcmbPaletteMode.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbPaletteMode.TabIndex = 1;
            this.kcmbPaletteMode.SelectedIndexChanged += new System.EventHandler(this.kcmbPaletteMode_SelectedIndexChanged);
            this.kcmbPaletteMode.TextChanged += new System.EventHandler(this.kcmbPaletteMode_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Theme:";
            // 
            // kbtnLoadTheme
            // 
            this.kbtnLoadTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnLoadTheme.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnLoadTheme.Location = new System.Drawing.Point(12, 9);
            this.kbtnLoadTheme.Name = "kbtnLoadTheme";
            this.kbtnLoadTheme.Size = new System.Drawing.Size(90, 25);
            this.kbtnLoadTheme.TabIndex = 2;
            this.kbtnLoadTheme.Values.Text = "Load &Theme";
            this.kbtnLoadTheme.Visible = false;
            this.kbtnLoadTheme.Click += new System.EventHandler(this.kbtnLoadTheme_Click);
            // 
            // ThemeSelector
            // 
            this.ClientSize = new System.Drawing.Size(544, 99);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemeSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Theme";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPaletteMode)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private ArrayList _themeList = new ArrayList();

        private SettingsManager _settingsManager = new SettingsManager();

        private KryptonManager _manager;
        #endregion

        #region Constructor
        public ThemeSelector(KryptonManager manager)
        {
            InitializeComponent();

            _manager = manager;

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

        private void kbtnApply_Click(object sender, EventArgs e)
        {
            ApplyTheme(kcmbPaletteMode.Text);
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void kcmbPaletteMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kcmbPaletteMode_TextChanged(object sender, EventArgs e)
        {

        }

        private void kbtnLoadTheme_Click(object sender, EventArgs e)
        {
            CustomThemeBrowser browser = new CustomThemeBrowser();

            browser.Show();
        }

        #region Methods
        private void ApplyTheme(string themeType)
        {
            if (themeType == "Professional - System")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.ProfessionalSystem;
            }
            else if (themeType == "Professional - Office 2003")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.ProfessionalOffice2003;
            }
            else if (themeType == "Office 2007 - Black")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2007Black;
            }
            else if (themeType == "Office 2007 - Blue")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2007Blue;
            }
            else if (themeType == "Office 2007 - Silver")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2007Silver;
            }
            else if (themeType == "Office 2007 - White")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2007White;
            }
            else if (themeType == "Office 2010 - Black")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2010Black;
            }
            else if (themeType == "Office 2010 - Blue")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2010Blue;
            }
            else if (themeType == "Office 2010 - Silver")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2010Silver;
            }
            else if (themeType == "Office 2010 - White")
            {
                _manager.GlobalPaletteMode = PaletteModeManager.Office2010White;
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
        }
        #endregion
    }
}
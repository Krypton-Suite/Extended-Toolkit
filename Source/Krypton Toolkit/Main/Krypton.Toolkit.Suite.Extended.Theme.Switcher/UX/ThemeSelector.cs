﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class ThemeSelector : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnLoadTheme;
        private KryptonButton kbtnApply;
        private KryptonButton kbtnCancel;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonComboBox kcmbPaletteMode;
        private KryptonButton kbtnResetTheme;
        private KryptonButton kbtnOptions;
        private KryptonLabel kryptonLabel1;

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
            this.kcmbPaletteMode = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPaletteMode)).BeginInit();
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
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 73);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(590, 50);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnOptions
            // 
            this.kbtnOptions.Location = new System.Drawing.Point(296, 13);
            this.kbtnOptions.Name = "kbtnOptions";
            this.kbtnOptions.Size = new System.Drawing.Size(90, 25);
            this.kbtnOptions.TabIndex = 6;
            this.kbtnOptions.Values.Image = global::Krypton.Toolkit.Suite.Extended.Theme.Switcher.Properties.Resources.Property_16x;
            this.kbtnOptions.Values.Text = "&Options";
            this.kbtnOptions.Click += new System.EventHandler(this.kbtnOptions_Click);
            // 
            // kbtnResetTheme
            // 
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
            this.kbtnApply.Location = new System.Drawing.Point(392, 13);
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
            this.kbtnCancel.Location = new System.Drawing.Point(488, 13);
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
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(590, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kcmbPaletteMode);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(590, 73);
            this.kryptonPanel2.TabIndex = 2;
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
            this.kcmbPaletteMode.TextChanged += new System.EventHandler(this.kcmbPaletteMode_TextChanged);
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
            // ThemeSelector
            // 
            this.ClientSize = new System.Drawing.Size(590, 123);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemeSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Theme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThemeSelector_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
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

        private KryptonPalette _palette;
        #endregion

        #region Constructor
        public ThemeSelector(KryptonManager manager)
        {
            InitializeComponent();

            _manager = manager;

            _palette = new KryptonPalette();

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

        #region Methods
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
        }
        #endregion

        private void kbtnApply_Click(object sender, EventArgs e) => ApplyTheme(kcmbPaletteMode.Text);

        private void kbtnCancel_Click(object sender, EventArgs e) => Hide();

        private void kbtnLoadTheme_Click(object sender, EventArgs e)
        {
            _palette.Import();

            _manager.GlobalPalette = _palette;

            _manager.GlobalPaletteMode = PaletteModeManager.Custom;

            kcmbPaletteMode.Text = "Custom";

            kbtnResetTheme.Enabled = true;
        }

        private void kcmbPaletteMode_TextChanged(object sender, EventArgs e) => kbtnApply.Enabled = MissingFrameWorkAPIs.IsNullOrWhiteSpace(kcmbPaletteMode.Text);

        private void ThemeSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settingsManager.SaveSettings();
        }

        private void kcmbPaletteMode_SelectedIndexChanged(object sender, EventArgs e) => kbtnApply.Enabled = true;

        private void kbtnResetTheme_Click(object sender, EventArgs e)
        {
            _settingsManager.SetTheme(PaletteModeManager.Office365Blue);

            _settingsManager.SetCustomThemePath(string.Empty);

            _settingsManager.SaveSettings();

            _manager.GlobalPalette = null;

            _manager.GlobalPaletteMode = PaletteModeManager.Office365Blue;

            kcmbPaletteMode.Text = "Office 365 - Blue";

            kbtnResetTheme.Enabled = false;
        }

        private void kbtnOptions_Click(object sender, EventArgs e)
        {
            ThemeSwitcherOptions options = new ThemeSwitcherOptions(_manager, _palette);

            options.Show();
        }
    }
}
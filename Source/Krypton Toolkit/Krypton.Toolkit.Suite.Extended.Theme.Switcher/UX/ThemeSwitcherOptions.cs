#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class ThemeSwitcherOptions : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnReset;
        private KryptonButton kbtnApply;
        private KryptonButton kbtnCancel;
        private KryptonPanel kryptonPanel2;
        private KryptonNavigator kryptonNavigator1;
        private KryptonPage kryptonPage1;
        private KryptonPage kryptonPage2;
        private KryptonPage kryptonPage3;
        private KryptonButton kbtnDownload;
        private KryptonButton kbtnSubmit;
        private KryptonWrapLabel kwlPaletteName;
        private KryptonButton kbtnLocate;
        private KryptonButton kbtnImport;
        private KryptonComboBox kcmbPaletteMode;
        private KryptonLabel kryptonLabel1;
        private KryptonComboBox kcmbLightTheme;
        private KryptonLabel kryptonLabel3;
        private KryptonComboBox kcmbDarkTheme;
        private KryptonLabel kryptonLabel2;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonCheckBox kchkAskMe;
        private KryptonCheckBox kchkReset;
        private KryptonCheckBox kchkImport;
        private KryptonButton kbtnResetDarkAndLightTheme;
        private KryptonButton kbtnRequestTheme;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnReset = new Krypton.Toolkit.KryptonButton();
            this.kbtnApply = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonNavigator1 = new Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new Krypton.Navigator.KryptonPage();
            this.kbtnRequestTheme = new Krypton.Toolkit.KryptonButton();
            this.kbtnDownload = new Krypton.Toolkit.KryptonButton();
            this.kbtnSubmit = new Krypton.Toolkit.KryptonButton();
            this.kwlPaletteName = new Krypton.Toolkit.KryptonWrapLabel();
            this.kbtnLocate = new Krypton.Toolkit.KryptonButton();
            this.kbtnImport = new Krypton.Toolkit.KryptonButton();
            this.kcmbPaletteMode = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonPage2 = new Krypton.Navigator.KryptonPage();
            this.kbtnResetDarkAndLightTheme = new Krypton.Toolkit.KryptonButton();
            this.kcmbLightTheme = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kcmbDarkTheme = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonPage3 = new Krypton.Navigator.KryptonPage();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kchkAskMe = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkReset = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkImport = new Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPaletteMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.kryptonPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbLightTheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbDarkTheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnReset);
            this.kryptonPanel1.Controls.Add(this.kbtnApply);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 480);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(626, 50);
            this.kryptonPanel1.TabIndex = 3;
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
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonNavigator1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(626, 480);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Button.CloseButtonAction = Krypton.Navigator.CloseButtonAction.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Location = new System.Drawing.Point(12, 12);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2,
            this.kryptonPage3});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(602, 451);
            this.kryptonNavigator1.TabIndex = 0;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.kbtnRequestTheme);
            this.kryptonPage1.Controls.Add(this.kbtnDownload);
            this.kryptonPage1.Controls.Add(this.kbtnSubmit);
            this.kryptonPage1.Controls.Add(this.kwlPaletteName);
            this.kryptonPage1.Controls.Add(this.kbtnLocate);
            this.kryptonPage1.Controls.Add(this.kbtnImport);
            this.kryptonPage1.Controls.Add(this.kcmbPaletteMode);
            this.kryptonPage1.Controls.Add(this.kryptonLabel1);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(600, 424);
            this.kryptonPage1.Text = "&Default Theme";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "28e83efc20ad413992631dfc38f82c20";
            // 
            // kbtnRequestTheme
            // 
            this.kbtnRequestTheme.Location = new System.Drawing.Point(160, 201);
            this.kbtnRequestTheme.Name = "kbtnRequestTheme";
            this.kbtnRequestTheme.Size = new System.Drawing.Size(121, 25);
            this.kbtnRequestTheme.TabIndex = 16;
            this.kbtnRequestTheme.Values.Text = "Re&quest a Theme";
            this.kbtnRequestTheme.Click += new System.EventHandler(this.kbtnRequestTheme_Click);
            // 
            // kbtnDownload
            // 
            this.kbtnDownload.Location = new System.Drawing.Point(256, 161);
            this.kbtnDownload.Name = "kbtnDownload";
            this.kbtnDownload.Size = new System.Drawing.Size(189, 25);
            this.kbtnDownload.TabIndex = 14;
            this.kbtnDownload.Values.Text = "&Download Additional Themes";
            this.kbtnDownload.Click += new System.EventHandler(this.kbtnDownload_Click);
            // 
            // kbtnSubmit
            // 
            this.kbtnSubmit.Location = new System.Drawing.Point(16, 201);
            this.kbtnSubmit.Name = "kbtnSubmit";
            this.kbtnSubmit.Size = new System.Drawing.Size(138, 25);
            this.kbtnSubmit.TabIndex = 13;
            this.kbtnSubmit.Values.Text = "&Submit a Theme";
            this.kbtnSubmit.Click += new System.EventHandler(this.kbtnSubmit_Click);
            // 
            // kwlPaletteName
            // 
            this.kwlPaletteName.AutoSize = false;
            this.kwlPaletteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlPaletteName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlPaletteName.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kwlPaletteName.Location = new System.Drawing.Point(16, 55);
            this.kwlPaletteName.Name = "kwlPaletteName";
            this.kwlPaletteName.Size = new System.Drawing.Size(566, 93);
            this.kwlPaletteName.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlPaletteName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kbtnLocate
            // 
            this.kbtnLocate.Enabled = false;
            this.kbtnLocate.Location = new System.Drawing.Point(112, 161);
            this.kbtnLocate.Name = "kbtnLocate";
            this.kbtnLocate.Size = new System.Drawing.Size(138, 25);
            this.kbtnLocate.TabIndex = 12;
            this.kbtnLocate.Values.Text = "&Locate Theme File";
            this.kbtnLocate.Click += new System.EventHandler(this.kbtnLocate_Click);
            // 
            // kbtnImport
            // 
            this.kbtnImport.Location = new System.Drawing.Point(16, 161);
            this.kbtnImport.Name = "kbtnImport";
            this.kbtnImport.Size = new System.Drawing.Size(90, 25);
            this.kbtnImport.TabIndex = 11;
            this.kbtnImport.Values.Text = "Im&port";
            this.kbtnImport.Click += new System.EventHandler(this.kbtnImport_Click);
            // 
            // kcmbPaletteMode
            // 
            this.kcmbPaletteMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbPaletteMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbPaletteMode.DropDownWidth = 506;
            this.kcmbPaletteMode.IntegralHeight = false;
            this.kcmbPaletteMode.Location = new System.Drawing.Point(76, 19);
            this.kcmbPaletteMode.Name = "kcmbPaletteMode";
            this.kcmbPaletteMode.Size = new System.Drawing.Size(506, 21);
            this.kcmbPaletteMode.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbPaletteMode.TabIndex = 10;
            this.kcmbPaletteMode.SelectedIndexChanged += new System.EventHandler(this.kcmbPaletteMode_SelectedIndexChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(16, 19);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel1.TabIndex = 9;
            this.kryptonLabel1.Values.Text = "Theme:";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Controls.Add(this.kbtnResetDarkAndLightTheme);
            this.kryptonPage2.Controls.Add(this.kcmbLightTheme);
            this.kryptonPage2.Controls.Add(this.kryptonLabel3);
            this.kryptonPage2.Controls.Add(this.kcmbDarkTheme);
            this.kryptonPage2.Controls.Add(this.kryptonLabel2);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(600, 424);
            this.kryptonPage2.Text = "Dar&k && Light Theme";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "220dbace80024bdea70072a95195e6b8";
            // 
            // kbtnResetDarkAndLightTheme
            // 
            this.kbtnResetDarkAndLightTheme.Enabled = false;
            this.kbtnResetDarkAndLightTheme.Location = new System.Drawing.Point(16, 136);
            this.kbtnResetDarkAndLightTheme.Name = "kbtnResetDarkAndLightTheme";
            this.kbtnResetDarkAndLightTheme.Size = new System.Drawing.Size(90, 25);
            this.kbtnResetDarkAndLightTheme.TabIndex = 15;
            this.kbtnResetDarkAndLightTheme.Values.Text = "&Reset Themes";
            this.kbtnResetDarkAndLightTheme.Click += new System.EventHandler(this.kbtnResetDarkAndLightTheme_Click);
            // 
            // kcmbLightTheme
            // 
            this.kcmbLightTheme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbLightTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbLightTheme.DropDownWidth = 506;
            this.kcmbLightTheme.IntegralHeight = false;
            this.kcmbLightTheme.Location = new System.Drawing.Point(14, 109);
            this.kcmbLightTheme.Name = "kcmbLightTheme";
            this.kcmbLightTheme.Size = new System.Drawing.Size(566, 21);
            this.kcmbLightTheme.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbLightTheme.TabIndex = 14;
            this.kcmbLightTheme.SelectedIndexChanged += new System.EventHandler(this.kcmbLightTheme_SelectedIndexChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(14, 83);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(86, 20);
            this.kryptonLabel3.TabIndex = 13;
            this.kryptonLabel3.Values.Text = "Light Theme:";
            // 
            // kcmbDarkTheme
            // 
            this.kcmbDarkTheme.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbDarkTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbDarkTheme.DropDownWidth = 506;
            this.kcmbDarkTheme.IntegralHeight = false;
            this.kcmbDarkTheme.Location = new System.Drawing.Point(16, 46);
            this.kcmbDarkTheme.Name = "kcmbDarkTheme";
            this.kcmbDarkTheme.Size = new System.Drawing.Size(566, 21);
            this.kcmbDarkTheme.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbDarkTheme.TabIndex = 12;
            this.kcmbDarkTheme.SelectedIndexChanged += new System.EventHandler(this.kcmbDarkTheme_SelectedIndexChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(16, 20);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(84, 20);
            this.kryptonLabel2.TabIndex = 11;
            this.kryptonLabel2.Values.Text = "Dark Theme:";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(600, 424);
            this.kryptonPage3.Text = "User Interface";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "f5d9411b0f4c4aa19c8daa9bc5cfea98";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(16, 19);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkAskMe);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkReset);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kchkImport);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(566, 207);
            this.kryptonGroupBox1.TabIndex = 3;
            this.kryptonGroupBox1.Values.Heading = "User Interface Elements";
            // 
            // kchkAskMe
            // 
            this.kchkAskMe.Location = new System.Drawing.Point(17, 90);
            this.kchkAskMe.Name = "kchkAskMe";
            this.kchkAskMe.Size = new System.Drawing.Size(294, 20);
            this.kchkAskMe.TabIndex = 5;
            this.kchkAskMe.Values.Text = "&Always ask me to save or reset my theme settings";
            this.kchkAskMe.CheckedChanged += new System.EventHandler(this.kchkAskMe_CheckedChanged);
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
            // ThemeSwitcherOptions
            // 
            this.ClientSize = new System.Drawing.Size(626, 530);
            this.Controls.Add(this.kryptonPanel2);
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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            this.kryptonPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPaletteMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            this.kryptonPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbLightTheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbDarkTheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _modified;

        private SettingsManager _settingsManager = new SettingsManager();

        private ThemeManager _themeManager = new ThemeManager();

        private KryptonManager _manager;

        private KryptonPalette _palette;
        #endregion

        #region Properties
        public KryptonManager KryptonManager { get => _manager; private set => _manager = value; }

        public KryptonPalette KryptonPalette { get => _palette; private set => _palette = value; }
        #endregion

        #region Constructors
        public ThemeSwitcherOptions(KryptonManager? manager, KryptonPalette? palette)
        {
            InitializeComponent();

            _manager = manager ?? new KryptonManager();

            _palette = palette ?? new KryptonPalette();

            PropagateThemeLists();
        }
        #endregion

        #region Methods
        private void EnableApplyButton(bool enabled) => kbtnApply.Enabled = enabled;

        private void EnableResetButton(bool enabled) => kbtnReset.Enabled = enabled;

        private void EnableLocateButton(bool enabled) => kbtnLocate.Enabled = enabled;

        private void SetModified(bool modified)
        {
            _modified = modified;

            EnableApplyButton(modified);

            EnableResetButton(modified);
        }

        /// <summary>Applies the theme.</summary>
        /// <param name="theme">The theme.</param>
        private void ApplyTheme(PaletteModeManager theme) => _settingsManager.SetSelectedTheme(theme);
        private void ChangePaletteName(string paletteName) => kwlPaletteName.Text = $"Custom Palette Name: {Path.GetFileName(paletteName)}";

        private void LocateTheme(string palettePath) => Process.Start("explorer.exe", palettePath);

        private void PropagateThemeLists()
        {
            ThemeManager.PropagateThemeList(kcmbDarkTheme);

            ThemeManager.PropagateThemeList(kcmbLightTheme);

            ThemeManager.PropagateThemeList(kcmbPaletteMode);
        }
        #endregion

        private void kcmbPaletteMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetModified(true);
        }

        private void kcmbDarkTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetModified(true);
        }

        private void kcmbLightTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetModified(true);
        }

        private void kchkImport_CheckedChanged(object sender, EventArgs e)
        {
            SetModified(true);
        }

        private void kchkReset_CheckedChanged(object sender, EventArgs e)
        {
            SetModified(true);
        }

        private void kchkAskMe_CheckedChanged(object sender, EventArgs e)
        {
            SetModified(true);
        }

        private void kbtnImport_Click(object sender, EventArgs e)
        {

        }

        private void kbtnLocate_Click(object sender, EventArgs e) => LocateTheme("");

        private void kbtnDownload_Click(object sender, EventArgs e)
        {

        }

        private void kbtnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void kbtnRequestTheme_Click(object sender, EventArgs e)
        {
            ApplicationUtilities.UnderConstruction();
        }

        private void kbtnResetDarkAndLightTheme_Click(object sender, EventArgs e)
        {

        }

        private void kbtnReset_Click(object sender, EventArgs e)
        {
            _settingsManager.ResetSettings();

            SetModified(false);
        }

        private void kbtnApply_Click(object sender, EventArgs e)
        {
            _settingsManager.SaveSettings();

            SetModified(false);
        }

        private void ThemeSwitcherOptions_Load(object sender, EventArgs e)
        {
            ThemeManager.SetPaletteTheme(_settingsManager.GetSelectedTheme(), kcmbPaletteMode);

            kcmbPaletteMode.Text = _settingsManager.GetSelectedTheme().ToString();

            kcmbDarkTheme.Text = _settingsManager.GetDarkTheme().ToString();

            kcmbLightTheme.Text = _settingsManager.GetLightTheme().ToString();

            kcmbLightTheme.Text = _settingsManager.GetLightTheme().ToString();

            kchkImport.Checked = _settingsManager.GetShowImportButton();

            kchkReset.Checked = _settingsManager.GetShowResetButton();

            kchkAskMe.Checked = _settingsManager.GetAskMe();

            SetModified(false);
        }
    }
}
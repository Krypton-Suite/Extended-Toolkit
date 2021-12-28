#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Microsoft.WindowsAPICodePack.Dialogs;

using System.Collections;
using System.IO;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class ThemeOptions : KryptonForm
    {
        #region Variables
        private KryptonManager _manager = new KryptonManager();
        private KryptonPalette _palette = new KryptonPalette();
        private PaletteThemeSettingsManager _paletteThemeSettingsManager = new PaletteThemeSettingsManager();
        private PaletteMode _paletteMode;
        private Timer _paletteUpdateTimer;
        private ArrayList _themeList;
        private AutoCompleteStringCollection _themeCollection;
        #endregion

        #region Properties        
        /// <summary>Gets or sets the palette mode.</summary>
        /// <value>The palette mode.</value>
        public PaletteMode PaletteMode { get { return _paletteMode; } set { _paletteMode = value; } }
        #endregion

        #region System
        private KryptonPanel kpnlButtons;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnApply;
        private KryptonPanel kpnlContent;
        private KryptonButton kbtnBrowse;
        private KryptonTextBox ktxtCustomPath;
        private KryptonLabel klblCustomTheme;
        private KryptonComboBox kcmbPaletteTheme;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnLoadTheme;
        private KryptonButton kbtnRestoreToDefaults;
        private System.Windows.Forms.Panel pnlSeperator;

        private void InitializeComponent()
        {
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnApply = new Krypton.Toolkit.KryptonButton();
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.kbtnLoadTheme = new Krypton.Toolkit.KryptonButton();
            this.kbtnBrowse = new Krypton.Toolkit.KryptonButton();
            this.ktxtCustomPath = new Krypton.Toolkit.KryptonTextBox();
            this.klblCustomTheme = new Krypton.Toolkit.KryptonLabel();
            this.kcmbPaletteTheme = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.pnlSeperator = new System.Windows.Forms.Panel();
            this.kbtnRestoreToDefaults = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).BeginInit();
            this.kpnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPaletteTheme)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.kbtnRestoreToDefaults);
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Controls.Add(this.kbtnOk);
            this.kpnlButtons.Controls.Add(this.kbtnApply);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 142);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.Size = new System.Drawing.Size(781, 54);
            this.kpnlButtons.TabIndex = 0;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(583, 12);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 30);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnCancel.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.Location = new System.Drawing.Point(487, 12);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 30);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnOk.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&Ok";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnApply
            // 
            this.kbtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnApply.Enabled = false;
            this.kbtnApply.Location = new System.Drawing.Point(679, 12);
            this.kbtnApply.Name = "kbtnApply";
            this.kbtnApply.Size = new System.Drawing.Size(90, 30);
            this.kbtnApply.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnApply.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnApply.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnApply.TabIndex = 0;
            this.kbtnApply.Values.Text = "A&pply";
            this.kbtnApply.Click += new System.EventHandler(this.kbtnApply_Click);
            // 
            // kpnlContent
            // 
            this.kpnlContent.Controls.Add(this.kbtnLoadTheme);
            this.kpnlContent.Controls.Add(this.kbtnBrowse);
            this.kpnlContent.Controls.Add(this.ktxtCustomPath);
            this.kpnlContent.Controls.Add(this.klblCustomTheme);
            this.kpnlContent.Controls.Add(this.kcmbPaletteTheme);
            this.kpnlContent.Controls.Add(this.kryptonLabel1);
            this.kpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContent.Location = new System.Drawing.Point(0, 0);
            this.kpnlContent.Name = "kpnlContent";
            this.kpnlContent.Size = new System.Drawing.Size(781, 142);
            this.kpnlContent.TabIndex = 1;
            // 
            // kbtnLoadTheme
            // 
            this.kbtnLoadTheme.AutoSize = true;
            this.kbtnLoadTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnLoadTheme.Enabled = false;
            this.kbtnLoadTheme.Location = new System.Drawing.Point(720, 87);
            this.kbtnLoadTheme.Name = "kbtnLoadTheme";
            this.kbtnLoadTheme.Size = new System.Drawing.Size(47, 30);
            this.kbtnLoadTheme.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnLoadTheme.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnLoadTheme.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnLoadTheme.TabIndex = 5;
            this.kbtnLoadTheme.Values.Text = "&Load";
            this.kbtnLoadTheme.Click += new System.EventHandler(this.kbtnLoadTheme_Click);
            // 
            // kbtnBrowse
            // 
            this.kbtnBrowse.AutoSize = true;
            this.kbtnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnBrowse.Enabled = false;
            this.kbtnBrowse.Location = new System.Drawing.Point(744, 51);
            this.kbtnBrowse.Name = "kbtnBrowse";
            this.kbtnBrowse.Size = new System.Drawing.Size(23, 30);
            this.kbtnBrowse.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowse.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnBrowse.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnBrowse.TabIndex = 4;
            this.kbtnBrowse.Values.Text = ".&..";
            this.kbtnBrowse.Click += new System.EventHandler(this.kbtnBrowse_Click);
            // 
            // ktxtCustomPath
            // 
            this.ktxtCustomPath.Enabled = false;
            this.ktxtCustomPath.Location = new System.Drawing.Point(248, 52);
            this.ktxtCustomPath.Name = "ktxtCustomPath";
            this.ktxtCustomPath.Size = new System.Drawing.Size(490, 29);
            this.ktxtCustomPath.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtCustomPath.TabIndex = 3;
            this.ktxtCustomPath.TextChanged += new System.EventHandler(this.ktxtCustomPath_TextChanged);
            // 
            // klblCustomTheme
            // 
            this.klblCustomTheme.Enabled = false;
            this.klblCustomTheme.Location = new System.Drawing.Point(38, 55);
            this.klblCustomTheme.Name = "klblCustomTheme";
            this.klblCustomTheme.Size = new System.Drawing.Size(204, 26);
            this.klblCustomTheme.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblCustomTheme.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.klblCustomTheme.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.klblCustomTheme.TabIndex = 2;
            this.klblCustomTheme.Values.Text = "Custom Theme File Path:";
            // 
            // kcmbPaletteTheme
            // 
            this.kcmbPaletteTheme.DropDownWidth = 216;
            this.kcmbPaletteTheme.Location = new System.Drawing.Point(147, 12);
            this.kcmbPaletteTheme.Name = "kcmbPaletteTheme";
            this.kcmbPaletteTheme.Size = new System.Drawing.Size(216, 27);
            this.kcmbPaletteTheme.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbPaletteTheme.TabIndex = 1;
            this.kcmbPaletteTheme.SelectedIndexChanged += new System.EventHandler(this.kcmbPaletteTheme_SelectedIndexChanged);
            this.kcmbPaletteTheme.TextChanged += new System.EventHandler(this.kcmbPaletteTheme_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(128, 26);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel1.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Palette Theme:";
            // 
            // pnlSeperator
            // 
            this.pnlSeperator.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlSeperator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSeperator.Location = new System.Drawing.Point(0, 139);
            this.pnlSeperator.Name = "pnlSeperator";
            this.pnlSeperator.Size = new System.Drawing.Size(781, 3);
            this.pnlSeperator.TabIndex = 2;
            // 
            // kbtnRestoreToDefaults
            // 
            this.kbtnRestoreToDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnRestoreToDefaults.Enabled = false;
            this.kbtnRestoreToDefaults.Location = new System.Drawing.Point(12, 12);
            this.kbtnRestoreToDefaults.Name = "kbtnRestoreToDefaults";
            this.kbtnRestoreToDefaults.Size = new System.Drawing.Size(163, 30);
            this.kbtnRestoreToDefaults.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRestoreToDefaults.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnRestoreToDefaults.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnRestoreToDefaults.TabIndex = 3;
            this.kbtnRestoreToDefaults.Values.Text = "&Restore to Defaults";
            this.kbtnRestoreToDefaults.Click += new System.EventHandler(this.kbtnRestoreToDefaults_Click);
            // 
            // ThemeOptions
            // 
            this.AcceptButton = this.kbtnOk;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(781, 196);
            this.Controls.Add(this.pnlSeperator);
            this.Controls.Add(this.kpnlContent);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemeOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Palette Theme Options";
            this.Load += new System.EventHandler(this.ThemeOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            this.kpnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPaletteTheme)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>Initializes a new instance of the <see cref="ThemeOptions"/> class.</summary>
        public ThemeOptions()
        {
            InitializeComponent();

            SetPaletteMode(_paletteThemeSettingsManager.GetTheme());

            _paletteUpdateTimer = new Timer();

            // Poll every 250 milliseconds
            _paletteUpdateTimer.Interval = 250;

            _paletteUpdateTimer.Enabled = true;

            _paletteUpdateTimer.Tick += PaletteUpdateTimer_Tick;
        }

        private void PaletteUpdateTimer_Tick(object sender, EventArgs e)
        {
            //if (GetPaletteMode() == PaletteMode.Custom)
            //{
            //    if (_paletteThemeSettingsManager.GetCustomThemeFilePath() != string.Empty)
            //    {
            //        _palette.Import(_paletteThemeSettingsManager.GetCustomThemeFilePath());
            //    }

            //    _manager.GlobalPaletteMode = PaletteModeManager.Custom;
            //}
            //else if (GetPaletteMode() == PaletteMode.Global)
            //{
            //    _manager.GlobalPaletteMode = PaletteModeManager.Custom;
            //}
            //else if (GetPaletteMode() == PaletteMode.Office2007Black)
            //{
            //    _manager.GlobalPaletteMode = PaletteModeManager.Office2007Black;
            //}
            //else if (GetPaletteMode() == PaletteMode.Office2007Blue)
            //{
            //    _manager.GlobalPaletteMode = PaletteModeManager.Office2007Blue;
            //}
            //else if (GetPaletteMode() == PaletteMode.Office2007Silver)
            //{
            //    _manager.GlobalPaletteMode = PaletteModeManager.Office2007Silver;
            //}
            //else if (GetPaletteMode() == PaletteMode.Office2010Black)
            //{
            //    _manager.GlobalPaletteMode = PaletteModeManager.Office2010Black;
            //}
            //else if (GetPaletteMode() == PaletteMode.Office2010Blue)
            //{
            //    _manager.GlobalPaletteMode = PaletteModeManager.Office2010Blue;
            //}
            //else if (GetPaletteMode() == PaletteMode.Office2010Silver)
            //{
            //    _manager.GlobalPaletteMode = PaletteModeManager.Office2010Silver;
            //}
        }

        /// <summary>
        ///   Handles the Load event of the ThemeOptions control.
        /// </summary>
        /// <param name="sender">
        ///   The source of the event.
        /// </param>
        /// <param name="e">
        ///   The <see cref="EventArgs" /> instance containing the event data.
        /// </param>
        private void ThemeOptions_Load(object sender, EventArgs e)
        {
            InitialiseThemeList();

            InitialiseThemeCollection();

            if (_themeList.Count != 0)
            {
                foreach (string item in _themeList)
                {
                    kcmbPaletteTheme.Items.Add(item);
                }
            }

            SetPaletteMode(_paletteThemeSettingsManager.GetTheme());

            //kcmbPaletteTheme.Text = GetPaletteModeAsString(GetPaletteMode());

            foreach (string item in _themeCollection)
            {
                kcmbPaletteTheme.AutoCompleteCustomSource.Add(item);
            }

            kcmbPaletteTheme.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void kbtnApply_Click(object sender, EventArgs e)
        {
            //_paletteThemeSettingsManager.SetTheme(GetPaletteMode());

            //if (GetPaletteMode() == PaletteMode.Custom)
            //{
            //    try
            //    {
            //        _paletteThemeSettingsManager.SetCustomThemeFilePath(_palette.GetFilePath());
            //    }
            //    catch (Exception exc)
            //    {
            //        KryptonMessageBox.Show($"An error has occurred: { exc.Message }", "Palette Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

            //EnableApplyButton(false);
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Hide();
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {

        }

        private void kbtnBrowse_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();

            commonOpenFileDialog.Filters.Add(new CommonFileDialogFilter("Palette Files (*.xml)", "*.xml"));

            commonOpenFileDialog.Title = "Open a custom palette file:";

            if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ktxtCustomPath.Text = Path.GetFullPath(commonOpenFileDialog.FileName);
            }
        }

        private void ktxtCustomPath_TextChanged(object sender, EventArgs e)
        {
            Timer update = new Timer();

            update.Interval = 250;

            update.Enabled = true;

            update.Tick += Update_Tick;

            kbtnLoadTheme.Enabled = true;
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            if (ktxtCustomPath.Text != string.Empty)
            {
                //ChangeTheme(PaletteMode.Custom);
            }
        }

        private void kcmbPaletteTheme_TextChanged(object sender, EventArgs e)
        {
            //if (kcmbPaletteTheme.Text == "Global")
            //{
            //    ChangeTheme(PaletteMode.Global);
            //}
            //else if (kcmbPaletteTheme.Text == "Professional System")
            //{
            //    ChangeTheme(PaletteMode.ProfessionalSystem);
            //}
            //else if (kcmbPaletteTheme.Text == "Professional Office 2003")
            //{
            //    ChangeTheme(PaletteMode.ProfessionalOffice2003);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2007 Black")
            //{
            //    ChangeTheme(PaletteMode.Office2007Black);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2007 Blue")
            //{
            //    ChangeTheme(PaletteMode.Office2007Blue);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2007 Silver")
            //{
            //    ChangeTheme(PaletteMode.Office2007Silver);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2010 Black")
            //{
            //    ChangeTheme(PaletteMode.Office2010Black);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2010 Blue")
            //{
            //    ChangeTheme(PaletteMode.Office2010Blue);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2010 Silver")
            //{
            //    ChangeTheme(PaletteMode.Office2010Silver);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2013")
            //{
            //    ChangeTheme(PaletteMode.Office2013);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2013 White")
            //{
            //    ChangeTheme(PaletteMode.Office2013White);
            //}
            //else if (kcmbPaletteTheme.Text == "Sparkle Blue")
            //{
            //    ChangeTheme(PaletteMode.SparkleBlue);
            //}
            //else if (kcmbPaletteTheme.Text == "Sparkle Orange")
            //{
            //    ChangeTheme(PaletteMode.SparkleOrange);
            //}
            //else if (kcmbPaletteTheme.Text == "Sparkle Purple")
            //{
            //    ChangeTheme(PaletteMode.SparklePurple);
            //}
            //else if (kcmbPaletteTheme.Text == "Custom")
            //{
            //    EnableCustomThemeControls(true);

            //    ChangeTheme(PaletteMode.Custom);
            //}
        }

        #region Methods
        private void ChangeTheme(PaletteModeManager paletteMode)
        {
            SetPaletteMode(paletteMode);

            //switch (paletteMode)
            //{
            //    case PaletteMode.Global:
            //        _manager.GlobalPaletteMode = PaletteModeManager.Custom;

            //        _paletteThemeSettingsManager.SetTheme(PaletteMode.Global);
            //        break;
            //    case PaletteMode.ProfessionalSystem:
            //        _manager.GlobalPaletteMode = PaletteModeManager.ProfessionalSystem;

            //        _paletteThemeSettingsManager.SetTheme(PaletteMode.ProfessionalSystem);
            //        break;
            //    case PaletteMode.ProfessionalOffice2003:
            //        _manager.GlobalPaletteMode = PaletteModeManager.ProfessionalOffice2003;

            //        _paletteThemeSettingsManager.SetTheme(PaletteMode.ProfessionalOffice2003);
            //        break;
            //    case PaletteMode.Office2007Blue:
            //        _manager.GlobalPaletteMode = PaletteModeManager.Office2007Blue;
            //        break;
            //    case PaletteMode.Office2007Silver:
            //        _manager.GlobalPaletteMode = PaletteModeManager.Office2007Silver;
            //        break;
            //    case PaletteMode.Office2007Black:
            //        _manager.GlobalPaletteMode = PaletteModeManager.Office2007Black;
            //        break;
            //    case PaletteMode.Office2010Blue:
            //        _manager.GlobalPaletteMode = PaletteModeManager.Office2010Blue;
            //        break;
            //    case PaletteMode.Office2010Silver:
            //        _manager.GlobalPaletteMode = PaletteModeManager.Office2010Silver;
            //        break;
            //    case PaletteMode.Office2010Black:
            //        _manager.GlobalPaletteMode = PaletteModeManager.Office2010Black;
            //        break;
            //    case PaletteMode.Office2013:
            //        _manager.GlobalPaletteMode = PaletteModeManager.Office2013;
            //        break;
            //    case PaletteMode.Office2013White:
            //        _manager.GlobalPaletteMode = PaletteModeManager.Office2013White;
            //        break;
            //    case PaletteMode.SparkleBlue:
            //        _manager.GlobalPaletteMode = PaletteModeManager.SparkleBlue;

            //        _paletteThemeSettingsManager.SetTheme(PaletteMode.SparkleBlue);
            //        break;
            //    case PaletteMode.SparkleOrange:
            //        _manager.GlobalPaletteMode = PaletteModeManager.SparkleOrange;

            //        _paletteThemeSettingsManager.SetTheme(PaletteMode.SparkleOrange);
            //        break;
            //    case PaletteMode.SparklePurple:
            //        _manager.GlobalPaletteMode = PaletteModeManager.SparklePurple;

            //        _paletteThemeSettingsManager.SetTheme(PaletteMode.SparklePurple);
            //        break;
            //    case PaletteMode.Custom:
            //        _manager.GlobalPaletteMode = PaletteModeManager.Custom;

            //        //_palette.Import(ktxtCustomPath.Text);

            //        _paletteThemeSettingsManager.SetTheme(PaletteMode.Custom);

            //        _paletteThemeSettingsManager.SetCustomThemeFilePath(ktxtCustomPath.Text);
            //        break;
            //    default:
            //        break;
            //}

            EnableApplyButton(true);

            EnableRestoreToDefaultsButton(true);
        }

        private void EnableRestoreToDefaultsButton(bool enabled)
        {
            kbtnRestoreToDefaults.Enabled = enabled;
        }

        private void EnableApplyButton(bool enabled)
        {
            kbtnApply.Enabled = enabled;
        }

        private void EnableCustomThemeControls(bool enabled)
        {
            klblCustomTheme.Enabled = enabled;

            ktxtCustomPath.Enabled = enabled;

            kbtnBrowse.Enabled = enabled;
        }

        private string GetPaletteModeAsString(PaletteMode paletteMode)
        {
            string mode = "";

            switch (paletteMode)
            {
                case PaletteMode.Global:
                    mode = "Global";
                    break;
                case PaletteMode.ProfessionalSystem:
                    mode = "Professional System";
                    break;
                case PaletteMode.ProfessionalOffice2003:
                    mode = "Professional Office 2003";
                    break;
                case PaletteMode.Office2007Blue:
                    mode = "Office 2007 Blue";
                    break;
                case PaletteMode.Office2007Silver:
                    mode = "Office 2007 Silver";
                    break;
                case PaletteMode.Office2007Black:
                    mode = "Office 2007 Black";
                    break;
                case PaletteMode.Office2010Blue:
                    mode = "Office 2010 Blue";
                    break;
                case PaletteMode.Office2010Silver:
                    mode = "Office 2010 Silver";
                    break;
                case PaletteMode.Office2010Black:
                    mode = "Office 2010 Black";
                    break;
                case PaletteMode.Office2013White:
                    mode = "Office 2013 White";
                    break;
                case PaletteMode.SparkleBlue:
                    mode = "Sparkle Blue";
                    break;
                case PaletteMode.SparkleOrange:
                    mode = "Sparkle Orange";
                    break;
                case PaletteMode.SparklePurple:
                    mode = "Sparkle Purple";
                    break;
                case PaletteMode.Custom:
                    mode = "Custom";
                    break;
            }

            return mode;
        }

        private void InitialiseThemeList()
        {
            _themeList = new ArrayList();

            _themeList.Add("Global");

            _themeList.Add("Professional System");

            _themeList.Add("Professional Office 2003");

            _themeList.Add("Office 2007 Blue");

            _themeList.Add("Office 2007 Silver");

            _themeList.Add("Office 2007 Black");

            _themeList.Add("Office 2010 Blue");

            _themeList.Add("Office 2010 Silver");

            _themeList.Add("Office 2010 Black");

            _themeList.Add("Office 2013");

            _themeList.Add("Office 2013 White");

            _themeList.Add("Sparkle Blue");

            _themeList.Add("Sparkle Orange");

            _themeList.Add("Sparkle Purple");

            _themeList.Add("Custom");
        }

        private void InitialiseThemeCollection()
        {
            _themeCollection = new AutoCompleteStringCollection();

            _themeCollection.Add("Global");

            _themeCollection.Add("Professional System");

            _themeCollection.Add("Professional Office 2003");

            _themeCollection.Add("Office 2007 Blue");

            _themeCollection.Add("Office 2007 Silver");

            _themeCollection.Add("Office 2007 Black");

            _themeCollection.Add("Office 2010 Blue");

            _themeCollection.Add("Office 2010 Silver");

            _themeCollection.Add("Office 2010 Black");

            _themeCollection.Add("Office 2013");

            _themeCollection.Add("Office 2013 White");

            _themeCollection.Add("Sparkle Blue");

            _themeCollection.Add("Sparkle Orange");

            _themeCollection.Add("Sparkle Purple");

            _themeCollection.Add("Custom");
        }
        #endregion

        private void kcmbPaletteTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (kcmbPaletteTheme.Text == "Global")
            //{
            //    ChangeTheme(PaletteMode.Global);
            //}
            //else if (kcmbPaletteTheme.Text == "Professional System")
            //{
            //    ChangeTheme(PaletteMode.ProfessionalSystem);
            //}
            //else if (kcmbPaletteTheme.Text == "Professional Office 2003")
            //{
            //    ChangeTheme(PaletteMode.ProfessionalOffice2003);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2007 Black")
            //{
            //    ChangeTheme(PaletteMode.Office2007Black);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2007 Blue")
            //{
            //    ChangeTheme(PaletteMode.Office2007Blue);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2007 Silver")
            //{
            //    ChangeTheme(PaletteMode.Office2007Silver);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2010 Black")
            //{
            //    ChangeTheme(PaletteMode.Office2010Black);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2010 Blue")
            //{
            //    ChangeTheme(PaletteMode.Office2010Blue);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2010 Silver")
            //{
            //    ChangeTheme(PaletteMode.Office2010Silver);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2013")
            //{
            //    ChangeTheme(PaletteMode.Office2013);
            //}
            //else if (kcmbPaletteTheme.Text == "Office 2013 White")
            //{
            //    ChangeTheme(PaletteMode.Office2013White);
            //}
            //else if (kcmbPaletteTheme.Text == "Sparkle Blue")
            //{
            //    ChangeTheme(PaletteMode.SparkleBlue);
            //}
            //else if (kcmbPaletteTheme.Text == "Sparkle Orange")
            //{
            //    ChangeTheme(PaletteMode.SparkleOrange);
            //}
            //else if (kcmbPaletteTheme.Text == "Sparkle Purple")
            //{
            //    ChangeTheme(PaletteMode.SparklePurple);
            //}
            //else if (kcmbPaletteTheme.Text == "Custom")
            //{
            //    EnableCustomThemeControls(true);

            //    ChangeTheme(PaletteMode.Custom);
            //}
        }

        private void kbtnLoadTheme_Click(object sender, EventArgs e)
        {
            _palette.Import();
        }

        private void kbtnRestoreToDefaults_Click(object sender, EventArgs e)
        {
            _paletteThemeSettingsManager.ResetPaletteThemeSettings(true);

            ChangeTheme(_paletteThemeSettingsManager.GetTheme());

            // kcmbPaletteTheme.Text = GetPaletteModeAsString(GetPaletteMode());

            EnableRestoreToDefaultsButton(false);
        }

        #region Setter/Getters
        /// <summary>
        /// Sets the PaletteMode to the value of paletteMode.
        /// </summary>
        /// <param name="paletteMode">The value of paletteMode.</param>
        public void SetPaletteMode(PaletteModeManager paletteMode)
        {
            //PaletteMode = paletteMode;
        }

        /// <summary>
        /// Gets the PaletteMode value.
        /// </summary>
        /// <returns>The value of paletteMode.</returns>
        //public PaletteModeManager GetPaletteMode()
        //{
        //    //return PaletteMode;
        //}
        #endregion
    }
}
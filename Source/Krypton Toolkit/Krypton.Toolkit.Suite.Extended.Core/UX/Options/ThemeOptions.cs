#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class ThemeOptions : KryptonForm
    {
        #region Variables
        private KryptonManager _manager = new();
        private KryptonCustomPaletteBase _palette = new();
        private PaletteThemeSettingsManager _paletteThemeSettingsManager = new();
        private PaletteMode _paletteMode;
        private Timer _paletteUpdateTimer;
        private ArrayList _themeList;
        private AutoCompleteStringCollection _themeCollection;
        #endregion

        #region Properties        
        /// <summary>Gets or sets the palette mode.</summary>
        /// <value>The palette mode.</value>
        public PaletteMode PaletteMode
        {
            get => _paletteMode;
            set => _paletteMode = value;
        }
        #endregion

        #region System
        private KryptonPanel kpnlButtons;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnApply;
        private KryptonPanel kpnlContent;
        private KryptonTextBox ktxtCustomPath;
        private KryptonLabel klblCustomTheme;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnLoadTheme;
        private KryptonButton kbtnRestoreToDefaults;
        private KryptonThemeComboBox ktcmbTheme;
        private ButtonSpecAny bsaReset;
        private ButtonSpecAny bsaBrowse;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemeOptions));
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kbtnRestoreToDefaults = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnApply = new Krypton.Toolkit.KryptonButton();
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.ktcmbTheme = new Krypton.Toolkit.KryptonThemeComboBox();
            this.kbtnLoadTheme = new Krypton.Toolkit.KryptonButton();
            this.ktxtCustomPath = new Krypton.Toolkit.KryptonTextBox();
            this.bsaReset = new Krypton.Toolkit.ButtonSpecAny();
            this.bsaBrowse = new Krypton.Toolkit.ButtonSpecAny();
            this.klblCustomTheme = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).BeginInit();
            this.kpnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ktcmbTheme)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.kryptonBorderEdge1);
            this.kpnlButtons.Controls.Add(this.kbtnRestoreToDefaults);
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Controls.Add(this.kbtnOk);
            this.kpnlButtons.Controls.Add(this.kbtnApply);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 129);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlButtons.Size = new System.Drawing.Size(699, 50);
            this.kpnlButtons.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(699, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kbtnRestoreToDefaults
            // 
            this.kbtnRestoreToDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnRestoreToDefaults.CornerRoundingRadius = -1F;
            this.kbtnRestoreToDefaults.Enabled = false;
            this.kbtnRestoreToDefaults.Location = new System.Drawing.Point(12, 13);
            this.kbtnRestoreToDefaults.Name = "kbtnRestoreToDefaults";
            this.kbtnRestoreToDefaults.Size = new System.Drawing.Size(142, 25);
            this.kbtnRestoreToDefaults.TabIndex = 3;
            this.kbtnRestoreToDefaults.Values.Text = "&Restore to Defaults";
            this.kbtnRestoreToDefaults.Click += this.kbtnRestoreToDefaults_Click;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.CornerRoundingRadius = -1F;
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(501, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += this.kbtnCancel_Click;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.CornerRoundingRadius = -1F;
            this.kbtnOk.Location = new System.Drawing.Point(405, 13);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&Ok";
            this.kbtnOk.Click += this.kbtnOk_Click;
            // 
            // kbtnApply
            // 
            this.kbtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnApply.CornerRoundingRadius = -1F;
            this.kbtnApply.Enabled = false;
            this.kbtnApply.Location = new System.Drawing.Point(597, 13);
            this.kbtnApply.Name = "kbtnApply";
            this.kbtnApply.Size = new System.Drawing.Size(90, 25);
            this.kbtnApply.TabIndex = 0;
            this.kbtnApply.Values.Text = "A&pply";
            this.kbtnApply.Click += this.kbtnApply_Click;
            // 
            // kpnlContent
            // 
            this.kpnlContent.Controls.Add(this.ktcmbTheme);
            this.kpnlContent.Controls.Add(this.kbtnLoadTheme);
            this.kpnlContent.Controls.Add(this.ktxtCustomPath);
            this.kpnlContent.Controls.Add(this.klblCustomTheme);
            this.kpnlContent.Controls.Add(this.kryptonLabel1);
            this.kpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContent.Location = new System.Drawing.Point(0, 0);
            this.kpnlContent.Name = "kpnlContent";
            this.kpnlContent.Size = new System.Drawing.Size(699, 129);
            this.kpnlContent.TabIndex = 1;
            // 
            // ktcmbTheme
            // 
            this.ktcmbTheme.CornerRoundingRadius = -1F;
            this.ktcmbTheme.DropDownWidth = 198;
            this.ktcmbTheme.IntegralHeight = false;
            this.ktcmbTheme.Location = new System.Drawing.Point(116, 10);
            this.ktcmbTheme.Name = "ktcmbTheme";
            this.ktcmbTheme.Size = new System.Drawing.Size(198, 21);
            this.ktcmbTheme.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.ktcmbTheme.TabIndex = 6;
            this.ktcmbTheme.TextChanged += this.ktcmbTheme_TextChanged;
            // 
            // kbtnLoadTheme
            // 
            this.kbtnLoadTheme.CornerRoundingRadius = -1F;
            this.kbtnLoadTheme.Enabled = false;
            this.kbtnLoadTheme.Location = new System.Drawing.Point(598, 84);
            this.kbtnLoadTheme.Name = "kbtnLoadTheme";
            this.kbtnLoadTheme.Size = new System.Drawing.Size(90, 25);
            this.kbtnLoadTheme.TabIndex = 5;
            this.kbtnLoadTheme.Values.Text = "&Load";
            this.kbtnLoadTheme.Click += this.kbtnLoadTheme_Click;
            // 
            // ktxtCustomPath
            // 
            this.ktxtCustomPath.ButtonSpecs.AddRange(new Krypton.Toolkit.ButtonSpecAny[] {
            this.bsaReset,
            this.bsaBrowse});
            this.ktxtCustomPath.Enabled = false;
            this.ktxtCustomPath.Location = new System.Drawing.Point(198, 55);
            this.ktxtCustomPath.Name = "ktxtCustomPath";
            this.ktxtCustomPath.Size = new System.Drawing.Size(490, 26);
            this.ktxtCustomPath.TabIndex = 3;
            this.ktxtCustomPath.TextChanged += this.ktxtCustomPath_TextChanged;
            // 
            // bsaReset
            // 
            this.bsaReset.Image = ((System.Drawing.Image)(resources.GetObject("bsaReset.Image")));
            this.bsaReset.UniqueName = "1f0247d059a64ff792fa7879355b8bf1";
            this.bsaReset.Click += this.bsaReset_Click;
            // 
            // bsaBrowse
            // 
            this.bsaBrowse.Enabled = Krypton.Toolkit.ButtonEnabled.False;
            this.bsaBrowse.Text = "...";
            this.bsaBrowse.UniqueName = "71736a3a0e124395bcca501caca11870";
            this.bsaBrowse.Click += this.bsaBrowse_Click;
            // 
            // klblCustomTheme
            // 
            this.klblCustomTheme.Enabled = false;
            this.klblCustomTheme.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblCustomTheme.Location = new System.Drawing.Point(38, 55);
            this.klblCustomTheme.Name = "klblCustomTheme";
            this.klblCustomTheme.Size = new System.Drawing.Size(154, 20);
            this.klblCustomTheme.TabIndex = 2;
            this.klblCustomTheme.Values.Text = "Custom Theme File Path:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(97, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Palette Theme:";
            // 
            // ThemeOptions
            // 
            this.AcceptButton = this.kbtnOk;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(699, 179);
            this.Controls.Add(this.kpnlContent);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemeOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Palette Theme Options";
            this.Load += this.ThemeOptions_Load;
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            this.kpnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ktcmbTheme)).EndInit();
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
            SetPaletteMode(_paletteThemeSettingsManager.GetTheme());
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

        private void LoadPalette()
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

            if (!string.IsNullOrEmpty(ktxtCustomPath.Text))
            {
                bsaBrowse.Enabled = ButtonEnabled.True;
            }
            else
            {
                bsaBrowse.Enabled = ButtonEnabled.False;
            }
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            if (ktxtCustomPath.Text != string.Empty)
            {
                //ChangeTheme(PaletteMode.Custom);
            }
        }

        #region Methods
        private void ChangeTheme(PaletteMode paletteMode)
        {
            SetPaletteMode(paletteMode);

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

        private void EnableCustomThemeControls(bool enabled, ButtonEnabled buttonEnabled)
        {
            klblCustomTheme.Enabled = enabled;

            ktxtCustomPath.Enabled = enabled;

            bsaBrowse.Enabled = buttonEnabled;
        }
        #endregion

        private void kbtnLoadTheme_Click(object sender, EventArgs e)
        {
            _palette.Import();
        }

        private void kbtnRestoreToDefaults_Click(object sender, EventArgs e)
        {
            _paletteThemeSettingsManager.ResetPaletteThemeSettings(true);

            ChangeTheme(_paletteThemeSettingsManager.GetTheme());

            EnableRestoreToDefaultsButton(false);
        }

        #region Setter/Getters
        /// <summary>
        /// Sets the PaletteMode to the value of paletteMode.
        /// </summary>
        /// <param name="paletteMode">The value of paletteMode.</param>
        public void SetPaletteMode(PaletteMode paletteMode)
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

        private void bsaBrowse_Click(object sender, EventArgs e)
        {
            LoadPalette();
        }

        private void bsaReset_Click(object sender, EventArgs e)
        {
            ktxtCustomPath.Text = string.Empty;

            bsaBrowse.Enabled = ButtonEnabled.False;
        }

        private void ktcmbTheme_TextChanged(object sender, EventArgs e)
        {
            if (ktcmbTheme.Text == @"Custom")
            {
                EnableCustomThemeControls(true, ButtonEnabled.True);
            }
            else
            {
                EnableCustomThemeControls(false, ButtonEnabled.False);
            }
        }
    }
}
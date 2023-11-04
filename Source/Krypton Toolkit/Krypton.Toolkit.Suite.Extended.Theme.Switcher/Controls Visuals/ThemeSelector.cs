#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

#nullable enable
namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class ThemeSelector : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnOptions;
        private KryptonButton kbtnResetTheme;
        private KryptonButton kbtnLoadTheme;
        private KryptonButton kbtnCancel;
        private KryptonPanel kryptonPanel2;
        private KryptonLabel kryptonLabel1;
        private IContainer components;
        private KryptonThemeComboBox kcmbSelectedTheme;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOptions = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetTheme = new Krypton.Toolkit.KryptonButton();
            this.kbtnLoadTheme = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kcmbSelectedTheme = new Krypton.Toolkit.KryptonThemeComboBox();
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
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 82);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(470, 50);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kbtnOptions
            // 
            this.kbtnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOptions.CornerRoundingRadius = -1F;
            this.kbtnOptions.Location = new System.Drawing.Point(272, 13);
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
            this.kbtnResetTheme.CornerRoundingRadius = -1F;
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
            this.kbtnLoadTheme.CornerRoundingRadius = -1F;
            this.kbtnLoadTheme.Location = new System.Drawing.Point(12, 13);
            this.kbtnLoadTheme.Name = "kbtnLoadTheme";
            this.kbtnLoadTheme.Size = new System.Drawing.Size(90, 25);
            this.kbtnLoadTheme.TabIndex = 2;
            this.kbtnLoadTheme.Values.Text = "Load Th&eme";
            this.kbtnLoadTheme.Click += new System.EventHandler(this.kbtnLoadTheme_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.CornerRoundingRadius = -1F;
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(368, 13);
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
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(470, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kcmbSelectedTheme);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(470, 82);
            this.kryptonPanel2.TabIndex = 3;
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
            // kcmbSelectedTheme
            // 
            this.kcmbSelectedTheme.CornerRoundingRadius = -1F;
            this.kcmbSelectedTheme.DropDownWidth = 445;
            this.kcmbSelectedTheme.IntegralHeight = false;
            this.kcmbSelectedTheme.Location = new System.Drawing.Point(13, 39);
            this.kcmbSelectedTheme.Name = "kcmbSelectedTheme";
            this.kcmbSelectedTheme.Size = new System.Drawing.Size(445, 21);
            this.kcmbSelectedTheme.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbSelectedTheme.TabIndex = 1;
            // 
            // ThemeSelector
            // 
            this.ClientSize = new System.Drawing.Size(470, 132);
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
        private SettingsManager _settingsManager = new();

        ThemeManager _themeManager = new();

        private KryptonManager _manager;

        private KryptonCustomPaletteBase _palette;
        #endregion

        #region Constructor
        public ThemeSelector(KryptonManager? manager)
        {
            InitializeComponent();

            _manager = manager ?? new KryptonManager();

            _palette = new KryptonCustomPaletteBase();

            ThemeManager.PropagateThemeList(kcmbSelectedTheme);
        }
        #endregion

        #region Methods
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
            _settingsManager.SetSelectedTheme(PaletteMode.Microsoft365Blue);

            _settingsManager.SetCustomThemePath(string.Empty);

            _settingsManager.SaveSettings(_settingsManager.GetAskMe());

            _manager.GlobalPalette = null;

            _manager.GlobalPaletteMode = PaletteMode.Microsoft365Blue;

            kcmbSelectedTheme.Text = @"Microsoft 365 - Blue";

            EnableResetButton(false);
        }

        private void kbtnLoadTheme_Click(object sender, EventArgs e)
        {
            _palette.Import();

            _manager.GlobalPalette = _palette;

            _manager.GlobalPaletteMode = PaletteMode.Custom;

            kcmbSelectedTheme.Text = @"Custom";

            EnableResetButton(true);
        }

        private void ThemeSelector_Load(object sender, EventArgs e)
        {
            ThemeManager.SetPaletteTheme(_settingsManager.GetSelectedTheme(), kcmbSelectedTheme);

            _themeManager.ApplyTheme(kcmbSelectedTheme.Text, _manager);
        }

        private void ThemeSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settingsManager.SaveSettings(_settingsManager.GetAskMe());
        }

        private void kcmbSelectedTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableResetButton(true);
        }
    }
}
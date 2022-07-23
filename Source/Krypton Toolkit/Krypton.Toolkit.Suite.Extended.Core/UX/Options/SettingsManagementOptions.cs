#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class SettingsManagementOptions : KryptonForm
    {
        #region Variables
        private ColourIntensitySettingsManager _colourBlendingSettingsManager = new ColourIntensitySettingsManager();
        private ColourIntegerSettingsManager _colourIntegerSettingsManager = new ColourIntegerSettingsManager();
        private AllMergedColourSettingsManager _colourSettingsManager = new AllMergedColourSettingsManager();
        private ColourStringSettingsManager _colourStringSettingsManager = new ColourStringSettingsManager();
        private GlobalBooleanSettingsManager _globalBooleanSettingsManager = new GlobalBooleanSettingsManager();
        private GlobalStringSettingsManager _globalStringSettingsManager = new GlobalStringSettingsManager();
        private PaletteTypefaceSettingsManager _paletteTypefaceSettingsManager = new PaletteTypefaceSettingsManager();
        #endregion

        #region System
        private KryptonPanel kryptonPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private KryptonButton kbtnResetPaletteTypefaceSettings;
        private KryptonButton kbtnResetGlobalStringSettings;
        private KryptonButton kbtnResetGlobalBooleanSettings;
        private KryptonButton kbtnResetColourStringSettings;
        private KryptonButton kbtnResetColourSettings;
        private KryptonButton kbtnResetColourIntegerSettings;
        private KryptonButton kbtnResetColourBlendingSettings;
        private KryptonButton kbtnNukeAllSettings;
        private KryptonCheckBox kchkAskForConfirmation;
        private KryptonButton kbtnCancel;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kbtnNukeAllSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourBlendingSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourIntegerSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourStringSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetGlobalBooleanSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetGlobalStringSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetPaletteTypefaceSettings = new Krypton.Toolkit.KryptonButton();
            this.kchkAskForConfirmation = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnResetPaletteTypefaceSettings);
            this.kryptonPanel1.Controls.Add(this.kbtnResetGlobalStringSettings);
            this.kryptonPanel1.Controls.Add(this.kbtnResetGlobalBooleanSettings);
            this.kryptonPanel1.Controls.Add(this.kbtnResetColourStringSettings);
            this.kryptonPanel1.Controls.Add(this.kbtnResetColourSettings);
            this.kryptonPanel1.Controls.Add(this.kbtnResetColourIntegerSettings);
            this.kryptonPanel1.Controls.Add(this.kbtnResetColourBlendingSettings);
            this.kryptonPanel1.Controls.Add(this.kbtnNukeAllSettings);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(714, 535);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnCancel);
            this.kryptonPanel2.Controls.Add(this.kchkAskForConfirmation);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 483);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(714, 52);
            this.kryptonPanel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 481);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(714, 2);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // kbtnNukeAllSettings
            // 
            this.kbtnNukeAllSettings.AutoSize = true;
            this.kbtnNukeAllSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnNukeAllSettings.Location = new System.Drawing.Point(12, 418);
            this.kbtnNukeAllSettings.Name = "kbtnNukeAllSettings";
            this.kbtnNukeAllSettings.Size = new System.Drawing.Size(137, 30);
            this.kbtnNukeAllSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnNukeAllSettings.TabIndex = 64;
            this.kbtnNukeAllSettings.Values.Text = "&Nuke All Settings";
            this.kbtnNukeAllSettings.Click += new System.EventHandler(this.kbtnNukeAllSettings_Click);
            // 
            // kbtnResetColourBlendingSettings
            // 
            this.kbtnResetColourBlendingSettings.AutoSize = true;
            this.kbtnResetColourBlendingSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetColourBlendingSettings.Location = new System.Drawing.Point(12, 12);
            this.kbtnResetColourBlendingSettings.Name = "kbtnResetColourBlendingSettings";
            this.kbtnResetColourBlendingSettings.Size = new System.Drawing.Size(236, 30);
            this.kbtnResetColourBlendingSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetColourBlendingSettings.TabIndex = 65;
            this.kbtnResetColourBlendingSettings.Values.Text = "Reset Colour &Blending Settings";
            this.kbtnResetColourBlendingSettings.Click += new System.EventHandler(this.kbtnResetColourBlendingSettings_Click);
            // 
            // kbtnResetColourIntegerSettings
            // 
            this.kbtnResetColourIntegerSettings.AutoSize = true;
            this.kbtnResetColourIntegerSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetColourIntegerSettings.Location = new System.Drawing.Point(12, 70);
            this.kbtnResetColourIntegerSettings.Name = "kbtnResetColourIntegerSettings";
            this.kbtnResetColourIntegerSettings.Size = new System.Drawing.Size(224, 30);
            this.kbtnResetColourIntegerSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetColourIntegerSettings.TabIndex = 66;
            this.kbtnResetColourIntegerSettings.Values.Text = "Reset Colour &Integer Settings";
            this.kbtnResetColourIntegerSettings.Click += new System.EventHandler(this.kbtnResetColourIntegerSettings_Click);
            // 
            // kbtnResetColourSettings
            // 
            this.kbtnResetColourSettings.AutoSize = true;
            this.kbtnResetColourSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetColourSettings.Location = new System.Drawing.Point(12, 128);
            this.kbtnResetColourSettings.Name = "kbtnResetColourSettings";
            this.kbtnResetColourSettings.Size = new System.Drawing.Size(168, 30);
            this.kbtnResetColourSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetColourSettings.TabIndex = 67;
            this.kbtnResetColourSettings.Values.Text = "Reset &Colour Settings";
            this.kbtnResetColourSettings.Click += new System.EventHandler(this.kbtnResetColourSettings_Click);
            // 
            // kbtnResetColourStringSettings
            // 
            this.kbtnResetColourStringSettings.AutoSize = true;
            this.kbtnResetColourStringSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetColourStringSettings.Location = new System.Drawing.Point(12, 186);
            this.kbtnResetColourStringSettings.Name = "kbtnResetColourStringSettings";
            this.kbtnResetColourStringSettings.Size = new System.Drawing.Size(215, 30);
            this.kbtnResetColourStringSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetColourStringSettings.TabIndex = 68;
            this.kbtnResetColourStringSettings.Values.Text = "Reset Colour &String Settings";
            this.kbtnResetColourStringSettings.Click += new System.EventHandler(this.kbtnResetColourStringSettings_Click);
            // 
            // kbtnResetGlobalBooleanSettings
            // 
            this.kbtnResetGlobalBooleanSettings.AutoSize = true;
            this.kbtnResetGlobalBooleanSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetGlobalBooleanSettings.Location = new System.Drawing.Point(12, 244);
            this.kbtnResetGlobalBooleanSettings.Name = "kbtnResetGlobalBooleanSettings";
            this.kbtnResetGlobalBooleanSettings.Size = new System.Drawing.Size(230, 30);
            this.kbtnResetGlobalBooleanSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetGlobalBooleanSettings.TabIndex = 69;
            this.kbtnResetGlobalBooleanSettings.Values.Text = "Reset Global B&oolean Settings";
            this.kbtnResetGlobalBooleanSettings.Click += new System.EventHandler(this.kbtnResetGlobalBooleanSettings_Click);
            // 
            // kbtnResetGlobalStringSettings
            // 
            this.kbtnResetGlobalStringSettings.AutoSize = true;
            this.kbtnResetGlobalStringSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetGlobalStringSettings.Location = new System.Drawing.Point(12, 302);
            this.kbtnResetGlobalStringSettings.Name = "kbtnResetGlobalStringSettings";
            this.kbtnResetGlobalStringSettings.Size = new System.Drawing.Size(214, 30);
            this.kbtnResetGlobalStringSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetGlobalStringSettings.TabIndex = 70;
            this.kbtnResetGlobalStringSettings.Values.Text = "Reset &Global String Settings";
            this.kbtnResetGlobalStringSettings.Click += new System.EventHandler(this.kbtnResetGlobalStringSettings_Click);
            // 
            // kbtnResetPaletteTypefaceSettings
            // 
            this.kbtnResetPaletteTypefaceSettings.AutoSize = true;
            this.kbtnResetPaletteTypefaceSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetPaletteTypefaceSettings.Location = new System.Drawing.Point(12, 360);
            this.kbtnResetPaletteTypefaceSettings.Name = "kbtnResetPaletteTypefaceSettings";
            this.kbtnResetPaletteTypefaceSettings.Size = new System.Drawing.Size(238, 30);
            this.kbtnResetPaletteTypefaceSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetPaletteTypefaceSettings.TabIndex = 71;
            this.kbtnResetPaletteTypefaceSettings.Values.Text = "Reset &Palette Typeface Settings";
            this.kbtnResetPaletteTypefaceSettings.Click += new System.EventHandler(this.kbtnResetPaletteTypefaceSettings_Click);
            // 
            // kchkAskForConfirmation
            // 
            this.kchkAskForConfirmation.Location = new System.Drawing.Point(12, 14);
            this.kchkAskForConfirmation.Name = "kchkAskForConfirmation";
            this.kchkAskForConfirmation.Size = new System.Drawing.Size(175, 26);
            this.kchkAskForConfirmation.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkAskForConfirmation.TabIndex = 0;
            this.kchkAskForConfirmation.Values.Text = "&Ask for Confirmation";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.AutoSize = true;
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(612, 10);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 30);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.TabIndex = 4;
            this.kbtnCancel.Values.Text = "Ca&ncel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // SettingsManagementOptions
            // 
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(714, 535);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsManagementOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Settings";
            this.Load += new System.EventHandler(this.SettingsManagementOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructors
        public SettingsManagementOptions()
        {
            InitializeComponent();
        }
        #endregion

        private void SettingsManagementOptions_Load(object sender, EventArgs e)
        {

        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void kbtnResetColourBlendingSettings_Click(object sender, EventArgs e)
        {
            _colourBlendingSettingsManager.ResetColourBlendingValues(kchkAskForConfirmation.Checked);

            _colourBlendingSettingsManager.SaveColourBlendingValues(kchkAskForConfirmation.Checked);

            kbtnResetColourBlendingSettings.Enabled = false;
        }

        private void kbtnResetColourIntegerSettings_Click(object sender, EventArgs e)
        {
            _colourIntegerSettingsManager.ResetColourIntegerSettings(kchkAskForConfirmation.Checked);

            _colourIntegerSettingsManager.SaveColourIntegerSettings(kchkAskForConfirmation.Checked);

            kbtnResetColourIntegerSettings.Enabled = false;
        }

        private void kbtnResetColourSettings_Click(object sender, EventArgs e)
        {
            _colourSettingsManager.ResetToDefaults(); // (kchkAskForConfirmation.Checked);

            _colourSettingsManager.SaveAllMergedColourSettings(kchkAskForConfirmation.Checked);

            kbtnResetColourSettings.Enabled = false;
        }

        private void kbtnResetColourStringSettings_Click(object sender, EventArgs e)
        {
            _colourStringSettingsManager.ResetColourStringSettings(kchkAskForConfirmation.Checked);

            _colourStringSettingsManager.SaveColourStringSettings(kchkAskForConfirmation.Checked);

            kbtnResetColourStringSettings.Enabled = false;
        }

        private void kbtnResetGlobalBooleanSettings_Click(object sender, EventArgs e)
        {
            _globalBooleanSettingsManager.ResetSettings(kchkAskForConfirmation.Checked);

            _globalBooleanSettingsManager.SaveBooleanSettings(kchkAskForConfirmation.Checked);

            kbtnResetGlobalBooleanSettings.Enabled = false;
        }

        private void kbtnResetGlobalStringSettings_Click(object sender, EventArgs e)
        {
            _globalStringSettingsManager.ResetSettings(kchkAskForConfirmation.Checked);

            _globalStringSettingsManager.SaveStringSettings(kchkAskForConfirmation.Checked);

            kbtnResetGlobalStringSettings.Enabled = false;
        }

        private void kbtnResetPaletteTypefaceSettings_Click(object sender, EventArgs e)
        {
            _paletteTypefaceSettingsManager.ResetPaletteTypefaceSettings(kchkAskForConfirmation.Checked);

            _paletteTypefaceSettingsManager.SavePaletteTypefaceSettings(kchkAskForConfirmation.Checked);

            kchkAskForConfirmation.Enabled = false;
        }

        private void kbtnNukeAllSettings_Click(object sender, EventArgs e)
        {
            NukeAllSettings(kchkAskForConfirmation.Checked);
        }

        private void NukeAllSettings(bool usePrompt)
        {
            if (usePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Warning: This action will reset all settings back to their defaults, and is not reversible!\nDo you want to proceed?", "Nuke All Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    _colourBlendingSettingsManager.ResetColourBlendingValues();

                    _colourBlendingSettingsManager.SaveColourBlendingValues();

                    kbtnResetColourBlendingSettings.Enabled = false;

                    _colourIntegerSettingsManager.ResetColourIntegerSettings();

                    _colourIntegerSettingsManager.SaveColourIntegerSettings();

                    kbtnResetColourIntegerSettings.Enabled = false;

                    _colourSettingsManager.ResetToDefaults();

                    _colourSettingsManager.SaveAllMergedColourSettings();

                    kbtnResetColourSettings.Enabled = false;

                    _colourStringSettingsManager.ResetColourStringSettings();

                    _colourStringSettingsManager.SaveColourStringSettings();

                    kbtnResetColourStringSettings.Enabled = false;

                    _globalBooleanSettingsManager.ResetSettings();

                    _globalBooleanSettingsManager.SaveBooleanSettings();

                    kbtnResetGlobalBooleanSettings.Enabled = false;

                    _globalStringSettingsManager.ResetSettings();

                    _globalStringSettingsManager.SaveStringSettings();

                    kbtnResetGlobalStringSettings.Enabled = false;

                    _paletteTypefaceSettingsManager.ResetPaletteTypefaceSettings();

                    _paletteTypefaceSettingsManager.SavePaletteTypefaceSettings();

                    kbtnResetPaletteTypefaceSettings.Enabled = false;

                    kbtnNukeAllSettings.Enabled = false;
                }
            }
        }
    }
}
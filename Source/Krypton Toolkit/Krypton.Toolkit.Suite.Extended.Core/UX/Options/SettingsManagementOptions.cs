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
    public partial class SettingsManagementOptions : KryptonForm
    {
        #region Variables
        private ColourIntensitySettingsManager _colourBlendingSettingsManager = new();
        private ColourIntegerSettingsManager _colourIntegerSettingsManager = new();
        private AllMergedColourSettingsManager _colourSettingsManager = new();
        private ColourStringSettingsManager _colourStringSettingsManager = new();
        private GlobalBooleanSettingsManager _globalBooleanSettingsManager = new();
        private GlobalStringSettingsManager _globalStringSettingsManager = new();
        private PaletteTypefaceSettingsManager _paletteTypefaceSettingsManager = new();
        #endregion

        #region System
        private KryptonPanel kryptonPanel2;
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
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnResetPaletteTypefaceSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetGlobalStringSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetGlobalBooleanSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourStringSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourIntegerSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourBlendingSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnNukeAllSettings = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kchkAskForConfirmation = new Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
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
            // kbtnResetPaletteTypefaceSettings
            // 
            this.kbtnResetPaletteTypefaceSettings.CornerRoundingRadius = -1F;
            this.kbtnResetPaletteTypefaceSettings.Location = new System.Drawing.Point(12, 360);
            this.kbtnResetPaletteTypefaceSettings.Name = "kbtnResetPaletteTypefaceSettings";
            this.kbtnResetPaletteTypefaceSettings.Size = new System.Drawing.Size(226, 25);
            this.kbtnResetPaletteTypefaceSettings.TabIndex = 71;
            this.kbtnResetPaletteTypefaceSettings.Values.Text = "Reset &Palette Typeface Settings";
            this.kbtnResetPaletteTypefaceSettings.Click += this.kbtnResetPaletteTypefaceSettings_Click;
            // 
            // kbtnResetGlobalStringSettings
            // 
            this.kbtnResetGlobalStringSettings.CornerRoundingRadius = -1F;
            this.kbtnResetGlobalStringSettings.Location = new System.Drawing.Point(12, 302);
            this.kbtnResetGlobalStringSettings.Name = "kbtnResetGlobalStringSettings";
            this.kbtnResetGlobalStringSettings.Size = new System.Drawing.Size(226, 25);
            this.kbtnResetGlobalStringSettings.TabIndex = 70;
            this.kbtnResetGlobalStringSettings.Values.Text = "Reset &Global String Settings";
            this.kbtnResetGlobalStringSettings.Click += this.kbtnResetGlobalStringSettings_Click;
            // 
            // kbtnResetGlobalBooleanSettings
            // 
            this.kbtnResetGlobalBooleanSettings.CornerRoundingRadius = -1F;
            this.kbtnResetGlobalBooleanSettings.Location = new System.Drawing.Point(12, 244);
            this.kbtnResetGlobalBooleanSettings.Name = "kbtnResetGlobalBooleanSettings";
            this.kbtnResetGlobalBooleanSettings.Size = new System.Drawing.Size(226, 25);
            this.kbtnResetGlobalBooleanSettings.TabIndex = 69;
            this.kbtnResetGlobalBooleanSettings.Values.Text = "Reset Global B&oolean Settings";
            this.kbtnResetGlobalBooleanSettings.Click += this.kbtnResetGlobalBooleanSettings_Click;
            // 
            // kbtnResetColourStringSettings
            // 
            this.kbtnResetColourStringSettings.CornerRoundingRadius = -1F;
            this.kbtnResetColourStringSettings.Location = new System.Drawing.Point(12, 186);
            this.kbtnResetColourStringSettings.Name = "kbtnResetColourStringSettings";
            this.kbtnResetColourStringSettings.Size = new System.Drawing.Size(226, 25);
            this.kbtnResetColourStringSettings.TabIndex = 68;
            this.kbtnResetColourStringSettings.Values.Text = "Reset Colour &String Settings";
            this.kbtnResetColourStringSettings.Click += this.kbtnResetColourStringSettings_Click;
            // 
            // kbtnResetColourSettings
            // 
            this.kbtnResetColourSettings.CornerRoundingRadius = -1F;
            this.kbtnResetColourSettings.Location = new System.Drawing.Point(12, 128);
            this.kbtnResetColourSettings.Name = "kbtnResetColourSettings";
            this.kbtnResetColourSettings.Size = new System.Drawing.Size(226, 25);
            this.kbtnResetColourSettings.TabIndex = 67;
            this.kbtnResetColourSettings.Values.Text = "Reset &Colour Settings";
            this.kbtnResetColourSettings.Click += this.kbtnResetColourSettings_Click;
            // 
            // kbtnResetColourIntegerSettings
            // 
            this.kbtnResetColourIntegerSettings.CornerRoundingRadius = -1F;
            this.kbtnResetColourIntegerSettings.Location = new System.Drawing.Point(12, 70);
            this.kbtnResetColourIntegerSettings.Name = "kbtnResetColourIntegerSettings";
            this.kbtnResetColourIntegerSettings.Size = new System.Drawing.Size(226, 25);
            this.kbtnResetColourIntegerSettings.TabIndex = 66;
            this.kbtnResetColourIntegerSettings.Values.Text = "Reset Colour &Integer Settings";
            this.kbtnResetColourIntegerSettings.Click += this.kbtnResetColourIntegerSettings_Click;
            // 
            // kbtnResetColourBlendingSettings
            // 
            this.kbtnResetColourBlendingSettings.CornerRoundingRadius = -1F;
            this.kbtnResetColourBlendingSettings.Location = new System.Drawing.Point(12, 12);
            this.kbtnResetColourBlendingSettings.Name = "kbtnResetColourBlendingSettings";
            this.kbtnResetColourBlendingSettings.Size = new System.Drawing.Size(226, 25);
            this.kbtnResetColourBlendingSettings.TabIndex = 65;
            this.kbtnResetColourBlendingSettings.Values.Text = "Reset Colour &Blending Settings";
            this.kbtnResetColourBlendingSettings.Click += this.kbtnResetColourBlendingSettings_Click;
            // 
            // kbtnNukeAllSettings
            // 
            this.kbtnNukeAllSettings.CornerRoundingRadius = -1F;
            this.kbtnNukeAllSettings.Location = new System.Drawing.Point(12, 418);
            this.kbtnNukeAllSettings.Name = "kbtnNukeAllSettings";
            this.kbtnNukeAllSettings.Size = new System.Drawing.Size(226, 25);
            this.kbtnNukeAllSettings.TabIndex = 64;
            this.kbtnNukeAllSettings.Values.Text = "&Nuke All Settings";
            this.kbtnNukeAllSettings.Click += this.kbtnNukeAllSettings_Click;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel2.Controls.Add(this.kbtnCancel);
            this.kryptonPanel2.Controls.Add(this.kchkAskForConfirmation);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 483);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel2.Size = new System.Drawing.Size(714, 52);
            this.kryptonPanel2.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(714, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.AutoSize = true;
            this.kbtnCancel.CornerRoundingRadius = -1F;
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(612, 15);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 4;
            this.kbtnCancel.Values.Text = "Ca&ncel";
            this.kbtnCancel.Click += this.kbtnCancel_Click;
            // 
            // kchkAskForConfirmation
            // 
            this.kchkAskForConfirmation.Location = new System.Drawing.Point(12, 20);
            this.kchkAskForConfirmation.Name = "kchkAskForConfirmation";
            this.kchkAskForConfirmation.Size = new System.Drawing.Size(136, 20);
            this.kchkAskForConfirmation.TabIndex = 0;
            this.kchkAskForConfirmation.Values.Text = "&Ask for Confirmation";
            // 
            // SettingsManagementOptions
            // 
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(714, 535);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsManagementOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Settings";
            this.Load += this.SettingsManagementOptions_Load;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
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
                DialogResult result = KryptonMessageBox.Show("Warning: This action will reset all settings back to their defaults, and is not reversible!\nDo you want to proceed?", "Nuke All Settings", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Warning, KryptonMessageBoxDefaultButton.Button2);

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
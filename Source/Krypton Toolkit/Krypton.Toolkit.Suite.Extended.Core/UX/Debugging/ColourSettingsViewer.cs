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
    public partial class ColourSettingsViewer : KryptonForm
    {
        #region System
        private KryptonPanel kryptonPanel2;
        private KryptonListBox klblRGBValues;
        private KryptonListBox klbHexValues;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnAllColoursAsRGB;
        private KryptonButton kbtnAllColoursAsHex;
        private System.Windows.Forms.PictureBox pbxColourPreviewer;
        private KryptonButton kbtnResetValues;
        private KryptonCheckBox kchkAutomaticallyUpdateValues;
        private KryptonButton kbtnLoadFromFile;
        private KryptonButton kbtnExport;
        private KryptonCheckBox kchkUseUppercase;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new();
            this.kchkAutomaticallyUpdateValues = new();
            this.kbtnOk = new();
            this.kryptonPanel2 = new();
            this.kchkUseUppercase = new();
            this.kbtnLoadFromFile = new();
            this.kbtnExport = new();
            this.pbxColourPreviewer = new();
            this.kbtnResetValues = new();
            this.kbtnAllColoursAsRGB = new();
            this.kbtnAllColoursAsHex = new();
            this.klblRGBValues = new();
            this.klbHexValues = new();
            this.kryptonBorderEdge1 = new();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColourPreviewer)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Controls.Add(this.kchkAutomaticallyUpdateValues);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new(0, 732);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new(1011, 49);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kchkAutomaticallyUpdateValues
            // 
            this.kchkAutomaticallyUpdateValues.Location = new(13, 17);
            this.kchkAutomaticallyUpdateValues.Name = "kchkAutomaticallyUpdateValues";
            this.kchkAutomaticallyUpdateValues.Size = new(180, 20);
            this.kchkAutomaticallyUpdateValues.TabIndex = 36;
            this.kchkAutomaticallyUpdateValues.Values.Text = "&Automatically Update Values";
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.CornerRoundingRadius = -1F;
            this.kbtnOk.Location = new(909, 12);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new(90, 25);
            this.kbtnOk.TabIndex = 3;
            this.kbtnOk.Values.Text = "&Ok";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kchkUseUppercase);
            this.kryptonPanel2.Controls.Add(this.kbtnLoadFromFile);
            this.kryptonPanel2.Controls.Add(this.kbtnExport);
            this.kryptonPanel2.Controls.Add(this.pbxColourPreviewer);
            this.kryptonPanel2.Controls.Add(this.kbtnResetValues);
            this.kryptonPanel2.Controls.Add(this.kbtnAllColoursAsRGB);
            this.kryptonPanel2.Controls.Add(this.kbtnAllColoursAsHex);
            this.kryptonPanel2.Controls.Add(this.klblRGBValues);
            this.kryptonPanel2.Controls.Add(this.klbHexValues);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new(1011, 732);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kchkUseUppercase
            // 
            this.kchkUseUppercase.Location = new(311, 510);
            this.kchkUseUppercase.Name = "kchkUseUppercase";
            this.kchkUseUppercase.Size = new(105, 20);
            this.kchkUseUppercase.TabIndex = 37;
            this.kchkUseUppercase.Values.Text = "Use &Uppercase";
            // 
            // kbtnLoadFromFile
            // 
            this.kbtnLoadFromFile.CornerRoundingRadius = -1F;
            this.kbtnLoadFromFile.Location = new(13, 681);
            this.kbtnLoadFromFile.Name = "kbtnLoadFromFile";
            this.kbtnLoadFromFile.Size = new(137, 30);
            this.kbtnLoadFromFile.TabIndex = 11;
            this.kbtnLoadFromFile.Values.Text = "&Load from File";
            // 
            // kbtnExport
            // 
            this.kbtnExport.CornerRoundingRadius = -1F;
            this.kbtnExport.Enabled = false;
            this.kbtnExport.Location = new(13, 637);
            this.kbtnExport.Name = "kbtnExport";
            this.kbtnExport.Size = new(147, 30);
            this.kbtnExport.TabIndex = 10;
            this.kbtnExport.Values.Text = "E&xport to File";
            // 
            // pbxColourPreviewer
            // 
            this.pbxColourPreviewer.BackColor = System.Drawing.Color.Transparent;
            this.pbxColourPreviewer.Location = new(515, 506);
            this.pbxColourPreviewer.Name = "pbxColourPreviewer";
            this.pbxColourPreviewer.Size = new(484, 120);
            this.pbxColourPreviewer.TabIndex = 6;
            this.pbxColourPreviewer.TabStop = false;
            // 
            // kbtnResetValues
            // 
            this.kbtnResetValues.CornerRoundingRadius = -1F;
            this.kbtnResetValues.Enabled = false;
            this.kbtnResetValues.Location = new(13, 593);
            this.kbtnResetValues.Name = "kbtnResetValues";
            this.kbtnResetValues.Size = new(144, 30);
            this.kbtnResetValues.TabIndex = 5;
            this.kbtnResetValues.Values.Text = "Re&set Values";
            // 
            // kbtnAllColoursAsRGB
            // 
            this.kbtnAllColoursAsRGB.CornerRoundingRadius = -1F;
            this.kbtnAllColoursAsRGB.Location = new(13, 549);
            this.kbtnAllColoursAsRGB.Name = "kbtnAllColoursAsRGB";
            this.kbtnAllColoursAsRGB.Size = new(292, 30);
            this.kbtnAllColoursAsRGB.TabIndex = 4;
            this.kbtnAllColoursAsRGB.Values.Text = "Get all Colour Settings as &RGB";
            this.kbtnAllColoursAsRGB.Click += new(this.kbtnAllColoursAsRGB_Click);
            // 
            // kbtnAllColoursAsHex
            // 
            this.kbtnAllColoursAsHex.CornerRoundingRadius = -1F;
            this.kbtnAllColoursAsHex.Location = new(13, 505);
            this.kbtnAllColoursAsHex.Name = "kbtnAllColoursAsHex";
            this.kbtnAllColoursAsHex.Size = new(292, 30);
            this.kbtnAllColoursAsHex.TabIndex = 3;
            this.kbtnAllColoursAsHex.Values.Text = "&Get all Colour Settings as Hexadecimal";
            this.kbtnAllColoursAsHex.Click += new(this.kbtnAllColoursAsHex_Click);
            // 
            // klblRGBValues
            // 
            this.klblRGBValues.Location = new(515, 13);
            this.klblRGBValues.Name = "klblRGBValues";
            this.klblRGBValues.Size = new(484, 473);
            this.klblRGBValues.TabIndex = 1;
            // 
            // klbHexValues
            // 
            this.klbHexValues.Location = new(13, 13);
            this.klbHexValues.Name = "klbHexValues";
            this.klbHexValues.Size = new(484, 473);
            this.klbHexValues.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new(1011, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // ColourSettingsViewer
            // 
            this.ClientSize = new(1011, 781);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourSettingsViewer";
            this.ShowInTaskbar = false;
            this.Text = "Palette Debug Console";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColourPreviewer)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public ColourSettingsViewer()
        {
            InitializeComponent();
        }

        private void kbtnAllColoursAsHex_Click(object sender, EventArgs e)
        {
            try
            {
                KryptonPaletteDebugManagement.PropagateHEXColourValues(klbHexValues, kchkUseUppercase.Checked);
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc, icon: ExtendedKryptonMessageBoxIcon.Error, methodSignature: Helpers.GetCurrentMethod());
            }
        }

        private void kbtnAllColoursAsRGB_Click(object sender, EventArgs e)
        {
            try
            {
                KryptonPaletteDebugManagement.PropagateRGBColourValues(klblRGBValues, kchkAutomaticallyUpdateValues.Checked);
            }
            catch (Exception exc)
            {

                throw;
            }
        }
    }
}
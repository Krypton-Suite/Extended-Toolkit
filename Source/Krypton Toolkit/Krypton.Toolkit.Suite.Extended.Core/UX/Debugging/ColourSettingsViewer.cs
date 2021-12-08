#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnAllColoursAsRGB;
        private KryptonButton kbtnAllColoursAsHex;
        private System.Windows.Forms.PictureBox pbxColourPreviewer;
        private KryptonButton kbtnResetValues;
        private KryptonCheckBox kchkAutomaticallyUpdateValues;
        private KryptonButton kbtnLoadFromFile;
        private KryptonButton kbtnExport;
        private KryptonCheckBox kchkUseUppercase;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kchkAutomaticallyUpdateValues = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kchkUseUppercase = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnLoadFromFile = new Krypton.Toolkit.KryptonButton();
            this.kbtnExport = new Krypton.Toolkit.KryptonButton();
            this.pbxColourPreviewer = new System.Windows.Forms.PictureBox();
            this.kbtnResetValues = new Krypton.Toolkit.KryptonButton();
            this.kbtnAllColoursAsRGB = new Krypton.Toolkit.KryptonButton();
            this.kbtnAllColoursAsHex = new Krypton.Toolkit.KryptonButton();
            this.klblRGBValues = new Krypton.Toolkit.KryptonListBox();
            this.klbHexValues = new Krypton.Toolkit.KryptonListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColourPreviewer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kchkAutomaticallyUpdateValues);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 732);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1011, 49);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kchkAutomaticallyUpdateValues
            // 
            this.kchkAutomaticallyUpdateValues.Location = new System.Drawing.Point(13, 11);
            this.kchkAutomaticallyUpdateValues.Name = "kchkAutomaticallyUpdateValues";
            this.kchkAutomaticallyUpdateValues.Size = new System.Drawing.Size(234, 26);
            this.kchkAutomaticallyUpdateValues.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkAutomaticallyUpdateValues.TabIndex = 36;
            this.kchkAutomaticallyUpdateValues.Values.Text = "&Automatically Update Values";
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.AutoSize = true;
            this.kbtnOk.Location = new System.Drawing.Point(909, 7);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 30);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1011, 732);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kchkUseUppercase
            // 
            this.kchkUseUppercase.Location = new System.Drawing.Point(311, 510);
            this.kchkUseUppercase.Name = "kchkUseUppercase";
            this.kchkUseUppercase.Size = new System.Drawing.Size(133, 26);
            this.kchkUseUppercase.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkUseUppercase.TabIndex = 37;
            this.kchkUseUppercase.Values.Text = "Use &Uppercase";
            // 
            // kbtnLoadFromFile
            // 
            this.kbtnLoadFromFile.AutoSize = true;
            this.kbtnLoadFromFile.Location = new System.Drawing.Point(13, 681);
            this.kbtnLoadFromFile.Name = "kbtnLoadFromFile";
            this.kbtnLoadFromFile.Size = new System.Drawing.Size(137, 30);
            this.kbtnLoadFromFile.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnLoadFromFile.TabIndex = 11;
            this.kbtnLoadFromFile.Values.Text = "&Load from File";
            // 
            // kbtnExport
            // 
            this.kbtnExport.AutoSize = true;
            this.kbtnExport.Enabled = false;
            this.kbtnExport.Location = new System.Drawing.Point(13, 637);
            this.kbtnExport.Name = "kbtnExport";
            this.kbtnExport.Size = new System.Drawing.Size(147, 30);
            this.kbtnExport.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnExport.TabIndex = 10;
            this.kbtnExport.Values.Text = "E&xport to File";
            // 
            // pbxColourPreviewer
            // 
            this.pbxColourPreviewer.BackColor = System.Drawing.Color.Transparent;
            this.pbxColourPreviewer.Location = new System.Drawing.Point(515, 506);
            this.pbxColourPreviewer.Name = "pbxColourPreviewer";
            this.pbxColourPreviewer.Size = new System.Drawing.Size(484, 120);
            this.pbxColourPreviewer.TabIndex = 6;
            this.pbxColourPreviewer.TabStop = false;
            // 
            // kbtnResetValues
            // 
            this.kbtnResetValues.AutoSize = true;
            this.kbtnResetValues.Enabled = false;
            this.kbtnResetValues.Location = new System.Drawing.Point(13, 593);
            this.kbtnResetValues.Name = "kbtnResetValues";
            this.kbtnResetValues.Size = new System.Drawing.Size(144, 30);
            this.kbtnResetValues.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetValues.TabIndex = 5;
            this.kbtnResetValues.Values.Text = "Re&set Values";
            // 
            // kbtnAllColoursAsRGB
            // 
            this.kbtnAllColoursAsRGB.AutoSize = true;
            this.kbtnAllColoursAsRGB.Location = new System.Drawing.Point(13, 549);
            this.kbtnAllColoursAsRGB.Name = "kbtnAllColoursAsRGB";
            this.kbtnAllColoursAsRGB.Size = new System.Drawing.Size(292, 30);
            this.kbtnAllColoursAsRGB.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnAllColoursAsRGB.TabIndex = 4;
            this.kbtnAllColoursAsRGB.Values.Text = "Get all Colour Settings as &RGB";
            this.kbtnAllColoursAsRGB.Click += new System.EventHandler(this.kbtnAllColoursAsRGB_Click);
            // 
            // kbtnAllColoursAsHex
            // 
            this.kbtnAllColoursAsHex.AutoSize = true;
            this.kbtnAllColoursAsHex.Location = new System.Drawing.Point(13, 505);
            this.kbtnAllColoursAsHex.Name = "kbtnAllColoursAsHex";
            this.kbtnAllColoursAsHex.Size = new System.Drawing.Size(292, 30);
            this.kbtnAllColoursAsHex.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnAllColoursAsHex.TabIndex = 3;
            this.kbtnAllColoursAsHex.Values.Text = "&Get all Colour Settings as Hexadecimal";
            this.kbtnAllColoursAsHex.Click += new System.EventHandler(this.kbtnAllColoursAsHex_Click);
            // 
            // klblRGBValues
            // 
            this.klblRGBValues.Location = new System.Drawing.Point(515, 13);
            this.klblRGBValues.Name = "klblRGBValues";
            this.klblRGBValues.Size = new System.Drawing.Size(484, 473);
            this.klblRGBValues.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRGBValues.TabIndex = 1;
            // 
            // klbHexValues
            // 
            this.klbHexValues.Location = new System.Drawing.Point(13, 13);
            this.klbHexValues.Name = "klbHexValues";
            this.klbHexValues.Size = new System.Drawing.Size(484, 473);
            this.klbHexValues.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbHexValues.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 729);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1011, 3);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ColourSettingsViewer
            // 
            this.ClientSize = new System.Drawing.Size(1011, 781);
            this.Controls.Add(this.pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
                ExceptionHandler.CaptureException(exc, icon: MessageBoxIcon.Error, methodSignature: Helpers.GetCurrentMethod());
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
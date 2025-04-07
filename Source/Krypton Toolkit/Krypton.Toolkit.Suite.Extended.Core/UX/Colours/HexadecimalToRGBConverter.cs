#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class HexadecimalToRGBConverter : KryptonForm
    {
        #region System
        private KryptonPanel kryptonPanel2;
        private KryptonListBox klbColours;
        private KryptonButton kbtnConvertToRGB;
        private KryptonTextBox ktxtHexValue;
        private KryptonLabel kryptonLabel5;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnExport;
        private KryptonButton kbtnLoadFromFile;
        private ContextMenuStrip ctxColourList;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem removeSelectedColourToolStripMenuItem;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonPanel1 = new();
            this.kbtnLoadFromFile = new();
            this.kbtnExport = new();
            this.kbtnOk = new();
            this.kbtnCancel = new();
            this.kryptonPanel2 = new();
            this.kbtnConvertToRGB = new();
            this.klbColours = new();
            this.ctxColourList = new(this.components);
            this.removeSelectedColourToolStripMenuItem = new();
            this.ktxtHexValue = new();
            this.kryptonLabel5 = new();
            this.kryptonBorderEdge1 = new();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel2).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.ctxColourList.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Controls.Add(this.kbtnLoadFromFile);
            this.kryptonPanel1.Controls.Add(this.kbtnExport);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new(0, 622);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new(816, 51);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnLoadFromFile
            // 
            this.kbtnLoadFromFile.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.kbtnLoadFromFile.AutoSize = true;
            this.kbtnLoadFromFile.Location = new(108, 14);
            this.kbtnLoadFromFile.Name = "kbtnLoadFromFile";
            this.kbtnLoadFromFile.Size = new(90, 25);
            this.kbtnLoadFromFile.TabIndex = 9;
            this.kbtnLoadFromFile.Values.Text = "&Load from File";
            this.kbtnLoadFromFile.Click += new(this.kbtnLoadFromFile_Click);
            // 
            // kbtnExport
            // 
            this.kbtnExport.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.kbtnExport.AutoSize = true;
            this.kbtnExport.Enabled = false;
            this.kbtnExport.Location = new(12, 14);
            this.kbtnExport.Name = "kbtnExport";
            this.kbtnExport.Size = new(90, 25);
            this.kbtnExport.TabIndex = 8;
            this.kbtnExport.Values.Text = "E&xport to File";
            this.kbtnExport.Click += new(this.kbtnExport_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.kbtnOk.AutoSize = true;
            this.kbtnOk.Location = new(618, 14);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new(90, 25);
            this.kbtnOk.TabIndex = 6;
            this.kbtnOk.Values.Text = "&Ok";
            this.kbtnOk.Click += new(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.kbtnCancel.AutoSize = true;
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new(714, 14);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new(90, 25);
            this.kbtnCancel.TabIndex = 7;
            this.kbtnCancel.Values.Text = "Ca&ncel";
            this.kbtnCancel.Click += new(this.kbtnCancel_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnConvertToRGB);
            this.kryptonPanel2.Controls.Add(this.klbColours);
            this.kryptonPanel2.Controls.Add(this.ktxtHexValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new(816, 622);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnConvertToRGB
            // 
            this.kbtnConvertToRGB.Enabled = false;
            this.kbtnConvertToRGB.Location = new(277, 577);
            this.kbtnConvertToRGB.Name = "kbtnConvertToRGB";
            this.kbtnConvertToRGB.Size = new(113, 25);
            this.kbtnConvertToRGB.TabIndex = 32;
            this.kbtnConvertToRGB.Values.Text = "&Convert to RGB";
            this.kbtnConvertToRGB.Click += new(this.kbtnConvertToRGB_Click);
            // 
            // klbColours
            // 
            this.klbColours.ContextMenuStrip = this.ctxColourList;
            this.klbColours.Location = new(12, 12);
            this.klbColours.Name = "klbColours";
            this.klbColours.Size = new(792, 549);
            this.klbColours.TabIndex = 0;
            // 
            // ctxColourList
            // 
            this.ctxColourList.Font = new("Segoe UI", 9F);
            this.ctxColourList.Items.AddRange([
                this.removeSelectedColourToolStripMenuItem
            ]);
            this.ctxColourList.Name = "ctxColourList";
            this.ctxColourList.Size = new(204, 26);
            // 
            // removeSelectedColourToolStripMenuItem
            // 
            this.removeSelectedColourToolStripMenuItem.Name = "removeSelectedColourToolStripMenuItem";
            this.removeSelectedColourToolStripMenuItem.Size = new(203, 22);
            this.removeSelectedColourToolStripMenuItem.Text = "&Remove Selected Colour";
            this.removeSelectedColourToolStripMenuItem.Click += new(this.removeSelectedColourToolStripMenuItem_Click);
            // 
            // ktxtHexValue
            // 
            this.ktxtHexValue.Location = new(117, 577);
            this.ktxtHexValue.MaxLength = 7;
            this.ktxtHexValue.Name = "ktxtHexValue";
            this.ktxtHexValue.Size = new(154, 23);
            this.ktxtHexValue.TabIndex = 31;
            this.ktxtHexValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtHexValue.TextChanged += new(this.ktxtHexValue_TextChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new(12, 577);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new(99, 20);
            this.kryptonLabel5.TabIndex = 30;
            this.kryptonLabel5.Values.Text = "Hexadecimal: #";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new(816, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // HexadecimalToRGBConverter
            // 
            this.AcceptButton = this.kbtnCancel;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new(816, 673);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HexadecimalToRGBConverter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hexadecimal to RGB Converter";
            this.Load += new(this.HexadecimalToRGBConverter_Load);
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel2).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ctxColourList.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _modified;
        private Color _targetColour = Color.Transparent;
        private System.Windows.Forms.Timer _editTimer;
        #endregion

        #region Properties
        public bool Modified
        {
            get => _modified;
            set => _modified = value;
        }
        public Color TargetColour
        {
            get => _targetColour;
            set => _targetColour = value;
        }
        #endregion

        public HexadecimalToRGBConverter()
        {
            InitializeComponent();
        }

        private void HexadecimalToRGBConverter_Load(object? sender, EventArgs e)
        {
            Modified = false;

            _editTimer = new();

            _editTimer.Interval = 250;

            _editTimer.Enabled = true;

            _editTimer.Tick += EditTimer_Tick;
        }

        private void EditTimer_Tick(object? sender, EventArgs e)
        {
            if (klbColours.Items.Count > 0)
            {
                kbtnExport.Enabled = true;
            }
            else
            {
                kbtnExport.Enabled = false;
            }
        }

        private void kbtnConvertToRGB_Click(object? sender, EventArgs e)
        {
            TargetColour = ColorTranslator.FromHtml($"#{ktxtHexValue.Text}");

            klbColours.Items.Add(ColourFormatting.FormatColourAsRGBString(TargetColour));

            TargetColour = Color.Transparent;

            Modified = true;

            ktxtHexValue.Text = "";

            kbtnConvertToRGB.Enabled = false;

            ktxtHexValue.Focus();
        }

        private void kbtnExport_Click(object? sender, EventArgs e)
        {
            CommonSaveFileDialog csfd = new();

            csfd.Filters.Add(new("Normal Text Files", ".txt"));

            if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (!File.Exists(Path.GetFullPath(csfd.FileName)))
                {
                    File.Create(csfd.FileName);
                }

                StreamWriter writer = new(csfd.FileName, true, Encoding.UTF8);

                foreach (string item in klbColours.Items)
                {
                    writer.WriteLine(item);
                }

                writer.Close();
            }

            Modified = false;
        }

        private void kbtnOk_Click(object? sender, EventArgs e)
        {
            if (Modified)
            {
                DialogResult result = KryptonMessageBox.Show("There are items that are not currently saved.\n\nSave these items now?", "Unsaved Data", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    kbtnExport.PerformClick();
                }
                else
                {
                    Hide();
                }
            }
        }

        private void kbtnCancel_Click(object? sender, EventArgs e)
        {

        }

        private void ktxtHexValue_TextChanged(object? sender, EventArgs e)
        {
            if (ktxtHexValue.Text.Length == 6)
            {
                kbtnConvertToRGB.Enabled = true;
            }
        }

        private void kbtnLoadFromFile_Click(object? sender, EventArgs e)
        {
            ArrayList fileContents = new();

            CommonOpenFileDialog cofd = new();

            cofd.Filters.Add(new("Normal Text Files", ".txt"));

            int counter = 0;

            string line;

            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                StreamReader reader = new(cofd.FileName, Encoding.UTF8);

                if (new FileInfo(cofd.FileName).Length == 0)
                {
                    KryptonMessageBox.Show($"There is no data in file: '{Path.GetFullPath(cofd.FileName)}'");
                }
                else
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        klbColours.Items.Add(line);

                        counter++;
                    }

                    Modified = true;
                }
            }
        }

        private void removeSelectedColourToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            klbColours.Items.RemoveAt(klbColours.SelectedIndex);
        }
    }
}
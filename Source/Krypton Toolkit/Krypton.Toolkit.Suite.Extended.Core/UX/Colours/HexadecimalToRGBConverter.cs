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
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class HexadecimalToRGBConverter : KryptonForm
    {
        #region System
        private KryptonPanel kryptonPanel2;
        private KryptonListBox klbColours;
        private System.Windows.Forms.Panel panel1;
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
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnConvertToRGB = new Krypton.Toolkit.KryptonButton();
            this.klbColours = new Krypton.Toolkit.KryptonListBox();
            this.ktxtHexValue = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kbtnExport = new Krypton.Toolkit.KryptonButton();
            this.kbtnLoadFromFile = new Krypton.Toolkit.KryptonButton();
            this.ctxColourList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.ctxColourList.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnLoadFromFile);
            this.kryptonPanel1.Controls.Add(this.kbtnExport);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 622);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(816, 51);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.AutoSize = true;
            this.kbtnOk.Location = new System.Drawing.Point(618, 9);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 30);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 6;
            this.kbtnOk.Values.Text = "&Ok";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.AutoSize = true;
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(714, 9);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 30);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.TabIndex = 7;
            this.kbtnCancel.Values.Text = "Ca&ncel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnConvertToRGB);
            this.kryptonPanel2.Controls.Add(this.klbColours);
            this.kryptonPanel2.Controls.Add(this.ktxtHexValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(816, 622);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnConvertToRGB
            // 
            this.kbtnConvertToRGB.AutoSize = true;
            this.kbtnConvertToRGB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnConvertToRGB.Enabled = false;
            this.kbtnConvertToRGB.Location = new System.Drawing.Point(308, 577);
            this.kbtnConvertToRGB.Name = "kbtnConvertToRGB";
            this.kbtnConvertToRGB.Size = new System.Drawing.Size(124, 30);
            this.kbtnConvertToRGB.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnConvertToRGB.TabIndex = 32;
            this.kbtnConvertToRGB.Values.Text = "&Convert to RGB";
            this.kbtnConvertToRGB.Click += new System.EventHandler(this.kbtnConvertToRGB_Click);
            // 
            // klbColours
            // 
            this.klbColours.ContextMenuStrip = this.ctxColourList;
            this.klbColours.Location = new System.Drawing.Point(12, 12);
            this.klbColours.Name = "klbColours";
            this.klbColours.Size = new System.Drawing.Size(792, 549);
            this.klbColours.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbColours.TabIndex = 0;
            // 
            // ktxtHexValue
            // 
            this.ktxtHexValue.Location = new System.Drawing.Point(148, 576);
            this.ktxtHexValue.MaxLength = 7;
            this.ktxtHexValue.Name = "ktxtHexValue";
            this.ktxtHexValue.Size = new System.Drawing.Size(154, 29);
            this.ktxtHexValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtHexValue.TabIndex = 31;
            this.ktxtHexValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtHexValue.TextChanged += new System.EventHandler(this.ktxtHexValue_TextChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(12, 577);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(130, 26);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 30;
            this.kryptonLabel5.Values.Text = "Hexadecimal: #";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 619);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 3);
            this.panel1.TabIndex = 2;
            // 
            // kbtnExport
            // 
            this.kbtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnExport.AutoSize = true;
            this.kbtnExport.Enabled = false;
            this.kbtnExport.Location = new System.Drawing.Point(12, 9);
            this.kbtnExport.Name = "kbtnExport";
            this.kbtnExport.Size = new System.Drawing.Size(147, 30);
            this.kbtnExport.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnExport.TabIndex = 8;
            this.kbtnExport.Values.Text = "E&xport to File";
            this.kbtnExport.Click += new System.EventHandler(this.kbtnExport_Click);
            // 
            // kbtnLoadFromFile
            // 
            this.kbtnLoadFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnLoadFromFile.AutoSize = true;
            this.kbtnLoadFromFile.Location = new System.Drawing.Point(165, 9);
            this.kbtnLoadFromFile.Name = "kbtnLoadFromFile";
            this.kbtnLoadFromFile.Size = new System.Drawing.Size(137, 30);
            this.kbtnLoadFromFile.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnLoadFromFile.TabIndex = 9;
            this.kbtnLoadFromFile.Values.Text = "&Load from File";
            this.kbtnLoadFromFile.Click += new System.EventHandler(this.kbtnLoadFromFile_Click);
            // 
            // ctxColourList
            // 
            this.ctxColourList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctxColourList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedColourToolStripMenuItem});
            this.ctxColourList.Name = "ctxColourList";
            this.ctxColourList.Size = new System.Drawing.Size(204, 48);
            // 
            // removeSelectedColourToolStripMenuItem
            // 
            this.removeSelectedColourToolStripMenuItem.Name = "removeSelectedColourToolStripMenuItem";
            this.removeSelectedColourToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.removeSelectedColourToolStripMenuItem.Text = "&Remove Selected Colour";
            this.removeSelectedColourToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedColourToolStripMenuItem_Click);
            // 
            // HexadecimalToRGBConverter
            // 
            this.AcceptButton = this.kbtnCancel;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(816, 673);
            this.Controls.Add(this.panel1);
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
            this.Load += new System.EventHandler(this.HexadecimalToRGBConverter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ctxColourList.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _modified;
        private Color _targetColour = Color.Transparent;
        private Timer _editTimer;
        #endregion

        #region Properties
        public bool Modified { get { return _modified; } set { _modified = value; } }
        public Color TargetColour { get { return _targetColour; } set { _targetColour = value; } }
        #endregion

        public HexadecimalToRGBConverter()
        {
            InitializeComponent();
        }

        private void HexadecimalToRGBConverter_Load(object sender, EventArgs e)
        {
            Modified = false;

            _editTimer = new Timer();

            _editTimer.Interval = 250;

            _editTimer.Enabled = true;

            _editTimer.Tick += EditTimer_Tick;
        }

        private void EditTimer_Tick(object sender, EventArgs e)
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

        private void kbtnConvertToRGB_Click(object sender, EventArgs e)
        {
            TargetColour = ColorTranslator.FromHtml($"#{ ktxtHexValue.Text }");

            klbColours.Items.Add(ColourFormatting.FormatColourAsRGBString(TargetColour));

            TargetColour = Color.Transparent;

            Modified = true;

            ktxtHexValue.Text = "";

            kbtnConvertToRGB.Enabled = false;

            ktxtHexValue.Focus();
        }

        private void kbtnExport_Click(object sender, EventArgs e)
        {
            CommonSaveFileDialog csfd = new CommonSaveFileDialog();

            csfd.Filters.Add(new CommonFileDialogFilter("Normal Text Files", ".txt"));

            if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (!File.Exists(Path.GetFullPath(csfd.FileName)))
                {
                    File.Create(csfd.FileName);
                }

                StreamWriter writer = new StreamWriter(csfd.FileName, true, Encoding.UTF8);

                foreach (string item in klbColours.Items)
                {
                    writer.WriteLine(item);
                }

                writer.Close();
            }

            Modified = false;
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            if (Modified)
            {
                DialogResult result = KryptonMessageBox.Show("There are items that are not currently saved.\n\nSave these items now?", "Unsaved Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void ktxtHexValue_TextChanged(object sender, EventArgs e)
        {
            if (ktxtHexValue.Text.Length == 6)
            {
                kbtnConvertToRGB.Enabled = true;
            }
        }

        private void kbtnLoadFromFile_Click(object sender, EventArgs e)
        {
            ArrayList fileContents = new ArrayList();

            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

            cofd.Filters.Add(new CommonFileDialogFilter("Normal Text Files", ".txt"));

            int counter = 0;

            string line;

            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                StreamReader reader = new StreamReader(cofd.FileName, Encoding.UTF8);

                if (new FileInfo(cofd.FileName).Length == 0)
                {
                    KryptonMessageBox.Show($"There is no data in file: '{ Path.GetFullPath(cofd.FileName) }'");
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

        private void removeSelectedColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            klbColours.Items.RemoveAt(klbColours.SelectedIndex);
        }
    }
}
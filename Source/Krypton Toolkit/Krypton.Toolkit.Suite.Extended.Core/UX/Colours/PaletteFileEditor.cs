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

using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

#pragma warning disable CS8602
namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class PaletteFileEditor : KryptonForm
    {
        #region Designer Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnClose = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateColours = new Krypton.Toolkit.KryptonButton();
            this.kbtnSaveFile = new Krypton.Toolkit.KryptonButton();
            this.kbtnOpenFile = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateNewFile = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.krtbFile = new Krypton.Toolkit.KryptonRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnClose);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateColours);
            this.kryptonPanel1.Controls.Add(this.kbtnSaveFile);
            this.kryptonPanel1.Controls.Add(this.kbtnOpenFile);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateNewFile);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 504);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(631, 52);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnClose
            // 
            this.kbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnClose.CornerRoundingRadius = -1F;
            this.kbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnClose.Location = new System.Drawing.Point(529, 15);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(90, 25);
            this.kbtnClose.TabIndex = 31;
            this.kbtnClose.UseAsADialogButton = true;
            this.kbtnClose.Values.Text = "Cance&l";
            // 
            // kbtnGenerateColours
            // 
            this.kbtnGenerateColours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnGenerateColours.AutoSize = true;
            this.kbtnGenerateColours.CornerRoundingRadius = -1F;
            this.kbtnGenerateColours.Location = new System.Drawing.Point(318, 15);
            this.kbtnGenerateColours.Name = "kbtnGenerateColours";
            this.kbtnGenerateColours.Size = new System.Drawing.Size(103, 25);
            this.kbtnGenerateColours.TabIndex = 30;
            this.kbtnGenerateColours.Values.Text = "Generate &Colours";
            // 
            // kbtnSaveFile
            // 
            this.kbtnSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnSaveFile.AutoSize = true;
            this.kbtnSaveFile.CornerRoundingRadius = -1F;
            this.kbtnSaveFile.Location = new System.Drawing.Point(222, 15);
            this.kbtnSaveFile.Name = "kbtnSaveFile";
            this.kbtnSaveFile.Size = new System.Drawing.Size(90, 25);
            this.kbtnSaveFile.TabIndex = 29;
            this.kbtnSaveFile.Values.Text = "S&ave File";
            // 
            // kbtnOpenFile
            // 
            this.kbtnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnOpenFile.AutoSize = true;
            this.kbtnOpenFile.CornerRoundingRadius = -1F;
            this.kbtnOpenFile.Location = new System.Drawing.Point(126, 15);
            this.kbtnOpenFile.Name = "kbtnOpenFile";
            this.kbtnOpenFile.Size = new System.Drawing.Size(90, 25);
            this.kbtnOpenFile.TabIndex = 28;
            this.kbtnOpenFile.Values.Text = "&Open File";
            // 
            // kbtnGenerateNewFile
            // 
            this.kbtnGenerateNewFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnGenerateNewFile.AutoSize = true;
            this.kbtnGenerateNewFile.CornerRoundingRadius = -1F;
            this.kbtnGenerateNewFile.Location = new System.Drawing.Point(12, 15);
            this.kbtnGenerateNewFile.Name = "kbtnGenerateNewFile";
            this.kbtnGenerateNewFile.Size = new System.Drawing.Size(108, 25);
            this.kbtnGenerateNewFile.TabIndex = 27;
            this.kbtnGenerateNewFile.Values.Text = "Generate &New File";
            this.kbtnGenerateNewFile.Click += new System.EventHandler(this.kbtnGenerateNewFile_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.krtbFile);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(631, 504);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // krtbFile
            // 
            this.krtbFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.krtbFile.Location = new System.Drawing.Point(12, 12);
            this.krtbFile.Name = "krtbFile";
            this.krtbFile.Size = new System.Drawing.Size(606, 477);
            this.krtbFile.TabIndex = 0;
            this.krtbFile.Text = "kryptonRichTextBox1";
            // 
            // PaletteFileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 556);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaletteFileEditor";
            this.Text = "PaletteFileEditor";
            this.Load += new System.EventHandler(this.PaletteFileEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnGenerateNewFile;
        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Krypton.Toolkit.KryptonButton kbtnGenerateColours;
        private Krypton.Toolkit.KryptonButton kbtnSaveFile;
        private Krypton.Toolkit.KryptonButton kbtnOpenFile;
        private KryptonButton kbtnClose;
        private KryptonRichTextBox krtbFile;

        //private AutocompleteMenuNS.AutocompleteMenu acmPalette;
        #endregion

        #region Variables
        private FileCreator _fileCreator = new();
        #endregion

        public PaletteFileEditor()
        {
            InitializeComponent();
        }

        public PaletteFileEditor(string paletteFilePath)
        {
            InitializeComponent();

            try
            {
                StreamReader reader = new StreamReader(paletteFilePath);

                string fileContents = reader.ReadToEnd();

                krtbFile.Text = fileContents;
            }
            catch (Exception error)
            {
                ExceptionCapture.CaptureException(error);
            }
        }

        private void kbtnGenerateNewFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(krtbFile.Text))
            {
                SaveFileDialog sfd = new()
                {
                    Title = @"Save palette file:",
                    Filter = @"Palette Files|*.xml"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(sfd.FileName);

                    writer.WriteAsync(krtbFile.Text);

                    writer.Close();

                    writer.Dispose();
                }
            }
            else
            {
                _fileCreator.GenerateNewFile(krtbFile);
            }
        }

        private void PaletteFileEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
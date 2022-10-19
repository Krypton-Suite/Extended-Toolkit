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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaletteFileEditor));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnGenerateColours = new Krypton.Toolkit.KryptonButton();
            this.kbtnSaveFile = new Krypton.Toolkit.KryptonButton();
            this.kbtnOpenFile = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateNewFile = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.filePane = new EasyScintilla.SimpleEditor();
            //this.acmPalette = new AutocompleteMenuNS.AutocompleteMenu();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateColours);
            this.kryptonPanel1.Controls.Add(this.kbtnSaveFile);
            this.kryptonPanel1.Controls.Add(this.kbtnOpenFile);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateNewFile);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 723);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(948, 52);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnGenerateColours
            // 
            this.kbtnGenerateColours.AutoSize = true;
            this.kbtnGenerateColours.Location = new System.Drawing.Point(531, 10);
            this.kbtnGenerateColours.Name = "kbtnGenerateColours";
            this.kbtnGenerateColours.Size = new System.Drawing.Size(167, 30);
            this.kbtnGenerateColours.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateColours.TabIndex = 30;
            this.kbtnGenerateColours.Values.Text = "Generate &Colours";
            // 
            // kbtnSaveFile
            // 
            this.kbtnSaveFile.AutoSize = true;
            this.kbtnSaveFile.Location = new System.Drawing.Point(358, 10);
            this.kbtnSaveFile.Name = "kbtnSaveFile";
            this.kbtnSaveFile.Size = new System.Drawing.Size(167, 30);
            this.kbtnSaveFile.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSaveFile.TabIndex = 29;
            this.kbtnSaveFile.Values.Text = "S&ave File";
            // 
            // kbtnOpenFile
            // 
            this.kbtnOpenFile.AutoSize = true;
            this.kbtnOpenFile.Location = new System.Drawing.Point(185, 10);
            this.kbtnOpenFile.Name = "kbtnOpenFile";
            this.kbtnOpenFile.Size = new System.Drawing.Size(167, 30);
            this.kbtnOpenFile.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOpenFile.TabIndex = 28;
            this.kbtnOpenFile.Values.Text = "&Open File";
            // 
            // kbtnGenerateNewFile
            // 
            this.kbtnGenerateNewFile.AutoSize = true;
            this.kbtnGenerateNewFile.Location = new System.Drawing.Point(12, 10);
            this.kbtnGenerateNewFile.Name = "kbtnGenerateNewFile";
            this.kbtnGenerateNewFile.Size = new System.Drawing.Size(167, 30);
            this.kbtnGenerateNewFile.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateNewFile.TabIndex = 27;
            this.kbtnGenerateNewFile.Values.Text = "Generate &New File";
            this.kbtnGenerateNewFile.Click += new System.EventHandler(this.kbtnGenerateNewFile_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.filePane);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(948, 723);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // filePane
            // 
            this.filePane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePane.FontQuality = ScintillaNET.FontQuality.AntiAliased;
            this.filePane.IndentationGuides = ScintillaNET.IndentView.LookBoth;
            this.filePane.Lexer = ScintillaNET.Lexer.Xml;
            this.filePane.Location = new System.Drawing.Point(12, 12);
            this.filePane.Name = "filePane";
            this.filePane.Size = new System.Drawing.Size(924, 695);
            this.filePane.Styler = null;
            this.filePane.TabIndex = 0;
            /*
            // 
            // acmPalette
            // 
            this.acmPalette.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("acmPalette.Colors")));
            this.acmPalette.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.acmPalette.ImageList = null;
            this.acmPalette.Items = new string[0];
            this.acmPalette.TargetControlWrapper = null;
            */
            // 
            // PaletteFileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 775);
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
        private EasyScintilla.SimpleEditor filePane;
        private Krypton.Toolkit.KryptonButton kbtnGenerateColours;
        private Krypton.Toolkit.KryptonButton kbtnSaveFile;
        private Krypton.Toolkit.KryptonButton kbtnOpenFile;
        //private AutocompleteMenuNS.AutocompleteMenu acmPalette;
        #endregion

        #region Variables
        private FileCreator _fileCreator = new FileCreator();
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

                filePane.Text = fileContents;
            }
            catch (Exception error)
            {
                ExceptionCapture.CaptureException(error);
            }
        }

        private void kbtnGenerateNewFile_Click(object sender, EventArgs e)
        {
            _fileCreator.GenerateNewFile(filePane);
        }

        private void PaletteFileEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
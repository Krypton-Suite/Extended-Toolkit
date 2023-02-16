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

namespace Krypton.Toolkit.Suite.Extended.Developer.Utilities
{
    public class KryptonDeveloperDebugConsole : KryptonForm
    {
        #region Design Code
        private KryptonButton kbtnClose;
        private KryptonButton kbtnCopy;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonRichTextBox krtbDebugBox;
        private KryptonButton kbtnSaveToFile;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new(typeof(KryptonDeveloperDebugConsole));
            this.kryptonPanel1 = new();
            this.kbtnClose = new();
            this.kbtnCopy = new();
            this.kryptonBorderEdge1 = new();
            this.kryptonPanel2 = new();
            this.krtbDebugBox = new();
            this.kbtnSaveToFile = new();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnSaveToFile);
            this.kryptonPanel1.Controls.Add(this.kbtnClose);
            this.kryptonPanel1.Controls.Add(this.kbtnCopy);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new(0, 509);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new(727, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnClose
            // 
            this.kbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnClose.Location = new(625, 13);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new(90, 25);
            this.kbtnClose.TabIndex = 2;
            this.kbtnClose.Values.Text = "&Close";
            this.kbtnClose.Click += this.kbtnClose_Click;
            // 
            // kbtnCopy
            // 
            this.kbtnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnCopy.Location = new(12, 13);
            this.kbtnCopy.Name = "kbtnCopy";
            this.kbtnCopy.Size = new(90, 25);
            this.kbtnCopy.TabIndex = 1;
            this.kbtnCopy.Values.Text = "Co&py";
            this.kbtnCopy.Click += this.kbtnCopy_Click;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new(727, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.krtbDebugBox);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new(727, 509);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // krtbDebugBox
            // 
            this.krtbDebugBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.krtbDebugBox.Location = new(13, 13);
            this.krtbDebugBox.Name = "krtbDebugBox";
            this.krtbDebugBox.ReadOnly = true;
            this.krtbDebugBox.Size = new(702, 480);
            this.krtbDebugBox.TabIndex = 0;
            this.krtbDebugBox.Text = "";
            this.krtbDebugBox.TextChanged += this.krtbDebugBox_TextChanged;
            // 
            // kbtnSaveToFile
            // 
            this.kbtnSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnSaveToFile.Location = new(108, 13);
            this.kbtnSaveToFile.Name = "kbtnSaveToFile";
            this.kbtnSaveToFile.Size = new(127, 25);
            this.kbtnSaveToFile.TabIndex = 4;
            this.kbtnSaveToFile.Values.Text = "&Save to File";
            this.kbtnSaveToFile.Click += this.kbtnSaveToFile_Click;
            // 
            // KryptonDeveloperDebugConsole
            // 
            this.ClientSize = new(727, 559);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonDeveloperDebugConsole";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debug Console";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructors
        public KryptonDeveloperDebugConsole(string message)
        {
            InitializeComponent();

            krtbDebugBox.Text = message;
        }

        public KryptonDeveloperDebugConsole(Exception exception, bool showMessageOnly = false, bool showInnerMessage = false, bool useStackTrace = false)
        {
            InitializeComponent();

            if (showMessageOnly)
            {
                krtbDebugBox.Text = exception.Message;
            }
            else if (showInnerMessage)
            {
                krtbDebugBox.Text = exception.InnerException.Message;
            }
            else if (useStackTrace)
            {
                krtbDebugBox.Text = exception.StackTrace;
            }
            else
            {
                StringBuilder builder = new();

                builder.Append($"{exception.Message}\n\n{exception.StackTrace}");

                krtbDebugBox.Text = builder.ToString();
            }
        }

        public KryptonDeveloperDebugConsole(string[] content)
        {
            InitializeComponent();

            foreach (string item in content)
            {
                krtbDebugBox.Text = item;
            }
        }
        #endregion

        private void krtbDebugBox_TextChanged(object sender, EventArgs e) => kbtnClose.Enabled = string.IsNullOrWhiteSpace(krtbDebugBox.Text);

        private void kbtnCopy_Click(object sender, EventArgs e) => Clipboard.SetText(krtbDebugBox.Text);

        private void kbtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kbtnSaveToFile_Click(object sender, EventArgs e)
        {
            CommonSaveFileDialog csfd = new();

            csfd.Filters.Add(new("Exception Captures", "txt"));

            csfd.DefaultFileName = $"Exception Capture - {DateTime.Now}";

            if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                krtbDebugBox.SaveFile(csfd.FileName);
            }
        }
    }
}
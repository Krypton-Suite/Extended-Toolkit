#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Tools;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonDeveloperDebugConsole));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnClose = new Krypton.Toolkit.KryptonButton();
            this.kbtnCopy = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.krtbDebugBox = new Krypton.Toolkit.KryptonRichTextBox();
            this.kbtnSaveToFile = new Krypton.Toolkit.KryptonButton();
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
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 509);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(727, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnClose
            // 
            this.kbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnClose.Location = new System.Drawing.Point(625, 13);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(90, 25);
            this.kbtnClose.TabIndex = 2;
            this.kbtnClose.Values.Text = "&Close";
            this.kbtnClose.Click += new System.EventHandler(this.kbtnClose_Click);
            // 
            // kbtnCopy
            // 
            this.kbtnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnCopy.Location = new System.Drawing.Point(12, 13);
            this.kbtnCopy.Name = "kbtnCopy";
            this.kbtnCopy.Size = new System.Drawing.Size(90, 25);
            this.kbtnCopy.TabIndex = 1;
            this.kbtnCopy.Values.Text = "Co&py";
            this.kbtnCopy.Click += new System.EventHandler(this.kbtnCopy_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(727, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.krtbDebugBox);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(727, 509);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // krtbDebugBox
            // 
            this.krtbDebugBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.krtbDebugBox.Location = new System.Drawing.Point(13, 13);
            this.krtbDebugBox.Name = "krtbDebugBox";
            this.krtbDebugBox.ReadOnly = true;
            this.krtbDebugBox.Size = new System.Drawing.Size(702, 480);
            this.krtbDebugBox.TabIndex = 0;
            this.krtbDebugBox.Text = "";
            this.krtbDebugBox.TextChanged += new System.EventHandler(this.krtbDebugBox_TextChanged);
            // 
            // kbtnSaveToFile
            // 
            this.kbtnSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnSaveToFile.Location = new System.Drawing.Point(108, 13);
            this.kbtnSaveToFile.Name = "kbtnSaveToFile";
            this.kbtnSaveToFile.Size = new System.Drawing.Size(127, 25);
            this.kbtnSaveToFile.TabIndex = 4;
            this.kbtnSaveToFile.Values.Text = "&Save to File";
            this.kbtnSaveToFile.Click += new System.EventHandler(this.kbtnSaveToFile_Click);
            // 
            // KryptonDeveloperDebugConsole
            // 
            this.ClientSize = new System.Drawing.Size(727, 559);
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
                StringBuilder builder = new StringBuilder();

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

        private void krtbDebugBox_TextChanged(object sender, EventArgs e) => kbtnClose.Enabled = MissingFrameWorkAPIs.IsNullOrWhiteSpace(krtbDebugBox.Text);

        private void kbtnCopy_Click(object sender, EventArgs e) => Clipboard.SetText(krtbDebugBox.Text);

        private void kbtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kbtnSaveToFile_Click(object sender, EventArgs e)
        {
            CommonSaveFileDialog csfd = new CommonSaveFileDialog();

            csfd.Filters.Add(new CommonFileDialogFilter("Exception Captures", "txt"));

            csfd.DefaultFileName = $"Exception Capture - {DateTime.Now}";

            if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                krtbDebugBox.SaveFile(csfd.FileName);
            }
        }
    }
}
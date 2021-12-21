#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Tools;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// A window that allows the developer to capture an exception, and present it in a window.
    /// </summary>
    public class KryptonExceptionCaptureDialog : KryptonForm
    {
        #region Design Code
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnExportException;
        private KryptonCheckBox kchkDarkMode;
        private KryptonTextBox ktxtException;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnExportException = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kchkDarkMode = new Krypton.Toolkit.KryptonCheckBox();
            this.ktxtException = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kchkDarkMode);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnExportException);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 417);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(549, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(447, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kbtnExportException
            // 
            this.kbtnExportException.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnExportException.Location = new System.Drawing.Point(13, 13);
            this.kbtnExportException.Name = "kbtnExportException";
            this.kbtnExportException.Size = new System.Drawing.Size(119, 25);
            this.kbtnExportException.TabIndex = 1;
            this.kbtnExportException.Values.Text = "Export &Exception";
            this.kbtnExportException.Click += new System.EventHandler(this.kbtnExportException_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(549, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtException);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(549, 417);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kchkDarkMode
            // 
            this.kchkDarkMode.Location = new System.Drawing.Point(139, 17);
            this.kchkDarkMode.Name = "kchkDarkMode";
            this.kchkDarkMode.Size = new System.Drawing.Size(84, 20);
            this.kchkDarkMode.TabIndex = 4;
            this.kchkDarkMode.Values.Text = "D&ark Mode";
            this.kchkDarkMode.CheckedChanged += new System.EventHandler(this.kchkDarkMode_CheckedChanged);
            // 
            // ktxtException
            // 
            this.ktxtException.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktxtException.Location = new System.Drawing.Point(12, 12);
            this.ktxtException.Multiline = true;
            this.ktxtException.Name = "ktxtException";
            this.ktxtException.ReadOnly = true;
            this.ktxtException.Size = new System.Drawing.Size(525, 395);
            this.ktxtException.TabIndex = 0;
            // 
            // KryptonExceptionCaptureDialog
            // 
            this.ClientSize = new System.Drawing.Size(549, 467);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonExceptionCaptureDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Fields
        private Exception _exception;
        #endregion

        #region Properties
        public Exception Exception { get => _exception; set => _exception = value; }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="KryptonExceptionCaptureDialog" /> class.</summary>
        /// <param name="exception">The exception.</param>
        /// <param name="titleText">The title text.</param>
        /// <param name="showDate">if set to <c>true</c> [show date].</param>
        /// <param name="darkMode">if set to <c>true</c> [dark mode].</param>
        public KryptonExceptionCaptureDialog(Exception exception, string titleText = "Exception Capture", bool showDate = false, bool darkMode = false)
        {
            InitializeComponent();

            Exception = exception;

            ToggleDarkMode(darkMode);

            SetupTitle(titleText, showDate);

            CaptureException(Exception);
        }
        #endregion

        #region Methods
        /// <summary>Captures the exception.</summary>
        /// <param name="exception">The exception.</param>
        /// <param name="showMessageOnly">if set to <c>true</c> [show message only].</param>
        /// <param name="showStackTrace">if set to <c>true</c> [show stack trace].</param>
        /// <param name="showInnerException">if set to <c>true</c> [show inner exception].</param>
        /// <param name="showFullDetails">if set to <c>true</c> [show full details].</param>
        private void CaptureException(Exception exception, bool showMessageOnly = true,
                                      bool showStackTrace = false, bool showInnerException = false,
                                      bool showFullDetails = false)
        {
            if (showMessageOnly)
            {
                ktxtException.Text = exception.Message;
            }
            else if (showStackTrace)
            {
                ktxtException.Text = exception.StackTrace;
            }
            else if (showInnerException)
            {
                ktxtException.Text = exception.InnerException.ToString();
            }

            if (showFullDetails)
            {
                StringBuilder builder = new StringBuilder();

                builder.Append($"{exception.Message}\n{exception.StackTrace}");

                ktxtException.Text = builder.ToString();
            }
        }

        /// <summary>Setups the title.</summary>
        /// <param name="text">The text.</param>
        /// <param name="showDate">if set to <c>true</c> [show date].</param>
        private void SetupTitle(string text, bool showDate = false)
        {
            if (showDate)
            {
                Text = $"{text} - {DateTime.Now}";
            }
            else
            {
                Text = $"{text}";
            }
        }

        // TODO: Rewrite once build 2108 is out
        private void ToggleDarkMode(bool darkMode)
        {
            ThemeSettingsManager theme = new ThemeSettingsManager();

            if (darkMode)
            {
                PaletteMode = theme.GetDarkModeThemePaletteMode();

                kchkDarkMode.Text = "&Light Mode";
            }
            else
            {
                PaletteMode = theme.GetLightModeThemePaletteMode();

                kchkDarkMode.Text = "D&ark Mode";
            }
        }
        #endregion

        private void kbtnExportException_Click(object sender, EventArgs e)
        {
            if (MissingFrameWorkAPIs.IsNullOrWhiteSpace(ktxtException.Text))
            {
                KryptonMessageBox.Show("No content was found!", "Save Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SaveFileDialog csfd = new SaveFileDialog();

                csfd.FileName = "Exception Capture";

                csfd.Filter = "Text Files|*.txt";

                if (csfd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(Path.GetFullPath(csfd.FileName));

                    writer.Write(ktxtException.Text);

                    writer.Flush();

                    writer.Close();

                    writer.Dispose();

                    DialogResult result = KryptonMessageBox.Show($"The exception has been written to file: '{Path.GetFullPath(csfd.FileName)}'.\nDo you want to view it now?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        Process.Start("notepad.exe", Path.GetFullPath(csfd.FileName));
                    }
                }
            }
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kchkDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            ToggleDarkMode(kchkDarkMode.Checked);
        }
    }
}

#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Specialised.Dialogs
{
    public class KryptonRunDialog : CommonExtendedKryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnRun;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnBrowse;
        private KryptonPanel kryptonPanel2;
        private KryptonWrapLabel kwlMessage;
        private KryptonComboBox kcmbOpenBox;
        private KryptonLabel klblOpen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsRunBox;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryToolStripMenuItem;
        private KryptonUACButton kuacbtnRun;
        private KryptonButton kbtnLocate;
        private PictureBox pbxInputIcon;
        private KryptonTextBox ktxtOpenBox;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonRunDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnLocate = new Krypton.Toolkit.KryptonButton();
            this.kuacbtnRun = new Krypton.Toolkit.Suite.Extended.Specialised.Dialogs.KryptonUACButton();
            this.kbtnRun = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnBrowse = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kwlMessage = new Krypton.Toolkit.KryptonWrapLabel();
            this.kcmbOpenBox = new Krypton.Toolkit.KryptonComboBox();
            this.cmsRunBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klblOpen = new Krypton.Toolkit.KryptonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbxInputIcon = new System.Windows.Forms.PictureBox();
            this.ktxtOpenBox = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbOpenBox)).BeginInit();
            this.cmsRunBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInputIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnLocate);
            this.kryptonPanel1.Controls.Add(this.kuacbtnRun);
            this.kryptonPanel1.Controls.Add(this.kbtnRun);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnBrowse);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 117);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(419, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnLocate
            // 
            this.kbtnLocate.Location = new System.Drawing.Point(12, 14);
            this.kbtnLocate.Name = "kbtnLocate";
            this.kbtnLocate.Size = new System.Drawing.Size(90, 25);
            this.kbtnLocate.TabIndex = 5;
            this.kbtnLocate.Values.Text = "Lo&cate";
            this.kbtnLocate.Click += new System.EventHandler(this.kbtnLocate_Click);
            // 
            // kuacbtnRun
            // 
            this.kuacbtnRun.AssemblyToElevate = null;
            this.kuacbtnRun.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kuacbtnRun.Enabled = false;
            this.kuacbtnRun.Location = new System.Drawing.Point(125, 13);
            this.kuacbtnRun.Name = "kuacbtnRun";
            this.kuacbtnRun.Size = new System.Drawing.Size(90, 26);
            this.kuacbtnRun.TabIndex = 3;
            this.kuacbtnRun.Values.Image = ((System.Drawing.Image)(resources.GetObject("kuacbtnRun.Values.Image")));
            this.kuacbtnRun.Values.Text = "&Run";
            this.kuacbtnRun.ExecuteProcessAsAdministrator += new Krypton.Toolkit.Suite.Extended.Specialised.Dialogs.KryptonUACButton.ExecuteProcessAsAdministratorEventHandler(this.kuacbtnRun_ExecuteProcessAsAdministrator);
            // 
            // kbtnRun
            // 
            this.kbtnRun.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnRun.Enabled = false;
            this.kbtnRun.Location = new System.Drawing.Point(125, 13);
            this.kbtnRun.Name = "kbtnRun";
            this.kbtnRun.Size = new System.Drawing.Size(90, 25);
            this.kbtnRun.TabIndex = 3;
            this.kbtnRun.Values.Text = "&Run";
            this.kbtnRun.Click += new System.EventHandler(this.kbtnRun_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(221, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kbtnBrowse
            // 
            this.kbtnBrowse.Location = new System.Drawing.Point(317, 13);
            this.kbtnBrowse.Name = "kbtnBrowse";
            this.kbtnBrowse.Size = new System.Drawing.Size(90, 25);
            this.kbtnBrowse.TabIndex = 1;
            this.kbtnBrowse.Values.Text = "B&rowse...";
            this.kbtnBrowse.Click += new System.EventHandler(this.kbtnBrowse_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(419, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtOpenBox);
            this.kryptonPanel2.Controls.Add(this.pbxInputIcon);
            this.kryptonPanel2.Controls.Add(this.kwlMessage);
            this.kryptonPanel2.Controls.Add(this.kcmbOpenBox);
            this.kryptonPanel2.Controls.Add(this.klblOpen);
            this.kryptonPanel2.Controls.Add(this.pictureBox1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(419, 117);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kwlMessage
            // 
            this.kwlMessage.AutoSize = false;
            this.kwlMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.kwlMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlMessage.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kwlMessage.Location = new System.Drawing.Point(83, 12);
            this.kwlMessage.Name = "kwlMessage";
            this.kwlMessage.Size = new System.Drawing.Size(324, 64);
            this.kwlMessage.Text = "Type the name of a program, folder, document or Internet resource, and Windows wi" +
    "ll open it for you.";
            this.kwlMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kcmbOpenBox
            // 
            this.kcmbOpenBox.ContextMenuStrip = this.cmsRunBox;
            this.kcmbOpenBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbOpenBox.DropDownWidth = 309;
            this.kcmbOpenBox.IntegralHeight = false;
            this.kcmbOpenBox.Location = new System.Drawing.Point(62, 83);
            this.kcmbOpenBox.Name = "kcmbOpenBox";
            this.kcmbOpenBox.Size = new System.Drawing.Size(307, 21);
            this.kcmbOpenBox.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbOpenBox.TabIndex = 2;
            // 
            // cmsRunBox
            // 
            this.cmsRunBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsRunBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.selectAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem3,
            this.clearHistoryToolStripMenuItem});
            this.cmsRunBox.Name = "cmsRunBox";
            this.cmsRunBox.Size = new System.Drawing.Size(143, 154);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.cutToolStripMenuItem.Text = "&Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.copyToolStripMenuItem.Text = "Co&py";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.pasteToolStripMenuItem.Text = "P&aste";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(139, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.selectAllToolStripMenuItem.Text = "&Select All";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(139, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(139, 6);
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.clearHistoryToolStripMenuItem.Text = "Clear &History";
            // 
            // klblOpen
            // 
            this.klblOpen.Location = new System.Drawing.Point(12, 83);
            this.klblOpen.Name = "klblOpen";
            this.klblOpen.Size = new System.Drawing.Size(43, 20);
            this.klblOpen.TabIndex = 1;
            this.klblOpen.Values.Text = "O&pen:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Krypton.Toolkit.Suite.Extended.Specialised.Dialogs.Properties.Resources.Run1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pbxInputIcon
            // 
            this.pbxInputIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxInputIcon.Location = new System.Drawing.Point(375, 79);
            this.pbxInputIcon.Name = "pbxInputIcon";
            this.pbxInputIcon.Size = new System.Drawing.Size(32, 32);
            this.pbxInputIcon.TabIndex = 3;
            this.pbxInputIcon.TabStop = false;
            // 
            // ktxtOpenBox
            // 
            this.ktxtOpenBox.ContextMenuStrip = this.cmsRunBox;
            this.ktxtOpenBox.Hint = "Type a path to launch...";
            this.ktxtOpenBox.Location = new System.Drawing.Point(62, 83);
            this.ktxtOpenBox.Name = "ktxtOpenBox";
            this.ktxtOpenBox.Size = new System.Drawing.Size(307, 23);
            this.ktxtOpenBox.TabIndex = 2;
            // 
            // KryptonRunDialog
            // 
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(419, 167);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonRunDialog";
            this.Text = "Run";
            this.Load += new System.EventHandler(this.KryptonRunDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbOpenBox)).EndInit();
            this.cmsRunBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInputIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private RunDialogIconVisibility _iconVisibility;
        #endregion

        #region Properties
        [DefaultValue(typeof(RunDialogIconVisibility), "RunDialogIconVisibility.VISIBLE"), Description("Shows the icon representation of the file, application etc in the text field.")]
        public RunDialogIconVisibility IconVisibility { get => _iconVisibility; set { _iconVisibility = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonRunDialog(bool showUACRunButton = false, bool showLocateButton = false, string message = "Type the name of a program, folder, document or Internet resource, and Windows will open it for you.",
                                RunDialogType type = RunDialogType.COMBOBOX, RunDialogIconVisibility iconVisibility = RunDialogIconVisibility.VISIBLE,
                                string openText = "O&pen", string locateText = "L&ocate", string runUACText = "&Run", string runText = "&Run",
                                string browseText = "Br&owse", string cancelText = "C&ancel")
        {
            InitializeComponent();

            kbtnLocate.Visible = showLocateButton;

            AdaptUI(type, iconVisibility);

            UpdateUIText(message, openText, locateText, runUACText, runText, browseText, cancelText);

            if (showUACRunButton)
            {
                kbtnRun.Visible = false;

                kuacbtnRun.Visible = true;

                AcceptButton = kuacbtnRun;
            }
            else
            {
                kbtnRun.Visible = true;

                kuacbtnRun.Visible = false;

                AcceptButton = kbtnRun;
            }
        }
        #endregion

        #region Methods
        private void UpdateUIText(string headerText, string openText, string locateText, string runUACText, string runText, string browseText, string cancelText)
        {
            kwlMessage.Text = headerText;

            klblOpen.Text = openText;

            kbtnLocate.Text = locateText;

            kuacbtnRun.Text = runUACText;

            kbtnRun.Text = runText;

            kbtnBrowse.Text = browseText;

            kbtnCancel.Text = cancelText;
        }

        private void BrowseForFile()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog() { Title = "Select a resource:" };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    kcmbOpenBox.Text = Path.GetFullPath(openFileDialog.FileName);
                }
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }
        }

        /// <summary>Determines whether [has file extension] [the specified path].</summary>
        /// <param name="path">The file path.</param>
        /// <returns><c>true</c> if [has file extension] [the specified path]; otherwise, <c>false</c>.</returns>
        private bool HasFileExtension(string path) => Path.HasExtension(path);

        /// <summary>Determines whether [is ComboBox string empty].</summary>
        /// <returns><c>true</c> if [is ComboBox string empty]; otherwise, <c>false</c>.</returns>
        private bool IsComboBoxStringEmpty() => string.IsNullOrEmpty(kcmbOpenBox.Text);

        /// <summary>Determines whether [is input a directory] [the specified input].</summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if [is input a directory] [the specified input]; otherwise, <c>false</c>.</returns>
        private bool IsInputADirectory(Control input) => input.Text.EndsWith("\\");

        /// <summary>Runs the process.</summary>
        /// <param name="path">The file path.</param>
        private void RunProcess(string path)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(path);

                Process.Start(psi);

                Close();
            }
            catch (Exception exc)
            {
                ExceptionCapture.CaptureException(exc);
            }
        }

        /// <summary>Gets the application icon.</summary>
        /// <param name="path">The file path.</param>
        /// <returns>The application icon.</returns>
        private Image GetApplicationIcon(string path) => Icon.ExtractAssociatedIcon(path).ToBitmap();

        /// <summary>Locates the process.</summary>
        /// <param name="path">The file path.</param>
        private void LocateProcess(string path) => Process.Start("explorer.exe", path);

        /// <summary>Enables the run button.</summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void EnableRunButton(bool value) => kbtnRun.Enabled = value;

        /// <summary>Enables the locate button.</summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void EnableLocateButton(bool value) => kbtnLocate.Enabled = value;

        /// <summary>Adapts the UI.</summary>
        /// <param name="type">The input type.</param>
        /// <param name="iconVisibility">The icon visibility.</param>
        public void AdaptUI(RunDialogType type, RunDialogIconVisibility iconVisibility)
        {
            switch (type)
            {
                case RunDialogType.COMBOBOX:
                    switch (iconVisibility)
                    {
                        case RunDialogIconVisibility.HIDDEN:
                            pbxInputIcon.Visible = false;

                            kcmbOpenBox.Visible = true;

                            ktxtOpenBox.Visible = false;

                            kcmbOpenBox.Size = new Size(345, 25);

                            break;
                        case RunDialogIconVisibility.VISIBLE:
                            pbxInputIcon.Visible = true;

                            kcmbOpenBox.Visible = true;

                            ktxtOpenBox.Visible = false;

                            kcmbOpenBox.Size = new Size(307, 25);
                            break;

                    }
                    break;
                case RunDialogType.TEXTBOX:
                    switch (iconVisibility)
                    {
                        case RunDialogIconVisibility.HIDDEN:
                            pbxInputIcon.Visible = false;

                            ktxtOpenBox.Visible = true;

                            kcmbOpenBox.Visible = false;

                            ktxtOpenBox.Size = new Size(345, 25);
                            break;
                        case RunDialogIconVisibility.VISIBLE:
                            pbxInputIcon.Visible = true;

                            ktxtOpenBox.Visible = true;

                            kcmbOpenBox.Visible = false;

                            ktxtOpenBox.Size = new Size(307, 25);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void KryptonRunDialog_Load(object sender, EventArgs e)
        {

        }

        private void kbtnRun_Click(object sender, EventArgs e)
        {
            RunProcess(kcmbOpenBox.Text);

            Hide();
        }

        private void kuacbtnRun_ExecuteProcessAsAdministrator(object sender, ExecuteProcessAsAdministratorEventArgs e)
        {
            e.ElevateProcessWithAdministrativeRights(kcmbOpenBox.Text);

            Hide();
        }

        private void kbtnLocate_Click(object sender, EventArgs e) => LocateProcess(kcmbOpenBox.Text);

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void kbtnBrowse_Click(object sender, EventArgs e) => BrowseForFile();
    }
}
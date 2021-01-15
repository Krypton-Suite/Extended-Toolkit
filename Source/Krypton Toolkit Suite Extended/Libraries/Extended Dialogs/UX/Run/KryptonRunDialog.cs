#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Base;
using Krypton.Toolkit.Suite.Extended.Common;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonRunDialog : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnLocate;
        private KryptonButton kbtnBrowse;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel1;
        private KryptonCancelDialogButton kdbtnCancel;
        private KryptonWrapLabel kryptonWrapLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private KryptonComboBox kcmbPath;
        private KryptonLabel kryptonLabel1;
        private System.Windows.Forms.PictureBox pbxInputIcon;
        private KryptonTextBox ktxtPath;
        private Base.KryptonUACElevatedButton kuacbtnRun;
        private KryptonOKDialogButton kdbRun;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonRunDialog));
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnLocate = new Krypton.Toolkit.KryptonButton();
            this.kbtnBrowse = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.ktxtPath = new Krypton.Toolkit.KryptonTextBox();
            this.pbxInputIcon = new System.Windows.Forms.PictureBox();
            this.kcmbPath = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonWrapLabel1 = new Krypton.Toolkit.KryptonWrapLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kuacbtnRun = new Krypton.Toolkit.Suite.Extended.Base.KryptonUACElevatedButton();
            this.kdbtnCancel = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonCancelDialogButton();
            this.kdbRun = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonOKDialogButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInputIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kuacbtnRun);
            this.kryptonPanel2.Controls.Add(this.kdbtnCancel);
            this.kryptonPanel2.Controls.Add(this.kbtnLocate);
            this.kryptonPanel2.Controls.Add(this.kbtnBrowse);
            this.kryptonPanel2.Controls.Add(this.kdbRun);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 262);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(637, 44);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnLocate
            // 
            this.kbtnLocate.Location = new System.Drawing.Point(12, 7);
            this.kbtnLocate.Name = "kbtnLocate";
            this.kbtnLocate.Size = new System.Drawing.Size(83, 25);
            this.kbtnLocate.TabIndex = 4;
            this.kbtnLocate.Values.Text = "Loc&ate...";
            this.kbtnLocate.Visible = false;
            this.kbtnLocate.Click += new System.EventHandler(this.kbtnLocate_Click);
            // 
            // kbtnBrowse
            // 
            this.kbtnBrowse.Location = new System.Drawing.Point(541, 7);
            this.kbtnBrowse.Name = "kbtnBrowse";
            this.kbtnBrowse.Size = new System.Drawing.Size(84, 25);
            this.kbtnBrowse.TabIndex = 3;
            this.kbtnBrowse.Values.Text = "Br&owse...";
            this.kbtnBrowse.Click += new System.EventHandler(this.kbtnBrowse_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 259);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 3);
            this.panel1.TabIndex = 2;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.ktxtPath);
            this.kryptonPanel1.Controls.Add(this.pbxInputIcon);
            this.kryptonPanel1.Controls.Add(this.kcmbPath);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonWrapLabel1);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(637, 259);
            this.kryptonPanel1.TabIndex = 3;
            // 
            // ktxtPath
            // 
            this.ktxtPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ktxtPath.Hint = "Type a path to a application, file/directory or website here...";
            this.ktxtPath.Location = new System.Drawing.Point(67, 197);
            this.ktxtPath.Name = "ktxtPath";
            this.ktxtPath.Size = new System.Drawing.Size(520, 24);
            this.ktxtPath.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtPath.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtPath.TabIndex = 4;
            this.ktxtPath.TextChanged += new System.EventHandler(this.ktxtPath_TextChanged);
            // 
            // pbxInputIcon
            // 
            this.pbxInputIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxInputIcon.Location = new System.Drawing.Point(593, 195);
            this.pbxInputIcon.Name = "pbxInputIcon";
            this.pbxInputIcon.Size = new System.Drawing.Size(32, 32);
            this.pbxInputIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxInputIcon.TabIndex = 8;
            this.pbxInputIcon.TabStop = false;
            // 
            // kcmbPath
            // 
            this.kcmbPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.kcmbPath.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbPath.DropDownWidth = 520;
            this.kcmbPath.IntegralHeight = false;
            this.kcmbPath.Location = new System.Drawing.Point(67, 201);
            this.kcmbPath.Name = "kcmbPath";
            this.kcmbPath.Size = new System.Drawing.Size(520, 22);
            this.kcmbPath.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbPath.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbPath.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbPath.TabIndex = 5;
            this.kcmbPath.TextChanged += new System.EventHandler(this.kcmbPath_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 201);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(49, 21);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Path:";
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.AutoSize = false;
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(67, 25);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(558, 148);
            this.kryptonWrapLabel1.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonWrapLabel1.Text = "Type the name of a application, file, directory or internet\r\nresource, and Window" +
    "s will open it for you.";
            this.kryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Krypton.Toolkit.Suite.Extended.Dialogs.Properties.Resources.Run_48_x_48;
            this.pictureBox1.Location = new System.Drawing.Point(12, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // kuacbtnRun
            // 
            this.kuacbtnRun.Location = new System.Drawing.Point(349, 7);
            this.kuacbtnRun.Name = "kuacbtnRun";
            this.kuacbtnRun.ProcessToElevate = null;
            this.kuacbtnRun.ShowUACShield = true;
            this.kuacbtnRun.Size = new System.Drawing.Size(90, 26);
            this.kuacbtnRun.TabIndex = 4;
            this.kuacbtnRun.Values.Text = "&Run";
            this.kuacbtnRun.ExecuteProcessAsAdministrator += new Krypton.Toolkit.Suite.Extended.Base.KryptonUACElevatedButton.ExecuteProcessAsAdministratorEventHandler(this.kuacbtnRun_ExecuteProcessAsAdministrator);
            // 
            // kdbtnCancel
            // 
            this.kdbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kdbtnCancel.Location = new System.Drawing.Point(445, 7);
            this.kdbtnCancel.Name = "kdbtnCancel";
            this.kdbtnCancel.ParentWindow = null;
            this.kdbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kdbtnCancel.TabIndex = 4;
            this.kdbtnCancel.Values.Text = "C&ancel";
            this.kdbtnCancel.Click += new System.EventHandler(this.kdbtnCancel_Click);
            // 
            // kdbRun
            // 
            this.kdbRun.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kdbRun.Enabled = false;
            this.kdbRun.Location = new System.Drawing.Point(349, 7);
            this.kdbRun.Name = "kdbRun";
            this.kdbRun.ParentWindow = null;
            this.kdbRun.Size = new System.Drawing.Size(90, 25);
            this.kdbRun.TabIndex = 2;
            this.kdbRun.Values.Text = "&Run";
            this.kdbRun.Click += new System.EventHandler(this.kdbRun_Click);
            // 
            // KryptonRunDialog
            // 
            this.ClientSize = new System.Drawing.Size(637, 306);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonRunDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Run";
            this.Load += new System.EventHandler(this.KryptonRunDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInputIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _showUACRunButton;

        private RunDialogType _type;

        private RunDialogIconVisibility _iconVisibility;
        #endregion

        #region Properties        
        /// <summary>Shows the run button as a <see cref="KryptonUACElevatedButton"/> style button instead of a <see cref="KryptonButton"/>.</summary>
        /// <value>
        ///   <c>true</c> if [show uac run button]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), Description("Shows the run button as a UAC style button.")]
        public bool ShowUACRunButton { get => _showUACRunButton; set { _showUACRunButton = value; Invalidate(); } }

        [DefaultValue(1), Description("Shows the icon representation of the file, application etc in the text field.")]
        public RunDialogIconVisibility IconVisibility { get => _iconVisibility; set { _iconVisibility = value; Invalidate(); } }

        public RunDialogType DialogType { get => _type; set { _type = value; Invalidate(); } }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="KryptonRunDialog"/> class.</summary>
        /// <param name="type">The input type.</param>
        /// <param name="iconVisibility">The icon visibility.</param>
        /// <param name="showUACRunButton"></param>
        public KryptonRunDialog(RunDialogType type = RunDialogType.TEXTBOX, RunDialogIconVisibility iconVisibility = RunDialogIconVisibility.VISIBLE, bool showUACRunButton = false)
        {
            InitializeComponent();

            ShowUACRunButton = showUACRunButton;

            IconVisibility = iconVisibility;

            DialogType = type;

            SetShowUACRunButton(showUACRunButton);

            SetDialogType(type);

            SetIconVisibility(iconVisibility);

            AdaptUI(type, iconVisibility);
        }
        #endregion

        #region Methods
        /// <summary>Determines whether [has file extension] [the specified path].</summary>
        /// <param name="path">The file path.</param>
        /// <returns><c>true</c> if [has file extension] [the specified path]; otherwise, <c>false</c>.</returns>
        private bool HasFileExtension(string path) => Path.HasExtension(path);

        /// <summary>Determines whether [is text box string empty].</summary>
        /// <returns><c>true</c> if [is text box string empty]; otherwise, <c>false</c>.</returns>
        private bool IsTextBoxStringEmpty() => string.IsNullOrEmpty(ktxtPath.Text);

        /// <summary>Determines whether [is ComboBox string empty].</summary>
        /// <returns><c>true</c> if [is ComboBox string empty]; otherwise, <c>false</c>.</returns>
        private bool IsComboBoxStringEmpty() => string.IsNullOrEmpty(kcmbPath.Text);

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
                ExceptionHandler.CaptureException(exc);
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
        private void EnableRunButton(bool value) => kdbRun.Enabled = value;

        /// <summary>Enables the locate button.</summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void EnableLocateButton(bool value) => kbtnLocate.Enabled = value;

        /// <summary>Adapts the UI.</summary>
        /// <param name="type">The input type.</param>
        /// <param name="iconVisibility">The icon visibility.</param>
        public void AdaptUI(RunDialogType type, RunDialogIconVisibility iconVisibility)
        {
            switch (iconVisibility)
            {
                case RunDialogIconVisibility.HIDDEN:
                    pbxInputIcon.Visible = false;

                    switch (type)
                    {
                        case RunDialogType.COMBOBOX:
                            kcmbPath.Visible = true;

                            kcmbPath.Size = new Size(558, 25);

                            ktxtPath.Visible = false;
                            break;
                        case RunDialogType.TEXTBOX:
                            kcmbPath.Visible = false;

                            ktxtPath.Visible = true;

                            ktxtPath.Size = new Size(558, 25);
                            break;
                    }
                    break;
                case RunDialogIconVisibility.VISIBLE:
                    pbxInputIcon.Visible = true;

                    switch (type)
                    {
                        case RunDialogType.COMBOBOX:
                            kcmbPath.Visible = true;

                            kcmbPath.Size = new Size(520, 25);

                            ktxtPath.Visible = false;
                            break;
                        case RunDialogType.TEXTBOX:
                            kcmbPath.Visible = false;

                            ktxtPath.Visible = true;

                            ktxtPath.Size = new Size(520, 25);
                            break;
                    }
                    break;

            }
        }
        #endregion

        #region Setters/Getters
        /// <summary>
        /// Sets the DialogType.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetDialogType(RunDialogType value) => DialogType = value;

        /// <summary>
        /// Gets the DialogType.
        /// </summary>
        /// <returns>The value of DialogType.</returns>
        public RunDialogType GetDialogType() => DialogType;

        /// <summary>
        /// Sets the IconVisibility.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetIconVisibility(RunDialogIconVisibility value) => _iconVisibility = value;

        /// <summary>
        /// Gets the IconVisibility.
        /// </summary>
        /// <returns>The value of IconVisibility.</returns>
        public RunDialogIconVisibility GetIconVisibility() => _iconVisibility;

        /// <summary>Shows the UAC run button.</summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public void SetShowUACRunButton(bool value) => ShowUACRunButton = value;

        /// <summary>Shows the UAC run button.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool GetShowUACRunButton() => ShowUACRunButton;
        #endregion

        #region Event Handlers
        private void KryptonRunDialog_Load(object sender, EventArgs e)
        {

        }

        private void kbtnBrowse_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

            cofd.Title = "Browse for a Process:";

            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (GetDialogType() == RunDialogType.COMBOBOX)
                {
                    kcmbPath.Text = Path.GetFullPath(cofd.FileName);

                    pbxInputIcon.Image = GetApplicationIcon(kcmbPath.Text);
                }
                else if (GetDialogType() == RunDialogType.TEXTBOX)
                {
                    ktxtPath.Text = Path.GetFullPath(cofd.FileName);

                    pbxInputIcon.Image = GetApplicationIcon(ktxtPath.Text);
                }
            }
        }

        private void kdbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kdbRun_Click(object sender, EventArgs e)
        {
            if (GetDialogType() == RunDialogType.COMBOBOX)
            {
                RunProcess(kcmbPath.Text);
            }
            else if (GetDialogType() == RunDialogType.TEXTBOX)
            {
                RunProcess(ktxtPath.Text);
            }
        }

        private void kbtnLocate_Click(object sender, EventArgs e)
        {
            if (GetDialogType() == RunDialogType.COMBOBOX)
            {
                LocateProcess(kcmbPath.Text);
            }
            else if (GetDialogType() == RunDialogType.TEXTBOX)
            {
                LocateProcess(ktxtPath.Text);
            }
        }

        private void ktxtPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void kcmbPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void kuacbtnRun_ExecuteProcessAsAdministrator(object sender, ExecuteProcessAsAdministratorEventArgs e)
        {
            if (GetDialogType() == RunDialogType.COMBOBOX)
            {
                RunProcess(kcmbPath.Text);
            }
            else if (GetDialogType() == RunDialogType.TEXTBOX)
            {
                RunProcess(ktxtPath.Text);
            }
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            if (ShowUACRunButton)
            {
                kuacbtnRun.Visible = true;

                AcceptButton = kuacbtnRun;

                kdbRun.Visible = false;
            }
            else
            {
                kdbRun.Visible = true;

                AcceptButton = kdbRun;

                kuacbtnRun.Visible = false;
            }

            AdaptUI(DialogType, IconVisibility);

            base.OnPaint(e);
        }
        #endregion
    }
}
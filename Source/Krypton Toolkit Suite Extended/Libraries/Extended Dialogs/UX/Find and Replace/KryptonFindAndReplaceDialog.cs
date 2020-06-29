using Krypton.Toolkit.Suite.Extended.Base;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonFindAndReplaceDialog : KryptonForm
    {
        #region Design Code
        private System.Windows.Forms.StatusStrip ss;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentStatus;
        private System.Windows.Forms.ToolStripProgressBar tspbCurrentStatusProgress;
        private System.Windows.Forms.ToolStripStatusLabel tsslCurrentStatusProgressValue;
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnReplace;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonDataGridView kdgvResults;
        private KryptonRichTextBox krtbPreview;
        private KryptonLabel kryptonLabel8;
        private KryptonLabel kryptonLabel7;
        private KryptonRichTextBox krtbReplace;
        private KryptonLabel kryptonLabel6;
        private KryptonGroupBox kryptonGroupBox2;
        private KryptonCheckBox kchkShowEncoding;
        private KryptonCheckBox kchkKeepModifiedDate;
        private KryptonCheckBox kchkSkipBinaryFileDetection;
        private KryptonCheckBox kchkUseRegularExpressions;
        private KryptonCheckBox kchkCaseSensitive;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonRichTextBox krtbFind;
        private KryptonLabel kryptonLabel5;
        private KryptonTextBox ktxtExcludeMask;
        private KryptonLabel kryptonLabel4;
        private KryptonTextBox ktxtFileMask;
        private KryptonLabel kryptonLabel3;
        private KryptonTextBox ktxtExcludeDirectory;
        private KryptonLabel kryptonLabel2;
        private KryptonCheckBox kchkIncludeSubdirectories;
        private KryptonTextBox ktxtInputDirectory;
        private KryptonButton kbtnBrowseInputDirectory;
        private KryptonLabel kryptonLabel1;
        private System.ComponentModel.IContainer components;
        private KryptonButton kbtnSwitch;
        private KryptonComboBox kcmbEncoding;
        private KryptonLabel kryptonLabel9;
        private KryptonCheckBox kchkIncludeFilesWithoutMatches;
        private KryptonCheckBox kchkUseEscapeCharacters;
        private KryptonLabel klblDetails;
        private KryptonButton kbtnGenerateReplaceCommandLine;
        private KryptonButton kbtnFindOnly;
        private KryptonButton kbtnBrowseExcludeDirectory;
        private KryptonTextBox ktxtCommandLine;
        private KryptonLabel kryptonLabel10;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.tsslCurrentStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbCurrentStatusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslCurrentStatusProgressValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnGenerateReplaceCommandLine = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnReplace = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.ktxtCommandLine = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel10 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnBrowseExcludeDirectory = new Krypton.Toolkit.KryptonButton();
            this.kbtnFindOnly = new Krypton.Toolkit.KryptonButton();
            this.kbtnSwitch = new Krypton.Toolkit.KryptonButton();
            this.kdgvResults = new Krypton.Toolkit.KryptonDataGridView();
            this.krtbPreview = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.krtbReplace = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.kcmbEncoding = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            this.kchkIncludeFilesWithoutMatches = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkUseEscapeCharacters = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkShowEncoding = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkKeepModifiedDate = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkSkipBinaryFileDetection = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkUseRegularExpressions = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkCaseSensitive = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.klblDetails = new Krypton.Toolkit.KryptonLabel();
            this.krtbFind = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtExcludeMask = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtFileMask = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtExcludeDirectory = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kchkIncludeSubdirectories = new Krypton.Toolkit.KryptonCheckBox();
            this.ktxtInputDirectory = new Krypton.Toolkit.KryptonTextBox();
            this.kbtnBrowseInputDirectory = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbEncoding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ss
            // 
            this.ss.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCurrentStatus,
            this.tspbCurrentStatusProgress,
            this.tsslCurrentStatusProgressValue});
            this.ss.Location = new System.Drawing.Point(0, 786);
            this.ss.Name = "ss";
            this.ss.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.ss.Size = new System.Drawing.Size(1132, 22);
            this.ss.TabIndex = 0;
            this.ss.Text = "statusStrip1";
            // 
            // tsslCurrentStatus
            // 
            this.tsslCurrentStatus.Name = "tsslCurrentStatus";
            this.tsslCurrentStatus.Size = new System.Drawing.Size(1117, 17);
            this.tsslCurrentStatus.Spring = true;
            this.tsslCurrentStatus.Text = "Ready";
            this.tsslCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspbCurrentStatusProgress
            // 
            this.tspbCurrentStatusProgress.Name = "tspbCurrentStatusProgress";
            this.tspbCurrentStatusProgress.Size = new System.Drawing.Size(100, 16);
            this.tspbCurrentStatusProgress.Visible = false;
            // 
            // tsslCurrentStatusProgressValue
            // 
            this.tsslCurrentStatusProgressValue.Name = "tsslCurrentStatusProgressValue";
            this.tsslCurrentStatusProgressValue.Size = new System.Drawing.Size(31, 17);
            this.tsslCurrentStatusProgressValue.Text = "{0}%";
            this.tsslCurrentStatusProgressValue.Visible = false;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateReplaceCommandLine);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnReplace);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 736);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1132, 50);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnGenerateReplaceCommandLine
            // 
            this.kbtnGenerateReplaceCommandLine.Enabled = false;
            this.kbtnGenerateReplaceCommandLine.Location = new System.Drawing.Point(12, 11);
            this.kbtnGenerateReplaceCommandLine.Name = "kbtnGenerateReplaceCommandLine";
            this.kbtnGenerateReplaceCommandLine.Size = new System.Drawing.Size(192, 25);
            this.kbtnGenerateReplaceCommandLine.TabIndex = 2;
            this.kbtnGenerateReplaceCommandLine.Values.Text = "&Generate Replace Command Line";
            this.kbtnGenerateReplaceCommandLine.Click += new System.EventHandler(this.kbtnGenerateReplaceCommandLine_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(1030, 11);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kbtnReplace
            // 
            this.kbtnReplace.Enabled = false;
            this.kbtnReplace.Location = new System.Drawing.Point(934, 11);
            this.kbtnReplace.Name = "kbtnReplace";
            this.kbtnReplace.Size = new System.Drawing.Size(90, 25);
            this.kbtnReplace.TabIndex = 0;
            this.kbtnReplace.Values.Text = "&Replace";
            this.kbtnReplace.Click += new System.EventHandler(this.kbtnReplace_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 734);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 2);
            this.panel1.TabIndex = 2;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtCommandLine);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel10);
            this.kryptonPanel2.Controls.Add(this.kbtnBrowseExcludeDirectory);
            this.kryptonPanel2.Controls.Add(this.kbtnFindOnly);
            this.kryptonPanel2.Controls.Add(this.kbtnSwitch);
            this.kryptonPanel2.Controls.Add(this.kdgvResults);
            this.kryptonPanel2.Controls.Add(this.krtbPreview);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel8);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel7);
            this.kryptonPanel2.Controls.Add(this.krtbReplace);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Controls.Add(this.krtbFind);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.ktxtExcludeMask);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.ktxtFileMask);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.ktxtExcludeDirectory);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kchkIncludeSubdirectories);
            this.kryptonPanel2.Controls.Add(this.ktxtInputDirectory);
            this.kryptonPanel2.Controls.Add(this.kbtnBrowseInputDirectory);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1132, 734);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // ktxtCommandLine
            // 
            this.ktxtCommandLine.Location = new System.Drawing.Point(642, 92);
            this.ktxtCommandLine.Name = "ktxtCommandLine";
            this.ktxtCommandLine.Size = new System.Drawing.Size(445, 20);
            this.ktxtCommandLine.TabIndex = 28;
            this.ktxtCommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ktxtCommandLine_KeyDown);
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(540, 95);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(96, 20);
            this.kryptonLabel10.TabIndex = 27;
            this.kryptonLabel10.Values.Text = "Command Line:";
            // 
            // kbtnBrowseExcludeDirectory
            // 
            this.kbtnBrowseExcludeDirectory.Location = new System.Drawing.Point(1093, 59);
            this.kbtnBrowseExcludeDirectory.Name = "kbtnBrowseExcludeDirectory";
            this.kbtnBrowseExcludeDirectory.Size = new System.Drawing.Size(27, 25);
            this.kbtnBrowseExcludeDirectory.TabIndex = 26;
            this.kbtnBrowseExcludeDirectory.Values.Text = ".&..";
            this.kbtnBrowseExcludeDirectory.Click += new System.EventHandler(this.kbtnBrowseExcludeDirectory_Click);
            // 
            // kbtnFindOnly
            // 
            this.kbtnFindOnly.Location = new System.Drawing.Point(668, 290);
            this.kbtnFindOnly.Name = "kbtnFindOnly";
            this.kbtnFindOnly.Size = new System.Drawing.Size(78, 61);
            this.kbtnFindOnly.TabIndex = 25;
            this.kbtnFindOnly.Values.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.swap_icon1;
            this.kbtnFindOnly.Values.Text = "Find\r\n&Only";
            this.kbtnFindOnly.Click += new System.EventHandler(this.kbtnFindOnly_Click);
            // 
            // kbtnSwitch
            // 
            this.kbtnSwitch.Location = new System.Drawing.Point(668, 181);
            this.kbtnSwitch.Name = "kbtnSwitch";
            this.kbtnSwitch.Size = new System.Drawing.Size(78, 61);
            this.kbtnSwitch.TabIndex = 24;
            this.kbtnSwitch.Values.Image = global::Krypton.Toolkit.Extended.Dialogs.Properties.Resources.swap_icon50_x_46;
            this.kbtnSwitch.Values.Text = "";
            this.kbtnSwitch.Click += new System.EventHandler(this.kbtnSwitch_Click);
            // 
            // kdgvResults
            // 
            this.kdgvResults.Location = new System.Drawing.Point(113, 516);
            this.kdgvResults.Name = "kdgvResults";
            this.kdgvResults.Size = new System.Drawing.Size(1007, 103);
            this.kdgvResults.TabIndex = 23;
            this.kdgvResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kdgvResults_CellClick);
            this.kdgvResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kdgvResults_CellDoubleClick);
            // 
            // krtbPreview
            // 
            this.krtbPreview.Location = new System.Drawing.Point(113, 625);
            this.krtbPreview.Name = "krtbPreview";
            this.krtbPreview.Size = new System.Drawing.Size(1007, 96);
            this.krtbPreview.StateCommon.Back.Color1 = System.Drawing.SystemColors.Info;
            this.krtbPreview.TabIndex = 22;
            this.krtbPreview.Text = "";
            this.krtbPreview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.krtbPreview_KeyDown);
            this.krtbPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.krtbPreview_MouseDown);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(12, 625);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(55, 20);
            this.kryptonLabel8.TabIndex = 21;
            this.kryptonLabel8.Values.Text = "Preview:";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(12, 516);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel7.TabIndex = 19;
            this.kryptonLabel7.Values.Text = "Results:";
            // 
            // krtbReplace
            // 
            this.krtbReplace.Location = new System.Drawing.Point(113, 410);
            this.krtbReplace.Name = "krtbReplace";
            this.krtbReplace.Size = new System.Drawing.Size(1007, 96);
            this.krtbReplace.TabIndex = 18;
            this.krtbReplace.Text = "";
            this.krtbReplace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.krtbReplace_KeyDown);
            this.krtbReplace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.krtbReplace_MouseDown);
            this.krtbReplace.Validating += new System.ComponentModel.CancelEventHandler(this.krtbReplace_Validating);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(12, 410);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel6.TabIndex = 17;
            this.kryptonLabel6.Values.Text = "Replace:";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(113, 248);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.kcmbEncoding);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel9);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kchkIncludeFilesWithoutMatches);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kchkUseEscapeCharacters);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kchkShowEncoding);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kchkKeepModifiedDate);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kchkSkipBinaryFileDetection);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kchkUseRegularExpressions);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kchkCaseSensitive);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(523, 150);
            this.kryptonGroupBox2.TabIndex = 16;
            this.kryptonGroupBox2.Values.Heading = "Options";
            // 
            // kcmbEncoding
            // 
            this.kcmbEncoding.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbEncoding.DropDownWidth = 265;
            this.kcmbEncoding.IntegralHeight = false;
            this.kcmbEncoding.Location = new System.Drawing.Point(241, 90);
            this.kcmbEncoding.Name = "kcmbEncoding";
            this.kcmbEncoding.Size = new System.Drawing.Size(265, 21);
            this.kcmbEncoding.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbEncoding.TabIndex = 15;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(171, 90);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel9.TabIndex = 14;
            this.kryptonLabel9.Values.Text = "Encoding:";
            // 
            // kchkIncludeFilesWithoutMatches
            // 
            this.kchkIncludeFilesWithoutMatches.Location = new System.Drawing.Point(171, 61);
            this.kchkIncludeFilesWithoutMatches.Name = "kchkIncludeFilesWithoutMatches";
            this.kchkIncludeFilesWithoutMatches.Size = new System.Drawing.Size(187, 20);
            this.kchkIncludeFilesWithoutMatches.TabIndex = 6;
            this.kchkIncludeFilesWithoutMatches.Values.Text = "Include Files Without &Matches";
            // 
            // kchkUseEscapeCharacters
            // 
            this.kchkUseEscapeCharacters.Location = new System.Drawing.Point(3, 90);
            this.kchkUseEscapeCharacters.Name = "kchkUseEscapeCharacters";
            this.kchkUseEscapeCharacters.Size = new System.Drawing.Size(145, 20);
            this.kchkUseEscapeCharacters.TabIndex = 5;
            this.kchkUseEscapeCharacters.Values.Text = "&Use Escape Characters";
            // 
            // kchkShowEncoding
            // 
            this.kchkShowEncoding.Location = new System.Drawing.Point(3, 61);
            this.kchkShowEncoding.Name = "kchkShowEncoding";
            this.kchkShowEncoding.Size = new System.Drawing.Size(107, 20);
            this.kchkShowEncoding.TabIndex = 4;
            this.kchkShowEncoding.Values.Text = "Show E&ncoding";
            // 
            // kchkKeepModifiedDate
            // 
            this.kchkKeepModifiedDate.Location = new System.Drawing.Point(171, 32);
            this.kchkKeepModifiedDate.Name = "kchkKeepModifiedDate";
            this.kchkKeepModifiedDate.Size = new System.Drawing.Size(132, 20);
            this.kchkKeepModifiedDate.TabIndex = 3;
            this.kchkKeepModifiedDate.Values.Text = "&Keep Modified Date";
            // 
            // kchkSkipBinaryFileDetection
            // 
            this.kchkSkipBinaryFileDetection.Location = new System.Drawing.Point(3, 32);
            this.kchkSkipBinaryFileDetection.Name = "kchkSkipBinaryFileDetection";
            this.kchkSkipBinaryFileDetection.Size = new System.Drawing.Size(162, 20);
            this.kchkSkipBinaryFileDetection.TabIndex = 2;
            this.kchkSkipBinaryFileDetection.Values.Text = "Skip Binary File &Detection";
            // 
            // kchkUseRegularExpressions
            // 
            this.kchkUseRegularExpressions.Location = new System.Drawing.Point(109, 3);
            this.kchkUseRegularExpressions.Name = "kchkUseRegularExpressions";
            this.kchkUseRegularExpressions.Size = new System.Drawing.Size(155, 20);
            this.kchkUseRegularExpressions.TabIndex = 1;
            this.kchkUseRegularExpressions.Values.Text = "&Use Regular Expressions";
            // 
            // kchkCaseSensitive
            // 
            this.kchkCaseSensitive.Location = new System.Drawing.Point(3, 3);
            this.kchkCaseSensitive.Name = "kchkCaseSensitive";
            this.kchkCaseSensitive.Size = new System.Drawing.Size(100, 20);
            this.kchkCaseSensitive.TabIndex = 0;
            this.kchkCaseSensitive.Values.Text = "&Case Sensitive";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(772, 146);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.klblDetails);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(348, 249);
            this.kryptonGroupBox1.TabIndex = 15;
            this.kryptonGroupBox1.Values.Heading = "Details";
            // 
            // klblDetails
            // 
            this.klblDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblDetails.Location = new System.Drawing.Point(0, 0);
            this.klblDetails.Name = "klblDetails";
            this.klblDetails.Size = new System.Drawing.Size(344, 225);
            this.klblDetails.TabIndex = 14;
            this.klblDetails.Values.Text = "";
            // 
            // krtbFind
            // 
            this.krtbFind.Location = new System.Drawing.Point(113, 146);
            this.krtbFind.Name = "krtbFind";
            this.krtbFind.Size = new System.Drawing.Size(523, 96);
            this.krtbFind.TabIndex = 14;
            this.krtbFind.Text = "";
            this.krtbFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.krtbFind_KeyDown);
            this.krtbFind.Validating += new System.ComponentModel.CancelEventHandler(this.krtbFind_Validating);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(12, 146);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel5.TabIndex = 13;
            this.kryptonLabel5.Values.Text = "Find:";
            // 
            // ktxtExcludeMask
            // 
            this.ktxtExcludeMask.Hint = "*.*";
            this.ktxtExcludeMask.Location = new System.Drawing.Point(389, 92);
            this.ktxtExcludeMask.MaxLength = 50;
            this.ktxtExcludeMask.Name = "ktxtExcludeMask";
            this.ktxtExcludeMask.Size = new System.Drawing.Size(145, 20);
            this.ktxtExcludeMask.TabIndex = 12;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(275, 95);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(87, 20);
            this.kryptonLabel4.TabIndex = 11;
            this.kryptonLabel4.Values.Text = "Exclude Mask:";
            // 
            // ktxtFileMask
            // 
            this.ktxtFileMask.Hint = "*.*";
            this.ktxtFileMask.Location = new System.Drawing.Point(113, 92);
            this.ktxtFileMask.MaxLength = 50;
            this.ktxtFileMask.Name = "ktxtFileMask";
            this.ktxtFileMask.Size = new System.Drawing.Size(145, 20);
            this.ktxtFileMask.TabIndex = 10;
            this.ktxtFileMask.Validating += new System.ComponentModel.CancelEventHandler(this.ktxtFileMask_Validating);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 95);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel3.TabIndex = 9;
            this.kryptonLabel3.Values.Text = "File Mask:";
            // 
            // ktxtExcludeDirectory
            // 
            this.ktxtExcludeDirectory.Location = new System.Drawing.Point(491, 58);
            this.ktxtExcludeDirectory.Name = "ktxtExcludeDirectory";
            this.ktxtExcludeDirectory.Size = new System.Drawing.Size(596, 20);
            this.ktxtExcludeDirectory.TabIndex = 8;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(377, 59);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(108, 20);
            this.kryptonLabel2.TabIndex = 7;
            this.kryptonLabel2.Values.Text = "Exclude Directory:";
            // 
            // kchkIncludeSubdirectories
            // 
            this.kchkIncludeSubdirectories.Location = new System.Drawing.Point(113, 59);
            this.kchkIncludeSubdirectories.Name = "kchkIncludeSubdirectories";
            this.kchkIncludeSubdirectories.Size = new System.Drawing.Size(145, 20);
            this.kchkIncludeSubdirectories.TabIndex = 6;
            this.kchkIncludeSubdirectories.Values.Text = "&Include Subdirectories";
            this.kchkIncludeSubdirectories.CheckedChanged += new System.EventHandler(this.kchkIncludeSubdirectories_CheckedChanged);
            // 
            // ktxtInputDirectory
            // 
            this.ktxtInputDirectory.Location = new System.Drawing.Point(113, 14);
            this.ktxtInputDirectory.Name = "ktxtInputDirectory";
            this.ktxtInputDirectory.Size = new System.Drawing.Size(974, 20);
            this.ktxtInputDirectory.TabIndex = 5;
            this.ktxtInputDirectory.Validating += new System.ComponentModel.CancelEventHandler(this.ktxtInputDirectory_Validating);
            this.ktxtInputDirectory.Validated += new System.EventHandler(this.ktxtInputDirectory_Validated);
            // 
            // kbtnBrowseInputDirectory
            // 
            this.kbtnBrowseInputDirectory.Location = new System.Drawing.Point(1093, 14);
            this.kbtnBrowseInputDirectory.Name = "kbtnBrowseInputDirectory";
            this.kbtnBrowseInputDirectory.Size = new System.Drawing.Size(27, 25);
            this.kbtnBrowseInputDirectory.TabIndex = 4;
            this.kbtnBrowseInputDirectory.Values.Text = ".&..";
            this.kbtnBrowseInputDirectory.Click += new System.EventHandler(this.kbtnBrowseInputDirectory_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 15);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(95, 20);
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Input Directory:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // KryptonFindAndReplaceDialog
            // 
            this.ClientSize = new System.Drawing.Size(1132, 808);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.ss);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonFindAndReplaceDialog";
            this.ShowInTaskbar = false;
            this.Text = "Find && Replace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KryptonFindAndReplaceDialog_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KryptonFindAndReplaceDialog_FormClosed);
            this.Load += new System.EventHandler(this.KryptonFindAndReplaceDialog_Load);
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbEncoding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Variables
        private Finder _finder;

        private Replacer _replacer;

        private Thread _currentThread;

        public bool _isFindOnly;

        private FormData _lastOperationFormData;

        private bool _isFormValid = true;

        private Control _firstInvalidControl = null;
        #endregion

        #region Delegates
        private delegate void SetFindResultCallback(Finder.FindResultItem resultItem, Stats stats, Status status);

        private delegate void SetReplaceResultCallback(Replacer.ReplaceResultItem resultItem, Stats stats, Status status);
        #endregion

        #region Constructor
        public KryptonFindAndReplaceDialog()
        {
            InitializeComponent();

            UpdateStatus();
        }
        #endregion

        #region Event Handlers
        private void KryptonFindAndReplaceDialog_Load(object sender, EventArgs e)
        {
            var encodings = GetEncodings();

            kcmbEncoding.Items.AddRange(encodings.ToArray());

            kcmbEncoding.SelectedIndex = 0;

            InitWithRegistryData();

            ktxtInputDirectory.Focus();
        }

        private void KryptonFindAndReplaceDialog_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void KryptonFindAndReplaceDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_currentThread != null && _currentThread.IsAlive)
            {
                _currentThread.Abort();
            }
        }

        private void kbtnBrowseInputDirectory_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

            if (!string.IsNullOrEmpty(ktxtInputDirectory.Text)) cofd.InitialDirectory = ktxtInputDirectory.Text;

            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ktxtInputDirectory.Text = Path.GetFullPath(cofd.FileName);
            }
        }

        private void kbtnBrowseExcludeDirectory_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ktxtExcludeDirectory.Text = Path.GetFullPath(cofd.FileName);
            }
        }

        private void kbtnSwitch_Click(object sender, EventArgs e)
        {
            string findText = krtbFind.Text;

            krtbFind.Text = krtbReplace.Text;

            krtbReplace.Text = findText;
        }

        private void kbtnFindOnly_Click(object sender, EventArgs e)
        {
            _isFindOnly = true;

            if (!ValidateForm())
            {
                return;
            }

            PrepareFinderGrid();

            UpdateStatus("Getting file list...");

            var finder = GetFinder();

            CreateListener(finder);

            ShowResultPanel();

            krtbPreview.Clear();

            SaveToRegistry();

            _currentThread = new Thread(DoFindWork);

            _currentThread.IsBackground = true;

            _currentThread.Start();
        }

        private void kbtnGenerateReplaceCommandLine_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            UpdateStatus();

            ktxtCommandLine.Clear();

            var replacer = GetReplacer();

            string s =
                String.Format(
                    "\"{0}\" {1}",
                    Application.ExecutablePath,
                    replacer.GenCommandLine(kchkShowEncoding.Checked)
                );

            ktxtCommandLine.Text = s;
        }

        private void kbtnReplace_Click(object sender, EventArgs e)
        {
            _isFindOnly = false;

            if (!ValidateForm())
                return;

            if (String.IsNullOrEmpty(krtbReplace.Text))
            {
                DialogResult dlgResult = KryptonMessageBoxExtended.Show(this, "Are you sure you would like to replace with an empty string?", "Replace Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.No)
                    return;
            }

            UpdateStatus("Getting file list...");

            PrepareReplacerGrid();

            krtbPreview.Clear();

            var replacer = GetReplacer();

            CreateListener(replacer);

            SaveToRegistry();

            _currentThread = new Thread(DoReplaceWork);
            _currentThread.IsBackground = true;

            _currentThread.Start();
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            if (_currentThread.IsAlive)
            {
                if (_isFindOnly)
                    _finder.CancelFind();
                else
                    _replacer.CancelReplace();
            }
        }

        private void krtbFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                krtbFind.SelectAll();

                e.SuppressKeyPress = true;

                e.Handled = true;
            }
        }

        private void krtbReplace_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void krtbPreview_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void ktxtInputDirectory_Validated(object sender, EventArgs e)
        {

        }

        private void ktxtInputDirectory_Validating(object sender, CancelEventArgs e)
        {
            var validationResult = ValidationUtils.IsDirValid(ktxtInputDirectory.Text, "Dir");

            if (!validationResult.IsSuccess)
            {
                errorProvider1.SetError(ktxtInputDirectory, validationResult.ErrorMessage);
                return;
            }

            errorProvider1.SetError(ktxtInputDirectory, "");
        }

        private void ktxtFileMask_Validating(object sender, CancelEventArgs e)
        {
            var validationResult = ValidationUtils.IsNotEmpty(ktxtFileMask.Text, "FileMask");

            if (!validationResult.IsSuccess)
            {
                errorProvider1.SetError(ktxtFileMask, validationResult.ErrorMessage);
                return;
            }

            errorProvider1.SetError(ktxtFileMask, "");
        }

        private void krtbFind_Validating(object sender, CancelEventArgs e)
        {
            var validationResult = ValidationUtils.IsNotEmpty(krtbFind.Text, "Find");

            if (!validationResult.IsSuccess)
            {
                errorProvider1.SetError(krtbFind, validationResult.ErrorMessage);
                return;
            }


            if (kchkUseRegularExpressions.Checked)
            {
                validationResult = ValidationUtils.IsValidRegExp(krtbFind.Text, "Find");

                if (!validationResult.IsSuccess)
                {
                    errorProvider1.SetError(krtbFind, validationResult.ErrorMessage);
                    return;
                }
            }

            if (kchkUseEscapeCharacters.Checked)
            {
                validationResult = ValidationUtils.IsValidEscapeSequence(krtbFind.Text, "Find");

                if (!validationResult.IsSuccess)
                {
                    errorProvider1.SetError(krtbFind, validationResult.ErrorMessage);
                    return;
                }
            }

            errorProvider1.SetError(krtbFind, "");
        }

        private void krtbReplace_Validating(object sender, CancelEventArgs e)
        {
            if (kchkUseEscapeCharacters.Checked)
            {
                var validationResult = ValidationUtils.IsValidEscapeSequence(krtbReplace.Text, "Replace");

                if (!validationResult.IsSuccess)
                {
                    errorProvider1.SetError(krtbReplace, validationResult.ErrorMessage);
                    return;
                }
            }

            errorProvider1.SetError(krtbReplace, "");
        }

        private void kdgvResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //heading
                return;

            int matchedPreviewColIndex = kdgvResults.ColumnCount - 1; //Always last column

            if (kdgvResults.Rows[e.RowIndex].Cells[matchedPreviewColIndex].Value == null)
            {
                HideMatchesPreviewPanel();
                return;
            }

            ShowMatchesPreviewPanel();

            var matchesPreviewText = kdgvResults.Rows[e.RowIndex].Cells[matchedPreviewColIndex].Value.ToString();

            krtbPreview.SelectionLength = 0;
            krtbPreview.Clear();

            krtbPreview.Text = matchesPreviewText;

            var font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);

            //Use _lastOperation form data since user may change it before clicking on preview
            var findText = _lastOperationFormData.IsFindOnly
                               ? _lastOperationFormData.FindText
                               : _lastOperationFormData.ReplaceText;
            findText = findText.Replace("\r\n", "\n");

            findText = ((_lastOperationFormData.IsRegEx || _lastOperationFormData.UseEscapeChars) && _lastOperationFormData.IsFindOnly) ? findText : Regex.Escape(findText);
            var mathches = Regex.Matches(krtbPreview.Text, findText,
                                         Utils.GetRegExOptions(_lastOperationFormData.IsCaseSensitive));

            int count = 0;
            int maxCount = 1000;

            foreach (Match match in mathches)
            {
                krtbPreview.SelectionStart = match.Index;

                krtbPreview.SelectionLength = match.Length;

                krtbPreview.SelectionFont = font;

                krtbPreview.SelectionColor = Color.CadetBlue;

                //Limit highlighted matches, otherwise may lock up the app .  Happened with 65K+
                count++;
                if (count > maxCount)
                    break;
            }

            krtbPreview.SelectionLength = 0;
        }

        private void kdgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) //heading
                return;

            OpenFileUsingExternalApp(e.RowIndex);
        }

        private void contextMenu_ClickOpen(object sender, GVResultEventArgs e)
        {
            OpenFileUsingExternalApp(e.cellRow);
        }

        private void contextMenu_ClickOpenFolder(object sender, GVResultEventArgs e)
        {
            var filePath = kdgvResults.Rows[e.cellRow].Cells[1].Value.ToString();

            string argument = @"/select, " + ktxtInputDirectory.Text + filePath.TrimStart('.');

            Process.Start("explorer.exe", argument);
        }

        private void krtbReplace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                krtbReplace.SelectAll();

                e.SuppressKeyPress = true;

                e.Handled = true;
            }
        }

        private void krtbPreview_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ktxtCommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                ktxtCommandLine.SelectAll();

                e.SuppressKeyPress = true;

                e.Handled = true;
            }
        }

        private void kchkIncludeSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            ktxtExcludeDirectory.Enabled = kchkIncludeSubdirectories.Checked;
        }
        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            ktxtInputDirectory.SelectionStart = ktxtInputDirectory.Text.Length;

            ktxtInputDirectory.DeselectAll();

            base.OnLoad(e);
        }
        #endregion

        #region Methods
        private void UpdateStatus(string statusText = "Ready...") => tsslCurrentStatus.Text = statusText;

        private void SaveToRegistry()
        {
            var data = new FormData();

            data.IsFindOnly = _isFindOnly;

            data.Dir = ktxtInputDirectory.Text;
            data.IncludeSubDirectories = kchkIncludeSubdirectories.Checked;
            data.FileMask = ktxtFileMask.Text;
            data.ExcludeFileMask = ktxtExcludeMask.Text;
            data.FindText = CleanRichBoxText(krtbFind.Text);
            data.IsCaseSensitive = kchkCaseSensitive.Checked;
            data.IsRegEx = kchkUseRegularExpressions.Checked;
            data.SkipBinaryFileDetection = kchkSkipBinaryFileDetection.Checked;
            data.IncludeFilesWithoutMatches = kchkIncludeFilesWithoutMatches.Checked;
            data.ShowEncoding = kchkShowEncoding.Checked;
            data.ReplaceText = CleanRichBoxText(krtbReplace.Text);
            data.UseEscapeChars = kchkUseEscapeCharacters.Checked;
            data.Encoding = kcmbEncoding.Text;
            data.ExcludeDir = ktxtExcludeDirectory.Text;
            data.IsKeepModifiedDate = kchkKeepModifiedDate.Checked;

            data.SaveSetting();

            _lastOperationFormData = data;
        }


        private void PrepareFinderGrid()
        {
            kdgvResults.DataSource = null;

            kdgvResults.Rows.Clear();
            kdgvResults.Columns.Clear();

            AddResultsColumn("Filename", "Filename", 250);
            AddResultsColumn("Path", "Path", 450);

            if (kchkShowEncoding.Checked)
                AddResultsColumn("FileEncoding", "Encoding", 100);

            AddResultsColumn("NumMatches", "Matches", 55);
            AddResultsColumn("ErrorMessage", "Error", 150);
            kdgvResults.Columns[kdgvResults.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            kdgvResults.Columns.Add("MatchesPreview", "");
            kdgvResults.Columns[kdgvResults.ColumnCount - 1].Visible = false;

            HideMatchesPreviewPanel();

            tspbCurrentStatusProgress.Value = 0;
        }

        private void AddResultsColumn(string dataPropertyName, string headerText, int width)
        {
            kdgvResults.Columns.Add(new DataGridViewColumn()
            {
                DataPropertyName = dataPropertyName,
                HeaderText = headerText,
                CellTemplate = new DataGridViewTextBoxCell(),
                Width = width,
                SortMode = DataGridViewColumnSortMode.Automatic,
            });
        }

        private void CreateListener(Finder finder)
        {
            _finder = finder;
            _finder.FileProcessed += OnFinderFileProcessed;
        }

        private void OnFinderFileProcessed(object sender, FinderEventArgs e)
        {
            if (!this.kdgvResults.InvokeRequired)
            {
                ShowFindResult(e.ResultItem, e.Stats, e.Status);
            }
            else
            {
                SetFindResultCallback findResultCallback = ShowFindResult;
                this.Invoke(findResultCallback, new object[] { e.ResultItem, e.Stats, e.Status });
            }
        }

        private void ShowFindResult(Finder.FindResultItem findResultItem, Stats stats, Status status)
        {
            if (stats.Files.Total != 0)
            {
                if (findResultItem.IncludeInResultsList)
                {
                    kdgvResults.Rows.Add();

                    int currentRow = kdgvResults.Rows.Count - 1;

                    kdgvResults.Rows[currentRow].ContextMenuStrip = CreateContextMenu(currentRow);

                    int columnIndex = 0;
                    kdgvResults.Rows[currentRow].Cells[columnIndex++].Value = findResultItem.FileName;
                    kdgvResults.Rows[currentRow].Cells[columnIndex++].Value = findResultItem.FileRelativePath;

                    if (_lastOperationFormData.ShowEncoding)
                        kdgvResults.Rows[currentRow].Cells[columnIndex++].Value = findResultItem.FileEncoding != null
                                                                                    ? findResultItem.FileEncoding.WebName
                                                                                    : String.Empty;

                    kdgvResults.Rows[currentRow].Cells[columnIndex++].Value = findResultItem.NumMatches;
                    kdgvResults.Rows[currentRow].Cells[columnIndex++].Value = findResultItem.ErrorMessage;

                    kdgvResults.Rows[currentRow].Resizable = DataGridViewTriState.False;

                    if (findResultItem.IsSuccess && findResultItem.NumMatches > 0) //Account for errors and IncludeFilesWithoutMatches
                    {
                        string fileContent = string.Empty;

                        using (var sr = new StreamReader(findResultItem.FilePath, findResultItem.FileEncoding))
                        {
                            fileContent = sr.ReadToEnd();
                        }


                        List<MatchPreviewLineNumber> lineNumbers = Utils.GetLineNumbersForMatchesPreview(fileContent,
                                                                                                         findResultItem.Matches);
                        kdgvResults.Rows[currentRow].Cells[columnIndex].Value = GenerateMatchesPreviewText(fileContent,
                                                                                                         lineNumbers.Select(
                                                                                                             ln => ln.LineNumber).ToList());
                    }

                    //Grid likes to select the first row for some reason
                    if (kdgvResults.Rows.Count == 1)
                        kdgvResults.ClearSelection();

                }

                tspbCurrentStatusProgress.Maximum = stats.Files.Total;
                tspbCurrentStatusProgress.Value = stats.Files.Processed;

                UpdateStatus($"Processing { stats.Files.Processed } of { stats.Files.Total } files.  Last file: { findResultItem.FileRelativePath }");

                ShowStats(stats);
            }
            else
            {
                UpdateStatus("No matches found!");

                HideStats();
            }



            //When last file - enable buttons back
            if (status == Status.Completed || status == Status.Cancelled)
            {
                if (status == Status.Completed)
                    UpdateStatus($"Processed { stats.Files.Processed } files.");

                if (status == Status.Cancelled)
                    UpdateStatus("Operation was cancelled.");

                EnableButtons();
            }

        }

        private void DisableButtons()
        {
            //this.Cursor = Cursors.WaitCursor;

            UpdateButtons(false);
        }

        private void EnableButtons()
        {
            UpdateButtons(true);

            //this.Cursor = Cursors.Arrow;
        }

        private void UpdateButtons(bool enabled)
        {
            kbtnFindOnly.Enabled = enabled;
            kbtnReplace.Enabled = enabled;
            kbtnGenerateReplaceCommandLine.Enabled = enabled;
            kbtnCancel.Enabled = !enabled;
        }

        private void DoFindWork()
        {
            try
            {
                _finder.Find();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OnFinderFileProcessed(this, new FinderEventArgs(new Finder.FindResultItem(), new Stats(), Status.Cancelled, _finder.IsSilent));
            }
        }

        private void ShowResultPanel()
        {
            DisableButtons();

            UpdateStatus("No matches found!");

            HideMatchesPreviewPanel();
        }

        private void ShowMatchesPreviewPanel()
        {
            if (!krtbPreview.Enabled)
            {
                krtbPreview.Enabled = true;
                //this.Height += krtbPreview.Height + 50;
            }

        }

        private void HideMatchesPreviewPanel()
        {
            if (krtbPreview.Enabled)
            {
                krtbPreview.Enabled = false;
                //this.Height -= (krtbPreview.Height + 50);
            }
        }

        private bool ValidateForm()
        {
            _isFormValid = true;
            _firstInvalidControl = null;

            ValidateControls(Controls);

            //Focus on first invalid control
            if (_firstInvalidControl != null)
            {
                if (_firstInvalidControl == kryptonPanel2)  //Handle pnlFind
                    _firstInvalidControl = krtbFind;

                _firstInvalidControl.Focus();
            }

            if (!_isFormValid && this.AutoValidate == AutoValidate.Disable)
                this.AutoValidate = AutoValidate.EnablePreventFocusChange; //Revalidate on focus change

            return _isFormValid;
        }

        private void ValidateControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                //Eric - Not needed for now
                //if (control is Panel && !control.CausesValidation)  //handle pnlFind which causes validation
                //{
                //	ValidateControls(control.Controls);
                //	continue;
                //}

                if (!control.CausesValidation)
                    continue;

                control.Focus();

                if (!Validate() || errorProvider1.GetError(control) != "")
                {
                    if (_isFormValid)
                        _firstInvalidControl = control;

                    _isFormValid = false;
                }
                else
                {
                    errorProvider1.SetError(control, "");
                }
            }
        }

        private void CreateListener(Replacer replacer)
        {
            _replacer = replacer;
            _replacer.FileProcessed += ReplaceFileProceed;
        }

        private void PrepareReplacerGrid()
        {
            kdgvResults.DataSource = null;

            kdgvResults.Rows.Clear();
            kdgvResults.Columns.Clear();

            AddResultsColumn("Filename", "Filename", 250);
            AddResultsColumn("Path", "Path", 400);

            if (kchkShowEncoding.Checked)
                AddResultsColumn("FileEncoding", "Encoding", 100);

            AddResultsColumn("NumMatches", "Matches", 50);
            AddResultsColumn("IsSuccess", "Replaced", 60);
            AddResultsColumn("ErrorMessage", "Error", 150);
            kdgvResults.Columns[kdgvResults.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            kdgvResults.Columns.Add("MatchesPreview", "");
            kdgvResults.Columns[kdgvResults.ColumnCount - 1].Visible = false;

            HideMatchesPreviewPanel();
            tspbCurrentStatusProgress.Value = 0;
        }

        private void DoReplaceWork()
        {
            try
            {
                _replacer.Replace();
            }
            catch (Exception e)
            {
                KryptonMessageBoxExtended.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReplaceFileProceed(this, new ReplacerEventArgs(new Replacer.ReplaceResultItem(), new Stats(), Status.Cancelled, _replacer.IsSilent));
            }
        }

        private void ShowReplaceResult(Replacer.ReplaceResultItem replaceResultItem, Stats stats, Status status)
        {
            if (stats.Files.Total > 0)
            {
                if (replaceResultItem.IncludeInResultsList)
                {
                    kdgvResults.Rows.Add();

                    int currentRow = kdgvResults.Rows.Count - 1;

                    kdgvResults.Rows[currentRow].ContextMenuStrip = CreateContextMenu(currentRow);

                    int columnIndex = 0;
                    kdgvResults.Rows[currentRow].Cells[columnIndex++].Value = replaceResultItem.FileName;
                    kdgvResults.Rows[currentRow].Cells[columnIndex++].Value = replaceResultItem.FileRelativePath;

                    if (_lastOperationFormData.ShowEncoding)
                        kdgvResults.Rows[currentRow].Cells[columnIndex++].Value = replaceResultItem.FileEncoding != null
                                                                                    ? replaceResultItem.FileEncoding.WebName
                                                                                    : String.Empty;

                    kdgvResults.Rows[currentRow].Cells[columnIndex++].Value = replaceResultItem.NumMatches;
                    kdgvResults.Rows[currentRow].Cells[columnIndex++].Value = replaceResultItem.IsReplaced ? "Yes" : "No";
                    kdgvResults.Rows[currentRow].Cells[columnIndex++].Value = replaceResultItem.ErrorMessage;

                    kdgvResults.Rows[currentRow].Resizable = DataGridViewTriState.False;

                    if (replaceResultItem.IsSuccess && replaceResultItem.NumMatches > 0)
                    //Account for errors and IncludeFilesWithoutMatches
                    {
                        string fileContent = string.Empty;


                        using (var sr = new StreamReader(replaceResultItem.FilePath, replaceResultItem.FileEncoding))
                        {
                            fileContent = sr.ReadToEnd();
                        }

                        List<MatchPreviewLineNumber> lineNumbers = Utils.GetLineNumbersForMatchesPreview(fileContent,
                                                                                                         replaceResultItem.Matches,
                                                                                                         _lastOperationFormData
                                                                                                             .ReplaceText.Length, true);
                        kdgvResults.Rows[currentRow].Cells[columnIndex].Value = GenerateMatchesPreviewText(fileContent,
                                                                                                         lineNumbers.Select(
                                                                                                             ln => ln.LineNumber).ToList());
                    }

                    //Grid likes to select the first row for some reason
                    if (kdgvResults.Rows.Count == 1)
                        kdgvResults.ClearSelection();
                }

                tspbCurrentStatusProgress.Maximum = stats.Files.Total;
                tspbCurrentStatusProgress.Value = stats.Files.Processed;

                UpdateStatus($"Processing { stats.Files.Processed } of { stats.Files.Total } files.  Last file: { replaceResultItem.FileRelativePath }");


                ShowStats(stats, true);
            }
            else
            {
                UpdateStatus("No matches found!");

                HideStats();
            }


            //When last file - enable buttons back
            if (status == Status.Completed || status == Status.Cancelled)
            {
                if (status == Status.Completed)
                    UpdateStatus($"Processed { stats.Files.Processed } files.");

                if (status == Status.Cancelled)
                    UpdateStatus("Operation was cancelled.");

                EnableButtons();
            }
        }

        private void ReplaceFileProceed(object sender, ReplacerEventArgs e)
        {
            if (!kdgvResults.InvokeRequired)
            {
                ShowReplaceResult(e.ResultItem, e.Stats, e.Status);
            }
            else
            {
                var replaceResultCallback = new SetReplaceResultCallback(ShowReplaceResult);
                Invoke(replaceResultCallback, new object[] { e.ResultItem, e.Stats, e.Status });
            }
        }

        private string GenerateMatchesPreviewText(string content, List<int> rowNumbers)
        {
            var separator = Environment.NewLine;

            var lines = content.Split(new string[] { separator }, StringSplitOptions.None);

            var stringBuilder = new StringBuilder();

            rowNumbers = rowNumbers.Distinct().OrderBy(r => r).ToList();
            var prevLineIndex = 0;
            string lineSeparator =
                ("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            foreach (var rowNumber in rowNumbers)
            {
                if (rowNumber - prevLineIndex > 1 && prevLineIndex != 0)
                {
                    stringBuilder.AppendLine("");
                    stringBuilder.AppendLine(lineSeparator);
                    stringBuilder.AppendLine("");
                }
                stringBuilder.AppendLine(lines[rowNumber]);
                prevLineIndex = rowNumber;
            }

            return stringBuilder.ToString();
        }

        private void OpenFileUsingExternalApp(int rowIndex)
        {
            var filePath = kdgvResults.Rows[rowIndex].Cells[1].Value.ToString();

            string file = ktxtInputDirectory.Text + filePath.TrimStart('.');
            Process.Start(file);
        }

        private ContextMenuStrip CreateContextMenu(int rowNumber)
        {
            var contextMenu = new ContextMenuStrip();
            contextMenu.ShowImageMargin = false;

            var openMenuItem = new ToolStripMenuItem("Open");

            var eventArgs = new GVResultEventArgs();
            eventArgs.cellRow = rowNumber;
            openMenuItem.Click += delegate { contextMenu_ClickOpen(this, eventArgs); };

            var openFolderMenuItem = new ToolStripMenuItem("Open Containing Folder");
            openFolderMenuItem.Click += delegate { contextMenu_ClickOpenFolder(this, eventArgs); };

            contextMenu.Items.Add(openMenuItem);
            contextMenu.Items.Add(openFolderMenuItem);

            return contextMenu;
        }

        private void ShowStats(Stats stats, bool showReplaceStats = false)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Files:");
            sb.AppendLine("- Total: " + stats.Files.Total);
            sb.AppendLine("- Processed: " + stats.Files.Processed);
            sb.AppendLine("- Binary: " + stats.Files.Binary + " (skipped)");
            sb.AppendLine("- With Matches: " + stats.Files.WithMatches);
            sb.AppendLine("- Without Matches: " + stats.Files.WithoutMatches);
            sb.AppendLine("- Failed to Open: " + stats.Files.FailedToRead);

            if (showReplaceStats)
                sb.AppendLine("- Failed to Write: " + stats.Files.FailedToWrite);

            sb.AppendLine("");
            sb.AppendLine("Matches:");
            sb.AppendLine("- Found: " + stats.Matches.Found);

            if (showReplaceStats)
                sb.AppendLine("- Replaced: " + stats.Matches.Replaced);

            var passedSeconds = stats.Time.Passed.TotalSeconds;
            var remainingSeconds = stats.Time.Remaining.TotalSeconds;

            if (passedSeconds >= 1)
            {
                sb.AppendLine("");
                sb.AppendLine("Time:");
                sb.AppendLine("- Passed: " + Utils.FormatTimeSpan(stats.Time.Passed));

                if (passedSeconds >= 3 && (int)remainingSeconds != 0)
                {
                    sb.AppendLine("- Remaining: " + Utils.FormatTimeSpan(stats.Time.Remaining) + " (estimated)");
                }
            }

            klblDetails.Text = sb.ToString();
        }


        private void HideStats()
        {
            klblDetails.Text = string.Empty;
        }

        private void InitWithRegistryData()
        {
            var data = new FormData();

            data.LoadSetting();

            if (data.IsFirstTime)
            {
                data.IsFirstTime = false;
                return;
            }

            ktxtInputDirectory.Text = data.Dir;
            kchkIncludeSubdirectories.Checked = data.IncludeSubDirectories;
            ktxtFileMask.Text = data.FileMask;
            ktxtExcludeMask.Text = data.ExcludeFileMask;
            ktxtExcludeDirectory.Text = data.ExcludeDir;
            krtbFind.Text = data.FindText;
            kchkCaseSensitive.Checked = data.IsCaseSensitive;
            kchkUseRegularExpressions.Checked = data.IsRegEx;
            kchkSkipBinaryFileDetection.Checked = data.SkipBinaryFileDetection;
            kchkIncludeFilesWithoutMatches.Checked = data.IncludeFilesWithoutMatches;
            kchkShowEncoding.Checked = data.ShowEncoding;
            krtbReplace.Text = data.ReplaceText;
            kchkUseEscapeCharacters.Checked = data.UseEscapeChars;
            kchkKeepModifiedDate.Checked = data.IsKeepModifiedDate;

            if (!string.IsNullOrEmpty(data.Encoding))
                kcmbEncoding.SelectedIndex = kcmbEncoding.Items.IndexOf(data.Encoding);
        }

        private List<string> GetEncodings()
        {
            var result = new List<string>();

            result.Add("Auto Detect");

            foreach (EncodingInfo ei in Encoding.GetEncodings().OrderBy(ei => ei.Name))
            {
                //Encoding e = ei.GetEncoding();

                result.Add(ei.Name);
            }

            return result;
        }

        private Finder GetFinder()
        {
            var finder = new Finder();
            finder.Dir = ktxtInputDirectory.Text;

            finder.IncludeSubDirectories = kchkIncludeSubdirectories.Checked;
            finder.FileMask = ktxtFileMask.Text;
            finder.FindTextHasRegEx = kchkUseRegularExpressions.Checked;
            finder.FindText = CleanRichBoxText(krtbFind.Text);
            finder.IsCaseSensitive = kchkCaseSensitive.Checked;
            finder.SkipBinaryFileDetection = kchkSkipBinaryFileDetection.Checked;
            finder.IncludeFilesWithoutMatches = kchkIncludeFilesWithoutMatches.Checked;
            finder.ExcludeFileMask = ktxtExcludeMask.Text;
            finder.ExcludeDir = ktxtExcludeDirectory.Text;

            finder.UseEscapeChars = kchkUseEscapeCharacters.Checked;

            if (kcmbEncoding.SelectedIndex > 0)
                finder.AlwaysUseEncoding = Utils.GetEncodingByName(kcmbEncoding.Text);

            return finder;
        }

        private string CleanRichBoxText(string text)
        {
            return text.Replace("\n", Environment.NewLine);
        }

        private Replacer GetReplacer()
        {
            var replacer = new Replacer();

            replacer.Dir = ktxtInputDirectory.Text;
            replacer.IncludeSubDirectories = kchkIncludeSubdirectories.Checked;

            replacer.FileMask = ktxtFileMask.Text;
            replacer.ExcludeFileMask = ktxtFileMask.Text;
            replacer.ExcludeDir = ktxtExcludeDirectory.Text;
            replacer.FindText = CleanRichBoxText(krtbFind.Text);
            replacer.IsCaseSensitive = kchkCaseSensitive.Checked;
            replacer.FindTextHasRegEx = kchkUseRegularExpressions.Checked;
            replacer.SkipBinaryFileDetection = kchkSkipBinaryFileDetection.Checked;
            replacer.IncludeFilesWithoutMatches = kchkIncludeFilesWithoutMatches.Checked;
            replacer.ReplaceText = CleanRichBoxText(krtbReplace.Text);
            replacer.UseEscapeChars = kchkUseEscapeCharacters.Checked;
            replacer.IsKeepModifiedDate = kchkKeepModifiedDate.Checked;


            if (kcmbEncoding.SelectedIndex > 0)
                replacer.AlwaysUseEncoding = Utils.GetEncodingByName(kcmbEncoding.Text);

            return replacer;
        }
        #endregion

        public class GVResultEventArgs : EventArgs
        {
            public int cellRow { get; set; }
        }
    }
}
﻿#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.File.Copier
{
    public class KryptonFileCopier : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kdbtnOk;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnCopyFiles;
        private KryptonGroupBox kryptonGroupBox2;
        private KryptonLabel klblDirectoryInformation;
        private KryptonButton kbtnMoveFiles;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonLabel klblFileHash;
        private KryptonFileListing kflListing;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonCheckBox kchkUseDebugConsole;
        private KryptonButton kdbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new();
            this.kchkUseDebugConsole = new();
            this.kryptonBorderEdge1 = new();
            this.kdbtnOk = new();
            this.kdbtnCancel = new();
            this.kryptonPanel2 = new();
            this.kbtnCopyFiles = new();
            this.kryptonGroupBox2 = new();
            this.klblDirectoryInformation = new();
            this.kbtnMoveFiles = new();
            this.kryptonGroupBox1 = new();
            this.klblFileHash = new();
            this.kflListing = new();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kchkUseDebugConsole);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Controls.Add(this.kdbtnOk);
            this.kryptonPanel1.Controls.Add(this.kdbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new(0, 395);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new(707, 43);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kchkUseDebugConsole
            // 
            this.kchkUseDebugConsole.Location = new(12, 11);
            this.kchkUseDebugConsole.Name = "kchkUseDebugConsole";
            this.kchkUseDebugConsole.Size = new(131, 20);
            this.kchkUseDebugConsole.TabIndex = 5;
            this.kchkUseDebugConsole.Values.Text = "Use &Debug Console";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new(707, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kdbtnOk
            // 
            this.kdbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kdbtnOk.Location = new(509, 6);
            this.kdbtnOk.Name = "kdbtnOk";
            this.kdbtnOk.Size = new(90, 25);
            this.kdbtnOk.TabIndex = 3;
            this.kdbtnOk.Values.Text = "&OK";
            // 
            // kdbtnCancel
            // 
            this.kdbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kdbtnCancel.Location = new(605, 6);
            this.kdbtnCancel.Name = "kdbtnCancel";
            this.kdbtnCancel.Size = new(90, 25);
            this.kdbtnCancel.TabIndex = 3;
            this.kdbtnCancel.Values.Text = "C&ancel";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnCopyFiles);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel2.Controls.Add(this.kbtnMoveFiles);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Controls.Add(this.kflListing);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new(707, 395);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // kbtnCopyFiles
            // 
            this.kbtnCopyFiles.Location = new(345, 335);
            this.kbtnCopyFiles.Name = "kbtnCopyFiles";
            this.kbtnCopyFiles.Size = new(293, 25);
            this.kbtnCopyFiles.TabIndex = 6;
            this.kbtnCopyFiles.Values.Text = "&Copy Files";
            this.kbtnCopyFiles.Click += new(this.kbtnCopyFiles_Click);
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new(288, 168);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.klblDirectoryInformation);
            this.kryptonGroupBox2.Size = new(409, 150);
            this.kryptonGroupBox2.TabIndex = 6;
            this.kryptonGroupBox2.Values.Heading = "Directory Information";
            // 
            // klblDirectoryInformation
            // 
            this.klblDirectoryInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblDirectoryInformation.Location = new(0, 0);
            this.klblDirectoryInformation.Name = "klblDirectoryInformation";
            this.klblDirectoryInformation.Size = new(405, 126);
            this.klblDirectoryInformation.TabIndex = 7;
            this.klblDirectoryInformation.Values.Text = "kryptonLabel2";
            // 
            // kbtnMoveFiles
            // 
            this.kbtnMoveFiles.Location = new(345, 335);
            this.kbtnMoveFiles.Name = "kbtnMoveFiles";
            this.kbtnMoveFiles.Size = new(293, 25);
            this.kbtnMoveFiles.TabIndex = 5;
            this.kbtnMoveFiles.Values.Text = "&Move Files";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new(286, 12);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.klblFileHash);
            this.kryptonGroupBox1.Size = new(409, 150);
            this.kryptonGroupBox1.TabIndex = 5;
            this.kryptonGroupBox1.Values.Heading = "File Hash";
            // 
            // klblFileHash
            // 
            this.klblFileHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblFileHash.Location = new(0, 0);
            this.klblFileHash.Name = "klblFileHash";
            this.klblFileHash.Size = new(405, 126);
            this.klblFileHash.StateCommon.ShortText.Font = new("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFileHash.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblFileHash.TabIndex = 5;
            this.klblFileHash.Values.Text = "{0}";
            // 
            // kflListing
            // 
            this.kflListing.Location = new(12, 12);
            this.kflListing.Name = "kflListing";
            this.kflListing.OpenFileDialogTitle = null;
            this.kflListing.PromptText = null;
            this.kflListing.Size = new(268, 374);
            this.kflListing.TabIndex = 5;
            // 
            // KryptonFileCopier
            // 
            this.AcceptButton = this.kdbtnOk;
            this.CancelButton = this.kdbtnCancel;
            this.ClientSize = new(707, 438);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonFileCopier";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Copy Files";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables

        private FileDialogType _fileDialogType;

        private string _sourceDirectory, _targetDirectory;
        #endregion

        #region Properties
        public string SourceDirectory { get => _sourceDirectory; set => _sourceDirectory = value; }

        public string TargetDirectory { get => _targetDirectory; set => _targetDirectory = value; }
        #endregion

        #region Constructors
        public KryptonFileCopier()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void CopyFiles()
        {
            if (kflListing.FileListing.Items.Count > 0)
            {
                List<string> tempFiles = new();

                foreach (string item in kflListing.FileListing.Items)
                {
                    tempFiles.Add(item);
                }

                string? tempPath = null;

                switch (_fileDialogType)
                {
                    case FileDialogType.Krypton:
                        KryptonFolderBrowserDialog kfbd = new();

                        kfbd.Title = @"Select a Destination:";

                        if (kfbd.ShowDialog() == DialogResult.OK)
                        {
                            tempPath = Path.GetFullPath(kfbd.SelectedPath);
                        }
                        break;
                    case FileDialogType.Standard:
                        FolderBrowserDialog fbd = new();

                        fbd.Description = @"Select a Destination:";

                        if (fbd.ShowDialog() == DialogResult.OK)
                        {
                            tempPath = Path.GetFullPath(fbd.SelectedPath);
                        }
                        break;
                    case FileDialogType.WindowsAPICodePack:
                        CommonOpenFileDialog cofd = new();

                        cofd.IsFolderPicker = true;

                        cofd.Title = "Select a destination:";

                        if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                        {
                            tempPath = Path.GetFullPath(cofd.FileName);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                CopyFiles copy = new(tempFiles, tempPath);

                KryptonFileMonitor monitor = new();

                monitor.SynchronizationObject = this;

                copy.CopyAsync(monitor);
            }
        }
        #endregion

        private void kbtnCopyFiles_Click(object sender, EventArgs e)
        {
            if (kchkUseDebugConsole.Checked)
            {
                List<string> files = new();

                foreach (string item in kflListing.FileListing.Items)
                {
                    files.Add(item);
                }

                KryptonDeveloperDebugConsole debugConsole = new(HelperUtilites.ReturnDirectoryListing(files));

                debugConsole.Show();
            }
            else
            {
                CopyFiles();
            }
        }
    }
}
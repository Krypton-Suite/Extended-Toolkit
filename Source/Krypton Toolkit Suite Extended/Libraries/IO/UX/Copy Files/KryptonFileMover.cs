﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    public class KryptonFileMover : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kdbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnCopyFiles;
        private KryptonGroupBox kryptonGroupBox2;
        private KryptonLabel klblDirectoryInformation;
        private KryptonButton kbtnMoveFiles;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonLabel klblFileHash;
        private KryptonFileListing kflListing;
        private KryptonButton kdbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kdbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kdbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCopyFiles = new Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.klblDirectoryInformation = new Krypton.Toolkit.KryptonLabel();
            this.kbtnMoveFiles = new Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.klblFileHash = new Krypton.Toolkit.KryptonLabel();
            this.kflListing = new Krypton.Toolkit.Suite.Extended.IO.KryptonFileListing();
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
            this.kryptonPanel1.Controls.Add(this.kdbtnOk);
            this.kryptonPanel1.Controls.Add(this.kdbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 395);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(707, 43);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kdbtnOk
            // 
            this.kdbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kdbtnOk.Location = new System.Drawing.Point(509, 6);
            this.kdbtnOk.Name = "kdbtnOk";
            this.kdbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kdbtnOk.TabIndex = 3;
            this.kdbtnOk.Values.Text = "&OK";
            // 
            // kdbtnCancel
            // 
            this.kdbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kdbtnCancel.Location = new System.Drawing.Point(605, 6);
            this.kdbtnCancel.Name = "kdbtnCancel";
            this.kdbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kdbtnCancel.TabIndex = 3;
            this.kdbtnCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 3);
            this.panel1.TabIndex = 3;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnCopyFiles);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel2.Controls.Add(this.kbtnMoveFiles);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Controls.Add(this.kflListing);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(707, 392);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // kbtnCopyFiles
            // 
            this.kbtnCopyFiles.Location = new System.Drawing.Point(345, 335);
            this.kbtnCopyFiles.Name = "kbtnCopyFiles";
            this.kbtnCopyFiles.Size = new System.Drawing.Size(293, 25);
            this.kbtnCopyFiles.TabIndex = 6;
            this.kbtnCopyFiles.Values.Text = "&Copy Files";
            this.kbtnCopyFiles.Click += new System.EventHandler(this.kbtnCopyFiles_Click);
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(288, 168);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.klblDirectoryInformation);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(409, 150);
            this.kryptonGroupBox2.TabIndex = 6;
            this.kryptonGroupBox2.Values.Heading = "Directory Information";
            // 
            // klblDirectoryInformation
            // 
            this.klblDirectoryInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblDirectoryInformation.Location = new System.Drawing.Point(0, 0);
            this.klblDirectoryInformation.Name = "klblDirectoryInformation";
            this.klblDirectoryInformation.Size = new System.Drawing.Size(405, 126);
            this.klblDirectoryInformation.TabIndex = 7;
            this.klblDirectoryInformation.Values.Text = "kryptonLabel2";
            // 
            // kbtnMoveFiles
            // 
            this.kbtnMoveFiles.Location = new System.Drawing.Point(345, 335);
            this.kbtnMoveFiles.Name = "kbtnMoveFiles";
            this.kbtnMoveFiles.Size = new System.Drawing.Size(293, 25);
            this.kbtnMoveFiles.TabIndex = 5;
            this.kbtnMoveFiles.Values.Text = "&Move Files";
            this.kbtnMoveFiles.Click += new System.EventHandler(this.kbtnMoveFiles_Click);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(286, 12);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.klblFileHash);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(409, 150);
            this.kryptonGroupBox1.TabIndex = 5;
            this.kryptonGroupBox1.Values.Heading = "File Hash";
            // 
            // klblFileHash
            // 
            this.klblFileHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblFileHash.Location = new System.Drawing.Point(0, 0);
            this.klblFileHash.Name = "klblFileHash";
            this.klblFileHash.Size = new System.Drawing.Size(405, 126);
            this.klblFileHash.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFileHash.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblFileHash.TabIndex = 5;
            this.klblFileHash.Values.Text = "{0}";
            // 
            // kflListing
            // 
            this.kflListing.Location = new System.Drawing.Point(12, 12);
            this.kflListing.Name = "kflListing";
            this.kflListing.OpenFileDialogTitle = null;
            this.kflListing.PromptText = null;
            this.kflListing.Size = new System.Drawing.Size(268, 374);
            this.kflListing.TabIndex = 5;
            // 
            // KryptonFileMover
            // 
            this.ClientSize = new System.Drawing.Size(707, 438);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "KryptonFileMover";
            this.Load += new System.EventHandler(this.KryptonFileMover_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
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
        private string _sourceDirectory, _targetDirectory;
        #endregion

        #region Properties
        public string SourceDirectory { get => _sourceDirectory; set => _sourceDirectory = value; }

        public string TargetDirectory { get => _targetDirectory; set => _targetDirectory = value; }
        #endregion

        private void KryptonFileMover_Load(object sender, EventArgs e)
        {

        }

        private void kbtnMoveFiles_Click(object sender, EventArgs e)
        {

        }

        private void kbtnCopyFiles_Click(object sender, EventArgs e)
        {
            if (kflListing.FileListing.Items.Count > 0)
            {
                List<string> tempFiles = new List<string>();

                foreach (string item in kflListing.FileListing.Items)
                {
                    tempFiles.Add(item);
                }

                string tempPath = null;

                CommonOpenFileDialog cofd = new CommonOpenFileDialog();

                cofd.IsFolderPicker = true;

                cofd.Title = "Select a destination:";

                if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    tempPath = Path.GetFullPath(cofd.FileName);
                }

                CopyFiles copy = new CopyFiles(tempFiles, tempPath);

                KryptonFileMonitor monitor = new KryptonFileMonitor();

                monitor.SynchronizationObject = this;

                copy.CopyAsync(monitor);
            }
        }
    }
}
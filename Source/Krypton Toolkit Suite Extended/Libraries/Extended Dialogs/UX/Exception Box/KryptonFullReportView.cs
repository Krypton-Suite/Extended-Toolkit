using Krypton.Toolkit.Suite.Extended.Core;
using System;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonFullReportView : KryptonForm
    {
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonCancelDialogButton kcdbCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private KryptonPanel kryptonPanel3;
        private Navigator.KryptonNavigator kryptonNavigator1;
        private Navigator.KryptonPage kryptonPage1;
        private Navigator.KryptonPage kryptonPage2;
        private KryptonButton kbtnSend;
        private KryptonButton kbtnLessDetails;
        private KryptonButton kbtnCopy;
        private KryptonButton kbtnSave;
        private KryptonRichTextBox kryptonRichTextBox2;
        private KryptonLabel kryptonLabel6;
        private Base.KryptonBorderedLabel kryptonBorderedLabel4;
        private KryptonLabel kryptonLabel4;
        private Base.KryptonBorderedLabel kryptonBorderedLabel5;
        private KryptonLabel kryptonLabel5;
        private Base.KryptonBorderedLabel kryptonBorderedLabel3;
        private KryptonLabel kryptonLabel3;
        private Base.KryptonBorderedLabel kryptonBorderedLabel2;
        private KryptonLabel kryptonLabel2;
        private Base.KryptonBorderedLabel kryptonBorderedLabel1;
        private KryptonLabel kryptonLabel1;
        private KryptonRichTextBox kryptonRichTextBox1;
        private System.Windows.Forms.PictureBox picGeneral;
        private Navigator.KryptonPage kryptonPage3;
        private Navigator.KryptonPage kryptonPage4;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonFullReportView));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.kcdbCancel = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnSend = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel3 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonNavigator1 = new Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new Krypton.Navigator.KryptonPage();
            this.kryptonPage2 = new Krypton.Navigator.KryptonPage();
            this.kbtnSave = new Krypton.Toolkit.KryptonButton();
            this.kbtnCopy = new Krypton.Toolkit.KryptonButton();
            this.kbtnLessDetails = new Krypton.Toolkit.KryptonButton();
            this.kryptonPage3 = new Krypton.Navigator.KryptonPage();
            this.kryptonPage4 = new Krypton.Navigator.KryptonPage();
            this.picGeneral = new System.Windows.Forms.PictureBox();
            this.kryptonRichTextBox1 = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonBorderedLabel1 = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonBorderedLabel2 = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonBorderedLabel3 = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonBorderedLabel4 = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonBorderedLabel5 = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonRichTextBox2 = new Krypton.Toolkit.KryptonRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.statusStrip1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 566);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(613, 22);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(613, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(496, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Loading system information...";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // kcdbCancel
            // 
            this.kcdbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kcdbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kcdbCancel.Location = new System.Drawing.Point(514, 7);
            this.kcdbCancel.Name = "kcdbCancel";
            this.kcdbCancel.ParentWindow = null;
            this.kcdbCancel.Size = new System.Drawing.Size(90, 25);
            this.kcdbCancel.TabIndex = 4;
            this.kcdbCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 522);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 3);
            this.panel1.TabIndex = 2;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnLessDetails);
            this.kryptonPanel2.Controls.Add(this.kbtnCopy);
            this.kryptonPanel2.Controls.Add(this.kbtnSave);
            this.kryptonPanel2.Controls.Add(this.kbtnSend);
            this.kryptonPanel2.Controls.Add(this.kcdbCancel);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 525);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(613, 41);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // kbtnSend
            // 
            this.kbtnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSend.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnSend.Location = new System.Drawing.Point(418, 7);
            this.kbtnSend.Name = "kbtnSend";
            this.kbtnSend.Size = new System.Drawing.Size(90, 25);
            this.kbtnSend.TabIndex = 5;
            this.kbtnSend.Values.Text = "S&end";
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.kryptonNavigator1);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(613, 522);
            this.kryptonPanel3.TabIndex = 4;
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Location = new System.Drawing.Point(12, 12);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2,
            this.kryptonPage3,
            this.kryptonPage4});
            this.kryptonNavigator1.SelectedIndex = 3;
            this.kryptonNavigator1.Size = new System.Drawing.Size(591, 500);
            this.kryptonNavigator1.TabIndex = 0;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.kryptonRichTextBox2);
            this.kryptonPage1.Controls.Add(this.kryptonLabel6);
            this.kryptonPage1.Controls.Add(this.kryptonBorderedLabel4);
            this.kryptonPage1.Controls.Add(this.kryptonLabel4);
            this.kryptonPage1.Controls.Add(this.kryptonBorderedLabel5);
            this.kryptonPage1.Controls.Add(this.kryptonLabel5);
            this.kryptonPage1.Controls.Add(this.kryptonBorderedLabel3);
            this.kryptonPage1.Controls.Add(this.kryptonLabel3);
            this.kryptonPage1.Controls.Add(this.kryptonBorderedLabel2);
            this.kryptonPage1.Controls.Add(this.kryptonLabel2);
            this.kryptonPage1.Controls.Add(this.kryptonBorderedLabel1);
            this.kryptonPage1.Controls.Add(this.kryptonLabel1);
            this.kryptonPage1.Controls.Add(this.kryptonRichTextBox1);
            this.kryptonPage1.Controls.Add(this.picGeneral);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(589, 473);
            this.kryptonPage1.Text = "General";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "08a4072e2e444d618f93b1769d0f5934";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(589, 473);
            this.kryptonPage2.Text = "Exceptions";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "694cc14036a848cf80adc36d768d2a0a";
            // 
            // kbtnSave
            // 
            this.kbtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnSave.Location = new System.Drawing.Point(322, 7);
            this.kbtnSave.Name = "kbtnSave";
            this.kbtnSave.Size = new System.Drawing.Size(90, 25);
            this.kbtnSave.TabIndex = 6;
            this.kbtnSave.Values.Text = "S&ave";
            // 
            // kbtnCopy
            // 
            this.kbtnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCopy.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnCopy.Location = new System.Drawing.Point(226, 7);
            this.kbtnCopy.Name = "kbtnCopy";
            this.kbtnCopy.Size = new System.Drawing.Size(90, 25);
            this.kbtnCopy.TabIndex = 7;
            this.kbtnCopy.Values.Text = "&Copy";
            // 
            // kbtnLessDetails
            // 
            this.kbtnLessDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnLessDetails.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnLessDetails.Location = new System.Drawing.Point(130, 7);
            this.kbtnLessDetails.Name = "kbtnLessDetails";
            this.kbtnLessDetails.Size = new System.Drawing.Size(90, 25);
            this.kbtnLessDetails.TabIndex = 8;
            this.kbtnLessDetails.Values.Text = "Less &Details";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(589, 473);
            this.kryptonPage3.Text = "Assemblies";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "fde488a4932e4ef29bd2bcb5e3a9d6fd";
            // 
            // kryptonPage4
            // 
            this.kryptonPage4.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage4.Flags = 65534;
            this.kryptonPage4.LastVisibleSet = true;
            this.kryptonPage4.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage4.Name = "kryptonPage4";
            this.kryptonPage4.Size = new System.Drawing.Size(589, 473);
            this.kryptonPage4.Text = "System";
            this.kryptonPage4.ToolTipTitle = "Page ToolTip";
            this.kryptonPage4.UniqueName = "c6c80bc57dec4d9f974905ba7ac0c48a";
            // 
            // picGeneral
            // 
            this.picGeneral.BackColor = System.Drawing.Color.Transparent;
            this.picGeneral.Image = ((System.Drawing.Image)(resources.GetObject("picGeneral.Image")));
            this.picGeneral.Location = new System.Drawing.Point(22, 20);
            this.picGeneral.Name = "picGeneral";
            this.picGeneral.Size = new System.Drawing.Size(64, 64);
            this.picGeneral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGeneral.TabIndex = 26;
            this.picGeneral.TabStop = false;
            // 
            // kryptonRichTextBox1
            // 
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(92, 20);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.ReadOnly = true;
            this.kryptonRichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(482, 64);
            this.kryptonRichTextBox1.TabIndex = 27;
            this.kryptonRichTextBox1.Text = "kryptonRichTextBox1";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(22, 107);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel1.TabIndex = 28;
            this.kryptonLabel1.Values.Text = "Application:";
            // 
            // kryptonBorderedLabel1
            // 
            this.kryptonBorderedLabel1.AutoSize = false;
            this.kryptonBorderedLabel1.BackColor = System.Drawing.Color.Transparent;
            this.kryptonBorderedLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kryptonBorderedLabel1.Location = new System.Drawing.Point(104, 106);
            this.kryptonBorderedLabel1.Name = "kryptonBorderedLabel1";
            this.kryptonBorderedLabel1.Size = new System.Drawing.Size(470, 25);
            this.kryptonBorderedLabel1.TabIndex = 29;
            this.kryptonBorderedLabel1.Values.Text = "kryptonBorderedLabel1";
            // 
            // kryptonBorderedLabel2
            // 
            this.kryptonBorderedLabel2.AutoSize = false;
            this.kryptonBorderedLabel2.BackColor = System.Drawing.Color.Transparent;
            this.kryptonBorderedLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kryptonBorderedLabel2.Location = new System.Drawing.Point(104, 153);
            this.kryptonBorderedLabel2.Name = "kryptonBorderedLabel2";
            this.kryptonBorderedLabel2.Size = new System.Drawing.Size(139, 25);
            this.kryptonBorderedLabel2.TabIndex = 31;
            this.kryptonBorderedLabel2.Values.Text = "kryptonBorderedLabel2";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(22, 154);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel2.TabIndex = 30;
            this.kryptonLabel2.Values.Text = "Application:";
            // 
            // kryptonBorderedLabel3
            // 
            this.kryptonBorderedLabel3.AutoSize = false;
            this.kryptonBorderedLabel3.BackColor = System.Drawing.Color.Transparent;
            this.kryptonBorderedLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kryptonBorderedLabel3.Location = new System.Drawing.Point(370, 153);
            this.kryptonBorderedLabel3.Name = "kryptonBorderedLabel3";
            this.kryptonBorderedLabel3.Size = new System.Drawing.Size(139, 25);
            this.kryptonBorderedLabel3.TabIndex = 33;
            this.kryptonBorderedLabel3.Values.Text = "kryptonBorderedLabel3";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(288, 154);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel3.TabIndex = 32;
            this.kryptonLabel3.Values.Text = "Application:";
            // 
            // kryptonBorderedLabel4
            // 
            this.kryptonBorderedLabel4.AutoSize = false;
            this.kryptonBorderedLabel4.BackColor = System.Drawing.Color.Transparent;
            this.kryptonBorderedLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kryptonBorderedLabel4.Location = new System.Drawing.Point(370, 195);
            this.kryptonBorderedLabel4.Name = "kryptonBorderedLabel4";
            this.kryptonBorderedLabel4.Size = new System.Drawing.Size(139, 25);
            this.kryptonBorderedLabel4.TabIndex = 37;
            this.kryptonBorderedLabel4.Values.Text = "kryptonBorderedLabel4";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(288, 196);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel4.TabIndex = 36;
            this.kryptonLabel4.Values.Text = "Application:";
            // 
            // kryptonBorderedLabel5
            // 
            this.kryptonBorderedLabel5.AutoSize = false;
            this.kryptonBorderedLabel5.BackColor = System.Drawing.Color.Transparent;
            this.kryptonBorderedLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kryptonBorderedLabel5.Location = new System.Drawing.Point(104, 195);
            this.kryptonBorderedLabel5.Name = "kryptonBorderedLabel5";
            this.kryptonBorderedLabel5.Size = new System.Drawing.Size(139, 25);
            this.kryptonBorderedLabel5.TabIndex = 35;
            this.kryptonBorderedLabel5.Values.Text = "kryptonBorderedLabel5";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(22, 196);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel5.TabIndex = 34;
            this.kryptonLabel5.Values.Text = "Application:";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(22, 238);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(390, 20);
            this.kryptonLabel6.TabIndex = 38;
            this.kryptonLabel6.Values.Text = "Please enter a brief explanation of events leading up to this exception";
            // 
            // kryptonRichTextBox2
            // 
            this.kryptonRichTextBox2.Location = new System.Drawing.Point(22, 265);
            this.kryptonRichTextBox2.Name = "kryptonRichTextBox2";
            this.kryptonRichTextBox2.Size = new System.Drawing.Size(552, 195);
            this.kryptonRichTextBox2.StateCommon.Back.Color1 = System.Drawing.Color.Cornsilk;
            this.kryptonRichTextBox2.TabIndex = 39;
            this.kryptonRichTextBox2.Text = "kryptonRichTextBox2";
            // 
            // KryptonExceptionMessageBox
            // 
            this.CancelButton = this.kcdbCancel;
            this.ClientSize = new System.Drawing.Size(613, 588);
            this.Controls.Add(this.kryptonPanel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KryptonExceptionMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.KryptonExceptionMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            this.kryptonPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGeneral)).EndInit();
            this.ResumeLayout(false);

        }

        private void KryptonExceptionMessageBox_Load(object sender, EventArgs e)
        {
            GlobalUtilityMethods.NotImplementedYet();

            Close();
        }
    }
}
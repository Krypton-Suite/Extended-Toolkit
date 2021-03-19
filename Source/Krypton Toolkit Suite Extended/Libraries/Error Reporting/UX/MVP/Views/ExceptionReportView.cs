using Krypton.Toolkit.Suite.Extended.Base;
using System;

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    public class ExceptionReportView : KryptonFormExtended
    {
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonPanel kpnlLessDetails;
        private System.Windows.Forms.PictureBox pictureBox1;
        private KryptonTextBox ktxtExceptionMessageLarge2;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnMoreDetails;
        private KryptonButton kbtnSimpleCopyDetails;
        private KryptonButton kbtnSimpleEMail;
        private KryptonLabel klblContactCompany;
        private Navigator.KryptonNavigator kryptonNavigator1;
        private Navigator.KryptonPage kpGeneral;
        private Navigator.KryptonPage kpExceptions;
        private KryptonTextBox ktxtExceptionMessageLarge;
        private KryptonTextBox ktxtUserExplanation;
        private KryptonLabel kryptonLabel7;
        private KryptonBorderedLabel kblTime;
        private KryptonLabel kryptonLabel5;
        private KryptonBorderedLabel kblDate;
        private KryptonLabel kryptonLabel6;
        private KryptonBorderedLabel kblRegion;
        private KryptonLabel kryptonLabel4;
        private KryptonBorderedLabel kblVersion;
        private KryptonLabel kryptonLabel3;
        private KryptonBorderedLabel kblApplication;
        private KryptonLabel kryptonLabel2;
        private KryptonTextBox ktxtExceptionMessage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Navigator.KryptonPage kpAssemblies;
        private System.Windows.Forms.ListView lvAssemblies;
        private Navigator.KryptonPage kpSystem;
        private KryptonTreeView ktvEnvironment;
        private KryptonButton kbtnEMail;
        private KryptonButton kbtnClose;
        private KryptonButton kbtnDetailToggle;
        private KryptonButton kbtnCopy;
        private KryptonButton kbtnSave;
        private KryptonPanel kpnlOptions;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionReportView));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnEMail = new Krypton.Toolkit.KryptonButton();
            this.kbtnClose = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kpnlLessDetails = new Krypton.Toolkit.KryptonPanel();
            this.ktxtExceptionMessageLarge2 = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kpnlOptions = new Krypton.Toolkit.KryptonPanel();
            this.kbtnMoreDetails = new Krypton.Toolkit.KryptonButton();
            this.kbtnSimpleCopyDetails = new Krypton.Toolkit.KryptonButton();
            this.kbtnSimpleEMail = new Krypton.Toolkit.KryptonButton();
            this.klblContactCompany = new Krypton.Toolkit.KryptonLabel();
            this.kryptonNavigator1 = new Krypton.Navigator.KryptonNavigator();
            this.kpGeneral = new Krypton.Navigator.KryptonPage();
            this.ktxtUserExplanation = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.kblTime = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kblDate = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kblRegion = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kblVersion = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kblApplication = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtExceptionMessage = new Krypton.Toolkit.KryptonTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.kpExceptions = new Krypton.Navigator.KryptonPage();
            this.kpAssemblies = new Krypton.Navigator.KryptonPage();
            this.lvAssemblies = new System.Windows.Forms.ListView();
            this.kpSystem = new Krypton.Navigator.KryptonPage();
            this.ktvEnvironment = new Krypton.Toolkit.KryptonTreeView();
            this.ktxtExceptionMessageLarge = new Krypton.Toolkit.KryptonTextBox();
            this.kbtnSave = new Krypton.Toolkit.KryptonButton();
            this.kbtnCopy = new Krypton.Toolkit.KryptonButton();
            this.kbtnDetailToggle = new Krypton.Toolkit.KryptonButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlLessDetails)).BeginInit();
            this.kpnlLessDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlOptions)).BeginInit();
            this.kpnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpGeneral)).BeginInit();
            this.kpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpExceptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpAssemblies)).BeginInit();
            this.kpAssemblies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpSystem)).BeginInit();
            this.kpSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 394);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(551, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(434, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Loading system information...";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnDetailToggle);
            this.kryptonPanel1.Controls.Add(this.kbtnCopy);
            this.kryptonPanel1.Controls.Add(this.kbtnSave);
            this.kryptonPanel1.Controls.Add(this.kbtnEMail);
            this.kryptonPanel1.Controls.Add(this.kbtnClose);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 357);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(551, 37);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnEMail
            // 
            this.kbtnEMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnEMail.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnEMail.Location = new System.Drawing.Point(353, 6);
            this.kbtnEMail.Name = "kbtnEMail";
            this.kbtnEMail.Size = new System.Drawing.Size(90, 25);
            this.kbtnEMail.TabIndex = 1;
            this.kbtnEMail.Values.Text = "E-&Mail";
            // 
            // kbtnClose
            // 
            this.kbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnClose.Location = new System.Drawing.Point(449, 6);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(90, 25);
            this.kbtnClose.TabIndex = 0;
            this.kbtnClose.Values.Text = "&Close";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 354);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 3);
            this.panel1.TabIndex = 2;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kpnlLessDetails);
            this.kryptonPanel2.Controls.Add(this.kryptonNavigator1);
            this.kryptonPanel2.Controls.Add(this.ktxtExceptionMessageLarge);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(551, 354);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // kpnlLessDetails
            // 
            this.kpnlLessDetails.Controls.Add(this.ktxtExceptionMessageLarge2);
            this.kpnlLessDetails.Controls.Add(this.kryptonLabel1);
            this.kpnlLessDetails.Controls.Add(this.pictureBox1);
            this.kpnlLessDetails.Controls.Add(this.kpnlOptions);
            this.kpnlLessDetails.Location = new System.Drawing.Point(0, 0);
            this.kpnlLessDetails.Name = "kpnlLessDetails";
            this.kpnlLessDetails.Size = new System.Drawing.Size(400, 200);
            this.kpnlLessDetails.StateCommon.Color1 = System.Drawing.Color.White;
            this.kpnlLessDetails.TabIndex = 0;
            // 
            // ktxtExceptionMessageLarge2
            // 
            this.ktxtExceptionMessageLarge2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktxtExceptionMessageLarge2.Location = new System.Drawing.Point(83, 46);
            this.ktxtExceptionMessageLarge2.Multiline = true;
            this.ktxtExceptionMessageLarge2.Name = "ktxtExceptionMessageLarge2";
            this.ktxtExceptionMessageLarge2.ReadOnly = true;
            this.ktxtExceptionMessageLarge2.Size = new System.Drawing.Size(302, 69);
            this.ktxtExceptionMessageLarge2.TabIndex = 3;
            this.ktxtExceptionMessageLarge2.Text = "No message";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(83, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(158, 26);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Operation Failed";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Krypton.Toolkit.Suite.Extended.Error.Reporting.Properties.Resources.Warning_64_x_58;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // kpnlOptions
            // 
            this.kpnlOptions.Controls.Add(this.kbtnMoreDetails);
            this.kpnlOptions.Controls.Add(this.kbtnSimpleCopyDetails);
            this.kpnlOptions.Controls.Add(this.kbtnSimpleEMail);
            this.kpnlOptions.Controls.Add(this.klblContactCompany);
            this.kpnlOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlOptions.Location = new System.Drawing.Point(0, 121);
            this.kpnlOptions.Name = "kpnlOptions";
            this.kpnlOptions.Size = new System.Drawing.Size(400, 79);
            this.kpnlOptions.TabIndex = 0;
            // 
            // kbtnMoreDetails
            // 
            this.kbtnMoreDetails.Location = new System.Drawing.Point(103, 42);
            this.kbtnMoreDetails.Name = "kbtnMoreDetails";
            this.kbtnMoreDetails.Size = new System.Drawing.Size(90, 25);
            this.kbtnMoreDetails.TabIndex = 3;
            this.kbtnMoreDetails.Values.Text = "&More Details";
            // 
            // kbtnSimpleCopyDetails
            // 
            this.kbtnSimpleCopyDetails.Location = new System.Drawing.Point(199, 42);
            this.kbtnSimpleCopyDetails.Name = "kbtnSimpleCopyDetails";
            this.kbtnSimpleCopyDetails.Size = new System.Drawing.Size(90, 25);
            this.kbtnSimpleCopyDetails.TabIndex = 2;
            this.kbtnSimpleCopyDetails.Values.Text = "Copy &Details";
            // 
            // kbtnSimpleEMail
            // 
            this.kbtnSimpleEMail.Location = new System.Drawing.Point(295, 42);
            this.kbtnSimpleEMail.Name = "kbtnSimpleEMail";
            this.kbtnSimpleEMail.Size = new System.Drawing.Size(90, 25);
            this.kbtnSimpleEMail.TabIndex = 1;
            this.kbtnSimpleEMail.Values.Text = "&E-Mail";
            // 
            // klblContactCompany
            // 
            this.klblContactCompany.Location = new System.Drawing.Point(13, 11);
            this.klblContactCompany.Name = "klblContactCompany";
            this.klblContactCompany.Size = new System.Drawing.Size(155, 20);
            this.klblContactCompany.TabIndex = 0;
            this.klblContactCompany.Values.Text = "<##COMPANY-NAME##>";
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Location = new System.Drawing.Point(13, 13);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kpGeneral,
            this.kpExceptions,
            this.kpAssemblies,
            this.kpSystem});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(526, 335);
            this.kryptonNavigator1.TabIndex = 2;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kpGeneral
            // 
            this.kpGeneral.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpGeneral.Controls.Add(this.ktxtUserExplanation);
            this.kpGeneral.Controls.Add(this.kryptonLabel7);
            this.kpGeneral.Controls.Add(this.kblTime);
            this.kpGeneral.Controls.Add(this.kryptonLabel5);
            this.kpGeneral.Controls.Add(this.kblDate);
            this.kpGeneral.Controls.Add(this.kryptonLabel6);
            this.kpGeneral.Controls.Add(this.kblRegion);
            this.kpGeneral.Controls.Add(this.kryptonLabel4);
            this.kpGeneral.Controls.Add(this.kblVersion);
            this.kpGeneral.Controls.Add(this.kryptonLabel3);
            this.kpGeneral.Controls.Add(this.kblApplication);
            this.kpGeneral.Controls.Add(this.kryptonLabel2);
            this.kpGeneral.Controls.Add(this.ktxtExceptionMessage);
            this.kpGeneral.Controls.Add(this.pictureBox2);
            this.kpGeneral.Flags = 65534;
            this.kpGeneral.LastVisibleSet = true;
            this.kpGeneral.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpGeneral.Name = "kpGeneral";
            this.kpGeneral.Size = new System.Drawing.Size(524, 308);
            this.kpGeneral.Text = "&General";
            this.kpGeneral.ToolTipTitle = "Page ToolTip";
            this.kpGeneral.UniqueName = "7ec5c377bc774cc1a902f9d23a7b3728";
            // 
            // ktxtUserExplanation
            // 
            this.ktxtUserExplanation.Location = new System.Drawing.Point(8, 211);
            this.ktxtUserExplanation.Multiline = true;
            this.ktxtUserExplanation.Name = "ktxtUserExplanation";
            this.ktxtUserExplanation.Size = new System.Drawing.Size(502, 85);
            this.ktxtUserExplanation.StateCommon.Back.Color1 = System.Drawing.Color.Cornsilk;
            this.ktxtUserExplanation.TabIndex = 15;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(8, 185);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel7.TabIndex = 14;
            this.kryptonLabel7.Values.Text = "Application:";
            // 
            // kblTime
            // 
            this.kblTime.AutoSize = false;
            this.kblTime.BackColor = System.Drawing.Color.Transparent;
            this.kblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kblTime.Location = new System.Drawing.Point(336, 150);
            this.kblTime.Name = "kblTime";
            this.kblTime.Size = new System.Drawing.Size(135, 25);
            this.kblTime.TabIndex = 13;
            this.kblTime.Values.Text = "{0}";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(255, 150);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(40, 20);
            this.kryptonLabel5.TabIndex = 12;
            this.kryptonLabel5.Values.Text = "Time:";
            // 
            // kblDate
            // 
            this.kblDate.AutoSize = false;
            this.kblDate.BackColor = System.Drawing.Color.Transparent;
            this.kblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kblDate.Location = new System.Drawing.Point(89, 150);
            this.kblDate.Name = "kblDate";
            this.kblDate.Size = new System.Drawing.Size(135, 25);
            this.kblDate.TabIndex = 11;
            this.kblDate.Values.Text = "{0}";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(8, 150);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(39, 20);
            this.kryptonLabel6.TabIndex = 10;
            this.kryptonLabel6.Values.Text = "Date:";
            // 
            // kblRegion
            // 
            this.kblRegion.AutoSize = false;
            this.kblRegion.BackColor = System.Drawing.Color.Transparent;
            this.kblRegion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kblRegion.Location = new System.Drawing.Point(336, 119);
            this.kblRegion.Name = "kblRegion";
            this.kblRegion.Size = new System.Drawing.Size(135, 25);
            this.kblRegion.TabIndex = 9;
            this.kblRegion.Values.Text = "{0}";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(255, 119);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Region:";
            // 
            // kblVersion
            // 
            this.kblVersion.AutoSize = false;
            this.kblVersion.BackColor = System.Drawing.Color.Transparent;
            this.kblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kblVersion.Location = new System.Drawing.Point(89, 119);
            this.kblVersion.Name = "kblVersion";
            this.kblVersion.Size = new System.Drawing.Size(135, 25);
            this.kblVersion.TabIndex = 7;
            this.kblVersion.Values.Text = "{0}";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(8, 119);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Values.Text = "Version:";
            // 
            // kblApplication
            // 
            this.kblApplication.AutoSize = false;
            this.kblApplication.BackColor = System.Drawing.Color.Transparent;
            this.kblApplication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kblApplication.Location = new System.Drawing.Point(89, 82);
            this.kblApplication.Name = "kblApplication";
            this.kblApplication.Size = new System.Drawing.Size(421, 25);
            this.kblApplication.TabIndex = 5;
            this.kblApplication.Values.Text = "{0}";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(8, 82);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Application:";
            // 
            // ktxtExceptionMessage
            // 
            this.ktxtExceptionMessage.Location = new System.Drawing.Point(79, 7);
            this.ktxtExceptionMessage.Multiline = true;
            this.ktxtExceptionMessage.Name = "ktxtExceptionMessage";
            this.ktxtExceptionMessage.ReadOnly = true;
            this.ktxtExceptionMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ktxtExceptionMessage.Size = new System.Drawing.Size(431, 68);
            this.ktxtExceptionMessage.TabIndex = 3;
            this.ktxtExceptionMessage.Text = "No message";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Krypton.Toolkit.Suite.Extended.Error.Reporting.Properties.Resources.Warning_64_x_58;
            this.pictureBox2.Location = new System.Drawing.Point(8, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // kpExceptions
            // 
            this.kpExceptions.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpExceptions.Flags = 65534;
            this.kpExceptions.LastVisibleSet = true;
            this.kpExceptions.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpExceptions.Name = "kpExceptions";
            this.kpExceptions.Size = new System.Drawing.Size(524, 308);
            this.kpExceptions.Text = "Ex&ceptions";
            this.kpExceptions.ToolTipTitle = "Page ToolTip";
            this.kpExceptions.UniqueName = "8117034f67524705b7213e5c615e8987";
            // 
            // kpAssemblies
            // 
            this.kpAssemblies.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpAssemblies.Controls.Add(this.lvAssemblies);
            this.kpAssemblies.Flags = 65534;
            this.kpAssemblies.LastVisibleSet = true;
            this.kpAssemblies.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpAssemblies.Name = "kpAssemblies";
            this.kpAssemblies.Size = new System.Drawing.Size(524, 308);
            this.kpAssemblies.Text = "Ass&emblies";
            this.kpAssemblies.ToolTipTitle = "Page ToolTip";
            this.kpAssemblies.UniqueName = "0b764967cdbf46089d42840dac075331";
            // 
            // lvAssemblies
            // 
            this.lvAssemblies.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAssemblies.FullRowSelect = true;
            this.lvAssemblies.HideSelection = false;
            this.lvAssemblies.HotTracking = true;
            this.lvAssemblies.HoverSelection = true;
            this.lvAssemblies.Location = new System.Drawing.Point(0, 0);
            this.lvAssemblies.Name = "lvAssemblies";
            this.lvAssemblies.Size = new System.Drawing.Size(524, 308);
            this.lvAssemblies.TabIndex = 22;
            this.lvAssemblies.UseCompatibleStateImageBehavior = false;
            this.lvAssemblies.View = System.Windows.Forms.View.Details;
            // 
            // kpSystem
            // 
            this.kpSystem.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpSystem.Controls.Add(this.ktvEnvironment);
            this.kpSystem.Flags = 65534;
            this.kpSystem.LastVisibleSet = true;
            this.kpSystem.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpSystem.Name = "kpSystem";
            this.kpSystem.Size = new System.Drawing.Size(524, 308);
            this.kpSystem.Text = "S&ystem";
            this.kpSystem.ToolTipTitle = "Page ToolTip";
            this.kpSystem.UniqueName = "c9fcf23c0d3b4c7d8d45ffbb9212277e";
            // 
            // ktvEnvironment
            // 
            this.ktvEnvironment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktvEnvironment.HotTracking = true;
            this.ktvEnvironment.Location = new System.Drawing.Point(0, 0);
            this.ktvEnvironment.Name = "ktvEnvironment";
            this.ktvEnvironment.Size = new System.Drawing.Size(524, 308);
            this.ktvEnvironment.TabIndex = 0;
            // 
            // ktxtExceptionMessageLarge
            // 
            this.ktxtExceptionMessageLarge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktxtExceptionMessageLarge.Location = new System.Drawing.Point(13, 12);
            this.ktxtExceptionMessageLarge.Multiline = true;
            this.ktxtExceptionMessageLarge.Name = "ktxtExceptionMessageLarge";
            this.ktxtExceptionMessageLarge.ReadOnly = true;
            this.ktxtExceptionMessageLarge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ktxtExceptionMessageLarge.Size = new System.Drawing.Size(526, 336);
            this.ktxtExceptionMessageLarge.TabIndex = 1;
            this.ktxtExceptionMessageLarge.Text = "No message";
            // 
            // kbtnSave
            // 
            this.kbtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnSave.Location = new System.Drawing.Point(257, 6);
            this.kbtnSave.Name = "kbtnSave";
            this.kbtnSave.Size = new System.Drawing.Size(90, 25);
            this.kbtnSave.TabIndex = 2;
            this.kbtnSave.Values.Text = "S&ave";
            // 
            // kbtnCopy
            // 
            this.kbtnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCopy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCopy.Location = new System.Drawing.Point(161, 6);
            this.kbtnCopy.Name = "kbtnCopy";
            this.kbtnCopy.Size = new System.Drawing.Size(90, 25);
            this.kbtnCopy.TabIndex = 3;
            this.kbtnCopy.Values.Text = "Co&py";
            // 
            // kbtnDetailToggle
            // 
            this.kbtnDetailToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnDetailToggle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnDetailToggle.Location = new System.Drawing.Point(65, 6);
            this.kbtnDetailToggle.Name = "kbtnDetailToggle";
            this.kbtnDetailToggle.Size = new System.Drawing.Size(90, 25);
            this.kbtnDetailToggle.TabIndex = 4;
            this.kbtnDetailToggle.Values.Text = "&Less Detils";
            // 
            // ExceptionReportView
            // 
            this.ClientSize = new System.Drawing.Size(551, 416);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionReportView";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ExceptionReportView_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlLessDetails)).EndInit();
            this.kpnlLessDetails.ResumeLayout(false);
            this.kpnlLessDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlOptions)).EndInit();
            this.kpnlOptions.ResumeLayout(false);
            this.kpnlOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpGeneral)).EndInit();
            this.kpGeneral.ResumeLayout(false);
            this.kpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpExceptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpAssemblies)).EndInit();
            this.kpAssemblies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpSystem)).EndInit();
            this.kpSystem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ExceptionReportView_Load(object sender, EventArgs e)
        {

        }
    }
}
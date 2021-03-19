using Krypton.Navigator;
using Krypton.Toolkit.Suite.Extended.Base;
using Krypton.Toolkit.Suite.Extended.Error.Reporting.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    public class ExceptionReportView : KryptonFormExtended, IExceptionReportView
    {
        #region Design Code  
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslProgressMessage;
        private System.Windows.Forms.ToolStripProgressBar tspbProgress;
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
        private Navigator.KryptonNavigator knContent;
        private Navigator.KryptonPage kpGeneral;
        private Navigator.KryptonPage kpExceptions;
        private KryptonTextBox ktxtExceptionMessageLarge;
        private KryptonTextBox ktxtUserExplanation;
        private KryptonLabel klblExplanation;
        private KryptonBorderedLabel kblTime;
        private KryptonLabel kryptonLabel5;
        private KryptonBorderedLabel kblDate;
        private KryptonLabel kryptonLabel6;
        private KryptonBorderedLabel kblRegion;
        private KryptonLabel kryptonLabel4;
        private KryptonBorderedLabel kblVersion;
        private KryptonLabel kryptonLabel3;
        private KryptonBorderedLabel kblApplicationName;
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
            this.tsslProgressMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnDetailToggle = new Krypton.Toolkit.KryptonButton();
            this.kbtnCopy = new Krypton.Toolkit.KryptonButton();
            this.kbtnSave = new Krypton.Toolkit.KryptonButton();
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
            this.knContent = new Krypton.Navigator.KryptonNavigator();
            this.kpGeneral = new Krypton.Navigator.KryptonPage();
            this.ktxtUserExplanation = new Krypton.Toolkit.KryptonTextBox();
            this.klblExplanation = new Krypton.Toolkit.KryptonLabel();
            this.kblTime = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kblDate = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kblRegion = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kblVersion = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kblApplicationName = new Krypton.Toolkit.Suite.Extended.Base.KryptonBorderedLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtExceptionMessage = new Krypton.Toolkit.KryptonTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.kpExceptions = new Krypton.Navigator.KryptonPage();
            this.kpAssemblies = new Krypton.Navigator.KryptonPage();
            this.lvAssemblies = new System.Windows.Forms.ListView();
            this.kpSystem = new Krypton.Navigator.KryptonPage();
            this.ktvEnvironment = new Krypton.Toolkit.KryptonTreeView();
            this.ktxtExceptionMessageLarge = new Krypton.Toolkit.KryptonTextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.knContent)).BeginInit();
            this.knContent.SuspendLayout();
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
            this.tsslProgressMessage,
            this.tspbProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 394);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(551, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslProgressMessage
            // 
            this.tsslProgressMessage.Name = "tsslProgressMessage";
            this.tsslProgressMessage.Size = new System.Drawing.Size(434, 17);
            this.tsslProgressMessage.Spring = true;
            this.tsslProgressMessage.Text = "Loading system information...";
            this.tsslProgressMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspbProgress
            // 
            this.tspbProgress.Name = "tspbProgress";
            this.tspbProgress.Size = new System.Drawing.Size(100, 16);
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
            this.kryptonPanel2.Controls.Add(this.knContent);
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
            // knContent
            // 
            this.knContent.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.knContent.Location = new System.Drawing.Point(13, 13);
            this.knContent.Name = "knContent";
            this.knContent.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kpGeneral,
            this.kpExceptions,
            this.kpAssemblies,
            this.kpSystem});
            this.knContent.SelectedIndex = 0;
            this.knContent.Size = new System.Drawing.Size(526, 335);
            this.knContent.TabIndex = 2;
            this.knContent.Text = "kryptonNavigator1";
            // 
            // kpGeneral
            // 
            this.kpGeneral.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpGeneral.Controls.Add(this.ktxtUserExplanation);
            this.kpGeneral.Controls.Add(this.klblExplanation);
            this.kpGeneral.Controls.Add(this.kblTime);
            this.kpGeneral.Controls.Add(this.kryptonLabel5);
            this.kpGeneral.Controls.Add(this.kblDate);
            this.kpGeneral.Controls.Add(this.kryptonLabel6);
            this.kpGeneral.Controls.Add(this.kblRegion);
            this.kpGeneral.Controls.Add(this.kryptonLabel4);
            this.kpGeneral.Controls.Add(this.kblVersion);
            this.kpGeneral.Controls.Add(this.kryptonLabel3);
            this.kpGeneral.Controls.Add(this.kblApplicationName);
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
            // klblExplanation
            // 
            this.klblExplanation.Location = new System.Drawing.Point(8, 185);
            this.klblExplanation.Name = "klblExplanation";
            this.klblExplanation.Size = new System.Drawing.Size(390, 20);
            this.klblExplanation.TabIndex = 14;
            this.klblExplanation.Values.Text = "Please enter a brief explanation of events leading up to this exception";
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
            // kblApplicationName
            // 
            this.kblApplicationName.AutoSize = false;
            this.kblApplicationName.BackColor = System.Drawing.Color.Transparent;
            this.kblApplicationName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kblApplicationName.Location = new System.Drawing.Point(89, 82);
            this.kblApplicationName.Name = "kblApplicationName";
            this.kblApplicationName.Size = new System.Drawing.Size(421, 25);
            this.kblApplicationName.TabIndex = 5;
            this.kblApplicationName.Values.Text = "{0}";
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExceptionReportView_KeyDown);
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
            ((System.ComponentModel.ISupportInitialize)(this.knContent)).EndInit();
            this.knContent.ResumeLayout(false);
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
        #endregion

        #region Variables
        private bool _isDataRefreshRequired;
        private readonly ExceptionReportPresenter _presenter;
        #endregion

        #region Properties
        public string ProgressMessage
        {
            set
            {
                tsslProgressMessage.Visible = true;
                tsslProgressMessage.Text = value;
            }
        }

        public bool EnableEmailButton { set => kbtnEMail.Enabled = value; }

        public bool ShowProgressBar { set => tspbProgress.Visible = value; }

        private bool ShowProgressLabel { set => tsslProgressMessage.Visible = value; }

        public bool ShowFullDetail { get; set; }

        public string UserExplanation => ktxtUserExplanation.Text;
        #endregion

        #region Constructor
        public ExceptionReportView(ExceptionReportInfo reportInfo)
        {
            ShowFullDetail = true;
            InitializeComponent();
            TopMost = reportInfo.TopMost;

            _presenter = new ExceptionReportPresenter(this, reportInfo);

            WireUpEvents();
            PopulateTabs();
            PopulateReportInfo(reportInfo);
        }
        #endregion

        #region Methods
        private void PopulateReportInfo(ExceptionReportInfo reportInfo)
        {
            klblExplanation.Text = reportInfo.UserExplanationLabel;
            ShowFullDetail = reportInfo.ShowFullDetail;
            ToggleShowFullDetail();
            kbtnDetailToggle.Visible = reportInfo.ShowLessDetailButton;

            //TODO: show all exception messages
            ktxtExceptionMessageLarge.Text =
                ktxtExceptionMessage.Text =
                    !string.IsNullOrEmpty(reportInfo.CustomMessage) ? reportInfo.CustomMessage : reportInfo.Exceptions.First().Message;

            ktxtExceptionMessageLarge2.Text = ktxtExceptionMessageLarge.Text;

            kblDate.Text = reportInfo.ExceptionDate.ToShortDateString();
            kblTime.Text = reportInfo.ExceptionDate.ToShortTimeString();
            kblRegion.Text = reportInfo.RegionInfo;
            kblApplicationName.Text = reportInfo.AppName;
            kblVersion.Text = reportInfo.AppVersion;


            /*btnClose.FlatStyle =
				btnDetailToggle.FlatStyle =
					btnCopy.FlatStyle =
						btnEmail.FlatStyle =
							btnSave.FlatStyle = reportInfo.ShowFlatButtons ? FlatStyle.Flat : FlatStyle.Standard;*/

            lvAssemblies.BackColor =
                kblRegion.BackColor =
                    kblTime.BackColor =
                        kblTime.BackColor =
                            kblVersion.BackColor =
                                kblApplicationName.BackColor =
                                    kblDate.BackColor =
                                        ktxtExceptionMessageLarge.BackColor =
                                            ktxtExceptionMessage.BackColor = reportInfo.BackgroundColor;

            if (!reportInfo.ShowButtonIcons)
            {
                RemoveButtonIcons();
            }

            if (!reportInfo.ShowEmailButton)
            {
                RemoveEmailButton();
            }

            Text = reportInfo.TitleText;
            ktxtUserExplanation.Font = new Font(ktxtUserExplanation.Font.FontFamily, reportInfo.UserExplanationFontSize);
            //lblContactCompany.Text =
            //	string.Format("If this problem persists, please contact {0} support.", reportInfo.CompanyName);
            klblContactCompany.Text =
                string.Format(
                    Strings.ExceptionReportView_PopulateReportInfo_If_this_problem_persists__please_contact__0__support_ +
                    Environment.NewLine, reportInfo.CompanyName);
            kbtnSimpleEMail.Text = string.Format("{0} {1}",
                reportInfo.SendMethod == ReportSendMethod.WebService ? Strings.Send : "Email",
                reportInfo.SendMethod == ReportSendMethod.WebService && !reportInfo.CompanyName.IsEmpty()
                    ? string.Format(Strings.to__0_, reportInfo.CompanyName)
                    : reportInfo.CompanyName);
            kbtnEMail.Text = reportInfo.SendMethod == ReportSendMethod.WebService ? Strings.Send : "Email";
        }

        private void RemoveEmailButton()
        {
            kbtnSimpleEMail.Hide();
            kbtnEMail.Hide();
            kbtnCopy.Location = kbtnEMail.Location;
            kbtnSimpleCopyDetails.Location = kbtnSimpleEMail.Location;
        }

        private void RemoveButtonIcons()
        {
            // removing the icons, requires a bit of reshuffling of positions
            kbtnCopy.Values.Image = kbtnEMail.Values.Image = kbtnSave.Values.Image = null;

            kbtnClose.Height = kbtnDetailToggle.Height = kbtnCopy.Height = kbtnEMail.Height = kbtnSave.Height = 27;

            //kbtnClose.TextAlign = btnDetailToggle.TextAlign = btnCopy.TextAlign = btnEmail.TextAlign = btnSave.TextAlign = ContentAlignment.MiddleCenter;

            kbtnClose.StateCommon.Content.ShortText.Font = kbtnDetailToggle.StateCommon.Content.ShortText.Font = kbtnSave.StateCommon.Content.ShortText.Font = kbtnEMail.StateCommon.Content.ShortText.Font = kbtnCopy.StateCommon.Content.ShortText.Font = new Font(kbtnCopy.StateCommon.Content.ShortText.Font.FontFamily, 8.25f);

            ShiftDown3Pixels(new[] { kbtnClose, kbtnDetailToggle, kbtnCopy, kbtnEMail, kbtnSave });
        }

        private static void ShiftDown3Pixels(IEnumerable<Control> buttons)
        {
            foreach (var button in buttons)
            {
                button.Location = Point.Add(button.Location, new Size(new Point(0, 3)));
            }
        }

        private void WireUpEvents()
        {
            kbtnEMail.Click += Email_Click;
            kbtnSimpleEMail.Click += Email_Click;
            kbtnCopy.Click += Copy_Click;
            kbtnSimpleCopyDetails.Click += Copy_Click;
            kbtnClose.Click += Close_Click;
            kbtnDetailToggle.Click += Detail_Click;
            kbtnMoreDetails.Click += Detail_Click;
            kbtnSave.Click += Save_Click;
            KeyPreview = true;
            KeyDown += ExceptionReportView_KeyDown;
        }

        /// <summary>
        /// starts with all tabs visible, and removes ones that aren't configured to show
        /// </summary>
        private void PopulateTabs()
        {
            if (!_presenter.ReportInfo.ShowGeneralTab)
            {
                knContent.Pages.Remove(kpGeneral);
            }
            if (!_presenter.ReportInfo.ShowExceptionsTab)
            {
                knContent.Pages.Remove(kpExceptions);
            }
            if (!_presenter.ReportInfo.ShowAssembliesTab)
            {
                knContent.Pages.Remove(kpAssemblies);
            }
            if (!_presenter.ReportInfo.ShowSysInfoTab)
            {
                knContent.Pages.Remove(kpSystem);
            }
        }

        public void ToggleShowFullDetail()
        {
            if (ShowFullDetail)
            {
                kpnlLessDetails.Hide();
                kbtnDetailToggle.Text = Strings.ExceptionReportView_ToggleShowFullDetail_Less_Detail;
                knContent.Visible = true;
                Size = new Size(625, 456);
            }
            else
            {
                kpnlLessDetails.Show();
                kbtnDetailToggle.Text = Strings.ExceptionReportView_ToggleShowFullDetail_More_Detail;
                knContent.Visible = false;
                Size = new Size(415, 235);
            }
        }
        #endregion

        private void ExceptionReportView_Load(object sender, EventArgs e)
        {

        }

        #region IExceptionReportView Implementation
        public void MapiSendCompleted()
        {
            Completed(true);

            ProgressMessage = string.Empty;
        }

        public void SetProgressCompleteState()
        {
            Cursor = Cursors.Default;
            ShowProgressLabel = ShowProgressBar = false;
        }

        public void ShowWindow()
        {
            _isDataRefreshRequired = true;
            ShowDialog();
        }

        public void SetInProgressState()
        {
            Cursor = Cursors.WaitCursor;
            ShowProgressLabel = true;
            ShowProgressBar = true;
            Application.DoEvents();
        }

        public void PopulateExceptionTab(IEnumerable<Exception> exceptions)
        {
            var exs = exceptions as Exception[] ?? exceptions.ToArray();
            if (exs.Length == 1)
            {
                var exception = exs.FirstOrDefault();
                AddExceptionControl(knContent, exception);
            }
            else
            {
                var innerTabControl = new KryptonNavigator { Dock = DockStyle.Fill };
                kpExceptions.Controls.Add(innerTabControl);
                for (var index = 0; index < exs.Length; index++)
                {
                    var exception = exs[index];
                    var tabPage = new KryptonPage { Text = $"Exception {  index + 1 }" };
                    innerTabControl.Pages.Add(tabPage);
                    AddExceptionControl(tabPage, exception);
                }
            }
        }

        private void AddExceptionControl(Control control, Exception exception)
        {
            var exceptionDetail = new ExceptionDetailControl();
            exceptionDetail.SetControlBackgrounds(_presenter.ReportInfo.BackgroundColor);
            exceptionDetail.PopulateExceptionTab(exception);
            exceptionDetail.Dock = DockStyle.Fill;
            control.Controls.Add(exceptionDetail);
        }

        public void PopulateAssembliesTab()
        {
            lvAssemblies.Clear();
            lvAssemblies.Columns.Add("Name", 320, HorizontalAlignment.Left);
            lvAssemblies.Columns.Add("Version", 150, HorizontalAlignment.Left);

            _presenter.GetReferencedAssemblies().ForEach(this.AddAssembly);
        }

        private void AddAssembly(AssemblyRef assembly)
        {
            var listViewItem = new ListViewItem
            {
                Text = assembly.Name
            };
            listViewItem.SubItems.Add(assembly.Version);
            lvAssemblies.Items.Add(listViewItem);
        }

        private KryptonTreeNode CreateSysInfoTree()
        {
            var rootNode = new KryptonTreeNode("System");

            foreach (var sysInfoResult in _presenter.GetSysInfoResults())
            {
                SysInfoResultMapper.AddTreeViewNode(rootNode, sysInfoResult);
            }

            return rootNode;
        }

        public void PopulateSysInfoTab()
        {
            var rootNode = CreateSysInfoTree();
            ktvEnvironment.Nodes.Add(rootNode);
            rootNode.Expand();
        }

        public void Completed(bool success)
        {
            ProgressMessage = success ? Strings.Report_sent : Strings.Failed_to_send_report;
            ShowProgressBar = false;
            kbtnEMail.Enabled = true;
        }

        public void ShowError(string message, Exception exception) => KryptonMessageBoxExtended.Show(message, Strings.ExceptionReportView_ShowError_Error_sending_report, MessageBoxButtons.OK, MessageBoxIcon.Error);
        #endregion

        #region Event Handlers
        private void ExceptionReportView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            _presenter.CopyReportToClipboard();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Detail_Click(object sender, EventArgs e)
        {
            _presenter.ToggleDetail();
        }

        private void Email_Click(object sender, EventArgs e)
        {
            _presenter.SendReport();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                _presenter.SaveReportToFile(saveDialog.FileName);
            }
        }
        #endregion

        #region Overrides
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            // this is to make it so the LessDetail view is fixed (it's design doesn't allow for resizing)
            // but MoreDetail is re-sizable
            FormBorderStyle = ShowFullDetail ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog;
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (_isDataRefreshRequired)
            {
                _isDataRefreshRequired = false;
                _presenter.PopulateReport();
            }
        }
        #endregion
    }
}

#pragma warning restore 1591
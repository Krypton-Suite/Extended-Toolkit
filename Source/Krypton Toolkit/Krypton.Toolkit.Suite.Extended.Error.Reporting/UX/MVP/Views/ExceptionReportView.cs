#pragma warning disable 1591
namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    public partial class ExceptionReportView : KryptonForm, IExceptionReportView
    {
        #region Design Code
        private KryptonPanel kpnlButtons;
        private KryptonButton kbtnElectronicMail;
        private KryptonButton kbtnClose;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonStatusStrip kryptonStatusStrip1;
        private ToolStripStatusLabel tslblProgressMessage;
        private KryptonButton kbtnLessDetail;
        private KryptonButton kbtnCopy;
        private KryptonButton kbtnSave;
        private KryptonPanel kpnlMain;
        private Navigator.KryptonNavigator kryptonNavigator1;
        private Navigator.KryptonPage kpGeneral;
        private Navigator.KryptonPage kpExceptions;
        private KryptonTextBox ktxtUserExplanation;
        private KryptonLabel klblExplanation;
        private KryptonTextBox ktxtTime;
        private KryptonLabel kryptonLabel4;
        private KryptonTextBox ktxtDate;
        private KryptonLabel kryptonLabel3;
        private KryptonTextBox ktxtVersion;
        private KryptonLabel kryptonLabel2;
        private KryptonTextBox ktxtApplicationName;
        private KryptonLabel kryptonLabel1;
        private KryptonTextBox ktxtExceptionMessage;
        private PictureBox picGeneral;
        private Navigator.KryptonPage kpAssemblies;
        private KryptonListView klvAssemblies;
        private Navigator.KryptonPage kpSystemInformation;
        private KryptonTreeView ktvEnvironment;
        private KryptonPanel kpnlLessDetails;
        private KryptonTextBox ktxtExceptionMessageLarge2;
        private KryptonLabel kryptonLabel6;
        private PictureBox lessDetail_alertIcon;
        private KryptonPanel kpnlLessDetail_optionsPanel;
        private KryptonBorderEdge kryptonBorderEdge2;
        private KryptonButton kbtnSimpleDetailToggle;
        private KryptonButton kbtnSimpleCopy;
        private KryptonButton kbtnSimpleEmail;
        private KryptonTextBox ktxtExceptionMessageLarge;
        private KryptonLabel klblContactCompany;
        private ToolStripProgressBar toolStripProgressBar1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionReportView));
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kbtnLessDetail = new Krypton.Toolkit.KryptonButton();
            this.kbtnCopy = new Krypton.Toolkit.KryptonButton();
            this.kbtnSave = new Krypton.Toolkit.KryptonButton();
            this.kbtnElectronicMail = new Krypton.Toolkit.KryptonButton();
            this.kbtnClose = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonStatusStrip1 = new Krypton.Toolkit.KryptonStatusStrip();
            this.tslblProgressMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.kpnlMain = new Krypton.Toolkit.KryptonPanel();
            this.kpnlLessDetails = new Krypton.Toolkit.KryptonPanel();
            this.ktxtExceptionMessageLarge2 = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.lessDetail_alertIcon = new System.Windows.Forms.PictureBox();
            this.kpnlLessDetail_optionsPanel = new Krypton.Toolkit.KryptonPanel();
            this.klblContactCompany = new Krypton.Toolkit.KryptonLabel();
            this.kbtnSimpleDetailToggle = new Krypton.Toolkit.KryptonButton();
            this.kbtnSimpleCopy = new Krypton.Toolkit.KryptonButton();
            this.kbtnSimpleEmail = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge2 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonNavigator1 = new Krypton.Navigator.KryptonNavigator();
            this.kpGeneral = new Krypton.Navigator.KryptonPage();
            this.ktxtUserExplanation = new Krypton.Toolkit.KryptonTextBox();
            this.klblExplanation = new Krypton.Toolkit.KryptonLabel();
            this.ktxtTime = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtDate = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtVersion = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtApplicationName = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtExceptionMessage = new Krypton.Toolkit.KryptonTextBox();
            this.picGeneral = new System.Windows.Forms.PictureBox();
            this.kpExceptions = new Krypton.Navigator.KryptonPage();
            this.kpAssemblies = new Krypton.Navigator.KryptonPage();
            this.klvAssemblies = new Krypton.Toolkit.KryptonListView();
            this.kpSystemInformation = new Krypton.Navigator.KryptonPage();
            this.ktvEnvironment = new Krypton.Toolkit.KryptonTreeView();
            this.ktxtExceptionMessageLarge = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            this.kryptonStatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).BeginInit();
            this.kpnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlLessDetails)).BeginInit();
            this.kpnlLessDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lessDetail_alertIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlLessDetail_optionsPanel)).BeginInit();
            this.kpnlLessDetail_optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpGeneral)).BeginInit();
            this.kpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpExceptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpAssemblies)).BeginInit();
            this.kpAssemblies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpSystemInformation)).BeginInit();
            this.kpSystemInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.kbtnLessDetail);
            this.kpnlButtons.Controls.Add(this.kbtnCopy);
            this.kpnlButtons.Controls.Add(this.kbtnSave);
            this.kpnlButtons.Controls.Add(this.kbtnElectronicMail);
            this.kpnlButtons.Controls.Add(this.kbtnClose);
            this.kpnlButtons.Controls.Add(this.kryptonBorderEdge1);
            this.kpnlButtons.Controls.Add(this.kryptonStatusStrip1);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 420);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlButtons.Size = new System.Drawing.Size(593, 74);
            this.kpnlButtons.TabIndex = 0;
            // 
            // kbtnLessDetail
            // 
            this.kbtnLessDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnLessDetail.Location = new System.Drawing.Point(119, 10);
            this.kbtnLessDetail.Name = "kbtnLessDetail";
            this.kbtnLessDetail.Size = new System.Drawing.Size(87, 39);
            this.kbtnLessDetail.TabIndex = 6;
            this.kbtnLessDetail.Values.Text = "Less Detai&l";
            // 
            // kbtnCopy
            // 
            this.kbtnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCopy.Location = new System.Drawing.Point(212, 10);
            this.kbtnCopy.Name = "kbtnCopy";
            this.kbtnCopy.Size = new System.Drawing.Size(87, 39);
            this.kbtnCopy.TabIndex = 5;
            this.kbtnCopy.Values.Image = global::Krypton.Toolkit.Suite.Extended.Error.Reporting.Properties.Resources.Copy;
            this.kbtnCopy.Values.Text = "Co&py";
            // 
            // kbtnSave
            // 
            this.kbtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSave.Location = new System.Drawing.Point(305, 10);
            this.kbtnSave.Name = "kbtnSave";
            this.kbtnSave.Size = new System.Drawing.Size(87, 39);
            this.kbtnSave.TabIndex = 4;
            this.kbtnSave.Values.Image = global::Krypton.Toolkit.Suite.Extended.Error.Reporting.Properties.Resources.Hard_Disk;
            this.kbtnSave.Values.Text = "S&ave";
            // 
            // kbtnElectronicMail
            // 
            this.kbtnElectronicMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnElectronicMail.Location = new System.Drawing.Point(398, 10);
            this.kbtnElectronicMail.Name = "kbtnElectronicMail";
            this.kbtnElectronicMail.Size = new System.Drawing.Size(87, 39);
            this.kbtnElectronicMail.TabIndex = 3;
            this.kbtnElectronicMail.Values.Image = global::Krypton.Toolkit.Suite.Extended.Error.Reporting.Properties.Resources.Forward;
            this.kbtnElectronicMail.Values.Text = "&E-Mail";
            // 
            // kbtnClose
            // 
            this.kbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnClose.Location = new System.Drawing.Point(491, 10);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(90, 39);
            this.kbtnClose.TabIndex = 2;
            this.kbtnClose.Values.Text = "&Close";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(593, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonStatusStrip1
            // 
            this.kryptonStatusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonStatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblProgressMessage,
            this.toolStripProgressBar1});
            this.kryptonStatusStrip1.Location = new System.Drawing.Point(0, 52);
            this.kryptonStatusStrip1.Name = "kryptonStatusStrip1";
            this.kryptonStatusStrip1.ProgressBars = null;
            this.kryptonStatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.kryptonStatusStrip1.Size = new System.Drawing.Size(593, 22);
            this.kryptonStatusStrip1.TabIndex = 0;
            this.kryptonStatusStrip1.Text = "kryptonStatusStrip1";
            // 
            // tslblProgressMessage
            // 
            this.tslblProgressMessage.Name = "tslblProgressMessage";
            this.tslblProgressMessage.Size = new System.Drawing.Size(476, 17);
            this.tslblProgressMessage.Spring = true;
            this.tslblProgressMessage.Text = "Loading system information...";
            this.tslblProgressMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // kpnlMain
            // 
            this.kpnlMain.Controls.Add(this.kryptonNavigator1);
            this.kpnlMain.Controls.Add(this.ktxtExceptionMessageLarge);
            this.kpnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlMain.Location = new System.Drawing.Point(0, 0);
            this.kpnlMain.Name = "kpnlMain";
            this.kpnlMain.Size = new System.Drawing.Size(593, 420);
            this.kpnlMain.TabIndex = 1;
            // 
            // kpnlLessDetails
            // 
            this.kpnlLessDetails.Controls.Add(this.ktxtExceptionMessageLarge2);
            this.kpnlLessDetails.Controls.Add(this.kryptonLabel6);
            this.kpnlLessDetails.Controls.Add(this.lessDetail_alertIcon);
            this.kpnlLessDetails.Controls.Add(this.kpnlLessDetail_optionsPanel);
            this.kpnlLessDetails.Location = new System.Drawing.Point(0, 0);
            this.kpnlLessDetails.Name = "kpnlLessDetails";
            this.kpnlLessDetails.Size = new System.Drawing.Size(507, 230);
            this.kpnlLessDetails.StateCommon.Color1 = System.Drawing.Color.White;
            this.kpnlLessDetails.StateCommon.Color2 = System.Drawing.Color.White;
            this.kpnlLessDetails.TabIndex = 1;
            // 
            // ktxtExceptionMessageLarge2
            // 
            this.ktxtExceptionMessageLarge2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktxtExceptionMessageLarge2.Location = new System.Drawing.Point(84, 66);
            this.ktxtExceptionMessageLarge2.Multiline = true;
            this.ktxtExceptionMessageLarge2.Name = "ktxtExceptionMessageLarge2";
            this.ktxtExceptionMessageLarge2.ReadOnly = true;
            this.ktxtExceptionMessageLarge2.Size = new System.Drawing.Size(415, 69);
            this.ktxtExceptionMessageLarge2.TabIndex = 28;
            this.ktxtExceptionMessageLarge2.Text = "kryptonTextBox1";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(84, 33);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(158, 26);
            this.kryptonLabel6.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 27;
            this.kryptonLabel6.Values.Text = "Operation Failed";
            // 
            // lessDetail_alertIcon
            // 
            this.lessDetail_alertIcon.BackColor = System.Drawing.Color.Transparent;
            this.lessDetail_alertIcon.Image = global::Krypton.Toolkit.Suite.Extended.Error.Reporting.Properties.Resources.Warning;
            this.lessDetail_alertIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lessDetail_alertIcon.Location = new System.Drawing.Point(11, 15);
            this.lessDetail_alertIcon.Name = "lessDetail_alertIcon";
            this.lessDetail_alertIcon.Size = new System.Drawing.Size(64, 64);
            this.lessDetail_alertIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.lessDetail_alertIcon.TabIndex = 26;
            this.lessDetail_alertIcon.TabStop = false;
            // 
            // kpnlLessDetail_optionsPanel
            // 
            this.kpnlLessDetail_optionsPanel.Controls.Add(this.klblContactCompany);
            this.kpnlLessDetail_optionsPanel.Controls.Add(this.kbtnSimpleDetailToggle);
            this.kpnlLessDetail_optionsPanel.Controls.Add(this.kbtnSimpleCopy);
            this.kpnlLessDetail_optionsPanel.Controls.Add(this.kbtnSimpleEmail);
            this.kpnlLessDetail_optionsPanel.Controls.Add(this.kryptonBorderEdge2);
            this.kpnlLessDetail_optionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlLessDetail_optionsPanel.Location = new System.Drawing.Point(0, 141);
            this.kpnlLessDetail_optionsPanel.Name = "kpnlLessDetail_optionsPanel";
            this.kpnlLessDetail_optionsPanel.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlLessDetail_optionsPanel.Size = new System.Drawing.Size(507, 89);
            this.kpnlLessDetail_optionsPanel.TabIndex = 0;
            // 
            // klblContactCompany
            // 
            this.klblContactCompany.Location = new System.Drawing.Point(17, 4);
            this.klblContactCompany.Name = "klblContactCompany";
            this.klblContactCompany.Size = new System.Drawing.Size(6, 2);
            this.klblContactCompany.TabIndex = 4;
            this.klblContactCompany.Values.Text = "";
            // 
            // kbtnSimpleDetailToggle
            // 
            this.kbtnSimpleDetailToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSimpleDetailToggle.Location = new System.Drawing.Point(94, 32);
            this.kbtnSimpleDetailToggle.Name = "kbtnSimpleDetailToggle";
            this.kbtnSimpleDetailToggle.Size = new System.Drawing.Size(131, 49);
            this.kbtnSimpleDetailToggle.TabIndex = 3;
            this.kbtnSimpleDetailToggle.Values.Image = global::Krypton.Toolkit.Suite.Extended.Error.Reporting.Properties.Resources.Add;
            this.kbtnSimpleDetailToggle.Values.Text = "M&ore Details";
            // 
            // kbtnSimpleCopy
            // 
            this.kbtnSimpleCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSimpleCopy.Location = new System.Drawing.Point(231, 32);
            this.kbtnSimpleCopy.Name = "kbtnSimpleCopy";
            this.kbtnSimpleCopy.Size = new System.Drawing.Size(131, 49);
            this.kbtnSimpleCopy.TabIndex = 2;
            this.kbtnSimpleCopy.Values.Image = global::Krypton.Toolkit.Suite.Extended.Error.Reporting.Properties.Resources.Copy;
            this.kbtnSimpleCopy.Values.Text = "&Copy Details";
            // 
            // kbtnSimpleEmail
            // 
            this.kbtnSimpleEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSimpleEmail.Location = new System.Drawing.Point(368, 32);
            this.kbtnSimpleEmail.Name = "kbtnSimpleEmail";
            this.kbtnSimpleEmail.Size = new System.Drawing.Size(131, 49);
            this.kbtnSimpleEmail.TabIndex = 1;
            this.kbtnSimpleEmail.Values.Image = global::Krypton.Toolkit.Suite.Extended.Error.Reporting.Properties.Resources.Forward;
            this.kbtnSimpleEmail.Values.Text = "";
            // 
            // kryptonBorderEdge2
            // 
            this.kryptonBorderEdge2.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge2.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge2.Name = "kryptonBorderEdge2";
            this.kryptonBorderEdge2.Size = new System.Drawing.Size(507, 1);
            this.kryptonBorderEdge2.Text = "kryptonBorderEdge2";
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonNavigator1.Button.CloseButtonAction = Krypton.Navigator.CloseButtonAction.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Location = new System.Drawing.Point(12, 12);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kpGeneral,
            this.kpExceptions,
            this.kpAssemblies,
            this.kpSystemInformation});
            this.kryptonNavigator1.SelectedIndex = 3;
            this.kryptonNavigator1.Size = new System.Drawing.Size(569, 391);
            this.kryptonNavigator1.TabIndex = 0;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kpGeneral
            // 
            this.kpGeneral.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpGeneral.Controls.Add(this.ktxtUserExplanation);
            this.kpGeneral.Controls.Add(this.klblExplanation);
            this.kpGeneral.Controls.Add(this.ktxtTime);
            this.kpGeneral.Controls.Add(this.kryptonLabel4);
            this.kpGeneral.Controls.Add(this.ktxtDate);
            this.kpGeneral.Controls.Add(this.kryptonLabel3);
            this.kpGeneral.Controls.Add(this.ktxtVersion);
            this.kpGeneral.Controls.Add(this.kryptonLabel2);
            this.kpGeneral.Controls.Add(this.ktxtApplicationName);
            this.kpGeneral.Controls.Add(this.kryptonLabel1);
            this.kpGeneral.Controls.Add(this.ktxtExceptionMessage);
            this.kpGeneral.Controls.Add(this.picGeneral);
            this.kpGeneral.Flags = 65534;
            this.kpGeneral.LastVisibleSet = true;
            this.kpGeneral.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpGeneral.Name = "kpGeneral";
            this.kpGeneral.Size = new System.Drawing.Size(567, 364);
            this.kpGeneral.Text = "General";
            this.kpGeneral.ToolTipTitle = "Page ToolTip";
            this.kpGeneral.UniqueName = "ec93428d50494b2b88f3e6f15a95e7e4";
            // 
            // ktxtUserExplanation
            // 
            this.ktxtUserExplanation.Location = new System.Drawing.Point(8, 198);
            this.ktxtUserExplanation.Multiline = true;
            this.ktxtUserExplanation.Name = "ktxtUserExplanation";
            this.ktxtUserExplanation.Size = new System.Drawing.Size(542, 154);
            this.ktxtUserExplanation.StateCommon.Back.Color1 = System.Drawing.Color.Cornsilk;
            this.ktxtUserExplanation.TabIndex = 37;
            // 
            // klblExplanation
            // 
            this.klblExplanation.Location = new System.Drawing.Point(8, 172);
            this.klblExplanation.Name = "klblExplanation";
            this.klblExplanation.Size = new System.Drawing.Size(390, 20);
            this.klblExplanation.TabIndex = 36;
            this.klblExplanation.Values.Text = "Please enter a brief explanation of events leading up to this exception";
            // 
            // ktxtTime
            // 
            this.ktxtTime.Location = new System.Drawing.Point(330, 135);
            this.ktxtTime.Name = "ktxtTime";
            this.ktxtTime.ReadOnly = true;
            this.ktxtTime.Size = new System.Drawing.Size(152, 23);
            this.ktxtTime.TabIndex = 35;
            this.ktxtTime.Text = "{APPLICATION-NAME}";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(248, 135);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(40, 20);
            this.kryptonLabel4.TabIndex = 34;
            this.kryptonLabel4.Values.Text = "Time:";
            // 
            // ktxtDate
            // 
            this.ktxtDate.Location = new System.Drawing.Point(90, 135);
            this.ktxtDate.Name = "ktxtDate";
            this.ktxtDate.ReadOnly = true;
            this.ktxtDate.Size = new System.Drawing.Size(152, 23);
            this.ktxtDate.TabIndex = 33;
            this.ktxtDate.Text = "{APPLICATION-NAME}";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(8, 135);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(39, 20);
            this.kryptonLabel3.TabIndex = 32;
            this.kryptonLabel3.Values.Text = "Date:";
            // 
            // ktxtVersion
            // 
            this.ktxtVersion.Location = new System.Drawing.Point(90, 106);
            this.ktxtVersion.Name = "ktxtVersion";
            this.ktxtVersion.ReadOnly = true;
            this.ktxtVersion.Size = new System.Drawing.Size(152, 23);
            this.ktxtVersion.TabIndex = 31;
            this.ktxtVersion.Text = "{APPLICATION-NAME}";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(8, 106);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel2.TabIndex = 30;
            this.kryptonLabel2.Values.Text = "Version:";
            // 
            // ktxtApplicationName
            // 
            this.ktxtApplicationName.Location = new System.Drawing.Point(90, 77);
            this.ktxtApplicationName.Name = "ktxtApplicationName";
            this.ktxtApplicationName.ReadOnly = true;
            this.ktxtApplicationName.Size = new System.Drawing.Size(460, 23);
            this.ktxtApplicationName.TabIndex = 29;
            this.ktxtApplicationName.Text = "{APPLICATION-NAME}";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(8, 77);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel1.TabIndex = 28;
            this.kryptonLabel1.Values.Text = "Application:";
            // 
            // ktxtExceptionMessage
            // 
            this.ktxtExceptionMessage.Location = new System.Drawing.Point(78, 7);
            this.ktxtExceptionMessage.Multiline = true;
            this.ktxtExceptionMessage.Name = "ktxtExceptionMessage";
            this.ktxtExceptionMessage.ReadOnly = true;
            this.ktxtExceptionMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ktxtExceptionMessage.Size = new System.Drawing.Size(472, 64);
            this.ktxtExceptionMessage.TabIndex = 27;
            this.ktxtExceptionMessage.Text = "kryptonTextBox1";
            // 
            // picGeneral
            // 
            this.picGeneral.BackColor = System.Drawing.Color.Transparent;
            this.picGeneral.Image = global::Krypton.Toolkit.Suite.Extended.Error.Reporting.Properties.Resources.Warning;
            this.picGeneral.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picGeneral.Location = new System.Drawing.Point(8, 7);
            this.picGeneral.Name = "picGeneral";
            this.picGeneral.Size = new System.Drawing.Size(64, 64);
            this.picGeneral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGeneral.TabIndex = 26;
            this.picGeneral.TabStop = false;
            // 
            // kpExceptions
            // 
            this.kpExceptions.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpExceptions.Flags = 65534;
            this.kpExceptions.LastVisibleSet = true;
            this.kpExceptions.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpExceptions.Name = "kpExceptions";
            this.kpExceptions.Size = new System.Drawing.Size(567, 364);
            this.kpExceptions.Text = "Exceptions";
            this.kpExceptions.ToolTipTitle = "Page ToolTip";
            this.kpExceptions.UniqueName = "70dc02f64cb24bdc91680e5bb8e01301";
            // 
            // kpAssemblies
            // 
            this.kpAssemblies.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpAssemblies.Controls.Add(this.klvAssemblies);
            this.kpAssemblies.Flags = 65534;
            this.kpAssemblies.LastVisibleSet = true;
            this.kpAssemblies.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpAssemblies.Name = "kpAssemblies";
            this.kpAssemblies.Size = new System.Drawing.Size(567, 364);
            this.kpAssemblies.Text = "Assemblies";
            this.kpAssemblies.ToolTipTitle = "Page ToolTip";
            this.kpAssemblies.UniqueName = "28ca0bbf236f49c18958ffa3d3557525";
            // 
            // klvAssemblies
            // 
            this.klvAssemblies.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.klvAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klvAssemblies.HideSelection = false;
            this.klvAssemblies.HotTracking = true;
            this.klvAssemblies.HoverSelection = true;
            this.klvAssemblies.ItemStyle = Krypton.Toolkit.ButtonStyle.ListItem;
            this.klvAssemblies.Location = new System.Drawing.Point(0, 0);
            this.klvAssemblies.Name = "klvAssemblies";
            this.klvAssemblies.OwnerDraw = true;
            this.klvAssemblies.Size = new System.Drawing.Size(567, 364);
            this.klvAssemblies.StateCommon.Item.Content.ShortText.MultiLine = Krypton.Toolkit.InheritBool.True;
            this.klvAssemblies.StateCommon.Item.Content.ShortText.MultiLineH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klvAssemblies.StateCommon.Item.Content.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klvAssemblies.TabIndex = 0;
            // 
            // kpSystemInformation
            // 
            this.kpSystemInformation.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpSystemInformation.Controls.Add(this.ktvEnvironment);
            this.kpSystemInformation.Flags = 65534;
            this.kpSystemInformation.LastVisibleSet = true;
            this.kpSystemInformation.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpSystemInformation.Name = "kpSystemInformation";
            this.kpSystemInformation.Size = new System.Drawing.Size(567, 364);
            this.kpSystemInformation.Text = "System";
            this.kpSystemInformation.ToolTipTitle = "Page ToolTip";
            this.kpSystemInformation.UniqueName = "9bbc2a1549d5487082f98e241dcebe25";
            // 
            // ktvEnvironment
            // 
            this.ktvEnvironment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktvEnvironment.Location = new System.Drawing.Point(0, 0);
            this.ktvEnvironment.Name = "ktvEnvironment";
            this.ktvEnvironment.Size = new System.Drawing.Size(567, 364);
            this.ktvEnvironment.TabIndex = 0;
            // 
            // ktxtExceptionMessageLarge
            // 
            this.ktxtExceptionMessageLarge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktxtExceptionMessageLarge.Location = new System.Drawing.Point(0, 0);
            this.ktxtExceptionMessageLarge.Multiline = true;
            this.ktxtExceptionMessageLarge.Name = "ktxtExceptionMessageLarge";
            this.ktxtExceptionMessageLarge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ktxtExceptionMessageLarge.Size = new System.Drawing.Size(593, 420);
            this.ktxtExceptionMessageLarge.TabIndex = 2;
            this.ktxtExceptionMessageLarge.Text = "kryptonTextBox1";
            this.ktxtExceptionMessageLarge.Visible = false;
            // 
            // ExceptionReportView
            // 
            this.CancelButton = this.kbtnClose;
            this.ClientSize = new System.Drawing.Size(593, 494);
            this.Controls.Add(this.kpnlLessDetails);
            this.Controls.Add(this.kpnlMain);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionReportView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            this.kryptonStatusStrip1.ResumeLayout(false);
            this.kryptonStatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).EndInit();
            this.kpnlMain.ResumeLayout(false);
            this.kpnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlLessDetails)).EndInit();
            this.kpnlLessDetails.ResumeLayout(false);
            this.kpnlLessDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lessDetail_alertIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlLessDetail_optionsPanel)).EndInit();
            this.kpnlLessDetail_optionsPanel.ResumeLayout(false);
            this.kpnlLessDetail_optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpGeneral)).EndInit();
            this.kpGeneral.ResumeLayout(false);
            this.kpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpExceptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpAssemblies)).EndInit();
            this.kpAssemblies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpSystemInformation)).EndInit();
            this.kpSystemInformation.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Fields
        private bool _isDataRefreshRequired;
        private readonly ExceptionReportPresenter _presenter;
        #endregion

        #region Property

        #endregion

        #region IExceptionReportView Implementation
        public string ProgressMessage
        {
            set
            {
                tslblProgressMessage.Visible = true;
                tslblProgressMessage.Text = value;
            }
        }

        public bool EnableEmailButton
        {
            set => kbtnElectronicMail.Enabled = value;
        }

        public bool ShowProgressBar
        {
            set => toolStripProgressBar1.Visible = value;
        }

        private bool ShowProgressLabel
        {
            set => tslblProgressMessage.Visible = value;
        }

        public bool ShowFullDetail { get; set; }

        public string UserExplanation => ktxtUserExplanation.Text;

        public void MapiSendCompleted()
        {
            Completed(true);
            ProgressMessage = string.Empty;
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
                AddExceptionControl(kpExceptions, exception);
            }
            else
            {
                var innerTabControl = new TabControl { Dock = DockStyle.Fill };
                kpExceptions.Controls.Add(innerTabControl);
                for (var index = 0; index < exs.Length; index++)
                {
                    var exception = exs[index];
                    var tabPage = new TabPage { Text = $"Exception {index + 1}" };
                    innerTabControl.TabPages.Add(tabPage);
                    AddExceptionControl(tabPage, exception);
                }
            }
        }

        public void PopulateAssembliesTab()
        {
            klvAssemblies.Clear();
            klvAssemblies.Columns.Add("Name", 320, HorizontalAlignment.Left);
            klvAssemblies.Columns.Add("Version", 150, HorizontalAlignment.Left);

            _presenter.GetReferencedAssemblies().ForEach(AddAssembly);
        }

        public void PopulateSysInfoTab()
        {
            var rootNode = CreateSysInfoTree();
            ktvEnvironment.Nodes.Add(rootNode);
            rootNode.Expand();
        }

        public void SetProgressCompleteState()
        {
            Cursor = Cursors.Default;
            ShowProgressLabel = ShowProgressBar = false;
        }

        public void ToggleShowFullDetail()
        {
            if (ShowFullDetail)
            {
                kpnlLessDetails.Hide();
                kbtnLessDetail.Text = Properties.Resources.ExceptionReportView_ToggleShowFullDetail_Less_Detail;
                kpnlMain.Show();
                kpnlButtons.Show();
                Size = new Size(613, 537);
            }
            else
            {
                kpnlLessDetails.Show();
                kbtnSimpleDetailToggle.Text = Properties.Resources.ExceptionReportView_ToggleShowFullDetail_More_Detail;
                kpnlMain.Hide();
                kpnlButtons.Hide();
                Size = new Size(415, 235);
            }
        }

        public void ShowWindow()
        {
            _isDataRefreshRequired = true;
            ShowDialog();
        }

        public void Completed(bool success)
        {
            ProgressMessage = success ? Properties.Resources.Report_sent : Properties.Resources.Failed_to_send_report;
            ShowProgressBar = false;
            kbtnElectronicMail.Enabled = true;
        }

        public void ShowError(string message, Exception exception)
        {
            KryptonMessageBox.Show(message, Properties.Resources.ExceptionReportView_ShowError_Error_sending_report, MessageBoxButtons.OK, KryptonMessageBoxIcon.ERROR);
        }
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
            klblExplanation.Text = reportInfo.UserExplanationLabel ?? Properties.Resources.Please_enter_a_brief_explanation_of_events_leading_up_to_this_exception;
            ShowFullDetail = reportInfo.ShowFullDetail;
            ToggleShowFullDetail();
            kbtnLessDetail.Visible = reportInfo.ShowLessDetailButton;

            //TODO: show all exception messages
            ktxtExceptionMessageLarge.Text =
                ktxtExceptionMessage.Text =
                    !string.IsNullOrEmpty(reportInfo.CustomMessage) ? reportInfo.CustomMessage : reportInfo.Exceptions.First().Message;

            ktxtExceptionMessageLarge2.Text = ktxtExceptionMessageLarge.Text;

            ktxtDate.Text = reportInfo.ExceptionDate.ToShortDateString();
            ktxtTime.Text = reportInfo.ExceptionDate.ToShortTimeString();
            ktxtApplicationName.Text = reportInfo.AppName;
            ktxtVersion.Text = reportInfo.AppVersion;
            
            if (!reportInfo.ShowButtonIcons)
            {
                RemoveButtonIcons();
            }

            if (!reportInfo.ShowEmailButton)
            {
                RemoveEmailButton();
            }

            Text = reportInfo.TitleText ?? Properties.Resources.ErrorReport;
            ktxtUserExplanation.StateCommon.Content.Font = new Font(ktxtUserExplanation.StateCommon.Content.Font.FontFamily, reportInfo.UserExplanationFontSize);
            klblContactCompany.Text =
                string.Format(
                    Properties.Resources.ExceptionReportView_PopulateReportInfo_If_this_problem_persists__please_contact__0__support_ +
                    Environment.NewLine, reportInfo.CompanyName);
            kbtnSimpleEmail.Text =
                $"{(reportInfo.SendMethod == ReportSendMethod.WebService ? Properties.Resources.Send : "Email")} {(reportInfo.SendMethod == ReportSendMethod.WebService && !reportInfo.CompanyName.IsEmpty() ? string.Format(Properties.Resources.to__0_, reportInfo.CompanyName) : reportInfo.CompanyName)}";
            kbtnElectronicMail.Text = reportInfo.SendMethod == ReportSendMethod.WebService ? Properties.Resources.Send : "Email";
        }

        private void RemoveEmailButton()
        {
            this.kbtnSimpleEmail.Hide();
            this.kbtnElectronicMail.Hide();
            this.kbtnCopy.Location = kbtnElectronicMail.Location;
            this.kbtnSimpleCopy.Location = kbtnSimpleEmail.Location;
        }

        private void RemoveButtonIcons()
        {
            // removing the icons, requires a bit of reshuffling of positions
            kbtnCopy.Values.Image = kbtnElectronicMail.Values.Image = kbtnSave.Values.Image = null;
            kbtnClose.Height = kbtnLessDetail.Height = kbtnCopy.Height = kbtnElectronicMail.Height = kbtnSave.Height = 27;
            //kbtnClose.TextAlign = btnDetailToggle.TextAlign = btnCopy.TextAlign = btnEmail.TextAlign = btnSave.TextAlign = ContentAlignment.MiddleCenter;
            kbtnClose.Font = kbtnLessDetail.Font = kbtnSave.Font = kbtnElectronicMail.Font = kbtnCopy.Font = new Font(kbtnCopy.Font.FontFamily, 8.25f);
            ShiftDown3Pixels(new[] { kbtnClose, kbtnLessDetail, kbtnCopy, kbtnElectronicMail, kbtnSave });
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
            kbtnElectronicMail.Click += Email_Click;
            kbtnSimpleEmail.Click += Email_Click;
            kbtnCopy.Click += Copy_Click;
            kbtnSimpleCopy.Click += Copy_Click;
            kbtnClose.Click += Close_Click;
            kbtnLessDetail.Click += Detail_Click;
            kbtnSimpleDetailToggle.Click += Detail_Click;
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
                kryptonNavigator1.Pages.Remove(kpGeneral);
            }
            if (!_presenter.ReportInfo.ShowExceptionsTab)
            {
                kryptonNavigator1.Pages.Remove(kpExceptions);
            }
            if (!_presenter.ReportInfo.ShowAssembliesTab)
            {
                kryptonNavigator1.Pages.Remove(kpAssemblies);
            }
            if (!_presenter.ReportInfo.ShowSysInfoTab)
            {
                kryptonNavigator1.Pages.Remove(kpSystemInformation);
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

        private void AddAssembly(AssemblyRef assembly)
        {
            var listViewItem = new ListViewItem
            {
                Text = assembly.Name
            };
            listViewItem.SubItems.Add(assembly.Version);
            klvAssemblies.Items.Add(listViewItem);
        }

        private TreeNode CreateSysInfoTree()
        {
            var rootNode = new TreeNode("System");

            foreach (var sysInfoResult in _presenter.GetSysInfoResults())
            {
                SysInfoResultMapperWinForm.AddTreeViewNode(rootNode, sysInfoResult);
            }

            return rootNode;
        }
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
                Filter = "Archive (*.zip)|*.zip|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                _presenter.SaveZipReportToFile(saveDialog.FileName);
            }
        }

        #endregion

        #region Protected

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (_isDataRefreshRequired)
            {
                _isDataRefreshRequired = false;

                _presenter.PopulateReport();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            FormBorderStyle = ShowFullDetail ? FormBorderStyle.Sizable : FormBorderStyle.FixedDialog;
        }

        #endregion
    }
}
#pragma warning restore 1591
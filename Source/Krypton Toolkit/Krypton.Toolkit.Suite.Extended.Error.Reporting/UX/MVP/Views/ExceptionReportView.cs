#region MIT License
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

// ReSharper disable InconsistentNaming
// ReSharper disable LocalizableElement
#pragma warning disable 1591, CS8625, CS8600, CS8622
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
            kpnlButtons = new KryptonPanel();
            kbtnLessDetail = new KryptonButton();
            kbtnCopy = new KryptonButton();
            kbtnSave = new KryptonButton();
            kbtnElectronicMail = new KryptonButton();
            kbtnClose = new KryptonButton();
            kryptonBorderEdge1 = new KryptonBorderEdge();
            kryptonStatusStrip1 = new KryptonStatusStrip();
            tslblProgressMessage = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            kpnlMain = new KryptonPanel();
            kpnlLessDetails = new KryptonPanel();
            ktxtExceptionMessageLarge2 = new KryptonTextBox();
            kryptonLabel6 = new KryptonLabel();
            lessDetail_alertIcon = new PictureBox();
            kpnlLessDetail_optionsPanel = new KryptonPanel();
            klblContactCompany = new KryptonLabel();
            kbtnSimpleDetailToggle = new KryptonButton();
            kbtnSimpleCopy = new KryptonButton();
            kbtnSimpleEmail = new KryptonButton();
            kryptonBorderEdge2 = new KryptonBorderEdge();
            kryptonNavigator1 = new Navigator.KryptonNavigator();
            kpGeneral = new Navigator.KryptonPage();
            ktxtUserExplanation = new KryptonTextBox();
            klblExplanation = new KryptonLabel();
            ktxtTime = new KryptonTextBox();
            kryptonLabel4 = new KryptonLabel();
            ktxtDate = new KryptonTextBox();
            kryptonLabel3 = new KryptonLabel();
            ktxtVersion = new KryptonTextBox();
            kryptonLabel2 = new KryptonLabel();
            ktxtApplicationName = new KryptonTextBox();
            kryptonLabel1 = new KryptonLabel();
            ktxtExceptionMessage = new KryptonTextBox();
            picGeneral = new PictureBox();
            kpExceptions = new Navigator.KryptonPage();
            kpAssemblies = new Navigator.KryptonPage();
            klvAssemblies = new KryptonListView();
            kpSystemInformation = new Navigator.KryptonPage();
            ktvEnvironment = new KryptonTreeView();
            ktxtExceptionMessageLarge = new KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(kpnlButtons)).BeginInit();
            kpnlButtons.SuspendLayout();
            kryptonStatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(kpnlMain)).BeginInit();
            kpnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(kpnlLessDetails)).BeginInit();
            kpnlLessDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(lessDetail_alertIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(kpnlLessDetail_optionsPanel)).BeginInit();
            kpnlLessDetail_optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(kryptonNavigator1)).BeginInit();
            kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(kpGeneral)).BeginInit();
            kpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(picGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(kpExceptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(kpAssemblies)).BeginInit();
            kpAssemblies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(kpSystemInformation)).BeginInit();
            kpSystemInformation.SuspendLayout();
            SuspendLayout();
            // 
            // kpnlButtons
            // 
            kpnlButtons.Controls.Add(kbtnLessDetail);
            kpnlButtons.Controls.Add(kbtnCopy);
            kpnlButtons.Controls.Add(kbtnSave);
            kpnlButtons.Controls.Add(kbtnElectronicMail);
            kpnlButtons.Controls.Add(kbtnClose);
            kpnlButtons.Controls.Add(kryptonBorderEdge1);
            kpnlButtons.Controls.Add(kryptonStatusStrip1);
            kpnlButtons.Dock = DockStyle.Bottom;
            kpnlButtons.Location = new Point(0, 420);
            kpnlButtons.Name = "kpnlButtons";
            kpnlButtons.PanelBackStyle = PaletteBackStyle.PanelAlternate;
            kpnlButtons.Size = new Size(593, 74);
            kpnlButtons.TabIndex = 0;
            // 
            // kbtnLessDetail
            // 
            kbtnLessDetail.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            kbtnLessDetail.Location = new Point(119, 10);
            kbtnLessDetail.Name = "kbtnLessDetail";
            kbtnLessDetail.Size = new Size(87, 39);
            kbtnLessDetail.TabIndex = 6;
            kbtnLessDetail.Values.Text = "Less Detai&l";
            // 
            // kbtnCopy
            // 
            kbtnCopy.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            kbtnCopy.Location = new Point(212, 10);
            kbtnCopy.Name = "kbtnCopy";
            kbtnCopy.Size = new Size(87, 39);
            kbtnCopy.TabIndex = 5;
            kbtnCopy.Values.Image = Properties.Resources.Copy;
            kbtnCopy.Values.Text = "Co&py";
            // 
            // kbtnSave
            // 
            kbtnSave.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            kbtnSave.Location = new Point(305, 10);
            kbtnSave.Name = "kbtnSave";
            kbtnSave.Size = new Size(87, 39);
            kbtnSave.TabIndex = 4;
            kbtnSave.Values.Image = Properties.Resources.Hard_Disk;
            kbtnSave.Values.Text = "S&ave";
            // 
            // kbtnElectronicMail
            // 
            kbtnElectronicMail.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            kbtnElectronicMail.Location = new Point(398, 10);
            kbtnElectronicMail.Name = "kbtnElectronicMail";
            kbtnElectronicMail.Size = new Size(87, 39);
            kbtnElectronicMail.TabIndex = 3;
            kbtnElectronicMail.Values.Image = Properties.Resources.Forward;
            kbtnElectronicMail.Values.Text = "&E-Mail";
            // 
            // kbtnClose
            // 
            kbtnClose.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            kbtnClose.DialogResult = DialogResult.Cancel;
            kbtnClose.Location = new Point(491, 10);
            kbtnClose.Name = "kbtnClose";
            kbtnClose.Size = new Size(90, 39);
            kbtnClose.TabIndex = 2;
            kbtnClose.Values.Text = "&Close";
            // 
            // kryptonBorderEdge1
            // 
            kryptonBorderEdge1.BorderStyle = PaletteBorderStyle.HeaderSecondary;
            kryptonBorderEdge1.Dock = DockStyle.Top;
            kryptonBorderEdge1.Location = new Point(0, 0);
            kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            kryptonBorderEdge1.Size = new Size(593, 1);
            kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonStatusStrip1
            // 
            kryptonStatusStrip1.Font = new Font("Segoe UI", 9F);
            kryptonStatusStrip1.Items.AddRange(new ToolStripItem[] {
            tslblProgressMessage,
            toolStripProgressBar1});
            kryptonStatusStrip1.Location = new Point(0, 52);
            kryptonStatusStrip1.Name = "kryptonStatusStrip1";
            kryptonStatusStrip1.ProgressBars = null;
            kryptonStatusStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            kryptonStatusStrip1.Size = new Size(593, 22);
            kryptonStatusStrip1.TabIndex = 0;
            kryptonStatusStrip1.Text = "kryptonStatusStrip1";
            // 
            // tslblProgressMessage
            // 
            tslblProgressMessage.Name = "tslblProgressMessage";
            tslblProgressMessage.Size = new Size(476, 17);
            tslblProgressMessage.Spring = true;
            tslblProgressMessage.Text = "Loading system information...";
            tslblProgressMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // kpnlMain
            // 
            kpnlMain.Controls.Add(kryptonNavigator1);
            kpnlMain.Controls.Add(ktxtExceptionMessageLarge);
            kpnlMain.Dock = DockStyle.Fill;
            kpnlMain.Location = new Point(0, 0);
            kpnlMain.Name = "kpnlMain";
            kpnlMain.Size = new Size(593, 420);
            kpnlMain.TabIndex = 1;
            // 
            // kpnlLessDetails
            // 
            kpnlLessDetails.Controls.Add(ktxtExceptionMessageLarge2);
            kpnlLessDetails.Controls.Add(kryptonLabel6);
            kpnlLessDetails.Controls.Add(lessDetail_alertIcon);
            kpnlLessDetails.Controls.Add(kpnlLessDetail_optionsPanel);
            kpnlLessDetails.Location = new Point(0, 0);
            kpnlLessDetails.Name = "kpnlLessDetails";
            kpnlLessDetails.Size = new Size(507, 230);
            kpnlLessDetails.StateCommon.Color1 = Color.White;
            kpnlLessDetails.StateCommon.Color2 = Color.White;
            kpnlLessDetails.TabIndex = 1;
            // 
            // ktxtExceptionMessageLarge2
            // 
            ktxtExceptionMessageLarge2.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
            ktxtExceptionMessageLarge2.Location = new Point(84, 66);
            ktxtExceptionMessageLarge2.Multiline = true;
            ktxtExceptionMessageLarge2.Name = "ktxtExceptionMessageLarge2";
            ktxtExceptionMessageLarge2.ReadOnly = true;
            ktxtExceptionMessageLarge2.Size = new Size(415, 69);
            ktxtExceptionMessageLarge2.TabIndex = 28;
            ktxtExceptionMessageLarge2.Text = "kryptonTextBox1";
            // 
            // kryptonLabel6
            // 
            kryptonLabel6.Location = new Point(84, 33);
            kryptonLabel6.Name = "kryptonLabel6";
            kryptonLabel6.Size = new Size(158, 26);
            kryptonLabel6.StateCommon.LongText.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            kryptonLabel6.StateCommon.ShortText.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            kryptonLabel6.TabIndex = 27;
            kryptonLabel6.Values.Text = "Operation Failed";
            // 
            // lessDetail_alertIcon
            // 
            lessDetail_alertIcon.BackColor = Color.Transparent;
            lessDetail_alertIcon.Image = Properties.Resources.Warning;
            lessDetail_alertIcon.ImeMode = ImeMode.NoControl;
            lessDetail_alertIcon.Location = new Point(11, 15);
            lessDetail_alertIcon.Name = "lessDetail_alertIcon";
            lessDetail_alertIcon.Size = new Size(64, 64);
            lessDetail_alertIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            lessDetail_alertIcon.TabIndex = 26;
            lessDetail_alertIcon.TabStop = false;
            // 
            // kpnlLessDetail_optionsPanel
            // 
            kpnlLessDetail_optionsPanel.Controls.Add(klblContactCompany);
            kpnlLessDetail_optionsPanel.Controls.Add(kbtnSimpleDetailToggle);
            kpnlLessDetail_optionsPanel.Controls.Add(kbtnSimpleCopy);
            kpnlLessDetail_optionsPanel.Controls.Add(kbtnSimpleEmail);
            kpnlLessDetail_optionsPanel.Controls.Add(kryptonBorderEdge2);
            kpnlLessDetail_optionsPanel.Dock = DockStyle.Bottom;
            kpnlLessDetail_optionsPanel.Location = new Point(0, 141);
            kpnlLessDetail_optionsPanel.Name = "kpnlLessDetail_optionsPanel";
            kpnlLessDetail_optionsPanel.PanelBackStyle = PaletteBackStyle.PanelAlternate;
            kpnlLessDetail_optionsPanel.Size = new Size(507, 89);
            kpnlLessDetail_optionsPanel.TabIndex = 0;
            // 
            // klblContactCompany
            // 
            klblContactCompany.Location = new Point(17, 4);
            klblContactCompany.Name = "klblContactCompany";
            klblContactCompany.Size = new Size(6, 2);
            klblContactCompany.TabIndex = 4;
            klblContactCompany.Values.Text = "";
            // 
            // kbtnSimpleDetailToggle
            // 
            kbtnSimpleDetailToggle.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            kbtnSimpleDetailToggle.Location = new Point(94, 32);
            kbtnSimpleDetailToggle.Name = "kbtnSimpleDetailToggle";
            kbtnSimpleDetailToggle.Size = new Size(131, 49);
            kbtnSimpleDetailToggle.TabIndex = 3;
            kbtnSimpleDetailToggle.Values.Image = Properties.Resources.Add;
            kbtnSimpleDetailToggle.Values.Text = "M&ore Details";
            // 
            // kbtnSimpleCopy
            // 
            kbtnSimpleCopy.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            kbtnSimpleCopy.Location = new Point(231, 32);
            kbtnSimpleCopy.Name = "kbtnSimpleCopy";
            kbtnSimpleCopy.Size = new Size(131, 49);
            kbtnSimpleCopy.TabIndex = 2;
            kbtnSimpleCopy.Values.Image = Properties.Resources.Copy;
            kbtnSimpleCopy.Values.Text = "&Copy Details";
            // 
            // kbtnSimpleEmail
            // 
            kbtnSimpleEmail.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            kbtnSimpleEmail.Location = new Point(368, 32);
            kbtnSimpleEmail.Name = "kbtnSimpleEmail";
            kbtnSimpleEmail.Size = new Size(131, 49);
            kbtnSimpleEmail.TabIndex = 1;
            kbtnSimpleEmail.Values.Image = Properties.Resources.Forward;
            kbtnSimpleEmail.Values.Text = "";
            // 
            // kryptonBorderEdge2
            // 
            kryptonBorderEdge2.BorderStyle = PaletteBorderStyle.HeaderPrimary;
            kryptonBorderEdge2.Dock = DockStyle.Top;
            kryptonBorderEdge2.Location = new Point(0, 0);
            kryptonBorderEdge2.Name = "kryptonBorderEdge2";
            kryptonBorderEdge2.Size = new Size(507, 1);
            kryptonBorderEdge2.Text = "kryptonBorderEdge2";
            // 
            // kryptonNavigator1
            // 
            kryptonNavigator1.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
            kryptonNavigator1.Button.CloseButtonAction = Navigator.CloseButtonAction.None;
            kryptonNavigator1.Button.CloseButtonDisplay = Navigator.ButtonDisplay.Hide;
            kryptonNavigator1.Location = new Point(12, 12);
            kryptonNavigator1.Name = "kryptonNavigator1";
            kryptonNavigator1.Pages.AddRange(new Navigator.KryptonPage[] {
            kpGeneral,
            kpExceptions,
            kpAssemblies,
            kpSystemInformation});
            kryptonNavigator1.SelectedIndex = 3;
            kryptonNavigator1.Size = new Size(569, 391);
            kryptonNavigator1.TabIndex = 0;
            kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kpGeneral
            // 
            kpGeneral.AutoHiddenSlideSize = new Size(200, 200);
            kpGeneral.Controls.Add(ktxtUserExplanation);
            kpGeneral.Controls.Add(klblExplanation);
            kpGeneral.Controls.Add(ktxtTime);
            kpGeneral.Controls.Add(kryptonLabel4);
            kpGeneral.Controls.Add(ktxtDate);
            kpGeneral.Controls.Add(kryptonLabel3);
            kpGeneral.Controls.Add(ktxtVersion);
            kpGeneral.Controls.Add(kryptonLabel2);
            kpGeneral.Controls.Add(ktxtApplicationName);
            kpGeneral.Controls.Add(kryptonLabel1);
            kpGeneral.Controls.Add(ktxtExceptionMessage);
            kpGeneral.Controls.Add(picGeneral);
            kpGeneral.Flags = 65534;
            kpGeneral.LastVisibleSet = true;
            kpGeneral.MinimumSize = new Size(50, 50);
            kpGeneral.Name = "kpGeneral";
            kpGeneral.Size = new Size(567, 364);
            kpGeneral.Text = "General";
            kpGeneral.ToolTipTitle = "Page ToolTip";
            kpGeneral.UniqueName = "ec93428d50494b2b88f3e6f15a95e7e4";
            // 
            // ktxtUserExplanation
            // 
            ktxtUserExplanation.Location = new Point(8, 198);
            ktxtUserExplanation.Multiline = true;
            ktxtUserExplanation.Name = "ktxtUserExplanation";
            ktxtUserExplanation.Size = new Size(542, 154);
            ktxtUserExplanation.StateCommon.Back.Color1 = Color.Cornsilk;
            ktxtUserExplanation.TabIndex = 37;
            // 
            // klblExplanation
            // 
            klblExplanation.Location = new Point(8, 172);
            klblExplanation.Name = "klblExplanation";
            klblExplanation.Size = new Size(390, 20);
            klblExplanation.TabIndex = 36;
            klblExplanation.Values.Text = "Please enter a brief explanation of events leading up to this exception";
            // 
            // ktxtTime
            // 
            ktxtTime.Location = new Point(330, 135);
            ktxtTime.Name = "ktxtTime";
            ktxtTime.ReadOnly = true;
            ktxtTime.Size = new Size(152, 23);
            ktxtTime.TabIndex = 35;
            ktxtTime.Text = "{APPLICATION-NAME}";
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(248, 135);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(40, 20);
            kryptonLabel4.TabIndex = 34;
            kryptonLabel4.Values.Text = "Time:";
            // 
            // ktxtDate
            // 
            ktxtDate.Location = new Point(90, 135);
            ktxtDate.Name = "ktxtDate";
            ktxtDate.ReadOnly = true;
            ktxtDate.Size = new Size(152, 23);
            ktxtDate.TabIndex = 33;
            ktxtDate.Text = "{APPLICATION-NAME}";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(8, 135);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(39, 20);
            kryptonLabel3.TabIndex = 32;
            kryptonLabel3.Values.Text = "Date:";
            // 
            // ktxtVersion
            // 
            ktxtVersion.Location = new Point(90, 106);
            ktxtVersion.Name = "ktxtVersion";
            ktxtVersion.ReadOnly = true;
            ktxtVersion.Size = new Size(152, 23);
            ktxtVersion.TabIndex = 31;
            ktxtVersion.Text = "{APPLICATION-NAME}";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(8, 106);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(54, 20);
            kryptonLabel2.TabIndex = 30;
            kryptonLabel2.Values.Text = "Version:";
            // 
            // ktxtApplicationName
            // 
            ktxtApplicationName.Location = new Point(90, 77);
            ktxtApplicationName.Name = "ktxtApplicationName";
            ktxtApplicationName.ReadOnly = true;
            ktxtApplicationName.Size = new Size(460, 23);
            ktxtApplicationName.TabIndex = 29;
            ktxtApplicationName.Text = "{APPLICATION-NAME}";
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(8, 77);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(75, 20);
            kryptonLabel1.TabIndex = 28;
            kryptonLabel1.Values.Text = "Application:";
            // 
            // ktxtExceptionMessage
            // 
            ktxtExceptionMessage.Location = new Point(78, 7);
            ktxtExceptionMessage.Multiline = true;
            ktxtExceptionMessage.Name = "ktxtExceptionMessage";
            ktxtExceptionMessage.ReadOnly = true;
            ktxtExceptionMessage.ScrollBars = ScrollBars.Vertical;
            ktxtExceptionMessage.Size = new Size(472, 64);
            ktxtExceptionMessage.TabIndex = 27;
            ktxtExceptionMessage.Text = "kryptonTextBox1";
            // 
            // picGeneral
            // 
            picGeneral.BackColor = Color.Transparent;
            picGeneral.Image = Properties.Resources.Warning;
            picGeneral.ImeMode = ImeMode.NoControl;
            picGeneral.Location = new Point(8, 7);
            picGeneral.Name = "picGeneral";
            picGeneral.Size = new Size(64, 64);
            picGeneral.SizeMode = PictureBoxSizeMode.StretchImage;
            picGeneral.TabIndex = 26;
            picGeneral.TabStop = false;
            // 
            // kpExceptions
            // 
            kpExceptions.AutoHiddenSlideSize = new Size(200, 200);
            kpExceptions.Flags = 65534;
            kpExceptions.LastVisibleSet = true;
            kpExceptions.MinimumSize = new Size(50, 50);
            kpExceptions.Name = "kpExceptions";
            kpExceptions.Size = new Size(567, 364);
            kpExceptions.Text = "Exceptions";
            kpExceptions.ToolTipTitle = "Page ToolTip";
            kpExceptions.UniqueName = "70dc02f64cb24bdc91680e5bb8e01301";
            // 
            // kpAssemblies
            // 
            kpAssemblies.AutoHiddenSlideSize = new Size(200, 200);
            kpAssemblies.Controls.Add(klvAssemblies);
            kpAssemblies.Flags = 65534;
            kpAssemblies.LastVisibleSet = true;
            kpAssemblies.MinimumSize = new Size(50, 50);
            kpAssemblies.Name = "kpAssemblies";
            kpAssemblies.Size = new Size(567, 364);
            kpAssemblies.Text = "Assemblies";
            kpAssemblies.ToolTipTitle = "Page ToolTip";
            kpAssemblies.UniqueName = "28ca0bbf236f49c18958ffa3d3557525";
            // 
            // klvAssemblies
            // 
            klvAssemblies.Activation = ItemActivation.OneClick;
            klvAssemblies.Dock = DockStyle.Fill;
            klvAssemblies.HideSelection = false;
            klvAssemblies.HotTracking = true;
            klvAssemblies.HoverSelection = true;
            klvAssemblies.ItemStyle = ButtonStyle.ListItem;
            klvAssemblies.Location = new Point(0, 0);
            klvAssemblies.Name = "klvAssemblies";
            klvAssemblies.OwnerDraw = true;
            klvAssemblies.Size = new Size(567, 364);
            klvAssemblies.StateCommon.Item.Content.ShortText.MultiLine = InheritBool.True;
            klvAssemblies.StateCommon.Item.Content.ShortText.MultiLineH = PaletteRelativeAlign.Center;
            klvAssemblies.StateCommon.Item.Content.ShortText.TextH = PaletteRelativeAlign.Center;
            klvAssemblies.TabIndex = 0;
            // 
            // kpSystemInformation
            // 
            kpSystemInformation.AutoHiddenSlideSize = new Size(200, 200);
            kpSystemInformation.Controls.Add(ktvEnvironment);
            kpSystemInformation.Flags = 65534;
            kpSystemInformation.LastVisibleSet = true;
            kpSystemInformation.MinimumSize = new Size(50, 50);
            kpSystemInformation.Name = "kpSystemInformation";
            kpSystemInformation.Size = new Size(567, 364);
            kpSystemInformation.Text = "System";
            kpSystemInformation.ToolTipTitle = "Page ToolTip";
            kpSystemInformation.UniqueName = "9bbc2a1549d5487082f98e241dcebe25";
            // 
            // ktvEnvironment
            // 
            ktvEnvironment.Dock = DockStyle.Fill;
            ktvEnvironment.Location = new Point(0, 0);
            ktvEnvironment.Name = "ktvEnvironment";
            ktvEnvironment.Size = new Size(567, 364);
            ktvEnvironment.TabIndex = 0;
            // 
            // ktxtExceptionMessageLarge
            // 
            ktxtExceptionMessageLarge.Dock = DockStyle.Fill;
            ktxtExceptionMessageLarge.Location = new Point(0, 0);
            ktxtExceptionMessageLarge.Multiline = true;
            ktxtExceptionMessageLarge.Name = "ktxtExceptionMessageLarge";
            ktxtExceptionMessageLarge.ScrollBars = ScrollBars.Vertical;
            ktxtExceptionMessageLarge.Size = new Size(593, 420);
            ktxtExceptionMessageLarge.TabIndex = 2;
            ktxtExceptionMessageLarge.Text = "kryptonTextBox1";
            ktxtExceptionMessageLarge.Visible = false;
            // 
            // ExceptionReportView
            // 
            CancelButton = kbtnClose;
            ClientSize = new Size(593, 494);
            Controls.Add(kpnlLessDetails);
            Controls.Add(kpnlMain);
            Controls.Add(kpnlButtons);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = ((Icon)(resources.GetObject("$this.Icon")));
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExceptionReportView";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(kpnlButtons)).EndInit();
            kpnlButtons.ResumeLayout(false);
            kpnlButtons.PerformLayout();
            kryptonStatusStrip1.ResumeLayout(false);
            kryptonStatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(kpnlMain)).EndInit();
            kpnlMain.ResumeLayout(false);
            kpnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(kpnlLessDetails)).EndInit();
            kpnlLessDetails.ResumeLayout(false);
            kpnlLessDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(lessDetail_alertIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(kpnlLessDetail_optionsPanel)).EndInit();
            kpnlLessDetail_optionsPanel.ResumeLayout(false);
            kpnlLessDetail_optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(kryptonNavigator1)).EndInit();
            kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(kpGeneral)).EndInit();
            kpGeneral.ResumeLayout(false);
            kpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(picGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(kpExceptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(kpAssemblies)).EndInit();
            kpAssemblies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(kpSystemInformation)).EndInit();
            kpSystemInformation.ResumeLayout(false);
            ResumeLayout(false);

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
                if (exception != null)
                {
                    AddExceptionControl(kpExceptions, exception);
                }
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
            KryptonMessageBox.Show(message, Properties.Resources.ExceptionReportView_ShowError_Error_sending_report, KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
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
            if (ktxtUserExplanation.StateCommon.Content.Font != null)
                ktxtUserExplanation.StateCommon.Content.Font = new Font(
                    ktxtUserExplanation.StateCommon.Content.Font.FontFamily, reportInfo.UserExplanationFontSize);
            klblContactCompany.Text =
                string.Format(
                    Properties.Resources.ExceptionReportView_PopulateReportInfo_If_this_problem_persists__please_contact__0__support_ +
                    Environment.NewLine, reportInfo.CompanyName);
            kbtnSimpleEmail.Text =
                $@"{(reportInfo.SendMethod == ReportSendMethod.WebService ? Properties.Resources.Send : "Email")} {(reportInfo.SendMethod == ReportSendMethod.WebService && !reportInfo.CompanyName.IsEmpty() ? string.Format(Properties.Resources.to__0_, reportInfo.CompanyName) : reportInfo.CompanyName)}";
            kbtnElectronicMail.Text = reportInfo.SendMethod == ReportSendMethod.WebService ? Properties.Resources.Send : "Email";
        }

        private void RemoveEmailButton()
        {
            kbtnSimpleEmail.Hide();
            kbtnElectronicMail.Hide();
            kbtnCopy.Location = kbtnElectronicMail.Location;
            kbtnSimpleCopy.Location = kbtnSimpleEmail.Location;
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
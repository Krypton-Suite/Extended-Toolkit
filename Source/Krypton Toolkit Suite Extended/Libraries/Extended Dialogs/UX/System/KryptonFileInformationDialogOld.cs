using Krypton.Toolkit.Suite.Extended.Standard.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonFileInformationDialogOld : KryptonForm
    {
        private KryptonPanelExtended kpnlButtons;
        private KryptonButtonExtended kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanelExtended kryptonPanelExtended1;
        private Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private Krypton.Navigator.KryptonPage kryptonPage1;
        private Krypton.Navigator.KryptonPage kryptonPage2;
        private Krypton.Navigator.KryptonPage kpFileAttributes;
        private KryptonLabel klblAccessed;
        private KryptonLabel klblModified;
        private KryptonLabel klblCreated;
        private System.Windows.Forms.Panel panel3;
        private KryptonLabel klblSizeOnDisk;
        private KryptonLabel klblFileSize;
        private KryptonLabel klblFileLocation;
        private System.Windows.Forms.Panel panel2;
        private KryptonLabel klblFileType;
        private System.Windows.Forms.Panel panel4;
        private KryptonTextBox ktbFileName;
        private System.Windows.Forms.PictureBox pbxFileIcon;
        private KryptonGroupBox kryptonGroupBox2;
        private KryptonButton kbtnImportHash;
        private KryptonButton kbtnValidate;
        private KryptonTextBox ktxtValidate;
        private KryptonComboBox kcmbValidatedHashType;
        private KryptonLabel kryptonLabel9;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonButton kbtnCalculateFileHash;
        private KryptonLabel klblRealFileHash;
        private KryptonComboBox kcmbHashType1;
        private KryptonLabel klblTotalFiles;
        private KryptonButton kbtnGetFileAttributes;
        private KryptonButton kryptonButton1;
        private KryptonButton kbtnClearAllFileAttributes;
        private KryptonGroupBox kryptonGroupBox3;
        private KryptonCheckBox kcbTemporary;
        private KryptonCheckBox kcbSystem;
        private KryptonCheckBox kcbSparseFile;
        private KryptonCheckBox kcbReparsePoint;
        private KryptonCheckBox kcbReadOnly;
        private KryptonCheckBox kcbOffline;
        private KryptonCheckBox kcbIntegrityStream;
        private KryptonCheckBox kcbNormal;
        private KryptonCheckBox kcbNoScrubData;
        private KryptonCheckBox kcbNotContextIndexed;
        private KryptonCheckBox kcbHidden;
        private KryptonCheckBox kcbCompressed;
        private KryptonCheckBox kcbDevice;
        private KryptonCheckBox kcbDirectory;
        private KryptonCheckBox kcbEncrypted;
        private KryptonCheckBox kcbArchive;
        private System.Windows.Forms.ContextMenuStrip ctxHashMenu;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgwMD5;
        private System.ComponentModel.BackgroundWorker bgwSHA1;
        private System.ComponentModel.BackgroundWorker bgwSHA256;
        private System.ComponentModel.BackgroundWorker bgwSHA384;
        private System.ComponentModel.BackgroundWorker bgwSHA512;
        private System.ComponentModel.BackgroundWorker bgwRIPEMD160;
        private System.Windows.Forms.Panel panel5;
        private KryptonButtonExtended kbtnCancel;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kpnlButtons = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonPanelExtended();
            this.kbtnOk = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnCancel = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanelExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonPanelExtended();
            this.kryptonNavigator1 = new Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new Krypton.Navigator.KryptonPage();
            this.klblAccessed = new Krypton.Toolkit.KryptonLabel();
            this.klblModified = new Krypton.Toolkit.KryptonLabel();
            this.klblCreated = new Krypton.Toolkit.KryptonLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.klblSizeOnDisk = new Krypton.Toolkit.KryptonLabel();
            this.klblFileSize = new Krypton.Toolkit.KryptonLabel();
            this.klblFileLocation = new Krypton.Toolkit.KryptonLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.klblFileType = new Krypton.Toolkit.KryptonLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ktbFileName = new Krypton.Toolkit.KryptonTextBox();
            this.pbxFileIcon = new System.Windows.Forms.PictureBox();
            this.kryptonPage2 = new Krypton.Navigator.KryptonPage();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.kbtnImportHash = new Krypton.Toolkit.KryptonButton();
            this.kbtnValidate = new Krypton.Toolkit.KryptonButton();
            this.ktxtValidate = new Krypton.Toolkit.KryptonTextBox();
            this.kcmbValidatedHashType = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kbtnCalculateFileHash = new Krypton.Toolkit.KryptonButton();
            this.klblRealFileHash = new Krypton.Toolkit.KryptonLabel();
            this.kcmbHashType1 = new Krypton.Toolkit.KryptonComboBox();
            this.klblTotalFiles = new Krypton.Toolkit.KryptonLabel();
            this.kpFileAttributes = new Krypton.Navigator.KryptonPage();
            this.kbtnGetFileAttributes = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kbtnClearAllFileAttributes = new Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox3 = new Krypton.Toolkit.KryptonGroupBox();
            this.kcbTemporary = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbSystem = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbSparseFile = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbReparsePoint = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbReadOnly = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbOffline = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbIntegrityStream = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbNormal = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbNoScrubData = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbNotContextIndexed = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbHidden = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbCompressed = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbDevice = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbDirectory = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbEncrypted = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbArchive = new Krypton.Toolkit.KryptonCheckBox();
            this.ctxHashMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwMD5 = new System.ComponentModel.BackgroundWorker();
            this.bgwSHA1 = new System.ComponentModel.BackgroundWorker();
            this.bgwSHA256 = new System.ComponentModel.BackgroundWorker();
            this.bgwSHA384 = new System.ComponentModel.BackgroundWorker();
            this.bgwSHA512 = new System.ComponentModel.BackgroundWorker();
            this.bgwRIPEMD160 = new System.ComponentModel.BackgroundWorker();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended1)).BeginInit();
            this.kryptonPanelExtended1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFileIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.kryptonPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbValidatedHashType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHashType1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpFileAttributes)).BeginInit();
            this.kpFileAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).BeginInit();
            this.kryptonGroupBox3.Panel.SuspendLayout();
            this.kryptonGroupBox3.SuspendLayout();
            this.ctxHashMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.kbtnOk);
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Image = null;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 691);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.Size = new System.Drawing.Size(720, 57);
            this.kpnlButtons.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kpnlButtons.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kpnlButtons.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kpnlButtons.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kpnlButtons.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kpnlButtons.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kpnlButtons.TabIndex = 1;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.Enabled = false;
            this.kbtnOk.Image = null;
            this.kbtnOk.Location = new System.Drawing.Point(522, 7);
            this.kbtnOk.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.ShortTextTypeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.Size = new System.Drawing.Size(90, 38);
            this.kbtnOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.TabIndex = 3;
            this.kbtnOk.Values.Text = "&Ok";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Image = null;
            this.kbtnCancel.Location = new System.Drawing.Point(618, 7);
            this.kbtnCancel.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.ShortTextTypeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.Size = new System.Drawing.Size(90, 38);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "Ca&ncel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 641);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 3);
            this.panel1.TabIndex = 3;
            // 
            // kryptonPanelExtended1
            // 
            this.kryptonPanelExtended1.Controls.Add(this.kryptonNavigator1);
            this.kryptonPanelExtended1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanelExtended1.Image = null;
            this.kryptonPanelExtended1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelExtended1.Name = "kryptonPanelExtended1";
            this.kryptonPanelExtended1.Size = new System.Drawing.Size(720, 691);
            this.kryptonPanelExtended1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonPanelExtended1.TabIndex = 4;
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Button.ButtonDisplayLogic = Krypton.Navigator.ButtonDisplayLogic.NextPrevious;
            this.kryptonNavigator1.Button.CloseButtonAction = Krypton.Navigator.CloseButtonAction.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Location = new System.Drawing.Point(14, 8);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2,
            this.kpFileAttributes});
            this.kryptonNavigator1.SelectedIndex = 2;
            this.kryptonNavigator1.Size = new System.Drawing.Size(692, 675);
            this.kryptonNavigator1.StateCommon.Tab.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonNavigator1.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonNavigator1.TabIndex = 1;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.klblAccessed);
            this.kryptonPage1.Controls.Add(this.klblModified);
            this.kryptonPage1.Controls.Add(this.klblCreated);
            this.kryptonPage1.Controls.Add(this.panel3);
            this.kryptonPage1.Controls.Add(this.klblSizeOnDisk);
            this.kryptonPage1.Controls.Add(this.klblFileSize);
            this.kryptonPage1.Controls.Add(this.klblFileLocation);
            this.kryptonPage1.Controls.Add(this.panel2);
            this.kryptonPage1.Controls.Add(this.klblFileType);
            this.kryptonPage1.Controls.Add(this.panel4);
            this.kryptonPage1.Controls.Add(this.ktbFileName);
            this.kryptonPage1.Controls.Add(this.pbxFileIcon);
            this.kryptonPage1.Controls.Add(this.panel1);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(690, 644);
            this.kryptonPage1.Text = "General";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "c8e6d019e3df414d87a48f82aaa4b1e9";
            // 
            // klblAccessed
            // 
            this.klblAccessed.Location = new System.Drawing.Point(20, 459);
            this.klblAccessed.Name = "klblAccessed";
            this.klblAccessed.Size = new System.Drawing.Size(99, 24);
            this.klblAccessed.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAccessed.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAccessed.TabIndex = 22;
            this.klblAccessed.Values.Text = "Accessed: {0}";
            // 
            // klblModified
            // 
            this.klblModified.Location = new System.Drawing.Point(20, 408);
            this.klblModified.Name = "klblModified";
            this.klblModified.Size = new System.Drawing.Size(98, 24);
            this.klblModified.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblModified.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblModified.TabIndex = 21;
            this.klblModified.Values.Text = "Modified: {0}";
            // 
            // klblCreated
            // 
            this.klblCreated.Location = new System.Drawing.Point(20, 357);
            this.klblCreated.Name = "klblCreated";
            this.klblCreated.Size = new System.Drawing.Size(90, 24);
            this.klblCreated.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblCreated.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblCreated.TabIndex = 20;
            this.klblCreated.Values.Text = "Created: {0}";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Location = new System.Drawing.Point(20, 334);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(651, 1);
            this.panel3.TabIndex = 16;
            // 
            // klblSizeOnDisk
            // 
            this.klblSizeOnDisk.Location = new System.Drawing.Point(20, 282);
            this.klblSizeOnDisk.Name = "klblSizeOnDisk";
            this.klblSizeOnDisk.Size = new System.Drawing.Size(117, 24);
            this.klblSizeOnDisk.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblSizeOnDisk.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblSizeOnDisk.TabIndex = 19;
            this.klblSizeOnDisk.Values.Text = "Size on disk: {0}";
            // 
            // klblFileSize
            // 
            this.klblFileSize.Location = new System.Drawing.Point(20, 231);
            this.klblFileSize.Name = "klblFileSize";
            this.klblFileSize.Size = new System.Drawing.Size(64, 24);
            this.klblFileSize.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFileSize.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFileSize.TabIndex = 18;
            this.klblFileSize.Values.Text = "Size: {0}";
            // 
            // klblFileLocation
            // 
            this.klblFileLocation.Location = new System.Drawing.Point(20, 180);
            this.klblFileLocation.Name = "klblFileLocation";
            this.klblFileLocation.Size = new System.Drawing.Size(95, 24);
            this.klblFileLocation.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFileLocation.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFileLocation.TabIndex = 17;
            this.klblFileLocation.Values.Text = "Location: {0}";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Location = new System.Drawing.Point(20, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 1);
            this.panel2.TabIndex = 15;
            // 
            // klblFileType
            // 
            this.klblFileType.Location = new System.Drawing.Point(20, 105);
            this.klblFileType.Name = "klblFileType";
            this.klblFileType.Size = new System.Drawing.Size(112, 24);
            this.klblFileType.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFileType.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFileType.TabIndex = 14;
            this.klblFileType.Values.Text = "Type of file: {0}";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel4.Location = new System.Drawing.Point(20, 83);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(651, 1);
            this.panel4.TabIndex = 13;
            // 
            // ktbFileName
            // 
            this.ktbFileName.Hint = "Filename.*.*";
            this.ktbFileName.Location = new System.Drawing.Point(91, 29);
            this.ktbFileName.Name = "ktbFileName";
            this.ktbFileName.Size = new System.Drawing.Size(580, 27);
            this.ktbFileName.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktbFileName.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktbFileName.TabIndex = 12;
            // 
            // pbxFileIcon
            // 
            this.pbxFileIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxFileIcon.Location = new System.Drawing.Point(20, 12);
            this.pbxFileIcon.Name = "pbxFileIcon";
            this.pbxFileIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxFileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxFileIcon.TabIndex = 11;
            this.pbxFileIcon.TabStop = false;
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPage2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(690, 644);
            this.kryptonPage2.Text = "Checksums";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "fa8152ff43634150b3dc299a9631bdfc";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(20, 272);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.kbtnImportHash);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kbtnValidate);
            this.kryptonGroupBox2.Panel.Controls.Add(this.ktxtValidate);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kcmbValidatedHashType);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel9);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(651, 221);
            this.kryptonGroupBox2.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBox2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBox2.TabIndex = 3;
            this.kryptonGroupBox2.Values.Heading = "Validate Checksum";
            // 
            // kbtnImportHash
            // 
            this.kbtnImportHash.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnImportHash.Location = new System.Drawing.Point(328, 156);
            this.kbtnImportHash.Name = "kbtnImportHash";
            this.kbtnImportHash.Size = new System.Drawing.Size(139, 29);
            this.kbtnImportHash.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnImportHash.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnImportHash.TabIndex = 15;
            this.kbtnImportHash.Values.Text = "&Import Hash";
            // 
            // kbtnValidate
            // 
            this.kbtnValidate.Enabled = false;
            this.kbtnValidate.Location = new System.Drawing.Point(473, 156);
            this.kbtnValidate.Name = "kbtnValidate";
            this.kbtnValidate.Size = new System.Drawing.Size(156, 29);
            this.kbtnValidate.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnValidate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnValidate.TabIndex = 10;
            this.kbtnValidate.Values.Text = "&Validate";
            // 
            // ktxtValidate
            // 
            this.ktxtValidate.Location = new System.Drawing.Point(15, 81);
            this.ktxtValidate.Name = "ktxtValidate";
            this.ktxtValidate.Size = new System.Drawing.Size(614, 35);
            this.ktxtValidate.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtValidate.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtValidate.TabIndex = 9;
            this.ktxtValidate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kcmbValidatedHashType
            // 
            this.kcmbValidatedHashType.DropDownWidth = 220;
            this.kcmbValidatedHashType.IntegralHeight = false;
            this.kcmbValidatedHashType.Location = new System.Drawing.Point(109, 29);
            this.kcmbValidatedHashType.Name = "kcmbValidatedHashType";
            this.kcmbValidatedHashType.Size = new System.Drawing.Size(132, 25);
            this.kcmbValidatedHashType.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbValidatedHashType.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbValidatedHashType.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbValidatedHashType.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbValidatedHashType.TabIndex = 8;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(15, 29);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(88, 24);
            this.kryptonLabel9.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel9.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel9.TabIndex = 7;
            this.kryptonLabel9.Values.Text = "Hash Type:";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(20, 12);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kbtnCalculateFileHash);
            this.kryptonGroupBox1.Panel.Controls.Add(this.klblRealFileHash);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kcmbHashType1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.klblTotalFiles);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(651, 221);
            this.kryptonGroupBox1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBox1.TabIndex = 2;
            this.kryptonGroupBox1.Values.Heading = "Calculate Checksum";
            // 
            // kbtnCalculateFileHash
            // 
            this.kbtnCalculateFileHash.Enabled = false;
            this.kbtnCalculateFileHash.Location = new System.Drawing.Point(473, 151);
            this.kbtnCalculateFileHash.Name = "kbtnCalculateFileHash";
            this.kbtnCalculateFileHash.Size = new System.Drawing.Size(156, 29);
            this.kbtnCalculateFileHash.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCalculateFileHash.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCalculateFileHash.TabIndex = 9;
            this.kbtnCalculateFileHash.Values.Text = "Calculat&e";
            // 
            // klblRealFileHash
            // 
            this.klblRealFileHash.AutoSize = false;
            this.klblRealFileHash.Location = new System.Drawing.Point(15, 84);
            this.klblRealFileHash.Name = "klblRealFileHash";
            this.klblRealFileHash.Size = new System.Drawing.Size(614, 52);
            this.klblRealFileHash.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRealFileHash.StateCommon.LongText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblRealFileHash.StateCommon.LongText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblRealFileHash.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRealFileHash.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblRealFileHash.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblRealFileHash.TabIndex = 7;
            this.klblRealFileHash.Values.Text = "";
            // 
            // kcmbHashType1
            // 
            this.kcmbHashType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbHashType1.DropDownWidth = 220;
            this.kcmbHashType1.IntegralHeight = false;
            this.kcmbHashType1.Location = new System.Drawing.Point(109, 19);
            this.kcmbHashType1.Name = "kcmbHashType1";
            this.kcmbHashType1.Size = new System.Drawing.Size(132, 25);
            this.kcmbHashType1.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbHashType1.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbHashType1.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbHashType1.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbHashType1.TabIndex = 6;
            // 
            // klblTotalFiles
            // 
            this.klblTotalFiles.Location = new System.Drawing.Point(15, 19);
            this.klblTotalFiles.Name = "klblTotalFiles";
            this.klblTotalFiles.Size = new System.Drawing.Size(88, 24);
            this.klblTotalFiles.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblTotalFiles.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblTotalFiles.TabIndex = 5;
            this.klblTotalFiles.Values.Text = "Hash Type:";
            // 
            // kpFileAttributes
            // 
            this.kpFileAttributes.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpFileAttributes.Controls.Add(this.kbtnGetFileAttributes);
            this.kpFileAttributes.Controls.Add(this.kryptonButton1);
            this.kpFileAttributes.Controls.Add(this.kbtnClearAllFileAttributes);
            this.kpFileAttributes.Controls.Add(this.kryptonGroupBox3);
            this.kpFileAttributes.Flags = 65534;
            this.kpFileAttributes.LastVisibleSet = true;
            this.kpFileAttributes.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpFileAttributes.Name = "kpFileAttributes";
            this.kpFileAttributes.Size = new System.Drawing.Size(690, 644);
            this.kpFileAttributes.Text = "File Attributes";
            this.kpFileAttributes.ToolTipTitle = "Page ToolTip";
            this.kpFileAttributes.UniqueName = "50a26aabd19c4b24a5d601dc8c8dcced";
            this.kpFileAttributes.Visible = false;
            // 
            // kbtnGetFileAttributes
            // 
            this.kbtnGetFileAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnGetFileAttributes.Location = new System.Drawing.Point(65, 272);
            this.kbtnGetFileAttributes.Name = "kbtnGetFileAttributes";
            this.kbtnGetFileAttributes.Size = new System.Drawing.Size(198, 29);
            this.kbtnGetFileAttributes.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGetFileAttributes.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGetFileAttributes.TabIndex = 21;
            this.kbtnGetFileAttributes.Values.Text = "G&et File Attributes";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonButton1.Location = new System.Drawing.Point(269, 272);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(198, 29);
            this.kryptonButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 20;
            this.kryptonButton1.Values.Text = "&Set File Attributes";
            // 
            // kbtnClearAllFileAttributes
            // 
            this.kbtnClearAllFileAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnClearAllFileAttributes.Location = new System.Drawing.Point(473, 272);
            this.kbtnClearAllFileAttributes.Name = "kbtnClearAllFileAttributes";
            this.kbtnClearAllFileAttributes.Size = new System.Drawing.Size(198, 29);
            this.kbtnClearAllFileAttributes.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnClearAllFileAttributes.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnClearAllFileAttributes.TabIndex = 19;
            this.kbtnClearAllFileAttributes.Values.Text = "Cle&ar All File Attributes";
            // 
            // kryptonGroupBox3
            // 
            this.kryptonGroupBox3.Location = new System.Drawing.Point(20, 12);
            this.kryptonGroupBox3.Name = "kryptonGroupBox3";
            // 
            // kryptonGroupBox3.Panel
            // 
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbTemporary);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbSystem);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbSparseFile);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbReparsePoint);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbReadOnly);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbOffline);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbIntegrityStream);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbNormal);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbNoScrubData);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbNotContextIndexed);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbHidden);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbCompressed);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbDevice);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbDirectory);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbEncrypted);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kcbArchive);
            this.kryptonGroupBox3.Size = new System.Drawing.Size(651, 243);
            this.kryptonGroupBox3.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBox3.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBox3.TabIndex = 18;
            this.kryptonGroupBox3.Values.Heading = "Validate Checksum";
            // 
            // kcbTemporary
            // 
            this.kcbTemporary.Location = new System.Drawing.Point(232, 161);
            this.kcbTemporary.Name = "kcbTemporary";
            this.kcbTemporary.Size = new System.Drawing.Size(103, 26);
            this.kcbTemporary.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbTemporary.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbTemporary.TabIndex = 15;
            this.kcbTemporary.ToolTipValues.Description = null;
            this.kcbTemporary.ToolTipValues.Heading = "Archived";
            this.kcbTemporary.Values.Text = "Te&mporary";
            // 
            // kcbSystem
            // 
            this.kcbSystem.Location = new System.Drawing.Point(133, 161);
            this.kcbSystem.Name = "kcbSystem";
            this.kcbSystem.Size = new System.Drawing.Size(77, 26);
            this.kcbSystem.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbSystem.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbSystem.TabIndex = 14;
            this.kcbSystem.ToolTipValues.Description = null;
            this.kcbSystem.ToolTipValues.Heading = "Archived";
            this.kcbSystem.Values.Text = "S&ystem";
            // 
            // kcbSparseFile
            // 
            this.kcbSparseFile.Location = new System.Drawing.Point(15, 161);
            this.kcbSparseFile.Name = "kcbSparseFile";
            this.kcbSparseFile.Size = new System.Drawing.Size(102, 26);
            this.kcbSparseFile.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbSparseFile.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbSparseFile.TabIndex = 13;
            this.kcbSparseFile.ToolTipValues.Description = null;
            this.kcbSparseFile.ToolTipValues.Heading = "Archived";
            this.kcbSparseFile.Values.Text = "Spar&se File";
            // 
            // kcbReparsePoint
            // 
            this.kcbReparsePoint.Location = new System.Drawing.Point(476, 114);
            this.kcbReparsePoint.Name = "kcbReparsePoint";
            this.kcbReparsePoint.Size = new System.Drawing.Size(125, 26);
            this.kcbReparsePoint.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbReparsePoint.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbReparsePoint.TabIndex = 12;
            this.kcbReparsePoint.ToolTipValues.Description = null;
            this.kcbReparsePoint.ToolTipValues.Heading = "Archived";
            this.kcbReparsePoint.Values.Text = "Re&parse Point";
            // 
            // kcbReadOnly
            // 
            this.kcbReadOnly.Location = new System.Drawing.Point(348, 114);
            this.kcbReadOnly.Name = "kcbReadOnly";
            this.kcbReadOnly.Size = new System.Drawing.Size(100, 26);
            this.kcbReadOnly.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbReadOnly.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbReadOnly.TabIndex = 11;
            this.kcbReadOnly.ToolTipValues.Description = null;
            this.kcbReadOnly.ToolTipValues.Heading = "Archived";
            this.kcbReadOnly.Values.Text = "&Read Only";
            // 
            // kcbOffline
            // 
            this.kcbOffline.Location = new System.Drawing.Point(232, 114);
            this.kcbOffline.Name = "kcbOffline";
            this.kcbOffline.Size = new System.Drawing.Size(73, 26);
            this.kcbOffline.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbOffline.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbOffline.TabIndex = 10;
            this.kcbOffline.ToolTipValues.Description = null;
            this.kcbOffline.ToolTipValues.Heading = "Archived";
            this.kcbOffline.Values.Text = "O&ffline";
            // 
            // kcbIntegrityStream
            // 
            this.kcbIntegrityStream.Location = new System.Drawing.Point(133, 67);
            this.kcbIntegrityStream.Name = "kcbIntegrityStream";
            this.kcbIntegrityStream.Size = new System.Drawing.Size(142, 26);
            this.kcbIntegrityStream.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbIntegrityStream.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbIntegrityStream.TabIndex = 9;
            this.kcbIntegrityStream.Values.Text = "I&ntegrity Stream";
            // 
            // kcbNormal
            // 
            this.kcbNormal.Location = new System.Drawing.Point(287, 67);
            this.kcbNormal.Name = "kcbNormal";
            this.kcbNormal.Size = new System.Drawing.Size(79, 26);
            this.kcbNormal.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbNormal.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbNormal.TabIndex = 8;
            this.kcbNormal.Values.Text = "No&rmal";
            // 
            // kcbNoScrubData
            // 
            this.kcbNoScrubData.Location = new System.Drawing.Point(399, 67);
            this.kcbNoScrubData.Name = "kcbNoScrubData";
            this.kcbNoScrubData.Size = new System.Drawing.Size(131, 26);
            this.kcbNoScrubData.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbNoScrubData.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbNoScrubData.TabIndex = 7;
            this.kcbNoScrubData.Values.Text = "No &Scrub Data";
            // 
            // kcbNotContextIndexed
            // 
            this.kcbNotContextIndexed.Location = new System.Drawing.Point(15, 114);
            this.kcbNotContextIndexed.Name = "kcbNotContextIndexed";
            this.kcbNotContextIndexed.Size = new System.Drawing.Size(176, 26);
            this.kcbNotContextIndexed.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbNotContextIndexed.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbNotContextIndexed.TabIndex = 6;
            this.kcbNotContextIndexed.Values.Text = "Not Co&ntext Indexed";
            // 
            // kcbHidden
            // 
            this.kcbHidden.Location = new System.Drawing.Point(15, 67);
            this.kcbHidden.Name = "kcbHidden";
            this.kcbHidden.Size = new System.Drawing.Size(78, 26);
            this.kcbHidden.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbHidden.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbHidden.TabIndex = 5;
            this.kcbHidden.ToolTipValues.Description = null;
            this.kcbHidden.ToolTipValues.Heading = "Archived";
            this.kcbHidden.Values.Text = "&Hidden";
            // 
            // kcbCompressed
            // 
            this.kcbCompressed.Location = new System.Drawing.Point(133, 19);
            this.kcbCompressed.Name = "kcbCompressed";
            this.kcbCompressed.Size = new System.Drawing.Size(115, 26);
            this.kcbCompressed.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbCompressed.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbCompressed.TabIndex = 4;
            this.kcbCompressed.Values.Text = "C&ompressed";
            // 
            // kcbDevice
            // 
            this.kcbDevice.Location = new System.Drawing.Point(287, 19);
            this.kcbDevice.Name = "kcbDevice";
            this.kcbDevice.Size = new System.Drawing.Size(73, 26);
            this.kcbDevice.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbDevice.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbDevice.TabIndex = 3;
            this.kcbDevice.Values.Text = "D&evice";
            // 
            // kcbDirectory
            // 
            this.kcbDirectory.Location = new System.Drawing.Point(399, 19);
            this.kcbDirectory.Name = "kcbDirectory";
            this.kcbDirectory.Size = new System.Drawing.Size(91, 26);
            this.kcbDirectory.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbDirectory.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbDirectory.TabIndex = 2;
            this.kcbDirectory.Values.Text = "D&irectory";
            // 
            // kcbEncrypted
            // 
            this.kcbEncrypted.Location = new System.Drawing.Point(529, 19);
            this.kcbEncrypted.Name = "kcbEncrypted";
            this.kcbEncrypted.Size = new System.Drawing.Size(97, 26);
            this.kcbEncrypted.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbEncrypted.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbEncrypted.TabIndex = 1;
            this.kcbEncrypted.Values.Text = "&Encrypted";
            // 
            // kcbArchive
            // 
            this.kcbArchive.Location = new System.Drawing.Point(15, 19);
            this.kcbArchive.Name = "kcbArchive";
            this.kcbArchive.Size = new System.Drawing.Size(79, 26);
            this.kcbArchive.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbArchive.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbArchive.TabIndex = 0;
            this.kcbArchive.ToolTipValues.Description = null;
            this.kcbArchive.ToolTipValues.Heading = "Archived";
            this.kcbArchive.Values.Text = "&Archive";
            // 
            // ctxHashMenu
            // 
            this.ctxHashMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctxHashMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.copyToolStripMenuItem,
            this.toolStripMenuItem2,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem3,
            this.selectAllToolStripMenuItem});
            this.ctxHashMenu.Name = "ctxHashMenu";
            this.ctxHashMenu.Size = new System.Drawing.Size(123, 110);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "C&ut";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(119, 6);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(119, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "&Select All";
            // 
            // bgwMD5
            // 
            this.bgwMD5.WorkerReportsProgress = true;
            this.bgwMD5.WorkerSupportsCancellation = true;
            // 
            // bgwSHA1
            // 
            this.bgwSHA1.WorkerReportsProgress = true;
            this.bgwSHA1.WorkerSupportsCancellation = true;
            // 
            // bgwSHA256
            // 
            this.bgwSHA256.WorkerReportsProgress = true;
            this.bgwSHA256.WorkerSupportsCancellation = true;
            // 
            // bgwSHA384
            // 
            this.bgwSHA384.WorkerReportsProgress = true;
            this.bgwSHA384.WorkerSupportsCancellation = true;
            // 
            // bgwSHA512
            // 
            this.bgwSHA512.WorkerReportsProgress = true;
            this.bgwSHA512.WorkerSupportsCancellation = true;
            // 
            // bgwRIPEMD160
            // 
            this.bgwRIPEMD160.WorkerReportsProgress = true;
            this.bgwRIPEMD160.WorkerSupportsCancellation = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 688);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(720, 3);
            this.panel5.TabIndex = 5;
            // 
            // KryptonFileInformationDialogOld
            // 
            this.AcceptButton = this.kbtnOk;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(720, 748);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.kryptonPanelExtended1);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonFileInformationDialogOld";
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelExtended1)).EndInit();
            this.kryptonPanelExtended1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            this.kryptonPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFileIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbValidatedHashType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHashType1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpFileAttributes)).EndInit();
            this.kpFileAttributes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).EndInit();
            this.kryptonGroupBox3.Panel.ResumeLayout(false);
            this.kryptonGroupBox3.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).EndInit();
            this.kryptonGroupBox3.ResumeLayout(false);
            this.ctxHashMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
using Krypton.Toolkit.Extended.Common;
using Krypton.Toolkit.Extended.Core;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using ExceptionHandler = Krypton.Toolkit.Extended.Core.ExceptionHandler;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonFileInformationDialog : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonOKDialogButton kryptonOKDialogButton1;
        private KryptonCancelDialogButton kryptonCancelDialogButton1;
        private KryptonPanel kryptonPanel2;
        private Navigator.KryptonNavigator kryptonNavigator1;
        private Navigator.KryptonPage kryptonPage1;
        private Navigator.KryptonPage kryptonPage2;
        private System.Windows.Forms.PictureBox pbxFileIcon;
        private Navigator.KryptonPage kryptonPage3;
        private KryptonTextBox ktxtFileName;
        private System.Windows.Forms.Panel panel3;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klbleFileType;
        private System.Windows.Forms.Panel panel2;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klbleModified;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klbleAccessed;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klbleCreated;
        private System.Windows.Forms.Panel panel4;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klbleFileSize;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klbeSizeOnDisk;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klbleFileLocation;
        private Suite.Extended.Standard.Controls.KryptonGroupBoxExtended kryptonGroupBoxExtended1;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klbleChecksumOutput;
        private Suite.Extended.Standard.Controls.KryptonComboBoxExtended kcmbeCalculateChecksumHashType;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended kryptonLabelExtended8;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended2;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnCalculateChecksum;
        private Suite.Extended.Standard.Controls.KryptonGroupBoxExtended kryptonGroupBoxExtended2;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtneValidateChecksum;
        private Suite.Extended.Standard.Controls.KryptonComboBoxExtended kcmbeValidateChecksumType;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended kryptonLabelExtended11;
        private Suite.Extended.Standard.Controls.KryptonTextBoxExtended ktxtFileHash;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnImportHash;
        private Suite.Extended.Standard.Controls.KryptonGroupBoxExtended kryptonGroupBoxExtended3;
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
        private KryptonButton kbtnGetFileAttributes;
        private KryptonButton kbtnSetFileAttributes;
        private KryptonButton kbtnClearAllFileAttributes;
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
        private System.Windows.Forms.Panel panel1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonButtonExtended2 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kryptonOKDialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonOKDialogButton();
            this.kryptonCancelDialogButton1 = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonNavigator1 = new Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new Krypton.Navigator.KryptonPage();
            this.klbleModified = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.klbleAccessed = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.klbleCreated = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.panel4 = new System.Windows.Forms.Panel();
            this.klbleFileSize = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.klbeSizeOnDisk = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.klbleFileLocation = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.panel3 = new System.Windows.Forms.Panel();
            this.klbleFileType = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ktxtFileName = new Krypton.Toolkit.KryptonTextBox();
            this.pbxFileIcon = new System.Windows.Forms.PictureBox();
            this.kryptonPage2 = new Krypton.Navigator.KryptonPage();
            this.kryptonGroupBoxExtended2 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonGroupBoxExtended();
            this.kbtnImportHash = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.ktxtFileHash = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonTextBoxExtended();
            this.ctxHashMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kbtneValidateChecksum = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kcmbeValidateChecksumType = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonComboBoxExtended();
            this.kryptonLabelExtended11 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.kryptonGroupBoxExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonGroupBoxExtended();
            this.kbtnCalculateChecksum = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.klbleChecksumOutput = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.kcmbeCalculateChecksumHashType = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonComboBoxExtended();
            this.kryptonLabelExtended8 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.kryptonPage3 = new Krypton.Navigator.KryptonPage();
            this.kbtnGetFileAttributes = new Krypton.Toolkit.KryptonButton();
            this.kbtnSetFileAttributes = new Krypton.Toolkit.KryptonButton();
            this.kbtnClearAllFileAttributes = new Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBoxExtended3 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonGroupBoxExtended();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bgwMD5 = new System.ComponentModel.BackgroundWorker();
            this.bgwSHA1 = new System.ComponentModel.BackgroundWorker();
            this.bgwSHA256 = new System.ComponentModel.BackgroundWorker();
            this.bgwSHA384 = new System.ComponentModel.BackgroundWorker();
            this.bgwSHA512 = new System.ComponentModel.BackgroundWorker();
            this.bgwRIPEMD160 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFileIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.kryptonPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended2.Panel)).BeginInit();
            this.kryptonGroupBoxExtended2.Panel.SuspendLayout();
            this.kryptonGroupBoxExtended2.SuspendLayout();
            this.ctxHashMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbeValidateChecksumType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended1.Panel)).BeginInit();
            this.kryptonGroupBoxExtended1.Panel.SuspendLayout();
            this.kryptonGroupBoxExtended1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbeCalculateChecksumHashType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended3.Panel)).BeginInit();
            this.kryptonGroupBoxExtended3.Panel.SuspendLayout();
            this.kryptonGroupBoxExtended3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButtonExtended2);
            this.kryptonPanel1.Controls.Add(this.kryptonOKDialogButton1);
            this.kryptonPanel1.Controls.Add(this.kryptonCancelDialogButton1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 585);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(608, 46);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonButtonExtended2
            // 
            this.kryptonButtonExtended2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonButtonExtended2.Image = null;
            this.kryptonButtonExtended2.Location = new System.Drawing.Point(314, 9);
            this.kryptonButtonExtended2.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.Name = "kryptonButtonExtended2";
            this.kryptonButtonExtended2.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.Size = new System.Drawing.Size(90, 25);
            this.kryptonButtonExtended2.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.TabIndex = 2;
            this.kryptonButtonExtended2.Values.Text = "&Apply";
            // 
            // kryptonOKDialogButton1
            // 
            this.kryptonOKDialogButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonOKDialogButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonOKDialogButton1.Image = null;
            this.kryptonOKDialogButton1.Location = new System.Drawing.Point(410, 9);
            this.kryptonOKDialogButton1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.Name = "kryptonOKDialogButton1";
            this.kryptonOKDialogButton1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonOKDialogButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonOKDialogButton1.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonOKDialogButton1.TabIndex = 1;
            this.kryptonOKDialogButton1.Values.Text = "&OK";
            // 
            // kryptonCancelDialogButton1
            // 
            this.kryptonCancelDialogButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonCancelDialogButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonCancelDialogButton1.Image = null;
            this.kryptonCancelDialogButton1.Location = new System.Drawing.Point(506, 9);
            this.kryptonCancelDialogButton1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.Name = "kryptonCancelDialogButton1";
            this.kryptonCancelDialogButton1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonCancelDialogButton1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonCancelDialogButton1.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonCancelDialogButton1.TabIndex = 0;
            this.kryptonCancelDialogButton1.Values.Text = "C&ancel";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonNavigator1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(608, 585);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Location = new System.Drawing.Point(12, 12);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2,
            this.kryptonPage3});
            this.kryptonNavigator1.SelectedIndex = 2;
            this.kryptonNavigator1.Size = new System.Drawing.Size(584, 564);
            this.kryptonNavigator1.TabIndex = 0;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.klbleModified);
            this.kryptonPage1.Controls.Add(this.klbleAccessed);
            this.kryptonPage1.Controls.Add(this.klbleCreated);
            this.kryptonPage1.Controls.Add(this.panel4);
            this.kryptonPage1.Controls.Add(this.klbleFileSize);
            this.kryptonPage1.Controls.Add(this.klbeSizeOnDisk);
            this.kryptonPage1.Controls.Add(this.klbleFileLocation);
            this.kryptonPage1.Controls.Add(this.panel3);
            this.kryptonPage1.Controls.Add(this.klbleFileType);
            this.kryptonPage1.Controls.Add(this.panel2);
            this.kryptonPage1.Controls.Add(this.ktxtFileName);
            this.kryptonPage1.Controls.Add(this.pbxFileIcon);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(582, 537);
            this.kryptonPage1.Text = "General";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "8ee7ca79748141e2ad1680003cb46cdc";
            // 
            // klbleModified
            // 
            this.klbleModified.Image = null;
            this.klbleModified.Location = new System.Drawing.Point(15, 284);
            this.klbleModified.LongTextTypeface = null;
            this.klbleModified.Name = "klbleModified";
            this.klbleModified.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleModified.Size = new System.Drawing.Size(97, 21);
            this.klbleModified.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleModified.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klbleModified.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klbleModified.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleModified.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klbleModified.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klbleModified.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleModified.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klbleModified.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klbleModified.TabIndex = 24;
            this.klbleModified.Values.Text = "Modified: {0}";
            // 
            // klbleAccessed
            // 
            this.klbleAccessed.Image = null;
            this.klbleAccessed.Location = new System.Drawing.Point(15, 325);
            this.klbleAccessed.LongTextTypeface = null;
            this.klbleAccessed.Name = "klbleAccessed";
            this.klbleAccessed.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleAccessed.Size = new System.Drawing.Size(106, 21);
            this.klbleAccessed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleAccessed.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klbleAccessed.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klbleAccessed.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleAccessed.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klbleAccessed.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klbleAccessed.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleAccessed.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klbleAccessed.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klbleAccessed.TabIndex = 23;
            this.klbleAccessed.Values.Text = "Accessed: {0}";
            // 
            // klbleCreated
            // 
            this.klbleCreated.Image = null;
            this.klbleCreated.Location = new System.Drawing.Point(15, 243);
            this.klbleCreated.LongTextTypeface = null;
            this.klbleCreated.Name = "klbleCreated";
            this.klbleCreated.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleCreated.Size = new System.Drawing.Size(94, 21);
            this.klbleCreated.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleCreated.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klbleCreated.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klbleCreated.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleCreated.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klbleCreated.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klbleCreated.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleCreated.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klbleCreated.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klbleCreated.TabIndex = 22;
            this.klbleCreated.Values.Text = "Created: {0}";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel4.Location = new System.Drawing.Point(15, 236);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(547, 1);
            this.panel4.TabIndex = 21;
            // 
            // klbleFileSize
            // 
            this.klbleFileSize.Image = null;
            this.klbleFileSize.Location = new System.Drawing.Point(15, 168);
            this.klbleFileSize.LongTextTypeface = null;
            this.klbleFileSize.Name = "klbleFileSize";
            this.klbleFileSize.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleFileSize.Size = new System.Drawing.Size(69, 21);
            this.klbleFileSize.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleFileSize.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klbleFileSize.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klbleFileSize.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleFileSize.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klbleFileSize.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klbleFileSize.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleFileSize.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klbleFileSize.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klbleFileSize.TabIndex = 20;
            this.klbleFileSize.Values.Text = "Size: {0}";
            // 
            // klbeSizeOnDisk
            // 
            this.klbeSizeOnDisk.Image = null;
            this.klbeSizeOnDisk.Location = new System.Drawing.Point(15, 209);
            this.klbeSizeOnDisk.LongTextTypeface = null;
            this.klbeSizeOnDisk.Name = "klbeSizeOnDisk";
            this.klbeSizeOnDisk.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbeSizeOnDisk.Size = new System.Drawing.Size(124, 21);
            this.klbeSizeOnDisk.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbeSizeOnDisk.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klbeSizeOnDisk.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klbeSizeOnDisk.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbeSizeOnDisk.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klbeSizeOnDisk.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klbeSizeOnDisk.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbeSizeOnDisk.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klbeSizeOnDisk.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klbeSizeOnDisk.TabIndex = 19;
            this.klbeSizeOnDisk.Values.Text = "Size on Disk: {0}";
            // 
            // klbleFileLocation
            // 
            this.klbleFileLocation.Image = null;
            this.klbleFileLocation.Location = new System.Drawing.Point(15, 127);
            this.klbleFileLocation.LongTextTypeface = null;
            this.klbleFileLocation.Name = "klbleFileLocation";
            this.klbleFileLocation.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleFileLocation.Size = new System.Drawing.Size(97, 21);
            this.klbleFileLocation.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleFileLocation.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klbleFileLocation.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klbleFileLocation.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleFileLocation.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klbleFileLocation.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klbleFileLocation.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleFileLocation.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klbleFileLocation.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klbleFileLocation.TabIndex = 18;
            this.klbleFileLocation.Values.Text = "Location: {0}";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Location = new System.Drawing.Point(15, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(547, 1);
            this.panel3.TabIndex = 17;
            // 
            // klbleFileType
            // 
            this.klbleFileType.Image = null;
            this.klbleFileType.Location = new System.Drawing.Point(15, 93);
            this.klbleFileType.LongTextTypeface = null;
            this.klbleFileType.Name = "klbleFileType";
            this.klbleFileType.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleFileType.Size = new System.Drawing.Size(114, 21);
            this.klbleFileType.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleFileType.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klbleFileType.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klbleFileType.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleFileType.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klbleFileType.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klbleFileType.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleFileType.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klbleFileType.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klbleFileType.TabIndex = 17;
            this.klbleFileType.Values.Text = "Type of file: {0}";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Location = new System.Drawing.Point(15, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 1);
            this.panel2.TabIndex = 16;
            // 
            // ktxtFileName
            // 
            this.ktxtFileName.Hint = "Filename.*";
            this.ktxtFileName.Location = new System.Drawing.Point(86, 36);
            this.ktxtFileName.Name = "ktxtFileName";
            this.ktxtFileName.Size = new System.Drawing.Size(475, 24);
            this.ktxtFileName.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtFileName.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtFileName.TabIndex = 1;
            // 
            // pbxFileIcon
            // 
            this.pbxFileIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxFileIcon.Location = new System.Drawing.Point(15, 15);
            this.pbxFileIcon.Name = "pbxFileIcon";
            this.pbxFileIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxFileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxFileIcon.TabIndex = 0;
            this.pbxFileIcon.TabStop = false;
            this.pbxFileIcon.Click += new System.EventHandler(this.pbxFileIcon_Click);
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Controls.Add(this.kryptonGroupBoxExtended2);
            this.kryptonPage2.Controls.Add(this.kryptonGroupBoxExtended1);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(582, 537);
            this.kryptonPage2.Text = "Checksums";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "3fddb318e3194de0a134c27f0424cd5d";
            // 
            // kryptonGroupBoxExtended2
            // 
            this.kryptonGroupBoxExtended2.Image = null;
            this.kryptonGroupBoxExtended2.Location = new System.Drawing.Point(15, 209);
            this.kryptonGroupBoxExtended2.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonGroupBoxExtended2.Name = "kryptonGroupBoxExtended2";
            // 
            // kryptonGroupBoxExtended2.Panel
            // 
            this.kryptonGroupBoxExtended2.Panel.Controls.Add(this.kbtnImportHash);
            this.kryptonGroupBoxExtended2.Panel.Controls.Add(this.ktxtFileHash);
            this.kryptonGroupBoxExtended2.Panel.Controls.Add(this.kbtneValidateChecksum);
            this.kryptonGroupBoxExtended2.Panel.Controls.Add(this.kcmbeValidateChecksumType);
            this.kryptonGroupBoxExtended2.Panel.Controls.Add(this.kryptonLabelExtended11);
            this.kryptonGroupBoxExtended2.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBoxExtended2.Size = new System.Drawing.Size(547, 174);
            this.kryptonGroupBoxExtended2.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonGroupBoxExtended2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBoxExtended2.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.TabIndex = 1;
            this.kryptonGroupBoxExtended2.Values.Heading = "Validate Checksum";
            // 
            // kbtnImportHash
            // 
            this.kbtnImportHash.Image = null;
            this.kbtnImportHash.Location = new System.Drawing.Point(296, 116);
            this.kbtnImportHash.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.Name = "kbtnImportHash";
            this.kbtnImportHash.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.Size = new System.Drawing.Size(114, 25);
            this.kbtnImportHash.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnImportHash.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnImportHash.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnImportHash.TabIndex = 7;
            this.kbtnImportHash.Values.Text = "Impo&rt Hash";
            // 
            // ktxtFileHash
            // 
            this.ktxtFileHash.ContextMenuStrip = this.ctxHashMenu;
            this.ktxtFileHash.Hint = "File hash here...";
            this.ktxtFileHash.Location = new System.Drawing.Point(13, 60);
            this.ktxtFileHash.Name = "ktxtFileHash";
            this.ktxtFileHash.Size = new System.Drawing.Size(517, 26);
            this.ktxtFileHash.StateActive.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtFileHash.StateActive.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtFileHash.StateActiveBackGroundColour = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateActiveBorderColourOne = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateActiveBorderColourTwo = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateActiveTextColour = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtFileHash.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtFileHash.StateCommonBackGroundColour = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateCommonTextColour = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateDisabled.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtFileHash.StateDisabled.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtFileHash.StateDisabledBackGroundColour = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateDisabledTextColour = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtFileHash.StateNormal.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtFileHash.StateNormalBackgroundColour = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.ktxtFileHash.StateNormalTextColour = System.Drawing.Color.Empty;
            this.ktxtFileHash.TabIndex = 6;
            this.ktxtFileHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtFileHash.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ctxHashMenu.Size = new System.Drawing.Size(181, 132);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cutToolStripMenuItem.Text = "C&ut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
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
            // kbtneValidateChecksum
            // 
            this.kbtneValidateChecksum.Image = null;
            this.kbtneValidateChecksum.Location = new System.Drawing.Point(416, 116);
            this.kbtneValidateChecksum.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.Name = "kbtneValidateChecksum";
            this.kbtneValidateChecksum.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.Size = new System.Drawing.Size(114, 25);
            this.kbtneValidateChecksum.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtneValidateChecksum.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtneValidateChecksum.TabIndex = 5;
            this.kbtneValidateChecksum.Values.Text = "&Validate";
            this.kbtneValidateChecksum.Click += new System.EventHandler(this.kbtneValidateChecksum_Click);
            // 
            // kcmbeValidateChecksumType
            // 
            this.kcmbeValidateChecksumType.ComboBoxContentTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.ComboBoxItemContentLongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.ComboBoxItemContentShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbeValidateChecksumType.DropDownWidth = 121;
            this.kcmbeValidateChecksumType.Image = null;
            this.kcmbeValidateChecksumType.IntegralHeight = false;
            this.kcmbeValidateChecksumType.Location = new System.Drawing.Point(118, 14);
            this.kcmbeValidateChecksumType.Name = "kcmbeValidateChecksumType";
            this.kcmbeValidateChecksumType.Size = new System.Drawing.Size(121, 22);
            this.kcmbeValidateChecksumType.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.StateActive.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeValidateChecksumType.StateActiveComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateActiveComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateActiveComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateActiveComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbeValidateChecksumType.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.StateCommonComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateCommonComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateCommonComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateCommonComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateCommonComboBoxDropBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateCommonComboBoxDropBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateCommonComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateCommonComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateCommonComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateCommonComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateCommonComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateCommonComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.StateDisabled.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeValidateChecksumType.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.StateDisabledComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateDisabledComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateDisabledComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateDisabledComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateDisabledComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateDisabledComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateDisabledComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateDisabledComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateDisabledComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateDisabledComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.StateNormal.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeValidateChecksumType.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.StateNormalComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateNormalComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateNormalComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateNormalComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateNormalComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateNormalComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateNormalComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateNormalComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateNormalComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateNormalComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeValidateChecksumType.StateTrackingComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateTrackingComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateTrackingComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateTrackingComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateTrackingComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.StateTrackingComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeValidateChecksumType.TabIndex = 3;
            // 
            // kryptonLabelExtended11
            // 
            this.kryptonLabelExtended11.Image = null;
            this.kryptonLabelExtended11.Location = new System.Drawing.Point(13, 12);
            this.kryptonLabelExtended11.LongTextTypeface = null;
            this.kryptonLabelExtended11.Name = "kryptonLabelExtended11";
            this.kryptonLabelExtended11.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended11.Size = new System.Drawing.Size(99, 23);
            this.kryptonLabelExtended11.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended11.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended11.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended11.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended11.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended11.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended11.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended11.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended11.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended11.TabIndex = 3;
            this.kryptonLabelExtended11.Values.Text = "Hash Type:";
            // 
            // kryptonGroupBoxExtended1
            // 
            this.kryptonGroupBoxExtended1.Image = null;
            this.kryptonGroupBoxExtended1.Location = new System.Drawing.Point(15, 15);
            this.kryptonGroupBoxExtended1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonGroupBoxExtended1.Name = "kryptonGroupBoxExtended1";
            // 
            // kryptonGroupBoxExtended1.Panel
            // 
            this.kryptonGroupBoxExtended1.Panel.Controls.Add(this.kbtnCalculateChecksum);
            this.kryptonGroupBoxExtended1.Panel.Controls.Add(this.klbleChecksumOutput);
            this.kryptonGroupBoxExtended1.Panel.Controls.Add(this.kcmbeCalculateChecksumHashType);
            this.kryptonGroupBoxExtended1.Panel.Controls.Add(this.kryptonLabelExtended8);
            this.kryptonGroupBoxExtended1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBoxExtended1.Size = new System.Drawing.Size(547, 174);
            this.kryptonGroupBoxExtended1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonGroupBoxExtended1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBoxExtended1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.TabIndex = 0;
            this.kryptonGroupBoxExtended1.Values.Heading = "Calculate Checksum";
            // 
            // kbtnCalculateChecksum
            // 
            this.kbtnCalculateChecksum.Image = null;
            this.kbtnCalculateChecksum.Location = new System.Drawing.Point(416, 116);
            this.kbtnCalculateChecksum.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.Name = "kbtnCalculateChecksum";
            this.kbtnCalculateChecksum.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.Size = new System.Drawing.Size(114, 25);
            this.kbtnCalculateChecksum.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCalculateChecksum.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCalculateChecksum.TabIndex = 5;
            this.kbtnCalculateChecksum.Values.Text = "&Calculate";
            this.kbtnCalculateChecksum.Click += new System.EventHandler(this.KbtnCalculateChecksum_Click);
            // 
            // klbleChecksumOutput
            // 
            this.klbleChecksumOutput.AutoSize = false;
            this.klbleChecksumOutput.Image = null;
            this.klbleChecksumOutput.Location = new System.Drawing.Point(13, 47);
            this.klbleChecksumOutput.LongTextTypeface = null;
            this.klbleChecksumOutput.Name = "klbleChecksumOutput";
            this.klbleChecksumOutput.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleChecksumOutput.Size = new System.Drawing.Size(517, 63);
            this.klbleChecksumOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleChecksumOutput.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klbleChecksumOutput.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klbleChecksumOutput.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klbleChecksumOutput.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleChecksumOutput.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klbleChecksumOutput.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klbleChecksumOutput.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klbleChecksumOutput.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klbleChecksumOutput.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klbleChecksumOutput.TabIndex = 4;
            this.klbleChecksumOutput.Values.Text = "{0}";
            // 
            // kcmbeCalculateChecksumHashType
            // 
            this.kcmbeCalculateChecksumHashType.ComboBoxContentTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.ComboBoxItemContentLongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.ComboBoxItemContentShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbeCalculateChecksumHashType.DropDownWidth = 121;
            this.kcmbeCalculateChecksumHashType.Image = null;
            this.kcmbeCalculateChecksumHashType.IntegralHeight = false;
            this.kcmbeCalculateChecksumHashType.Location = new System.Drawing.Point(118, 14);
            this.kcmbeCalculateChecksumHashType.Name = "kcmbeCalculateChecksumHashType";
            this.kcmbeCalculateChecksumHashType.Size = new System.Drawing.Size(121, 22);
            this.kcmbeCalculateChecksumHashType.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.StateActive.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeCalculateChecksumHashType.StateActiveComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateActiveComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateActiveComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateActiveComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbeCalculateChecksumHashType.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.StateCommonComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateCommonComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateCommonComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateCommonComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateCommonComboBoxDropBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateCommonComboBoxDropBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateCommonComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateCommonComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateCommonComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateCommonComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateCommonComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateCommonComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.StateDisabled.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeCalculateChecksumHashType.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.StateDisabledComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateDisabledComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateDisabledComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateDisabledComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateDisabledComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateDisabledComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateDisabledComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateDisabledComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateDisabledComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateDisabledComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.StateNormal.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeCalculateChecksumHashType.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.StateNormalComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateNormalComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateNormalComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateNormalComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateNormalComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateNormalComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateNormalComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateNormalComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateNormalComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateNormalComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeCalculateChecksumHashType.StateTrackingComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateTrackingComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateTrackingComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateTrackingComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateTrackingComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.StateTrackingComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeCalculateChecksumHashType.TabIndex = 3;
            // 
            // kryptonLabelExtended8
            // 
            this.kryptonLabelExtended8.Image = null;
            this.kryptonLabelExtended8.Location = new System.Drawing.Point(13, 12);
            this.kryptonLabelExtended8.LongTextTypeface = null;
            this.kryptonLabelExtended8.Name = "kryptonLabelExtended8";
            this.kryptonLabelExtended8.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended8.Size = new System.Drawing.Size(99, 23);
            this.kryptonLabelExtended8.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended8.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended8.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended8.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended8.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended8.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended8.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended8.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended8.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended8.TabIndex = 3;
            this.kryptonLabelExtended8.Values.Text = "Hash Type:";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Controls.Add(this.kbtnGetFileAttributes);
            this.kryptonPage3.Controls.Add(this.kbtnSetFileAttributes);
            this.kryptonPage3.Controls.Add(this.kbtnClearAllFileAttributes);
            this.kryptonPage3.Controls.Add(this.kryptonGroupBoxExtended3);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(582, 537);
            this.kryptonPage3.Text = "File Attributes";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "8e92f6dd15a247e8a902b4d38f68d539";
            // 
            // kbtnGetFileAttributes
            // 
            this.kbtnGetFileAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnGetFileAttributes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGetFileAttributes.Location = new System.Drawing.Point(174, 185);
            this.kbtnGetFileAttributes.Name = "kbtnGetFileAttributes";
            this.kbtnGetFileAttributes.Size = new System.Drawing.Size(121, 25);
            this.kbtnGetFileAttributes.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGetFileAttributes.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGetFileAttributes.TabIndex = 24;
            this.kbtnGetFileAttributes.Values.Text = "G&et File Attributes";
            this.kbtnGetFileAttributes.Click += new System.EventHandler(this.kbtnGetFileAttributes_Click);
            // 
            // kbtnSetFileAttributes
            // 
            this.kbtnSetFileAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnSetFileAttributes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnSetFileAttributes.Location = new System.Drawing.Point(301, 185);
            this.kbtnSetFileAttributes.Name = "kbtnSetFileAttributes";
            this.kbtnSetFileAttributes.Size = new System.Drawing.Size(111, 25);
            this.kbtnSetFileAttributes.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSetFileAttributes.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSetFileAttributes.TabIndex = 23;
            this.kbtnSetFileAttributes.Values.Text = "&Set File Attributes";
            // 
            // kbtnClearAllFileAttributes
            // 
            this.kbtnClearAllFileAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnClearAllFileAttributes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnClearAllFileAttributes.Location = new System.Drawing.Point(417, 185);
            this.kbtnClearAllFileAttributes.Name = "kbtnClearAllFileAttributes";
            this.kbtnClearAllFileAttributes.Size = new System.Drawing.Size(145, 25);
            this.kbtnClearAllFileAttributes.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnClearAllFileAttributes.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnClearAllFileAttributes.TabIndex = 22;
            this.kbtnClearAllFileAttributes.Values.Text = "Cle&ar All File Attributes";
            this.kbtnClearAllFileAttributes.Click += new System.EventHandler(this.kbtnClearAllFileAttributes_Click);
            // 
            // kryptonGroupBoxExtended3
            // 
            this.kryptonGroupBoxExtended3.Image = null;
            this.kryptonGroupBoxExtended3.Location = new System.Drawing.Point(15, 15);
            this.kryptonGroupBoxExtended3.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonGroupBoxExtended3.Name = "kryptonGroupBoxExtended3";
            // 
            // kryptonGroupBoxExtended3.Panel
            // 
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbTemporary);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbSystem);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbSparseFile);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbReparsePoint);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbReadOnly);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbOffline);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbIntegrityStream);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbNormal);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbNoScrubData);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbNotContextIndexed);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbHidden);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbCompressed);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbDevice);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbDirectory);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbEncrypted);
            this.kryptonGroupBoxExtended3.Panel.Controls.Add(this.kcbArchive);
            this.kryptonGroupBoxExtended3.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBoxExtended3.Size = new System.Drawing.Size(547, 164);
            this.kryptonGroupBoxExtended3.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonGroupBoxExtended3.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBoxExtended3.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended3.TabIndex = 1;
            this.kryptonGroupBoxExtended3.Values.Heading = "Calculate Checksum";
            // 
            // kcbTemporary
            // 
            this.kcbTemporary.Location = new System.Drawing.Point(204, 109);
            this.kcbTemporary.Name = "kcbTemporary";
            this.kcbTemporary.Size = new System.Drawing.Size(99, 21);
            this.kcbTemporary.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbTemporary.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbTemporary.TabIndex = 31;
            this.kcbTemporary.ToolTipValues.Description = null;
            this.kcbTemporary.ToolTipValues.Heading = "Archived";
            this.kcbTemporary.Values.Text = "Te&mporary";
            this.kcbTemporary.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbSystem
            // 
            this.kcbSystem.Location = new System.Drawing.Point(122, 109);
            this.kcbSystem.Name = "kcbSystem";
            this.kcbSystem.Size = new System.Drawing.Size(76, 21);
            this.kcbSystem.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbSystem.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbSystem.TabIndex = 30;
            this.kcbSystem.ToolTipValues.Description = null;
            this.kcbSystem.ToolTipValues.Heading = "Archived";
            this.kcbSystem.Values.Text = "S&ystem";
            this.kcbSystem.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbSparseFile
            // 
            this.kcbSparseFile.Location = new System.Drawing.Point(13, 109);
            this.kcbSparseFile.Name = "kcbSparseFile";
            this.kcbSparseFile.Size = new System.Drawing.Size(103, 21);
            this.kcbSparseFile.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbSparseFile.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbSparseFile.TabIndex = 29;
            this.kcbSparseFile.ToolTipValues.Description = null;
            this.kcbSparseFile.ToolTipValues.Heading = "Archived";
            this.kcbSparseFile.Values.Text = "Spar&se File";
            this.kcbSparseFile.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbReparsePoint
            // 
            this.kcbReparsePoint.Location = new System.Drawing.Point(362, 82);
            this.kcbReparsePoint.Name = "kcbReparsePoint";
            this.kcbReparsePoint.Size = new System.Drawing.Size(122, 21);
            this.kcbReparsePoint.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbReparsePoint.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbReparsePoint.TabIndex = 28;
            this.kcbReparsePoint.ToolTipValues.Description = null;
            this.kcbReparsePoint.ToolTipValues.Heading = "Archived";
            this.kcbReparsePoint.Values.Text = "Re&parse Point";
            this.kcbReparsePoint.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbReadOnly
            // 
            this.kcbReadOnly.Location = new System.Drawing.Point(259, 82);
            this.kcbReadOnly.Name = "kcbReadOnly";
            this.kcbReadOnly.Size = new System.Drawing.Size(97, 21);
            this.kcbReadOnly.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbReadOnly.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbReadOnly.TabIndex = 27;
            this.kcbReadOnly.ToolTipValues.Description = null;
            this.kcbReadOnly.ToolTipValues.Heading = "Archived";
            this.kcbReadOnly.Values.Text = "&Read Only";
            this.kcbReadOnly.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbOffline
            // 
            this.kcbOffline.Location = new System.Drawing.Point(184, 82);
            this.kcbOffline.Name = "kcbOffline";
            this.kcbOffline.Size = new System.Drawing.Size(69, 21);
            this.kcbOffline.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbOffline.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbOffline.TabIndex = 26;
            this.kcbOffline.ToolTipValues.Description = null;
            this.kcbOffline.ToolTipValues.Heading = "Archived";
            this.kcbOffline.Values.Text = "O&ffline";
            this.kcbOffline.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbIntegrityStream
            // 
            this.kcbIntegrityStream.Location = new System.Drawing.Point(93, 47);
            this.kcbIntegrityStream.Name = "kcbIntegrityStream";
            this.kcbIntegrityStream.Size = new System.Drawing.Size(133, 21);
            this.kcbIntegrityStream.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbIntegrityStream.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbIntegrityStream.TabIndex = 25;
            this.kcbIntegrityStream.Values.Text = "I&ntegrity Stream";
            this.kcbIntegrityStream.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbNormal
            // 
            this.kcbNormal.Location = new System.Drawing.Point(232, 47);
            this.kcbNormal.Name = "kcbNormal";
            this.kcbNormal.Size = new System.Drawing.Size(74, 21);
            this.kcbNormal.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbNormal.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbNormal.TabIndex = 24;
            this.kcbNormal.Values.Text = "No&rmal";
            this.kcbNormal.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbNoScrubData
            // 
            this.kcbNoScrubData.Location = new System.Drawing.Point(312, 47);
            this.kcbNoScrubData.Name = "kcbNoScrubData";
            this.kcbNoScrubData.Size = new System.Drawing.Size(125, 21);
            this.kcbNoScrubData.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbNoScrubData.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbNoScrubData.TabIndex = 23;
            this.kcbNoScrubData.Values.Text = "No &Scrub Data";
            this.kcbNoScrubData.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbNotContextIndexed
            // 
            this.kcbNotContextIndexed.Location = new System.Drawing.Point(13, 82);
            this.kcbNotContextIndexed.Name = "kcbNotContextIndexed";
            this.kcbNotContextIndexed.Size = new System.Drawing.Size(165, 21);
            this.kcbNotContextIndexed.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbNotContextIndexed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbNotContextIndexed.TabIndex = 22;
            this.kcbNotContextIndexed.Values.Text = "Not Co&ntext Indexed";
            this.kcbNotContextIndexed.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbHidden
            // 
            this.kcbHidden.Location = new System.Drawing.Point(13, 47);
            this.kcbHidden.Name = "kcbHidden";
            this.kcbHidden.Size = new System.Drawing.Size(74, 21);
            this.kcbHidden.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbHidden.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbHidden.TabIndex = 21;
            this.kcbHidden.ToolTipValues.Description = null;
            this.kcbHidden.ToolTipValues.Heading = "Archived";
            this.kcbHidden.Values.Text = "&Hidden";
            this.kcbHidden.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbCompressed
            // 
            this.kcbCompressed.Location = new System.Drawing.Point(95, 14);
            this.kcbCompressed.Name = "kcbCompressed";
            this.kcbCompressed.Size = new System.Drawing.Size(112, 21);
            this.kcbCompressed.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbCompressed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbCompressed.TabIndex = 20;
            this.kcbCompressed.Values.Text = "C&ompressed";
            this.kcbCompressed.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbDevice
            // 
            this.kcbDevice.Location = new System.Drawing.Point(213, 14);
            this.kcbDevice.Name = "kcbDevice";
            this.kcbDevice.Size = new System.Drawing.Size(72, 21);
            this.kcbDevice.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbDevice.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbDevice.TabIndex = 19;
            this.kcbDevice.Values.Text = "D&evice";
            this.kcbDevice.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbDirectory
            // 
            this.kcbDirectory.Location = new System.Drawing.Point(291, 14);
            this.kcbDirectory.Name = "kcbDirectory";
            this.kcbDirectory.Size = new System.Drawing.Size(86, 21);
            this.kcbDirectory.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbDirectory.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbDirectory.TabIndex = 18;
            this.kcbDirectory.Values.Text = "D&irectory";
            this.kcbDirectory.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbEncrypted
            // 
            this.kcbEncrypted.Location = new System.Drawing.Point(383, 14);
            this.kcbEncrypted.Name = "kcbEncrypted";
            this.kcbEncrypted.Size = new System.Drawing.Size(94, 21);
            this.kcbEncrypted.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbEncrypted.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbEncrypted.TabIndex = 17;
            this.kcbEncrypted.Values.Text = "&Encrypted";
            this.kcbEncrypted.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // kcbArchive
            // 
            this.kcbArchive.Location = new System.Drawing.Point(13, 14);
            this.kcbArchive.Name = "kcbArchive";
            this.kcbArchive.Size = new System.Drawing.Size(76, 21);
            this.kcbArchive.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbArchive.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbArchive.TabIndex = 16;
            this.kcbArchive.ToolTipValues.Description = null;
            this.kcbArchive.ToolTipValues.Heading = "Archived";
            this.kcbArchive.Values.Text = "&Archive";
            this.kcbArchive.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 582);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 3);
            this.panel1.TabIndex = 2;
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
            // KryptonFileInformationDialog
            // 
            this.ClientSize = new System.Drawing.Size(608, 631);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonFileInformationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.KryptonFileInformationDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            this.kryptonPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFileIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended2.Panel)).EndInit();
            this.kryptonGroupBoxExtended2.Panel.ResumeLayout(false);
            this.kryptonGroupBoxExtended2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended2)).EndInit();
            this.kryptonGroupBoxExtended2.ResumeLayout(false);
            this.ctxHashMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbeValidateChecksumType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended1.Panel)).EndInit();
            this.kryptonGroupBoxExtended1.Panel.ResumeLayout(false);
            this.kryptonGroupBoxExtended1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended1)).EndInit();
            this.kryptonGroupBoxExtended1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbeCalculateChecksumHashType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended3.Panel)).EndInit();
            this.kryptonGroupBoxExtended3.Panel.ResumeLayout(false);
            this.kryptonGroupBoxExtended3.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended3)).EndInit();
            this.kryptonGroupBoxExtended3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private string _filePath;

        private SecurityAssistant _securityAssistant = new SecurityAssistant();

        private KryptonCheckBox[] _checkBoxes = new KryptonCheckBox[16];
        #endregion

        #region Properties
        public string FilePath { get => _filePath; private set => _filePath = value; }

        public KryptonCheckBox[] FileAttributeOptions { get => _checkBoxes; private set => _checkBoxes = value; }
        #endregion

        #region Constructor
        public KryptonFileInformationDialog(string filePath)
        {
            InitializeComponent();

            InitialiseCheckboxArray();

            GrabFileData(filePath);
        }
        #endregion

        #region Methods
        private void GrabFileData(string filePath)
        {
            // Create a new FileInfo object
            FileInfo info = new FileInfo(filePath);

            try
            {
                pbxFileIcon.Image = GetApplicationIcon(filePath);

                Icon = GetApplicationFileIcon(filePath);

                GetFileAttributes(filePath);

                ktxtFileName.Text = Path.GetFileName(filePath);

                Text = $"Properties for { Path.GetFileName(filePath) }";


                klbleFileLocation.Text = $"Location: { filePath }";

                klbleFileLocation.ToolTipValues.Description = klbleFileLocation.Text;

                klbleFileSize.Text = $"Size: { FileUtilities.GetReadableFileSize(info.Length) }";

                klbeSizeOnDisk.Text = $"Size on Disk: { FileUtilities.GetFileSizeOnDisk(filePath) }";

                klbleCreated.Text = $"Created: { ReturnDateTimeString(info.CreationTime) }";

                klbleModified.Text = $"Modified: { ReturnDateTimeString(info.LastWriteTime) }";

                klbleAccessed.Text = $"Accessed: { ReturnDateTimeString(info.LastAccessTime) }";
            }
            catch (Exception e)
            {
                ExceptionHandler.CaptureException(e);
            }
        }

        private string ReturnDateTimeString(DateTime input) => input.ToString();

        private void SetFileAttributes(string path, FileAttributes attributes) => File.SetAttributes(path, attributes);

        /// <summary>Returns the file attributes.</summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private FileAttributes ReturnFileAttributes(string path) => File.GetAttributes(path);

        /// <summary>Returns the file attributes.</summary>
        /// <param name="path">The path.</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        private bool ReturnFileAttributes(string path, FileAttributes attributes) => ReturnFileAttributes(path) == attributes;

        /// <summary>Gets the application icon.</summary>
        /// <param name="path">The file path.</param>
        /// <returns>The application icon.</returns>
        private Image GetApplicationIcon(string path) => Icon.ExtractAssociatedIcon(path).ToBitmap();

        private Icon GetApplicationFileIcon(string path) => Icon.ExtractAssociatedIcon(path);

        /// <summary>Gets the file attributes.</summary>
        /// <param name="path">The path.</param>
        private void GetFileAttributes(string path)
        {
            kcbArchive.Checked = ReturnFileAttributes(path, FileAttributes.Archive);

            kcbCompressed.Checked = ReturnFileAttributes(path, FileAttributes.Compressed);

            kcbDevice.Checked = ReturnFileAttributes(path, FileAttributes.Device);

            kcbDirectory.Checked = ReturnFileAttributes(path, FileAttributes.Directory);

            kcbEncrypted.Checked = ReturnFileAttributes(path, FileAttributes.Encrypted);

            kcbHidden.Checked = ReturnFileAttributes(path, FileAttributes.Hidden);

            kcbIntegrityStream.Checked = ReturnFileAttributes(path, FileAttributes.IntegrityStream);

            kcbNormal.Checked = ReturnFileAttributes(path, FileAttributes.Normal);

            kcbNoScrubData.Checked = ReturnFileAttributes(path, FileAttributes.NoScrubData);

            kcbNotContextIndexed.Checked = ReturnFileAttributes(path, FileAttributes.NotContentIndexed);

            kcbOffline.Checked = ReturnFileAttributes(path, FileAttributes.Offline);

            kcbReadOnly.Checked = ReturnFileAttributes(path, FileAttributes.ReadOnly);

            kcbReparsePoint.Checked = ReturnFileAttributes(path, FileAttributes.ReparsePoint);

            kcbSparseFile.Checked = ReturnFileAttributes(path, FileAttributes.SparseFile);

            kcbSystem.Checked = ReturnFileAttributes(path, FileAttributes.System);

            kcbTemporary.Checked = ReturnFileAttributes(path, FileAttributes.Temporary);
        }

        private void InitialiseCheckboxArray()
        {
            FileAttributeOptions[0] = kcbArchive;

            FileAttributeOptions[1] = kcbCompressed;

            FileAttributeOptions[2] = kcbDevice;

            FileAttributeOptions[3] = kcbDirectory;

            FileAttributeOptions[4] = kcbEncrypted;

            FileAttributeOptions[5] = kcbHidden;

            FileAttributeOptions[6] = kcbIntegrityStream;

            FileAttributeOptions[7] = kcbNormal;

            FileAttributeOptions[8] = kcbNoScrubData;

            FileAttributeOptions[9] = kcbNotContextIndexed;

            FileAttributeOptions[10] = kcbOffline;

            FileAttributeOptions[11] = kcbReadOnly;

            FileAttributeOptions[12] = kcbReparsePoint;

            FileAttributeOptions[13] = kcbSparseFile;

            FileAttributeOptions[14] = kcbSystem;

            FileAttributeOptions[15] = kcbTemporary;
        }

        private string CalculateChecksum(string filePath, string text)
        {
            throw new NotImplementedException();
        }

        private bool IsChecksumValid(string checksumHash)
        {
            string fileChecksum = CalculateChecksum(FilePath, kcmbeValidateChecksumType.Text);

            return fileChecksum.Equals(checksumHash);
        }
        #endregion 

        private void KryptonFileInformationDialog_Load(object sender, EventArgs e)
        {
            foreach (string item in _securityAssistant.ReturnSupportedHashAlgorithims())
            {
                kcmbeCalculateChecksumHashType.Items.Add(item);

                kcmbeValidateChecksumType.Items.Add(item);
            }
        }

        private void pbxFileIcon_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(FilePath)) Process.Start("explorer.exe", FilePath);
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc);
            }
        }

        private void KbtnCalculateChecksum_Click(object sender, EventArgs e) => klbleChecksumOutput.Text = CalculateChecksum(FilePath, kcmbeCalculateChecksumHashType.Text);

        private void CheckedChanged(object sender, EventArgs e) => kbtnGetFileAttributes.Enabled = true;

        private void kbtnGetFileAttributes_Click(object sender, EventArgs e) => GetFileAttributes(FilePath);

        private void kbtneValidateChecksum_Click(object sender, EventArgs e)
        {
            if (IsChecksumValid(ktxtFileHash.Text))
            {
                ktxtFileHash.StateCommon.Back.Color1 = Color.Green;
            }
            else
            {
                ktxtFileHash.StateCommon.Back.Color1 = Color.Red;

                ktxtFileHash.StateCommon.Content.Color1 = Color.White;
            }
        }

        private void kbtnClearAllFileAttributes_Click(object sender, EventArgs e)
        {
            foreach (KryptonCheckBox item in FileAttributeOptions)
            {
                item.Checked = false;
            }

            kbtnSetFileAttributes.PerformClick();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ktxtFileHash.Text.cut
        }
    }
}
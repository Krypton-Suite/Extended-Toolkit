#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.IO;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class SystemInformationWindow : KryptonForm
    {
        #region Designer Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemInformationWindow));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnClose = new Krypton.Toolkit.KryptonButton();
            this.kryptonNavigator1 = new Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new Krypton.Navigator.KryptonPage();
            this.krtbSystemInformation = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonPage2 = new Krypton.Navigator.KryptonPage();
            this.krtbCPUInformation = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonPage3 = new Krypton.Navigator.KryptonPage();
            this.krtbVideoInformation = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonPage4 = new Krypton.Navigator.KryptonPage();
            this.krtbLocalDrivesInformation = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonPage5 = new Krypton.Navigator.KryptonPage();
            this.klstMoreInformation = new Krypton.Toolkit.KryptonListBox();
            this.kbtnSave = new Krypton.Toolkit.KryptonButton();
            this.kcmbClass = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonManager1 = new Krypton.Toolkit.KryptonManager(this.components);
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateInRealTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrRealTimeUpdater = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.kryptonPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).BeginInit();
            this.kryptonPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage5)).BeginInit();
            this.kryptonPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbClass)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnClose);
            this.kryptonPanel1.Controls.Add(this.kryptonNavigator1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 798);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnClose
            // 
            this.kbtnClose.AutoSize = true;
            this.kbtnClose.Location = new System.Drawing.Point(697, 756);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(90, 30);
            this.kbtnClose.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnClose.TabIndex = 1;
            this.kbtnClose.Values.Text = "C&lose";
            this.kbtnClose.Click += new System.EventHandler(this.kbtnClose_Click);
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Button.CloseButtonAction = Krypton.Navigator.CloseButtonAction.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Location = new System.Drawing.Point(12, 12);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2,
            this.kryptonPage3,
            this.kryptonPage4,
            this.kryptonPage5});
            this.kryptonNavigator1.SelectedIndex = 4;
            this.kryptonNavigator1.Size = new System.Drawing.Size(776, 732);
            this.kryptonNavigator1.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonNavigator1.TabIndex = 0;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.krtbSystemInformation);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(774, 699);
            this.kryptonPage1.Text = "System";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "52A80FE93F9648674DAA3B958E5EEAE3";
            // 
            // krtbSystemInformation
            // 
            this.krtbSystemInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbSystemInformation.Location = new System.Drawing.Point(0, 0);
            this.krtbSystemInformation.Name = "krtbSystemInformation";
            this.krtbSystemInformation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.krtbSystemInformation.Size = new System.Drawing.Size(774, 699);
            this.krtbSystemInformation.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.krtbSystemInformation.TabIndex = 1;
            this.krtbSystemInformation.Text = "";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Controls.Add(this.krtbCPUInformation);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(774, 699);
            this.kryptonPage2.Text = "CPU";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "AF3BD15EEE494D712799EDA8503D850E";
            // 
            // krtbCPUInformation
            // 
            this.krtbCPUInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbCPUInformation.Location = new System.Drawing.Point(0, 0);
            this.krtbCPUInformation.Name = "krtbCPUInformation";
            this.krtbCPUInformation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.krtbCPUInformation.Size = new System.Drawing.Size(774, 699);
            this.krtbCPUInformation.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.krtbCPUInformation.TabIndex = 1;
            this.krtbCPUInformation.Text = "";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Controls.Add(this.krtbVideoInformation);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(774, 699);
            this.kryptonPage3.Text = "Video";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "2502D0D0948B48EAA1A4DF94B9393C51";
            // 
            // krtbVideoInformation
            // 
            this.krtbVideoInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbVideoInformation.Location = new System.Drawing.Point(0, 0);
            this.krtbVideoInformation.Name = "krtbVideoInformation";
            this.krtbVideoInformation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.krtbVideoInformation.Size = new System.Drawing.Size(774, 699);
            this.krtbVideoInformation.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.krtbVideoInformation.TabIndex = 1;
            this.krtbVideoInformation.Text = "";
            // 
            // kryptonPage4
            // 
            this.kryptonPage4.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage4.Controls.Add(this.krtbLocalDrivesInformation);
            this.kryptonPage4.Flags = 65534;
            this.kryptonPage4.LastVisibleSet = true;
            this.kryptonPage4.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage4.Name = "kryptonPage4";
            this.kryptonPage4.Size = new System.Drawing.Size(774, 699);
            this.kryptonPage4.Text = "Local Drives";
            this.kryptonPage4.ToolTipTitle = "Page ToolTip";
            this.kryptonPage4.UniqueName = "0E6E7473C4AF4658239BBFE1BE865410";
            // 
            // krtbLocalDrivesInformation
            // 
            this.krtbLocalDrivesInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbLocalDrivesInformation.Location = new System.Drawing.Point(0, 0);
            this.krtbLocalDrivesInformation.Name = "krtbLocalDrivesInformation";
            this.krtbLocalDrivesInformation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.krtbLocalDrivesInformation.Size = new System.Drawing.Size(774, 699);
            this.krtbLocalDrivesInformation.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.krtbLocalDrivesInformation.TabIndex = 1;
            this.krtbLocalDrivesInformation.Text = "";
            // 
            // kryptonPage5
            // 
            this.kryptonPage5.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage5.Controls.Add(this.klstMoreInformation);
            this.kryptonPage5.Controls.Add(this.kbtnSave);
            this.kryptonPage5.Controls.Add(this.kcmbClass);
            this.kryptonPage5.Controls.Add(this.kryptonLabel1);
            this.kryptonPage5.Flags = 65534;
            this.kryptonPage5.LastVisibleSet = true;
            this.kryptonPage5.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage5.Name = "kryptonPage5";
            this.kryptonPage5.Size = new System.Drawing.Size(774, 699);
            this.kryptonPage5.Text = "More";
            this.kryptonPage5.ToolTipTitle = "Page ToolTip";
            this.kryptonPage5.UniqueName = "D7CDD629AF9D4B7AB886B5D66381737C";
            // 
            // klstMoreInformation
            // 
            this.klstMoreInformation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.klstMoreInformation.Location = new System.Drawing.Point(0, 49);
            this.klstMoreInformation.Name = "klstMoreInformation";
            this.klstMoreInformation.ScrollAlwaysVisible = true;
            this.klstMoreInformation.Size = new System.Drawing.Size(774, 650);
            this.klstMoreInformation.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klstMoreInformation.TabIndex = 5;
            // 
            // kbtnSave
            // 
            this.kbtnSave.AutoSize = true;
            this.kbtnSave.Enabled = false;
            this.kbtnSave.Location = new System.Drawing.Point(346, 15);
            this.kbtnSave.Name = "kbtnSave";
            this.kbtnSave.Size = new System.Drawing.Size(90, 28);
            this.kbtnSave.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSave.TabIndex = 4;
            this.kbtnSave.Values.Text = "&Save";
            // 
            // kcmbClass
            // 
            this.kcmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbClass.DropDownWidth = 121;
            this.kcmbClass.Location = new System.Drawing.Point(120, 16);
            this.kcmbClass.Name = "kcmbClass";
            this.kcmbClass.Size = new System.Drawing.Size(219, 25);
            this.kcmbClass.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbClass.TabIndex = 3;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(14, 15);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(100, 26);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Select Class:";
            // 
            // ctxMenu
            // 
            this.ctxMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateInRealTimeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.copyInformationToolStripMenuItem});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(181, 54);
            // 
            // updateInRealTimeToolStripMenuItem
            // 
            this.updateInRealTimeToolStripMenuItem.CheckOnClick = true;
            this.updateInRealTimeToolStripMenuItem.Name = "updateInRealTimeToolStripMenuItem";
            this.updateInRealTimeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateInRealTimeToolStripMenuItem.Text = "Update in &Real Time";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // copyInformationToolStripMenuItem
            // 
            this.copyInformationToolStripMenuItem.Name = "copyInformationToolStripMenuItem";
            this.copyInformationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyInformationToolStripMenuItem.Text = "&Copy Information";
            // 
            // tmrRealTimeUpdater
            // 
            this.tmrRealTimeUpdater.Interval = 250;
            // 
            // SystemInformationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 798);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemInformationWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Information";
            this.Load += new System.EventHandler(this.SystemInformationWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).EndInit();
            this.kryptonPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage5)).EndInit();
            this.kryptonPage5.ResumeLayout(false);
            this.kryptonPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbClass)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnClose;
        private Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private Krypton.Navigator.KryptonPage kryptonPage1;
        private Krypton.Navigator.KryptonPage kryptonPage2;
        private Krypton.Navigator.KryptonPage kryptonPage3;
        private Krypton.Navigator.KryptonPage kryptonPage4;
        private Krypton.Navigator.KryptonPage kryptonPage5;
        private Krypton.Toolkit.KryptonRichTextBox krtbSystemInformation;
        private Krypton.Toolkit.KryptonRichTextBox krtbCPUInformation;
        private Krypton.Toolkit.KryptonRichTextBox krtbVideoInformation;
        private Krypton.Toolkit.KryptonRichTextBox krtbLocalDrivesInformation;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonComboBox kcmbClass;
        private Krypton.Toolkit.KryptonButton kbtnSave;
        private Krypton.Toolkit.KryptonListBox klstMoreInformation;
        private Krypton.Toolkit.KryptonManager kryptonManager1;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem updateInRealTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyInformationToolStripMenuItem;
        private System.Windows.Forms.Timer tmrRealTimeUpdater;
        #endregion

        #region Variables
        private string[] stringWin32classes = {"Win32_1394Controller",
                                                "Win32_1394ControllerDevice",
                                                "Win32_AccountSID",
                                                "Win32_ActionCheck",
                                                "Win32_ActiveRoute",
                                                "Win32_AllocatedResource",
                                                "Win32_ApplicationCommandLine",
                                                "Win32_ApplicationService",
                                                "Win32_AssociatedBattery",
                                                "Win32_AssociatedProcessorMemory",
                                                "Win32_AutochkSetting",
                                                "Win32_BaseBoard",
                                                "Win32_Battery",
                                                "Win32_Binary",
                                                "Win32_BindImageAction",
                                                "Win32_BIOS",
                                                "Win32_BootConfiguration",
                                                "Win32_Bus"+
                                                "Win32_CacheMemory",
                                                "Win32_CDROMDrive",
                                                "Win32_CheckCheck",
                                                "Win32_CIMLogicalDeviceCIMDataFile",
                                                "Win32_ClassicCOMApplicationClasses",
                                                "Win32_ClassicCOMClass",
                                                "Win32_ClassicCOMClassSetting",
                                                "Win32_ClassicCOMClassSettings",
                                                "Win32_ClassInforAction",
                                                "Win32_ClientApplicationSetting",
                                                "Win32_CodecFile",
                                                "Win32_COMApplicationSettings",
                                                "Win32_COMClassAutoEmulator",
                                                "Win32_ComClassEmulator",
                                                "Win32_CommandLineAccess",
                                                "Win32_ComponentCategory",
                                                "Win32_ComputerSystem",
                                                "Win32_ComputerSystemProcessor",
                                                "Win32_ComputerSystemProduct",
                                                "Win32_ComputerSystemWindowsProductActivationSetting",
                                                "Win32_Condition",
                                                "Win32_ConnectionShare",
                                                "Win32_ControllerHastHub",
                                                "Win32_CreateFolderAction",
                                                "Win32_CurrentProbe",
                                                "Win32_DCOMApplication",
                                                "Win32_DCOMApplicationAccessAllowedSetting",
                                                "Win32_DCOMApplicationLaunchAllowedSetting",
                                                "Win32_DCOMApplicationSetting",
                                                "Win32_DependentService",
                                                "Win32_Desktop",
                                                "Win32_DesktopMonitor",
                                                "Win32_DeviceBus",
                                                "Win32_DeviceMemoryAddress",
                                                "Win32_Directory",
                                                "Win32_DirectorySpecification",
                                                "Win32_DiskDrive",
                                                "Win32_DiskDrivePhysicalMedia",
                                                "Win32_DiskDriveToDiskPartition",
                                                "Win32_DiskPartition",
                                                "Win32_DiskQuota",
                                                "Win32_DisplayConfiguration",
                                                "Win32_DisplayControllerConfiguration",
                                                "Win32_DMAChanner",
                                                "Win32_DriverForDevice",
                                                "Win32_DriverVXD",
                                                "Win32_DuplicateFileAction",
                                                "Win32_Environment",
                                                "Win32_EnvironmentSpecification",
                                                "Win32_ExtensionInfoAction",
                                                "Win32_Fan",
                                                "Win32_FileSpecification",
                                                "Win32_FloppyController",
                                                "Win32_FloppyDrive",
                                                "Win32_FontInfoAction",
                                                "Win32_Group",
                                                "Win32_GroupDomain",
                                                "Win32_GroupUser",
                                                "Win32_HeatPipe",
                                                "Win32_IDEController",
                                                "Win32_IDEControllerDevice",
                                                "Win32_ImplementedCategory",
                                                "Win32_InfraredDevice",
                                                "Win32_IniFileSpecification",
                                                "Win32_InstalledSoftwareElement",
                                                "Win32_IP4PersistedRouteTable",
                                                "Win32_IP4RouteTable",
                                                "Win32_IRQResource",
                                                "Win32_Keyboard",
                                                "Win32_LaunchCondition",
                                                "Win32_LoadOrderGroup",
                                                "Win32_LoadOrderGroupServiceDependencies",
                                                "Win32_LoadOrderGroupServiceMembers",
                                                "Win32_LocalTime",
                                                "Win32_LoggedOnUser",
                                                "Win32_LogicalDisk",
                                                "Win32_LogicalDiskRootDirectory",
                                                "Win32_LogicalDiskToPartition",
                                                "Win32_LogicalFileAccess",
                                                "Win32_LogicalFileAuditing",
                                                "Win32_LogicalFileGroup",
                                                "Win32_LogicalFileOwner",
                                                "Win32_LogicalFileSecuritySetting",
                                                "Win32_LogicalMemoryConfiguration",
                                                "Win32_LogicalProgramGroup",
                                                "Win32_LogicalProgramGroupDirectory",
                                                "Win32_LogicalProgramGroupItem",
                                                "Win32_LogicalProgramGroupItemDataFile",
                                                "Win32_LogicalShareAccess",
                                                "Win32_LogicalShareAuditing",
                                                "Win32_LogicalShareSecuritySetting",
                                                "Win32_LogonSession",
                                                "Win32_LogonSessionMappedDisk",
                                                "Win32_MappedLogicalDisk",
                                                "Win32_MemoryArray",
                                                "Win32_MemoryArrayLocation",
                                                "Win32_MemoryDevice",
                                                "Win32_MemoryDeviceArray",
                                                "Win32_MemoryDeviceLocation",
                                                "Win32_MIMEInfoAction",
                                                "Win32_MotherboardDevice",
                                                "Win32_MoveFileAction",
                                                "Win32_NamedJobObject",
                                                "Win32_NamedJobObjectActgInfo",
                                                "Win32_NamedJobObjectLimit",
                                                "Win32_NamedJobObjectLimitSetting",
                                                "Win32_NamedJobObjectProcess",
                                                "Win32_NamedJobObjectSecLimit",
                                                "Win32_NamedJobObjectSecLimitSetting",
                                                "Win32_NamedJobObjectStatistics",
                                                "Win32_NetworkAdapter",
                                                "Win32_NetworkAdapterConfiguration",
                                                "Win32_NetworkAdapterSetting",
                                                "Win32_NetworkClient",
                                                "Win32_NetworkConnection",
                                                "Win32_NetworkLoginProfile",
                                                "Win32_NetworkProtocol",
                                                "Win32_NTDomain",
                                                "Win32_NTEventlogFile",
                                                "Win32_NTLogEvent",
                                                "Win32_NTLogEventComputer",
                                                "Win32_NTLogEvnetLog",
                                                "Win32_NTLogEventUser",
                                                "Win32_ODBCAttribute",
                                                "Win32_ODBCDataSourceAttribute",
                                                "Win32_ODBCDataSourceSpecification",
                                                "Win32_ODBCDriverAttribute",
                                                "Win32_ODBCDriverSoftwareElement",
                                                "Win32_ODBCDriverSpecification",
                                                "Win32_ODBCSourceAttribute",
                                                "Win32_ODBCTranslatorSpecification",
                                                "Win32_OnBoardDevice",
                                                "Win32_OperatingSystem",
                                                "Win32_OperatingSystemAutochkSetting",
                                                "Win32_OperatingSystemQFE",
                                                "Win32_OSRecoveryConfiguration",
                                                "Win32_PageFile",
                                                "Win32_PageFileElementSetting",
                                                "Win32_PageFileSetting",
                                                "Win32_PageFileUsage",
                                                "Win32_ParallelPort",
                                                "Win32_Patch",
                                                "Win32_PatchFile",
                                                "Win32_PatchPackage",
                                                "Win32_PCMCIAControler",
                                                "Win32_PerfFormattedData_ASP_ActiveServerPages",
                                                "Win32_PerfFormattedData_ASPNET_114322_ASPNETAppsv114322",
                                                "Win32_PerfFormattedData_ASPNET_114322_ASPNETv114322",
                                                "Win32_PerfFormattedData_ASPNET_2040607_ASPNETAppsv2040607",
                                                "Win32_PerfFormattedData_ASPNET_2040607_ASPNETv2040607",
                                                "Win32_PerfFormattedData_ASPNET_ASPNET",
                                                "Win32_PerfFormattedData_ASPNET_ASPNETApplications",
                                                "Win32_PerfFormattedData_aspnet_state_ASPNETStateService",
                                                "Win32_PerfFormattedData_ContentFilter_IndexingServiceFilter",
                                                "Win32_PerfFormattedData_ContentIndex_IndexingService",
                                                "Win32_PerfFormattedData_DTSPipeline_SQLServerDTSPipeline",
                                                "Win32_PerfFormattedData_Fax_FaxServices",
                                                "Win32_PerfFormattedData_InetInfo_InternetInformationServicesGlobal",
                                                "Win32_PerfFormattedData_ISAPISearch_HttpIndexingService",
                                                "Win32_PerfFormattedData_MSDTC_DistributedTransactionCoordinator",
                                                "Win32_PerfFormattedData_NETCLRData_NETCLRData",
                                                "Win32_PerfFormattedData_NETCLRNetworking_NETCLRNetworking",
                                                "Win32_PerfFormattedData_NETDataProviderforOracle_NETCLRData",
                                                "Win32_PerfFormattedData_NETDataProviderforSqlServer_NETDataProviderforSqlServer",
                                                "Win32_PerfFormattedData_NETFramework_NETCLRExceptions",
                                                "Win32_PerfFormattedData_NETFramework_NETCLRInterop",
                                                "Win32_PerfFormattedData_NETFramework_NETCLRJit",
                                                "Win32_PerfFormattedData_NETFramework_NETCLRLoading",
                                                "Win32_PerfFormattedData_NETFramework_NETCLRLocksAndThreads",
                                                "Win32_PerfFormattedData_NETFramework_NETCLRMemory",
                                                "Win32_PerfFormattedData_NETFramework_NETCLRRemoting",
                                                "Win32_PerfFormattedData_NETFramework_NETCLRSecurity",
                                                "Win32_PerfFormattedData_NTFSDRV_ControladordealmacenamientoNTFSdeSMTP",
                                                "Win32_PerfFormattedData_Outlook_Outlook",
                                                "Win32_PerfFormattedData_PerfDisk_LogicalDisk",
                                                "Win32_PerfFormattedData_PerfDisk_PhysicalDisk",
                                                "Win32_PerfFormattedData_PerfNet_Browser",
                                                "Win32_PerfFormattedData_PerfNet_Redirector",
                                                "Win32_PerfFormattedData_PerfNet_Server",
                                                "Win32_PerfFormattedData_PerfNet_ServerWorkQueues",
                                                "Win32_PerfFormattedData_PerfOS_Cache",
                                                "Win32_PerfFormattedData_PerfOS_Memory",
                                                "Win32_PerfFormattedData_PerfOS_Objects",
                                                "Win32_PerfFormattedData_PerfOS_PagingFile",
                                                "Win32_PerfFormattedData_PerfOS_Processor",
                                                "Win32_PerfFormattedData_PerfOS_System",
                                                "Win32_PerfFormattedData_PerfProc_FullImage_Costly",
                                                "Win32_PerfFormattedData_PerfProc_Image_Costly",
                                                "Win32_PerfFormattedData_PerfProc_JobObject",
                                                "Win32_PerfFormattedData_PerfProc_JobObjectDetails",
                                                "Win32_PerfFormattedData_PerfProc_Process",
                                                "Win32_PerfFormattedData_PerfProc_ProcessAddressSpace_Costly",
                                                "Win32_PerfFormattedData_PerfProc_Thread",
                                                "Win32_PerfFormattedData_PerfProc_ThreadDetails_Costly",
                                                "Win32_PerfFormattedData_RemoteAccess_RASPort",
                                                "Win32_PerfFormattedData_RemoteAccess_RASTotal",
                                                "Win32_PerfFormattedData_RSVP_RSVPInterfaces",
                                                "Win32_PerfFormattedData_RSVP_RSVPService",
                                                "Win32_PerfFormattedData_Spooler_PrintQueue",
                                                "Win32_PerfFormattedData_TapiSrv_Telephony",
                                                "Win32_PerfFormattedData_Tcpip_ICMP",
                                                "Win32_PerfFormattedData_Tcpip_IP",
                                                "Win32_PerfFormattedData_Tcpip_NBTConnection",
                                                "Win32_PerfFormattedData_Tcpip_NetworkInterface",
                                                "Win32_PerfFormattedData_Tcpip_TCP",
                                                "Win32_PerfFormattedData_Tcpip_UDP",
                                                "Win32_PerfFormattedData_TermService_TerminalServices",
                                                "Win32_PerfFormattedData_TermService_TerminalServicesSession",
                                                "Win32_PerfFormattedData_W3SVC_WebService",
                                                "Win32_PerfRawData_ASP_ActiveServerPages",
                                                "Win32_PerfRawData_ASPNET_114322_ASPNETAppsv114322",
                                                "Win32_PerfRawData_ASPNET_114322_ASPNETv114322",
                                                "Win32_PerfRawData_ASPNET_2040607_ASPNETAppsv2040607",
                                                "Win32_PerfRawData_ASPNET_2040607_ASPNETv2040607",
                                                "Win32_PerfRawData_ASPNET_ASPNET",
                                                "Win32_PerfRawData_ASPNET_ASPNETApplications",
                                                "Win32_PerfRawData_aspnet_state_ASPNETStateService",
                                                "Win32_PerfRawData_ContentFilter_IndexingServiceFilter",
                                                "Win32_PerfRawData_ContentIndex_IndexingService",
                                                "Win32_PerfRawData_DTSPipeline_SQLServerDTSPipeline",
                                                "Win32_PerfRawData_Fax_FaxServices",
                                                "Win32_PerfRawData_InetInfo_InternetInformationServicesGlobal",
                                                "Win32_PerfRawData_ISAPISearch_HttpIndexingService",
                                                "Win32_PerfRawData_MSDTC_DistributedTransactionCoordinator",
                                                "Win32_PerfRawData_NETCLRData_NETCLRData",
                                                "Win32_PerfRawData_NETCLRNetworking_NETCLRNetworking",
                                                "Win32_PerfRawData_NETDataProviderforOracle_NETCLRData",
                                                "Win32_PerfRawData_NETDataProviderforSqlServer_NETDataProviderforSqlServer",
                                                "Win32_PerfRawData_NETFramework_NETCLRExceptions",
                                                "Win32_PerfRawData_NETFramework_NETCLRInterop",
                                                "Win32_PerfRawData_NETFramework_NETCLRJit",
                                                "Win32_PerfRawData_NETFramework_NETCLRLoading",
                                                "Win32_PerfRawData_NETFramework_NETCLRLocksAndThreads",
                                                "Win32_PerfRawData_NETFramework_NETCLRMemory",
                                                "Win32_PerfRawData_NETFramework_NETCLRRemoting",
                                                "Win32_PerfRawData_NETFramework_NETCLRSecurity",
                                                "Win32_PerfRawData_NTFSDRV_ControladordealmacenamientoNTFSdeSMTP",
                                                "Win32_PerfRawData_Outlook_Outlook",
                                                "Win32_PerfRawData_PerfDisk_LogicalDisk",
                                                "Win32_PerfRawData_PerfDisk_PhysicalDisk",
                                                "Win32_PerfRawData_PerfNet_Browser",
                                                "Win32_PerfRawData_PerfNet_Redirector",
                                                "Win32_PerfRawData_PerfNet_Server",
                                                "Win32_PerfRawData_PerfNet_ServerWorkQueues",
                                                "Win32_PerfRawData_PerfOS_Cache",
                                                "Win32_PerfRawData_PerfOS_Memory",
                                                "Win32_PerfRawData_PerfOS_Objects",
                                                "Win32_PerfRawData_PerfOS_PagingFile",
                                                "Win32_PerfRawData_PerfOS_Processor",
                                                "Win32_PerfRawData_PerfOS_System",
                                                "Win32_PerfRawData_PerfProc_FullImage_Costly",
                                                "Win32_PerfRawData_PerfProc_Image_Costly",
                                                "Win32_PerfRawData_PerfProc_JobObject",
                                                "Win32_PerfRawData_PerfProc_JobObjectDetails",
                                                "Win32_PerfRawData_PerfProc_Process",
                                                "Win32_PerfRawData_PerfProc_ProcessAddressSpace_Costly",
                                                "Win32_PerfRawData_PerfProc_Thread",
                                                "Win32_PerfRawData_PerfProc_ThreadDetails_Costly",
                                                "Win32_PerfRawData_RemoteAccess_RASPort",
                                                "Win32_PerfRawData_RemoteAccess_RASTotal",
                                                "Win32_PerfRawData_RSVP_RSVPInterfaces",
                                                "Win32_PerfRawData_RSVP_RSVPService",
                                                "Win32_PerfRawData_Spooler_PrintQueue",
                                                "Win32_PerfRawData_TapiSrv_Telephony",
                                                "Win32_PerfRawData_Tcpip_ICMP",
                                                "Win32_PerfRawData_Tcpip_IP",
                                                "Win32_PerfRawData_Tcpip_NBTConnection",
                                                "Win32_PerfRawData_Tcpip_NetworkInterface",
                                                "Win32_PerfRawData_Tcpip_TCP",
                                                "Win32_PerfRawData_Tcpip_UDP",
                                                "Win32_PerfRawData_TermService_TerminalServices",
                                                "Win32_PerfRawData_TermService_TerminalServicesSession",
                                                "Win32_PerfRawData_W3SVC_WebService",
                                                "Win32_PhysicalMedia",
                                                "Win32_PhysicalMemory",
                                                "Win32_PhysicalMemoryArray",
                                                "Win32_PhysicalMemoryLocation",
                                                "Win32_PingStatus",
                                                "Win32_PNPAllocatedResource",
                                                "Win32_PnPDevice",
                                                "Win32_PnPEntity",
                                                "Win32_PnPSignedDriver",
                                                "Win32_PnPSignedDriverCIMDataFile",
                                                "Win32_PointingDevice",
                                                "Win32_PortableBattery",
                                                "Win32_PortConnector",
                                                "Win32_PortResource",
                                                "Win32_POTSModem",
                                                "Win32_POTSModemToSerialPort",
                                                "Win32_Printer",
                                                "Win32_PrinterConfiguration",
                                                "Win32_PrinterController",
                                                "Win32_PrinterDriver",
                                                "Win32_PrinterDriverDll",
                                                "Win32_PrinterSetting",
                                                "Win32_PrinterShare",
                                                "Win32_PrintJob",
                                                "Win32_Process",
                                                "Win32_Processor",
                                                "Win32_Product",
                                                "Win32_ProductCheck",
                                                "Win32_ProductResource",
                                                "Win32_ProductSoftwareFeatures",
                                                "Win32_ProgIDSpecification",
                                                "Win32_ProgramGroup",
                                                "Win32_ProgramGroupContents",
                                                "Win32_Property",
                                                "Win32_ProtocolBinding",
                                                "Win32_Proxy",
                                                "Win32_PublishComponentAction",
                                                "Win32_QuickFixEngineering",
                                                "Win32_QuotaSetting",
                                                "Win32_Refrigeration",
                                                "Win32_Registry",
                                                "Win32_RegistryAction",
                                                "Win32_RemoveFileAction",
                                                "Win32_RemoveIniAction",
                                                "Win32_ReserveCost",
                                                "Win32_ScheduledJob",
                                                "Win32_SCSIController",
                                                "Win32_SCSIControllerDevice",
                                                "Win32_SecuritySettingOfLogicalFile",
                                                "Win32_SecuritySettingOfLogicalShare",
                                                "Win32_SelfRegModuleAction",
                                                "Win32_SerialPort",
                                                "Win32_SerialPortConfiguration",
                                                "Win32_SerialPortSetting",
                                                "Win32_ServerConnection",
                                                "Win32_ServerSession",
                                                "Win32_Service",
                                                "Win32_ServiceControl",
                                                "Win32_ServiceSpecification",
                                                "Win32_ServiceSpecificationService",
                                                "Win32_SessionConnection",
                                                "Win32_SessionProcess",
                                                "Win32_Share",
                                                "Win32_ShareToDirectory",
                                                "Win32_ShortcutAction",
                                                "Win32_ShortcutFile",
                                                "Win32_ShortcutSAP",
                                                "Win32_SID",
                                                "Win32_SoftwareElement",
                                                "Win32_SoftwareElementAction",
                                                "Win32_SoftwareElementCheck",
                                                "Win32_SoftwareElementCondition",
                                                "Win32_SoftwareElementResource",
                                                "Win32_SoftwareFeature",
                                                "Win32_SoftwareFeatureAction",
                                                "Win32_SoftwareFeatureCheck",
                                                "Win32_SoftwareFeatureParent",
                                                "Win32_SoftwareFeatureSoftwareElements",
                                                "Win32_SoundDevice",
                                                "Win32_StartupCommand",
                                                "Win32_SubDirectory",
                                                "Win32_SystemAccount",
                                                "Win32_SystemBIOS",
                                                "Win32_SystemBootConfiguration",
                                                "Win32_SystemDesktop",
                                                "Win32_SystemDevices",
                                                "Win32_SystemDriver",
                                                "Win32_SystemDriverPNPEntity",
                                                "Win32_SystemEnclosure",
                                                "Win32_SystemLoadOrderGroups",
                                                "Win32_SystemLogicalMemoryConfiguration",
                                                "Win32_SystemNetworkConnections",
                                                "Win32_SystemOperatingSystem",
                                                "Win32_SystemPartitions",
                                                "Win32_SystemProcesses",
                                                "Win32_SystemProgramGroups",
                                                "Win32_SystemResources",
                                                "Win32_SystemServices",
                                                "Win32_SystemSlot",
                                                "Win32_SystemSystemDriver",
                                                "Win32_SystemTimeZone",
                                                "Win32_SystemUsers",
                                                "Win32_TapeDrive",
                                                "Win32_TCPIPPrinterPort",
                                                "Win32_TemperatureProbe",
                                                "Win32_Terminal",
                                                "Win32_TerminalService",
                                                "Win32_TerminalServiceSetting",
                                                "Win32_TerminalServiceToSetting",
                                                "Win32_TerminalTerminalSetting",
                                                "Win32_Thread",
                                                "Win32_TimeZone",
                                                "Win32_TSAccount",
                                                "Win32_TSClientSetting",
                                                "Win32_TSEnvironmentSetting",
                                                "Win32_TSGeneralSetting",
                                                "Win32_TSLogonSetting",
                                                "Win32_TSNetworkAdapterListSetting",
                                                "Win32_TSNetworkAdapterSetting",
                                                "Win32_TSPermissionsSetting",
                                                "Win32_TSRemoteControlSetting",
                                                "Win32_TSSessionDirectory",
                                                "Win32_TSSessionDirectorySetting",
                                                "Win32_TSSessionSetting",
                                                "Win32_TypeLibraryAction",
                                                "Win32_UninterruptiblePowerSupply",
                                                "Win32_USBController",
                                                "Win32_USBControllerDevice",
                                                "Win32_USBHub",
                                                "Win32_UserAccount",
                                                "Win32_UserDesktop",
                                                "Win32_UserInDomain",
                                                "Win32_UTCTime",
                                                "Win32_VideoController",
                                                "Win32_VideoSettings",
                                                "Win32_VoltageProbe",
                                                "Win32_VolumeQuotaSetting",
                                                "Win32_WindowsProductActivation",
                                                "Win32_WMIElementSetting",
                                                "Win32_WMISetting"
                                                };

        private Control _targetControl = null;
        #endregion

        #region Properties
        public Control TargetControl { get { return _targetControl; } set { _targetControl = value; } }
        #endregion

        public SystemInformationWindow()
        {
            InitializeComponent();
        }

        private void kbtnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void SystemInformationWindow_Load(object sender, EventArgs e)
        {
            foreach (string win32Class in stringWin32classes)
            {
                kcmbClass.Items.Add(win32Class);

                KryptonCheckBox classCheckBox = new KryptonCheckBox();

                classCheckBox.StateCommon.ShortText.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point);

                classCheckBox.Text = win32Class;

                klstMoreInformation.Items.Add(classCheckBox);
            }

            GetSystemDetails();
        }

        private string GetSystemDetails()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                sb.AppendFormat($"Operating System: { Environment.OSVersion }\n");

                if (Environment.Is64BitOperatingSystem)
                {
                    sb.AppendFormat("\t\t x64 (64-bit) Operating System\n");
                }
                else
                {
                    sb.AppendFormat("\t\t x86 (32-bit) Operating System\n");
                }

                sb.AppendFormat($"System Directory: { Environment.SystemDirectory }\n");

                sb.AppendFormat($"Processor Count: { Environment.ProcessorCount }\n");

                sb.AppendFormat($"User Domain Name: { Environment.UserDomainName }\n");

                sb.AppendFormat($"User Name: { Environment.UserName }\n");

                sb.AppendFormat("Logical Drives:\n");

                foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
                {
                    sb.AppendFormat($"\t Drive: { driveInfo.Name }\n\t\t Volume Label: { driveInfo.VolumeLabel }\n\t\t Drive Type: { driveInfo.DriveType }\n\t\t Drive Format: { driveInfo.DriveFormat }\n\t\t Total Size: { driveInfo.TotalSize }\n\t\t Available Free Space: { driveInfo.AvailableFreeSpace }\n");
                }

                sb.AppendFormat($"System Page Size: { Environment.SystemPageSize }\n");

                sb.AppendFormat($"Version: { Environment.Version }");
            }
            catch (Exception error)
            {
                KryptonMessageBox.Show($"An error has occurred: { error.Message }", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return sb.ToString();
        }

        private string DeviceInformation(string stringIn)
        {
            StringBuilder StringBuilder1 = new StringBuilder(string.Empty);
            try
            {
                //ManagementClass ManagementClass1 = new ManagementClass(stringIn);
                ////Create a ManagementObjectCollection to loop through
                //ManagementObjectCollection ManagemenobjCol = ManagementClass1.GetInstances();
                ////Get the properties in the class
                //PropertyDataCollection properties = ManagementClass1.Properties;
                //foreach (ManagementObject obj in ManagemenobjCol)
                //{
                //    foreach (PropertyData property in properties)
                //    {
                //        try
                //        {
                //            StringBuilder1.AppendLine(property.Name + ":  " + obj.Properties[property.Name].Value.ToString());
                //        }
                //        catch
                //        {
                //            //Add codes to manage more informations
                //        }
                //    }
                //    StringBuilder1.AppendLine();
                //}
            }
            catch
            {
                //Win 32 Classes Which are not defined on client system
            }
            return StringBuilder1.ToString();
        }
    }
}
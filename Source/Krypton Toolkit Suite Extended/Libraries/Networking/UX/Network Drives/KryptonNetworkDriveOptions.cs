namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class KryptonNetworkDriveOptions : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private KryptonPanel kryptonPanel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonTextBox ktxtShareAddress;
        private KryptonLabel kryptonLabel5;
        private KryptonLabel kryptonLabel4;
        private KryptonLabel kryptonLabel3;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private KryptonTextBox kryptonTextBox1;
        private KryptonTextBox ktxtUsername;
        private KryptonComboBox kcmbDriveLetter;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.ToolStripMenuItem functionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dialogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private KryptonCheckBox kcbSaveCredentials;
        private KryptonCheckBox kcbPromptForCredentials;
        private KryptonCheckBox kcbForceDisConnection;
        private KryptonCheckBox kcbPersistantConnection;
        private KryptonButton kbtnDisconnect;
        private KryptonButton kbtnMapDrive;
        private System.Windows.Forms.ToolStripMenuItem restoreAllDrivesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDriveConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showDriveDisconnectionToolStripMenuItem;
        private KryptonPanel kryptonPanel3;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kryptonPanel3 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            this.ktxtUsername = new Krypton.Toolkit.KryptonTextBox();
            this.kcmbDriveLetter = new Krypton.Toolkit.KryptonComboBox();
            this.ktxtShareAddress = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnMapDrive = new Krypton.Toolkit.KryptonButton();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.kbtnDisconnect = new Krypton.Toolkit.KryptonButton();
            this.functionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kcbPersistantConnection = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbForceDisConnection = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbPromptForCredentials = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbSaveCredentials = new Krypton.Toolkit.KryptonCheckBox();
            this.restoreAllDrivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDriveConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.showDriveDisconnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbDriveLetter)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.statusStrip1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 299);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(502, 24);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 2);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(502, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.menuStrip1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(502, 24);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionsToolStripMenuItem,
            this.dialogsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(301, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 24);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(502, 275);
            this.kryptonPanel3.TabIndex = 2;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 15);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kcbSaveCredentials);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kcbPromptForCredentials);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kcbForceDisConnection);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kcbPersistantConnection);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kbtnDisconnect);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kbtnMapDrive);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonTextBox1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.ktxtUsername);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kcmbDriveLetter);
            this.kryptonGroupBox1.Panel.Controls.Add(this.ktxtShareAddress);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel5);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(480, 252);
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Map Drive Settings";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Hint = "Password...";
            this.kryptonTextBox1.Location = new System.Drawing.Point(116, 129);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.PasswordChar = '●';
            this.kryptonTextBox1.Size = new System.Drawing.Size(237, 23);
            this.kryptonTextBox1.TabIndex = 8;
            this.kryptonTextBox1.UseSystemPasswordChar = true;
            // 
            // ktxtUsername
            // 
            this.ktxtUsername.Hint = "Username...";
            this.ktxtUsername.Location = new System.Drawing.Point(116, 91);
            this.ktxtUsername.Name = "ktxtUsername";
            this.ktxtUsername.Size = new System.Drawing.Size(237, 23);
            this.ktxtUsername.TabIndex = 7;
            // 
            // kcmbDriveLetter
            // 
            this.kcmbDriveLetter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbDriveLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbDriveLetter.DropDownWidth = 64;
            this.kcmbDriveLetter.IntegralHeight = false;
            this.kcmbDriveLetter.Location = new System.Drawing.Point(116, 53);
            this.kcmbDriveLetter.Name = "kcmbDriveLetter";
            this.kcmbDriveLetter.Size = new System.Drawing.Size(64, 21);
            this.kcmbDriveLetter.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbDriveLetter.TabIndex = 6;
            // 
            // ktxtShareAddress
            // 
            this.ktxtShareAddress.Hint = "\\\\<##SERVER-SHARE##>\\Path";
            this.ktxtShareAddress.Location = new System.Drawing.Point(116, 15);
            this.ktxtShareAddress.Name = "ktxtShareAddress";
            this.ktxtShareAddress.Size = new System.Drawing.Size(237, 23);
            this.ktxtShareAddress.TabIndex = 5;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(19, 167);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel5.TabIndex = 4;
            this.kryptonLabel5.Values.Text = "Options:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(19, 129);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(65, 20);
            this.kryptonLabel4.TabIndex = 3;
            this.kryptonLabel4.Values.Text = "Password:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(19, 91);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(68, 20);
            this.kryptonLabel3.TabIndex = 2;
            this.kryptonLabel3.Values.Text = "Username:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(19, 53);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(84, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Map to Drive:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(19, 15);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Share Address:";
            // 
            // kbtnMapDrive
            // 
            this.kbtnMapDrive.Enabled = false;
            this.kbtnMapDrive.Location = new System.Drawing.Point(359, 15);
            this.kbtnMapDrive.Name = "kbtnMapDrive";
            this.kbtnMapDrive.Size = new System.Drawing.Size(105, 25);
            this.kbtnMapDrive.TabIndex = 3;
            this.kbtnMapDrive.Values.Text = "&Map Drive";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(16, 17);
            this.tslStatus.Text = "...";
            // 
            // kbtnDisconnect
            // 
            this.kbtnDisconnect.Enabled = false;
            this.kbtnDisconnect.Location = new System.Drawing.Point(359, 53);
            this.kbtnDisconnect.Name = "kbtnDisconnect";
            this.kbtnDisconnect.Size = new System.Drawing.Size(105, 25);
            this.kbtnDisconnect.TabIndex = 9;
            this.kbtnDisconnect.Values.Text = "D&isconnect";
            // 
            // functionsToolStripMenuItem
            // 
            this.functionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreAllDrivesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            this.functionsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.functionsToolStripMenuItem.Text = "F&unctions";
            // 
            // dialogsToolStripMenuItem
            // 
            this.dialogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDriveConnectionToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showDriveDisconnectionToolStripMenuItem});
            this.dialogsToolStripMenuItem.Name = "dialogsToolStripMenuItem";
            this.dialogsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.dialogsToolStripMenuItem.Text = "D&ialogs";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // kcbPersistantConnection
            // 
            this.kcbPersistantConnection.Checked = true;
            this.kcbPersistantConnection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kcbPersistantConnection.Location = new System.Drawing.Point(116, 167);
            this.kcbPersistantConnection.Name = "kcbPersistantConnection";
            this.kcbPersistantConnection.Size = new System.Drawing.Size(142, 20);
            this.kcbPersistantConnection.TabIndex = 10;
            this.kcbPersistantConnection.Values.Text = "&Persistant Connection";
            // 
            // kcbForceDisConnection
            // 
            this.kcbForceDisConnection.Location = new System.Drawing.Point(270, 167);
            this.kcbForceDisConnection.Name = "kcbForceDisConnection";
            this.kcbForceDisConnection.Size = new System.Drawing.Size(141, 20);
            this.kcbForceDisConnection.TabIndex = 11;
            this.kcbForceDisConnection.Values.Text = "Fo&rce Dis/Connection";
            // 
            // kcbPromptForCredentials
            // 
            this.kcbPromptForCredentials.Location = new System.Drawing.Point(116, 194);
            this.kcbPromptForCredentials.Name = "kcbPromptForCredentials";
            this.kcbPromptForCredentials.Size = new System.Drawing.Size(147, 20);
            this.kcbPromptForCredentials.TabIndex = 12;
            this.kcbPromptForCredentials.Values.Text = "&Prompt for Credentials";
            // 
            // kcbSaveCredentials
            // 
            this.kcbSaveCredentials.Location = new System.Drawing.Point(270, 193);
            this.kcbSaveCredentials.Name = "kcbSaveCredentials";
            this.kcbSaveCredentials.Size = new System.Drawing.Size(113, 20);
            this.kcbSaveCredentials.TabIndex = 13;
            this.kcbSaveCredentials.Values.Text = "Save &Credentials";
            // 
            // restoreAllDrivesToolStripMenuItem
            // 
            this.restoreAllDrivesToolStripMenuItem.Name = "restoreAllDrivesToolStripMenuItem";
            this.restoreAllDrivesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.restoreAllDrivesToolStripMenuItem.Text = "Re&store All Drives";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "C&lose";
            // 
            // showDriveConnectionToolStripMenuItem
            // 
            this.showDriveConnectionToolStripMenuItem.Name = "showDriveConnectionToolStripMenuItem";
            this.showDriveConnectionToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.showDriveConnectionToolStripMenuItem.Text = "Show \'Drive &Connection\'";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(215, 6);
            // 
            // showDriveDisconnectionToolStripMenuItem
            // 
            this.showDriveDisconnectionToolStripMenuItem.Name = "showDriveDisconnectionToolStripMenuItem";
            this.showDriveDisconnectionToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.showDriveDisconnectionToolStripMenuItem.Text = "Show \'Driv&e Disconnection\'";
            // 
            // KryptonNetworkDriveOptions
            // 
            this.ClientSize = new System.Drawing.Size(502, 323);
            this.Controls.Add(this.kryptonPanel3);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "KryptonNetworkDriveOptions";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbDriveLetter)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

    }
}
using Krypton.Toolkit.Suite.Extended.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{ 
    public class KryptonRunDialog : KryptonFormExtended
    {
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonUACElevatedButtonVersion1 kuacbtnRun;
        private KryptonCancelDialogButton kdbtnCancel;
        private KryptonButton kbtnBrowse;
        private KryptonOKDialogButton kdbRun;
        private KryptonButton kbtnLocate;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kuacbtnRun = new Krypton.Toolkit.Suite.Extended.Base.KryptonUACElevatedButtonVersion1();
            this.kdbtnCancel = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonCancelDialogButton();
            this.kbtnBrowse = new Krypton.Toolkit.KryptonButton();
            this.kdbRun = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonOKDialogButton();
            this.kbtnLocate = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnLocate);
            this.kryptonPanel1.Controls.Add(this.kuacbtnRun);
            this.kryptonPanel1.Controls.Add(this.kdbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnBrowse);
            this.kryptonPanel1.Controls.Add(this.kdbRun);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 218);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(550, 43);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 3);
            this.panel1.TabIndex = 3;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.ControlCustom1;
            this.kryptonPanel2.Size = new System.Drawing.Size(550, 215);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // kuacbtnRun
            // 
            this.kuacbtnRun.Location = new System.Drawing.Point(262, 6);
            this.kuacbtnRun.Name = "kuacbtnRun";
            this.kuacbtnRun.ProcessToElevate = null;
            this.kuacbtnRun.Size = new System.Drawing.Size(90, 26);
            this.kuacbtnRun.TabIndex = 7;
            this.kuacbtnRun.Values.Text = "&Run";
            // 
            // kdbtnCancel
            // 
            this.kdbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kdbtnCancel.Location = new System.Drawing.Point(358, 6);
            this.kdbtnCancel.Name = "kdbtnCancel";
            this.kdbtnCancel.ParentWindow = null;
            this.kdbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kdbtnCancel.TabIndex = 8;
            this.kdbtnCancel.Values.Text = "C&ancel";
            // 
            // kbtnBrowse
            // 
            this.kbtnBrowse.Location = new System.Drawing.Point(454, 6);
            this.kbtnBrowse.Name = "kbtnBrowse";
            this.kbtnBrowse.Size = new System.Drawing.Size(84, 25);
            this.kbtnBrowse.TabIndex = 6;
            this.kbtnBrowse.Values.Text = "Br&owse...";
            // 
            // kdbRun
            // 
            this.kdbRun.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kdbRun.Enabled = false;
            this.kdbRun.Location = new System.Drawing.Point(262, 6);
            this.kdbRun.Name = "kdbRun";
            this.kdbRun.ParentWindow = null;
            this.kdbRun.Size = new System.Drawing.Size(90, 25);
            this.kdbRun.TabIndex = 5;
            this.kdbRun.Values.Text = "&Run";
            // 
            // kbtnLocate
            // 
            this.kbtnLocate.Location = new System.Drawing.Point(12, 6);
            this.kbtnLocate.Name = "kbtnLocate";
            this.kbtnLocate.Size = new System.Drawing.Size(83, 25);
            this.kbtnLocate.TabIndex = 9;
            this.kbtnLocate.Values.Text = "Loc&ate...";
            this.kbtnLocate.Visible = false;
            // 
            // KryptonRunDialog
            // 
            this.ClientSize = new System.Drawing.Size(550, 261);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonRunDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Run";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
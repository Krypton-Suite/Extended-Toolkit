using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    public class CustomFormatRule : KryptonForm
    {
        private KryptonPanel kryptonPanel1;
        private Toolkit.Extended.Base.KryptonOKDialogButton kryptonOKDialogButton1;
        private Toolkit.Extended.Base.KryptonCancelDialogButton kryptonCancelDialogButton1;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonCancelDialogButton1 = new Krypton.Toolkit.Extended.Base.KryptonCancelDialogButton();
            this.kryptonOKDialogButton1 = new Krypton.Toolkit.Extended.Base.KryptonOKDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonOKDialogButton1);
            this.kryptonPanel1.Controls.Add(this.kryptonCancelDialogButton1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 213);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(622, 48);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonCancelDialogButton1
            // 
            this.kryptonCancelDialogButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonCancelDialogButton1.Location = new System.Drawing.Point(520, 11);
            this.kryptonCancelDialogButton1.Name = "kryptonCancelDialogButton1";
            this.kryptonCancelDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonCancelDialogButton1.TabIndex = 0;
            this.kryptonCancelDialogButton1.Values.Image = global::Krypton.Toolkit.Suite.Extended.Outlook.Grid.Properties.Resources.Critical_16_x_16;
            this.kryptonCancelDialogButton1.Values.Text = "C&ancel";
            // 
            // kryptonOKDialogButton1
            // 
            this.kryptonOKDialogButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonOKDialogButton1.Location = new System.Drawing.Point(424, 11);
            this.kryptonOKDialogButton1.Name = "kryptonOKDialogButton1";
            this.kryptonOKDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonOKDialogButton1.TabIndex = 1;
            this.kryptonOKDialogButton1.Values.Image = global::Krypton.Toolkit.Suite.Extended.Outlook.Grid.Properties.Resources.Ok_16_x_16;
            this.kryptonOKDialogButton1.Values.Text = "&OK";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(622, 210);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // CustomFormatRule
            // 
            this.ClientSize = new System.Drawing.Size(622, 261);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "CustomFormatRule";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
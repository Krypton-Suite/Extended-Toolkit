using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class ScreenColourPickerDialog : KryptonForm
    {
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private Cyotek.Windows.Forms.ColorEditorManager cem;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.cem = new Cyotek.Windows.Forms.ColorEditorManager();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 318);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(577, 39);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(577, 315);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // ScreenColourPickerDialog
            // 
            this.ClientSize = new System.Drawing.Size(577, 357);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenColourPickerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class ColourPickerDialog : KryptonForm
    {
        private KryptonPanel kryptonPanel1;
        private Suite.Extended.Base.KryptonOKDialogButton kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private Cyotek.Windows.Forms.ColorGrid colorGrid1;
        private ColourWheelControl colourWheelControl1;
        private KryptonButton kryptonButton1;
        private KryptonButton kbtnSavePalette;
        private Suite.Extended.Base.KryptonCancelDialogButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.Suite.Extended.Base.KryptonOKDialogButton();
            this.kbtnCancel = new Krypton.Toolkit.Suite.Extended.Base.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.colourWheelControl1 = new Krypton.Toolkit.Extended.Colour.Controls.ColourWheelControl();
            this.colorGrid1 = new Cyotek.Windows.Forms.ColorGrid();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kbtnSavePalette = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 416);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(597, 43);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(399, 6);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 3;
            this.kbtnOk.Values.Text = "&OK";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(495, 6);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 3;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 2);
            this.panel1.TabIndex = 3;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonButton1);
            this.kryptonPanel2.Controls.Add(this.colorGrid1);
            this.kryptonPanel2.Controls.Add(this.kbtnSavePalette);
            this.kryptonPanel2.Controls.Add(this.colourWheelControl1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(597, 414);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // colourWheelControl1
            // 
            this.colourWheelControl1.BackColor = System.Drawing.Color.Transparent;
            this.colourWheelControl1.Location = new System.Drawing.Point(12, 12);
            this.colourWheelControl1.Name = "colourWheelControl1";
            this.colourWheelControl1.Size = new System.Drawing.Size(160, 160);
            this.colourWheelControl1.TabIndex = 5;
            // 
            // colorGrid1
            // 
            this.colorGrid1.BackColor = System.Drawing.Color.Transparent;
            this.colorGrid1.Location = new System.Drawing.Point(12, 209);
            this.colorGrid1.Name = "colorGrid1";
            this.colorGrid1.Size = new System.Drawing.Size(247, 165);
            this.colorGrid1.TabIndex = 6;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.AutoSize = true;
            this.kryptonButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton1.Location = new System.Drawing.Point(40, 181);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(22, 22);
            this.kryptonButton1.TabIndex = 30;
            this.kryptonButton1.Values.Image = global::Krypton.Toolkit.Extended.Colour.Controls.Properties.Resources.palette_load;
            this.kryptonButton1.Values.Text = "";
            // 
            // kbtnSavePalette
            // 
            this.kbtnSavePalette.AutoSize = true;
            this.kbtnSavePalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnSavePalette.Location = new System.Drawing.Point(12, 181);
            this.kbtnSavePalette.Name = "kbtnSavePalette";
            this.kbtnSavePalette.Size = new System.Drawing.Size(22, 22);
            this.kbtnSavePalette.TabIndex = 29;
            this.kbtnSavePalette.Values.Image = global::Krypton.Toolkit.Extended.Colour.Controls.Properties.Resources.palette_save;
            this.kbtnSavePalette.Values.Text = "";
            // 
            // ColourPickerDialog
            // 
            this.ClientSize = new System.Drawing.Size(597, 459);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ColourPickerDialog";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
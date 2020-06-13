using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonColourPickerDialog : KryptonForm
    {
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private Base.KryptonOKDialogButton kdbtnOk;
        private Base.KryptonCancelDialogButton kdbtnCancel;
        private Cyotek.Windows.Forms.ColorGrid colorGrid1;
        private KryptonButton kryptonButton2;
        private KryptonButton kryptonButton1;
        private Base.CircularPictureBox cpbxColour;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.cpbxColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.kdbtnCancel = new Krypton.Toolkit.Extended.Base.KryptonCancelDialogButton();
            this.kdbtnOk = new Krypton.Toolkit.Extended.Base.KryptonOKDialogButton();
            this.colorGrid1 = new Cyotek.Windows.Forms.ColorGrid();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxColour)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kdbtnOk);
            this.kryptonPanel1.Controls.Add(this.kdbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 416);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(615, 43);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonButton2);
            this.kryptonPanel2.Controls.Add(this.kryptonButton1);
            this.kryptonPanel2.Controls.Add(this.colorGrid1);
            this.kryptonPanel2.Controls.Add(this.cpbxColour);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(615, 413);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // cpbxColour
            // 
            this.cpbxColour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpbxColour.BackColor = System.Drawing.SystemColors.Control;
            this.cpbxColour.Location = new System.Drawing.Point(503, 12);
            this.cpbxColour.Name = "cpbxColour";
            this.cpbxColour.Size = new System.Drawing.Size(100, 100);
            this.cpbxColour.TabIndex = 3;
            this.cpbxColour.TabStop = false;
            this.cpbxColour.ToolTipValues = null;
            // 
            // kdbtnCancel
            // 
            this.kdbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kdbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kdbtnCancel.Location = new System.Drawing.Point(513, 6);
            this.kdbtnCancel.Name = "kdbtnCancel";
            this.kdbtnCancel.ParentWindow = this;
            this.kdbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kdbtnCancel.TabIndex = 3;
            this.kdbtnCancel.Values.Text = "C&ancel";
            // 
            // kdbtnOk
            // 
            this.kdbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kdbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kdbtnOk.Location = new System.Drawing.Point(417, 6);
            this.kdbtnOk.Name = "kdbtnOk";
            this.kdbtnOk.ParentWindow = this;
            this.kdbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kdbtnOk.TabIndex = 3;
            this.kdbtnOk.Values.Text = "&OK";
            // 
            // colorGrid1
            // 
            this.colorGrid1.BackColor = System.Drawing.Color.Transparent;
            this.colorGrid1.Location = new System.Drawing.Point(12, 239);
            this.colorGrid1.Name = "colorGrid1";
            this.colorGrid1.Size = new System.Drawing.Size(247, 165);
            this.colorGrid1.TabIndex = 3;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.AutoSize = true;
            this.kryptonButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton1.Location = new System.Drawing.Point(12, 211);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(22, 22);
            this.kryptonButton1.TabIndex = 3;
            this.kryptonButton1.Values.Image = global::Krypton.Toolkit.Extended.Colour.Controls.Properties.Resources.palette_load;
            this.kryptonButton1.Values.Text = "";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.AutoSize = true;
            this.kryptonButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton2.Location = new System.Drawing.Point(40, 211);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(22, 22);
            this.kryptonButton2.TabIndex = 4;
            this.kryptonButton2.Values.Image = global::Krypton.Toolkit.Extended.Colour.Controls.Properties.Resources.palette_save;
            this.kryptonButton2.Values.Text = "";
            // 
            // KryptonColourPickerDialog
            // 
            this.AcceptButton = this.kdbtnOk;
            this.CancelButton = this.kdbtnCancel;
            this.ClientSize = new System.Drawing.Size(615, 459);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonColourPickerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select a Colour";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxColour)).EndInit();
            this.ResumeLayout(false);

        }

        #region Variables
        private Color _colour;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set { _colour = value; } }
        #endregion
    }
}
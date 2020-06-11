using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class ColourPickerDialog : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private Cyotek.Windows.Forms.ColorGrid colorGrid1;
        private ScreenColourPickerControl screenColourPickerControl1;
        private ColourWheelControl colourWheelControl1;
        private ColourEditorManager colourEditorManager1;
        private KryptonButton kryptonButton2;
        private KryptonButton kryptonButton1;
        private Base.KryptonOKDialogButton kryptonOKDialogButton1;
        private Base.KryptonCancelDialogButton kryptonCancelDialogButton1;
        private Base.CircularPictureBox circularPictureBox1;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.screenColourPickerControl1 = new Krypton.Toolkit.Extended.Colour.Controls.ScreenColourPickerControl();
            this.colourWheelControl1 = new Krypton.Toolkit.Extended.Colour.Controls.ColourWheelControl();
            this.colorGrid1 = new Cyotek.Windows.Forms.ColorGrid();
            this.colourEditorManager1 = new Krypton.Toolkit.Extended.Colour.Controls.ColourEditorManager();
            this.circularPictureBox1 = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.kryptonOKDialogButton1 = new Krypton.Toolkit.Extended.Base.KryptonOKDialogButton();
            this.kryptonCancelDialogButton1 = new Krypton.Toolkit.Extended.Base.KryptonCancelDialogButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonOKDialogButton1);
            this.kryptonPanel1.Controls.Add(this.kryptonCancelDialogButton1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 410);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(541, 39);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 3);
            this.panel1.TabIndex = 0;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.circularPictureBox1);
            this.kryptonPanel2.Controls.Add(this.kryptonButton2);
            this.kryptonPanel2.Controls.Add(this.kryptonButton1);
            this.kryptonPanel2.Controls.Add(this.screenColourPickerControl1);
            this.kryptonPanel2.Controls.Add(this.colourWheelControl1);
            this.kryptonPanel2.Controls.Add(this.colorGrid1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(541, 407);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.AutoSize = true;
            this.kryptonButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton2.Location = new System.Drawing.Point(40, 193);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(22, 22);
            this.kryptonButton2.TabIndex = 3;
            this.kryptonButton2.Values.Image = global::Krypton.Toolkit.Extended.Colour.Controls.Properties.Resources.palette_save;
            this.kryptonButton2.Values.Text = "";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.AutoSize = true;
            this.kryptonButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton1.Location = new System.Drawing.Point(12, 193);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(22, 22);
            this.kryptonButton1.TabIndex = 2;
            this.kryptonButton1.Values.Image = global::Krypton.Toolkit.Extended.Colour.Controls.Properties.Resources.palette_load;
            this.kryptonButton1.Values.Text = "";
            // 
            // screenColourPickerControl1
            // 
            this.screenColourPickerControl1.Colour = System.Drawing.Color.Empty;
            this.screenColourPickerControl1.Location = new System.Drawing.Point(265, 319);
            this.screenColourPickerControl1.Name = "screenColourPickerControl1";
            this.screenColourPickerControl1.Size = new System.Drawing.Size(69, 70);
            this.screenColourPickerControl1.Text = "screenColourPickerControl1";
            // 
            // colourWheelControl1
            // 
            this.colourWheelControl1.BackColor = System.Drawing.Color.Transparent;
            this.colourWheelControl1.Location = new System.Drawing.Point(12, 12);
            this.colourWheelControl1.Name = "colourWheelControl1";
            this.colourWheelControl1.Size = new System.Drawing.Size(247, 174);
            this.colourWheelControl1.TabIndex = 2;
            // 
            // colorGrid1
            // 
            this.colorGrid1.BackColor = System.Drawing.Color.Transparent;
            this.colorGrid1.Location = new System.Drawing.Point(12, 221);
            this.colorGrid1.Name = "colorGrid1";
            this.colorGrid1.Size = new System.Drawing.Size(247, 165);
            this.colorGrid1.TabIndex = 0;
            // 
            // colourEditorManager1
            // 
            this.colourEditorManager1.Color = System.Drawing.Color.Empty;
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.circularPictureBox1.Location = new System.Drawing.Point(341, 319);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(80, 80);
            this.circularPictureBox1.TabIndex = 4;
            this.circularPictureBox1.TabStop = false;
            this.circularPictureBox1.ToolTipValues = null;
            // 
            // kryptonOKDialogButton1
            // 
            this.kryptonOKDialogButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonOKDialogButton1.Location = new System.Drawing.Point(343, 6);
            this.kryptonOKDialogButton1.Name = "kryptonOKDialogButton1";
            this.kryptonOKDialogButton1.ParentWindow = this;
            this.kryptonOKDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonOKDialogButton1.TabIndex = 3;
            this.kryptonOKDialogButton1.Values.Text = "&OK";
            // 
            // kryptonCancelDialogButton1
            // 
            this.kryptonCancelDialogButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonCancelDialogButton1.Location = new System.Drawing.Point(439, 6);
            this.kryptonCancelDialogButton1.Name = "kryptonCancelDialogButton1";
            this.kryptonCancelDialogButton1.ParentWindow = this;
            this.kryptonCancelDialogButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonCancelDialogButton1.TabIndex = 2;
            this.kryptonCancelDialogButton1.Values.Text = "C&ancel";
            // 
            // ColourPickerDialog
            // 
            this.ClientSize = new System.Drawing.Size(541, 449);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourPickerDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select a Colour";
            this.Load += new System.EventHandler(this.ColourPickerDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public Color Colour { get; set; }

        private void ColourPickerDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
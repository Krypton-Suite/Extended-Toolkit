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
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private Cyotek.Windows.Forms.ColorGrid colorGrid1;
        private ScreenColourPickerControl screenColourPickerControl1;
        private ColourWheelControl colourWheelControl1;
        private ColourEditorManager colourEditorManager1;
        private ColourEditorUserControl colourEditorUserControl1;
        private KryptonButton kryptonButton2;
        private KryptonButton kryptonButton1;
        private KryptonPanel kryptonPanel2;

        public Color Colour { get; set; }

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.colorGrid1 = new Cyotek.Windows.Forms.ColorGrid();
            this.screenColourPickerControl1 = new Krypton.Toolkit.Extended.Colour.Controls.ScreenColourPickerControl();
            this.colourWheelControl1 = new Krypton.Toolkit.Extended.Colour.Controls.ColourWheelControl();
            this.colourEditorManager1 = new Krypton.Toolkit.Extended.Colour.Controls.ColourEditorManager();
            this.colourEditorUserControl1 = new Krypton.Toolkit.Extended.Colour.Controls.ColourEditorUserControl();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 408);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(541, 36);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 405);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 3);
            this.panel1.TabIndex = 0;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonButton2);
            this.kryptonPanel2.Controls.Add(this.kryptonButton1);
            this.kryptonPanel2.Controls.Add(this.colourEditorUserControl1);
            this.kryptonPanel2.Controls.Add(this.screenColourPickerControl1);
            this.kryptonPanel2.Controls.Add(this.colourWheelControl1);
            this.kryptonPanel2.Controls.Add(this.colorGrid1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(541, 405);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // colorGrid1
            // 
            this.colorGrid1.BackColor = System.Drawing.Color.Transparent;
            this.colorGrid1.Location = new System.Drawing.Point(12, 221);
            this.colorGrid1.Name = "colorGrid1";
            this.colorGrid1.Size = new System.Drawing.Size(247, 165);
            this.colorGrid1.TabIndex = 0;
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
            // colourEditorManager1
            // 
            this.colourEditorManager1.Color = System.Drawing.Color.Empty;
            // 
            // colourEditorUserControl1
            // 
            this.colourEditorUserControl1.BackColor = System.Drawing.Color.Transparent;
            this.colourEditorUserControl1.Location = new System.Drawing.Point(265, 12);
            this.colourEditorUserControl1.Name = "colourEditorUserControl1";
            this.colourEditorUserControl1.Size = new System.Drawing.Size(261, 273);
            this.colourEditorUserControl1.TabIndex = 2;
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
            // ColourPickerDialog
            // 
            this.ClientSize = new System.Drawing.Size(541, 444);
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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void ColourPickerDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
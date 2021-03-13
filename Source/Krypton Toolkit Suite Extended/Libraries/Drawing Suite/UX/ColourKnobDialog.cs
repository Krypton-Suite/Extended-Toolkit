using System;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    public class ColourKnobDialog : KryptonForm
    {
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private Base.CircularPictureBox circularPictureBox1;
        private Base.KryptonKnobControlEnhanced kryptonKnobControlEnhanced3;
        private Base.KryptonKnobControlEnhanced kryptonKnobControlEnhanced2;
        private Base.KryptonKnobControlEnhanced kryptonKnobControlEnhanced1;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.circularPictureBox1 = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.kryptonKnobControlEnhanced3 = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControlEnhanced();
            this.kryptonKnobControlEnhanced2 = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControlEnhanced();
            this.kryptonKnobControlEnhanced1 = new Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControlEnhanced();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 216);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(588, 45);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(489, 8);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 3);
            this.panel1.TabIndex = 2;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.circularPictureBox1);
            this.kryptonPanel2.Controls.Add(this.kryptonKnobControlEnhanced3);
            this.kryptonPanel2.Controls.Add(this.kryptonKnobControlEnhanced2);
            this.kryptonPanel2.Controls.Add(this.kryptonKnobControlEnhanced1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(588, 213);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.circularPictureBox1.Location = new System.Drawing.Point(465, 44);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(114, 114);
            this.circularPictureBox1.TabIndex = 3;
            this.circularPictureBox1.TabStop = false;
            // 
            // kryptonKnobControlEnhanced3
            // 
            this.kryptonKnobControlEnhanced3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonKnobControlEnhanced3.EndAngle = 405F;
            this.kryptonKnobControlEnhanced3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kryptonKnobControlEnhanced3.KnobBackColour = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonKnobControlEnhanced3.LargeChange = 5;
            this.kryptonKnobControlEnhanced3.Location = new System.Drawing.Point(328, 44);
            this.kryptonKnobControlEnhanced3.Maximum = 255;
            this.kryptonKnobControlEnhanced3.Minimum = 0;
            this.kryptonKnobControlEnhanced3.Name = "kryptonKnobControlEnhanced3";
            this.kryptonKnobControlEnhanced3.PointerColour = System.Drawing.Color.Blue;
            this.kryptonKnobControlEnhanced3.PointerStyle = Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControlEnhanced.KnobPointerStyles.CIRCLE;
            this.kryptonKnobControlEnhanced3.ScaleColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonKnobControlEnhanced3.ScaleDivisions = 11;
            this.kryptonKnobControlEnhanced3.ScaleSubDivisions = 4;
            this.kryptonKnobControlEnhanced3.ScaleTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonKnobControlEnhanced3.ShowLargeScale = true;
            this.kryptonKnobControlEnhanced3.ShowSmallScale = false;
            this.kryptonKnobControlEnhanced3.Size = new System.Drawing.Size(114, 114);
            this.kryptonKnobControlEnhanced3.SmallChange = 1;
            this.kryptonKnobControlEnhanced3.StartAngle = 135F;
            this.kryptonKnobControlEnhanced3.TabIndex = 2;
            this.kryptonKnobControlEnhanced3.Value = 0;
            // 
            // kryptonKnobControlEnhanced2
            // 
            this.kryptonKnobControlEnhanced2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonKnobControlEnhanced2.EndAngle = 405F;
            this.kryptonKnobControlEnhanced2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kryptonKnobControlEnhanced2.KnobBackColour = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonKnobControlEnhanced2.LargeChange = 5;
            this.kryptonKnobControlEnhanced2.Location = new System.Drawing.Point(169, 44);
            this.kryptonKnobControlEnhanced2.Maximum = 255;
            this.kryptonKnobControlEnhanced2.Minimum = 0;
            this.kryptonKnobControlEnhanced2.Name = "kryptonKnobControlEnhanced2";
            this.kryptonKnobControlEnhanced2.PointerColour = System.Drawing.Color.Green;
            this.kryptonKnobControlEnhanced2.PointerStyle = Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControlEnhanced.KnobPointerStyles.CIRCLE;
            this.kryptonKnobControlEnhanced2.ScaleColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonKnobControlEnhanced2.ScaleDivisions = 11;
            this.kryptonKnobControlEnhanced2.ScaleSubDivisions = 4;
            this.kryptonKnobControlEnhanced2.ScaleTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonKnobControlEnhanced2.ShowLargeScale = true;
            this.kryptonKnobControlEnhanced2.ShowSmallScale = false;
            this.kryptonKnobControlEnhanced2.Size = new System.Drawing.Size(114, 114);
            this.kryptonKnobControlEnhanced2.SmallChange = 1;
            this.kryptonKnobControlEnhanced2.StartAngle = 135F;
            this.kryptonKnobControlEnhanced2.TabIndex = 1;
            this.kryptonKnobControlEnhanced2.Value = 0;
            // 
            // kryptonKnobControlEnhanced1
            // 
            this.kryptonKnobControlEnhanced1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonKnobControlEnhanced1.EndAngle = 405F;
            this.kryptonKnobControlEnhanced1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kryptonKnobControlEnhanced1.KnobBackColour = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonKnobControlEnhanced1.LargeChange = 5;
            this.kryptonKnobControlEnhanced1.Location = new System.Drawing.Point(12, 44);
            this.kryptonKnobControlEnhanced1.Maximum = 255;
            this.kryptonKnobControlEnhanced1.Minimum = 0;
            this.kryptonKnobControlEnhanced1.Name = "kryptonKnobControlEnhanced1";
            this.kryptonKnobControlEnhanced1.PointerColour = System.Drawing.Color.Red;
            this.kryptonKnobControlEnhanced1.PointerStyle = Krypton.Toolkit.Suite.Extended.Base.KryptonKnobControlEnhanced.KnobPointerStyles.CIRCLE;
            this.kryptonKnobControlEnhanced1.ScaleColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonKnobControlEnhanced1.ScaleDivisions = 11;
            this.kryptonKnobControlEnhanced1.ScaleSubDivisions = 4;
            this.kryptonKnobControlEnhanced1.ScaleTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonKnobControlEnhanced1.ShowLargeScale = true;
            this.kryptonKnobControlEnhanced1.ShowSmallScale = false;
            this.kryptonKnobControlEnhanced1.Size = new System.Drawing.Size(114, 114);
            this.kryptonKnobControlEnhanced1.SmallChange = 1;
            this.kryptonKnobControlEnhanced1.StartAngle = 135F;
            this.kryptonKnobControlEnhanced1.TabIndex = 0;
            this.kryptonKnobControlEnhanced1.Value = 0;
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(393, 8);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&Ok";
            // 
            // ColourKnobDialog
            // 
            this.AcceptButton = this.kbtnOk;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(588, 261);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourKnobDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ColourKnobDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void ColourKnobDialog_Load(object sender, EventArgs e)
        {
            Common.DevelopmentUtilities.UnderConstruction(this);
        }
    }
}
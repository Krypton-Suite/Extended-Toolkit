namespace TestApp
{
    partial class CircularProgressBarExample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CircularProgressBarExample));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonColorButton3 = new Krypton.Toolkit.KryptonColorButton();
            this.kryptonColorButton2 = new Krypton.Toolkit.KryptonColorButton();
            this.kryptonColorButton1 = new Krypton.Toolkit.KryptonColorButton();
            this.kryptonCheckBox1 = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonTrackBar1 = new Krypton.Toolkit.KryptonTrackBar();
            this.circularProgressBar1 = new Krypton.Toolkit.Suite.Extended.Circular.ProgressBar.CircularProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonColorButton3);
            this.kryptonPanel1.Controls.Add(this.kryptonColorButton2);
            this.kryptonPanel1.Controls.Add(this.kryptonColorButton1);
            this.kryptonPanel1.Controls.Add(this.kryptonCheckBox1);
            this.kryptonPanel1.Controls.Add(this.kryptonTrackBar1);
            this.kryptonPanel1.Controls.Add(this.circularProgressBar1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(659, 352);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonColorButton3
            // 
            this.kryptonColorButton3.Location = new System.Drawing.Point(339, 141);
            this.kryptonColorButton3.Name = "kryptonColorButton3";
            this.kryptonColorButton3.Size = new System.Drawing.Size(205, 25);
            this.kryptonColorButton3.TabIndex = 6;
            this.kryptonColorButton3.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonColorButton3.Values.Image")));
            this.kryptonColorButton3.Values.Text = "Thi&rd Colour";
            // 
            // kryptonColorButton2
            // 
            this.kryptonColorButton2.Location = new System.Drawing.Point(339, 110);
            this.kryptonColorButton2.Name = "kryptonColorButton2";
            this.kryptonColorButton2.Size = new System.Drawing.Size(205, 25);
            this.kryptonColorButton2.TabIndex = 5;
            this.kryptonColorButton2.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonColorButton2.Values.Image")));
            this.kryptonColorButton2.Values.Text = "&Second Colour";
            // 
            // kryptonColorButton1
            // 
            this.kryptonColorButton1.Location = new System.Drawing.Point(339, 79);
            this.kryptonColorButton1.Name = "kryptonColorButton1";
            this.kryptonColorButton1.Size = new System.Drawing.Size(205, 25);
            this.kryptonColorButton1.TabIndex = 4;
            this.kryptonColorButton1.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonColorButton1.Values.Image")));
            this.kryptonColorButton1.Values.Text = "F&irst Colour";
            // 
            // kryptonCheckBox1
            // 
            this.kryptonCheckBox1.Location = new System.Drawing.Point(339, 52);
            this.kryptonCheckBox1.Name = "kryptonCheckBox1";
            this.kryptonCheckBox1.Size = new System.Drawing.Size(104, 20);
            this.kryptonCheckBox1.TabIndex = 3;
            this.kryptonCheckBox1.Values.Text = "Use colour trio";
            this.kryptonCheckBox1.CheckedChanged += new System.EventHandler(this.kryptonCheckBox1_CheckedChanged);
            // 
            // kryptonTrackBar1
            // 
            this.kryptonTrackBar1.Location = new System.Drawing.Point(338, 12);
            this.kryptonTrackBar1.Maximum = 100;
            this.kryptonTrackBar1.Name = "kryptonTrackBar1";
            this.kryptonTrackBar1.Size = new System.Drawing.Size(303, 33);
            this.kryptonTrackBar1.TabIndex = 2;
            this.kryptonTrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.kryptonTrackBar1.ValueChanged += new System.EventHandler(this.kryptonTrackBar1_ValueChanged);
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation_NET5.KnownAnimationFunctions.Linear;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.FirstValueColour = System.Drawing.Color.Red;
            this.circularProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.circularProgressBar1.InnerColour = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(12, 12);
            this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColour = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.circularProgressBar1.OuterMargin = -25;
            this.circularProgressBar1.OuterWidth = 26;
            this.circularProgressBar1.ProgressColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(107)))));
            this.circularProgressBar1.ProgressWidth = 25;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar1.SecondValueColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.circularProgressBar1.Size = new System.Drawing.Size(320, 320);
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.SubscriptColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 1;
            this.circularProgressBar1.Text = "{0}%";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar1.ThirdValueColour = System.Drawing.Color.Green;
            // 
            // CircularProgressBarExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 352);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CircularProgressBarExample";
            this.Text = "CircularProgressBarExample";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonTrackBar kryptonTrackBar1;
        private Krypton.Toolkit.Suite.Extended.Circular.ProgressBar.CircularProgressBar circularProgressBar1;
        private Krypton.Toolkit.KryptonCheckBox kryptonCheckBox1;
        private Krypton.Toolkit.KryptonColorButton kryptonColorButton3;
        private Krypton.Toolkit.KryptonColorButton kryptonColorButton2;
        private Krypton.Toolkit.KryptonColorButton kryptonColorButton1;
    }
}
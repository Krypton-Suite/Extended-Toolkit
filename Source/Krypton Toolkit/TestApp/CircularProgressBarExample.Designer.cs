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
            this.kcbThirdColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcbSecondColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcbFirstColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcbUseColourTrio = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonTrackBar1 = new Krypton.Toolkit.KryptonTrackBar();
            this.circularProgressBar1 = new Krypton.Toolkit.Suite.Extended.Circular.ProgressBar.CircularProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kcbThirdColour);
            this.kryptonPanel1.Controls.Add(this.kcbSecondColour);
            this.kryptonPanel1.Controls.Add(this.kcbFirstColour);
            this.kryptonPanel1.Controls.Add(this.kcbUseColourTrio);
            this.kryptonPanel1.Controls.Add(this.kryptonTrackBar1);
            this.kryptonPanel1.Controls.Add(this.circularProgressBar1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(659, 352);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kcbThirdColour
            // 
            this.kcbThirdColour.Location = new System.Drawing.Point(339, 141);
            this.kcbThirdColour.Name = "kcbThirdColour";
            this.kcbThirdColour.SelectedColor = System.Drawing.Color.Green;
            this.kcbThirdColour.SelectedRect = new System.Drawing.Rectangle(0, 0, 16, 16);
            this.kcbThirdColour.Size = new System.Drawing.Size(205, 25);
            this.kcbThirdColour.Splitter = false;
            this.kcbThirdColour.TabIndex = 6;
            this.kcbThirdColour.Values.RoundedCorners = 8;
            this.kcbThirdColour.Values.Text = "Thi&rd Colour";
            this.kcbThirdColour.VisibleNoColor = false;
            this.kcbThirdColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbThirdColour_SelectedColorChanged);
            // 
            // kcbSecondColour
            // 
            this.kcbSecondColour.Location = new System.Drawing.Point(339, 110);
            this.kcbSecondColour.Name = "kcbSecondColour";
            this.kcbSecondColour.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.kcbSecondColour.SelectedRect = new System.Drawing.Rectangle(0, 0, 16, 16);
            this.kcbSecondColour.Size = new System.Drawing.Size(205, 25);
            this.kcbSecondColour.Splitter = false;
            this.kcbSecondColour.TabIndex = 5;
            this.kcbSecondColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kcbSecondColour.Values.Image")));
            this.kcbSecondColour.Values.RoundedCorners = 8;
            this.kcbSecondColour.Values.Text = "&Second Colour";
            this.kcbSecondColour.VisibleNoColor = false;
            this.kcbSecondColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbSecondColour_SelectedColorChanged);
            // 
            // kcbFirstColour
            // 
            this.kcbFirstColour.Location = new System.Drawing.Point(339, 79);
            this.kcbFirstColour.Name = "kcbFirstColour";
            this.kcbFirstColour.SelectedRect = new System.Drawing.Rectangle(0, 0, 16, 16);
            this.kcbFirstColour.Size = new System.Drawing.Size(205, 25);
            this.kcbFirstColour.Splitter = false;
            this.kcbFirstColour.TabIndex = 4;
            this.kcbFirstColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kcbFirstColour.Values.Image")));
            this.kcbFirstColour.Values.RoundedCorners = 8;
            this.kcbFirstColour.Values.Text = "F&irst Colour";
            this.kcbFirstColour.VisibleNoColor = false;
            this.kcbFirstColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbFirstColour_SelectedColorChanged);
            // 
            // kcbUseColourTrio
            // 
            this.kcbUseColourTrio.Location = new System.Drawing.Point(339, 52);
            this.kcbUseColourTrio.Name = "kcbUseColourTrio";
            this.kcbUseColourTrio.Size = new System.Drawing.Size(104, 20);
            this.kcbUseColourTrio.TabIndex = 3;
            this.kcbUseColourTrio.Values.Text = "Use colour trio";
            this.kcbUseColourTrio.CheckedChanged += new System.EventHandler(this.kryptonCheckBox1_CheckedChanged);
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
            this.Load += new System.EventHandler(this.CircularProgressBarExample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonTrackBar kryptonTrackBar1;
        private Krypton.Toolkit.Suite.Extended.Circular.ProgressBar.CircularProgressBar circularProgressBar1;
        private Krypton.Toolkit.KryptonCheckBox kcbUseColourTrio;
        private Krypton.Toolkit.KryptonColorButton kcbThirdColour;
        private Krypton.Toolkit.KryptonColorButton kcbSecondColour;
        private Krypton.Toolkit.KryptonColorButton kcbFirstColour;
    }
}
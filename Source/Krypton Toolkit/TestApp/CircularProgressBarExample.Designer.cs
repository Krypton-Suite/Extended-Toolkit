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
            this.kcbUseColourTrio = new Krypton.Toolkit.KryptonCheckBox();
            this.ktbProgressValue = new Krypton.Toolkit.KryptonTrackBar();
            this.cpbExample = new Krypton.Toolkit.Suite.Extended.Circular.ProgressBar.CircularProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kcbUseColourTrio);
            this.kryptonPanel1.Controls.Add(this.ktbProgressValue);
            this.kryptonPanel1.Controls.Add(this.cpbExample);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(659, 348);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kcbUseColourTrio
            // 
            this.kcbUseColourTrio.Location = new System.Drawing.Point(339, 52);
            this.kcbUseColourTrio.Name = "kcbUseColourTrio";
            this.kcbUseColourTrio.Size = new System.Drawing.Size(104, 20);
            this.kcbUseColourTrio.TabIndex = 3;
            this.kcbUseColourTrio.Values.Text = "Use colour trio";
            this.kcbUseColourTrio.CheckedChanged += new System.EventHandler(this.kcbUseColourTrio_CheckedChanged);
            // 
            // ktbProgressValue
            // 
            this.ktbProgressValue.Location = new System.Drawing.Point(338, 12);
            this.ktbProgressValue.Maximum = 100;
            this.ktbProgressValue.Name = "ktbProgressValue";
            this.ktbProgressValue.Size = new System.Drawing.Size(303, 33);
            this.ktbProgressValue.TabIndex = 2;
            this.ktbProgressValue.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ktbProgressValue.ValueChanged += new System.EventHandler(this.ktbProgressValue_ValueChanged);
            // 
            // cpbExample
            // 
            this.cpbExample.AnimationFunction = WinFormAnimation_NET5.KnownAnimationFunctions.Linear;
            this.cpbExample.AnimationSpeed = 500;
            this.cpbExample.BackColor = System.Drawing.Color.Transparent;
            this.cpbExample.FirstValueColour = System.Drawing.Color.Red;
            this.cpbExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.cpbExample.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.cpbExample.InnerColour = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.cpbExample.InnerMargin = 2;
            this.cpbExample.InnerWidth = -1;
            this.cpbExample.Location = new System.Drawing.Point(12, 12);
            this.cpbExample.MarqueeAnimationSpeed = 2000;
            this.cpbExample.Name = "cpbExample";
            this.cpbExample.OuterColour = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.cpbExample.OuterMargin = -25;
            this.cpbExample.OuterWidth = 26;
            this.cpbExample.ProgressColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(107)))));
            this.cpbExample.ProgressWidth = 25;
            this.cpbExample.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cpbExample.SecondValueColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.cpbExample.Size = new System.Drawing.Size(320, 320);
            this.cpbExample.StartAngle = 270;
            this.cpbExample.SubscriptColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.cpbExample.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpbExample.SubscriptText = "";
            this.cpbExample.SuperscriptColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.cpbExample.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpbExample.SuperscriptText = "";
            this.cpbExample.TabIndex = 1;
            this.cpbExample.Text = "{0}%";
            this.cpbExample.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.cpbExample.ThirdValueColour = System.Drawing.Color.Green;
            // 
            // CircularProgressBarExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 348);
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
        private Krypton.Toolkit.KryptonTrackBar ktbProgressValue;
        private Krypton.Toolkit.Suite.Extended.Circular.ProgressBar.CircularProgressBar cpbExample;
        private Krypton.Toolkit.KryptonCheckBox kcbUseColourTrio;
        private Krypton.Toolkit.KryptonColorButton kryptonColorButton1;
    }
}
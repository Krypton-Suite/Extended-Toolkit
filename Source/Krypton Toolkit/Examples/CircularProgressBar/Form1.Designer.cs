
namespace CircularProgressBar
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ccbTest = new Krypton.Toolkit.Suite.Extended.Circular.ProgressBar.CircularProgressBar();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kcbColourTrio = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnStart = new Krypton.Toolkit.KryptonButton();
            this.kbtnStop = new Krypton.Toolkit.KryptonButton();
            this.kbtnReset = new Krypton.Toolkit.KryptonButton();
            this.tmrIncrement = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ccbTest
            // 
            this.ccbTest.AnimationFunction = Windows.Forms.Animation.Library.KnownAnimationFunctions.Linear;
            this.ccbTest.AnimationSpeed = 500;
            this.ccbTest.BackColor = System.Drawing.Color.Transparent;
            this.ccbTest.FirstValueColour = System.Drawing.Color.Red;
            this.ccbTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.ccbTest.InnerColour = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.ccbTest.InnerMargin = 2;
            this.ccbTest.InnerWidth = -1;
            this.ccbTest.Location = new System.Drawing.Point(12, 12);
            this.ccbTest.MarqueeAnimationSpeed = 2000;
            this.ccbTest.Name = "ccbTest";
            this.ccbTest.OuterColour = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.ccbTest.OuterMargin = -25;
            this.ccbTest.OuterWidth = 26;
            this.ccbTest.ProgressColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(107)))));
            this.ccbTest.ProgressWidth = 25;
            this.ccbTest.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.ccbTest.SecondValueColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.ccbTest.Size = new System.Drawing.Size(320, 320);
            this.ccbTest.StartAngle = 270;
            this.ccbTest.SubscriptColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.ccbTest.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.ccbTest.SubscriptText = "";
            this.ccbTest.SuperscriptColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.ccbTest.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.ccbTest.SuperscriptText = "";
            this.ccbTest.TabIndex = 0;
            this.ccbTest.Text = "{0}";
            this.ccbTest.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.ccbTest.ThirdValueColour = System.Drawing.Color.Green;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnReset);
            this.kryptonPanel1.Controls.Add(this.kbtnStop);
            this.kryptonPanel1.Controls.Add(this.kbtnStart);
            this.kryptonPanel1.Controls.Add(this.kcbColourTrio);
            this.kryptonPanel1.Controls.Add(this.ccbTest);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(343, 410);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kcbColourTrio
            // 
            this.kcbColourTrio.Location = new System.Drawing.Point(12, 378);
            this.kcbColourTrio.Name = "kcbColourTrio";
            this.kcbColourTrio.Size = new System.Drawing.Size(108, 20);
            this.kcbColourTrio.TabIndex = 2;
            this.kcbColourTrio.Values.Text = "&Use Colour Trio";
            this.kcbColourTrio.CheckedChanged += new System.EventHandler(this.kcbColourTrio_CheckedChanged);
            // 
            // kbtnStart
            // 
            this.kbtnStart.Location = new System.Drawing.Point(12, 338);
            this.kbtnStart.Name = "kbtnStart";
            this.kbtnStart.Size = new System.Drawing.Size(90, 25);
            this.kbtnStart.TabIndex = 3;
            this.kbtnStart.Values.Text = "&Start";
            this.kbtnStart.Click += new System.EventHandler(this.kbtnStart_Click);
            // 
            // kbtnStop
            // 
            this.kbtnStop.Location = new System.Drawing.Point(108, 338);
            this.kbtnStop.Name = "kbtnStop";
            this.kbtnStop.Size = new System.Drawing.Size(90, 25);
            this.kbtnStop.TabIndex = 4;
            this.kbtnStop.Values.Text = "S&top";
            this.kbtnStop.Click += new System.EventHandler(this.kbtnStop_Click);
            // 
            // kbtnReset
            // 
            this.kbtnReset.Location = new System.Drawing.Point(204, 338);
            this.kbtnReset.Name = "kbtnReset";
            this.kbtnReset.Size = new System.Drawing.Size(90, 25);
            this.kbtnReset.TabIndex = 5;
            this.kbtnReset.Values.Text = "R&eset";
            this.kbtnReset.Click += new System.EventHandler(this.kbtnReset_Click);
            // 
            // tmrIncrement
            // 
            this.tmrIncrement.Enabled = true;
            this.tmrIncrement.Interval = 1000;
            this.tmrIncrement.Tick += new System.EventHandler(this.tmrIncrement_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 410);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "Form1";
            this.Text = "Circular Progressbar";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Circular.ProgressBar.CircularProgressBar ccbTest;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonCheckBox kcbColourTrio;
        private Krypton.Toolkit.KryptonButton kbtnReset;
        private Krypton.Toolkit.KryptonButton kbtnStop;
        private Krypton.Toolkit.KryptonButton kbtnStart;
        private System.Windows.Forms.Timer tmrIncrement;
    }
}


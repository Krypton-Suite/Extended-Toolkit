
namespace PropertyGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kpg = new Krypton.Toolkit.Suite.Extended.Property.Grid.KryptonPropertyGrid();
            this.circularPictureBox1 = new Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox();
            this.kryptonBorderedLabel1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonBorderedLabel();
            this.kryptonCommandLinkButton1 = new Krypton.Toolkit.Suite.Extended.Buttons.KryptonCommandLinkButton();
            this.circularProgressBar1 = new Krypton.Toolkit.Suite.Extended.Circular.Progress.Bar.CircularProgressBar();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpg
            // 
            this.kpg.CategoryForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kpg.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kpg.HelpForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kpg.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(196)))), ((int)(((byte)(216)))));
            this.kpg.Location = new System.Drawing.Point(458, 12);
            this.kpg.Name = "kpg";
            this.kpg.Size = new System.Drawing.Size(330, 426);
            this.kpg.TabIndex = 0;
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.circularPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("circularPictureBox1.Image")));
            this.circularPictureBox1.Location = new System.Drawing.Point(12, 12);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.circularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.circularPictureBox1.TabIndex = 1;
            this.circularPictureBox1.TabStop = false;
            this.circularPictureBox1.Click += new System.EventHandler(this.circularPictureBox1_Click);
            // 
            // kryptonBorderedLabel1
            // 
            this.kryptonBorderedLabel1.BackColor = System.Drawing.Color.Transparent;
            this.kryptonBorderedLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kryptonBorderedLabel1.Location = new System.Drawing.Point(202, 73);
            this.kryptonBorderedLabel1.Name = "kryptonBorderedLabel1";
            this.kryptonBorderedLabel1.Size = new System.Drawing.Size(139, 20);
            this.kryptonBorderedLabel1.TabIndex = 2;
            this.kryptonBorderedLabel1.Values.Text = "kryptonBorderedLabel1";
            this.kryptonBorderedLabel1.Click += new System.EventHandler(this.kryptonBorderedLabel1_Click);
            // 
            // kryptonCommandLinkButton1
            // 
            this.kryptonCommandLinkButton1.Location = new System.Drawing.Point(202, 12);
            this.kryptonCommandLinkButton1.Name = "kryptonCommandLinkButton1";
            this.kryptonCommandLinkButton1.OverrideFocus.Border.Draw = Krypton.Toolkit.InheritBool.True;
            this.kryptonCommandLinkButton1.OverrideFocus.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonCommandLinkButton1.OverrideFocus.Border.GraphicsHint = Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonCommandLinkButton1.ProcessToElevate = null;
            this.kryptonCommandLinkButton1.Size = new System.Drawing.Size(250, 55);
            this.kryptonCommandLinkButton1.StateCommon.Content.LongText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonCommandLinkButton1.StateCommon.Content.LongText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.kryptonCommandLinkButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonCommandLinkButton1.StateCommon.Content.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonCommandLinkButton1.StateCommon.Content.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonCommandLinkButton1.TabIndex = 3;
            this.kryptonCommandLinkButton1.Click += new System.EventHandler(this.kryptonCommandLinkButton1_Click);
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = Windows.Forms.Animation.Library.KnownAnimationFunctions.Linear;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.FirstValueColour = System.Drawing.Color.Red;
            this.circularProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.circularProgressBar1.InnerColour = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(12, 118);
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
            this.circularProgressBar1.TabIndex = 4;
            this.circularProgressBar1.Text = "0";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar1.ThirdValueColour = System.Drawing.Color.Green;
            this.circularProgressBar1.Click += new System.EventHandler(this.circularProgressBar1_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBorderedLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonCommandLinkButton1);
            this.kryptonPanel1.Controls.Add(this.circularProgressBar1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
            this.kryptonPanel1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.circularPictureBox1);
            this.Controls.Add(this.kpg);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Property Grid";
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Property.Grid.KryptonPropertyGrid kpg;
        private Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox circularPictureBox1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonBorderedLabel kryptonBorderedLabel1;
        private Krypton.Toolkit.Suite.Extended.Buttons.KryptonCommandLinkButton kryptonCommandLinkButton1;
        private Krypton.Toolkit.Suite.Extended.Circular.Progress.Bar.CircularProgressBar circularProgressBar1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}


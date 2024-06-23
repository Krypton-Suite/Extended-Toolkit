#region MIT License

/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */

#endregion
namespace Examples
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
            this.kcbtnProgressColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcbtnThirdColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcbtnSecondColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcbtnFirstColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcbUseColourTrio = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonTrackBar1 = new Krypton.Toolkit.KryptonTrackBar();
            this.circularProgressBar1 = new Krypton.Toolkit.Suite.Extended.Circular.ProgressBar.CircularProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kcbtnProgressColour);
            this.kryptonPanel1.Controls.Add(this.kcbtnThirdColour);
            this.kryptonPanel1.Controls.Add(this.kcbtnSecondColour);
            this.kryptonPanel1.Controls.Add(this.kcbtnFirstColour);
            this.kryptonPanel1.Controls.Add(this.kcbUseColourTrio);
            this.kryptonPanel1.Controls.Add(this.kryptonTrackBar1);
            this.kryptonPanel1.Controls.Add(this.circularProgressBar1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(659, 450);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kcbtnProgressColour
            // 
            this.kcbtnProgressColour.CustomColorPreviewShape = Krypton.Toolkit.KryptonColorButtonCustomColorPreviewShape.Circle;
            this.kcbtnProgressColour.Location = new System.Drawing.Point(339, 204);
            this.kcbtnProgressColour.Name = "kcbtnProgressColour";
            this.kcbtnProgressColour.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(107)))));
            this.kcbtnProgressColour.Size = new System.Drawing.Size(194, 25);
            this.kcbtnProgressColour.Splitter = false;
            this.kcbtnProgressColour.TabIndex = 7;
            this.kcbtnProgressColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kcbtnProgressColour.Values.Image")));
            this.kcbtnProgressColour.Values.RoundedCorners = 8;
            this.kcbtnProgressColour.Values.Text = "Progress Colour";
            this.kcbtnProgressColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbtnProgressColour_SelectedColorChanged);
            // 
            // kcbtnThirdColour
            // 
            this.kcbtnThirdColour.CustomColorPreviewShape = Krypton.Toolkit.KryptonColorButtonCustomColorPreviewShape.Circle;
            this.kcbtnThirdColour.DropDownOrientation = Krypton.Toolkit.VisualOrientation.Right;
            this.kcbtnThirdColour.Enabled = false;
            this.kcbtnThirdColour.Location = new System.Drawing.Point(339, 141);
            this.kcbtnThirdColour.Name = "kcbtnThirdColour";
            this.kcbtnThirdColour.SelectedColor = System.Drawing.Color.Green;
            this.kcbtnThirdColour.Size = new System.Drawing.Size(194, 25);
            this.kcbtnThirdColour.Splitter = false;
            this.kcbtnThirdColour.TabIndex = 6;
            this.kcbtnThirdColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kcbtnThirdColour.Values.Image")));
            this.kcbtnThirdColour.Values.RoundedCorners = 8;
            this.kcbtnThirdColour.Values.Text = "Third Colour";
            this.kcbtnThirdColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbtnThirdColour_SelectedColorChanged);
            // 
            // kcbtnSecondColour
            // 
            this.kcbtnSecondColour.CustomColorPreviewShape = Krypton.Toolkit.KryptonColorButtonCustomColorPreviewShape.Circle;
            this.kcbtnSecondColour.DropDownOrientation = Krypton.Toolkit.VisualOrientation.Right;
            this.kcbtnSecondColour.Enabled = false;
            this.kcbtnSecondColour.Location = new System.Drawing.Point(339, 110);
            this.kcbtnSecondColour.Name = "kcbtnSecondColour";
            this.kcbtnSecondColour.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.kcbtnSecondColour.Size = new System.Drawing.Size(194, 25);
            this.kcbtnSecondColour.Splitter = false;
            this.kcbtnSecondColour.TabIndex = 5;
            this.kcbtnSecondColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kcbtnSecondColour.Values.Image")));
            this.kcbtnSecondColour.Values.RoundedCorners = 8;
            this.kcbtnSecondColour.Values.Text = "Second Colour";
            this.kcbtnSecondColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbtnSecondColour_SelectedColorChanged);
            // 
            // kcbtnFirstColour
            // 
            this.kcbtnFirstColour.CustomColorPreviewShape = Krypton.Toolkit.KryptonColorButtonCustomColorPreviewShape.Circle;
            this.kcbtnFirstColour.DropDownOrientation = Krypton.Toolkit.VisualOrientation.Right;
            this.kcbtnFirstColour.Enabled = false;
            this.kcbtnFirstColour.Location = new System.Drawing.Point(339, 79);
            this.kcbtnFirstColour.Name = "kcbtnFirstColour";
            this.kcbtnFirstColour.Size = new System.Drawing.Size(194, 25);
            this.kcbtnFirstColour.Splitter = false;
            this.kcbtnFirstColour.TabIndex = 4;
            this.kcbtnFirstColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kcbtnFirstColour.Values.Image")));
            this.kcbtnFirstColour.Values.RoundedCorners = 8;
            this.kcbtnFirstColour.Values.Text = "First Colour";
            this.kcbtnFirstColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbtnFirstColour_SelectedColorChanged);
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
            this.ClientSize = new System.Drawing.Size(659, 450);
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
        private Krypton.Toolkit.KryptonCheckBox kcbUseColourTrio;
        private Krypton.Toolkit.KryptonColorButton kcbtnThirdColour;
        private Krypton.Toolkit.KryptonColorButton kcbtnSecondColour;
        private Krypton.Toolkit.KryptonColorButton kcbtnFirstColour;
        private Krypton.Toolkit.KryptonColorButton kcbtnProgressColour;
    }
}
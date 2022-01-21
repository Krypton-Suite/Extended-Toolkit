namespace DataVisualisation.ScottPlot.Demos
{
    partial class MouseTracker
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
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.klblXCoordinate = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.klblXPixel = new Krypton.Toolkit.KryptonLabel();
            this.klblMouse = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.klblYPixel = new Krypton.Toolkit.KryptonLabel();
            this.klblYCoordinate = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.formsPlot1 = new Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.klblYPixel);
            this.kryptonPanel2.Controls.Add(this.klblYCoordinate);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel9);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel2.Controls.Add(this.klblMouse);
            this.kryptonPanel2.Controls.Add(this.klblXPixel);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.klblXCoordinate);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(800, 100);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 33);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(27, 21);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "X:";
            // 
            // klblXCoordinate
            // 
            this.klblXCoordinate.Location = new System.Drawing.Point(105, 33);
            this.klblXCoordinate.Name = "klblXCoordinate";
            this.klblXCoordinate.Size = new System.Drawing.Size(20, 21);
            this.klblXCoordinate.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblXCoordinate.TabIndex = 5;
            this.klblXCoordinate.Values.Text = "?";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(44, 6);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(47, 21);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Values.Text = "Pixel";
            // 
            // klblXPixel
            // 
            this.klblXPixel.Location = new System.Drawing.Point(44, 33);
            this.klblXPixel.Name = "klblXPixel";
            this.klblXPixel.Size = new System.Drawing.Size(20, 21);
            this.klblXPixel.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblXPixel.TabIndex = 7;
            this.klblXPixel.Values.Text = "?";
            // 
            // klblMouse
            // 
            this.klblMouse.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblMouse.Location = new System.Drawing.Point(220, 6);
            this.klblMouse.Name = "klblMouse";
            this.klblMouse.Size = new System.Drawing.Size(154, 21);
            this.klblMouse.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMouse.TabIndex = 8;
            this.klblMouse.Values.Text = "Waiting for mouse...";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(105, 6);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(90, 21);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 9;
            this.kryptonLabel6.Values.Text = "Coordinate";
            // 
            // klblYPixel
            // 
            this.klblYPixel.Location = new System.Drawing.Point(44, 60);
            this.klblYPixel.Name = "klblYPixel";
            this.klblYPixel.Size = new System.Drawing.Size(20, 21);
            this.klblYPixel.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblYPixel.TabIndex = 12;
            this.klblYPixel.Values.Text = "?";
            // 
            // klblYCoordinate
            // 
            this.klblYCoordinate.Location = new System.Drawing.Point(105, 60);
            this.klblYCoordinate.Name = "klblYCoordinate";
            this.klblYCoordinate.Size = new System.Drawing.Size(20, 21);
            this.klblYCoordinate.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblYCoordinate.TabIndex = 11;
            this.klblYCoordinate.Values.Text = "?";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(12, 60);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(27, 21);
            this.kryptonLabel9.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel9.TabIndex = 10;
            this.kryptonLabel9.Values.Text = "Y:";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.formsPlot1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 100);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 350);
            this.kryptonPanel1.TabIndex = 6;
            // 
            // formsPlot1
            // 
            this.formsPlot1.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(0, 0);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(800, 350);
            this.formsPlot1.TabIndex = 0;
            this.formsPlot1.MouseEnter += new System.EventHandler(this.formsPlot1_MouseEnter);
            this.formsPlot1.MouseLeave += new System.EventHandler(this.formsPlot1_MouseLeave);
            this.formsPlot1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formsPlot1_MouseMove);
            // 
            // MouseTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Name = "MouseTracker";
            this.Text = "MouseTracker";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel klblYPixel;
        private Krypton.Toolkit.KryptonLabel klblYCoordinate;
        private Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonLabel klblMouse;
        private Krypton.Toolkit.KryptonLabel klblXPixel;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel klblXCoordinate;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot formsPlot1;
    }
}
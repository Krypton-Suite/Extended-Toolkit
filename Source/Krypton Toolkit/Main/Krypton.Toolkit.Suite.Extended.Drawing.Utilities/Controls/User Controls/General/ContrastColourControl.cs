namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Controls
{
    public class ContrastColourControl : UserControl
    {
        private CircularPictureBox cpbContrastColour;
        private KryptonLabel kryptonLabel1;
        private KryptonLabel kryptonLabel2;
        private KryptonButton kryptonButton1;
        private KryptonButton kryptonButton2;
        private CircularPictureBox cpbBaseColour;

        private void InitializeComponent()
        {
            this.cpbBaseColour = new Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox();
            this.cpbContrastColour = new Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbContrastColour)).BeginInit();
            this.SuspendLayout();
            // 
            // cpbBaseColour
            // 
            this.cpbBaseColour.BackColor = System.Drawing.Color.White;
            this.cpbBaseColour.Location = new System.Drawing.Point(28, 45);
            this.cpbBaseColour.Name = "cpbBaseColour";
            this.cpbBaseColour.Size = new System.Drawing.Size(256, 256);
            this.cpbBaseColour.TabIndex = 96;
            this.cpbBaseColour.TabStop = false;
            // 
            // cpbContrastColour
            // 
            this.cpbContrastColour.BackColor = System.Drawing.Color.White;
            this.cpbContrastColour.Location = new System.Drawing.Point(526, 45);
            this.cpbContrastColour.Name = "cpbContrastColour";
            this.cpbContrastColour.Size = new System.Drawing.Size(256, 256);
            this.cpbContrastColour.TabIndex = 97;
            this.cpbContrastColour.TabStop = false;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(107, 18);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(100, 21);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 98;
            this.kryptonLabel1.Values.Text = "Base Colour";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(588, 18);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(124, 21);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 99;
            this.kryptonLabel2.Values.Text = "Contrast Colour";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(357, 109);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton1.TabIndex = 101;
            this.kryptonButton1.Values.Text = "-->";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(357, 205);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton2.TabIndex = 102;
            this.kryptonButton2.Values.Text = "<--";
            // 
            // ContrastColourControl
            // 
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.cpbContrastColour);
            this.Controls.Add(this.cpbBaseColour);
            this.Name = "ContrastColourControl";
            this.Size = new System.Drawing.Size(805, 491);
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbContrastColour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
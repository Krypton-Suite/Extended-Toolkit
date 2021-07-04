namespace Cyotek.Windows.Forms
{
  partial class ColorEditor
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.rgbHeaderLabel = new System.Windows.Forms.Label();
      this.rLabel = new System.Windows.Forms.Label();
      this.rNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.rColorBar = new Cyotek.Windows.Forms.RgbaColorSlider();
      this.gLabel = new System.Windows.Forms.Label();
      this.gColorBar = new Cyotek.Windows.Forms.RgbaColorSlider();
      this.gNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.bLabel = new System.Windows.Forms.Label();
      this.bColorBar = new Cyotek.Windows.Forms.RgbaColorSlider();
      this.bNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.hexLabel = new System.Windows.Forms.Label();
      this.hexTextBox = new System.Windows.Forms.ComboBox();
      this.lNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.lColorBar = new Cyotek.Windows.Forms.LightnessColorSlider();
      this.lLabel = new System.Windows.Forms.Label();
      this.sNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.sColorBar = new Cyotek.Windows.Forms.SaturationColorSlider();
      this.sLabel = new System.Windows.Forms.Label();
      this.hColorBar = new Cyotek.Windows.Forms.HueColorSlider();
      this.hNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.hLabel = new System.Windows.Forms.Label();
      this.hslLabel = new System.Windows.Forms.Label();
      this.aNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.aColorBar = new Cyotek.Windows.Forms.RgbaColorSlider();
      this.aLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.rNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.hNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.aNumericUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // rgbHeaderLabel
      // 
      this.rgbHeaderLabel.AutoSize = true;
      this.rgbHeaderLabel.Location = new System.Drawing.Point(-3, 0);
      this.rgbHeaderLabel.Name = "rgbHeaderLabel";
      this.rgbHeaderLabel.Size = new System.Drawing.Size(33, 13);
      this.rgbHeaderLabel.TabIndex = 0;
      this.rgbHeaderLabel.Text = "RGB:";
      // 
      // rLabel
      // 
      this.rLabel.AutoSize = true;
      this.rLabel.Location = new System.Drawing.Point(3, 13);
      this.rLabel.Name = "rLabel";
      this.rLabel.Size = new System.Drawing.Size(18, 13);
      this.rLabel.TabIndex = 1;
      this.rLabel.Text = "R:";
      // 
      // rNumericUpDown
      // 
      this.rNumericUpDown.Location = new System.Drawing.Point(105, 11);
      this.rNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.rNumericUpDown.Name = "rNumericUpDown";
      this.rNumericUpDown.Size = new System.Drawing.Size(58, 20);
      this.rNumericUpDown.TabIndex = 2;
      this.rNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.rNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // rColorBar
      // 
      this.rColorBar.Location = new System.Drawing.Point(27, 13);
      this.rColorBar.Name = "rColorBar";
      this.rColorBar.Size = new System.Drawing.Size(72, 20);
      this.rColorBar.TabIndex = 3;
      this.rColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // gLabel
      // 
      this.gLabel.AutoSize = true;
      this.gLabel.Location = new System.Drawing.Point(3, 39);
      this.gLabel.Name = "gLabel";
      this.gLabel.Size = new System.Drawing.Size(18, 13);
      this.gLabel.TabIndex = 4;
      this.gLabel.Text = "G:";
      // 
      // gColorBar
      // 
      this.gColorBar.Channel = Cyotek.Windows.Forms.RgbaChannel.Green;
      this.gColorBar.Location = new System.Drawing.Point(27, 39);
      this.gColorBar.Name = "gColorBar";
      this.gColorBar.Size = new System.Drawing.Size(72, 20);
      this.gColorBar.TabIndex = 6;
      this.gColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // gNumericUpDown
      // 
      this.gNumericUpDown.Location = new System.Drawing.Point(105, 37);
      this.gNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.gNumericUpDown.Name = "gNumericUpDown";
      this.gNumericUpDown.Size = new System.Drawing.Size(58, 20);
      this.gNumericUpDown.TabIndex = 5;
      this.gNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.gNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // bLabel
      // 
      this.bLabel.AutoSize = true;
      this.bLabel.Location = new System.Drawing.Point(3, 65);
      this.bLabel.Name = "bLabel";
      this.bLabel.Size = new System.Drawing.Size(17, 13);
      this.bLabel.TabIndex = 7;
      this.bLabel.Text = "B:";
      // 
      // bColorBar
      // 
      this.bColorBar.Channel = Cyotek.Windows.Forms.RgbaChannel.Blue;
      this.bColorBar.Location = new System.Drawing.Point(27, 65);
      this.bColorBar.Name = "bColorBar";
      this.bColorBar.Size = new System.Drawing.Size(72, 20);
      this.bColorBar.TabIndex = 9;
      this.bColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // bNumericUpDown
      // 
      this.bNumericUpDown.Location = new System.Drawing.Point(105, 65);
      this.bNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.bNumericUpDown.Name = "bNumericUpDown";
      this.bNumericUpDown.Size = new System.Drawing.Size(58, 20);
      this.bNumericUpDown.TabIndex = 8;
      this.bNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.bNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // hexLabel
      // 
      this.hexLabel.AutoSize = true;
      this.hexLabel.Location = new System.Drawing.Point(3, 94);
      this.hexLabel.Name = "hexLabel";
      this.hexLabel.Size = new System.Drawing.Size(29, 13);
      this.hexLabel.TabIndex = 10;
      this.hexLabel.Text = "Hex:";
      // 
      // hexTextBox
      // 
      this.hexTextBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.hexTextBox.Location = new System.Drawing.Point(105, 91);
      this.hexTextBox.Name = "hexTextBox";
      this.hexTextBox.Size = new System.Drawing.Size(58, 21);
      this.hexTextBox.TabIndex = 11;
      this.hexTextBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.hexTextBox_DrawItem);
      this.hexTextBox.DropDown += new System.EventHandler(this.hexTextBox_DropDown);
      this.hexTextBox.SelectedIndexChanged += new System.EventHandler(this.hexTextBox_SelectedIndexChanged);
      this.hexTextBox.TextChanged += new System.EventHandler(this.ValueChangedHandler);
      this.hexTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hexTextBox_KeyDown);
      // 
      // lNumericUpDown
      // 
      this.lNumericUpDown.Location = new System.Drawing.Point(105, 190);
      this.lNumericUpDown.Name = "lNumericUpDown";
      this.lNumericUpDown.Size = new System.Drawing.Size(58, 20);
      this.lNumericUpDown.TabIndex = 20;
      this.lNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.lNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // lColorBar
      // 
      this.lColorBar.Location = new System.Drawing.Point(27, 190);
      this.lColorBar.Name = "lColorBar";
      this.lColorBar.Size = new System.Drawing.Size(72, 20);
      this.lColorBar.TabIndex = 21;
      this.lColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // lLabel
      // 
      this.lLabel.AutoSize = true;
      this.lLabel.Location = new System.Drawing.Point(3, 192);
      this.lLabel.Name = "lLabel";
      this.lLabel.Size = new System.Drawing.Size(16, 13);
      this.lLabel.TabIndex = 19;
      this.lLabel.Text = "L:";
      // 
      // sNumericUpDown
      // 
      this.sNumericUpDown.Location = new System.Drawing.Point(105, 164);
      this.sNumericUpDown.Name = "sNumericUpDown";
      this.sNumericUpDown.Size = new System.Drawing.Size(58, 20);
      this.sNumericUpDown.TabIndex = 17;
      this.sNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.sNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // sColorBar
      // 
      this.sColorBar.Location = new System.Drawing.Point(27, 164);
      this.sColorBar.Name = "sColorBar";
      this.sColorBar.Size = new System.Drawing.Size(72, 20);
      this.sColorBar.TabIndex = 18;
      this.sColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // sLabel
      // 
      this.sLabel.AutoSize = true;
      this.sLabel.Location = new System.Drawing.Point(4, 166);
      this.sLabel.Name = "sLabel";
      this.sLabel.Size = new System.Drawing.Size(17, 13);
      this.sLabel.TabIndex = 16;
      this.sLabel.Text = "S:";
      // 
      // hColorBar
      // 
      this.hColorBar.Location = new System.Drawing.Point(27, 138);
      this.hColorBar.Name = "hColorBar";
      this.hColorBar.Size = new System.Drawing.Size(72, 20);
      this.hColorBar.TabIndex = 15;
      this.hColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // hNumericUpDown
      // 
      this.hNumericUpDown.Location = new System.Drawing.Point(105, 138);
      this.hNumericUpDown.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
      this.hNumericUpDown.Name = "hNumericUpDown";
      this.hNumericUpDown.Size = new System.Drawing.Size(58, 20);
      this.hNumericUpDown.TabIndex = 14;
      this.hNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.hNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // hLabel
      // 
      this.hLabel.AutoSize = true;
      this.hLabel.Location = new System.Drawing.Point(3, 140);
      this.hLabel.Name = "hLabel";
      this.hLabel.Size = new System.Drawing.Size(18, 13);
      this.hLabel.TabIndex = 13;
      this.hLabel.Text = "H:";
      // 
      // hslLabel
      // 
      this.hslLabel.AutoSize = true;
      this.hslLabel.Location = new System.Drawing.Point(3, 117);
      this.hslLabel.Name = "hslLabel";
      this.hslLabel.Size = new System.Drawing.Size(31, 13);
      this.hslLabel.TabIndex = 12;
      this.hslLabel.Text = "HSL:";
      // 
      // aNumericUpDown
      // 
      this.aNumericUpDown.Location = new System.Drawing.Point(105, 216);
      this.aNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.aNumericUpDown.Name = "aNumericUpDown";
      this.aNumericUpDown.Size = new System.Drawing.Size(58, 20);
      this.aNumericUpDown.TabIndex = 23;
      this.aNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.aNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // aColorBar
      // 
      this.aColorBar.Channel = Cyotek.Windows.Forms.RgbaChannel.Alpha;
      this.aColorBar.Location = new System.Drawing.Point(27, 216);
      this.aColorBar.Name = "aColorBar";
      this.aColorBar.Size = new System.Drawing.Size(72, 20);
      this.aColorBar.TabIndex = 24;
      this.aColorBar.ValueChanged += new System.EventHandler(this.ValueChangedHandler);
      // 
      // aLabel
      // 
      this.aLabel.AutoSize = true;
      this.aLabel.Location = new System.Drawing.Point(3, 218);
      this.aLabel.Name = "aLabel";
      this.aLabel.Size = new System.Drawing.Size(37, 13);
      this.aLabel.TabIndex = 22;
      this.aLabel.Text = "Alpha:";
      // 
      // ColorEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.aLabel);
      this.Controls.Add(this.aNumericUpDown);
      this.Controls.Add(this.aColorBar);
      this.Controls.Add(this.hslLabel);
      this.Controls.Add(this.lNumericUpDown);
      this.Controls.Add(this.lColorBar);
      this.Controls.Add(this.lLabel);
      this.Controls.Add(this.sNumericUpDown);
      this.Controls.Add(this.sColorBar);
      this.Controls.Add(this.sLabel);
      this.Controls.Add(this.hColorBar);
      this.Controls.Add(this.hNumericUpDown);
      this.Controls.Add(this.hLabel);
      this.Controls.Add(this.hexTextBox);
      this.Controls.Add(this.hexLabel);
      this.Controls.Add(this.bNumericUpDown);
      this.Controls.Add(this.bColorBar);
      this.Controls.Add(this.bLabel);
      this.Controls.Add(this.gNumericUpDown);
      this.Controls.Add(this.gColorBar);
      this.Controls.Add(this.gLabel);
      this.Controls.Add(this.rColorBar);
      this.Controls.Add(this.rNumericUpDown);
      this.Controls.Add(this.rLabel);
      this.Controls.Add(this.rgbHeaderLabel);
      this.Name = "ColorEditor";
      this.Size = new System.Drawing.Size(173, 246);
      ((System.ComponentModel.ISupportInitialize)(this.rNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.hNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.aNumericUpDown)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label rgbHeaderLabel;
    private System.Windows.Forms.Label rLabel;
    private System.Windows.Forms.NumericUpDown rNumericUpDown;
    private RgbaColorSlider rColorBar;
    private System.Windows.Forms.Label gLabel;
    private RgbaColorSlider gColorBar;
    private System.Windows.Forms.NumericUpDown gNumericUpDown;
    private System.Windows.Forms.Label bLabel;
    private RgbaColorSlider bColorBar;
    private System.Windows.Forms.NumericUpDown bNumericUpDown;
    private System.Windows.Forms.Label hexLabel;
    private System.Windows.Forms.ComboBox hexTextBox;
    private System.Windows.Forms.NumericUpDown lNumericUpDown;
    private LightnessColorSlider lColorBar;
    private System.Windows.Forms.Label lLabel;
    private System.Windows.Forms.NumericUpDown sNumericUpDown;
    private SaturationColorSlider sColorBar;
    private System.Windows.Forms.Label sLabel;
    private HueColorSlider hColorBar;
    private System.Windows.Forms.NumericUpDown hNumericUpDown;
    private System.Windows.Forms.Label hLabel;
    private System.Windows.Forms.Label hslLabel;
    private System.Windows.Forms.NumericUpDown aNumericUpDown;
    private RgbaColorSlider aColorBar;
    private System.Windows.Forms.Label aLabel;
  }
}

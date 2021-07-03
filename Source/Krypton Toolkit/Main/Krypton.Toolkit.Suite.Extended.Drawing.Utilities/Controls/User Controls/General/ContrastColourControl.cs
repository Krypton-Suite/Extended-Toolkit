namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities.Controls
{
    public class ContrastColourControl : UserControl
    {
        private CircularPictureBox cpbContrastColour;
        private KryptonLabel kryptonLabel1;
        private KryptonLabel kryptonLabel2;
        private KryptonButton kryptonButton1;
        private KryptonButton kryptonButton2;
        private KryptonAlphaValueLabel kryptonAlphaValueLabel1;
        private KryptonRedValueLabel kryptonRedValueLabel1;
        private KryptonBlueValueLabel kryptonBlueValueLabel1;
        private KryptonGreenValueLabel kryptonGreenValueLabel1;
        private KryptonAlphaValueNumericBox kryptonAlphaValueNumericBox1;
        private KryptonRedValueNumericBox kryptonRedValueNumericBox1;
        private KryptonBlueValueNumericBox kryptonBlueValueNumericBox1;
        private KryptonGreenValueNumericBox kryptonGreenValueNumericBox1;
        private KryptonGreenValueNumericBox kryptonGreenValueNumericBox2;
        private KryptonBlueValueNumericBox kryptonBlueValueNumericBox2;
        private KryptonRedValueNumericBox kryptonRedValueNumericBox2;
        private KryptonAlphaValueNumericBox kryptonAlphaValueNumericBox2;
        private KryptonGreenValueLabel kryptonGreenValueLabel2;
        private KryptonBlueValueLabel kryptonBlueValueLabel2;
        private KryptonRedValueLabel kryptonRedValueLabel2;
        private KryptonAlphaValueLabel kryptonAlphaValueLabel2;
        private CircularPictureBox cpbBaseColour;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContrastColourControl));
            this.cpbBaseColour = new Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox();
            this.cpbContrastColour = new Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonAlphaValueLabel1 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonAlphaValueLabel();
            this.kryptonRedValueLabel1 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonRedValueLabel();
            this.kryptonBlueValueLabel1 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonBlueValueLabel();
            this.kryptonGreenValueLabel1 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonGreenValueLabel();
            this.kryptonAlphaValueNumericBox1 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonAlphaValueNumericBox();
            this.kryptonRedValueNumericBox1 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonRedValueNumericBox();
            this.kryptonBlueValueNumericBox1 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonBlueValueNumericBox();
            this.kryptonGreenValueNumericBox1 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonGreenValueNumericBox();
            this.kryptonGreenValueNumericBox2 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonGreenValueNumericBox();
            this.kryptonBlueValueNumericBox2 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonBlueValueNumericBox();
            this.kryptonRedValueNumericBox2 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonRedValueNumericBox();
            this.kryptonAlphaValueNumericBox2 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonAlphaValueNumericBox();
            this.kryptonGreenValueLabel2 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonGreenValueLabel();
            this.kryptonBlueValueLabel2 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonBlueValueLabel();
            this.kryptonRedValueLabel2 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonRedValueLabel();
            this.kryptonAlphaValueLabel2 = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonAlphaValueLabel();
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
            // kryptonAlphaValueLabel1
            // 
            this.kryptonAlphaValueLabel1.AlphaValue = 0;
            this.kryptonAlphaValueLabel1.ExtraText = "Alpha Value";
            this.kryptonAlphaValueLabel1.Location = new System.Drawing.Point(32, 307);
            this.kryptonAlphaValueLabel1.Name = "kryptonAlphaValueLabel1";
            this.kryptonAlphaValueLabel1.ShowColon = false;
            this.kryptonAlphaValueLabel1.ShowCurrentColourValue = false;
            this.kryptonAlphaValueLabel1.Size = new System.Drawing.Size(102, 21);
            this.kryptonAlphaValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonAlphaValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonAlphaValueLabel1.TabIndex = 103;
            this.kryptonAlphaValueLabel1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonAlphaValueLabel1.Values.Text = "Alpha Value:";
            // 
            // kryptonRedValueLabel1
            // 
            this.kryptonRedValueLabel1.ExtraText = "Red Value";
            this.kryptonRedValueLabel1.Location = new System.Drawing.Point(43, 335);
            this.kryptonRedValueLabel1.Name = "kryptonRedValueLabel1";
            this.kryptonRedValueLabel1.RedValue = 0;
            this.kryptonRedValueLabel1.ShowColon = false;
            this.kryptonRedValueLabel1.ShowCurrentColourValue = false;
            this.kryptonRedValueLabel1.Size = new System.Drawing.Size(91, 21);
            this.kryptonRedValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.TabIndex = 104;
            this.kryptonRedValueLabel1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.UseAccessibleUI = false;
            this.kryptonRedValueLabel1.Values.Text = "Red Value:";
            // 
            // kryptonBlueValueLabel1
            // 
            this.kryptonBlueValueLabel1.BlueValue = 0;
            this.kryptonBlueValueLabel1.ExtraText = "Blue Value";
            this.kryptonBlueValueLabel1.Location = new System.Drawing.Point(40, 363);
            this.kryptonBlueValueLabel1.Name = "kryptonBlueValueLabel1";
            this.kryptonBlueValueLabel1.ShowColon = false;
            this.kryptonBlueValueLabel1.ShowCurrentColourValue = false;
            this.kryptonBlueValueLabel1.Size = new System.Drawing.Size(94, 21);
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.TabIndex = 105;
            this.kryptonBlueValueLabel1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.UseAccessibleUI = false;
            this.kryptonBlueValueLabel1.Values.Text = "Blue Value:";
            // 
            // kryptonGreenValueLabel1
            // 
            this.kryptonGreenValueLabel1.ExtraText = "Green Value";
            this.kryptonGreenValueLabel1.GreenValue = 0;
            this.kryptonGreenValueLabel1.Location = new System.Drawing.Point(28, 391);
            this.kryptonGreenValueLabel1.Name = "kryptonGreenValueLabel1";
            this.kryptonGreenValueLabel1.ShowColon = false;
            this.kryptonGreenValueLabel1.ShowCurrentColourValue = false;
            this.kryptonGreenValueLabel1.Size = new System.Drawing.Size(106, 21);
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.TabIndex = 106;
            this.kryptonGreenValueLabel1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.UseAccessibleUI = false;
            this.kryptonGreenValueLabel1.Values.Text = "Green Value:";
            // 
            // kryptonAlphaValueNumericBox1
            // 
            this.kryptonAlphaValueNumericBox1.Location = new System.Drawing.Point(141, 307);
            this.kryptonAlphaValueNumericBox1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonAlphaValueNumericBox1.Name = "kryptonAlphaValueNumericBox1";
            this.kryptonAlphaValueNumericBox1.Size = new System.Drawing.Size(77, 22);
            this.kryptonAlphaValueNumericBox1.TabIndex = 107;
            this.kryptonAlphaValueNumericBox1.Typeface = null;
            // 
            // kryptonRedValueNumericBox1
            // 
            this.kryptonRedValueNumericBox1.Location = new System.Drawing.Point(141, 334);
            this.kryptonRedValueNumericBox1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonRedValueNumericBox1.Name = "kryptonRedValueNumericBox1";
            this.kryptonRedValueNumericBox1.Size = new System.Drawing.Size(77, 22);
            this.kryptonRedValueNumericBox1.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueNumericBox1.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonRedValueNumericBox1.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonRedValueNumericBox1.TabIndex = 108;
            this.kryptonRedValueNumericBox1.ToolTipValues.Description = "The red value";
            this.kryptonRedValueNumericBox1.ToolTipValues.EnableToolTips = true;
            this.kryptonRedValueNumericBox1.ToolTipValues.Heading = "Red Value";
            this.kryptonRedValueNumericBox1.ToolTipValues.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.kryptonRedValueNumericBox1.Typeface = null;
            this.kryptonRedValueNumericBox1.UseAccessibleUI = false;
            //
            // kryptonBlueValueNumericBox1
            // 
            this.kryptonBlueValueNumericBox1.Location = new System.Drawing.Point(141, 364);
            this.kryptonBlueValueNumericBox1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonBlueValueNumericBox1.Name = "kryptonBlueValueNumericBox1";
            this.kryptonBlueValueNumericBox1.Size = new System.Drawing.Size(77, 22);
            this.kryptonBlueValueNumericBox1.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueNumericBox1.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonBlueValueNumericBox1.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonBlueValueNumericBox1.TabIndex = 109;
            this.kryptonBlueValueNumericBox1.ToolTipValues.Description = "The blue value";
            this.kryptonBlueValueNumericBox1.ToolTipValues.EnableToolTips = true;
            this.kryptonBlueValueNumericBox1.ToolTipValues.Heading = "Blue Value";
            this.kryptonBlueValueNumericBox1.ToolTipValues.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.kryptonBlueValueNumericBox1.Typeface = null;
            this.kryptonBlueValueNumericBox1.UseAccessibleUI = false;
            // 
            // kryptonGreenValueNumericBox1
            // 
            this.kryptonGreenValueNumericBox1.Location = new System.Drawing.Point(141, 391);
            this.kryptonGreenValueNumericBox1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonGreenValueNumericBox1.Name = "kryptonGreenValueNumericBox1";
            this.kryptonGreenValueNumericBox1.Size = new System.Drawing.Size(77, 22);
            this.kryptonGreenValueNumericBox1.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueNumericBox1.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonGreenValueNumericBox1.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonGreenValueNumericBox1.TabIndex = 110;
            this.kryptonGreenValueNumericBox1.ToolTipValues.Description = "The green value";
            this.kryptonGreenValueNumericBox1.ToolTipValues.EnableToolTips = true;
            this.kryptonGreenValueNumericBox1.ToolTipValues.Heading = "Green Value";
            this.kryptonGreenValueNumericBox1.ToolTipValues.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.kryptonGreenValueNumericBox1.Typeface = null;
            this.kryptonGreenValueNumericBox1.UseAccessibleUI = false;
            // 
            // kryptonGreenValueNumericBox2
            // 
            this.kryptonGreenValueNumericBox2.Location = new System.Drawing.Point(662, 391);
            this.kryptonGreenValueNumericBox2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonGreenValueNumericBox2.Name = "kryptonGreenValueNumericBox2";
            this.kryptonGreenValueNumericBox2.Size = new System.Drawing.Size(77, 22);
            this.kryptonGreenValueNumericBox2.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueNumericBox2.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonGreenValueNumericBox2.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonGreenValueNumericBox2.TabIndex = 118;
            this.kryptonGreenValueNumericBox2.ToolTipValues.Description = "The green value";
            this.kryptonGreenValueNumericBox2.ToolTipValues.EnableToolTips = true;
            this.kryptonGreenValueNumericBox2.ToolTipValues.Heading = "Green Value";
            this.kryptonGreenValueNumericBox2.ToolTipValues.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.kryptonGreenValueNumericBox2.Typeface = null;
            this.kryptonGreenValueNumericBox2.UseAccessibleUI = false;
            // 
            // kryptonBlueValueNumericBox2
            // 
            this.kryptonBlueValueNumericBox2.Location = new System.Drawing.Point(662, 364);
            this.kryptonBlueValueNumericBox2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonBlueValueNumericBox2.Name = "kryptonBlueValueNumericBox2";
            this.kryptonBlueValueNumericBox2.Size = new System.Drawing.Size(77, 22);
            this.kryptonBlueValueNumericBox2.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueNumericBox2.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonBlueValueNumericBox2.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonBlueValueNumericBox2.TabIndex = 117;
            this.kryptonBlueValueNumericBox2.ToolTipValues.Description = "The blue value";
            this.kryptonBlueValueNumericBox2.ToolTipValues.EnableToolTips = true;
            this.kryptonBlueValueNumericBox2.ToolTipValues.Heading = "Blue Value";
            this.kryptonBlueValueNumericBox2.ToolTipValues.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.kryptonBlueValueNumericBox2.Typeface = null;
            this.kryptonBlueValueNumericBox2.UseAccessibleUI = false;
            // 
            // kryptonRedValueNumericBox2
            // 
            this.kryptonRedValueNumericBox2.Location = new System.Drawing.Point(662, 334);
            this.kryptonRedValueNumericBox2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonRedValueNumericBox2.Name = "kryptonRedValueNumericBox2";
            this.kryptonRedValueNumericBox2.Size = new System.Drawing.Size(77, 22);
            this.kryptonRedValueNumericBox2.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueNumericBox2.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonRedValueNumericBox2.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonRedValueNumericBox2.TabIndex = 116;
            this.kryptonRedValueNumericBox2.ToolTipValues.Description = "The red value";
            this.kryptonRedValueNumericBox2.ToolTipValues.EnableToolTips = true;
            this.kryptonRedValueNumericBox2.ToolTipValues.Heading = "Red Value";
            this.kryptonRedValueNumericBox2.ToolTipValues.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            this.kryptonRedValueNumericBox2.Typeface = null;
            this.kryptonRedValueNumericBox2.UseAccessibleUI = false;
            // 
            // kryptonAlphaValueNumericBox2
            // 
            this.kryptonAlphaValueNumericBox2.Location = new System.Drawing.Point(662, 307);
            this.kryptonAlphaValueNumericBox2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.kryptonAlphaValueNumericBox2.Name = "kryptonAlphaValueNumericBox2";
            this.kryptonAlphaValueNumericBox2.Size = new System.Drawing.Size(77, 22);
            this.kryptonAlphaValueNumericBox2.TabIndex = 115;
            this.kryptonAlphaValueNumericBox2.Typeface = null;
            // 
            // kryptonGreenValueLabel2
            // 
            this.kryptonGreenValueLabel2.ExtraText = "Green Value";
            this.kryptonGreenValueLabel2.GreenValue = 0;
            this.kryptonGreenValueLabel2.Location = new System.Drawing.Point(549, 391);
            this.kryptonGreenValueLabel2.Name = "kryptonGreenValueLabel2";
            this.kryptonGreenValueLabel2.ShowColon = false;
            this.kryptonGreenValueLabel2.ShowCurrentColourValue = false;
            this.kryptonGreenValueLabel2.Size = new System.Drawing.Size(106, 21);
            this.kryptonGreenValueLabel2.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel2.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel2.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel2.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel2.TabIndex = 114;
            this.kryptonGreenValueLabel2.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel2.UseAccessibleUI = false;
            this.kryptonGreenValueLabel2.Values.Text = "Green Value:";
            // 
            // kryptonBlueValueLabel2
            // 
            this.kryptonBlueValueLabel2.BlueValue = 0;
            this.kryptonBlueValueLabel2.ExtraText = "Blue Value";
            this.kryptonBlueValueLabel2.Location = new System.Drawing.Point(561, 363);
            this.kryptonBlueValueLabel2.Name = "kryptonBlueValueLabel2";
            this.kryptonBlueValueLabel2.ShowColon = false;
            this.kryptonBlueValueLabel2.ShowCurrentColourValue = false;
            this.kryptonBlueValueLabel2.Size = new System.Drawing.Size(94, 21);
            this.kryptonBlueValueLabel2.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel2.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel2.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel2.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel2.TabIndex = 113;
            this.kryptonBlueValueLabel2.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel2.UseAccessibleUI = false;
            this.kryptonBlueValueLabel2.Values.Text = "Blue Value:";
            // 
            // kryptonRedValueLabel2
            // 
            this.kryptonRedValueLabel2.ExtraText = "Red Value";
            this.kryptonRedValueLabel2.Location = new System.Drawing.Point(564, 335);
            this.kryptonRedValueLabel2.Name = "kryptonRedValueLabel2";
            this.kryptonRedValueLabel2.RedValue = 0;
            this.kryptonRedValueLabel2.ShowColon = false;
            this.kryptonRedValueLabel2.ShowCurrentColourValue = false;
            this.kryptonRedValueLabel2.Size = new System.Drawing.Size(91, 21);
            this.kryptonRedValueLabel2.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel2.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel2.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel2.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel2.TabIndex = 112;
            this.kryptonRedValueLabel2.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel2.UseAccessibleUI = false;
            this.kryptonRedValueLabel2.Values.Text = "Red Value:";
            // 
            // kryptonAlphaValueLabel2
            // 
            this.kryptonAlphaValueLabel2.AlphaValue = 0;
            this.kryptonAlphaValueLabel2.ExtraText = "Alpha Value";
            this.kryptonAlphaValueLabel2.Location = new System.Drawing.Point(553, 307);
            this.kryptonAlphaValueLabel2.Name = "kryptonAlphaValueLabel2";
            this.kryptonAlphaValueLabel2.ShowColon = false;
            this.kryptonAlphaValueLabel2.ShowCurrentColourValue = false;
            this.kryptonAlphaValueLabel2.Size = new System.Drawing.Size(102, 21);
            this.kryptonAlphaValueLabel2.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonAlphaValueLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonAlphaValueLabel2.TabIndex = 111;
            this.kryptonAlphaValueLabel2.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonAlphaValueLabel2.Values.Text = "Alpha Value:";
            // 
            // ContrastColourControl
            // 
            this.Controls.Add(this.kryptonGreenValueNumericBox2);
            this.Controls.Add(this.kryptonBlueValueNumericBox2);
            this.Controls.Add(this.kryptonRedValueNumericBox2);
            this.Controls.Add(this.kryptonAlphaValueNumericBox2);
            this.Controls.Add(this.kryptonGreenValueLabel2);
            this.Controls.Add(this.kryptonBlueValueLabel2);
            this.Controls.Add(this.kryptonRedValueLabel2);
            this.Controls.Add(this.kryptonAlphaValueLabel2);
            this.Controls.Add(this.kryptonGreenValueNumericBox1);
            this.Controls.Add(this.kryptonBlueValueNumericBox1);
            this.Controls.Add(this.kryptonRedValueNumericBox1);
            this.Controls.Add(this.kryptonAlphaValueNumericBox1);
            this.Controls.Add(this.kryptonGreenValueLabel1);
            this.Controls.Add(this.kryptonBlueValueLabel1);
            this.Controls.Add(this.kryptonRedValueLabel1);
            this.Controls.Add(this.kryptonAlphaValueLabel1);
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
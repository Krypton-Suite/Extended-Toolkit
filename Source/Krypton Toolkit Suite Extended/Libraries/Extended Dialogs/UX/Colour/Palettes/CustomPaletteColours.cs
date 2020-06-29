namespace Krypton.Toolkit.Extended.Dialogs
{
    public class CustomPaletteColours : KryptonForm
    {
        private KryptonPanel kpnlButtons;
        private KryptonOKDialogButton kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel1;
        private KryptonListBox kryptonListBox1;
        private Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonBlueValueNumericBox knudBaseBlue;
        private Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonGreenValueNumericBox knudBaseGreen;
        private Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonRedValueNumericBox knudBaseRed;
        private System.Windows.Forms.PictureBox pbxColourPreview;
        private KryptonButton kryptonButton3;
        private KryptonButton kryptonButton2;
        private KryptonButton kryptonButton1;
        private Suite.Extended.Standard.Controls.KryptonComboBoxExtended kryptonComboBoxExtended2;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended kryptonLabelExtended2;
        private Suite.Extended.Standard.Controls.KryptonComboBoxExtended kryptonComboBoxExtended1;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended kryptonLabelExtended1;
        private Krypton.Toolkit.Suite.Extended.Drawing.Suite.ColourHexadecimalTextBox colourHexadecimalTextBox1;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended kryptonLabelExtended3;
        private KryptonButton kryptonButton5;
        private KryptonButton kryptonButton4;
        private Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonBlueValueLabel kryptonBlueValueLabel1;
        private Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonGreenValueLabel kryptonGreenValueLabel1;
        private Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonRedValueLabel kryptonRedValueLabel1;
        private KryptonCancelDialogButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kryptonButton5 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton4 = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.Extended.Dialogs.KryptonOKDialogButton();
            this.kbtnCancel = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.pbxColourPreview = new System.Windows.Forms.PictureBox();
            this.kryptonListBox1 = new Krypton.Toolkit.KryptonListBox();
            this.kryptonBlueValueLabel1 = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonBlueValueLabel();
            this.kryptonGreenValueLabel1 = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonGreenValueLabel();
            this.kryptonRedValueLabel1 = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonRedValueLabel();
            this.kryptonComboBoxExtended2 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonComboBoxExtended();
            this.kryptonLabelExtended2 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.kryptonComboBoxExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonComboBoxExtended();
            this.kryptonLabelExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.knudBaseBlue = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonBlueValueNumericBox();
            this.knudBaseGreen = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonGreenValueNumericBox();
            this.knudBaseRed = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.KryptonRedValueNumericBox();
            this.colourHexadecimalTextBox1 = new Krypton.Toolkit.Suite.Extended.Drawing.Suite.ColourHexadecimalTextBox();
            this.kryptonLabelExtended3 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxExtended2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxExtended1)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.colourHexadecimalTextBox1);
            this.kpnlButtons.Controls.Add(this.kryptonLabelExtended3);
            this.kpnlButtons.Controls.Add(this.kryptonButton5);
            this.kpnlButtons.Controls.Add(this.kryptonButton4);
            this.kpnlButtons.Controls.Add(this.kbtnOk);
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 243);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.Size = new System.Drawing.Size(887, 44);
            this.kpnlButtons.TabIndex = 2;
            // 
            // kryptonButton5
            // 
            this.kryptonButton5.AutoSize = true;
            this.kryptonButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton5.Location = new System.Drawing.Point(179, 8);
            this.kryptonButton5.Name = "kryptonButton5";
            this.kryptonButton5.Size = new System.Drawing.Size(163, 25);
            this.kryptonButton5.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton5.TabIndex = 159;
            this.kryptonButton5.Values.Text = "Utilise as Base &Colour";
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.AutoSize = true;
            this.kryptonButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButton4.Location = new System.Drawing.Point(12, 8);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(161, 25);
            this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton4.TabIndex = 158;
            this.kryptonButton4.Values.Text = "Save &Selected Colour";
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(689, 7);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 2;
            this.kbtnOk.Values.Text = "&OK";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(785, 7);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 3);
            this.panel1.TabIndex = 4;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBlueValueLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonGreenValueLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonRedValueLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonComboBoxExtended2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabelExtended2);
            this.kryptonPanel1.Controls.Add(this.kryptonComboBoxExtended1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabelExtended1);
            this.kryptonPanel1.Controls.Add(this.kryptonButton3);
            this.kryptonPanel1.Controls.Add(this.kryptonButton2);
            this.kryptonPanel1.Controls.Add(this.kryptonButton1);
            this.kryptonPanel1.Controls.Add(this.pbxColourPreview);
            this.kryptonPanel1.Controls.Add(this.kryptonListBox1);
            this.kryptonPanel1.Controls.Add(this.knudBaseBlue);
            this.kryptonPanel1.Controls.Add(this.knudBaseGreen);
            this.kryptonPanel1.Controls.Add(this.knudBaseRed);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(887, 240);
            this.kryptonPanel1.TabIndex = 5;
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.Location = new System.Drawing.Point(691, 206);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(124, 25);
            this.kryptonButton3.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton3.TabIndex = 159;
            this.kryptonButton3.Values.Text = "Generate &Blue";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(412, 206);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(139, 25);
            this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton2.TabIndex = 158;
            this.kryptonButton2.Values.Text = "Generate Gr&een";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(143, 206);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(116, 25);
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 157;
            this.kryptonButton1.Values.Text = "Generate &Red";
            // 
            // pbxColourPreview
            // 
            this.pbxColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.pbxColourPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxColourPreview.Location = new System.Drawing.Point(204, 13);
            this.pbxColourPreview.Name = "pbxColourPreview";
            this.pbxColourPreview.Size = new System.Drawing.Size(671, 112);
            this.pbxColourPreview.TabIndex = 156;
            this.pbxColourPreview.TabStop = false;
            // 
            // kryptonListBox1
            // 
            this.kryptonListBox1.Location = new System.Drawing.Point(13, 13);
            this.kryptonListBox1.Name = "kryptonListBox1";
            this.kryptonListBox1.Size = new System.Drawing.Size(185, 171);
            this.kryptonListBox1.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonListBox1.TabIndex = 24;
            // 
            // kryptonBlueValueLabel1
            // 
            this.kryptonBlueValueLabel1.BlueValue = 0;
            this.kryptonBlueValueLabel1.ExtraText = "Blue";
            this.kryptonBlueValueLabel1.Location = new System.Drawing.Point(557, 206);
            this.kryptonBlueValueLabel1.Name = "kryptonBlueValueLabel1";
            this.kryptonBlueValueLabel1.ShowColon = false;
            this.kryptonBlueValueLabel1.ShowCurrentColourValue = false;
            this.kryptonBlueValueLabel1.Size = new System.Drawing.Size(48, 21);
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonBlueValueLabel1.TabIndex = 166;
            this.kryptonBlueValueLabel1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonBlueValueLabel1.UseAccessibleUI = false;
            this.kryptonBlueValueLabel1.Values.Text = "Blue:";
            // 
            // kryptonGreenValueLabel1
            // 
            this.kryptonGreenValueLabel1.ExtraText = "Green";
            this.kryptonGreenValueLabel1.GreenValue = 0;
            this.kryptonGreenValueLabel1.Location = new System.Drawing.Point(265, 206);
            this.kryptonGreenValueLabel1.Name = "kryptonGreenValueLabel1";
            this.kryptonGreenValueLabel1.ShowColon = false;
            this.kryptonGreenValueLabel1.ShowCurrentColourValue = false;
            this.kryptonGreenValueLabel1.Size = new System.Drawing.Size(61, 21);
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGreenValueLabel1.TabIndex = 165;
            this.kryptonGreenValueLabel1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGreenValueLabel1.UseAccessibleUI = false;
            this.kryptonGreenValueLabel1.Values.Text = "Green:";
            // 
            // kryptonRedValueLabel1
            // 
            this.kryptonRedValueLabel1.ExtraText = "Red";
            this.kryptonRedValueLabel1.Location = new System.Drawing.Point(13, 206);
            this.kryptonRedValueLabel1.Name = "kryptonRedValueLabel1";
            this.kryptonRedValueLabel1.RedValue = 0;
            this.kryptonRedValueLabel1.ShowColon = false;
            this.kryptonRedValueLabel1.ShowCurrentColourValue = false;
            this.kryptonRedValueLabel1.Size = new System.Drawing.Size(45, 21);
            this.kryptonRedValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRedValueLabel1.TabIndex = 164;
            this.kryptonRedValueLabel1.Typeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRedValueLabel1.UseAccessibleUI = false;
            this.kryptonRedValueLabel1.Values.Text = "Red:";
            // 
            // kryptonComboBoxExtended2
            // 
            this.kryptonComboBoxExtended2.ComboBoxContentTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.ComboBoxItemContentLongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.ComboBoxItemContentShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kryptonComboBoxExtended2.DropDownWidth = 191;
            this.kryptonComboBoxExtended2.Image = null;
            this.kryptonComboBoxExtended2.IntegralHeight = false;
            this.kryptonComboBoxExtended2.Location = new System.Drawing.Point(684, 146);
            this.kryptonComboBoxExtended2.Name = "kryptonComboBoxExtended2";
            this.kryptonComboBoxExtended2.Size = new System.Drawing.Size(191, 22);
            this.kryptonComboBoxExtended2.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateActive.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonComboBoxExtended2.StateActiveComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateActiveComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateActiveComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateActiveComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonComboBoxExtended2.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateCommonComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxDropBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxDropBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateCommonComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateDisabled.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonComboBoxExtended2.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateDisabledComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateDisabledComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateNormal.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonComboBoxExtended2.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateNormalComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateNormalComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended2.StateTrackingComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateTrackingComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateTrackingComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateTrackingComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateTrackingComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.StateTrackingComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended2.TabIndex = 163;
            // 
            // kryptonLabelExtended2
            // 
            this.kryptonLabelExtended2.Image = null;
            this.kryptonLabelExtended2.Location = new System.Drawing.Point(549, 146);
            this.kryptonLabelExtended2.LongTextTypeface = null;
            this.kryptonLabelExtended2.Name = "kryptonLabelExtended2";
            this.kryptonLabelExtended2.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended2.Size = new System.Drawing.Size(129, 21);
            this.kryptonLabelExtended2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended2.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended2.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended2.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended2.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended2.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended2.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended2.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended2.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended2.TabIndex = 162;
            this.kryptonLabelExtended2.Values.Text = "System Colours:";
            // 
            // kryptonComboBoxExtended1
            // 
            this.kryptonComboBoxExtended1.ComboBoxContentTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.ComboBoxItemContentLongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.ComboBoxItemContentShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kryptonComboBoxExtended1.DropDownWidth = 191;
            this.kryptonComboBoxExtended1.Image = null;
            this.kryptonComboBoxExtended1.IntegralHeight = false;
            this.kryptonComboBoxExtended1.Location = new System.Drawing.Point(352, 146);
            this.kryptonComboBoxExtended1.Name = "kryptonComboBoxExtended1";
            this.kryptonComboBoxExtended1.Size = new System.Drawing.Size(191, 22);
            this.kryptonComboBoxExtended1.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateActive.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonComboBoxExtended1.StateActiveComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateActiveComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateActiveComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateActiveComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonComboBoxExtended1.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateCommonComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxDropBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxDropBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateCommonComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateDisabled.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonComboBoxExtended1.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateDisabledComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateDisabledComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateNormal.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kryptonComboBoxExtended1.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateNormalComboBoxBackColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxContentColour = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateNormalComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.StateTrackingComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateTrackingComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateTrackingComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateTrackingComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateTrackingComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.StateTrackingComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonComboBoxExtended1.TabIndex = 161;
            // 
            // kryptonLabelExtended1
            // 
            this.kryptonLabelExtended1.Image = null;
            this.kryptonLabelExtended1.Location = new System.Drawing.Point(205, 146);
            this.kryptonLabelExtended1.LongTextTypeface = null;
            this.kryptonLabelExtended1.Name = "kryptonLabelExtended1";
            this.kryptonLabelExtended1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.Size = new System.Drawing.Size(141, 21);
            this.kryptonLabelExtended1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended1.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended1.TabIndex = 160;
            this.kryptonLabelExtended1.Values.Text = "Standard Colours:";
            // 
            // knudBaseBlue
            // 
            this.knudBaseBlue.Location = new System.Drawing.Point(611, 206);
            this.knudBaseBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBaseBlue.Name = "knudBaseBlue";
            this.knudBaseBlue.Size = new System.Drawing.Size(74, 22);
            this.knudBaseBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knudBaseBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBaseBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBaseBlue.TabIndex = 23;
            this.knudBaseBlue.Typeface = null;
            this.knudBaseBlue.UseAccessibleUI = false;
            // 
            // knudBaseGreen
            // 
            this.knudBaseGreen.Location = new System.Drawing.Point(332, 206);
            this.knudBaseGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBaseGreen.Name = "knudBaseGreen";
            this.knudBaseGreen.Size = new System.Drawing.Size(74, 22);
            this.knudBaseGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudBaseGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBaseGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBaseGreen.TabIndex = 22;
            this.knudBaseGreen.Typeface = null;
            this.knudBaseGreen.UseAccessibleUI = false;
            // 
            // knudBaseRed
            // 
            this.knudBaseRed.Location = new System.Drawing.Point(63, 206);
            this.knudBaseRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBaseRed.Name = "knudBaseRed";
            this.knudBaseRed.Size = new System.Drawing.Size(74, 22);
            this.knudBaseRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudBaseRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBaseRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBaseRed.TabIndex = 21;
            this.knudBaseRed.Typeface = null;
            this.knudBaseRed.UseAccessibleUI = false;
            // 
            // colourHexadecimalTextBox1
            // 
            this.colourHexadecimalTextBox1.Colour = System.Drawing.Color.Empty;
            this.colourHexadecimalTextBox1.Hint = "000000";
            this.colourHexadecimalTextBox1.Location = new System.Drawing.Point(516, 9);
            this.colourHexadecimalTextBox1.MaxLength = 6;
            this.colourHexadecimalTextBox1.Name = "colourHexadecimalTextBox1";
            this.colourHexadecimalTextBox1.Size = new System.Drawing.Size(100, 24);
            this.colourHexadecimalTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colourHexadecimalTextBox1.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.colourHexadecimalTextBox1.TabIndex = 162;
            // 
            // kryptonLabelExtended3
            // 
            this.kryptonLabelExtended3.Image = null;
            this.kryptonLabelExtended3.Location = new System.Drawing.Point(348, 11);
            this.kryptonLabelExtended3.LongTextTypeface = null;
            this.kryptonLabelExtended3.Name = "kryptonLabelExtended3";
            this.kryptonLabelExtended3.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended3.Size = new System.Drawing.Size(161, 21);
            this.kryptonLabelExtended3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended3.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended3.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended3.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended3.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended3.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended3.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabelExtended3.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.kryptonLabelExtended3.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonLabelExtended3.TabIndex = 161;
            this.kryptonLabelExtended3.Values.Text = "Hexadecimal Colour:";
            // 
            // CustomPaletteColours
            // 
            this.ClientSize = new System.Drawing.Size(887, 287);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomPaletteColours";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Custom Palette Colours";
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxExtended2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxExtended1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
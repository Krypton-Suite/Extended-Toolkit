
namespace MessageBox
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnTestConfigurator = new Krypton.Toolkit.KryptonButton();
            this.kbtnTest = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kchkDefineTypeface = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonGroupBox3 = new Krypton.Toolkit.KryptonGroupBox();
            this.ktxtOptionalCheckBoxText = new Krypton.Toolkit.KryptonTextBox();
            this.kchkShowOptionalCheckBoxResult = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkIsOptionalCheckBoxChecked = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkShowOptionalCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.krbButtonsYesNoCancel = new Krypton.Toolkit.KryptonRadioButton();
            this.krbButtonsRetryCancel = new Krypton.Toolkit.KryptonRadioButton();
            this.krbButtonsYesNo = new Krypton.Toolkit.KryptonRadioButton();
            this.krbButtonsOkCancel = new Krypton.Toolkit.KryptonRadioButton();
            this.krbButtonsAbortRetryIgnore = new Krypton.Toolkit.KryptonRadioButton();
            this.krbButtonsOk = new Krypton.Toolkit.KryptonRadioButton();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.krbIconStop = new Krypton.Toolkit.KryptonRadioButton();
            this.krbIconHand = new Krypton.Toolkit.KryptonRadioButton();
            this.klblCustomIconPath = new Krypton.Toolkit.KryptonLabel();
            this.kbtnBrowseForCustomIcon = new Krypton.Toolkit.KryptonButton();
            this.krbIconCustom = new Krypton.Toolkit.KryptonRadioButton();
            this.krbIconQuestion = new Krypton.Toolkit.KryptonRadioButton();
            this.krbIconError = new Krypton.Toolkit.KryptonRadioButton();
            this.krbIconInformation = new Krypton.Toolkit.KryptonRadioButton();
            this.krbIconWarning = new Krypton.Toolkit.KryptonRadioButton();
            this.krbIconNone = new Krypton.Toolkit.KryptonRadioButton();
            this.ktxtMessage = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtCaption = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonMessageBoxConfigurator1 = new Krypton.Toolkit.Suite.Extended.Messagebox.KryptonMessageBoxConfigurator();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).BeginInit();
            this.kryptonGroupBox3.Panel.SuspendLayout();
            this.kryptonGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnTestConfigurator);
            this.kryptonPanel1.Controls.Add(this.kbtnTest);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 583);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(519, 39);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnTestConfigurator
            // 
            this.kbtnTestConfigurator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnTestConfigurator.Location = new System.Drawing.Point(349, 7);
            this.kbtnTestConfigurator.Name = "kbtnTestConfigurator";
            this.kbtnTestConfigurator.Size = new System.Drawing.Size(77, 22);
            this.kbtnTestConfigurator.TabIndex = 2;
            this.kbtnTestConfigurator.Values.Text = "&Test";
            this.kbtnTestConfigurator.Click += new System.EventHandler(this.kbtnTestConfigurator_Click);
            // 
            // kbtnTest
            // 
            this.kbtnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnTest.Location = new System.Drawing.Point(432, 7);
            this.kbtnTest.Name = "kbtnTest";
            this.kbtnTest.Size = new System.Drawing.Size(77, 22);
            this.kbtnTest.TabIndex = 1;
            this.kbtnTest.Values.Text = "&Test";
            this.kbtnTest.Click += new System.EventHandler(this.kbtnTest_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 580);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kchkDefineTypeface);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox3);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Controls.Add(this.ktxtMessage);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.ktxtCaption);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(519, 580);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kchkDefineTypeface
            // 
            this.kchkDefineTypeface.Location = new System.Drawing.Point(77, 539);
            this.kchkDefineTypeface.Name = "kchkDefineTypeface";
            this.kchkDefineTypeface.Size = new System.Drawing.Size(111, 20);
            this.kchkDefineTypeface.TabIndex = 7;
            this.kchkDefineTypeface.Values.Text = "Define &Typeface";
            // 
            // kryptonGroupBox3
            // 
            this.kryptonGroupBox3.Location = new System.Drawing.Point(77, 409);
            this.kryptonGroupBox3.Name = "kryptonGroupBox3";
            // 
            // kryptonGroupBox3.Panel
            // 
            this.kryptonGroupBox3.Panel.Controls.Add(this.ktxtOptionalCheckBoxText);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kchkShowOptionalCheckBoxResult);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kchkIsOptionalCheckBoxChecked);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kchkShowOptionalCheckBox);
            this.kryptonGroupBox3.Size = new System.Drawing.Size(434, 123);
            this.kryptonGroupBox3.TabIndex = 6;
            this.kryptonGroupBox3.Values.Heading = "Checkbox";
            // 
            // ktxtOptionalCheckBoxText
            // 
            this.ktxtOptionalCheckBoxText.Enabled = false;
            this.ktxtOptionalCheckBoxText.Hint = "Enter text here...";
            this.ktxtOptionalCheckBoxText.Location = new System.Drawing.Point(10, 66);
            this.ktxtOptionalCheckBoxText.Name = "ktxtOptionalCheckBoxText";
            this.ktxtOptionalCheckBoxText.Size = new System.Drawing.Size(414, 23);
            this.ktxtOptionalCheckBoxText.TabIndex = 3;
            // 
            // kchkShowOptionalCheckBoxResult
            // 
            this.kchkShowOptionalCheckBoxResult.Enabled = false;
            this.kchkShowOptionalCheckBoxResult.Location = new System.Drawing.Point(10, 39);
            this.kchkShowOptionalCheckBoxResult.Name = "kchkShowOptionalCheckBoxResult";
            this.kchkShowOptionalCheckBoxResult.Size = new System.Drawing.Size(197, 20);
            this.kchkShowOptionalCheckBoxResult.TabIndex = 2;
            this.kchkShowOptionalCheckBoxResult.Values.Text = "Show Optional CheckBox Res&ult";
            // 
            // kchkIsOptionalCheckBoxChecked
            // 
            this.kchkIsOptionalCheckBoxChecked.Enabled = false;
            this.kchkIsOptionalCheckBoxChecked.Location = new System.Drawing.Point(177, 12);
            this.kchkIsOptionalCheckBoxChecked.Name = "kchkIsOptionalCheckBoxChecked";
            this.kchkIsOptionalCheckBoxChecked.Size = new System.Drawing.Size(189, 20);
            this.kchkIsOptionalCheckBoxChecked.TabIndex = 1;
            this.kchkIsOptionalCheckBoxChecked.Values.Text = "I&s Optional CheckBox Checked";
            // 
            // kchkShowOptionalCheckBox
            // 
            this.kchkShowOptionalCheckBox.Location = new System.Drawing.Point(10, 12);
            this.kchkShowOptionalCheckBox.Name = "kchkShowOptionalCheckBox";
            this.kchkShowOptionalCheckBox.Size = new System.Drawing.Size(160, 20);
            this.kchkShowOptionalCheckBox.TabIndex = 0;
            this.kchkShowOptionalCheckBox.Values.Text = "Show &Optional CheckBox";
            this.kchkShowOptionalCheckBox.CheckedChanged += new System.EventHandler(this.kchkShowOptionalCheckBox_CheckedChanged);
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(77, 303);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.krbButtonsYesNoCancel);
            this.kryptonGroupBox2.Panel.Controls.Add(this.krbButtonsRetryCancel);
            this.kryptonGroupBox2.Panel.Controls.Add(this.krbButtonsYesNo);
            this.kryptonGroupBox2.Panel.Controls.Add(this.krbButtonsOkCancel);
            this.kryptonGroupBox2.Panel.Controls.Add(this.krbButtonsAbortRetryIgnore);
            this.kryptonGroupBox2.Panel.Controls.Add(this.krbButtonsOk);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(434, 99);
            this.kryptonGroupBox2.TabIndex = 5;
            this.kryptonGroupBox2.Values.Heading = "Buttons";
            // 
            // krbButtonsYesNoCancel
            // 
            this.krbButtonsYesNoCancel.Location = new System.Drawing.Point(10, 39);
            this.krbButtonsYesNoCancel.Name = "krbButtonsYesNoCancel";
            this.krbButtonsYesNoCancel.Size = new System.Drawing.Size(100, 20);
            this.krbButtonsYesNoCancel.TabIndex = 9;
            this.krbButtonsYesNoCancel.Values.Text = "&Yes No Cancel";
            // 
            // krbButtonsRetryCancel
            // 
            this.krbButtonsRetryCancel.Location = new System.Drawing.Point(334, 13);
            this.krbButtonsRetryCancel.Name = "krbButtonsRetryCancel";
            this.krbButtonsRetryCancel.Size = new System.Drawing.Size(90, 20);
            this.krbButtonsRetryCancel.TabIndex = 8;
            this.krbButtonsRetryCancel.Values.Text = "&Retry Cancel";
            // 
            // krbButtonsYesNo
            // 
            this.krbButtonsYesNo.Location = new System.Drawing.Point(267, 13);
            this.krbButtonsYesNo.Name = "krbButtonsYesNo";
            this.krbButtonsYesNo.Size = new System.Drawing.Size(61, 20);
            this.krbButtonsYesNo.TabIndex = 7;
            this.krbButtonsYesNo.Values.Text = "Ye&s No";
            // 
            // krbButtonsOkCancel
            // 
            this.krbButtonsOkCancel.Location = new System.Drawing.Point(184, 13);
            this.krbButtonsOkCancel.Name = "krbButtonsOkCancel";
            this.krbButtonsOkCancel.Size = new System.Drawing.Size(77, 20);
            this.krbButtonsOkCancel.TabIndex = 6;
            this.krbButtonsOkCancel.Values.Text = "Ok &Cancel";
            // 
            // krbButtonsAbortRetryIgnore
            // 
            this.krbButtonsAbortRetryIgnore.Location = new System.Drawing.Point(54, 13);
            this.krbButtonsAbortRetryIgnore.Name = "krbButtonsAbortRetryIgnore";
            this.krbButtonsAbortRetryIgnore.Size = new System.Drawing.Size(124, 20);
            this.krbButtonsAbortRetryIgnore.TabIndex = 1;
            this.krbButtonsAbortRetryIgnore.Values.Text = "&Abort Retry Ignore";
            // 
            // krbButtonsOk
            // 
            this.krbButtonsOk.Location = new System.Drawing.Point(10, 13);
            this.krbButtonsOk.Name = "krbButtonsOk";
            this.krbButtonsOk.Size = new System.Drawing.Size(38, 20);
            this.krbButtonsOk.TabIndex = 0;
            this.krbButtonsOk.Values.Text = "O&k";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(77, 171);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.krbIconStop);
            this.kryptonGroupBox1.Panel.Controls.Add(this.krbIconHand);
            this.kryptonGroupBox1.Panel.Controls.Add(this.klblCustomIconPath);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kbtnBrowseForCustomIcon);
            this.kryptonGroupBox1.Panel.Controls.Add(this.krbIconCustom);
            this.kryptonGroupBox1.Panel.Controls.Add(this.krbIconQuestion);
            this.kryptonGroupBox1.Panel.Controls.Add(this.krbIconError);
            this.kryptonGroupBox1.Panel.Controls.Add(this.krbIconInformation);
            this.kryptonGroupBox1.Panel.Controls.Add(this.krbIconWarning);
            this.kryptonGroupBox1.Panel.Controls.Add(this.krbIconNone);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(434, 126);
            this.kryptonGroupBox1.TabIndex = 4;
            this.kryptonGroupBox1.Values.Heading = "Icon";
            // 
            // krbIconStop
            // 
            this.krbIconStop.Location = new System.Drawing.Point(68, 34);
            this.krbIconStop.Name = "krbIconStop";
            this.krbIconStop.Size = new System.Drawing.Size(48, 20);
            this.krbIconStop.TabIndex = 9;
            this.krbIconStop.Values.Text = "St&op";
            // 
            // krbIconHand
            // 
            this.krbIconHand.Location = new System.Drawing.Point(10, 34);
            this.krbIconHand.Name = "krbIconHand";
            this.krbIconHand.Size = new System.Drawing.Size(52, 20);
            this.krbIconHand.TabIndex = 8;
            this.krbIconHand.Values.Text = "H&and";
            // 
            // klblCustomIconPath
            // 
            this.klblCustomIconPath.Enabled = false;
            this.klblCustomIconPath.Location = new System.Drawing.Point(10, 66);
            this.klblCustomIconPath.Name = "klblCustomIconPath";
            this.klblCustomIconPath.Size = new System.Drawing.Size(6, 2);
            this.klblCustomIconPath.TabIndex = 7;
            this.klblCustomIconPath.Values.Text = "";
            // 
            // kbtnBrowseForCustomIcon
            // 
            this.kbtnBrowseForCustomIcon.Enabled = false;
            this.kbtnBrowseForCustomIcon.Location = new System.Drawing.Point(213, 34);
            this.kbtnBrowseForCustomIcon.Name = "kbtnBrowseForCustomIcon";
            this.kbtnBrowseForCustomIcon.Size = new System.Drawing.Size(150, 25);
            this.kbtnBrowseForCustomIcon.TabIndex = 6;
            this.kbtnBrowseForCustomIcon.Values.Text = "&Browse for Icon";
            this.kbtnBrowseForCustomIcon.Click += new System.EventHandler(this.kbtnBrowseForCustomIcon_Click);
            // 
            // krbIconCustom
            // 
            this.krbIconCustom.Location = new System.Drawing.Point(143, 34);
            this.krbIconCustom.Name = "krbIconCustom";
            this.krbIconCustom.Size = new System.Drawing.Size(64, 20);
            this.krbIconCustom.TabIndex = 5;
            this.krbIconCustom.Values.Text = "C&ustom";
            this.krbIconCustom.CheckedChanged += new System.EventHandler(this.krbIconCustom_CheckedChanged);
            // 
            // krbIconQuestion
            // 
            this.krbIconQuestion.Location = new System.Drawing.Point(291, 8);
            this.krbIconQuestion.Name = "krbIconQuestion";
            this.krbIconQuestion.Size = new System.Drawing.Size(72, 20);
            this.krbIconQuestion.TabIndex = 4;
            this.krbIconQuestion.Values.Text = "Q&uestion";
            // 
            // krbIconError
            // 
            this.krbIconError.Location = new System.Drawing.Point(236, 8);
            this.krbIconError.Name = "krbIconError";
            this.krbIconError.Size = new System.Drawing.Size(49, 20);
            this.krbIconError.TabIndex = 3;
            this.krbIconError.Values.Text = "&Error";
            // 
            // krbIconInformation
            // 
            this.krbIconInformation.Location = new System.Drawing.Point(143, 8);
            this.krbIconInformation.Name = "krbIconInformation";
            this.krbIconInformation.Size = new System.Drawing.Size(87, 20);
            this.krbIconInformation.TabIndex = 2;
            this.krbIconInformation.Values.Text = "In&formation";
            // 
            // krbIconWarning
            // 
            this.krbIconWarning.Location = new System.Drawing.Point(68, 8);
            this.krbIconWarning.Name = "krbIconWarning";
            this.krbIconWarning.Size = new System.Drawing.Size(69, 20);
            this.krbIconWarning.TabIndex = 1;
            this.krbIconWarning.Values.Text = "Wa&rning";
            // 
            // krbIconNone
            // 
            this.krbIconNone.Location = new System.Drawing.Point(10, 8);
            this.krbIconNone.Name = "krbIconNone";
            this.krbIconNone.Size = new System.Drawing.Size(52, 20);
            this.krbIconNone.TabIndex = 0;
            this.krbIconNone.Values.Text = "&None";
            // 
            // ktxtMessage
            // 
            this.ktxtMessage.Hint = "This is a message!";
            this.ktxtMessage.Location = new System.Drawing.Point(77, 41);
            this.ktxtMessage.Multiline = true;
            this.ktxtMessage.Name = "ktxtMessage";
            this.ktxtMessage.Size = new System.Drawing.Size(434, 124);
            this.ktxtMessage.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(10, 41);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Message:";
            // 
            // ktxtCaption
            // 
            this.ktxtCaption.Hint = "Enter a caption here...";
            this.ktxtCaption.Location = new System.Drawing.Point(77, 10);
            this.ktxtCaption.Name = "ktxtCaption";
            this.ktxtCaption.Size = new System.Drawing.Size(434, 23);
            this.ktxtCaption.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(10, 10);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Caption:";
            // 
            // kryptonMessageBoxConfigurator1
            // 
            this.kryptonMessageBoxConfigurator1.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.kryptonMessageBoxConfigurator1.MessageBoxContentText = "kryptonMessageBoxConfigurator1";
            this.kryptonMessageBoxConfigurator1.MessageBoxDefaultButton = System.Windows.Forms.MessageBoxDefaultButton.Button1;
            this.kryptonMessageBoxConfigurator1.MessageBoxIcon = Krypton.Toolkit.Suite.Extended.Messagebox.ExtendedMessageBoxIcon.CUSTOM;
            this.kryptonMessageBoxConfigurator1.OptionalCheckBoxAnchor = System.Windows.Forms.AnchorStyles.Left;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 622);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).EndInit();
            this.kryptonGroupBox3.Panel.ResumeLayout(false);
            this.kryptonGroupBox3.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).EndInit();
            this.kryptonGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnTest;
        private System.Windows.Forms.Panel panel1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonTextBox ktxtMessage;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonTextBox ktxtCaption;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonRadioButton krbButtonsOk;
        private Krypton.Toolkit.KryptonLabel klblCustomIconPath;
        private Krypton.Toolkit.KryptonButton kbtnBrowseForCustomIcon;
        private Krypton.Toolkit.KryptonRadioButton krbIconCustom;
        private Krypton.Toolkit.KryptonRadioButton krbIconQuestion;
        private Krypton.Toolkit.KryptonRadioButton krbIconError;
        private Krypton.Toolkit.KryptonRadioButton krbIconInformation;
        private Krypton.Toolkit.KryptonRadioButton krbIconWarning;
        private Krypton.Toolkit.KryptonRadioButton krbIconNone;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox3;
        private Krypton.Toolkit.KryptonCheckBox kchkShowOptionalCheckBoxResult;
        private Krypton.Toolkit.KryptonCheckBox kchkIsOptionalCheckBoxChecked;
        private Krypton.Toolkit.KryptonCheckBox kchkShowOptionalCheckBox;
        private Krypton.Toolkit.KryptonRadioButton krbButtonsYesNoCancel;
        private Krypton.Toolkit.KryptonRadioButton krbButtonsRetryCancel;
        private Krypton.Toolkit.KryptonRadioButton krbButtonsYesNo;
        private Krypton.Toolkit.KryptonRadioButton krbButtonsOkCancel;
        private Krypton.Toolkit.KryptonRadioButton krbButtonsAbortRetryIgnore;
        private Krypton.Toolkit.KryptonCheckBox kchkDefineTypeface;
        private Krypton.Toolkit.KryptonTextBox ktxtOptionalCheckBoxText;
        private Krypton.Toolkit.KryptonRadioButton krbIconHand;
        private Krypton.Toolkit.KryptonRadioButton krbIconStop;
        private Krypton.Toolkit.KryptonButton kbtnTestConfigurator;
        private Krypton.Toolkit.Suite.Extended.Messagebox.KryptonMessageBoxConfigurator kryptonMessageBoxConfigurator1;
    }
}


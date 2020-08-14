using Krypton.Toolkit.Suite.Extended.Dialogs;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    public class CustomFormatRule : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonOKDialogButton kbtnOk;
        private KryptonCancelDialogButton kbtnCancel;
        private System.Windows.Forms.Panel panel1;
        private KryptonComboBox kcmbeFormat;
        private KryptonLabel klblFormat;
        private System.Windows.Forms.PictureBox pbxPreview;
        private KryptonLabel klblPreview;
        private KryptonColorButton kcoleMax;
        private KryptonColorButton kcoleMed;
        private KryptonColorButton kcoleMin;
        private KryptonComboBox kcmbeFill;
        private KryptonLabel klblFill;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new KryptonOKDialogButton();
            this.kbtnCancel = new KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kcmbeFill = new Krypton.Toolkit.KryptonComboBox();
            this.klblFill = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.kcoleMax = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonColourButtonExtended();
            this.kcoleMed = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonColourButtonExtended();
            this.kcoleMin = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonColourButtonExtended();
            this.pbxPreview = new System.Windows.Forms.PictureBox();
            this.klblPreview = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.kcmbeFormat = new Krypton.Toolkit.KryptonComboBox();
            this.klblFormat = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbeFill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbeFormat)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 213);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(622, 48);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(424, 11);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Image = global::Krypton.Toolkit.Suite.Extended.Outlook.Grid.Properties.Resources.Ok_16_x_16;
            this.kbtnOk.Values.Text = "&OK";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(520, 11);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Image = global::Krypton.Toolkit.Suite.Extended.Outlook.Grid.Properties.Resources.Critical_16_x_16;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kcmbeFill);
            this.kryptonPanel2.Controls.Add(this.klblFill);
            this.kryptonPanel2.Controls.Add(this.kcoleMax);
            this.kryptonPanel2.Controls.Add(this.kcoleMed);
            this.kryptonPanel2.Controls.Add(this.kcoleMin);
            this.kryptonPanel2.Controls.Add(this.pbxPreview);
            this.kryptonPanel2.Controls.Add(this.klblPreview);
            this.kryptonPanel2.Controls.Add(this.kcmbeFormat);
            this.kryptonPanel2.Controls.Add(this.klblFormat);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(622, 210);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kcmbeFill
            // 
            this.kcmbeFill.IntegralHeight = false;
            this.kcmbeFill.Location = new System.Drawing.Point(91, 166);
            this.kcmbeFill.Name = "kcmbeFill";
            this.kcmbeFill.Size = new System.Drawing.Size(519, 22);
            this.kcmbeFill.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFill.StateActive.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeFill.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFill.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbeFill.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFill.StateDisabled.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeFill.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFill.StateNormal.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeFill.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.TabIndex = 10;
            this.kcmbeFill.SelectedIndexChanged += new System.EventHandler(this.kcmbeFill_SelectedIndexChanged);
            // 
            // klblFill
            // 
            this.klblFill.Location = new System.Drawing.Point(12, 167);
            this.klblFill.Name = "klblFill";
            this.klblFill.Size = new System.Drawing.Size(37, 21);
            this.klblFill.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFill.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFill.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFill.TabIndex = 9;
            this.klblFill.Values.Text = "Fill:";
            // 
            // kcoleMax
            // 
            this.kcoleMax.Location = new System.Drawing.Point(280, 94);
            this.kcoleMax.Name = "kcoleMax";
            this.kcoleMax.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.SelectedColor = System.Drawing.Color.Empty;
            this.kcoleMax.Size = new System.Drawing.Size(128, 25);
            this.kcoleMax.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.TabIndex = 7;
            this.kcoleMax.Values.Text = "M&aximum Colour";
            this.kcoleMax.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcoleMax_SelectedColorChanged);
            // 
            // kcoleMed
            // 
            this.kcoleMed.Location = new System.Drawing.Point(146, 94);
            this.kcoleMed.Name = "kcoleMed";
            this.kcoleMed.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.SelectedColor = System.Drawing.Color.Empty;
            this.kcoleMed.Size = new System.Drawing.Size(128, 25);
            this.kcoleMed.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.TabIndex = 8;
            this.kcoleMed.Values.Text = "Med&ium Colour";
            this.kcoleMed.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcoleMed_SelectedColorChanged);
            // 
            // kcoleMin
            // 
            this.kcoleMin.Location = new System.Drawing.Point(12, 94);
            this.kcoleMin.Name = "kcoleMin";
            this.kcoleMin.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.SelectedColor = System.Drawing.Color.Empty;
            this.kcoleMin.Size = new System.Drawing.Size(128, 25);
            this.kcoleMin.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.TabIndex = 6;
            this.kcoleMin.Values.Text = "Mini&mum Colour";
            this.kcoleMin.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcoleMin_SelectedColorChanged);
            // 
            // pbxPreview
            // 
            this.pbxPreview.BackColor = System.Drawing.Color.Transparent;
            this.pbxPreview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbxPreview.Location = new System.Drawing.Point(91, 39);
            this.pbxPreview.Name = "pbxPreview";
            this.pbxPreview.Size = new System.Drawing.Size(519, 21);
            this.pbxPreview.TabIndex = 5;
            this.pbxPreview.TabStop = false;
            this.pbxPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxPreview_Paint);
            // 
            // klblPreview
            // 
            this.klblPreview.Location = new System.Drawing.Point(12, 39);
            this.klblPreview.Name = "klblPreview";
            this.klblPreview.Size = new System.Drawing.Size(73, 21);
            this.klblPreview.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblPreview.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblPreview.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblPreview.TabIndex = 2;
            this.klblPreview.Values.Text = "Preview:";
            // 
            // kcmbeFormat
            // 
            this.kcmbeFormat.DropDownWidth = 519;
            this.kcmbeFormat.IntegralHeight = false;
            this.kcmbeFormat.Location = new System.Drawing.Point(91, 11);
            this.kcmbeFormat.Name = "kcmbeFormat";
            this.kcmbeFormat.Size = new System.Drawing.Size(519, 22);
            this.kcmbeFormat.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFormat.StateActive.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeFormat.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFormat.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbeFormat.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFormat.StateDisabled.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeFormat.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFormat.StateNormal.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeFormat.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.TabIndex = 1;
            this.kcmbeFormat.SelectedIndexChanged += new System.EventHandler(this.kcmbeFormat_SelectedIndexChanged);
            // 
            // klblFormat
            // 
            this.klblFormat.Location = new System.Drawing.Point(12, 12);
            this.klblFormat.Name = "klblFormat";
            this.klblFormat.Size = new System.Drawing.Size(67, 21);
            this.klblFormat.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFormat.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFormat.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFormat.TabIndex = 0;
            this.klblFormat.Values.Text = "Format:";
            // 
            // CustomFormatRule
            // 
            this.AcceptButton = this.kbtnOk;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(622, 261);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomFormatRule";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Custom Rule";
            this.Load += new System.EventHandler(this.CustomFormatRule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbeFill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbeFormat)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        /// <summary>
        /// Gradient boolean
        /// </summary>
        public bool gradient;

        /// <summary>
        /// The colours
        /// </summary>
        public Color colMin, colMedium, colMax;

        /// <summary>
        /// The Conditional Formatting type
        /// </summary>
        public EnumConditionalFormatType mode;
        #endregion

        #region Properties
        [DefaultValue(null)]
        public Color MinimumColour { get => colMin; set => colMin = value; }

        [DefaultValue(null)]
        public Color MediumColour { get => colMedium; set => colMedium = value; }

        [DefaultValue(null)]
        public Color MaximumColour { get => colMax; set => colMax = value; }

        public EnumConditionalFormatType Mode { get => mode; set => mode = value; }
        #endregion

        #region Constructors
        public CustomFormatRule(EnumConditionalFormatType initialmode)
        {
            InitializeComponent();

            kcmbeFill.SelectedIndex = 0;

            kcmbeFormat.SelectedIndex = -1;

            mode = initialmode;

            colMin = Color.FromArgb(84, 179, 112);

            colMedium = Color.FromArgb(252, 229, 130);

            colMax = Color.FromArgb(243, 120, 97);
        }
        #endregion

        #region Event Handlers
        private void CustomFormatRule_Load(object sender, EventArgs e)
        {
            kcoleMin.SelectedColor = colMin;

            kcoleMed.SelectedColor = colMedium;

            kcoleMax.SelectedColor = colMax;

            int selectedIndex = -1;

            string[] names = Enum.GetNames(typeof(EnumConditionalFormatType));

            for (int i = 0; i < names.Length; i++)
            {
                if (mode.ToString().Equals(names[i]))
                {
                    selectedIndex = i;
                }

                kcmbeFormat.Items.Add(new KryptonListItem(LanguageManager.Instance.GetStringGB(names[i])) { Tag = names[i] });
            }

            kcmbeFormat.SelectedIndex = selectedIndex;
        }

        private void kcoleMed_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            colMedium = e.Color;

            pbxPreview.Invalidate();
        }

        private void kcoleMax_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            colMax = e.Color;

            pbxPreview.Invalidate();
        }

        private void kcmbeFill_SelectedIndexChanged(object sender, EventArgs e)
        {
            gradient = kcmbeFill.SelectedIndex == 1;

            UpdateUI();
        }

        private void kcmbeFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = (EnumConditionalFormatType)Enum.Parse(typeof(EnumConditionalFormatType), ((KryptonListItem)kcmbeFill.Items[kcmbeFill.SelectedIndex]).Tag.ToString());

            UpdateUI();
        }

        private void pbxPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            switch (mode)
            {
                case EnumConditionalFormatType.TWOCOLOURSRANGE:
                    // Draw the background gradient.
                    using (LinearGradientBrush lgbr = new LinearGradientBrush(e.ClipRectangle, colMin, colMax, LinearGradientMode.Horizontal))
                    {
                        e.Graphics.FillRectangle(lgbr, e.ClipRectangle);
                    }
                    break;
                case EnumConditionalFormatType.THREECOLOURSRANGE:
                    // Draw the background gradient.
                    using (LinearGradientBrush lgbr = new LinearGradientBrush(e.ClipRectangle, colMin, colMax, LinearGradientMode.Horizontal))
                    {
                        ColorBlend colourBlend = new ColorBlend();

                        colourBlend.Colors = new Color[] { colMin, colMedium, colMax };

                        colourBlend.Positions = new float[] { 0f, 0.5f, 1.0f };

                        lgbr.InterpolationColors = colourBlend;

                        e.Graphics.FillRectangle(lgbr, e.ClipRectangle);
                    }
                    break;
                case EnumConditionalFormatType.BAR:
                    if (gradient)
                    {
                        using (LinearGradientBrush lgbr = new LinearGradientBrush(e.ClipRectangle, colMin, Color.White, LinearGradientMode.Horizontal))
                        {
                            e.Graphics.FillRectangle(lgbr, e.ClipRectangle);
                        }
                    }
                    else
                    {
                        using (SolidBrush sbr = new SolidBrush(colMin))
                        {
                            e.Graphics.FillRectangle(sbr, e.ClipRectangle);
                        }
                    }
                    using (Pen pen = new Pen(colMin)) //Color.FromArgb(255, 140, 197, 66)))
                    {
                        Rectangle rect = e.ClipRectangle;
                        rect.Inflate(-1, -1);
                        e.Graphics.DrawRectangle(pen, rect);
                    }
                    break;
                default:
                    break;
            }
        }

        private void kcoleMin_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            colMin = e.Color;

            pbxPreview.Invalidate();
        }
        #endregion

        #region Methods
        private void UpdateUI()
        {
            switch (mode)
            {
                case EnumConditionalFormatType.TWOCOLOURSRANGE:
                    klblFill.Enabled = true;

                    kcmbeFill.Enabled = true;

                    kcoleMin.Enabled = true;

                    kcoleMed.Enabled = false;

                    kcoleMax.Enabled = true;
                    break;
                case EnumConditionalFormatType.THREECOLOURSRANGE:
                    klblFill.Enabled = false;

                    kcmbeFill.Enabled = false;

                    kcoleMin.Enabled = true;

                    kcoleMed.Enabled = true;

                    kcoleMax.Enabled = true;
                    break;
                case EnumConditionalFormatType.BAR:
                    klblFill.Enabled = true;

                    kcmbeFill.Enabled = true;

                    kcmbeFormat.Enabled = true;

                    kcoleMin.Enabled = true;

                    kcoleMed.Enabled = false;

                    kcoleMax.Enabled = false;
                    break;
                default:
                    break;
            }

            pbxPreview.Invalidate();
        }
        #endregion
    }
}
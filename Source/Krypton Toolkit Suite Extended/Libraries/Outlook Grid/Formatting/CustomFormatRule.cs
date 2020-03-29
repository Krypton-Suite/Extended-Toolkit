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
        private Toolkit.Extended.Base.KryptonOKDialogButton kbtnOk;
        private Toolkit.Extended.Base.KryptonCancelDialogButton kbtnCancel;
        private System.Windows.Forms.Panel panel1;
        private Standard.Controls.KryptonComboBoxExtended kcmbeFormat;
        private Standard.Controls.KryptonLabelExtended klblFormat;
        private System.Windows.Forms.PictureBox pbxPreview;
        private Standard.Controls.KryptonLabelExtended klblPreview;
        private Standard.Controls.KryptonColourButtonExtended kcoleMax;
        private Standard.Controls.KryptonColourButtonExtended kcoleMed;
        private Standard.Controls.KryptonColourButtonExtended kcoleMin;
        private Standard.Controls.KryptonComboBoxExtended kcmbeFill;
        private Standard.Controls.KryptonLabelExtended klblFill;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.Extended.Base.KryptonOKDialogButton();
            this.kbtnCancel = new Krypton.Toolkit.Extended.Base.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kcmbeFill = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonComboBoxExtended();
            this.klblFill = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.kcoleMax = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonColourButtonExtended();
            this.kcoleMed = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonColourButtonExtended();
            this.kcoleMin = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonColourButtonExtended();
            this.pbxPreview = new System.Windows.Forms.PictureBox();
            this.klblPreview = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.kcmbeFormat = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonComboBoxExtended();
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
            this.kcmbeFill.ComboBoxContentTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFill.ComboBoxItemContentLongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.ComboBoxItemContentShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.DropDownWidth = 519;
            this.kcmbeFill.Image = null;
            this.kcmbeFill.IntegralHeight = false;
            this.kcmbeFill.Location = new System.Drawing.Point(91, 166);
            this.kcmbeFill.Name = "kcmbeFill";
            this.kcmbeFill.Size = new System.Drawing.Size(519, 22);
            this.kcmbeFill.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFill.StateActive.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeFill.StateActiveComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeFill.StateActiveComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateActiveComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateActiveComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeFill.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFill.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbeFill.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateCommonComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeFill.StateCommonComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateCommonComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateCommonComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeFill.StateCommonComboBoxDropBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateCommonComboBoxDropBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateCommonComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateCommonComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateCommonComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateCommonComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateCommonComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateCommonComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFill.StateDisabled.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeFill.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateDisabledComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeFill.StateDisabledComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateDisabledComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateDisabledComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeFill.StateDisabledComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateDisabledComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateDisabledComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateDisabledComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateDisabledComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateDisabledComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFill.StateNormal.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeFill.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateNormalComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeFill.StateNormalComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateNormalComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateNormalComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeFill.StateNormalComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateNormalComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateNormalComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateNormalComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateNormalComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateNormalComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFill.StateTrackingComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateTrackingComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateTrackingComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateTrackingComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.StateTrackingComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFill.StateTrackingComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFill.TabIndex = 10;
            this.kcmbeFill.SelectedIndexChanged += new System.EventHandler(this.kcmbeFill_SelectedIndexChanged);
            // 
            // klblFill
            // 
            this.klblFill.Image = null;
            this.klblFill.Location = new System.Drawing.Point(12, 167);
            this.klblFill.LongTextTypeface = null;
            this.klblFill.Name = "klblFill";
            this.klblFill.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFill.Size = new System.Drawing.Size(37, 21);
            this.klblFill.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFill.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblFill.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblFill.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFill.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblFill.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblFill.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFill.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblFill.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblFill.TabIndex = 9;
            this.klblFill.Values.Text = "Fill:";
            // 
            // kcoleMax
            // 
            this.kcoleMax.Image = null;
            this.kcoleMax.Location = new System.Drawing.Point(280, 94);
            this.kcoleMax.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.Name = "kcoleMax";
            this.kcoleMax.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.SelectedColor = System.Drawing.Color.Empty;
            this.kcoleMax.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.Size = new System.Drawing.Size(128, 25);
            this.kcoleMax.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMax.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMax.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMax.TabIndex = 7;
            this.kcoleMax.Values.Text = "M&aximum Colour";
            this.kcoleMax.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcoleMax_SelectedColorChanged);
            // 
            // kcoleMed
            // 
            this.kcoleMed.Image = null;
            this.kcoleMed.Location = new System.Drawing.Point(146, 94);
            this.kcoleMed.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.Name = "kcoleMed";
            this.kcoleMed.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.SelectedColor = System.Drawing.Color.Empty;
            this.kcoleMed.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.Size = new System.Drawing.Size(128, 25);
            this.kcoleMed.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMed.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMed.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMed.TabIndex = 8;
            this.kcoleMed.Values.Text = "Med&ium Colour";
            this.kcoleMed.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcoleMed_SelectedColorChanged);
            // 
            // kcoleMin
            // 
            this.kcoleMin.Image = null;
            this.kcoleMin.Location = new System.Drawing.Point(12, 94);
            this.kcoleMin.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.Name = "kcoleMin";
            this.kcoleMin.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.SelectedColor = System.Drawing.Color.Empty;
            this.kcoleMin.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.Size = new System.Drawing.Size(128, 25);
            this.kcoleMin.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcoleMin.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcoleMin.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kcoleMin.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
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
            this.klblPreview.Image = null;
            this.klblPreview.Location = new System.Drawing.Point(12, 39);
            this.klblPreview.LongTextTypeface = null;
            this.klblPreview.Name = "klblPreview";
            this.klblPreview.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblPreview.Size = new System.Drawing.Size(73, 21);
            this.klblPreview.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblPreview.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblPreview.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblPreview.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblPreview.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblPreview.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblPreview.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblPreview.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblPreview.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblPreview.TabIndex = 2;
            this.klblPreview.Values.Text = "Preview:";
            // 
            // kcmbeFormat
            // 
            this.kcmbeFormat.ComboBoxContentTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFormat.ComboBoxItemContentLongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.ComboBoxItemContentShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.DropDownWidth = 519;
            this.kcmbeFormat.Image = null;
            this.kcmbeFormat.IntegralHeight = false;
            this.kcmbeFormat.Location = new System.Drawing.Point(91, 11);
            this.kcmbeFormat.Name = "kcmbeFormat";
            this.kcmbeFormat.Size = new System.Drawing.Size(519, 22);
            this.kcmbeFormat.StateActive.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFormat.StateActive.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeFormat.StateActiveComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateActiveComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateActiveComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateActiveComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFormat.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbeFormat.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateCommonComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateCommonComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateCommonComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateCommonComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateCommonComboBoxDropBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateCommonComboBoxDropBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateCommonComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateCommonComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateCommonComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateCommonComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateCommonComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateCommonComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateDisabled.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFormat.StateDisabled.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeFormat.StateDisabled.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateDisabled.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateDisabledComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateDisabledComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateDisabledComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateDisabledComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateDisabledComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateDisabledComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateDisabledComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateDisabledComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateDisabledComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateDisabledComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateNormal.ComboBox.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.kcmbeFormat.StateNormal.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.kcmbeFormat.StateNormal.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateNormal.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateNormalComboBoxBackColour = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateNormalComboBoxBorderColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateNormalComboBoxBorderColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateNormalComboBoxContentColour = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateNormalComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateNormalComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateNormalComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateNormalComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateNormalComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateNormalComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateTracking.Item.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateTracking.Item.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbeFormat.StateTrackingComboBoxItemBackColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateTrackingComboBoxItemBackColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateTrackingComboBoxItemContentLongTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateTrackingComboBoxItemContentLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateTrackingComboBoxItemContentShortTextColourOne = System.Drawing.Color.Empty;
            this.kcmbeFormat.StateTrackingComboBoxItemContentShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcmbeFormat.TabIndex = 1;
            this.kcmbeFormat.SelectedIndexChanged += new System.EventHandler(this.kcmbeFormat_SelectedIndexChanged);
            // 
            // klblFormat
            // 
            this.klblFormat.Image = null;
            this.klblFormat.Location = new System.Drawing.Point(12, 12);
            this.klblFormat.LongTextTypeface = null;
            this.klblFormat.Name = "klblFormat";
            this.klblFormat.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFormat.Size = new System.Drawing.Size(67, 21);
            this.klblFormat.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFormat.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblFormat.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblFormat.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFormat.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblFormat.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblFormat.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFormat.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblFormat.StateNormalTextColourTwo = System.Drawing.Color.Empty;
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
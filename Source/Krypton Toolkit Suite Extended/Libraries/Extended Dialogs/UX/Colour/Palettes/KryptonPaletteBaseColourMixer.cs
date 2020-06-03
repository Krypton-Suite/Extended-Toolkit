using Krypton.Toolkit.Suite.Extended.Colour.Controls;
using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    [DefaultEvent("BasicPaletteColoursChanged")]
    public class KryptonPaletteBaseColourMixer : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kpnlButtons;
        private Colour.Controls.ColourHexadecimalTextBox colourHexadecimalTextBox1;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended kryptonLabelExtended3;
        private KryptonOKDialogButton kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel1;
        private Suite.Extended.Standard.Controls.KryptonGroupBoxExtended kryptonGroupBoxExtended1;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended4;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended3;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended2;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended1;
        private Suite.Extended.Standard.Controls.KryptonGroupBoxExtended kryptonGroupBoxExtended2;
        private Suite.Extended.Standard.Controls.KryptonComboBoxExtended kryptonComboBoxExtended1;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended5;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended6;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended7;
        private Suite.Extended.Base.KryptonARGBColourSliderVertical kargbColour;
        private Suite.Extended.Base.BasicPaletteColourUserControl basicPaletteColourUserControl1;
        private KryptonCancelDialogButton kbtnCancel;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonPaletteBaseColourMixer));
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.colourHexadecimalTextBox1 = new Krypton.Toolkit.Extended.Colour.Controls.ColourHexadecimalTextBox();
            this.kryptonLabelExtended3 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.kbtnOk = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonOKDialogButton();
            this.kbtnCancel = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kargbColour = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonARGBColourSliderVertical();
            this.kryptonGroupBoxExtended2 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonGroupBoxExtended();
            this.kryptonComboBoxExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonComboBoxExtended();
            this.kryptonButtonExtended5 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kryptonButtonExtended6 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kryptonButtonExtended7 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kryptonGroupBoxExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonGroupBoxExtended();
            this.kryptonButtonExtended4 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kryptonButtonExtended3 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kryptonButtonExtended2 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kryptonButtonExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.basicPaletteColourUserControl1 = new Krypton.Toolkit.Extended.Palette.Controls.BasicPaletteColourUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended2.Panel)).BeginInit();
            this.kryptonGroupBoxExtended2.Panel.SuspendLayout();
            this.kryptonGroupBoxExtended2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxExtended1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended1.Panel)).BeginInit();
            this.kryptonGroupBoxExtended1.Panel.SuspendLayout();
            this.kryptonGroupBoxExtended1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.colourHexadecimalTextBox1);
            this.kpnlButtons.Controls.Add(this.kryptonLabelExtended3);
            this.kpnlButtons.Controls.Add(this.kbtnOk);
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 549);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.Size = new System.Drawing.Size(759, 44);
            this.kpnlButtons.TabIndex = 3;
            // 
            // colourHexadecimalTextBox1
            // 
            this.colourHexadecimalTextBox1.Colour = System.Drawing.Color.Empty;
            this.colourHexadecimalTextBox1.Hint = "000000";
            this.colourHexadecimalTextBox1.Location = new System.Drawing.Point(180, 9);
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
            this.kryptonLabelExtended3.Location = new System.Drawing.Point(12, 11);
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
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Image = null;
            this.kbtnOk.Location = new System.Drawing.Point(561, 7);
            this.kbtnOk.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.TabIndex = 2;
            this.kbtnOk.Values.Text = "&OK";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Image = null;
            this.kbtnCancel.Location = new System.Drawing.Point(657, 7);
            this.kbtnCancel.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 546);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 3);
            this.panel1.TabIndex = 5;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.basicPaletteColourUserControl1);
            this.kryptonPanel1.Controls.Add(this.kargbColour);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBoxExtended2);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBoxExtended1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(759, 546);
            this.kryptonPanel1.TabIndex = 6;
            // 
            // kargbColour
            // 
            this.kargbColour.BackColor = System.Drawing.Color.Transparent;
            this.kargbColour.Colour = System.Drawing.Color.Empty;
            this.kargbColour.ColourHexadecimalValue = null;
            this.kargbColour.Location = new System.Drawing.Point(155, 21);
            this.kargbColour.Name = "kargbColour";
            this.kargbColour.Size = new System.Drawing.Size(341, 491);
            this.kargbColour.TabIndex = 7;
            this.kargbColour.ColourChanged += new Krypton.Toolkit.Extended.Colour.Controls.KryptonARGBColourSliderVertical.ColourChangedEventHandler(this.kargbColour_ColourChanged);
            this.kargbColour.ColourHexadecimalValuesChanged += new Krypton.Toolkit.Extended.Colour.Controls.KryptonARGBColourSliderVertical.ColourHexadecimalValuesChangedEventHandler(this.kargbColour_ColourHexadecimalValuesChanged);
            // 
            // kryptonGroupBoxExtended2
            // 
            this.kryptonGroupBoxExtended2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonGroupBoxExtended2.Image = null;
            this.kryptonGroupBoxExtended2.Location = new System.Drawing.Point(518, 271);
            this.kryptonGroupBoxExtended2.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonGroupBoxExtended2.Name = "kryptonGroupBoxExtended2";
            // 
            // kryptonGroupBoxExtended2.Panel
            // 
            this.kryptonGroupBoxExtended2.Panel.Controls.Add(this.kryptonComboBoxExtended1);
            this.kryptonGroupBoxExtended2.Panel.Controls.Add(this.kryptonButtonExtended5);
            this.kryptonGroupBoxExtended2.Panel.Controls.Add(this.kryptonButtonExtended6);
            this.kryptonGroupBoxExtended2.Panel.Controls.Add(this.kryptonButtonExtended7);
            this.kryptonGroupBoxExtended2.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBoxExtended2.Size = new System.Drawing.Size(229, 185);
            this.kryptonGroupBoxExtended2.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonGroupBoxExtended2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBoxExtended2.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended2.TabIndex = 179;
            this.kryptonGroupBoxExtended2.Values.Heading = "Define Colour";
            // 
            // kryptonComboBoxExtended1
            // 
            this.kryptonComboBoxExtended1.ComboBoxContentTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.ComboBoxItemContentLongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.ComboBoxItemContentShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonComboBoxExtended1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kryptonComboBoxExtended1.DropDownWidth = 188;
            this.kryptonComboBoxExtended1.Image = null;
            this.kryptonComboBoxExtended1.IntegralHeight = false;
            this.kryptonComboBoxExtended1.Items.AddRange(new object[] {
            "Base Colour",
            "Darkest Colour",
            "Dark Colour",
            "Middle Colour",
            "Light Colour",
            "Lightest Colour"});
            this.kryptonComboBoxExtended1.Location = new System.Drawing.Point(19, 12);
            this.kryptonComboBoxExtended1.Name = "kryptonComboBoxExtended1";
            this.kryptonComboBoxExtended1.Size = new System.Drawing.Size(188, 22);
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
            this.kryptonComboBoxExtended1.TabIndex = 4;
            // 
            // kryptonButtonExtended5
            // 
            this.kryptonButtonExtended5.Image = null;
            this.kryptonButtonExtended5.Location = new System.Drawing.Point(19, 120);
            this.kryptonButtonExtended5.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended5.Name = "kryptonButtonExtended5";
            this.kryptonButtonExtended5.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended5.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended5.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended5.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended5.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended5.Size = new System.Drawing.Size(188, 25);
            this.kryptonButtonExtended5.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended5.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended5.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended5.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended5.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended5.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended5.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended5.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended5.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended5.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended5.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended5.TabIndex = 3;
            this.kryptonButtonExtended5.Values.Text = "&More Colour Options";
            // 
            // kryptonButtonExtended6
            // 
            this.kryptonButtonExtended6.Image = null;
            this.kryptonButtonExtended6.Location = new System.Drawing.Point(19, 83);
            this.kryptonButtonExtended6.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended6.Name = "kryptonButtonExtended6";
            this.kryptonButtonExtended6.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended6.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended6.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended6.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended6.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended6.Size = new System.Drawing.Size(188, 25);
            this.kryptonButtonExtended6.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended6.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended6.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended6.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended6.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended6.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended6.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended6.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended6.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended6.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended6.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended6.TabIndex = 2;
            this.kryptonButtonExtended6.Values.Text = "&Export Selected Colour";
            // 
            // kryptonButtonExtended7
            // 
            this.kryptonButtonExtended7.Image = null;
            this.kryptonButtonExtended7.Location = new System.Drawing.Point(19, 46);
            this.kryptonButtonExtended7.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended7.Name = "kryptonButtonExtended7";
            this.kryptonButtonExtended7.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended7.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended7.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended7.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended7.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended7.Size = new System.Drawing.Size(188, 25);
            this.kryptonButtonExtended7.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended7.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended7.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended7.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended7.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended7.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended7.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended7.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended7.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended7.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended7.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended7.TabIndex = 1;
            this.kryptonButtonExtended7.Values.Text = "&Change Selected Colour";
            // 
            // kryptonGroupBoxExtended1
            // 
            this.kryptonGroupBoxExtended1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonGroupBoxExtended1.Image = null;
            this.kryptonGroupBoxExtended1.Location = new System.Drawing.Point(518, 43);
            this.kryptonGroupBoxExtended1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonGroupBoxExtended1.Name = "kryptonGroupBoxExtended1";
            // 
            // kryptonGroupBoxExtended1.Panel
            // 
            this.kryptonGroupBoxExtended1.Panel.Controls.Add(this.kryptonButtonExtended4);
            this.kryptonGroupBoxExtended1.Panel.Controls.Add(this.kryptonButtonExtended3);
            this.kryptonGroupBoxExtended1.Panel.Controls.Add(this.kryptonButtonExtended2);
            this.kryptonGroupBoxExtended1.Panel.Controls.Add(this.kryptonButtonExtended1);
            this.kryptonGroupBoxExtended1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBoxExtended1.Size = new System.Drawing.Size(229, 185);
            this.kryptonGroupBoxExtended1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonGroupBoxExtended1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBoxExtended1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonGroupBoxExtended1.TabIndex = 178;
            this.kryptonGroupBoxExtended1.Values.Heading = "Colour Options";
            // 
            // kryptonButtonExtended4
            // 
            this.kryptonButtonExtended4.Image = null;
            this.kryptonButtonExtended4.Location = new System.Drawing.Point(19, 120);
            this.kryptonButtonExtended4.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended4.Name = "kryptonButtonExtended4";
            this.kryptonButtonExtended4.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended4.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended4.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended4.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended4.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended4.Size = new System.Drawing.Size(188, 25);
            this.kryptonButtonExtended4.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended4.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended4.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended4.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended4.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended4.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended4.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended4.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended4.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended4.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended4.TabIndex = 3;
            this.kryptonButtonExtended4.Values.Text = "Generate Bl&ue Value";
            // 
            // kryptonButtonExtended3
            // 
            this.kryptonButtonExtended3.Image = null;
            this.kryptonButtonExtended3.Location = new System.Drawing.Point(19, 86);
            this.kryptonButtonExtended3.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended3.Name = "kryptonButtonExtended3";
            this.kryptonButtonExtended3.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended3.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended3.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended3.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended3.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended3.Size = new System.Drawing.Size(188, 25);
            this.kryptonButtonExtended3.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended3.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended3.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended3.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended3.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended3.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended3.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended3.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended3.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended3.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended3.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended3.TabIndex = 2;
            this.kryptonButtonExtended3.Values.Text = "Generate Gree&n Value";
            // 
            // kryptonButtonExtended2
            // 
            this.kryptonButtonExtended2.Image = null;
            this.kryptonButtonExtended2.Location = new System.Drawing.Point(19, 52);
            this.kryptonButtonExtended2.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.Name = "kryptonButtonExtended2";
            this.kryptonButtonExtended2.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended2.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended2.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended2.Size = new System.Drawing.Size(188, 25);
            this.kryptonButtonExtended2.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended2.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended2.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended2.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended2.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended2.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended2.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended2.TabIndex = 1;
            this.kryptonButtonExtended2.Values.Text = "Generate R&ed Value";
            // 
            // kryptonButtonExtended1
            // 
            this.kryptonButtonExtended1.Image = null;
            this.kryptonButtonExtended1.Location = new System.Drawing.Point(19, 18);
            this.kryptonButtonExtended1.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.Name = "kryptonButtonExtended1";
            this.kryptonButtonExtended1.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended1.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended1.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended1.Size = new System.Drawing.Size(188, 25);
            this.kryptonButtonExtended1.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended1.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended1.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended1.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended1.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kryptonButtonExtended1.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButtonExtended1.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kryptonButtonExtended1.TabIndex = 0;
            this.kryptonButtonExtended1.Values.Text = "Generate &Alpha Value";
            // 
            // basicPaletteColourUserControl1
            // 
            this.basicPaletteColourUserControl1.AutomaticallyUpdateColourValues = false;
            this.basicPaletteColourUserControl1.BackColor = System.Drawing.Color.Transparent;
            this.basicPaletteColourUserControl1.BaseColour = System.Drawing.Color.Empty;
            this.basicPaletteColourUserControl1.BasicPaletteColours = new System.Drawing.Color[] {
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty,
        System.Drawing.Color.Empty};
            this.basicPaletteColourUserControl1.DarkColour = System.Drawing.Color.Empty;
            this.basicPaletteColourUserControl1.DarkestColour = System.Drawing.Color.Empty;
            this.basicPaletteColourUserControl1.DefaultColour = System.Drawing.Color.Empty;
            this.basicPaletteColourUserControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.basicPaletteColourUserControl1.LightColour = System.Drawing.Color.Empty;
            this.basicPaletteColourUserControl1.LightestColour = System.Drawing.Color.Empty;
            this.basicPaletteColourUserControl1.Location = new System.Drawing.Point(0, 0);
            this.basicPaletteColourUserControl1.MediumColour = System.Drawing.Color.Empty;
            this.basicPaletteColourUserControl1.Name = "basicPaletteColourUserControl1";
            this.basicPaletteColourUserControl1.Size = new System.Drawing.Size(149, 546);
            this.basicPaletteColourUserControl1.TabIndex = 7;
            // 
            // KryptonPaletteBaseColourMixer
            // 
            this.ClientSize = new System.Drawing.Size(759, 593);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonPaletteBaseColourMixer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Base Palette Colours";
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended2.Panel)).EndInit();
            this.kryptonGroupBoxExtended2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended2)).EndInit();
            this.kryptonGroupBoxExtended2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxExtended1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended1.Panel)).EndInit();
            this.kryptonGroupBoxExtended1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBoxExtended1)).EndInit();
            this.kryptonGroupBoxExtended1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private BasicPaletteColours _basicPaletteColour;

        private Color _baseColour, _darkestColour, _middleColour, _lightColour, _lightestColour;

        private int _alphaValue, _redValue, _greenValue, _blueValue;
        #endregion

        #region Events
        public delegate void BasicPaletteColoursChangedHandler(object sender, BasicPaletteColoursEventArgs e);

        public delegate void BaseColourChangedHandler(object sender, ColourChangedEventArgs e);

        public delegate void DarkestColourChangedHandler(object sender, ColourChangedEventArgs e);

        public delegate void MiddleColourChangedHandler(object sender, ColourChangedEventArgs e);

        public delegate void LightColourChangedHandler(object sender, ColourChangedEventArgs e);

        public delegate void LightestColourChangedHandler(object sender, ColourChangedEventArgs e);


        public event BasicPaletteColoursChangedHandler BasicPaletteColoursChanged;

        public event BaseColourChangedHandler BaseColourChanged;

        public event DarkestColourChangedHandler DarkestColourChanged;

        public event MiddleColourChangedHandler MiddleColourChanged;

        public event LightColourChangedHandler LightColourChanged;

        public event LightestColourChangedHandler LightestColourChanged;

        protected virtual void OnBasicPaletteColoursChanged(object sender, BasicPaletteColoursEventArgs e) => BasicPaletteColoursChanged?.Invoke(sender, e);

        protected virtual void OnBaseColourChanged(object sender, ColourChangedEventArgs e) => BaseColourChanged?.Invoke(sender, e);

        protected virtual void OnDarkestColourChanged(object sender, ColourChangedEventArgs e) => DarkestColourChanged?.Invoke(sender, e);

        protected virtual void OnMiddleColourChanged(object sender, ColourChangedEventArgs e) => MiddleColourChanged?.Invoke(sender, e);
        #endregion

        #region Constructor
        public KryptonPaletteBaseColourMixer()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        private void kcsColour_ColourHexadecimalValuesChanged(object sender, ColourHexadecimalValuesEventArgs e)
        {
            //kcsColour.Colour = e.TranslateHexadecimalToColour(kcsColour.ColourHexadecimalValue);
        }

        private void kargbColour_ColourChanged(object sender, ColourChangedEventArgs e)
        {

        }

        private void kargbColour_ColourHexadecimalValuesChanged(object sender, ColourHexadecimalValuesEventArgs e)
        {
            kargbColour.Colour = e.TranslateHexadecimalToColour(kargbColour.ColourHexadecimalValue);
        }
        #endregion
    }
}
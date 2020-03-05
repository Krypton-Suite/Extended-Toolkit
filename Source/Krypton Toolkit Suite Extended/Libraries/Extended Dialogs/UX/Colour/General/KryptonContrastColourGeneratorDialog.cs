using Krypton.Toolkit.Extended.Core;
using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonContrastColourGeneratorDialog : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kpnlButtons;
        private Suite.Extended.Standard.Controls.KryptonCheckBoxExtended kcbAutomateColourContrastValues;
        private KryptonOKDialogButton kbtnOk;
        private Suite.Extended.Standard.Controls.KryptonCheckBoxExtended kcbKeepOpacityValues;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel1;
        private Base.CircularPictureBox cpbContrastColourPreview;
        private Base.CircularPictureBox cpbBaseColour;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klblBaseColour;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klblContrastColour;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended2;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kryptonButtonExtended1;
        private Colour.Controls.KryptonAlphaValueNumericBox knudBaseAlpha;
        private Colour.Controls.KryptonBlueValueLabel klblBaseBlue;
        private Colour.Controls.KryptonGreenValueLabel klblBaseGreen;
        private Colour.Controls.KryptonRedValueLabel klblBaseRed;
        private Colour.Controls.KryptonAlphaValueLabel klblBaseAlpha;
        private Colour.Controls.KryptonRedValueNumericBox knudBaseRed;
        private Colour.Controls.KryptonGreenValueNumericBox knudBaseGreen;
        private Colour.Controls.KryptonBlueValueNumericBox knudBaseBlue;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnGenerateBlueBaseColourValue;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnGenerateGreenColourValue;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnGenerateRedBaseColourValue;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnGenerateAlphaBaseColourValue;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnGenerateBlueContrastColourValue;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnGenerateGreenContrastColourValue;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnGenerateRedContrastColourValue;
        private Suite.Extended.Standard.Controls.KryptonButtonExtended kbtnGenerateAlphaContrastColourValue;
        private Colour.Controls.KryptonBlueValueNumericBox knudContrastColourBlue;
        private Colour.Controls.KryptonGreenValueNumericBox knudContrastColourGreen;
        private Colour.Controls.KryptonRedValueNumericBox knudContrastColourRed;
        private Colour.Controls.KryptonAlphaValueNumericBox knudContrastColourAlpha;
        private Colour.Controls.KryptonBlueValueLabel klblContrastColourBlue;
        private Colour.Controls.KryptonGreenValueLabel klblContrastColourGreen;
        private Colour.Controls.KryptonRedValueLabel klblContrastColourRed;
        private Colour.Controls.KryptonAlphaValueLabel klblContrastColourAlpha;
        private KryptonCancelDialogButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kcbKeepOpacityValues = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonCheckBoxExtended();
            this.kcbAutomateColourContrastValues = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonCheckBoxExtended();
            this.kbtnOk = new Krypton.Toolkit.Extended.Dialogs.KryptonOKDialogButton();
            this.kbtnCancel = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnGenerateBlueContrastColourValue = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnGenerateGreenContrastColourValue = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnGenerateRedContrastColourValue = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnGenerateAlphaContrastColourValue = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.knudContrastColourBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueNumericBox();
            this.knudContrastColourGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueNumericBox();
            this.knudContrastColourRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueNumericBox();
            this.knudContrastColourAlpha = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaValueNumericBox();
            this.klblContrastColourBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.klblContrastColourGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.klblContrastColourRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueLabel();
            this.klblContrastColourAlpha = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.kbtnGenerateBlueBaseColourValue = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnGenerateGreenColourValue = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnGenerateRedBaseColourValue = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kbtnGenerateAlphaBaseColourValue = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.knudBaseBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueNumericBox();
            this.knudBaseGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueNumericBox();
            this.knudBaseRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueNumericBox();
            this.knudBaseAlpha = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaValueNumericBox();
            this.klblBaseBlue = new Krypton.Toolkit.Extended.Colour.Controls.KryptonBlueValueLabel();
            this.klblBaseGreen = new Krypton.Toolkit.Extended.Colour.Controls.KryptonGreenValueLabel();
            this.klblBaseRed = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRedValueLabel();
            this.klblBaseAlpha = new Krypton.Toolkit.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.kryptonButtonExtended2 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.kryptonButtonExtended1 = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonButtonExtended();
            this.klblContrastColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.cpbContrastColourPreview = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.cpbBaseColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.klblBaseColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbContrastColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColour)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.kcbKeepOpacityValues);
            this.kpnlButtons.Controls.Add(this.kcbAutomateColourContrastValues);
            this.kpnlButtons.Controls.Add(this.kbtnOk);
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 382);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.Size = new System.Drawing.Size(578, 44);
            this.kpnlButtons.TabIndex = 1;
            // 
            // kcbKeepOpacityValues
            // 
            this.kcbKeepOpacityValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kcbKeepOpacityValues.Image = null;
            this.kcbKeepOpacityValues.Location = new System.Drawing.Point(210, 14);
            this.kcbKeepOpacityValues.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbKeepOpacityValues.Name = "kcbKeepOpacityValues";
            this.kcbKeepOpacityValues.OverrideFocus.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbKeepOpacityValues.OverrideFocus.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbKeepOpacityValues.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbKeepOpacityValues.Size = new System.Drawing.Size(129, 16);
            this.kcbKeepOpacityValues.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbKeepOpacityValues.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbKeepOpacityValues.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.StateDisabled.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbKeepOpacityValues.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbKeepOpacityValues.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.StateNormal.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbKeepOpacityValues.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbKeepOpacityValues.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcbKeepOpacityValues.TabIndex = 3;
            this.kcbKeepOpacityValues.Values.Text = "Keep &Opacity Values";
            // 
            // kcbAutomateColourContrastValues
            // 
            this.kcbAutomateColourContrastValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kcbAutomateColourContrastValues.Image = null;
            this.kcbAutomateColourContrastValues.Location = new System.Drawing.Point(12, 14);
            this.kcbAutomateColourContrastValues.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbAutomateColourContrastValues.Name = "kcbAutomateColourContrastValues";
            this.kcbAutomateColourContrastValues.OverrideFocus.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbAutomateColourContrastValues.OverrideFocus.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbAutomateColourContrastValues.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbAutomateColourContrastValues.Size = new System.Drawing.Size(192, 16);
            this.kcbAutomateColourContrastValues.StateCommon.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbAutomateColourContrastValues.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbAutomateColourContrastValues.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.StateDisabled.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbAutomateColourContrastValues.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbAutomateColourContrastValues.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.StateNormal.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbAutomateColourContrastValues.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kcbAutomateColourContrastValues.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kcbAutomateColourContrastValues.TabIndex = 2;
            this.kcbAutomateColourContrastValues.Values.Text = "&Automate Colour Contrast Values";
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Image = null;
            this.kbtnOk.Location = new System.Drawing.Point(380, 7);
            this.kbtnOk.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            this.kbtnCancel.Location = new System.Drawing.Point(476, 7);
            this.kbtnCancel.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
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
            this.panel1.Location = new System.Drawing.Point(0, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 3);
            this.panel1.TabIndex = 3;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateBlueContrastColourValue);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateGreenContrastColourValue);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateRedContrastColourValue);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateAlphaContrastColourValue);
            this.kryptonPanel1.Controls.Add(this.knudContrastColourBlue);
            this.kryptonPanel1.Controls.Add(this.knudContrastColourGreen);
            this.kryptonPanel1.Controls.Add(this.knudContrastColourRed);
            this.kryptonPanel1.Controls.Add(this.knudContrastColourAlpha);
            this.kryptonPanel1.Controls.Add(this.klblContrastColourBlue);
            this.kryptonPanel1.Controls.Add(this.klblContrastColourGreen);
            this.kryptonPanel1.Controls.Add(this.klblContrastColourRed);
            this.kryptonPanel1.Controls.Add(this.klblContrastColourAlpha);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateBlueBaseColourValue);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateGreenColourValue);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateRedBaseColourValue);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateAlphaBaseColourValue);
            this.kryptonPanel1.Controls.Add(this.knudBaseBlue);
            this.kryptonPanel1.Controls.Add(this.knudBaseGreen);
            this.kryptonPanel1.Controls.Add(this.knudBaseRed);
            this.kryptonPanel1.Controls.Add(this.knudBaseAlpha);
            this.kryptonPanel1.Controls.Add(this.klblBaseBlue);
            this.kryptonPanel1.Controls.Add(this.klblBaseGreen);
            this.kryptonPanel1.Controls.Add(this.klblBaseRed);
            this.kryptonPanel1.Controls.Add(this.klblBaseAlpha);
            this.kryptonPanel1.Controls.Add(this.kryptonButtonExtended2);
            this.kryptonPanel1.Controls.Add(this.kryptonButtonExtended1);
            this.kryptonPanel1.Controls.Add(this.klblContrastColour);
            this.kryptonPanel1.Controls.Add(this.cpbContrastColourPreview);
            this.kryptonPanel1.Controls.Add(this.cpbBaseColour);
            this.kryptonPanel1.Controls.Add(this.klblBaseColour);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(578, 379);
            this.kryptonPanel1.TabIndex = 4;
            // 
            // kbtnGenerateBlueContrastColourValue
            // 
            this.kbtnGenerateBlueContrastColourValue.AutoSize = true;
            this.kbtnGenerateBlueContrastColourValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateBlueContrastColourValue.Image = null;
            this.kbtnGenerateBlueContrastColourValue.Location = new System.Drawing.Point(527, 336);
            this.kbtnGenerateBlueContrastColourValue.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueContrastColourValue.Name = "kbtnGenerateBlueContrastColourValue";
            this.kbtnGenerateBlueContrastColourValue.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueContrastColourValue.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueContrastColourValue.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueContrastColourValue.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueContrastColourValue.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueContrastColourValue.Size = new System.Drawing.Size(155, 25);
            this.kbtnGenerateBlueContrastColourValue.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueContrastColourValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueContrastColourValue.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueContrastColourValue.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueContrastColourValue.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueContrastColourValue.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueContrastColourValue.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueContrastColourValue.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueContrastColourValue.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueContrastColourValue.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueContrastColourValue.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueContrastColourValue.TabIndex = 33;
            this.kbtnGenerateBlueContrastColourValue.Values.Text = "Generate &Blue Value";
            // 
            // kbtnGenerateGreenContrastColourValue
            // 
            this.kbtnGenerateGreenContrastColourValue.AutoSize = true;
            this.kbtnGenerateGreenContrastColourValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateGreenContrastColourValue.Image = null;
            this.kbtnGenerateGreenContrastColourValue.Location = new System.Drawing.Point(527, 293);
            this.kbtnGenerateGreenContrastColourValue.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenContrastColourValue.Name = "kbtnGenerateGreenContrastColourValue";
            this.kbtnGenerateGreenContrastColourValue.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenContrastColourValue.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenContrastColourValue.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenContrastColourValue.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenContrastColourValue.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenContrastColourValue.Size = new System.Drawing.Size(167, 25);
            this.kbtnGenerateGreenContrastColourValue.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenContrastColourValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenContrastColourValue.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenContrastColourValue.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenContrastColourValue.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenContrastColourValue.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenContrastColourValue.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenContrastColourValue.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenContrastColourValue.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenContrastColourValue.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenContrastColourValue.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenContrastColourValue.TabIndex = 32;
            this.kbtnGenerateGreenContrastColourValue.Values.Text = "Generate G&reen Value";
            // 
            // kbtnGenerateRedContrastColourValue
            // 
            this.kbtnGenerateRedContrastColourValue.AutoSize = true;
            this.kbtnGenerateRedContrastColourValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateRedContrastColourValue.Image = null;
            this.kbtnGenerateRedContrastColourValue.Location = new System.Drawing.Point(527, 250);
            this.kbtnGenerateRedContrastColourValue.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedContrastColourValue.Name = "kbtnGenerateRedContrastColourValue";
            this.kbtnGenerateRedContrastColourValue.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedContrastColourValue.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedContrastColourValue.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedContrastColourValue.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedContrastColourValue.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedContrastColourValue.Size = new System.Drawing.Size(152, 25);
            this.kbtnGenerateRedContrastColourValue.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedContrastColourValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedContrastColourValue.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedContrastColourValue.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedContrastColourValue.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedContrastColourValue.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedContrastColourValue.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedContrastColourValue.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedContrastColourValue.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedContrastColourValue.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedContrastColourValue.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedContrastColourValue.TabIndex = 31;
            this.kbtnGenerateRedContrastColourValue.Values.Text = "Generate &Red Value";
            // 
            // kbtnGenerateAlphaContrastColourValue
            // 
            this.kbtnGenerateAlphaContrastColourValue.AutoSize = true;
            this.kbtnGenerateAlphaContrastColourValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateAlphaContrastColourValue.Image = null;
            this.kbtnGenerateAlphaContrastColourValue.Location = new System.Drawing.Point(527, 209);
            this.kbtnGenerateAlphaContrastColourValue.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaContrastColourValue.Name = "kbtnGenerateAlphaContrastColourValue";
            this.kbtnGenerateAlphaContrastColourValue.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaContrastColourValue.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaContrastColourValue.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaContrastColourValue.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaContrastColourValue.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaContrastColourValue.Size = new System.Drawing.Size(163, 25);
            this.kbtnGenerateAlphaContrastColourValue.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaContrastColourValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaContrastColourValue.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaContrastColourValue.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaContrastColourValue.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaContrastColourValue.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaContrastColourValue.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaContrastColourValue.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaContrastColourValue.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaContrastColourValue.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaContrastColourValue.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaContrastColourValue.TabIndex = 30;
            this.kbtnGenerateAlphaContrastColourValue.Values.Text = "Generate &Alpha Value";
            // 
            // knudContrastColourBlue
            // 
            this.knudContrastColourBlue.Location = new System.Drawing.Point(447, 338);
            this.knudContrastColourBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudContrastColourBlue.Name = "knudContrastColourBlue";
            this.knudContrastColourBlue.Size = new System.Drawing.Size(74, 23);
            this.knudContrastColourBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knudContrastColourBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudContrastColourBlue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudContrastColourBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudContrastColourBlue.TabIndex = 29;
            // 
            // knudContrastColourGreen
            // 
            this.knudContrastColourGreen.Location = new System.Drawing.Point(447, 295);
            this.knudContrastColourGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudContrastColourGreen.Name = "knudContrastColourGreen";
            this.knudContrastColourGreen.Size = new System.Drawing.Size(74, 23);
            this.knudContrastColourGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudContrastColourGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudContrastColourGreen.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudContrastColourGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudContrastColourGreen.TabIndex = 28;
            // 
            // knudContrastColourRed
            // 
            this.knudContrastColourRed.Location = new System.Drawing.Point(447, 252);
            this.knudContrastColourRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudContrastColourRed.Name = "knudContrastColourRed";
            this.knudContrastColourRed.Size = new System.Drawing.Size(74, 23);
            this.knudContrastColourRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudContrastColourRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudContrastColourRed.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudContrastColourRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudContrastColourRed.TabIndex = 27;
            // 
            // knudContrastColourAlpha
            // 
            this.knudContrastColourAlpha.Location = new System.Drawing.Point(447, 211);
            this.knudContrastColourAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudContrastColourAlpha.Name = "knudContrastColourAlpha";
            this.knudContrastColourAlpha.Size = new System.Drawing.Size(74, 23);
            this.knudContrastColourAlpha.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.knudContrastColourAlpha.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.knudContrastColourAlpha.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudContrastColourAlpha.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudContrastColourAlpha.TabIndex = 26;
            // 
            // klblContrastColourBlue
            // 
            this.klblContrastColourBlue.Location = new System.Drawing.Point(380, 340);
            this.klblContrastColourBlue.Name = "klblContrastColourBlue";
            this.klblContrastColourBlue.RedValue = 255;
            this.klblContrastColourBlue.Size = new System.Drawing.Size(48, 21);
            this.klblContrastColourBlue.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.klblContrastColourBlue.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.klblContrastColourBlue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblContrastColourBlue.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.klblContrastColourBlue.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.klblContrastColourBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblContrastColourBlue.TabIndex = 25;
            this.klblContrastColourBlue.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblContrastColourBlue.Values.Text = "Blue:";
            // 
            // klblContrastColourGreen
            // 
            this.klblContrastColourGreen.Location = new System.Drawing.Point(380, 297);
            this.klblContrastColourGreen.Name = "klblContrastColourGreen";
            this.klblContrastColourGreen.RedValue = 255;
            this.klblContrastColourGreen.Size = new System.Drawing.Size(61, 21);
            this.klblContrastColourGreen.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.klblContrastColourGreen.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.klblContrastColourGreen.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblContrastColourGreen.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.klblContrastColourGreen.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.klblContrastColourGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblContrastColourGreen.TabIndex = 24;
            this.klblContrastColourGreen.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblContrastColourGreen.Values.Text = "Green:";
            // 
            // klblContrastColourRed
            // 
            this.klblContrastColourRed.Location = new System.Drawing.Point(380, 254);
            this.klblContrastColourRed.Name = "klblContrastColourRed";
            this.klblContrastColourRed.RedValue = 255;
            this.klblContrastColourRed.Size = new System.Drawing.Size(45, 21);
            this.klblContrastColourRed.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.klblContrastColourRed.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.klblContrastColourRed.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblContrastColourRed.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.klblContrastColourRed.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.klblContrastColourRed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblContrastColourRed.TabIndex = 23;
            this.klblContrastColourRed.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblContrastColourRed.Values.Text = "Red:";
            // 
            // klblContrastColourAlpha
            // 
            this.klblContrastColourAlpha.AlphaValue = 255;
            this.klblContrastColourAlpha.Location = new System.Drawing.Point(380, 213);
            this.klblContrastColourAlpha.Name = "klblContrastColourAlpha";
            this.klblContrastColourAlpha.Size = new System.Drawing.Size(57, 21);
            this.klblContrastColourAlpha.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblContrastColourAlpha.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblContrastColourAlpha.TabIndex = 22;
            this.klblContrastColourAlpha.TextSize = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblContrastColourAlpha.Values.Text = "Alpha:";
            // 
            // kbtnGenerateBlueBaseColourValue
            // 
            this.kbtnGenerateBlueBaseColourValue.AutoSize = true;
            this.kbtnGenerateBlueBaseColourValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateBlueBaseColourValue.Image = null;
            this.kbtnGenerateBlueBaseColourValue.Location = new System.Drawing.Point(159, 336);
            this.kbtnGenerateBlueBaseColourValue.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueBaseColourValue.Name = "kbtnGenerateBlueBaseColourValue";
            this.kbtnGenerateBlueBaseColourValue.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueBaseColourValue.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueBaseColourValue.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueBaseColourValue.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueBaseColourValue.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueBaseColourValue.Size = new System.Drawing.Size(155, 25);
            this.kbtnGenerateBlueBaseColourValue.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueBaseColourValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueBaseColourValue.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueBaseColourValue.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueBaseColourValue.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueBaseColourValue.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueBaseColourValue.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueBaseColourValue.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueBaseColourValue.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateBlueBaseColourValue.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueBaseColourValue.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateBlueBaseColourValue.TabIndex = 21;
            this.kbtnGenerateBlueBaseColourValue.Values.Text = "Generate &Blue Value";
            // 
            // kbtnGenerateGreenColourValue
            // 
            this.kbtnGenerateGreenColourValue.AutoSize = true;
            this.kbtnGenerateGreenColourValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateGreenColourValue.Image = null;
            this.kbtnGenerateGreenColourValue.Location = new System.Drawing.Point(159, 293);
            this.kbtnGenerateGreenColourValue.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenColourValue.Name = "kbtnGenerateGreenColourValue";
            this.kbtnGenerateGreenColourValue.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenColourValue.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenColourValue.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenColourValue.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenColourValue.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenColourValue.Size = new System.Drawing.Size(167, 25);
            this.kbtnGenerateGreenColourValue.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenColourValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenColourValue.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenColourValue.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenColourValue.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenColourValue.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenColourValue.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenColourValue.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenColourValue.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateGreenColourValue.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenColourValue.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateGreenColourValue.TabIndex = 20;
            this.kbtnGenerateGreenColourValue.Values.Text = "Generate G&reen Value";
            // 
            // kbtnGenerateRedBaseColourValue
            // 
            this.kbtnGenerateRedBaseColourValue.AutoSize = true;
            this.kbtnGenerateRedBaseColourValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateRedBaseColourValue.Image = null;
            this.kbtnGenerateRedBaseColourValue.Location = new System.Drawing.Point(159, 250);
            this.kbtnGenerateRedBaseColourValue.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedBaseColourValue.Name = "kbtnGenerateRedBaseColourValue";
            this.kbtnGenerateRedBaseColourValue.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedBaseColourValue.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedBaseColourValue.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedBaseColourValue.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedBaseColourValue.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedBaseColourValue.Size = new System.Drawing.Size(152, 25);
            this.kbtnGenerateRedBaseColourValue.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedBaseColourValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedBaseColourValue.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedBaseColourValue.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedBaseColourValue.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedBaseColourValue.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedBaseColourValue.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedBaseColourValue.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedBaseColourValue.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateRedBaseColourValue.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedBaseColourValue.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateRedBaseColourValue.TabIndex = 19;
            this.kbtnGenerateRedBaseColourValue.Values.Text = "Generate &Red Value";
            // 
            // kbtnGenerateAlphaBaseColourValue
            // 
            this.kbtnGenerateAlphaBaseColourValue.AutoSize = true;
            this.kbtnGenerateAlphaBaseColourValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateAlphaBaseColourValue.Image = null;
            this.kbtnGenerateAlphaBaseColourValue.Location = new System.Drawing.Point(159, 209);
            this.kbtnGenerateAlphaBaseColourValue.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaBaseColourValue.Name = "kbtnGenerateAlphaBaseColourValue";
            this.kbtnGenerateAlphaBaseColourValue.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaBaseColourValue.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaBaseColourValue.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaBaseColourValue.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaBaseColourValue.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaBaseColourValue.Size = new System.Drawing.Size(163, 25);
            this.kbtnGenerateAlphaBaseColourValue.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaBaseColourValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaBaseColourValue.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaBaseColourValue.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaBaseColourValue.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaBaseColourValue.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaBaseColourValue.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaBaseColourValue.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaBaseColourValue.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnGenerateAlphaBaseColourValue.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlphaBaseColourValue.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnGenerateAlphaBaseColourValue.TabIndex = 18;
            this.kbtnGenerateAlphaBaseColourValue.Values.Text = "Generate &Alpha Value";
            // 
            // knudBaseBlue
            // 
            this.knudBaseBlue.Location = new System.Drawing.Point(79, 338);
            this.knudBaseBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBaseBlue.Name = "knudBaseBlue";
            this.knudBaseBlue.Size = new System.Drawing.Size(74, 23);
            this.knudBaseBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knudBaseBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBaseBlue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBaseBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBaseBlue.TabIndex = 17;
            // 
            // knudBaseGreen
            // 
            this.knudBaseGreen.Location = new System.Drawing.Point(79, 295);
            this.knudBaseGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBaseGreen.Name = "knudBaseGreen";
            this.knudBaseGreen.Size = new System.Drawing.Size(74, 23);
            this.knudBaseGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudBaseGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBaseGreen.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBaseGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBaseGreen.TabIndex = 16;
            // 
            // knudBaseRed
            // 
            this.knudBaseRed.Location = new System.Drawing.Point(79, 252);
            this.knudBaseRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBaseRed.Name = "knudBaseRed";
            this.knudBaseRed.Size = new System.Drawing.Size(74, 23);
            this.knudBaseRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudBaseRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBaseRed.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBaseRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBaseRed.TabIndex = 15;
            // 
            // knudBaseAlpha
            // 
            this.knudBaseAlpha.Location = new System.Drawing.Point(79, 211);
            this.knudBaseAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBaseAlpha.Name = "knudBaseAlpha";
            this.knudBaseAlpha.Size = new System.Drawing.Size(74, 23);
            this.knudBaseAlpha.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.knudBaseAlpha.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.knudBaseAlpha.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBaseAlpha.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBaseAlpha.TabIndex = 14;
            // 
            // klblBaseBlue
            // 
            this.klblBaseBlue.Location = new System.Drawing.Point(12, 340);
            this.klblBaseBlue.Name = "klblBaseBlue";
            this.klblBaseBlue.RedValue = 255;
            this.klblBaseBlue.Size = new System.Drawing.Size(48, 21);
            this.klblBaseBlue.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.klblBaseBlue.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.klblBaseBlue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseBlue.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.klblBaseBlue.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.klblBaseBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBaseBlue.TabIndex = 13;
            this.klblBaseBlue.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseBlue.Values.Text = "Blue:";
            // 
            // klblBaseGreen
            // 
            this.klblBaseGreen.Location = new System.Drawing.Point(12, 297);
            this.klblBaseGreen.Name = "klblBaseGreen";
            this.klblBaseGreen.RedValue = 255;
            this.klblBaseGreen.Size = new System.Drawing.Size(61, 21);
            this.klblBaseGreen.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.klblBaseGreen.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.klblBaseGreen.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseGreen.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.klblBaseGreen.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.klblBaseGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBaseGreen.TabIndex = 12;
            this.klblBaseGreen.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseGreen.Values.Text = "Green:";
            // 
            // klblBaseRed
            // 
            this.klblBaseRed.Location = new System.Drawing.Point(12, 254);
            this.klblBaseRed.Name = "klblBaseRed";
            this.klblBaseRed.RedValue = 255;
            this.klblBaseRed.Size = new System.Drawing.Size(45, 21);
            this.klblBaseRed.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.klblBaseRed.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.klblBaseRed.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseRed.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.klblBaseRed.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.klblBaseRed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBaseRed.TabIndex = 11;
            this.klblBaseRed.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseRed.Values.Text = "Red:";
            // 
            // klblBaseAlpha
            // 
            this.klblBaseAlpha.AlphaValue = 255;
            this.klblBaseAlpha.Location = new System.Drawing.Point(12, 213);
            this.klblBaseAlpha.Name = "klblBaseAlpha";
            this.klblBaseAlpha.Size = new System.Drawing.Size(57, 21);
            this.klblBaseAlpha.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBaseAlpha.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBaseAlpha.TabIndex = 10;
            this.klblBaseAlpha.TextSize = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBaseAlpha.Values.Text = "Alpha:";
            // 
            // kryptonButtonExtended2
            // 
            this.kryptonButtonExtended2.AutoSize = true;
            this.kryptonButtonExtended2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButtonExtended2.Image = null;
            this.kryptonButtonExtended2.Location = new System.Drawing.Point(274, 148);
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
            this.kryptonButtonExtended2.Size = new System.Drawing.Size(31, 25);
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
            this.kryptonButtonExtended2.TabIndex = 9;
            this.kryptonButtonExtended2.Values.Text = "<--";
            // 
            // kryptonButtonExtended1
            // 
            this.kryptonButtonExtended1.AutoSize = true;
            this.kryptonButtonExtended1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonButtonExtended1.Image = null;
            this.kryptonButtonExtended1.Location = new System.Drawing.Point(274, 76);
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
            this.kryptonButtonExtended1.Size = new System.Drawing.Size(31, 25);
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
            this.kryptonButtonExtended1.TabIndex = 5;
            this.kryptonButtonExtended1.Values.Text = "-->";
            // 
            // klblContrastColour
            // 
            this.klblContrastColour.Image = null;
            this.klblContrastColour.Location = new System.Drawing.Point(411, 12);
            this.klblContrastColour.LongTextTypeface = null;
            this.klblContrastColour.Name = "klblContrastColour";
            this.klblContrastColour.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblContrastColour.Size = new System.Drawing.Size(124, 21);
            this.klblContrastColour.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblContrastColour.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblContrastColour.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblContrastColour.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblContrastColour.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblContrastColour.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblContrastColour.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblContrastColour.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblContrastColour.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblContrastColour.TabIndex = 8;
            this.klblContrastColour.Values.Text = "Contrast Colour";
            // 
            // cpbContrastColourPreview
            // 
            this.cpbContrastColourPreview.BackColor = System.Drawing.SystemColors.Control;
            this.cpbContrastColourPreview.Location = new System.Drawing.Point(395, 39);
            this.cpbContrastColourPreview.Name = "cpbContrastColourPreview";
            this.cpbContrastColourPreview.Size = new System.Drawing.Size(167, 149);
            this.cpbContrastColourPreview.TabIndex = 7;
            this.cpbContrastColourPreview.TabStop = false;
            this.cpbContrastColourPreview.ToolTipValues = null;
            // 
            // cpbBaseColour
            // 
            this.cpbBaseColour.BackColor = System.Drawing.SystemColors.Control;
            this.cpbBaseColour.Location = new System.Drawing.Point(12, 39);
            this.cpbBaseColour.Name = "cpbBaseColour";
            this.cpbBaseColour.Size = new System.Drawing.Size(167, 149);
            this.cpbBaseColour.TabIndex = 6;
            this.cpbBaseColour.TabStop = false;
            this.cpbBaseColour.ToolTipValues = null;
            // 
            // klblBaseColour
            // 
            this.klblBaseColour.Image = null;
            this.klblBaseColour.Location = new System.Drawing.Point(49, 12);
            this.klblBaseColour.LongTextTypeface = null;
            this.klblBaseColour.Name = "klblBaseColour";
            this.klblBaseColour.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBaseColour.Size = new System.Drawing.Size(100, 21);
            this.klblBaseColour.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBaseColour.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblBaseColour.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblBaseColour.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBaseColour.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblBaseColour.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblBaseColour.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBaseColour.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblBaseColour.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblBaseColour.TabIndex = 5;
            this.klblBaseColour.Values.Text = "Base Colour";
            // 
            // KryptonContrastColourGeneratorDialog
            // 
            this.ClientSize = new System.Drawing.Size(578, 426);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kpnlButtons);
            this.Name = "KryptonContrastColourGeneratorDialog";
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbContrastColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColour)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _useForPalettes, _useColouredButtons, _accessibleUI;

        private Color _baseColour, _contrastColour;

        private ColourDialogLayoutType _colourDialogLayoutType;
        #endregion

        #region Properties
        public bool UseForPalettes { get => _useForPalettes; set => _useForPalettes = value; }

        public bool UseColouredButtons { get => _useColouredButtons; set { _useColouredButtons = value; Invalidate(); } }

        [Category("Design"), Description("If you suffer from colour blindness, it is suggested that you turn this option on.")]
        public bool UseAccessibleUI { get => _accessibleUI; set { _accessibleUI = value; Invalidate(); } }

        public Color BaseColour { get => _baseColour; set => _baseColour = value; }

        public Color ContrastColour { get => _contrastColour; set => _contrastColour = value; }

        public ColourDialogLayoutType ColourDialogLayoutType { get => _colourDialogLayoutType; set { _colourDialogLayoutType = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonContrastColourGeneratorDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void ResizeWindow(Size size) => Size = size;

        private void RelocateControls(ColourDialogLayoutType layoutType)
        {
            switch (layoutType)
            {
                case ColourDialogLayoutType.STANDARD:
                    ResizeWindow(new Size(594, 465));

                    SetControlsVisibility(ColourDialogLayoutType.STANDARD);
                    break;
                case ColourDialogLayoutType.ENHANCED:
                    break;
            }
        }

        private void SetControlsVisibility(ColourDialogLayoutType layoutType)
        {
            switch (layoutType)
            {
                case ColourDialogLayoutType.STANDARD:

                    break;
                case ColourDialogLayoutType.ENHANCED:
                    break;
            }
        }
        #endregion
    }
}